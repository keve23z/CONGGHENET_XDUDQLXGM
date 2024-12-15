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
    public partial class frm_AdminApp : Form
    {

        public frm_AdminApp()
        {
            InitializeComponent();
            //ThemNhanVien themNhanVien = new ThemNhanVien();
            //pn_bg3.Controls.Add(themNhanVien);
            //themNhanVien.Dock = DockStyle.Fill;
            //themNhanVien.BringToFront();
            

        }
        private void frm_AdminApp_Load(object sender, EventArgs e)
        {
           
        }
       

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            
            Admin_ThongKe thongKe = new Admin_ThongKe();
            pn_bg3.Controls.Clear();
            pn_bg3.Controls.Add(thongKe);
            thongKe.Dock = DockStyle.Fill;
            thongKe.BringToFront();
            this.Text = "THỐNG KÊ";
        }




        private void btn_Them_Click(object sender, EventArgs e)
        {
            Admin_ThemNhanVien themNhanVien = new Admin_ThemNhanVien();
            pn_bg3.Controls.Add(themNhanVien);
            themNhanVien.Dock = DockStyle.Fill;
            themNhanVien.BringToFront();
            this.Text = "QUẢN LÝ NHÂN VIÊN";
        }

        private void btn_NCC_Click(object sender, EventArgs e)
        {
            Admin_NhaCungCap nhaCungCap = new Admin_NhaCungCap();
            pn_bg3.Controls.Add(nhaCungCap);
            nhaCungCap.Dock = DockStyle.Fill;
            nhaCungCap.BringToFront();
            this.Text = "QUẢN LÝ NHÀ CUNG CẤP";
        }

        private void btn_QLSP_Click(object sender, EventArgs e)
        {
            Admin_QuanLySP quanLySP = new Admin_QuanLySP();
            pn_bg3.Controls.Add(quanLySP);
            quanLySP.Dock = DockStyle.Fill;
            quanLySP.BringToFront();
            this.Text = "QUẢN LÝ SẢN PHẦM";
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            pn_bg3.Controls.Clear();

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn THOÁT?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                return;
            }

            foreach (Form form in Application.OpenForms)
            {
                if (form is frm_Login loginForm)
                {
                    loginForm.Show(); // Hiển thị lại form Login
                    break;
                }
            }
            this.Close(); 
        }

        private void btn_QLHD_Click(object sender, EventArgs e)
        {
            Admin_QuanLyHD quanLyHD = new Admin_QuanLyHD();
            pn_bg3.Controls.Add(quanLyHD);
            quanLyHD.Dock = DockStyle.Fill;
            quanLyHD.BringToFront();
            this.Text = "QUẢN LÝ HÓA ĐƠN";
        }
    }
}
