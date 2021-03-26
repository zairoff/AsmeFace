using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class Staff : UserControl
    {
        private List<Employee> employees;

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
            Column11.Text = Properties.Resources.GRIDVIEW_HISTORY;

            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.dataGridView1.CellValueNeeded += new
            DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);          
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {          
            //if (employees.Count < 1)
            //    return;

            //try
            //{
            //    if (e.RowIndex == this.dataGridView1.RowCount - 1) return;

            //    Employee employee = this.employees[e.RowIndex];                    

            //    // Set the cell value to paint using the Customer object retrieved.
            //    switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
            //    {
            //        case "Column2":
            //            e.Value = employee.ID;
            //            break;

            //        case "Column1":
            //            e.Value = ByteToImage(employee.Photo);
            //            break;

            //        case "Column3":
            //            e.Value = employee.Familiya;
            //            break;

            //        case "Column4":
            //            e.Value = employee.Ism;
            //            break;

            //        case "Column5":
            //            e.Value = employee.Otchestvo;
            //            break;

            //        case "Column6":
            //            e.Value = employee.Otdel;
            //            break;

            //        case "Column7":
            //            e.Value = employee.Lavozim;
            //            break;
            //    }
            //}
            //catch (Exception msg)
            //{
            //    CustomMessageBox.Error(msg.ToString());
            //}            
        }

        private readonly DataBase _dataBase;
        private readonly GetTree _tree;
        private readonly AsmeDevice _asmeDevice;
        private string query;

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
            query = "select employeeid," +
                "photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, address from employee " +
                "where department <@ '" + treeView1.SelectedNode.Name + "' and status = true order by employeeid desc";

            RetriveData(query);

            ShowEmployeeCount();
        }

        private void RetriveData(string query)
        {
            dataGridView1.Rows.Clear();

            //employees = _dataBase.GetEmployee(query);
            //dataGridView1.RowCount = employees.Count + 1;
            _dataBase.GetRecords(query, dataGridView1);

            //if (employees.Count < 1)
            //    return;

            //foreach (var employee in employees)
            //{
            //    dataGridView1.Rows.Insert(
            //        0,
            //        ByteToImage(employee.Photo),
            //        employee.ID,
            //        employee.Familiya,
            //        employee.Ism,
            //        employee.Otchestvo,
            //        employee.Otdel,
            //        employee.Lavozim);
            //}            
        }

        private void ShowEmployeeCount()
        {
            if (treeView1.SelectedNode == treeView1.Nodes[0])
                label1.Text = treeView1.SelectedNode.Text + " | " + Properties.Resources.CONTROL_STAFF_EMPLOYEE_COUNT + dataGridView1.Rows.Count;
            else
                label1.Text = treeView1.SelectedNode.Text + " | " + Properties.Resources.CONTROL_STAFF_EMPLOYEE_COUNT +  dataGridView1.Rows.Count;
        }

        private System.Drawing.Image ByteToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            var userID = Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                new Forms.EmployeeEdit(userID).ShowDialog();
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(8) && e.RowIndex != -1)
            {
                var retire = new Forms.Retire(userID);
                retire.Notify += NotifyHandler;
                retire.ShowDialog();
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(9) && e.RowIndex != -1)
            {
                if (UpdateOrDeleteEmployee(userID, "delete from employee where employeeid = " + userID))
                    RetriveData(query);

                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(10) && e.RowIndex != -1)
            {
                new Forms.EmployeeHistory(userID).ShowDialog();               
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

            query = "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, address from employee " +
                    "where familiya ILIKE '" + SearchTextBox.Text.Trim() + "%' and status = true";

            RetriveData(query);
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            new Forms.Retireds().ShowDialog();
        }
    }
}
