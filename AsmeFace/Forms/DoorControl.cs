﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class DoorControl : Form
    {
        public DoorControl()
        {
            InitializeComponent();                 
        }

        private DataBase _dataBase;
        private GetTree _getTree;
        private AsmeDevice _asmeDevice;
        private List<Employee> _employees;

        private void FillTree()
        {
            List<Tree> myTrees = _dataBase.GetTree("select ttext, mytree from department order by id asc");
            for (int i = 0; i < myTrees.Count; i++)
            {
                TreeNode tnode = new TreeNode
                {
                    Name = myTrees[i].Tname,
                    Text = myTrees[i].Ttext
                };
                _getTree.FindByText(tnode, treeView1);
            }
        }        

        private void GetDevices()
        {
            var doors = _dataBase.GetStringList("select name from doors");
            foreach(var door in doors)
            {
                checkedListBox2.Items.Add(door);
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                GetEmployee("select employeeid, photo, finger, card, ism, familiya, otchestvo, " +
                "otdel, lavozim, address from employee where department <@ '"
                + treeView1.SelectedNode.Name + "' and status = true order by employeeid desc");
            }
            catch (Exception ex)
            {

            }            
        }   
        
        private void GetEmployee(string query)
        {
            _employees = _dataBase.GetEmployee(query);

            checkedListBox1.Items.Clear();
            //checkedListBox1.Dispose();

            if (_employees.Count < 1)
                return;

            for (int i = 0; i < _employees.Count; i++)
            {
                checkedListBox1.Items.Add(_employees[i].Familiya + " " + _employees[i].Ism + " " + _employees[i].Otchestvo);
            }
        }

        private void DoorControl_Load(object sender, EventArgs e)
        {
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
            WindowState = FormWindowState.Maximized;

            _dataBase = new DataBase();
            _getTree = new GetTree();
            _asmeDevice = new AsmeDevice();
            FillTree();
            GetDevices();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckList(checkedListBox1, checkBox1);
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckList(checkedListBox2, checkBox2);
        }

        private void CheckList(CheckedListBox checkedListBox, CheckBox checkBox)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, checkBox.Checked);
            }
        }

        private void Syncronize()
        {
            try
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    label4.Text = Properties.Resources.DOOR_CONTROL_SYNCING;
                    button1.Enabled = false;
                    button2.Enabled = false;
                }));

                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                {
                    if (checkedListBox1.GetItemChecked(j))
                    {
                        for (int i = 0; i < checkedListBox2.Items.Count; i++)
                        {
                            if (checkedListBox2.GetItemChecked(i))
                            {
                                var devices = _dataBase.GetDevices("select *from devices where device_door = '" +
                                    checkedListBox2.Items[i].ToString() + "'");
                                foreach (var device in devices)
                                {
                                    SyncAction(_employees[j], device);
                                }
                            }
                        }
                    }
                }

                BeginInvoke(new MethodInvoker(delegate ()
                {
                    label4.Text = Properties.Resources.DOOR_CONTROL_FINISHED;
                    button1.Enabled = true;
                    button2.Enabled = true;
                }));
            }
            catch(Exception msg)
            {
                CustomMessageBox.Error(msg.ToString());
            }            
        }

        private void SyncAction(Employee employee, DeviceInfo device)
        {
            int nRes = _asmeDevice.DetectController(device.dwIPAddress);

            if (nRes < 0)
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    dataGridView1.Rows.Insert(
                        0,
                        employee.Familiya + " " + employee.Ism,
                        device.dwIPAddress,
                        "Failed to DetectController: " + _asmeDevice.GetResponse(nRes)
                        );
                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                }));
                return;
            }

            nRes = _asmeDevice.OpenDevice(device.dwIPAddress);

            if (nRes < 0) 
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    dataGridView1.Rows.Insert(
                        0,
                        employee.Familiya + " " + employee.Ism,
                        device.dwIPAddress,
                        "Failed to open: " + _asmeDevice.GetResponse(nRes)
                        );
                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                }));
                return;
            }          
            
            

            if (employee.Finger != null && string.Equals(device.dwType, "Finger"))
            {
                //CustomLog.WriteToFile("FINGER");
                var unmanagedPointer = Marshal.AllocHGlobal(employee.Finger.Length);
                Marshal.Copy(employee.Finger, 0, unmanagedPointer, employee.Finger.Length);                
                nRes = _asmeDevice.SetFinger(employee.ID, unmanagedPointer);
                Marshal.FreeHGlobal(unmanagedPointer);

                if (nRes < 0)
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        dataGridView1.Rows.Insert(
                            0,
                            employee.Familiya + " " + employee.Ism,
                            device.dwIPAddress,
                            "Failed to set fingerprint: " + _asmeDevice.GetResponse(nRes)
                            );
                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                    }));
                    _asmeDevice.CloseDevice();
                    return;
                }
            }

            if (string.Equals(device.dwType, "Face"))
            {
                //CustomLog.WriteToFile("FACE");

                nRes = _asmeDevice.WriteFace(employee.Photo, employee.ID);

                if (nRes < 0)
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        dataGridView1.Rows.Insert(
                            0,
                            employee.Familiya + " " + employee.Ism,
                            device.dwIPAddress,
                            "Failed to set face: " + _asmeDevice.GetResponse(nRes)
                            );
                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                    }));
                    _asmeDevice.CloseDevice();
                    return;
                }
            }

            nRes = _asmeDevice.SetCard(employee.ID, employee.Card, 0);

            if (nRes < 0)
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    dataGridView1.Rows.Insert(
                        0,
                        employee.Familiya + " " + employee.Ism,
                        device.dwIPAddress,
                        "Failed to set card: " + _asmeDevice.GetResponse(nRes)
                        );
                    dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                }));
                _asmeDevice.CloseDevice();
                return;
            }

            BeginInvoke(new MethodInvoker(delegate ()
            {
                dataGridView1.Rows.Insert(
                    0,
                    employee.Familiya + " " + employee.Ism,
                    device.dwIPAddress,
                    "Success"
                    );
            }));

            _asmeDevice.CloseDevice();

            _dataBase.InsertData("select update_door_control('" + device.szMac + "'," + employee.ID + ")");
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Syncronize));
            thread.Start();
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SearchTextBox.Text))
                    return;

                GetEmployee("select employeeid, photo, finger, card, ism, familiya, otchestvo, otdel, lavozim, address, enrollment_number, amizone_code, shtat, passport " +
                            "from employee where familiya ILIKE '" +
                            SearchTextBox.Text.Trim() + "%' or ism  ILIKE '" +
                            SearchTextBox.Text.Trim() + "%' and status = true order by employeeid desc limit 50");
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
