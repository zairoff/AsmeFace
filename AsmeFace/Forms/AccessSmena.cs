using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class AccessSmena : Form
    {
        public AccessSmena()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            RetriveData();
        }

        private readonly DataBase _dataBase;        

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                return;

            if (_dataBase.CheckDB("select exists(select 1 from access_smena where smena_nomi = '" + textBox1.Text.Trim() + "')"))
            {
                CustomMessageBox.Info("Ограничения существует");
                return;
            }

            var query = "insert into access_smena (smena_nomi, smena_boshlanishi, smena_tugashi) values ('" +
                textBox1.Text.Trim() + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')";

            if (_dataBase.InsertData(query))
                RetriveData();
        }

        private void RetriveData()
        {
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
            var accesses = _dataBase.GetAccessSmena("select *from access_smena");
            foreach (var access in accesses)
            {
                dataGridView1.Rows.Insert(0,
                    access.Name,
                    access.Start,
                    access.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
            {
                var query = "delete from access_smena where smena_nomi = '" + dataGridView1[0,
                    dataGridView1.CurrentRow.Index].Value.ToString() + "'";

                if (_dataBase.InsertData(query))
                    RetriveData();
            }
        }
    }
}
