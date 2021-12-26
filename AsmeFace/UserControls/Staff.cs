using AsmeFace.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class Staff : UserControl
    {
        private readonly DataBase _dataBase;
        private readonly GetTree _tree;
        private readonly AsmeDevice _asmeDevice;
        private string query;
        private int _databaseOffset = 0;
        private int _dataBaseLimit = 10;
        private IList<Employee> employees;
        private int _employeeCount;

        public Staff()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _tree = new GetTree();
            _asmeDevice = new AsmeDevice();
            FillTree();
            Column8.Text = Properties.Resources.GRIDVIEW_EDIT;
            Column9.Text = Properties.Resources.GRIDVIEW_RETIRE;
            Column10.Text = Properties.Resources.GRIDVIEW_DELETE;
            Column12.Text = Properties.Resources.GRIDVIEW_HISTORY;        
        }       

        public void NotifyHandler(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

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

        private void Button1_Click(object sender, EventArgs e)
        {
            new Forms.EmployeeHire().ShowDialog();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            query = "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, " +
                    "address, address, enrollment_number, amizone_code from employee where department <@ '" + treeView1.SelectedNode.Name +
                    "' and status = true order by employeeid asc limit " + _dataBaseLimit;

            _databaseOffset = 0;

            RetriveData(query);

            ShowEmployeeCount();
        }

        private void RetriveData(string query)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;

            employees = _dataBase.GetEmployee(query);

            if (employees.Count < 1)
                return;           

            for(int i = employees.Count - 1; i >= 0; i--)
            {
                dataGridView1.Rows.Insert(
                    0,
                    ByteToImage(employees[i].Photo),
                    employees[i].ID,
                    employees[i].Familiya,
                    employees[i].Ism,
                    employees[i].Otchestvo,
                    employees[i].Otdel,
                    employees[i].Lavozim,
                    employees[i].Amizone_code,
                    employees[i].Enrollment_number);
            }
        }       

        private void ShowEmployeeCount()
        {
            _employeeCount = _dataBase.GetID("select count(*) from employee where department <@ '" +
                          treeView1.SelectedNode.Name + "' and status = true");

            label1.Text = treeView1.SelectedNode.Text + " | " +
                          Properties.Resources.CONTROL_STAFF_EMPLOYEE_COUNT + _employeeCount;
        }

        private System.Drawing.Image ByteToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private bool UpdateOrDeleteEmployee(int userID, string query)
        {
            var devices = _dataBase.GetDevices("select *from devices");

            if (devices.Count < 1)
                return false;

            foreach (var device in devices)
            {
                int nRes = _asmeDevice.OpenDevice(device.dwIPAddress);
                if (nRes < 0)
                {
                    CustomMessageBox.Error(
                        "Failed to open device "
                        + device.dwIPAddress +
                        " : " + _asmeDevice.GetResponse(nRes));
                    return false;
                }               

                nRes = _asmeDevice.DeleteCard(userID);

                if (nRes < 0)
                {
                    CustomMessageBox.Error("Failed to delete card, device "
                        + device.dwIPAddress +
                        " : " + _asmeDevice.GetResponse(nRes));
                    _asmeDevice.CloseDevice();
                    return false;
                }

                if (device.dwType.Equals("Face"))
                {
                    CustomLog.WriteToFile("sTAFF " + userID);
                    nRes = _asmeDevice.DeleteFace(userID);
                    if (nRes < 0)
                    {
                        CustomMessageBox.Error("Failed to delete face, device "
                            + device.dwIPAddress +
                            " : " + _asmeDevice.GetResponse(nRes));
                        _asmeDevice.CloseDevice();
                        return false;
                    }
                }

                if (device.dwType.Equals("Finger"))
                {
                    nRes = _asmeDevice.DeleteFinger(userID);
                    if (nRes < 0)
                    {
                        CustomMessageBox.Error("Failed to delete fingerprint, device "
                            + device.dwIPAddress +
                            " : " + _asmeDevice.GetResponse(nRes));
                        _asmeDevice.CloseDevice();
                        return false;
                    }
                }
                _asmeDevice.CloseDevice();
            }

            //var query = "update employee set status = false where employeeid = " + userID);
            //var query = "delete from employee where employeeid = " + userID);
            return _dataBase.InsertData(query);
                
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
                return;

            query = "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, address, " +
                    "enrollment_number, amizone_code from employee where familiya ILIKE '"
                    + SearchTextBox.Text.Trim() + "%' or ism ILIKE '" + SearchTextBox.Text.Trim() +
                    "%' and status = true order by employeeid asc limit " + _dataBaseLimit;

            _databaseOffset = 0;

            RetriveData(query);
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            new BulkRegister().Show();
        }

        private void forwardBtn_MouseEnter(object sender, EventArgs e)
        {
            forwardBtn.Image = Properties.Resources.right_arrow_light;
        }

        private void forwardBtn_MouseLeave(object sender, EventArgs e)
        {
            forwardBtn.Image = Properties.Resources.right_arrow;
        }

        private void backBtn_MouseEnter(object sender, EventArgs e)
        {
            backBtn.Image = Properties.Resources.left_arrow_light;
        }

        private void backBtn_MouseLeave(object sender, EventArgs e)
        {
            backBtn.Image = Properties.Resources.left_arrow;
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count == 0 || treeView1.SelectedNode == null || _employeeCount < _dataBaseLimit)
                return;

            _databaseOffset += _dataBaseLimit;
            query = "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, " +
                    "address, enrollment_number, amizone_code from employee where department <@ '" + treeView1.SelectedNode.Name +
                    "' and status = true order by employeeid asc LIMIT " + _dataBaseLimit + " OFFSET " + _databaseOffset;

            RetriveData(query);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (_databaseOffset < _dataBaseLimit || treeView1.Nodes.Count == 0 || treeView1.SelectedNode == null)
                return;

            _databaseOffset -= _dataBaseLimit;
            query = "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, " +
                    "address, enrollment_number, amizone_code from employee where department <@ '" + treeView1.SelectedNode.Name +
                    "' and status = true order by employeeid asc LIMIT " + _dataBaseLimit + " OFFSET " + _databaseOffset;

            RetriveData(query);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            var userID = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(9) && e.RowIndex != -1)
            {
                new Forms.EmployeeEdit(userID).ShowDialog();
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(10) && e.RowIndex != -1)
            {
                var retire = new Forms.Retire(userID);
                retire.Notify += NotifyHandler;
                retire.ShowDialog();
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(11) && e.RowIndex != -1)
            {
                if (UpdateOrDeleteEmployee(userID, "delete from employee where employeeid = " + userID))
                    RetriveData(query);
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(12) && e.RowIndex != -1)
            {
                new Forms.EmployeeHistory(userID).ShowDialog();
                return;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new Forms.Retireds().ShowDialog();
        }
    }
}
