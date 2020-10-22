using ASMeSDK_CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class AccessForm : Form
    {
        public AccessForm()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _getTree = new GetTree();
            _asmeDevice = new AsmeDevice();
            FillTree();
            GetGrafik();
        }

        private readonly DataBase _dataBase;
        private readonly GetTree _getTree;        
        private List<EmployeeShortInfo> _employees;
        private readonly AsmeDevice _asmeDevice;
        private string query;

        private void GetGrafik()
        {
            var grafiks = _dataBase.GetStringList("select distinct access_grafik_nomi from access_grafik");
            foreach (string grafik in grafiks)
            {
                comboBox1.Items.Add(grafik);
            }
        }

        private void AccessForm_Load(object sender, EventArgs e)
        {
            //MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
            //WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillTree()
        {
            var myTrees = _dataBase.GetTree("select ttext, mytree from department order by id asc");
            for (int i = 0; i < myTrees.Count; i++)
            {
                TreeNode tnode = new TreeNode
                {
                    Name = myTrees[i].Tname,
                    Text = myTrees[i].Ttext
                };
                _getTree.FindByText(tnode, treeView1);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetEmployee("select distinct e.employeeid, e.ism, e.familiya, e.otchestvo, e.otdel, e.lavozim from employee e inner join control_doors cd on e.employeeid = cd.employeeid where e.department <@ '"
                + treeView1.SelectedNode.Name + "' and e.status = true order by e.employeeid desc");

            query = "select t1.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t2.access_grafik_nomi " +
                "from employee t1 inner join access_employee t2 on t1.employeeid = t2.employeeid where " +
                "t1.department <@ '" + treeView1.SelectedNode.Name + "' and t1.status = true";

            RetriveGrafik(query);
        }        

        private void GetEmployee(string query)
        {
            checkedListBox1.Items.Clear();

            _employees = _dataBase.GetEmployeeShortInfo(query);

            if (_employees.Count < 1)
                return;

            for (int i = 0; i < _employees.Count; i++)
            {
                checkedListBox1.Items.Add(_employees[i].Familiya + " " + _employees[i].Ism);
            }
        }

        private void RetriveGrafik(string query)
        {
            dataGridView1.Rows.Clear();

            var employees = _dataBase.GetEmployeeAccessGrafik(query);

            if (employees.Count < 1)
                return;

            //dataGridView1.Refresh();
            foreach (var employee in employees)
            {
                dataGridView1.Rows.Insert(
                    0,
                    employee.ID,
                    employee.Familiya + " " + employee.Ism + " " + employee.Otchestvo,
                    employee.Otdel,
                    employee.Lavozim,
                    employee.Grafik
                    );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                CustomMessageBox.Info("Выберите график");
                return;
            }

            if (checkedListBox1.Items.Count < 1)
                return;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    InsertOrUpdateDataBase(_employees[i].ID);

                    if (UpdateDevice(_employees[i].ID) < 0)
                        CustomMessageBox.Error("Failed");                  
                       
                    //MessageBox.Show(employeeListbox[i].Familiya + " : " + employeeListbox[i].ID);
                }
            }
            CustomMessageBox.Info("Операция выполнена!\r\nЧтобы узнать график ограничения сотрудника\r\n" +
                                "выберите отдел");
        }

        private void InsertOrUpdateDataBase(int userID)
        {
            var query = "select exists(select 1 from access_employee where employeeid = " + userID + ")";

            if (_dataBase.CheckDB(query))
                _dataBase.InsertData("update access_employee set access_grafik_nomi = '" + comboBox1.Text.Trim() + "' where employeeid = " + userID);
            else
                _dataBase.InsertData("insert into access_employee (employeeid, access_grafik_nomi) values(" + userID + ",'" + comboBox1.Text.Trim() + "')");
        }

        private int UpdateDevice(int userID)
        {
            var accesses = _dataBase.GetAccess(
                "select ae.employeeid, e.card, ag.id, ae.access_grafik_nomi, d.device_ip " +
                "from access_employee ae " +
                "inner join access_group ag on ae.access_grafik_nomi = ag.access_grafik_nomi " +
                "inner join control_doors cd on cd.employeeid = ae.employeeid " +
                "inner join devices d on d.device_mac = cd.device_mac " +
                "inner join employee e on e.employeeid = ae.employeeid " +
                "where ae.employeeid = " + userID);

            if (accesses.Count < 1)
            {
                CustomLog.WriteToFile("AccessForm access is null " + userID);
                return -1;
            }
                
            foreach(var access in accesses)
            {
                asc_STU.LPAS_ME_WEEK_SCHEDULE week = new asc_STU.LPAS_ME_WEEK_SCHEDULE
                {
                    aDaySeg = new asc_STU.AS_ME_TIME_SEG[7, 3]
                };

                for (int i = 0; i < 7; i++)
                {
                    var grafiks = _dataBase.GetAccessGrafik("select *from access_grafik where access_grafik_nomi = '" + access.Grafik + "' and kun = " + (i + 1));

                    foreach (var grafik in grafiks)
                    {
                        CustomLog.WriteToFile(i + 
                            " Boshlanishi1: " + grafik.Boshlanishi1 + "\n\r" +
                            " Tugashi1: " + grafik.Tugashi1 + "\n\r" +
                            " Boshlanishi2: " + grafik.Boshlanishi2 + "\n\r" +
                            " Tugashi2: " + grafik.Tugashi2 + "\n\r" +
                            " Boshlanishi3: " + grafik.Boshlanishi3 + "\n\r" +
                            " Tugashi3: " + grafik.Tugashi3 + "\n\r" 
                            );
                        if (!string.IsNullOrEmpty(grafik.Boshlanishi1) && !string.IsNullOrEmpty(grafik.Tugashi1))
                        {
                            week.aDaySeg[i, 0].byStartHour = (byte)Convert.ToInt32(grafik.Boshlanishi1.Substring(0, 2));
                            week.aDaySeg[i, 0].byStartMinute = (byte)Convert.ToInt32(grafik.Boshlanishi1.Substring(3, 2));
                            week.aDaySeg[i, 0].byEndHour = (byte)Convert.ToInt32(grafik.Tugashi1.Substring(0, 2));
                            week.aDaySeg[i, 0].byEndMinute = (byte)Convert.ToInt32(grafik.Tugashi1.Substring(3, 2));
                        }
                        else
                        {
                            week.aDaySeg[i, 0].byStartHour = 0;
                            week.aDaySeg[i, 0].byStartMinute = 0;
                            week.aDaySeg[i, 0].byEndHour = 23;
                            week.aDaySeg[i, 0].byEndMinute = 59;
                        }

                        if (!string.IsNullOrEmpty(grafik.Boshlanishi2) && !string.IsNullOrEmpty(grafik.Tugashi2))
                        {
                            week.aDaySeg[i, 1].byStartHour = (byte)Convert.ToInt32(grafik.Boshlanishi2.Substring(0, 2));
                            week.aDaySeg[i, 1].byStartMinute = (byte)Convert.ToInt32(grafik.Boshlanishi2.Substring(3, 2));
                            week.aDaySeg[i, 1].byEndHour = (byte)Convert.ToInt32(grafik.Tugashi2.Substring(0, 2));
                            week.aDaySeg[i, 1].byEndMinute = (byte)Convert.ToInt32(grafik.Tugashi2.Substring(3, 2));
                        }
                        else
                        {
                            week.aDaySeg[i, 1].byStartHour = 0;
                            week.aDaySeg[i, 1].byStartMinute = 0;
                            week.aDaySeg[i, 1].byEndHour = 0;
                            week.aDaySeg[i, 1].byEndMinute = 0;
                        }

                        if (!string.IsNullOrEmpty(grafik.Boshlanishi3) && !string.IsNullOrEmpty(grafik.Tugashi3))
                        {
                            week.aDaySeg[i, 2].byStartHour = (byte)Convert.ToInt32(grafik.Boshlanishi3.Substring(0, 2));
                            week.aDaySeg[i, 2].byStartMinute = (byte)Convert.ToInt32(grafik.Boshlanishi3.Substring(3, 2));
                            week.aDaySeg[i, 2].byEndHour = (byte)Convert.ToInt32(grafik.Tugashi3.Substring(0, 2));
                            week.aDaySeg[i, 2].byEndMinute = (byte)Convert.ToInt32(grafik.Tugashi3.Substring(3, 2));
                        }
                        else
                        {
                            week.aDaySeg[i, 2].byStartHour = 0;
                            week.aDaySeg[i, 2].byStartMinute = 0;
                            week.aDaySeg[i, 2].byEndHour = 0;
                            week.aDaySeg[i, 2].byEndMinute = 0;
                        }

                        //week.aDaySeg[i, 2].byStartHour = 0;
                        //week.aDaySeg[i, 2].byStartMinute = 0;
                        //week.aDaySeg[i, 2].byEndHour = 0;
                        //week.aDaySeg[i, 2].byEndMinute = 0;
                    }
                }

                if (_asmeDevice.OpenDevice(access.DeviceIp) < 0)
                {
                    CustomMessageBox.Error("Failed to open the device");
                    return -1;
                }

                if (_asmeDevice.CommunicationTest() < 0)
                {
                    CustomLog.WriteToFile("AccessForm CommunicationTest");
                    return -1;
                }

                if (_asmeDevice.SetGroup(access.GroupID, week) < 0)
                {
                    CustomLog.WriteToFile("AccessForm SetGroup " + access.GroupID);
                    return -1;
                }

                if (_asmeDevice.SetCard(access.Employeeid, access.Card, access.GroupID) < 0)
                {
                    CustomLog.WriteToFile("AccessForm SetCard " + access.GroupID);
                    return -1;
                }

                _asmeDevice.CloseDevice();
            }            
            return 1;
        }

        private int UpdateDeviceForDefault(int userID)
        {
            var accesses = _dataBase.GetAccess(
                "select ae.employeeid, e.card, ag.id, ae.access_grafik_nomi, d.device_ip " +
                "from access_employee ae " +
                "inner join access_group ag on ae.access_grafik_nomi = ag.access_grafik_nomi " +
                "inner join control_doors cd on cd.employeeid = ae.employeeid " +
                "inner join devices d on d.device_mac = cd.device_mac " +
                "inner join employee e on e.employeeid = ae.employeeid " +
                "where ae.employeeid = " + userID);

            if (accesses.Count < 1)
            {
                CustomLog.WriteToFile("AccessForm, UpdateDeviceForDefault access is null " + userID);
                return -1;
            }

            foreach (var access in accesses)
            {               
                if (_asmeDevice.OpenDevice(access.DeviceIp) < 0)
                {
                    CustomMessageBox.Error("Failed to open the device");
                    return -1;
                }

                if (_asmeDevice.CommunicationTest() < 0)
                {
                    CustomLog.WriteToFile("AccessForm CommunicationTest");
                    return -1;
                }

                if (_asmeDevice.SetGroup(0, _asmeDevice.GetDefaultWeek()) < 0)
                {
                    CustomLog.WriteToFile("AccessForm SetGroup");
                    return -1;
                }

                if (_asmeDevice.SetCard(access.Employeeid, access.Card, 0) < 0)
                {
                    CustomLog.WriteToFile("AccessForm SetCard");
                    return -1;
                }

                _asmeDevice.CloseDevice();               
            }
            return 1;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                var userID = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                if (UpdateDeviceForDefault(userID) < 0)
                {
                    CustomMessageBox.Error("Failed ");
                    return;
                }
                _dataBase.InsertData("delete from access_employee where employeeid = " + userID);
                RetriveGrafik(query);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
            }
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
                return;

            GetEmployee("select distinct e.employeeid, e.ism, e.familiya, e.otchestvo, e.otdel, e.lavozim from employee e inner join control_doors cd on e.employeeid = cd.employeeid where e.familiya ILIKE'"
                        + SearchTextBox.Text + "%' and e.status = true order by e.employeeid desc");

            query = "select t1.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t2.access_grafik_nomi " +
                            "from employee t1 inner join access_employee t2 on t1.employeeid = t2.employeeid where " +
                            "t1.familiya ILIKE '" + SearchTextBox.Text + "%' and t1.status = true";

            RetriveGrafik(query);
        }
    }
}
