﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class EmployeeInDevice : Form
    {
        public EmployeeInDevice()
        {
            InitializeComponent();
            _dataBase = new DataBase();
            _tree = new GetTree();
            _asmeDevice = new AsmeDevice();
            FillTree();
        }

        private DataBase _dataBase;
        private GetTree _tree;
        private AsmeDevice _asmeDevice;

        private void FillTree()
        {
            var myTrees = _dataBase.GetTree("select ttext, mytree from department order by id asc");
            for (int i = 0; i < myTrees.Count; i++)
            {
                TreeNode tnode = new TreeNode
                {
                    Name = myTrees[i].Tname,
                    Text = myTrees[i].Ttext
                };
                _tree.FindByText(tnode, treeView1);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RetriveData();
        }

        private void RetriveData()
        {
            var employees = _dataBase.GetEmployeeInDevices(
                "select t2.employeeid, t1.ism, t1.familiya, t1.otchestvo, t1.otdel, t1.lavozim, t3.device_mac, t3.device_ip, t3.device_type," +
                "t3.device_status, t3.device_door from control_doors t2 " +
                "inner join employee t1 on t1.employeeid = t2.employeeid " +
                "inner join devices t3 on t3.device_mac = t2.device_mac " +
                "where department <@ '" + treeView1.SelectedNode.Name + "' order by employeeid desc");

            dataGridView1.Rows.Clear();

            foreach (var employee in employees)
            {
                dataGridView1.Rows.Insert(
                    0,
                    employee.DeviceInfo.dwIPAddress,
                    employee.DeviceInfo.szMac,
                    employee.DeviceInfo.dwType,
                    employee.DeviceInfo.dwDoor,
                    employee.DeviceInfo.dwStatus,
                    employee.EmployeeShortInfo.ID,
                    employee.EmployeeShortInfo.Familiya + " " +
                    employee.EmployeeShortInfo.Ism + " " +
                    employee.EmployeeShortInfo.Otchestvo);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            if (dataGridView1.CurrentCell.ColumnIndex.Equals(7) && e.RowIndex != -1)
            {
                //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                int nRes = _asmeDevice.OpenDevice(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                if (nRes < 0)
                {
                    CustomMessageBox.Error("Failed to open the device " + nRes);
                    return;
                }

                nRes = _asmeDevice.DeleteCard(Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value));

                if (nRes < 0)
                {
                    CustomMessageBox.Error("Failed to delete card " + nRes);
                    _asmeDevice.CloseDevice();
                    return;
                }

                if (string.Equals(dataGridView1.CurrentRow.Cells[2].Value.ToString(), "Finger"))
                {
                    nRes = _asmeDevice.DeleteFinger(Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value));
                    if (nRes < 0)
                    {
                        CustomMessageBox.Error("Failed to delete finger " + nRes);
                        _asmeDevice.CloseDevice();
                        return;
                    }
                }

                if (string.Equals(dataGridView1.CurrentRow.Cells[2].Value.ToString(), "Face"))
                {
                    nRes = _asmeDevice.DeleteFace(Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value));
                    if (nRes < 0)
                    {
                        CustomMessageBox.Error("Failed to delete face " + nRes);
                        _asmeDevice.CloseDevice();
                        return;
                    }
                }

                _asmeDevice.CloseDevice();

                if (_dataBase.InsertData("delete from control_doors where device_mac = '" +
                    dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' and employeeid = " +
                    Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value)))
                {
                    CustomMessageBox.Info("Выполнено успещно");
                    RetriveData();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
