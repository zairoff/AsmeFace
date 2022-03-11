using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AsmeFace.Forms
{
    public partial class BulkRegister : Form
    {
        public BulkRegister()
        {
            InitializeComponent();
            dataBase = new DataBase();
        }

        private readonly DataBase dataBase;

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;

            var file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                filePath = file.FileName;
                fileExt = Path.GetExtension(filePath);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    button3.Enabled = false;
                    var thread = new Thread(() => ImportDepartment(filePath));
                    thread.Start();
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }           
        }

        private void ImportDepartment(string filePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Workbook xlWorkbook = null;
            Worksheet xlWorksheet = null;
            Range xlRange = null;
            try
            {

                xlWorkbook = xlApp.Workbooks.Open(filePath);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                BeginInvoke(new MethodInvoker(() => progressBar1.Maximum = rowCount));

                string root = "TDYU";
                for (int i = 1; i < rowCount; i++)
                {
                    var bulinma = xlRange.Cells[(i + 1), 4];
                    var lavozim = xlRange.Cells[(i + 1), 5];

                    if (bulinma != null && lavozim != null)
                    {
                        bulinma = bulinma.Value.ToString();
                        var bulinmaRp = bulinma.Replace(" ", "");
                        lavozim = lavozim.Value.ToString();
                        var lavozimRp = lavozim.Replace(" ", "");

                        bool exists = dataBase.CheckDB(System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("select exists(select 1 from department where mytree = '" + root + "." + bulinmaRp + "')")));
                        if (exists)
                        {
                            exists = dataBase.CheckDB(System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("select exists(select 1 from department where mytree = '" + root + "." + bulinmaRp + "." + lavozimRp + "')")));

                            if (exists)
                            {
                                BeginInvoke(new MethodInvoker(delegate ()
                                {
                                    dataGridView2.Rows.Insert(0, bulinma, lavozim, "already exist");
                                }));
                                continue;
                            }
                            else
                            {
                                Insert(System.Text.Encoding.UTF8.GetString(
                                    System.Text.Encoding.UTF8.GetBytes(
                                        "insert into department (ttext, mytree) values('" + lavozim + "','" + root + "." + bulinmaRp + "." + lavozimRp + "')")));
                            }
                        }
                        else
                        {
                            Insert(System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("insert into department (ttext, mytree) values('" + bulinma + "','" + root + "." + bulinmaRp + "')")));
                            Insert(System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("insert into department (ttext, mytree) values('" + lavozim + "','" + root + "." + bulinmaRp + "." + lavozimRp + "')")));
                        }

                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            dataGridView2.Rows.Insert(0, bulinma, lavozim, "added");
                        }));
                    }
                    BeginInvoke(new MethodInvoker(() => progressBar1.Value = i));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                BeginInvoke(new MethodInvoker(delegate ()
                {
                    button3.Enabled = true;

                }));
            }
        }

        private void Insert(string query)
        {
            dataBase.InsertData(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;

            var file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                filePath = file.FileName;
                fileExt = Path.GetExtension(filePath);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    button3.Enabled = false;
                    var thread = new Thread(() => ImportEmployee(filePath));
                    thread.Start();
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                var i2 = new Bitmap(imageIn);
                i2.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void ImportEmployee(string filePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Workbook xlWorkbook = null;
            Worksheet xlWorksheet = null;
            Range xlRange = null;
            try
            {

                xlWorkbook = xlApp.Workbooks.Open(filePath);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count - 1;
                int colCount = xlRange.Columns.Count;

                BeginInvoke(new MethodInvoker(() => progressBar2.Maximum = rowCount));
                string root = "TDYU";
                for (int i = 1; i < rowCount; i++)
                {
                    //Picture pic = (Picture)xlWorksheet.Pictures(i + 1);
                    //pic.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);
                    //byte[] image = null;
                    //if (Clipboard.ContainsImage())
                    //{
                    //    //pictureBox1.Image = Clipboard.GetImage();
                    //    image = ImageToByteArray(Clipboard.GetImage());
                    //}

                    var employeeID = xlRange.Cells[(i + 1), 1].Value?.ToString();
                    var names = xlRange.Cells[(i + 2), 2].Value?.ToString().Split(' ');
                    var firstName = names[1];
                    var lastName = names[0];
                    string familyName = "";

                    if (names.Length > 3)
                    {
                        familyName = names[2] + " " + names[3];
                    }
                    else
                    {
                        familyName = names[2];
                    }

                    var passport = xlRange.Cells[(i + 2), 3].Value?.ToString().Replace(" ", "");
                    var department = xlRange.Cells[(i + 2), 4].Value?.ToString();
                    var position = xlRange.Cells[(i + 2), 5].Value?.ToString();
                    var departmentCheck = root + "." + department.Replace(" ", "") + "." + position.Replace(" ", "");
                    var shtat = xlRange.Cells[(i + 2), 6].Value?.ToString();
                    var address = xlRange.Cells[(i + 2), 7].Value?.ToString().Replace(" ", "");

                    var path = Path.GetDirectoryName(filePath);

                    string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                    byte[] image = null;
                    
                    foreach (var file in files)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(file).Replace(" ", "");
                        if (fileName == passport)
                        {
                            image = File.ReadAllBytes(file);
                            break;
                        }
                    }

                    if(image is null)
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            dataGridView1.Rows.Insert(
                                        0,
                                        employeeID,
                                        firstName + " " + lastName,
                                        position,
                                        "Image not found");
                            progressBar2.Value = i;

                        }));
                        continue;
                    }

                    bool exists = dataBase.CheckDB(System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("select exists(select 1 from department where mytree = '" + departmentCheck + "')")));

                    if (!exists)
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            dataGridView1.Rows.Insert(
                                        0,
                                        employeeID,
                                        firstName + " " + lastName,
                                        position,
                                        "department or subdepartment not found");
                            progressBar2.Value = i;

                        }));
                        continue;
                    }

                    exists = dataBase.CheckDB(System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("select exists(select 1 from employee where employeeid = " + employeeID + ")")));

                    if (exists)
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            dataGridView1.Rows.Insert(
                                        0,
                                        employeeID,
                                        firstName + " " + lastName,
                                        position,
                                        "employeeID already exist");
                            progressBar2.Value = i;

                        }));
                        continue;
                    }

                    //string department2 = Convert.ToString(department);

                    //dataBase.InsertFace(System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes("insert into employee (employeeid, ism, familiya, otchestvo, department, otdel, lavozim, status, address, shtat, passport) " +
                    //                    "values(" + employeeID + ",'" + firstName + "','" + lastName + "','" + familyName + "','" + departmentCheck + "','" + department +
                    //                    "','" + position + "', true, '" + address + "','" + shtat + "','" + passport + "')")));


                    dataBase.InsertFace("insert into employee (employeeid, photo, finger, ism, familiya, otchestvo, department, otdel, lavozim, status, address, shtat, passport) " +
                                        "values(" + employeeID + ",@Image, @Finger,'" + firstName + "','" + lastName + "','" +
                                        familyName + "','" + departmentCheck + "','" + department + "','" + position + "', true, '" +
                                        address + "','" + shtat + "','" + passport + "')", image, null);

                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        dataGridView1.Rows.Insert(
                                    0,
                                    employeeID,
                                    firstName + " " + lastName,
                                    position,
                                    "OK");

                        progressBar2.Value = i;

                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                BeginInvoke(new MethodInvoker(delegate ()
                {
                    button3.Enabled = true;

                }));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
