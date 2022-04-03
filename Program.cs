using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{

    static class Program
    {
        public static bool OpenDetailFormRegister { get; set; }
        public static bool OpenDetailFormLogin { get; set; }
        public static bool OpenDetailFormMenu { get; set; }
        public static bool CheckExit { get; set; }
     
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenDetailFormRegister = false;
            OpenDetailFormLogin = false;
            CheckExit = true;
           
            Application.Run(new LoginForm());
            while (CheckExit==true)
            {
                if (OpenDetailFormRegister)
                {
                    Application.Run(new RegisterForm());
                }
                if (OpenDetailFormLogin)
                {
                    Application.Run(new LoginForm());
                }
                if (OpenDetailFormMenu)
                {
                    Application.Run(new MenuForm());
                }

            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
