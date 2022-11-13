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

                for (int i = 0; i < rowCount; i++)
                {
                    var ttext = xlRange.Cells[(i + 1), 1];
                    var mytree = xlRange.Cells[(i + 1), 2];
                    if (ttext != null && mytree != null)
                    {
                        ttext = ttext.Value.ToString();
                        mytree = mytree.Value.ToString().Replace(" ", "");

                        if (i == 0)
                        {
                            Insert("insert into department (ttext, mytree) values('" + ttext + "','" + mytree + "')");
                            BeginInvoke(new MethodInvoker(() => dataGridView2.Rows.Insert(0, ttext, mytree, "First departmenmt")));
                            continue;
                        }

                        bool exists = dataBase.CheckDB("select exists(select 1 from department where mytree = '" + mytree + "')");

                        if (exists)
                        {
                            mytree = mytree + "." + ttext;
                            Insert("insert into department (ttext, mytree) values('" + ttext + "','" + mytree + "')");
                            BeginInvoke(new MethodInvoker(() => dataGridView2.Rows.Insert(0, ttext, mytree)));
                        }
                        else
                        {
                            BeginInvoke(new MethodInvoker(delegate ()
                            {
                                dataGridView2.Rows.Insert(0, ttext, mytree, "sub-department not exist");
                            }));
                        }
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
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
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

                for (int i = 0; i < rowCount; i++)
                {
                    Picture pic = (Picture)xlWorksheet.Pictures(i + 1);
                    pic.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);
                    byte[] image = null;
                    if (Clipboard.ContainsImage())
                    {
                        //pictureBox1.Image = Clipboard.GetImage();
                        image = ImageToByteArray(Clipboard.GetImage());
                    }
                    var employeeID = xlRange.Cells[(i + 2), 1].Value?.ToString();
                    var card = xlRange.Cells[(i + 2), 3].Value?.ToString();
                    var firstName = xlRange.Cells[(i + 2), 4].Value?.ToString();
                    var lastName = xlRange.Cells[(i + 2), 5].Value?.ToString();
                    var familyName = xlRange.Cells[(i + 2), 6].Value?.ToString();
                    var department = xlRange.Cells[(i + 2), 7].Value?.ToString().Replace(" ", "");
                    var position = xlRange.Cells[(i + 2), 8].Value?.ToString().Replace(" ", "");
                    var departmentCheck = department + "." + position;
                    var address = xlRange.Cells[(i + 2), 10].Value?.ToString().Replace(" ", "");
                    var enrollment = xlRange.Cells[(i + 2), 11].Value?.ToString().Replace(" ", "");
                    var amizone = xlRange.Cells[(i + 2), 12].Value?.ToString().Replace(" ", "");

                    bool exists = dataBase.CheckDB("select exists(select 1 from department where mytree = '" + departmentCheck + "')");

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

                    exists = dataBase.CheckDB("select exists(select 1 from employee where employeeid = " + employeeID + ")");

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

                    string department2 = Convert.ToString(department);

                    dataBase.InsertFace("insert into employee (employeeid, photo, finger, card, ism, familiya, otchestvo, department, otdel, lavozim, status, address, enrollment_number, amizone_code) " +
                                        "values(" + employeeID + ",@Image, @Finger, '" + card + "','" + firstName + "','" + lastName + "','" +
                                        familyName + "','" + departmentCheck + "','" + department2.Split('.').Last() + "','" + position + "', true, '" +
                                        address + "','" + enrollment + "','" + amizone + "')", image, null);

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
