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

            dataGridView1.Columns[0].HeaderText = Properties.Resources.GRAFIK_VIEW_DAY;
            dataGridView1.Columns[1].HeaderText = Properties.Resources.GRAFIK_VIEW_DATE;
            dataGridView1.Columns[2].HeaderText = Properties.Resources.GRAFIK_VIEW_START;
            dataGridView1.Columns[3].HeaderText = Properties.Resources.GRAFIK_VIEW_FINISH;
            dataGridView1.Columns[4].HeaderText = Properties.Resources.GRAFIK_VIEW_BREAK_START;
            dataGridView1.Columns[5].HeaderText = Properties.Resources.GRAFIK_VIEW_BREAK_END;
            dataGridView1.Columns[6].HeaderText = Properties.Resources.GRAFIK_VIEW_BREAK_LATE;
            dataGridView1.Columns[7].HeaderText = Properties.Resources.GRAFIK_VIEW_BREAK_EARLY;
        }

        private DataBase _dataBase;

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
