using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class EmployeeHire : EmployeeAdd
    {
        public EmployeeHire()
        {
            InitializeComponent();
            textBox1.Text = (_dataBase.GetID("select employeeid from employee order by employeeid desc limit 1") + 1).ToString();
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

                queryEncode = System.Text.Encoding.UTF8.GetBytes("insert into employee (employeeid, photo, finger, " +
                                "card, ism, familiya, otchestvo, department, otdel, lavozim, address, shtat, passport) " +
                                "values(" + userID + ", @Image, @Finger, '" + textBox7.Text + "','" + textBox3.Text + "','" + textBox2.Text +
                                "','" + textBox4.Text + "','" + treeView1.SelectedNode.Name + "','" + textBox6.Text + "','" + textBox5.Text +
                                "','" + textBox9.Text + "') returning employeeid");

                var index = _dataBase.InsertFace(System.Text.Encoding.UTF8.GetString(queryEncode), photo, finger);

                queryEncode = System.Text.Encoding.UTF8.GetBytes(
                            "insert into employee_history (employeeid, ism, familiya, otchestvo, otdel, " +
                            "lavozim, status, sana) values(" + userID + ",'" + textBox3.Text + "','" +
                            textBox2.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + 
                            textBox5.Text + "','" + Properties.Resources.EMPLOYEE_HISTORY_HIRED + "','" + 
                            dateTimePicker1.Text + "')");

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
