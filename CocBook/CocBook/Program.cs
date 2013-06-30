using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CocBook
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
            /*
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            */
            ConnectDBForm form1 = new ConnectDBForm();
            form1.Show();
            Application.Run();
            
        }
    }
}
