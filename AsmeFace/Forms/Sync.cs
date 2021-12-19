using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class Sync : Form
    {
        public Sync()
        {
            InitializeComponent();
        }

        private DataBase myDataBase = new DataBase();
        private AsmeDevice asmeDevice = new AsmeDevice();

        private void button1_Click(object sender, System.EventArgs e)
        {            
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Syncronize));
            thread.Start();
        }

        private void Syncronize()
        {            
            System.Collections.Generic.List<string> devices = myDataBase.GetStringList("select device_ip from devices");
            if (devices.Count < 1)
            {
                MessageBox.Show("Нет добавленный устройств");
                return;
            }

            var myEmployees = myDataBase.GetEmployee(
                "select employeeid, photo, ism, familiya, otchestvo, otdel, lavozim, address, enrollment_number, amizone_code from employee order by employeeid desc");

            if (myEmployees.Count < 1)
                return;

            BeginInvoke(new MethodInvoker(delegate ()
            {
                label1.Text = "Синхронизируется...";
                button1.Enabled = false;
                button2.Enabled = false;
            }));

            foreach (Employee myEmployee in myEmployees)
            {
                foreach (string device in devices)
                {
                    SyncAction(myEmployee, device);
                }
            }
            BeginInvoke(new MethodInvoker(delegate ()
            {
                label1.Text = "Завершено";
                button1.Enabled = true;
                button2.Enabled = true;
            }));
        }

        private void SyncAction(Employee myEmployee, string ip)
        {
            int nRes = asmeDevice.OpenDevice(ip);
            if (nRes < 0)
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    dataGridView1.Rows.Insert(
                        0,
                        "Failed to open: " + asmeDevice.GetResponse(nRes),
                        ip,
                        myEmployee.ID,
                        myEmployee.Familiya,
                        myEmployee.Ism);
                }));
                return;
            }
            nRes = asmeDevice.WriteFace(myEmployee.Photo, myEmployee.ID);
            if (nRes < 0)
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    dataGridView1.Rows.Insert(
                        0,
                        "Failed to write: " + asmeDevice.GetResponse(nRes),
                        ip,
                        myEmployee.ID,
                        myEmployee.Familiya,
                        myEmployee.Ism);
                }));
                asmeDevice.CloseDevice();
                return;
            }
            BeginInvoke(new MethodInvoker(delegate ()
            {
                dataGridView1.Rows.Insert(
                    0,
                    "Success: " + nRes,
                    ip,
                    myEmployee.ID,
                    myEmployee.Familiya,
                    myEmployee.Ism);
            }));
            asmeDevice.CloseDevice();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
