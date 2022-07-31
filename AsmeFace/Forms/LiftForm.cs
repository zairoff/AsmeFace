using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class LiftForm : Form
    {
        public LiftForm()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _tree = new GetTree();
            FillTree();
            GetLifts();
        }

        private DataBase _dataBase;
        private GetTree _tree;
        private List<Employee> _employees;
        private List<Lift> _lifts;
        private string query;

        private void FillTree()
        {
            var trees = _dataBase.GetTree("select ttext, mytree from department order by id asc");
            for (int i = 0; i < trees.Count; i++)
            {
                TreeNode tnode = new TreeNode
                {
                    Name = trees[i].Tname,
                    Text = trees[i].Ttext
                };
                _tree.FindByText(tnode, treeView1);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            query = "select employeeid, finger, photo, card, familiya, ism, otchestvo, otdel, lavozim, address from employee where department <@ '" + treeView1.SelectedNode.Name + "' and status = true";

            GetEmployee(query);

            GetLiftControl();
        }

        private void GetEmployee(string query)
        {

            _employees = _dataBase.GetEmployee(query);

            if (_employees.Count < 1)
                return;

            checkedListBox1.Items.Clear();

            for (int i = 0; i < _employees.Count; i++)
            {
                checkedListBox1.Items.Add(_employees[i].Familiya + " " + _employees[i].Ism);
            }
        }

        private void GetLifts()
        {
            _lifts = _dataBase.GetLifts("select *from lift");

            if (_lifts.Count < 1)
                return;

            checkedListBox2.Items.Clear();

            for (int i = 0; i < _lifts.Count; i++)
            {
                checkedListBox2.Items.Add(_lifts[i].Name);
            }
        }

        private void GetLiftControl()
        {
            var liftControls = _dataBase.GetLiftControl("select e.employeeid, e.ism, e.familiya, e.card, l.name, l.serinniy, l.address from employee e inner " +
                    "join control_lift c on e.employeeid = c.employeeid inner join lift l on c.serinniy = l.serinniy where e.department <@ '" + treeView1.SelectedNode.Name + "' and status = true");

            if (liftControls.Count < 1)
                return;

            dataGridView1.Rows.Clear();

            foreach (var liftControl in liftControls)
            {
                dataGridView1.Rows.Insert(0, false, liftControl.Lift.Name, liftControl.Lift.Serinniy, liftControl.Lift.IP, liftControl.Employee.ID,
                                        $"{liftControl.Employee.Ism} {liftControl.Employee.Familiya}", liftControl.Employee.Card);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var success = AddOrDeleteLift("192.168.100.11", "175110119", "11277717", 1);

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkedListBox2.GetItemChecked(i))
                {
                    for (int j = 0; j < checkedListBox1.Items.Count; j++)
                    {
                        if (checkedListBox1.GetItemChecked(j))
                        {
                            if (!_dataBase.CheckDB("select exists(select 1 from control_lift where employeeid = " + _employees[j].ID + " and serinniy = '" + _lifts[i].Serinniy + "')"))
                            {
                                if (string.IsNullOrEmpty(_employees[j].Card))
                                    continue;

                                var success = AddOrDeleteLift(_lifts[i].IP, _lifts[i].Serinniy, _employees[j].Card, 1);

                                if (success)
                                {
                                    try
                                    {
                                        _dataBase.InsertData("insert into control_lift (serinniy, employeeid) values ('" + _lifts[i].Serinniy + "', " + _employees[j].ID + ")");
                                        GetLiftControl();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private byte[] Dec_to_hex(string dec_num)
        {
            string hex = int.Parse(dec_num).ToString("x");
            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
                if (hex.Length < 8)
                    hex = "00" + hex;
            }
            else if (hex.Length < 8)
            {
                hex = "00" + hex;
                if (hex.Length < 8)
                    hex = "00" + hex;
            }
            return Enumerable.Range(0, hex.Length).Where<int>((Func<int, bool>)(x => x % 2 == 0)).Select<int, byte>((Func<int, byte>)(x => Convert.ToByte(hex.Substring(x, 2), 16))).ToArray<byte>();
        }

        private string Get_num(string dec_num)
        {
            int num = int.Parse(dec_num);
            string str1 = "00000000";
            string str2 = num.ToString("x");
            string str3 = str1.Substring(0, 8 - str2.Length) + str2;
            int int32 = Convert.ToInt32(str3.Substring(0, 4), 16);
            string str4 = Convert.ToInt32(str3.Substring(4, 4), 16).ToString();
            return int32.ToString() + "00000".Substring(0, 5 - str4.Length) + str4;
        }

        private bool AddOrDeleteLift(string ip, string serinniy, string card, byte status)
        {
            try
            {
                int port = 60000;
                var tcpClient = new TcpClient(ip, port);
                byte[] hex1 = this.Dec_to_hex(serinniy);
                byte[] hex2 = this.Dec_to_hex(this.Get_num(card));
                char[] chArray = new char[8];
                char[] chArray2 = new char[8];
                char[] chArray3 = new char[4];

                int index1 = 0;
                for (int i = checkedListBox3.Items.Count - 1; i >= 0; --i)
                {
                    chArray[index1] = checkedListBox3.GetItemCheckState(i) == CheckState.Checked ? '1' : '0';
                    ++index1;
                }

                index1 = 0;
                for (int i = checkedListBox4.Items.Count - 1; i >= 0; --i)
                {
                    chArray2[index1] = checkedListBox4.GetItemCheckState(i) == CheckState.Checked ? '1' : '0';
                    ++index1;
                }

                index1 = 0;
                for (int i = checkedListBox5.Items.Count - 1; i >= 0; --i)
                {
                    chArray3[index1] = checkedListBox5.GetItemCheckState(i) == CheckState.Checked ? '1' : '0';
                    ++index1;
                }

                var str1 = new string(chArray, 0, 8);
                var str2 = new string(chArray2, 0, 8);
                var str3 = new string(chArray3, 0, 4);

                var binary1 = Convert.ToInt32(str1, 2);
                var binary2 = Convert.ToInt32(str2, 2);
                var binary3 = Convert.ToInt32(str3, 2);

                string hex_dostup1 = binary1.ToString("X4");
                string hex_dostup2 = binary2.ToString("X4");
                string hex_dostup3 = binary3.ToString("X4");

                if (hex_dostup1.Length == 1)
                    hex_dostup1 = $"0{hex_dostup1}";

                if (hex_dostup2.Length == 1)
                    hex_dostup2 = $"0{hex_dostup2}";

                if (hex_dostup3.Length == 1)
                    hex_dostup3 = $"0{hex_dostup3}";

                byte[] array1 = Enumerable.Range(0, hex_dostup1.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex_dostup1.Substring(x, 2), 16)).ToArray();
                byte[] array2 = Enumerable.Range(0, hex_dostup2.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex_dostup2.Substring(x, 2), 16)).ToArray();
                byte[] array3 = Enumerable.Range(0, hex_dostup3.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex_dostup3.Substring(x, 2), 16)).ToArray();

                byte[] numArray1 = new byte[64]
                {
                  (byte) 23,
                  (byte) 80,
                  (byte) 0,
                  (byte) 0,
                  hex1[3],
                  hex1[2],
                  hex1[1],
                  hex1[0],
                  hex2[3],
                  hex2[2],
                  hex2[1],
                  hex2[0],
                  (byte) 32,
                  (byte) 25,
                  (byte) 5,
                  (byte) 36,
                  (byte) 32,
                  (byte) 41,
                  (byte) 8,
                  (byte) 36,
                  status,
                  array1[1],
                  array2[1],
                  array3[1],
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0,
                  (byte) 0
                };

                NetworkStream stream = tcpClient.GetStream();
                stream.Write(numArray1, 0, numArray1.Length);
                byte[] numArray2 = new byte[64];
                string empty = string.Empty;
                stream.Read(numArray2, 0, numArray2.Length);
                stream.Close();
                tcpClient.Close();
                return true;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, checkBox2.Checked);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, checkBox3.Checked);
            }

            for (int i = 0; i < checkedListBox4.Items.Count; i++)
            {
                checkedListBox4.SetItemChecked(i, checkBox3.Checked);
            }

            for (int i = 0; i < checkedListBox5.Items.Count; i++)
            {
                checkedListBox5.SetItemChecked(i, checkBox3.Checked);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                var address = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                var serinniy = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                var card = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                var employeeid = Convert.ToInt32(dataGridView1[4, dataGridView1.CurrentRow.Index].Value);

                var success = AddOrDeleteLift(address, serinniy, card, 0);

                if (success)
                {
                    if(_dataBase.InsertData("delete from control_lift where employeeid = " + employeeid + " and serinniy = '" + serinniy + "'"))
                    {
                        dataGridView1.Rows.Clear();
                        GetLiftControl();
                    }
                }
            }
            return;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {

            }
        }
    }
}
