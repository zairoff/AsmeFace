﻿using System;
using System.Text;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class EmployeeRehire : EmployeeAdd
    {
        public EmployeeRehire(int id)
        {
            InitializeComponent();
            var employee = _dataBase.GetEmployee(
                            "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel," +
                            "lavozim, address from employee where employeeid = " + id);
            if (employee.Count > 0)
            {
                pictureBox1.Image = ByteToImage(employee[0].Photo);
                textBox1.Text = employee[0].ID.ToString();
                textBox2.Text = employee[0].Familiya;
                textBox3.Text = employee[0].Ism;
                textBox4.Text = employee[0].Otchestvo;
                textBox7.Text = employee[0].Card;
                textBox8.Text = employee[0].Finger == null ? "" : Convert.ToBase64String(employee[0].Finger);
                textBox9.Text = employee[0].Address;
            }
        }

        protected override void Button3_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                byte[] queryEncode = null;
                byte[] finger = null;
                var userID = Convert.ToInt32(textBox1.Text);
                var photo = ImageToByteArray(pictureBox1.Image);

                if (!string.IsNullOrEmpty(textBox8.Text))
                    finger = Convert.FromBase64String(textBox8.Text);

                queryEncode = Encoding.UTF8.GetBytes(
                            "update employee set photo = @Image, finger = @finger, card = '" + 
                            textBox7.Text + "', familiya = '" + textBox2.Text + "', ism = '" + 
                            textBox3.Text + "', otchestvo = '" + textBox4.Text + "'," + "department = '" + 
                            treeView1.SelectedNode.Name + "', otdel = '" + textBox6.Text + "'," +
                            "lavozim = '" + textBox5.Text + "', address = '" + textBox9.Text +
                            "', status = true where employeeid = " + userID + ";" +
                            "insert into employee_history (employeeid, ism, familiya, otchestvo, otdel, " +
                            "lavozim, status, sana) values(" + userID + ",'" + textBox3.Text + "','" +
                            textBox2.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" +
                            textBox5.Text + "','" + Properties.Resources.EMPLOYEE_HISTORY_REHIRED + "','" +
                            dateTimePicker1.Text + "')");

                var index = _dataBase.InsertFace(System.Text.Encoding.UTF8.GetString(queryEncode), photo, finger);           

                if (index < 0)
                {
                    MessageBox.Show(Properties.Resources.OPERATION_FAILED);
                    return;
                }

                ClearFields();
                CustomMessageBox.Info(Properties.Resources.OPERATION_SUCCESS);
            }
            else
            {
                CustomMessageBox.Info(Properties.Resources.FILL_IN_ALL_FIELDS);
            }
        }
    }
}
