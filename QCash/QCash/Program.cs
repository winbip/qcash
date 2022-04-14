using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QCash
{
    static class Program //This class has an alternative at below. That is not bad.
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
            PreventMultipleInstance.Run(new frmMain());
        }
    }
}

//Alternative class starts=========================================
/*
    static class Program
    {
        //NOTE- USE THE FOLLOWING DIRECTIVES
        //using System;
        //using System.Windows.Forms;
        //using System.Diagnostics;
        //using System.Threading;
        //using System.Runtime.InteropServices;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [STAThread]
        static void Main()
        {
            bool NoInstanceFound;
            using (Mutex mutex = new Mutex(true, "Local\\MyAppName{D169586C-52F3-4C7B-85D4-A8D718436D0A}", out NoInstanceFound))
            {
                if (NoInstanceFound)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                else
                {
                    MessageBox.Show("The application is already running");
                    //return;
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }
    }
         
 */
//Alternative class ends ==========================================