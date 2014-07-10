using System;
using System.Windows.Forms;
using FireDeptFeesTool.Forms;
using FireDeptFeesTool.Helpers;

namespace FireDeptFeesTool
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ImportForm());
            //Application.Run(new MainForm());
            Application.Run(new ShellForm());
            //Application.Run(new PrintSelection());
            //Application.Run(new ManageSettingsForm());
        }
    }
}