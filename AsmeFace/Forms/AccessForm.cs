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
            FillTree();
        }

        private readonly DataBase _dataBase;
        private readonly GetTree _getTree;        
        private List<EmployeeShortInfo> _employees;

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
            checkedListBox1.Items.Clear();

            _employees = _dataBase.GetEmployeeShortInfo("select e.employeeid, e.ism, e.familiya, e.otchestvo, e.otdel, e.lavozim from employee e inner join control_doors cd on e.employeeid = cd.employeeid where e.department <@ '" 
                + treeView1.SelectedNode.Name + "' order by e.employeeid desc");

            if (_employees.Count < 1)
                return;

            for (int i = 0; i < _employees.Count; i++)
            {
                checkedListBox1.Items.Add(_employees[i].Familiya + " " + _employees[i].Ism);
            }
            RetriveGrafik();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                _dataBase.InsertData("delete from access_employee where employeeid = " +
                    System.Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value));
                RetriveGrafik();
            }
        }

        private void RetriveGrafik()
        {
            dataGridView1.Rows.Clear();

            var employees = _dataBase.GetEmployeeGrafikSingle(
                "select t1.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t2.grafik_nomi " +
                "from employee t1 inner join access_employee t2 on t1.employeeid = t2.employeeid where " +
                "t1.department <@ '" + treeView1.SelectedNode.Name + "'");

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
                    if (_dataBase.CheckDB("select exists(select 1 from access_employee where employeeid = " +
                        _employees[i].ID + ")"))
                    {
                        _dataBase.InsertData("update access_employee set grafik_nomi = ' " + comboBox1.Text + "' where " +
                            "employeeid = " + _employees[i].ID);
                    }
                    else
                    {
                        _dataBase.InsertData("insert into grafik_employee (employeeid, grafik_nomi) values(" +
                            _employees[i].ID + ",'" + comboBox1.Text + "')");
                    }
                    //MessageBox.Show(employeeListbox[i].Familiya + " : " + employeeListbox[i].ID);
                }
            }
            CustomMessageBox.Info("Операция выполнена успешно!\r\nЧтобы узнать график ограничения сотрудника\r\n" +
                                "выберите отдел");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AccessSmena().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AccessGrafik().Show();
        }
    }
}
