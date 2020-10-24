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
            _languageKey = (ConfigurationManager.AppSettings["language"]);

        }

        public Forms.Form1 ParentForm { get; set; }
        private readonly string _languageKey;

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

            ChangeLanguage("def");
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
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(language);
                ParentForm.button1.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button1.Text"));
                ParentForm.button2.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button2.Text"));
                ParentForm.button3.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button3.Text"));
                ParentForm.button4.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button4.Text"));
                ParentForm.button5.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button5.Text"));
                ParentForm.button6.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button6.Text"));
                ParentForm.button7.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button7.Text"));
                ParentForm.button8.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button8.Text"));
                
                //Button staff = ParentForm.Controls["button1"] as Button;
                //Button department = ParentForm.Controls["button2"] as Button;
                //Button employee_shift = ParentForm.Controls["button3"] as Button;
                //Button shifts = ParentForm.Controls["button4"] as Button;
                //Button schedules = ParentForm.Controls["button5"] as Button;
                //Button devices = ParentForm.Controls["button6"] as Button;
                //Button contacts = ParentForm.Controls["button7"] as Button;
                //Button languages = ParentForm.Controls["button8"] as Button;

                //MessageBox.Show(new System.Resources.ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button1.Text"));

                //staff.Text = (new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button1.Text")).ToString();
                //department.Text = new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button2.Text");
                //employee_shift.Text = new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button3.Text");
                //shifts.Text = new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button4.Text");
                //schedules.Text = new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button5.Text");
                //devices.Text = new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button6.Text");
                //contacts.Text = new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button7.Text");
                //languages.Text = new ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button8.Text");

                var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                if(!string.IsNullOrEmpty(_languageKey))
                    config.AppSettings.Settings.Remove("language");

                config.AppSettings.Settings.Add("language", language);
                config.Save(ConfigurationSaveMode.Minimal);
            }
        }
    }
}
