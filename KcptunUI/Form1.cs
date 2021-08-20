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
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;

            startInfo.FileName = "C:\\bin\\kcptun.exe";
            startInfo.Arguments = "-c C:\\Users\\alcheung\\programs\\kcptun\\bwg.json";

            // process.StartInfo = startInfo;
            Process process = Process.Start(startInfo);

            var _ = ConsumeReader(process.StandardOutput);
            _ = ConsumeReader(process.StandardError);

            Console.WriteLine("Calling WaitForExit()...");
            process.WaitForExit();
            Console.WriteLine("Process has exited. Exit code: {0}", p.ExitCode);
            Console.WriteLine("WaitForExit returned.");
        }

        async static Task ConsumeReader(TextReader reader)
        {
            string text;

            while ((text = await reader.ReadLineAsync()) != null)
            {
                Console.WriteLine(text);
            }
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
