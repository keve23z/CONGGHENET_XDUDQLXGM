using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class frm_LoadApp : Form
    {
        public frm_LoadApp()
        {
            InitializeComponent();
        }

        private void time_load_Tick(object sender, EventArgs e)
        {
            pn_Load1.Width += 6;
            if (pn_Load1.Width >= 636)
            {
                time_load.Stop();
                frm_Login frm = new frm_Login();
                frm.Show();
                this.Hide();

            }
        }
        //Data Source=DESKTOP-A4AOROR;Initial Catalog=QL_CH_Xe;Integrated Security=True;Encrypt=True;TrustServerCertificate=True
        private void frm_LoadApp_Load(object sender, EventArgs e)
        {

        }
    }
}
