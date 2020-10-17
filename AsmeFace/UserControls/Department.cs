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
            if (treeView1.Nodes.Count == 0 && !string.IsNullOrEmpty(textBox1.Text))
            {
                InsertMainNode(textBox1.Text.Replace(" ", ""));
                return;
            }                     

            if (treeView1.SelectedNode == null || string.IsNullOrEmpty(textBox1.Text))
                return;

            InsertNodes(treeView1.SelectedNode.FullPath.ToString().Replace(" ", "") + "." + textBox1.Text.Replace(" ", ""));
            
        }

        private void InsertMainNode(string nodeName)
        {
            var query = "insert into department (ttext, mytree) values ('" + textBox1.Text.Trim() + "','" + nodeName + "')";

            if (_dataBase.InsertData(query))
            {
                var mainNode = new TreeNode
                {
                    Name = nodeName,
                    Text = textBox1.Text
                };
                treeView1.Nodes.Add(mainNode);
                textBox1.Text = "";
            }
        }

        private void InsertNodes(string nodeName)
        {
            //var str = treeView1.SelectedNode.FullPath.ToString().Replace(" ", "");
            //str += "." + textBox1.Text.Replace(" ", "");
            var query = "insert into department (ttext, mytree) values ('" + textBox1.Text.Trim() + "','" + nodeName + "')";

            if (_dataBase.InsertData(query))
            {
                var mainNode = new TreeNode
                {
                    Name = nodeName,
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
            if (treeView1.SelectedNode == null || string.IsNullOrEmpty(textBox1.Text))
                return;

            var fromTree = treeView1.SelectedNode.Text.Replace(" ", "");
            var toTree = textBox1.Text.Replace(" ", "");

            var fromText = treeView1.SelectedNode.Text.Trim();
            var toText = textBox1.Text.Trim();

            var query = "UPDATE department SET mytree = REPLACE(mytree::text, '" + fromTree + "','" + toTree + "')::ltree, ttext = REPLACE(ttext, '" + fromText + "','" + toText + "');" +
                        "UPDATE employee SET department = REPLACE(department::text, '" + fromTree + "','" + toTree + "')::ltree," +
                        "otdel = REPLACE(otdel, '" + fromText + "','" + toText + "'), lavozim = REPLACE(lavozim, '" + fromText + "','" + toText + "')";

            if (_dataBase.InsertData(query))
            {
                treeView1.Nodes.Clear();
                FillTree();
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode == treeView1.Nodes[0])
                return;

            var query = "delete from department where mytree <@ '" + treeView1.SelectedNode.Name + "'";
            //var bt = System.Text.Encoding.UTF8.GetBytes(query);

            if (_dataBase.InsertData(query))
            {
                treeView1.Nodes.Clear();
                FillTree();
            }
        }
    }
}
