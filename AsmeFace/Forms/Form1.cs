using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class Form1 : Form, ICustomMouseEvents
    {
        public Form1()
        {
          //System.Threading.Thread.CurrentThread.CurrentCulture =
         //System.Globalization.CultureInfo.GetCultureInfo("ru");
         
            InitializeComponent();
            programm_type = (System.Configuration.ConfigurationManager.AppSettings["program_type"]);
        }

        private UserControls.Department department;
        private UserControls.Device device;
        private UserControls.Grafik grafik;        
        private UserControls.Smena smena;
        private UserControls.Staff staff;
        //private UserControls.Syncronization syncronization;
        private UserControls.GrafikStaff grafikStaff;
        private UserControls.GrafikstaffSingle _grafikSingle;
        private UserControls.Contact contact;
        private UserControls.Language _language;
        private DataBase mydataBase = new DataBase();
        private System.Drawing.Point lastLocation;
        private bool mouseDown = false;
        private readonly string programm_type;

        public void MouseEnterOrLeave(Button button, System.Drawing.Color TextColor, System.Drawing.Color BackColor)
        {
            button.ForeColor = TextColor;
            button.BackColor = BackColor;            
        }
        
        private void ReplaseUserControl(UserControl userControl)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            if (smena != null)
                smena.Dispose();

            smena = new UserControls.Smena
            {
                Dock = DockStyle.Fill
            };
            ReplaseUserControl(smena);        
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (department == null)
            {
                department = new UserControls.Department();
                System.Drawing.Size size = new System.Drawing.Size(department.Size.Width, this.panel3.Size.Height);
                department.Size = size;
                System.Drawing.Point point = new System.Drawing.Point(this.panel3.Size.Width / 2 - department.Size.Width / 2,
                    this.panel3.Size.Height / 2 - department.Size.Height / 2);

                department.Location = point;
            }                     
            ReplaseUserControl(department);
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            if (device != null)
                device.Dispose();

            device = new UserControls.Device
            {
                Dock = DockStyle.Fill
            };
            ReplaseUserControl(device);            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (staff != null)
                staff.Dispose();

            staff = new UserControls.Staff
            {
                Dock = DockStyle.Fill
            };
            ReplaseUserControl(staff);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            if (grafik != null)
                grafik.Dispose();

            grafik = new UserControls.Grafik
            {
                Dock = DockStyle.Fill
            };
            ReplaseUserControl(grafik);            
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (programm_type == "2")
            {
                if (grafikStaff != null)
                    grafikStaff.Dispose();

                grafikStaff = new UserControls.GrafikStaff
                {
                    Dock = DockStyle.Fill
                };
                ReplaseUserControl(grafikStaff);
            }
            else if (programm_type == "1")
            {
                if (_grafikSingle != null)
                    _grafikSingle.Dispose();

                _grafikSingle = new UserControls.GrafikstaffSingle
                {
                    Dock = DockStyle.Fill
                };
                ReplaseUserControl(_grafikSingle);
            }
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            //new Sync().ShowDialog();
            //if (syncronization == null)
            //{
            //    syncronization = new UserControls.Syncronization();
            //    syncronization.Dock = DockStyle.Fill;
            //}
            //ReplaseUserControl(syncronization);
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new System.Drawing.Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            _language = new UserControls.Language
            {
                Dock = DockStyle.Fill,
                ParentForm = this                
            };
            ReplaseUserControl(_language);
        }

        private void button7_Click_2(object sender, System.EventArgs e)
        {
            //MessageBox.Show(new System.Resources.ResourceManager("AsmeFace.Forms.Form1", System.Reflection.Assembly.GetExecutingAssembly()).GetString("button1.Text"));

            if (contact == null)
            {
                contact = new UserControls.Contact();
                System.Drawing.Size size = new System.Drawing.Size(contact.Size.Width, this.panel3.Size.Height);
                contact.Size = size;
                System.Drawing.Point point = new System.Drawing.Point(this.panel3.Size.Width / 2 - contact.Size.Width / 2,
                    this.panel3.Size.Height / 2 - contact.Size.Height / 2);

                contact.Location = point;
            }
            ReplaseUserControl(contact);
        }
    }
}
