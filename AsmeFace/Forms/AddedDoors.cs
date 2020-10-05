using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class AddedDoors : Form
    {
        public AddedDoors()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            GetDoors();
        }

        private DataBase _dataBase;

        private void GetDoors()
        {
            var devices = _dataBase.GetDevices("select *from devices");

            if (devices.Count < 1)
                return;

            foreach (var device in devices)
            {
                dataGridView1.Rows.Insert(0, device.szMac, device.dwIPAddress, device.dwType, device.dwStatus, device.dwDoor);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                if (_dataBase.InsertData("delete from devices where device_mac = '"
                    + dataGridView1.CurrentRow.Cells[0].Value.ToString().Replace(" ", "") + "'"))
                {
                    dataGridView1.Rows.Clear();
                    GetDoors();
                }
            }
        }
    }
}
