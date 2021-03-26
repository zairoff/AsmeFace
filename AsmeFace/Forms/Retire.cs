using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class Retire : Form
    {
        public Retire(int id)
        {
            InitializeComponent();
            _asmeDevice = new AsmeDevice();
            _dataBase = new DataBase();
            _employee = _dataBase.GetEmployee(
                            "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel," +
                            " lavozim, address from employee where employeeid = " + id);
            if (_employee.Count > 0)
            {
                pictureBox1.Image = ByteToImage(_employee[0].Photo);
                textBox1.Text = _employee[0].ID.ToString();
                textBox2.Text = _employee[0].Familiya;
                textBox3.Text = _employee[0].Ism;
            }
        }

        private readonly AsmeDevice _asmeDevice;
        private readonly DataBase _dataBase;
        public event EventHandler Notify;
        private readonly List<Employee> _employee;

        private System.Drawing.Image ByteToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var userID = Convert.ToInt32(textBox1.Text);
            var query = "update employee set status = false where employeeid = " + userID + ";" +
                        "insert into employee_history (employeeid, ism, familiya, otchestvo, otdel, " +
                        "lavozim, status, extra_info, sana) values(" + userID + ",'" + textBox3.Text + "','" +
                        textBox2.Text + "','" + _employee[0].Otchestvo + "','" + _employee[0].Otdel +
                        "','" + _employee[0].Lavozim + "','" + Properties.Resources.EMPLOYEE_HISTORY_RETIRED +
                        "','" + textBox4.Text + "','" + dateTimePicker1.Text + "')";

            if (UpdateOrDeleteEmployee(userID, query))
            {
                ClearFields();
                CustomMessageBox.Info(Properties.Resources.OPERATION_SUCCESS);
            }                
            else
                CustomMessageBox.Info(Properties.Resources.OPERATION_FAILED);
        }

        private void ClearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            pictureBox1.Image = null;
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

            return _dataBase.InsertData(query);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Retire_FormClosing(object sender, FormClosingEventArgs e)
        {
            Notify?.Invoke(this, EventArgs.Empty);
        }
    }
}
