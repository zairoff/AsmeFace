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
    public partial class EmployeeRehire : EmployeeAdd
    {
        public EmployeeRehire(int id)
        {
            InitializeComponent();
            var employee = _dataBase.GetEmployee(
                            "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel," +
                            " lavozim, address from employee where employeeid = " + id);
            if (employee.Count > 0)
            {
                pictureBox1.Image = ByteToImage(employee[0].Photo);
                textBox1.Text = employee[0].ID.ToString();
                textBox2.Text = employee[0].Familiya;
                textBox3.Text = employee[0].Ism;
                textBox4.Text = employee[0].Otchestvo;
                textBox7.Text = employee[0].Card;
                textBox8.Text = employee[0].Finger == null ? "" : System.Text.Encoding.UTF8.GetString(employee[0].Finger);
                textBox9.Text = employee[0].Address;
            }
        }

        protected override void Button3_Click(object sender, System.EventArgs e)
        {
            if (CheckFields())
            {
                byte[] queryEncode = null;
                byte[] finger = null;
                var userID = Convert.ToInt32(textBox1.Text);
                var photo = ImageToByteArray(pictureBox1.Image);

                if (!string.IsNullOrEmpty(textBox8.Text))
                    finger = Convert.FromBase64String(textBox8.Text);

                queryEncode = System.Text.Encoding.UTF8.GetBytes("update employee set photo = @Image, finger = @finger," +
                         "card = '" + textBox7.Text + "', familiya = '" + textBox2.Text + "', ism = '" + textBox3.Text +
                         "', otchestvo = '" + textBox4.Text + "'," + "department = '" + treeView1.SelectedNode.Name +
                         "', otdel = '" + textBox6.Text + "'," + "lavozim = '" + textBox5.Text + "'," +
                         "address = '" + textBox9.Text + "', status = true where employeeid = " + userID);

                var index = _dataBase.InsertFace(System.Text.Encoding.UTF8.GetString(queryEncode), photo, finger);

                queryEncode = System.Text.Encoding.UTF8.GetBytes("insert into employee_history (employeeid," +
                    "department, position, status, hired_date) values(" + userID + ",'" + textBox6.Text + "','" +
                    textBox5.Text + "', true, '" + dateTimePicker1.Text + "')");

                if (index < 0)
                {
                    MessageBox.Show(Properties.Resources.OPERATION_FAILED);
                    return;
                }

                ClearFields();
                textBox1.Text = (index + 1).ToString();
                _dataBase.InsertData(System.Text.Encoding.UTF8.GetString(queryEncode));
                CustomMessageBox.Info(Properties.Resources.OPERATION_SUCCESS);
            }
            else
            {
                CustomMessageBox.Info(Properties.Resources.FILL_IN_ALL_FIELDS);
            }
        }
    }
}
