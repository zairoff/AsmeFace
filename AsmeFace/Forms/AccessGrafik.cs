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
    public partial class AccessGrafik : Form
    {
        public AccessGrafik()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            _dataBase = new DataBase();
            GetAccessWeek();
            GetAccessGrafik();
        }

        private readonly DataBase _dataBase;

        private void GetAccessWeek()
        {
            var accesses = _dataBase.GetStringList("select smena_nomi from access_smena");
            foreach (string access in accesses)
            {
                Column6.Items.Add(access);
            }
        }

        private void GetAccessGrafik()
        {
            listBox1.Items.Clear();
            var grafiks = _dataBase.GetStringList("select distinct grafik_nomi from access_grafik");
            foreach (string grafik in grafiks)
            {
                listBox1.Items.Add(grafik);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == 6) //Assuming 0 is the index of the ComboBox Column you want to show
            {
                if (e.Control is ComboBox cb)
                {
                    cb.SelectionChangeCommitted -= new EventHandler(cb_SelectedIndexChanged);
                    // now attach the event handler
                    cb.SelectionChangeCommitted += new EventHandler(cb_SelectedIndexChanged);
                }
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.EditingControl is ComboBox tb)
            {
                var query = "select *from access_grafik_update(" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) + ",'" +
                    dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + tb.Text + "')";

                UpdateGrid(query);
            }
        }

        private void UpdateGrid(string query)
        {
            var grafiks = _dataBase.GetAccessGr(query);
            ClearAll();
            foreach (var grafik in grafiks)
            {
                dataGridView1.Rows.Insert(
                    0,
                    grafik.Name,
                    grafik.Start,
                    grafik.Stop,
                    grafik.Day);
            }
        }

        private void ClearAll()
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(comboBox1.Text))
                return;

            if (_dataBase.CheckDB("select exists(select 1 from access_grafik where grafik_nomi = '" + textBox1.Text.Trim() + "')"))
            {
                CustomMessageBox.Info("График сушествует");
                return;
            }
            int sikl = 0;
            if (comboBox1.SelectedIndex == 0)
                sikl = 1 * Convert.ToInt32(textBox3.Text);
            if (comboBox1.SelectedIndex == 1)
                sikl = 7 * Convert.ToInt32(textBox3.Text);
            if (comboBox1.SelectedIndex == 2)
                sikl = 30 * Convert.ToInt32(textBox3.Text);

            for (int i = 1; i <= sikl; i++)
            {
                if (!_dataBase.InsertData("insert into access_grafik (grafik_nomi, kun) values('" + textBox1.Text.Trim() + "'," + i + ")"))
                    break;
            }
            UpdateGrid("select *from access_grafik where grafik_nomi = '" + textBox1.Text.Trim() + "' order by kun desc");

            GetAccessGrafik();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                CustomMessageBox.Info("Выберите график");
                return;
            }

            if (_dataBase.InsertData("delete from access_grafik where grafik_nomi = '" + listBox1.Items[listBox1.SelectedIndex].ToString() + "'"))
            {
                ClearAll();
                GetAccessGrafik();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(4) && e.RowIndex != -1)
            {
                string gr_nomi = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                UpdateGrid("update access_grafik set smena_boshlanishi = null, smena_tugashi = null where grafik_nomi = '" + gr_nomi +
                    "' and kun = " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) + ";" +
                    "select *from access_grafik where grafik_nomi = '" + gr_nomi + "'" + " order by kun desc");
            }
        }
    }
}
