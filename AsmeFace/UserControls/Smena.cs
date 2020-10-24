using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class Smena : UserControl
    {
        public Smena()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            RetriveSmena();
        }

        private DataBase _dataBase;

        private void button1_Click(object sender, EventArgs e)
        {
            //if(dateTimePicker2.Value.ToString("tt", System.Globalization.CultureInfo.InvariantCulture) == "AM")
            //{
            //    DateTime dateTime = DateTime.Parse("2020-07-15");
            //    MessageBox.Show((dateTime + dateTimePicker2.Value).ToString());
            //}
            //MessageBox.Show(dateTimePicker2.Value.ToString("tt", System.Globalization.CultureInfo.InvariantCulture));
            //MessageBox.Show((DateTime.ParseExact("2020-07-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + dateTimePicker2.Value).ToString());
            if (string.IsNullOrEmpty(textBox1.Text))
                return;

            if (_dataBase.CheckDB("select exists(select 1 from smena where smena_nomi = '" + textBox1.Text.Trim() + "')"))
            {
                CustomMessageBox.Info(textBox1.Text + " " + Properties.Resources.EXIST);
                return;
            }
            if (_dataBase.InsertData("insert into smena (smena_nomi, smena_boshlanishi, smena_tugashi, obed_boshlanishi," +
                "obed_tugashi, kech_keldi, vox_ketdi) values ('" + textBox1.Text.Trim() + "','" + dateTimePicker1.Text + "','" +
                dateTimePicker2.Text + "','" + dateTimePicker3.Text + "','" + dateTimePicker4.Text + "'," +
                numericUpDown1.Value + "," + numericUpDown2.Value + ")"))
            {
                RetriveSmena();
            }

        }

        private void RetriveSmena()
        {
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
            var list = _dataBase.GetSmena("select *from smena");
            foreach (var mySmena in list)
            {
                dataGridView1.Rows.Insert(0,
                    mySmena.Smena_nomi,
                    mySmena.Smena_boshlanishi,
                    mySmena.Smena_tugashi,
                    mySmena.Obed_boshlanishi,
                    mySmena.Obed_tugashi,
                    mySmena.Kech_keldi,
                    mySmena.Vox_ketdi);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if(dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                if (_dataBase.InsertData("delete from smena where smena_nomi = '" + dataGridView1[0,
                    dataGridView1.CurrentRow.Index].Value.ToString() + "'"))
                    RetriveSmena();
            }
        }
    }
}
