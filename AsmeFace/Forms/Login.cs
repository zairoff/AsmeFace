using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            _dataBase = new DataBase();
            SetLanguage();
            InitializeComponent();            
            textBox3.Select();
            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString());
        }

        private readonly DataBase _dataBase;

        private void SetLanguage()
        {
            try
            {
                var language = _dataBase.GetString("select lan from language limit 1");
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(language);
            }
            catch (Exception msg)
            {
                CustomMessageBox.Error(msg.ToString());
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            connectDB();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            new ChangePassword().Show();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            textBox3.ForeColor = System.Drawing.Color.Black;
            if (e.KeyValue == (char)Keys.Enter)
            {
                connectDB();
            }
        }

        private void connectDB()
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox3.Text))
                {
                    CustomMessageBox.Info(Properties.Resources.FILL_IN_ALL_FIELDS);
                    return;
                }                              

                if (_dataBase.CheckDB("select exists(select 1 from login where username = '" + textBox2.Text +
                    "' and pass = '" + textBox3.Text + "')"))
                {
                    Hide();
                    new Form1().Show();
                }
                else
                {
                    textBox3.ForeColor = System.Drawing.Color.Red;
                    CustomMessageBox.Error(Properties.Resources.LOGIN_WRONG);
                }
            }
            catch(Exception msg)
            {
                CustomMessageBox.Error(msg.ToString());
            }            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
