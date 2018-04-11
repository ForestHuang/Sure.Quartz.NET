using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sure.Quartz.CronForms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Globalization.CultureInfo UICulture = new System.Globalization.CultureInfo("en-GB");

            Thread.CurrentThread.CurrentUICulture = UICulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cron());
        }
    }
}
