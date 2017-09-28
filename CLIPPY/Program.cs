using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CLIPPY
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        static void Main(string[] args)
        {
            //SendKeys.Send("%{TAB}")





            Process process = Process.GetCurrentProcess();
            SetForegroundWindow(process.MainModule.BaseAddress);

            Console.WriteLine("Hello World!");

        
        }
    }
}
