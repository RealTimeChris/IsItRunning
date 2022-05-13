using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IsItRunning
{
    public partial class IsItRunning : ServiceBase
    {
        public IsItRunning()
        {
            InitializeComponent();
        }
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string processName01 = "MBot-GameHouse";
            Process[] results = Process.GetProcessesByName(processName01);
            if (results.Length == 1)
            {

            }
            else if (results.Length == 0)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files\PowerShell\7\pwsh.exe";
                startInfo.Arguments = @"C:\Users\Chris\source\repos\BotRunning\BootAndSave-GameHouse.ps1";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = false;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
            }
        }
        protected override void OnStart(string[] args)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }
        System.Timers.Timer timer;
        protected override void OnStop()
        {

        }
    }
}
