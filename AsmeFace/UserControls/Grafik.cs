using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class Grafik : UserControl
    {
        public Grafik()
        {
            InitializeComponent();
            var programm_type = (System.Configuration.ConfigurationManager.AppSettings["program_type"]);
            if(programm_type == "1")
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = false;
                textBox3.Text = "7";
                textBox3.Enabled = false;
            }

            _dataBase = new DataBase();
            var smenas = _dataBase.GetStringList("select smena_nomi from smena");
            foreach (string smena in smenas)
            {
                Column9.Items.Add(smena);
            }
            FillListview();
        }

        private DataBase _dataBase;

        private void FillListview()
        {
            listBox1.Items.Clear();
            var grafiks = _dataBase.GetStringList("select distinct grafik_nomi from grafik");
            foreach (string grafik in grafiks)
            {
                listBox1.Items.Add(grafik);
            }
        }        

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == 9) //Assuming 0 is the index of the ComboBox Column you want to show
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

                UpdateGrid("select *from grafik_update(" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) + ",'" +
                    dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + tb.Text + "')");
                //myDataBase.insertData();
                //dataGridView1.CurrentRow.Cells[0].Value = tb.Text;
                //((DataGridView)sender).CurrentRow.Cells[1].Value = tb.Text;
                //MessageBox.Show(dataGridView1.CurrentCell.ColumnIndex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(comboBox1.Text))
                return;

            if (_dataBase.CheckDB("select exists(select 1 from grafik where grafik_nomi = '" + textBox1.Text.Trim() + "')"))
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

            for(int i = 1; i <= sikl; i++)
            {
                if (!_dataBase.InsertData("insert into grafik (grafik_nomi, kun) values('" + textBox1.Text.Trim() + "'," + i + ")"))
                    break;
            }

            //_dataBase.InsertData("select update_access_group('" + textBox1.Text.Trim() + "')");
            UpdateGrid("select *from grafik where grafik_nomi = '" + textBox1.Text.Trim() + "' order by kun desc");

            FillListview();
        }

        private void UpdateGrid(string query)
        {
            var grafiks = _dataBase.GetGrafik(query);
            ClearAll();
            foreach (MyGrafik grafik in grafiks)
            {
                dataGridView1.Rows.Insert(
                    0,
                    grafik.Grafik_nomi,
                    grafik.Smena_boshlanishi,
                    grafik.Smena_tugashi,
                    grafik.Obed_boshlanishi,
                    grafik.Obed_tugashi,
                    grafik.Kech_keldi,
                    grafik.Vox_ketdi,
                    grafik.Kun);
            }
        }

        private void ClearAll()
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox3.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid("select *from grafik where grafik_nomi = '" + listBox1.Items[listBox1.SelectedIndex].ToString() + "'" +
                " order by kun desc");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                CustomMessageBox.Info("Выберите график");
                return;
            }        
            
            // Need to finde alternatives, it's in rush
            if(_dataBase.CheckDB("select exists(select 1 from grafik_employee where grafik_nomi = '" + listBox1.Items[listBox1.SelectedIndex].ToString() + "')"))
            {
                CustomMessageBox.Warning("График исползуется");
                return;
            }

            //if (_dataBase.CheckDB("select exists(select 1 from access_employee where grafik_nomi = '" + textBox1.Text.Trim() + "')"))
            //{
            //    CustomMessageBox.Warning("График исползуется");
            //    return;
            //}            

            if (_dataBase.InsertData(
                "delete from grafik where grafik_nomi = '" + listBox1.Items[listBox1.SelectedIndex].ToString() + "';" + 
                "delete from grafik_employee where grafik_nomi = '" + listBox1.Items[listBox1.SelectedIndex].ToString() + "';" /*+
                "delete from access_employee where grafik_nomi = '" + listBox1.Items[listBox1.SelectedIndex].ToString() + "';" +
                "delete from access_group where grafik_nomi = '" + listBox1.Items[listBox1.SelectedIndex].ToString() + "';"*/))
            {
                ClearAll();
                FillListview();
            }
               
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(8) && e.RowIndex != -1)
            {
                string gr_nomi = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                UpdateGrid("update grafik set smena_boshlanishi = null, smena_tugashi = null, obed_boshlanishi = null," +
                    "obed_tugashi = null, kech_keldi = null, vox_ketdi = null where grafik_nomi = '" + gr_nomi +
                    "' and kun = " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) + ";" +
                    "select *from grafik where grafik_nomi = '" + gr_nomi + "'" + " order by kun desc");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
