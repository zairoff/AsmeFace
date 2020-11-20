using System;
using System.Configuration;
using System.Resources;
using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class Language : UserControl
    {
        public Language()
        {
            InitializeComponent();
            _dataBase = new DataBase();
        }

        public new Forms.Form1 ParentForm { get; set; }
        private readonly DataBase _dataBase;

        private void EnglishPictureBox_Click(object sender, EventArgs e)
        {
            if (ParentForm == null)
                return;

            ChangeLanguage("en");
        }

        private void RussianPictureBox_Click(object sender, EventArgs e)
        {
            if (ParentForm == null)
                return;

            ChangeLanguage("ru");
        }

        private void ChangeLanguage(string language)
        {
            var dialogResult = MessageBox.Show(
                Properties.Resources.CONTROL_LANGUAGE_CHANGE,
                Properties.Resources.WARNING,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if(_dataBase.InsertData("update language set lan = '" + language + "'"))
                    {
                        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(language);

                        ParentForm.button1.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button1.Text"));
                        ParentForm.button2.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button2.Text"));
                        ParentForm.button3.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button3.Text"));
                        ParentForm.button4.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button4.Text"));
                        ParentForm.button5.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button5.Text"));
                        ParentForm.button6.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button6.Text"));
                        ParentForm.button7.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button7.Text"));
                        ParentForm.button8.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button8.Text"));
                    }
                    //var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    ////config.AppSettings.Settings["language"].Value = language;
                    ////config.Save(ConfigurationSaveMode.Modified);
                    ////ConfigurationManager.RefreshSection("appSettings");

                    //config.AppSettings.Settings.Remove("language");
                    //config.AppSettings.Settings.Add("language", language);
                    //config.Save(ConfigurationSaveMode.Modified);                    
                }
                catch (Exception msg)
                {
                    CustomMessageBox.Error(msg.ToString());
                }                
            }
        }
    }
}
