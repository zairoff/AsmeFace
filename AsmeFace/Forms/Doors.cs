using System;
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
                CustomMessageBox.Info(textBox1.Text + " " + Properties.Resources.EXIST);
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
                name + " " + Properties.Resources.DOORS_DELETE_DOOR,
                Properties.Resources.WARNING,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if(_dataBase.CheckDB("select exists(select 1 from devices where device_door = '" + name + "')"))
                {
                    CustomMessageBox.Error(Properties.Resources.DOORS_IN_USE);
                    return;
                }

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
                Properties.Resources.DOORS_EDIT_DOOR,
                Properties.Resources.WARNING,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    _dataBase.InsertData("update doors set main = " +
                     checkedListBox1.GetItemChecked(i) + " where name = '" + checkedListBox1.Items[i].ToString() + "'");
                }
                GetDoors();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || checkedListBox1.SelectedItem == null)
                return;

            var door = checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();

            if (_dataBase.InsertData(
                "update doors set name = '" + textBox1.Text + "' where name = '" + door + "';" +
                "update reports set door_name = '" + textBox1.Text + "' where door_name = '" + door + "';" +
                "update devices set device_door = '" + textBox1.Text + "' where device_door = '" + door + "';"))
                GetDoors();
        }
    }
}
