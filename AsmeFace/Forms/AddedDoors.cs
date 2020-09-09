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
    public partial class AddedDoors : Form
    {
        public AddedDoors()
        {
            InitializeComponent();
            var _dataBase = new DataBase();
            var devices = _dataBase.GetDevices("select *from devices");

            if (devices.Count < 1)
                return;

            foreach (var device in devices)
            {
                dataGridView1.Rows.Insert(0, device.dwIPAddress, device.dwType, device.dwStatus, device.dwDoor);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
