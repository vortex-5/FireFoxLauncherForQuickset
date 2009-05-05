using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FirefoxLauncherForQuickset
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        int timer=0;
        int dir = 2;

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Region = new Region(RoundedRectangle.Create(this,20));
        }

        private void animi_Tick(object sender, EventArgs e)
        {
            this.Opacity = timer / 100.0;
            //this.Location = new Point (Location.X,timer*2);
            System.Diagnostics.Debug.WriteLine(timer);
            timer += dir;
            if (timer > 100)
            {
                dir = -2;
            }
            if (timer < 0)
            {
                this.Close();
            }
        }
        private void close_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void launch_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            String filename = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\firefox.exe", "", "ERROR").ToString();

            String currentPath = Application.StartupPath; //System.IO.Directory.GetCurrentDirectory(); //save our current path info
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\DMX.exe", "path", currentPath);

            //modify the DMX directory to reflect were we are currently installed


            
            if (filename == "ERROR")
            {
                MessageBox.Show("Error firefox not installed!");
                close.Stop();
                launch.Stop();
                this.Close();
            }
            else
            {
                proc.StartInfo.FileName = filename;
                proc.Start();
                launch.Stop();
            }
        }
    }
}