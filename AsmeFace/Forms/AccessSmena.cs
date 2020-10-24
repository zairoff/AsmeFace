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
            RetriveSmena();
        }

        private DataBase _dataBase;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                return;

            if (_dataBase.CheckDB("select exists(select 1 from access_smena where access_smena_nomi = '" + textBox1.Text.Trim() + "')"))
            {
                CustomMessageBox.Info(Properties.Resources.SCHEDULE_EXIST);
                return;
            }

            var query = _dataBase.InsertData("insert into access_smena (access_smena_nomi, boshlanishi_1, tugashi_1, boshlanishi_2," +
                        "tugashi_2, boshlanishi_3, tugashi_3) values ('" + textBox1.Text.Trim() + "','" + dateTimePicker1.Text + "','" +
                        dateTimePicker2.Text + "','" + dateTimePicker3.Text + "','" + dateTimePicker4.Text + "','" +
                        dateTimePicker5.Text + "','" + dateTimePicker6.Text + "')");
            if (query)
                RetriveSmena();
        }

        private void RetriveSmena()
        {
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
            var list = _dataBase.GetAccessSmenas("select *from access_smena");
            foreach (var accessSmena in list)
            {
                dataGridView1.Rows.Insert(0,
                    accessSmena.AccessSmenaNomi,
                    accessSmena.Boshlanishi1,
                    accessSmena.Tugashi1,
                    accessSmena.Boshlanishi2,
                    accessSmena.Tugashi2,
                    accessSmena.Boshlanishi3,
                    accessSmena.Tugashi3);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                if (_dataBase.InsertData("delete from access_smena where access_smena_nomi = '" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + "'"))
                    RetriveSmena();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
