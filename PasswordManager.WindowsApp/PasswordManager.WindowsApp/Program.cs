using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.WindowsApp
{
    static class Program
    {

        public static class MyStaticValues
        {
            public static int userID  { get; set; }
        }



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var main = new frmLogin();
            main.FormClosed += new FormClosedEventHandler(FormClosed);
            main.Show();
            Application.Run();

            //Application.Run(new frmLogin());
        }




        static void FormClosed(object sender, FormClosedEventArgs e)
        {

            ((Form)sender).FormClosed -= FormClosed;

            if(Application.OpenForms.Count ==0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += FormClosed;
            }       

        }

    }
}
