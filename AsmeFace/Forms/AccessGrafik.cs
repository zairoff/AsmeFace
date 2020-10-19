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
            _dataBase = new DataBase();
            var smenas = _dataBase.GetStringList("select access_smena_nomi from access_smena");
            foreach (var smena in smenas)
            {
                Column9.Items.Add(smena);
            }
            FillListview();
        }

        private DataBase _dataBase;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid("select *from access_grafik where access_grafik_nomi = '" + listBox1.Items[listBox1.SelectedIndex].ToString() + "' order by kun desc");
        }

        private void FillListview()
        {
            listBox1.Items.Clear();
            var grafiks = _dataBase.GetStringList("select distinct access_grafik_nomi from access_grafik");
            foreach (string grafik in grafiks)
            {
                listBox1.Items.Add(grafik);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                return;

            if (_dataBase.CheckDB("select exists(select 1 from access_grafik where access_grafik_nomi = '" + textBox1.Text.Trim() + "')"))
            {
                CustomMessageBox.Info("График сушествует");
                return;
            }

            for (int i = 1; i <= 7; i++)
            {
                if (!_dataBase.InsertData("insert into access_grafik (access_grafik_nomi, kun) values('" + textBox1.Text.Trim() + "'," + i + ")"))
                    break;
            }

            _dataBase.InsertData("select update_access_group('" + textBox1.Text.Trim() + "')");

            UpdateGrid("select *from access_grafik where access_grafik_nomi = '" + textBox1.Text.Trim() + "' order by kun desc");

            FillListview();
        }

        private void UpdateGrid(string query)
        {
            var grafiks = _dataBase.GetAccessGrafik(query);
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            foreach (var grafik in grafiks)
            {
                dataGridView1.Rows.Insert(
                    0,
                    grafik.AccessSmenaNomi,
                    grafik.Boshlanishi1,
                    grafik.Tugashi1,
                    grafik.Boshlanishi2,
                    grafik.Tugashi2,
                    grafik.Boshlanishi3,
                    grafik.Tugashi3,
                    grafik.Kun);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(9) && e.RowIndex != -1)
            {
                var gr_nomi = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                UpdateGrid("update access_grafik set boshlanishi_1 = null, tugashi_1 = null, boshlanishi_2 = null," +
                    "tugashi_2 = null, boshlanishi_3 = null, tugashi_3 = null where access_grafik_nomi = '" + gr_nomi +
                    "' and kun = " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) + ";" +
                    "select *from access_grafik where access_grafik_nomi = '" + gr_nomi + "'" + " order by kun desc");
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == 8) //Assuming 0 is the index of the ComboBox Column you want to show
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
                //MessageBox.Show("select *from grafik_update(" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) + ",'" +
                //    dataGridView1.CurrentRow.Cells[7].Value.ToString() + "','" + tb.Text + "')");

                UpdateGrid("select *from update_access_grafik(" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) + ",'" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + tb.Text + "')");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                CustomMessageBox.Info("Выберите график");
                return;
            }

            var grafik = listBox1.Items[listBox1.SelectedIndex].ToString();
            // Need to finde alternatives, it's in rush
            if (_dataBase.CheckDB("select exists(select 1 from access_employee where access_grafik_nomi = '" + grafik + "')"))
            {
                CustomMessageBox.Warning("График исползуется");
                return;
            }          

            if (_dataBase.InsertData(
                "delete from access_grafik where access_grafik_nomi = '" + grafik + "';" +
                "delete from access_employee where access_grafik_nomi = '" + grafik + "';" +
                "delete from access_group where access_grafik_nomi = '" + grafik + "';"))
            {
                textBox1.Text = "";
                dataGridView1.Rows.Clear();
                FillListview();
            }
        }
    }
}
