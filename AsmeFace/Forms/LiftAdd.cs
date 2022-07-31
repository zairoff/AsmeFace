using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class LiftAdd : Form
    {
        public LiftAdd()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            GetLifts();
        }

        private DataBase _dataBase;

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
                return;

            if (_dataBase.CheckDB("select exists(select 1 from lift where serinniy = '" + textBox1.Text + "')"))
            {
                CustomMessageBox.Info(textBox1.Text + " " + Properties.Resources.EXIST);
                return;
            }

            if (_dataBase.InsertData("insert into lift (name, serinniy, address) values('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')"))
            {
                GetLifts();
            }
        }

        private void GetLifts()
        {
            var lifts = _dataBase.GetLifts("select *from lift");
            dataGridView1.Rows.Clear();
            foreach (var lift in lifts)
            {
                dataGridView1.Rows.Insert(0, lift.Name, lift.Serinniy, lift.IP);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
            {
                if (_dataBase.InsertData("delete from lift where serinniy = '" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value + "'"))
                {
                    GetLifts();
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
