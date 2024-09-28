using GoldnetWrapper.Core;
using GoldnetWrapper.Core.Properties;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace GoldnetWrapper
{
    internal static class Program
    {

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_SHOW = 5; // Command to show the window

        [STAThread]
        static void Main(string[] args)
        {
            // Use the application name as the mutex name
            string mutexName = $"{Application.ProductName}Mutex"; // Dynamic mutex name based on app name
            bool createdNew;

            using (Mutex mutex = new Mutex(true, mutexName, out createdNew))
            {
                if (!createdNew)
                {
                    // Another instance is already running, find it and bring to the front
                    Process currentProcess = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                    {
                        if (process.Id != currentProcess.Id) // Exclude current process
                        {
                            // Bring the existing instance to the front
                            ShowWindow(process.MainWindowHandle, SW_SHOW);
                            SetForegroundWindow(process.MainWindowHandle);
                            break; // Exit the loop after finding the first instance
                        }
                    }
                    return; // Exit the current instance
                }
            }
            //Load important data before initializing the rest of the app
            RegistryHelper.LoadVariables();
            TGMSManager.LoadProperties();
            ReadOnlyVariables.tgms_address = TGMSManager.GetPropertyKey("tgms-address");
            int tgmsPort = 0; 
            int.TryParse(TGMSManager.GetPropertyKey("tgms-port"), out tgmsPort);
            ReadOnlyVariables.tgms_port = tgmsPort;


            //Initialize the app form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
