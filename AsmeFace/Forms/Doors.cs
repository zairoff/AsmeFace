using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class Doors : Form
    {
        private DataBase _dataBase;
        public Doors()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            GetDoors();
        }

        private void GetDoors()
        {
            var doors = _dataBase.GetDoors("select *from doors");
            checkedListBox1.Items.Clear();
            foreach (var door in doors)
            {
                checkedListBox1.Items.Add(door.Name, door.Main);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                return;

            if (_dataBase.CheckDB("select exists(select 1 from doors where name = '" + textBox1.Text + "')"))
            {
                CustomMessageBox.Info("Дверь " + textBox1.Text + " уже существует");
                return;
            }

            if (_dataBase.InsertData("insert into doors values('" + textBox1.Text + "')"))
            {
                GetDoors();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem == null)
                return;

            var name = checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();
            var dialogResult = MessageBox.Show(
                name + " удалить дверь?",
                "Основной дверь",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (_dataBase.InsertData("delete from doors where name = '" +
                checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString() + "'"))
                    GetDoors();
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }          

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem == null)
                return;

            var name = checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();
            var dialogResult = MessageBox.Show(
                " Изменить двери?",
                "Основной дверь",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                for(int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    _dataBase.InsertData("update doors set main = " +
                     checkedListBox1.GetItemChecked(i) + " where name = '" + checkedListBox1.Items[i].ToString() + "'");
                }
                GetDoors();
            }
        }
    }
}
