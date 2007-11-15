using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace monitorSwitcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form theForm = new Form1();
            Application.Run(theForm);
        }
    }
}