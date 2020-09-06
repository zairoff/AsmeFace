namespace AsmeFace
{
    public class GetTree
    {
        public void FindByText(System.Windows.Forms.TreeNode tree, System.Windows.Forms.TreeView treeView)
        {
            System.Windows.Forms.TreeNodeCollection nodes = treeView.Nodes;
            if (nodes.Count < 1)
            {
                treeView.Nodes.Add(tree);
                return;
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Name == tree.Name.Replace("." + tree.Text.Replace(" ", ""), ""))
                {
                    nodes[i].Nodes.Add(tree);
                    return;
                }
                AddNodes(nodes[i], tree);
            }
        }

        private void AddNodes(System.Windows.Forms.TreeNode treeNode, System.Windows.Forms.TreeNode tree)
        {
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                if (treeNode.Nodes[i].Name == tree.Name.Replace("." + tree.Text.Replace(" ", ""), ""))
                    treeNode.Nodes[i].Nodes.Add(tree);
                AddNodes(treeNode.Nodes[i], tree);
            }
        }

        public void ClearBackColor(System.Windows.Forms.TreeView treeView, System.Drawing.Color color)
        {
            System.Windows.Forms.TreeNodeCollection nodes = treeView.Nodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                ClearRecursive(nodes[i], treeView, color);
            }
        }

        private void ClearRecursive(System.Windows.Forms.TreeNode treeNode, System.Windows.Forms.TreeView treeView,
            System.Drawing.Color color)
        {
            treeView.Nodes[0].BackColor = color;
            treeView.Nodes[0].ForeColor = System.Drawing.Color.Black;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                treeNode.Nodes[i].BackColor = color;
                treeNode.Nodes[i].ForeColor = System.Drawing.Color.Black;
                ClearRecursive(treeNode.Nodes[i], treeView, color);
            }
        }
    }
}
