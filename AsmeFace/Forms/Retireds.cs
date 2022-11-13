using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class Retireds : Form
    {
        public Retireds()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _tree = new GetTree();
            _asmeDevice = new AsmeDevice();
            FillTree();
            Column8.Text = Properties.Resources.GRIDVIEW_EDIT;
            Column9.Text = Properties.Resources.GRIDVIEW_HISTORY;
        }

        private readonly DataBase _dataBase;
        private readonly GetTree _tree;
        private readonly AsmeDevice _asmeDevice;
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

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            query = "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, address " +
                    "from employee where department <@ '" + treeView1.SelectedNode.Name +
                    "' and status = false order by employeeid desc";

            RetriveData(query);
        }

        private void RetriveData(string query)
        {
            dataGridView1.Rows.Clear();

            var employees = _dataBase.GetEmployee(query);

            if (employees.Count < 1)
                return;

            foreach (var employee in employees)
            {
                dataGridView1.Rows.Insert(
                    0,
                    ByteToImage(employee.Photo),
                    employee.ID,
                    employee.Familiya,
                    employee.Ism,
                    employee.TableId,
                    employee.Otdel,
                    employee.Lavozim);
            }
        }

        private Image ByteToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
                return;

            query = "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, address from employee " +
                    "where familiya ILIKE '" + SearchTextBox.Text.Trim() + "%' or ism ILIKE '" + SearchTextBox.Text.Trim() + "%' and status = false";

            RetriveData(query);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            var userID = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                new Forms.EmployeeRehire(userID).ShowDialog();
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(8) && e.RowIndex != -1)
            {
                new Forms.EmployeeHistory(userID).ShowDialog();
                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
