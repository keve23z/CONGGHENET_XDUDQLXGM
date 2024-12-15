using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Admin_ThongKe : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        public Admin_ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            Load_ThongKe();
            load_combox_Ngay_Thang_Nam();
        }

        private void Load_ThongKe()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(MA_NV) FROM NHANVIEN", conn);
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(SDT_KH) FROM KHACHHANG", conn);
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(MA_NCC) FROM NHACUNGCAP", conn);
            SqlCommand cmd3 = new SqlCommand("SELECT SUM(TONGBILL_XUAT) FROM HD_XUAT_BAOHANH", conn);
            SqlCommand cmd4 = new SqlCommand("SELECT SUM(TONGBILL_NHAP) FROM HD_NHAP", conn);
            SqlCommand cmd5 = new SqlCommand("SELECT SUM(SOLUONG_SP) FROM SANPHAM", conn);
            SqlCommand cmd6 = new SqlCommand("SELECT SUM(SL_SANPHAM) FROM CTHD_XUAT", conn);
            conn.Open();
            int tongNV = (int)cmd.ExecuteScalar();
            int tongKH = (int)cmd1.ExecuteScalar();
            int tongNCC = (int)cmd2.ExecuteScalar();
            decimal tongDoanhSo = (decimal)cmd3.ExecuteScalar();
            decimal tongTienChi = (decimal)cmd4.ExecuteScalar();
            int tongSP_TonKho = (int)cmd5.ExecuteScalar();
            int tongSP_Xuat = (int)cmd6.ExecuteScalar();
            conn.Close();
            lb_slNV.Text = tongNV.ToString();
            lb_slKH.Text = tongKH.ToString();
            lb_slNCC.Text = tongNCC.ToString();
            lb_Doanhso.Text = tongDoanhSo.ToString();
            lb_Tienchi.Text = tongTienChi.ToString();
            lb_slTon.Text = tongSP_TonKho.ToString();
            lb_slXuat.Text = tongSP_Xuat.ToString();
        }

        private void load_combox_Ngay_Thang_Nam()
        {
            cbo_Ngay.Items.Add("NULL");
            cbo_Thang.Items.Add("NULL");
            cbo_Nam.Items.Add("NULL");
            for (int i = 1; i <= 31; i++)
            {
                cbo_Ngay.Items.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                cbo_Thang.Items.Add(i);
            }
            for (int i = 2021; i <= 2025; i++)
            {
                cbo_Nam.Items.Add(i);
            }
            cbo_Ngay.SelectedIndex = cbo_Thang.SelectedIndex = cbo_Nam.SelectedIndex = 0;
        }
        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            if(cbo_Ngay.SelectedIndex == 0 && cbo_Thang.SelectedIndex == 0 && cbo_Nam.SelectedIndex == 0)
            {
                Load_ThongKe();
            }
            if (cbo_Ngay.SelectedIndex != 0 && cbo_Thang.SelectedIndex != 0 && cbo_Nam.SelectedIndex != 0)
            {
                TinhThongKeTheoNgay();
            }
            if (cbo_Ngay.SelectedIndex == 0 && cbo_Thang.SelectedIndex != 0)
            {
                TinhThongKeTheoThang();
            }
            if (cbo_Ngay.SelectedIndex == 0 && cbo_Thang.SelectedIndex == 0 && cbo_Nam.SelectedIndex != 0)
            {
                TinhThongKeTheoNam();
            }
        }
        private void TinhThongKeTheoNgay()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(TONGBILL_XUAT) FROM HD_XUAT_BAOHANH WHERE DAY(NGAYXUAT) = @Ngay AND MONTH(NGAYXUAT) = @Thang AND YEAR(NGAYXUAT) = @Nam", conn);
            SqlCommand cmd1 = new SqlCommand("SELECT SUM(TONGBILL_NHAP) FROM HD_NHAP WHERE DAY(NGAYNHAP) = @Ngay AND MONTH(NGAYNHAP) = @Thang AND YEAR(NGAYNHAP) = @Nam", conn);
            cmd.Parameters.AddWithValue("@Ngay", cbo_Ngay.SelectedItem);
            cmd.Parameters.AddWithValue("@Thang", cbo_Thang.SelectedItem);
            cmd.Parameters.AddWithValue("@Nam", cbo_Nam.SelectedItem);
            cmd1.Parameters.AddWithValue("@Ngay", cbo_Ngay.SelectedItem);
            cmd1.Parameters.AddWithValue("@Thang", cbo_Thang.SelectedItem);
            cmd1.Parameters.AddWithValue("@Nam", cbo_Nam.SelectedItem);
            conn.Open();
            decimal tongDoanhSo = cmd.ExecuteScalar() == DBNull.Value ? 0 : (decimal)cmd.ExecuteScalar();
            decimal tongTienChi = cmd1.ExecuteScalar() == DBNull.Value ? 0 : (decimal)cmd1.ExecuteScalar();
            conn.Close();
            if (tongDoanhSo == 0) lb_Doanhso.Text = "0";
            else lb_Doanhso.Text = tongDoanhSo.ToString();
            if (tongTienChi == 0) lb_Tienchi.Text = "0";
            else lb_Tienchi.Text = tongTienChi.ToString();
        }
        private void TinhThongKeTheoThang()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(TONGBILL_XUAT) FROM HD_XUAT_BAOHANH WHERE MONTH(NGAYXUAT) = @Thang AND YEAR(NGAYXUAT) = @Nam", conn);
            SqlCommand cmd1 = new SqlCommand("SELECT SUM(TONGBILL_NHAP) FROM HD_NHAP WHERE MONTH(NGAYNHAP) = @Thang AND YEAR(NGAYNHAP) = @Nam", conn);
            cmd.Parameters.AddWithValue("@Thang", cbo_Thang.SelectedItem);
            cmd.Parameters.AddWithValue("@Nam", cbo_Nam.SelectedItem);
            cmd1.Parameters.AddWithValue("@Thang", cbo_Thang.SelectedItem);
            cmd1.Parameters.AddWithValue("@Nam", cbo_Nam.SelectedItem);
            conn.Open();
            decimal tongDoanhSo = cmd.ExecuteScalar() == DBNull.Value ? 0 : (decimal)cmd.ExecuteScalar();
            decimal tongTienChi = cmd1.ExecuteScalar() == DBNull.Value ? 0 : (decimal)cmd1.ExecuteScalar();
            conn.Close();
            if (tongDoanhSo == 0) lb_Doanhso.Text = "0";
            else lb_Doanhso.Text = tongDoanhSo.ToString();
            if (tongTienChi == 0) lb_Tienchi.Text = "0";
            else lb_Tienchi.Text = tongTienChi.ToString();
        }
        private void TinhThongKeTheoNam()
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM(TONGBILL_XUAT) FROM HD_XUAT_BAOHANH WHERE YEAR(NGAYXUAT) = @Nam", conn);
            SqlCommand cmd1 = new SqlCommand("SELECT SUM(TONGBILL_NHAP) FROM HD_NHAP WHERE YEAR(NGAYNHAP) = @Nam", conn);
            cmd.Parameters.AddWithValue("@Nam", cbo_Nam.SelectedItem);
            cmd1.Parameters.AddWithValue("@Nam", cbo_Nam.SelectedItem);
            conn.Open();
            decimal tongDoanhSo = cmd.ExecuteScalar() == DBNull.Value ? 0 : (decimal)cmd.ExecuteScalar();
            decimal tongTienChi = cmd1.ExecuteScalar() == DBNull.Value ? 0 : (decimal)cmd1.ExecuteScalar();
            conn.Close();
            if (tongDoanhSo == 0) lb_Doanhso.Text = "0";
            else lb_Doanhso.Text = tongDoanhSo.ToString();
            if (tongTienChi == 0) lb_Tienchi.Text = "0";
            else lb_Tienchi.Text = tongTienChi.ToString();
        }
    }
}
