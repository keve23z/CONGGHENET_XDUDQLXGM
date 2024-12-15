using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class frm_UserApp : Form
    {

        private NhanVien CurrentNhanVien;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        private List<HoaDon> hoaDonXuats = new List<HoaDon>();
        private List<HoaDon> hoaDonNhaps = new List<HoaDon>();
        private List<SanPham> sanPhams = new List<SanPham>();
        private List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
        private List<KhachHang> khachHangs = new List<KhachHang>();

        public void LoadHDX()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM HD_XUAT_BAOHANH ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaHD = readerHD["MAHD_XUAT"].ToString();
                hoaDon.SDT_KH = readerHD["SDT_KH"].ToString();
                hoaDon.Ma_NV = readerHD["MA_NV"].ToString();
                hoaDon.TongBill= decimal.Parse(readerHD["TONGBILL_XUAT"].ToString());
                hoaDon.PhuongThucGiaoDich= readerHD["PHUONGTHUCGIAODICH"].ToString();
                hoaDon.Ngay = Convert.ToDateTime(readerHD["NGAYXUAT"]).ToString("dd-MM-yyyy");
                hoaDonXuats.Add(hoaDon);
            }
            conn.Close();
        }
        public void LoadHDN()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM HD_NHAP ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaHD = readerHD["MAHD_NHAP"].ToString();
                hoaDon.MA_NCC = readerHD["MA_NCC"].ToString();
                hoaDon.Ma_NV = readerHD["MA_NV"].ToString();
                hoaDon.TongBill = decimal.Parse(readerHD["TONGBILL_NHAP"].ToString());
                hoaDon.Ngay = Convert.ToDateTime(readerHD["NGAYNHAP"]).ToString("dd-MM-yyyy");
                hoaDonNhaps.Add(hoaDon);
            }
            conn.Close();
        }
        public void LoadSP()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM SANPHAM ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                SanPham sanPham = new SanPham();
                sanPham.MA_SP = readerHD["MA_SP"].ToString();
                sanPham.TEN_SP = readerHD["TEN_SP"].ToString();
                sanPham.MOTA_SP = readerHD["MOTA_SP"].ToString();
                sanPham.SOLUONG_SP = int.Parse(readerHD["SOLUONG_SP"].ToString());
                sanPham.GIA_NHAP = decimal.Parse(readerHD["GIA_NHAP"].ToString());
                sanPham.GIA_BAN = decimal.Parse(readerHD["GIA_BAN"].ToString());
                sanPham.TGBAOHANH = int.Parse(readerHD["TGBAOHANH"].ToString());
                sanPham.ANH_SP = readerHD["ANH_SP"].ToString();
                sanPham.MA_LOAI = readerHD["MA_LOAI"].ToString();
                sanPhams.Add(sanPham);
            }
            conn.Close();
        }
        public void LoadNCC()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM NHACUNGCAP ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                NhaCungCap nhaCungCap = new NhaCungCap();
                nhaCungCap.MaNCC = readerHD["MA_NCC"].ToString();
                nhaCungCap.TenNCC = readerHD["TEN_NCC"].ToString();
                nhaCungCaps.Add(nhaCungCap);
            }
            conn.Close();
        }
        public void LoadKH()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM KHACHHANG ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                KhachHang khachHang = new KhachHang();
                khachHang.SDT_KH = readerHD["SDT_KH"].ToString();
                khachHang.TENKH = readerHD["TENKH"].ToString();
                khachHang.DIACHI_KH = readerHD["DIACHI_KH"].ToString();
                khachHang.MAIL = readerHD["MAIL"].ToString();  
                khachHangs.Add(khachHang);
            }
            conn.Close();
        }
        public frm_UserApp(NhanVien nhanVien)
        {
            InitializeComponent();
            CurrentNhanVien = nhanVien;
        }
        public void LoadInfor()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT NHANVIEN.CHUCVU,NHANVIEN.SDT_NV,NHANVIEN.TENNV,NHANVIEN.GIOITINH,NHANVIEN.NGAYSINH,NHANVIEN.DIACHI_NV" +
                                             " FROM NHANVIEN " +
                                             "WHERE MA_NV='" + CurrentNhanVien.Login + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CurrentNhanVien.MaNV = CurrentNhanVien.Login;
                CurrentNhanVien.TenNV = reader["TENNV"].ToString();
                CurrentNhanVien.SDT_NV = reader["SDT_NV"].ToString();
                CurrentNhanVien.ChucVu = reader["CHUCVU"].ToString();
                CurrentNhanVien.GioiTinh = reader["GIOITINH"].ToString();
                CurrentNhanVien.NgaySinh = reader["NGAYSINH"].ToString();
                CurrentNhanVien.DiaChi = reader["DIACHI_NV"].ToString();
            }
            conn.Close();
        }
        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            User_KhachHang khachHang = new User_KhachHang();
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(khachHang);
            khachHang.Dock = DockStyle.Fill;
            khachHang.BringToFront();
            this.Text = "KHÁCH HÀNG";
        }

        private void btn_NhapHang_Click(object sender, EventArgs e)
        {
            User_NhapHang nhapHang = new User_NhapHang(CurrentNhanVien, hoaDonNhaps, sanPhams,nhaCungCaps);
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(nhapHang);
            nhapHang.Dock = DockStyle.Fill;
            nhapHang.BringToFront();
            this.Text = "NHẬP HÀNG";
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            User_HoaDon hoaDon=new User_HoaDon(CurrentNhanVien,hoaDonXuats, sanPhams, khachHangs);
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(hoaDon);
            hoaDon.Dock = DockStyle.Fill;
            hoaDon.BringToFront();
            this.Text = "HOÁ ĐƠN";
        }

        private void btn_TTNV_Click(object sender, EventArgs e)
        {
            User_ThongTinCaNhan ThongTinCaNhan = new User_ThongTinCaNhan(CurrentNhanVien);
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(ThongTinCaNhan);
            ThongTinCaNhan.Dock = DockStyle.Fill;
            ThongTinCaNhan.BringToFront() ;
            this.Text = "THÔNG TIN CÁ NHÂN";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r= MessageBox.Show("Bạn có muốn ĐĂNG XUẤT?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                return; 
            }
            // Xóa thông tin đăng nhập
            if (CurrentNhanVien != null)
            {
                CurrentNhanVien.Login = null;
                CurrentNhanVien.Pass = null;
            }

            // Quay lại form Login
            foreach (Form form in Application.OpenForms)
            {
                if (form is frm_Login loginForm)
                {
                    loginForm.Show(); // Hiển thị lại form Login
                    break;
                }
            }

            this.Close(); // Đóng form UserApp
        }
        public string GetMiddleAndLastName(string fullName)
        {
            var words = fullName.Trim().Split(' ');

            if (words.Length == 1)
            {
                return fullName;
            }

            if (words.Length == 2)
            {
                return fullName;
            }

            return string.Join(" ", words.Skip(1));
        }

        private void frm_UserApp_Load(object sender, EventArgs e)
        {
            LoadHDX();
            LoadHDN();
            LoadSP();
            LoadKH();
            LoadNCC();
            LoadInfor();
            lb_br3.Text = GetMiddleAndLastName(CurrentNhanVien.TenNV);
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {

            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(picb_bgrUser);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_AdminApp themNhanVien = new frm_AdminApp();
            themNhanVien.Show();
            this.Text = "QUẢN LÝ NHÂN VIÊN";
        }

       

        private void btn_XuatHoaDon_Click_1(object sender, EventArgs e)
        {
            User_XuatHoaDon xuatHoaDon = new User_XuatHoaDon();
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(xuatHoaDon);
            xuatHoaDon.Dock = DockStyle.Fill;
            xuatHoaDon.BringToFront();
            this.Text = "XUẤT HOÁ ĐƠN";
        }
    }
}
