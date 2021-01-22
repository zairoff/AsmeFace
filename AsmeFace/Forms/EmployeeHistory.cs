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
    public partial class EmployeeHistory : Form
    {
        public EmployeeHistory(int id)
        {
            InitializeComponent();
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

            _dataBase.GetRecords("select department, position, hired_date, retired_date, reason " +
                                "from employee_history where employeeid = " + id,
                                dataGridView1);

            SetHeaders();
        }

        private readonly DataBase _dataBase;

        private Image ByteToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void SetHeaders()
        {
            dataGridView1.Columns[0].HeaderText = Properties.Resources.GRIDVIEW_DEPARTMENT;
            dataGridView1.Columns[1].HeaderText = Properties.Resources.GRIDVIEW_POSITION;
            dataGridView1.Columns[2].HeaderText = Properties.Resources.GRIDVIEW_HIRED_DATE;
            dataGridView1.Columns[3].HeaderText = Properties.Resources.GRIDVIEW_RETIRED_DATE;
            dataGridView1.Columns[4].HeaderText = Properties.Resources.GRIDVIEW_REASON;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
