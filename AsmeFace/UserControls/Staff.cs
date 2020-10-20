using System;
using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class Staff : UserControl
    {
        public Staff()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _tree = new GetTree();
            _asmeDevice = new AsmeDevice();
            FillTree();
        }

        private DataBase _dataBase;
        private GetTree _tree;
        private AsmeDevice _asmeDevice;

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

        private void button1_Click(object sender, EventArgs e)
        {
            new Forms.EmployeeAdd().ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RetriveData("select employeeid," +
                "photo, finger, card, ism, familiya, otchestvo, otdel, lavozim from employee " +
                "where department <@ '" + treeView1.SelectedNode.Name + "' and status = true order by employeeid desc");

            ShowEmployeeCount();
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
                    employee.Otchestvo,
                    employee.Otdel,
                    employee.Lavozim);
            }            
        }

        private void ShowEmployeeCount()
        {
            if (treeView1.SelectedNode == treeView1.Nodes[0])
                label1.Text = treeView1.SelectedNode.Text + " | количество сотрудников: " + dataGridView1.Rows.Count;
            else
                label1.Text = "Отдел: " + treeView1.SelectedNode.Text + " | количество сотрудников: " + dataGridView1.Rows.Count;
        }

        private System.Drawing.Image ByteToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            var userID = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                new Forms.EmployeeAdd(userID).ShowDialog();
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(8) && e.RowIndex != -1)
            {
                if (UpdateOrDeleteEmployee(userID, "update employee set status = false where employeeid = " + userID))
                    dataGridView1.Rows.Clear();
                //{
                //    RetriveData("select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim from employee " +
                //                "where department <@ '" + treeView1.SelectedNode.Name + "' and status = true order by employeeid desc");
                //    ShowEmployeeCount();
                //}
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(9) && e.RowIndex != -1)
            {
                if (UpdateOrDeleteEmployee(userID, "delete from employee where employeeid = " + userID))
                    dataGridView1.Rows.Clear();
                //{
                //    RetriveData("select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim from employee " +
                //                "where department <@ '" + treeView1.SelectedNode.Name + "' and status = true order by employeeid desc");
                //    ShowEmployeeCount();
                //}                
                return;
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
            }

            //var query = "update employee set status = false where employeeid = " + userID);
            //var query = "delete from employee where employeeid = " + userID);
            return _dataBase.InsertData(query);
                
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
                return;

            var query = "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim from employee " +
                "where familiya ILIKE '" + SearchTextBox.Text.Trim() + "%' and status = true";

            RetriveData(query);
        }
    }
}
