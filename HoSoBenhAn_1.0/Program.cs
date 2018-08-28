using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;
using E00_Base;


namespace HISQLHSBA
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
            Application.Run(new frmhsluutru(new LibDal.AccessData(), "", "", 0, 1));
            //Application.Run(new frmNhanHS());
        }
    }
}
