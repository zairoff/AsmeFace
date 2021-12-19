using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class EmployeeInDevice : Form
    {
        public EmployeeInDevice()
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
        private string query;

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
                _tree.FindByText(tnode, treeView1);
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            query = "select t2.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t3.device_mac, t3.device_ip, t3.device_type," +
                    "t3.device_status, t3.device_door from control_doors t2 " +
                    "inner join employee t1 on t1.employeeid = t2.employeeid " +
                    "inner join devices t3 on t3.device_mac = t2.device_mac " +
                    "where department <@ '" + treeView1.SelectedNode.Name + "' and status = true order by employeeid desc";

            RetriveData(query);
        }

        private void RetriveData(string query)
        {
            var employees = _dataBase.GetEmployeeInDevices(query);

            dataGridView1.Rows.Clear();

            foreach (var employee in employees)
            {
                dataGridView1.Rows.Insert(
                    0,
                    false,
                    employee.DeviceInfo.dwIPAddress,
                    employee.DeviceInfo.szMac,
                    employee.DeviceInfo.dwType,
                    employee.DeviceInfo.dwDoor,
                    employee.DeviceInfo.dwStatus,
                    employee.EmployeeShortInfo.ID,
                    employee.EmployeeShortInfo.Familiya + " " +
                    employee.EmployeeShortInfo.Ism + " " +
                    employee.EmployeeShortInfo.Otchestvo);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                Delete(
                    dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                    dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                    dataGridView1.CurrentRow.Cells[2].Value.ToString(),
                    Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value));

                CustomMessageBox.Info(Properties.Resources.OPERATION_SUCCESS);
                RetriveData(query);

                //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                //int nRes = _asmeDevice.OpenDevice(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                //if (nRes < 0)
                //{
                //    CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_OPEN);
                //    return;
                //}

                //nRes = _asmeDevice.DeleteCard(Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value));

                //if (nRes < 0)
                //{
                //    CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_INFO);
                //    _asmeDevice.CloseDevice();
                //    return;
                //}

                //if (string.Equals(dataGridView1.CurrentRow.Cells[2].Value.ToString(), "Finger"))
                //{
                //    nRes = _asmeDevice.DeleteFinger(Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value));
                //    if (nRes < 0)
                //    {
                //        CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_INFO);
                //        _asmeDevice.CloseDevice();
                //        return;
                //    }
                //}

                //if (string.Equals(dataGridView1.CurrentRow.Cells[2].Value.ToString(), "Face"))
                //{
                //    nRes = _asmeDevice.DeleteFace(Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value));
                //    if (nRes < 0)
                //    {
                //        CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_INFO);
                //        _asmeDevice.CloseDevice();
                //        return;
                //    }
                //}

                //_asmeDevice.CloseDevice();

                //if (_dataBase.InsertData("delete from control_doors where device_mac = '" +
                //    dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' and employeeid = " +
                //    Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value)))
                //{
                //    CustomMessageBox.Info(Properties.Resources.OPERATION_SUCCESS);
                //    RetriveData(query);
                //}
            }
        }

        private void Delete(string ip, string deviceType, string mac, int userId)
        {
            int nRes = _asmeDevice.OpenDevice(ip);
            if (nRes < 0)
            {
                CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_OPEN);
                return;
            }

            nRes = _asmeDevice.DeleteCard(userId);

            if (nRes < 0)
            {
                CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_INFO);
                _asmeDevice.CloseDevice();
                return;
            }

            if (string.Equals(deviceType, "Finger"))
            {
                nRes = _asmeDevice.DeleteFinger(userId);
                if (nRes < 0)
                {
                    CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_INFO);
                    _asmeDevice.CloseDevice();
                    return;
                }
            }

            if (string.Equals(deviceType, "Face"))
            {
                nRes = _asmeDevice.DeleteFace(userId);
                if (nRes < 0)
                {
                    CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_INFO);
                    _asmeDevice.CloseDevice();
                    return;
                }
            }

            _asmeDevice.CloseDevice();

            _dataBase.InsertData("delete from control_doors where device_mac = '" + mac + "' and employeeid = " + userId);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
                return;

            query = "select t2.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t3.device_mac, t3.device_ip, t3.device_type," +
                    "t3.device_status, t3.device_door from control_doors t2 " +
                    "inner join employee t1 on t1.employeeid = t2.employeeid " +
                    "inner join devices t3 on t3.device_mac = t2.device_mac " +
                    "where t1.familiya ILIKE '" + SearchTextBox.Text.Trim() + "%' or " +
                    "t1.ism ILIKE '" + SearchTextBox.Text.Trim() + "%' and status = true order by employeeid desc";

            RetriveData(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if(Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    Delete(
                        row.Cells[1].Value.ToString(),
                        row.Cells[3].Value.ToString(),
                        row.Cells[2].Value.ToString(),
                        Convert.ToInt32(row.Cells[6].Value)
                        );
                }
                
            }

            CustomMessageBox.Info(Properties.Resources.OPERATION_SUCCESS);
            RetriveData(query);
        }
    }
}
