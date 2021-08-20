using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace KcptunUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void onStart(object sender, EventArgs e)
        {
            MessageBox.Show("Start", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "C:\\bin\\kcptun.exe";
            startInfo.Arguments = "-v";
            process.StartInfo = startInfo;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            string q = "";
            while (!process.HasExited)
            {
                q += process.StandardOutput.ReadToEnd();
            }
            Console.WriteLine(q);
        }

        private void onStop(object sender, EventArgs e)
        {
            MessageBox.Show("Stop", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onSelectConfig(object sender, EventArgs e)
        {
            MessageBox.Show("On click", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
