using System;
using System.Windows.Forms;

namespace AsmeFace
{
    class CustomLog
    {
        public static void WriteToFile(string Message)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AsmeLogs";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AsmeLogs\\Log-" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!System.IO.File.Exists(filepath))
            {
                // Create a file to write to.   
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (System.IO.StreamWriter sw = System.IO.File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
