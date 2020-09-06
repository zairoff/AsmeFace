using System.Windows.Forms;

namespace AsmeFace.UserControls
{
    public partial class Department : UserControl
    {
        public Department()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _tree = new GetTree();
            FillTree();
        }

        private DataBase _dataBase;
        private GetTree _tree;

        private void FillTree()
        {
            var trees = _dataBase.GetTree("select ttext, mytree from department order by id asc");
            for (int i = 0; i < trees.Count; i++)
            {
                var tnode = new TreeNode
                {
                    Name = trees[i].Tname,
                    Text = trees[i].Ttext
                };
                _tree.FindByText(tnode, treeView1);               
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (treeView1.SelectedNode == null || string.IsNullOrEmpty(textBox1.Text))
                return;

            var str = treeView1.SelectedNode.FullPath.ToString().Replace(" ", "");
            str += "." + textBox1.Text.Replace(" ", "");           
            var query = "insert into department (ttext, mytree) values ('" + textBox1.Text + "','" + str + "')";
            var bt = System.Text.Encoding.UTF8.GetBytes(query);

            if (_dataBase.InsertData(System.Text.Encoding.UTF8.GetString(bt)))
            {
                var mainNode = new TreeNode
                {
                    Name = str,
                    Text = textBox1.Text
                };
                treeView1.SelectedNode.Nodes.Add(mainNode);
                treeView1.SelectedNode.ExpandAll();
                _tree.ClearBackColor(treeView1, System.Drawing.Color.White);
                textBox1.Text = "";
                treeView1.SelectedNode = null;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _tree.ClearBackColor(treeView1, System.Drawing.Color.White);
            treeView1.SelectedNode.BackColor = System.Drawing.Color.Blue;
            treeView1.SelectedNode.ForeColor = System.Drawing.Color.White;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode == treeView1.Nodes[0])
                return;

            var query = "delete from department where mytree <@ '" + treeView1.SelectedNode.Name + "'";
            var bt = System.Text.Encoding.UTF8.GetBytes(query);

            if (_dataBase.InsertData(System.Text.Encoding.UTF8.GetString(bt)))
            {
                treeView1.Nodes.Clear();
                FillTree();
            }
        }
    }
}
