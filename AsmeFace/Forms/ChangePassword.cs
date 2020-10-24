using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myDatabase = new DataBase();
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text) &&
                string.IsNullOrEmpty(textBox3.Text))
            {
                CustomMessageBox.Info(Properties.Resources.FILL_IN_ALL_FIELDS);
                return;
            }
            if (!myDatabase.CheckDB("select exists(select 1 from login where pass = '" + textBox1.Text + "')"))
            {
                textBox1.ForeColor = System.Drawing.Color.Red;
                CustomMessageBox.Error(Properties.Resources.PASSWORD_WRONG);
                return;
            }
            if (!string.Equals(textBox2.Text, textBox3.Text))
            {
                textBox2.ForeColor = System.Drawing.Color.Red;
                textBox3.ForeColor = System.Drawing.Color.Red;
                CustomMessageBox.Error(Properties.Resources.PASSWORD_NOT_MATCH);
                return;
            }

            myDatabase.InsertData("update login set pass = '" + textBox3.Text + "' where pass = '" + textBox1.Text + "'");

            if (myDatabase.CheckDB("select exists(select 1 from login where pass = '" + textBox3.Text + "')"))
            {
                CustomMessageBox.Info(Properties.Resources.OPERATION_SUCCESS);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Black;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox2.ForeColor = System.Drawing.Color.Black;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            textBox3.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new Login().Show();
        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
