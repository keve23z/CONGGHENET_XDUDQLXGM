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
    public partial class User_ThongTinCaNhan : UserControl
    {
        private NhanVien CurrentNhanVien;
        private List<HoaDon> hoaDonXuats = new List<HoaDon>();
        private List<HoaDon> hoaDonNhaps = new List<HoaDon>();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        public User_ThongTinCaNhan(NhanVien currentNhanVien)
        {
            InitializeComponent();
            CurrentNhanVien = currentNhanVien;
            
        }
        public void LoadGioiTinh()
        {
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
            cb_GioiTinh.Items.Add("Khác");
            cb_GioiTinh.SelectedIndex = 0;
        }
        
        public void LoadHDX()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT MAHD_XUAT,NGAYXUAT " +
                                                "FROM HD_XUAT_BAOHANH " +
                                                "WHERE MA_NV = '" + CurrentNhanVien.Login + "'", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaHD = readerHD["MAHD_XUAT"].ToString();
                hoaDon.Ngay = Convert.ToDateTime(readerHD["NGAYXUAT"]).ToString("dd-MM-yyyy");
                hoaDonXuats.Add(hoaDon);
            }
            conn.Close();
        }
        public void LoadHDN()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT MAHD_NHAP,NGAYNHAP " +
                                                "FROM HD_NHAP " +
                                                "WHERE MA_NV = '" + CurrentNhanVien.Login + "'", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaHD = readerHD["MAHD_NHAP"].ToString();
                hoaDon.Ngay = Convert.ToDateTime(readerHD["NGAYNHAP"]).ToString("dd-MM-yyyy");
                hoaDonNhaps.Add(hoaDon);
            }
            conn.Close();
        }
        public void LoadHoaDonXuat()
        {
            LoadHDX();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = hoaDonXuats;
            dataGridView1.Columns["MaHD"].HeaderText = "Mã Hoá Đơn";
            dataGridView1.Columns["Ngay"].HeaderText = "Ngày Xuất";
            dataGridView1.Columns["SDT_KH"].Visible = false;
            //dataGridView1.Columns["MoTa"].Visible = false;
            dataGridView1.Columns["MA_NCC"].Visible = false;
            dataGridView1.Columns["Ma_NV"].Visible = false;
            dataGridView1.Columns["TongBill"].Visible = false;
            dataGridView1.Columns["PhuongThucGiaoDich"].Visible = false;
        }
        public void LoadHoaDonNhap()
        {
            LoadHDN();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = hoaDonNhaps;
            dataGridView2.Columns["MaHD"].HeaderText = "Mã Hoá Đơn";
            dataGridView2.Columns["Ngay"].HeaderText = "Ngày Nhập";
            dataGridView2.Columns["SDT_KH"].Visible = false;
            //dataGridView2.Columns["MoTa"].Visible = false;
            dataGridView2.Columns["MA_NCC"].Visible = false;
            dataGridView2.Columns["Ma_NV"].Visible = false;
            dataGridView2.Columns["TongBill"].Visible = false;
            dataGridView2.Columns["PhuongThucGiaoDich"].Visible = false;
            dataGridView2.Refresh();
        }

        private void User_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadGioiTinh();
            LoadHoaDonXuat();
            LoadHoaDonNhap();
            txt_MaNV.Text = CurrentNhanVien.MaNV;
            txt_Pass.Text = CurrentNhanVien.Pass;
            txt_ChucVu.Text= CurrentNhanVien.ChucVu;
            txt_SDT.Text = CurrentNhanVien.SDT_NV;
            txt_TenNV.Text= CurrentNhanVien.TenNV;
            cb_GioiTinh.Text = CurrentNhanVien.GioiTinh;
            dt_NgaySinh.Value=DateTime.Parse(CurrentNhanVien.NgaySinh);
            txt_DiaChi.Text = CurrentNhanVien.DiaChi;
        }

        private void txt_Pass_TextChanged(object sender, EventArgs e)
        {
            txt_Pass.PasswordChar = '●';
        }
        
        private void chb_Show_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Show.Checked) txt_Pass.PasswordChar = '\0';
            else txt_Pass.PasswordChar = '●';
        }
        // các hàm check dl 
        private bool checkSoDienThoai(string sdt)
        {
            // số đầu tiên là số 0
            if (sdt[0] != '0')
            {
                return false;
            }
            if (sdt.Length != 10)
            {
                return false;
            }
            return true;
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            if (btn_ChinhSua.Text == "Chỉnh sửa")
            {

                btn_ChinhSua.Text = "Lưu";
                btn_ChinhSua.BackColor = Color.Red;
                btn_ChinhSua.ForeColor = Color.White;
                txt_Pass.Enabled = true;
                txt_SDT.Enabled = true;
                cb_GioiTinh.Enabled = true;
                txt_DiaChi.Enabled = true;
            }
            else
            {
                DialogResult r;
                r = MessageBox.Show("Bạn có muốn LƯU THÔNG TIN VỪA CHỈNH SỬA?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    return;
                }
                if (txt_Pass.Text == "" || cb_GioiTinh.Text == "" || txt_SDT.Text == "" || txt_DiaChi.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                if (checkSoDienThoai(txt_SDT.Text) == false)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ");
                    return;
                }
                conn.Open();
                // cập nhật thông tin nhân viên
                SqlCommand cmd = new SqlCommand("UPDATE NHANVIEN SET GIOITINH = N'" + cb_GioiTinh.Text + "', SDT_NV = '" + txt_SDT.Text + "', DIACHI_NV = N'" + txt_DiaChi.Text + "' WHERE MA_NV = '" + CurrentNhanVien.MaNV + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                // cập nhật Pass nhân viên
                SqlCommand cmd1 = new SqlCommand("UPDATE TAIKHOAN_NV SET PASS = '" + txt_Pass.Text + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Sửa thông tin nhân viên thành công");
                btn_ChinhSua.Text = "Chỉnh sửa";
                btn_ChinhSua.BackColor = Color.AliceBlue;
                btn_ChinhSua.ForeColor = Color.FromArgb(0, 0, 255);
                txt_Pass.Enabled = false;
                txt_SDT.Enabled = false;
                cb_GioiTinh.Enabled = false;
                txt_DiaChi.Enabled = false;
            }
        }
    }
}
