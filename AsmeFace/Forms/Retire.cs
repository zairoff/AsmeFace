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
    public partial class Retire : Form
    {
        public Retire(int id)
        {
            InitializeComponent();
            _asmeDevice = new AsmeDevice();
            _dataBase = new DataBase();
            var employee = _dataBase.GetEmployee(
                            "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel," +
                            " lavozim, address from employee where employeeid = " + id);
            if (employee.Count > 0)
            {
                pictureBox1.Image = ByteToImage(employee[0].Photo);
                textBox1.Text = employee[0].ID.ToString();
                textBox2.Text = employee[0].Familiya;
                textBox3.Text = employee[0].Ism;
            }
        }

        private readonly AsmeDevice _asmeDevice;
        private readonly DataBase _dataBase;
        public event EventHandler Notify;

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
                        "update employee_history set retired_date = '" + dateTimePicker1.Text + "', status = false, " +
                                    "reason = '" + textBox4.Text + "' " +
                                    "where hired_date = (" +
                                    "select hired_date from employee_history " +
                                                            "where employeeid = " + userID +
                                                            "and status = true " +
                                                            "order by hired_date desc " +
                                                            "limit 1);";

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
            //var devices = _dataBase.GetDevices("select *from devices");

            //if (devices.Count < 1)
            //    return false;

            //foreach (var device in devices)
            //{
            //    int nRes = _asmeDevice.OpenDevice(device.dwIPAddress);
            //    if (nRes < 0)
            //    {
            //        CustomMessageBox.Error(
            //            "Failed to open device "
            //            + device.dwIPAddress +
            //            " : " + _asmeDevice.GetResponse(nRes));
            //        return false;
            //    }

            //    nRes = _asmeDevice.DeleteCard(userID);

            //    if (nRes < 0)
            //    {
            //        CustomMessageBox.Error("Failed to delete card, device "
            //            + device.dwIPAddress +
            //            " : " + _asmeDevice.GetResponse(nRes));
            //        _asmeDevice.CloseDevice();
            //        return false;
            //    }

            //    if (device.dwType.Equals("Face"))
            //    {
            //        CustomLog.WriteToFile("sTAFF " + userID);
            //        nRes = _asmeDevice.DeleteFace(userID);
            //        if (nRes < 0)
            //        {
            //            CustomMessageBox.Error("Failed to delete face, device "
            //                + device.dwIPAddress +
            //                " : " + _asmeDevice.GetResponse(nRes));
            //            _asmeDevice.CloseDevice();
            //            return false;
            //        }
            //    }

            //    if (device.dwType.Equals("Finger"))
            //    {
            //        nRes = _asmeDevice.DeleteFinger(userID);
            //        if (nRes < 0)
            //        {
            //            CustomMessageBox.Error("Failed to delete fingerprint, device "
            //                + device.dwIPAddress +
            //                " : " + _asmeDevice.GetResponse(nRes));
            //            _asmeDevice.CloseDevice();
            //            return false;
            //        }
            //    }
            //    _asmeDevice.CloseDevice();
            //}

            //var query = "update employee set status = false where employeeid = " + userID);
            //var query = "delete from employee where employeeid = " + userID);
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
