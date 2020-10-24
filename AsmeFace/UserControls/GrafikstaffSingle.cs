using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class GrafikstaffSingle : UserControl
    {
        public GrafikstaffSingle()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _tree = new GetTree();
            FillTree();
            var grafiks = _dataBase.GetStringList("select distinct grafik_nomi from grafik");
            foreach (string grafik in grafiks)
            {
                comboBox1.Items.Add(grafik);
            }
        }

        private DataBase _dataBase;
        private GetTree _tree;
        private System.Collections.Generic.List<EmployeeShortInfo> _employeeShortInfo;
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
            query = "select employeeid, familiya, ism, otchestvo, otdel, " +
                "lavozim from employee where department <@ '" + treeView1.SelectedNode.Name + "' and status = true";

            GetEmployee(query);

            query = "select t1.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t2.grafik_nomi " +
                "from employee t1 inner join grafik_employee t2 on t1.employeeid = t2.employeeid where " +
                "t1.department <@ '" + treeView1.SelectedNode.Name + "' and t1.status = true";

            RetriveGrafik(query);
        }

        private void GetEmployee(string query)
        {
            dataGridView1.Rows.Clear();
            checkedListBox1.Items.Clear();

            _employeeShortInfo = _dataBase.GetEmployeeShortInfo(query);

            if (_employeeShortInfo.Count < 1)
                return;

            for (int i = 0; i < _employeeShortInfo.Count; i++)
            {
                checkedListBox1.Items.Add(_employeeShortInfo[i].Familiya);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //MessageBox.Show(employeeListbox[checkedListBox1.SelectedIndex].ID);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                CustomMessageBox.Info(Properties.Resources.SHIFT_CHOOSE);
                return;
            }
            if (checkedListBox1.Items.Count < 1)
                return;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (_dataBase.CheckDB("select exists(select 1 from grafik_employee where employeeid = " +
                        _employeeShortInfo[i].ID + ")"))
                    {
                        _dataBase.InsertData("update grafik_employee set grafik_nomi = ' " + comboBox1.Text + "' where " +
                            "employeeid = " + _employeeShortInfo[i].ID);
                    }
                    else
                    {
                        _dataBase.InsertData("insert into grafik_employee (employeeid, grafik_nomi) values(" +
                            _employeeShortInfo[i].ID + ",'" + comboBox1.Text + "')");
                    }
                    //MessageBox.Show(employeeListbox[i].Familiya + " : " + employeeListbox[i].ID);
                }
            }
            CustomMessageBox.Info(Properties.Resources.CONTROL_GRAFIK_STAFF_SUCCESS_INFO);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                _dataBase.InsertData("delete from grafik_employee where employeeid = " +
                    System.Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value));
                RetriveGrafik(query);
            }
        }

        private void RetriveGrafik(string query)
        {
            dataGridView1.Rows.Clear();

            var employeeGrafiks = _dataBase.GetEmployeeGrafikSingle(query);

            if (employeeGrafiks.Count < 1)
                return;
            
            //dataGridView1.Refresh();
            foreach (var employeeGrafik in employeeGrafiks)
            {
                dataGridView1.Rows.Insert(
                    0,
                    employeeGrafik.ID,
                    employeeGrafik.Familiya + " " + employeeGrafik.Ism + " " + employeeGrafik.Otchestvo,
                    employeeGrafik.Otdel,
                    employeeGrafik.Lavozim,
                    employeeGrafik.Grafik
                    );
            }
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
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

            var searchQuery = SearchTextBox.Text.Trim();

            query = "select employeeid, familiya, ism, otchestvo, otdel, lavozim from employee where familiya ILIKE '" +
                searchQuery + "%' and status = true";

            GetEmployee(query);

            query = "select t1.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t2.grafik_nomi " +
                "from employee t1 inner join grafik_employee t2 on t1.employeeid = t2.employeeid where " +
                "t1.familiya ILIKE '" + searchQuery + "%' and t1.status = true";

            RetriveGrafik(query);
        }
    }
}
