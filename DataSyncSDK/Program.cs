using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace DataSyncSDK
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
            string language = System.Globalization.CultureInfo.InstalledUICulture.Name;
            if (language.Equals("zh-CN"))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }
            Application.Run(new mainForm());
        }
    }
}
