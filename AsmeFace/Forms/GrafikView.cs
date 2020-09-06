using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class GrafikView : Form
    {
        public GrafikView(int ID, string grafik, string dan, string gacha)
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _dataBase.GetRecords("select *from grafik_view(" + ID + ",'" + 
                grafik + "','" + dan + "','" + gacha + "')", dataGridView1);

            dataGridView1.Columns[0].HeaderText = "День";
            dataGridView1.Columns[1].HeaderText = "Число";
            dataGridView1.Columns[2].HeaderText = "Начало";
            dataGridView1.Columns[3].HeaderText = "Окончание";
            dataGridView1.Columns[4].HeaderText = "Начало прерыва";
            dataGridView1.Columns[5].HeaderText = "Окончание прерыва";
            dataGridView1.Columns[6].HeaderText = "Опоздание";
            dataGridView1.Columns[7].HeaderText = "Ранный уход";
        }

        private DataBase _dataBase;

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
