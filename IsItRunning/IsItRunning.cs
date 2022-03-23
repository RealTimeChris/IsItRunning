using System;
using System.Diagnostics;
using System.ServiceProcess;

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
            string processName01 = "MBot-Janny-Cpp";
            Process[] results = Process.GetProcessesByName(processName01);
            if (results.Length == 1)
            {

            }
            else if (results.Length == 0)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "powershell.exe";
                startInfo.Arguments = @"C:\Users\Chris\source\repos\BotRunning\BootAndSave-Janny.ps1";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
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
