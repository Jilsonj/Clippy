using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CLIPPY.NET
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [STAThread]
        static void Main(string[] args)
        {
            SendKeys.SendWait(("%{TAB}"));
            Thread.Sleep(850);
            //SendKeys.SendWait(("^{c}"));

            var text = Clipboard.GetText(System.Windows.Forms.TextDataFormat.Text);

            var result = ExecuterFinder.FindAndExecute(text);
            Process process = Process.GetCurrentProcess();

            Clipboard.SetText(result);

        }
    }
}
