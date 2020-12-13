using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.util;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (LoginSecurity.checkBossComputer())
            {
                //是管理员用的电脑
                Form1 f1 = new Form1();
                Application.Run(f1);
            }
            else
            {
                Login login = new Login();
                Application.Run(login);
            }


        }
    }
}
