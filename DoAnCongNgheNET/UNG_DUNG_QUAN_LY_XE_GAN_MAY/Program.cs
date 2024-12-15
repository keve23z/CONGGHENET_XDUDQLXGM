using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_LoadApp());
            //Application.Run(new frm_AdminApp());

            //NhanVien nhan = new NhanVien
            //{
            //    Login = "NV002",
            //    Pass = "101010"
            //};
            //Application.Run(new frm_UserApp(nhan));
        }
    }
}
