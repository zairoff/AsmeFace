using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class Device : UserControl
    {
        public Device()
        {
            InitializeComponent();
            _asmeDevice = new AsmeDevice();
            _dataBase = new DataBase();
            var doors = _dataBase.GetStringList("select name from doors");
            foreach (var door in doors)
            {
                Column6.Items.Add(door);
            }
        }

        private AsmeDevice _asmeDevice;
        private DataBase _dataBase;

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Font = new Font("Lucida fax", 13f, FontStyle.Regular);
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
            label2.ForeColor = Color.White;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            this.label3.Font = new Font("Lucida fax", 13f, FontStyle.Regular);
            this.label3.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.label3.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
            this.label3.ForeColor = Color.White;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            this.label4.Font = new Font("Lucida fax", 13f, FontStyle.Regular);
            this.label4.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.label4.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
            this.label4.ForeColor = Color.White;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.Font = new Font("Lucida fax", 13f, FontStyle.Regular);
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
            label5.ForeColor = Color.White;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.Font = new Font("Lucida fax", 13f, FontStyle.Regular);
            label6.ForeColor = Color.White;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
            label6.ForeColor = Color.White;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.Font = new Font("Lucida fax", 13f, FontStyle.Regular);
            label7.ForeColor = Color.White;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
            label7.ForeColor = Color.White;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (_asmeDevice.FindController() > 0)
            {
                var devices = _asmeDevice.GetControllerInfo();
                if(devices != null)
                {
                    foreach(DeviceInfo device in devices)
                    {
                        dataGridView1.Rows.Insert(0, device.szVersion, device.szMac, device.dwIPAddress);
                    }
                }
            }            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Forms.Doors().Show();            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1)
            {              
                dataGridView1.EndEdit();

                if (dataGridView1.CurrentRow.Cells[3].Value == null)
                {
                    CustomMessageBox.Info("Выберите тип устройство");
                    return;
                }

                if (dataGridView1.CurrentRow.Cells[4].Value == null)
                {
                    CustomMessageBox.Info("Выберите направления");
                    return;
                }

                if (dataGridView1.CurrentRow.Cells[5].Value == null)
                {
                    CustomMessageBox.Info("Выберите дверь");
                    return;
                }

                if (_dataBase.CheckDB("select exists(select 1 from devices where device_mac = '" + dataGridView1[1,
                    dataGridView1.CurrentRow.Index].Value.ToString().Replace(" ", "") + "')"))
                {
                    CustomMessageBox.Info("Устройство существует в баз данных");
                    return;
                }

                if (_dataBase.InsertData("insert into devices (device_version, device_mac, device_ip, device_type," +
                    "device_status, device_door) values ('" + 
                    dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" +
                    dataGridView1.CurrentRow.Cells[1].Value.ToString().Replace(" ", "") + "','" +
                    dataGridView1.CurrentRow.Cells[2].Value.ToString().Replace(" ", "") + "','" +
                    dataGridView1.CurrentRow.Cells[3].Value.ToString() + "','" +
                    dataGridView1.CurrentRow.Cells[4].Value.ToString() + "','" +
                    dataGridView1.CurrentRow.Cells[5].Value.ToString() + "')"))
                {
                    CustomMessageBox.Info("Добавлено успешно!");
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                var ip = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (_asmeDevice.OpenDevice(ip) < 0)
                {
                    CustomMessageBox.Error("Failed to open device");
                    return;
                }

                if (_asmeDevice.InitController(ip) < 0)
                {
                    CustomMessageBox.Error("Инициализировать не удалось");
                    _asmeDevice.CloseDevice();
                    return;
                }
                CustomMessageBox.Info("Инстализация выполнено успещно!");
                _asmeDevice.CloseDevice();
                return;
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(8) && e.RowIndex != -1)
            {
                if (dataGridView1.CurrentRow.Cells[3].Value == null)
                    return;

                if (string.Equals("Finger", dataGridView1.CurrentRow.Cells[3].Value.ToString()))
                    new Forms.DeviceFinger(dataGridView1.CurrentRow.Cells[2].Value.ToString()).Show();

                if (string.Equals("Face", dataGridView1.CurrentRow.Cells[3].Value.ToString()))
                    new Forms.DeviceFace(dataGridView1.CurrentRow.Cells[2].Value.ToString()).Show();
            }

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(9) && e.RowIndex != -1)
            {
                if (_dataBase.InsertData("delete from devices where device_mac = '"
                    + dataGridView1.CurrentRow.Cells[1].Value.ToString().Replace(" ", "") + "'"))
                    dataGridView1.Rows.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new Forms.DoorControl().Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new Forms.EmployeeInDevice().Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Forms.AddedDoors().Show();
            //dataGridView1.Rows.Clear();

            //var devices = _dataBase.GetDevices("select *from devices");

            //if (devices.Count < 1)
            //    return;

            ////Column4.Items.Clear();
            ////Column5.Items.Clear();
            ////Column6.Items.Clear();

            //foreach (var device in devices)
            //{
            //    dataGridView1.Rows.Insert(0, device.szVersion, device.szMac, device.dwIPAddress);
            //    //Column6.Items.Add(device.dwDoor);
            //    //Column5.Items.Add(device.dwStatus);
            //    //Column4.Items.Add(device.dwType);
            //}
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //new Forms.AccessForm().Show();
        }
    }
}
