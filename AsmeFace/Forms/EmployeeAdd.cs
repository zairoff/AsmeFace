using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace AsmeFace.Forms
{
    public partial class EmployeeAdd : Form
    {
        public EmployeeAdd()
        {
            InitializeComponent();
            textBox1.Text = (_dataBase.GetID("select employeeid from employee order by employeeid desc limit 1") + 1).ToString();
            FillTree();
            _status = false;
        }

        public EmployeeAdd(int id)
        {
            InitializeComponent();
            var employee = _dataBase.GetEmployee(
                "select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim from employee " +
                "where employeeid = " + id);
            if(employee.Count > 0)
            {
                pictureBox1.Image = ByteToImage(employee[0].Photo);
                textBox1.Text = employee[0].ID.ToString();
                textBox2.Text = employee[0].Familiya;
                textBox3.Text = employee[0].Ism;
                textBox4.Text = employee[0].Otchestvo;
                textBox7.Text = employee[0].Card;               
                textBox8.Text = employee[0].Finger == null ? "" : System.Text.Encoding.UTF8.GetString(employee[0].Finger);
            }
            FillTree();
            _status = true;
        }

        private DataBase _dataBase = new DataBase();
        private GetTree _tree = new GetTree();
        private AsmeDevice _asmeDevice = new AsmeDevice();
        private readonly bool _status;

        private void FillTree()
        {
            var trees = _dataBase.GetTree("select ttext, mytree from department order by id asc");
            for (int i = 0; i < trees.Count; i++)
            {
                TreeNode tnode = new TreeNode
                {
                    Name = trees[i].Tname,
                    Text = trees[i].Ttext
                };
                _tree.FindByText(tnode, treeView1);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var dg = new OpenFileDialog();

            if (dg.ShowDialog() != DialogResult.OK)
                return;

            var image = System.Drawing.Image.FromFile(dg.FileName);

            if (image.Width < 240 || image.Width > 768 || image.Height < 320 || image.Height > 1024)
            {
                CustomMessageBox.Error("Image is not valid");
                return;
            }
            pictureBox1.Image = image;
        }

        private bool CheckFields()
        {
            return (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && pictureBox1.Image != null);
        }

        private void ClearFields()
        {
            textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
            textBox7.Text = ""; textBox8.Text = ""; pictureBox1.Image = null;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                var i2 = new System.Drawing.Bitmap(imageIn);
                i2.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private System.Drawing.Image ByteToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (CheckFields())
            {
                byte[] queryEncode = null;
                byte[] finger = null;
                var userID = Convert.ToInt32(textBox1.Text);
                var photo = ImageToByteArray(pictureBox1.Image);

                if (!string.IsNullOrEmpty(textBox8.Text))
                    finger = Convert.FromBase64String(textBox8.Text);

                if (!_status)
                {
                    queryEncode = System.Text.Encoding.UTF8.GetBytes("insert into employee (employeeid, photo, finger, " +
                    "card, ism, familiya, otchestvo, department, otdel, lavozim) values(" + userID + ", @Image, @Finger, '" +
                    textBox7.Text +"','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + treeView1.SelectedNode.Name +
                    "','" + textBox6.Text + "','" + textBox5.Text + "') returning employeeid");
                }
                else
                {
                    queryEncode = System.Text.Encoding.UTF8.GetBytes("update employee set photo = @Image, finger = @finger," +
                        "card = '" + textBox7.Text + "', familiya = '" + textBox2.Text + "', ism = '" + textBox3.Text +
                        "', otchestvo = '" + textBox4.Text + "'," + "department = '" + treeView1.SelectedNode.Name +
                        "', otdel = '" + textBox6.Text + "'," + "lavozim = '" + textBox5.Text + "' where employeeid = " + userID);
                }              

                var index = _dataBase.InsertFace(System.Text.Encoding.UTF8.GetString(queryEncode), photo, finger);
                if (index < 0)
                {
                    MessageBox.Show("Не удалось добавить в базу данных");
                    return;
                }
                
                ClearFields();
                textBox1.Text = (index + 1).ToString();
                CustomMessageBox.Info("Добавлено успещно!");
            }
            else
            {
                CustomMessageBox.Info("Пожалуйста, заполните все обязательные поля!");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _tree.ClearBackColor(treeView1, System.Drawing.SystemColors.Control);
            treeView1.SelectedNode.BackColor = System.Drawing.Color.Blue;
            treeView1.SelectedNode.ForeColor = System.Drawing.Color.White;
            textBox5.Text = treeView1.SelectedNode.Text;
            if (treeView1.SelectedNode == treeView1.Nodes[0])
                textBox6.Text = treeView1.SelectedNode.Text;
            else
                textBox6.Text = treeView1.SelectedNode.Parent.Text; 
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btn_finger_Click(object sender, System.EventArgs e)
        {
            try
            {
                textBox8.Text = "";
                int nRes = _asmeDevice.OpenDevice(System.Configuration.ConfigurationManager.AppSettings["finger"]);
                if (nRes < 0)
                {
                    CustomMessageBox.Error("Failed to open the device " + nRes);
                    return;
                }

                //var managedArray = new byte[570];
                var unmanagedPointer = Marshal.AllocHGlobal(570);
                //Marshal.Copy(employee.Finger, 0, unmanagedPointer, employee.Finger.Length);
                
                nRes = _asmeDevice.ReadFinger(unmanagedPointer);
                if (nRes < 0)
                {
                    CustomMessageBox.Error("Failed to read fingerprint " + nRes);
                    Marshal.FreeHGlobal(unmanagedPointer);
                    _asmeDevice.CloseDevice();
                    return;
                }             

                _asmeDevice.CloseDevice();
                var managedArray = new byte[570];
                Marshal.Copy(unmanagedPointer, managedArray, 0, 570);
                textBox8.Text = Convert.ToBase64String(managedArray);
                Marshal.FreeHGlobal(unmanagedPointer);
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
        }

        //private void btn_card_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        textBox7.Text = "";
        //        int nRes = _asmeDevice.OpenDevice(System.Configuration.ConfigurationManager.AppSettings["finger"].ToString());
        //        if (nRes < 0)
        //        {
        //            CustomMessageBox.Error("Failed to open the device " + nRes);
        //            return;
        //        }

        //        ulong card = 0;
        //        nRes = _asmeDevice.ReadCard(card);                              
        //        if (nRes < 0)
        //        {
        //            CustomMessageBox.Error("Failed to read fingerprint " + nRes);
        //            _asmeDevice.CloseDevice();
        //            return;
        //        }

        //        _asmeDevice.CloseDevice();

        //        textBox7.Text = card.ToString();
        //    }
        //    catch (Exception msg)
        //    {
        //        MessageBox.Show(msg.ToString());
        //    }
        //}
    }
}
