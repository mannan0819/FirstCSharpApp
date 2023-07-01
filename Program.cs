// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

[DllImport("USER32.DLL")]
static extern bool SetForegroundWindow(IntPtr hWnd);


[DllImport("USER32.DLL")]
static extern bool SetActiveWindow(IntPtr hWnd);

[DllImport("USER32.DLL")]
static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

Process[] processlist = Process.GetProcesses();


foreach (Process process in processlist)
{
    if (!String.IsNullOrEmpty(process.MainWindowTitle))
    {
        if (process.ProcessName.Contains("Spotify"))
        {
            Console.WriteLine("FOUND SPOTIFY");
            ShowWindow(process.MainWindowHandle, 3);
            SetForegroundWindow(process.MainWindowHandle);
            //SetActiveWindow(process.MainWindowHandle);
        }
        Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
    }
}

