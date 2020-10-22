using System;
using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class GrafikStaff : UserControl
    {
        public GrafikStaff()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _tree = new GetTree();
            FillTree();
            var smenas = _dataBase.GetStringList("select distinct grafik_nomi from grafik");
            foreach (string smena in smenas)
            {
                comboBox1.Items.Add(smena);
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

            query = "select t1.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t2.grafik_nomi, " +
                "t2.dan, t2.gacha from employee t1 inner join grafik_employee t2 on t1.employeeid = t2.employeeid where " +
                "(t1.department <@ '" + treeView1.SelectedNode.Name + "' and t1.status = true and t2.dan >= '" + dateTimePicker1.Text + "'" +
                "and t2.dan <= '" + dateTimePicker2.Text + "') or (t1.department <@ '" + treeView1.SelectedNode.Name + "'" +
                " and t1.status = true and t2.gacha >= '" + dateTimePicker1.Text + "' and t2.gacha <= '" + dateTimePicker2.Text + "')" +
                "or (t1.department <@ '" + treeView1.SelectedNode.Name + "' and t1.status = true and " +
                "'" + dateTimePicker1.Text + "' >= t2.dan and '" + dateTimePicker2.Text + "' <= t2.gacha)";

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
                CustomMessageBox.Info("Выберите график");
                return;
            }

            if (checkedListBox1.Items.Count < 1)
                return;

            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                CustomMessageBox.Info("Число должна быть установлена ​​на будущее");
                return;
            }

            textBox1.Text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if(_dataBase.CheckDB("select exists(select 1 from grafik_employee where (employeeid = " + 
                        _employeeShortInfo[i].ID + " and dan >= '" + dateTimePicker1.Text + "' and dan <= '" + 
                        dateTimePicker2.Text + "') or (employeeid = " + _employeeShortInfo[i].ID + " and gacha >= '" 
                        + dateTimePicker1.Text + "' and gacha <= '" + dateTimePicker2.Text + "') or (employeeid = "
                        + _employeeShortInfo[i].ID + " and '" + dateTimePicker1.Text + "' >= dan and '" 
                        + dateTimePicker1.Text + "' <= gacha) or (employeeid = " + _employeeShortInfo[i].ID + " and '" 
                        + dateTimePicker2.Text + "' >= dan and '" + dateTimePicker1.Text +"' <= gacha))"))
                    {                        
                        textBox1.Text += ("У сотрудника: " + _employeeShortInfo[i].Familiya + " есть график в этом периоде\r\n");
                        //MessageBox.Show("У сотрудника: " + employeeListbox[i].Familiya + " есть график в этом периоде");
                        //listBox1.Items.(0, "У сотрудника: " + employeeListbox[i].Familiya + " есть график в этом периоде");
                    }
                    else
                    {
                        _dataBase.InsertData("insert into grafik_employee (employeeid, grafik_nomi, dan, gacha) values(" +
                            _employeeShortInfo[i].ID + ",'" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" +
                            dateTimePicker2.Text + "')");
                    }
                    //MessageBox.Show(employeeListbox[i].Familiya + " : " + employeeListbox[i].ID);
                }
            }
            CustomMessageBox.Info("Операция выполнена успешно!\r\nЧтобы узнать график сотрудника\r\nвыберите период времени и отдел");
            textBox1.Text += "Заверщено!\r\n";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
                {
                    _dataBase.InsertData("delete from grafik_employee where grafik_nomi = '" + dataGridView1[4,
                        dataGridView1.CurrentRow.Index].Value.ToString() + "' and employeeid = " + System.Convert.ToInt32(dataGridView1[0,
                        dataGridView1.CurrentRow.Index].Value) + " and dan = '" + dataGridView1[5,
                        dataGridView1.CurrentRow.Index].Value.ToString() + "' and gacha = '" + dataGridView1[6,
                        dataGridView1.CurrentRow.Index].Value.ToString() + "'");

                    RetriveGrafik(query);
                    return;
                }

                if (dataGridView1.CurrentCell.ColumnIndex.Equals(8) && e.RowIndex != -1)
                {
                    new Forms.GrafikView(System.Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value),
                        dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString(),
                        dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString(),
                        dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString()).ShowDialog();
                }
            }
            catch (Exception msg)
            {
                CustomMessageBox.Error(msg.ToString());
            }            
        }

        private void RetriveGrafik(string query)
        {
            dataGridView1.Rows.Clear();

            var employeeGrafiks = _dataBase.GetEmployeeGrafik(query);

            if (employeeGrafiks.Count < 1)
                return;

            //dataGridView1.Refresh();
            foreach (EmployeeGrafik employeeGrafik in employeeGrafiks)
            {
                dataGridView1.Rows.Insert(
                    0,
                    employeeGrafik.ID,
                    employeeGrafik.Familiya + " " + employeeGrafik.Ism + " " + employeeGrafik.Otchestvo,
                    employeeGrafik.Otdel,
                    employeeGrafik.Lavozim,
                    employeeGrafik.Grafik,
                    employeeGrafik.Dan,
                    employeeGrafik.Gacha);
            }
            //MessageBox.Show(treeView1.SelectedNode.Name);
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

            query = "select t1.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t2.grafik_nomi, " +
                "t2.dan, t2.gacha from employee t1 inner join grafik_employee t2 on t1.employeeid = t2.employeeid where " +
                "(t1.familiya ILIKE '" + searchQuery + "%' and t1.status = true and t2.dan >= '" + dateTimePicker1.Text + "'" +
                "and t2.dan <= '" + dateTimePicker2.Text + "') or (t1.familiya ILIKE '" + searchQuery + "%'" +
                " and t1.status = true and t2.gacha >= '" + dateTimePicker1.Text + "' and t2.gacha <= '" + dateTimePicker2.Text + "')" +
                "or (t1.familiya ILIKE '" + searchQuery + "%' and t1.status = true and " +
                "'" + dateTimePicker1.Text + "' >= t2.dan and '" + dateTimePicker2.Text + "' <= t2.gacha)";

            RetriveGrafik(query);
        }
    }
}
