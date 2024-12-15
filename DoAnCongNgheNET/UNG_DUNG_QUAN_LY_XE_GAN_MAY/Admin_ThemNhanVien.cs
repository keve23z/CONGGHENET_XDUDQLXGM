using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;
using System.Windows.Input;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Admin_ThemNhanVien : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        public Admin_ThemNhanVien()
        {
            InitializeComponent();
        }
        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
            cb_GioiTinh.Items.Add("Khác");
            cb_GioiTinh.SelectedIndex = 0;
            cob_ChucVu.Items.Add("Quản lý");
            cob_ChucVu.Items.Add("Nhân viên bán hàng");
            cob_ChucVu.Items.Add("Nhân viên kỹ thuật");
            cob_ChucVu.SelectedIndex = 0;
            txt_SDT.KeyPress += new KeyPressEventHandler(txt_SDT_KeyPress);
            txt_TTK.Enabled = txt_MK.Enabled = false;
            Load_Treeview();

        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool checkSoDienThoai(string sdt)
        {
            if (sdt[0] != '0')
            {
                return false;
            }
            if (sdt.Length != 10 && sdt.Length != 11)
            {
                return false;
            }
            return true;
        }


        private bool checkNgaySinh(string ngaySinh)
        {
            // lơn hơn 18 tuổi
            DateTime now = DateTime.Now;
            DateTime date = DateTime.Parse(ngaySinh);
            if (now.Year - date.Year < 18)
            {
                return false;
            }
            return true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (txt_MaNV.Text == "" || txt_TenNV.Text == "" || txt_SDT.Text == "" || txt_DiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (checkSoDienThoai(txt_SDT.Text) == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNV = txt_MaNV.Text;
            nhanVien.TenNV = txt_TenNV.Text;
            nhanVien.GioiTinh = cb_GioiTinh.Text;
            nhanVien.ChucVu = cob_ChucVu.Text;
            nhanVien.SDT_NV = txt_SDT.Text;
            nhanVien.NgaySinh = dt_NgaySinh.Value.ToString("yyyy-MM-dd");
            nhanVien.DiaChi = txt_DiaChi.Text;
            TaiKhoanNhanVien TK = new TaiKhoanNhanVien();
            TK.TenDangNhap = nhanVien.MaNV;
            TK.MatKhau = nhanVien.MaNV;
            if (!checkNgaySinh(nhanVien.NgaySinh))
            {
                MessageBox.Show("Nhân viên phải lớn hơn 18 tuổi");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN WHERE MA_NV = '" + nhanVien.MaNV + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
                conn.Close();
                return;
            }
            conn.Close();
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO NHANVIEN VALUES('" + nhanVien.MaNV + "', N'" + nhanVien.TenNV + "', N'" + nhanVien.GioiTinh + "', N'" + nhanVien.ChucVu + "', '" + nhanVien.SDT_NV + "', '" + nhanVien.NgaySinh + "', N'" + nhanVien.DiaChi + "')", conn);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO TAIKHOAN_NV (MA_NV, PASS) VALUES('"+ TK.TenDangNhap +"', '" + TK.MatKhau + "')", conn);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Thêm nhân viên thành công");
            Load_Treeview();
            XoaThongTin_txt();
        }

        private void btn_Chitiet_Click(object sender, EventArgs e)
        {
            string MaNV = txt_MaNV.Text;
            if (MaNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN WHERE MA_NV = '" + MaNV + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_TenNV.Text = dr["TENNV"].ToString();
                cb_GioiTinh.Text = dr["GIOITINH"].ToString();
                cob_ChucVu.Text = dr["CHUCVU"].ToString();
                txt_SDT.Text = dr["SDT_NV"].ToString();
                dt_NgaySinh.Value = DateTime.Parse(dr["NGAYSINH"].ToString());
                txt_DiaChi.Text = dr["DIACHI_NV"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên");
                dr.Close();
                conn.Close();
                return;
            }
            dr.Close();

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM TAIKHOAN_NV WHERE MA_NV = '" + MaNV + "'", conn);
            SqlDataReader dr1 = cmd2.ExecuteReader();
            if (dr1.Read())
            {
                if (dr1["IS_ACTIVE"].ToString() == "1")
                {
                    txt_TTK.Text = dr1["MA_NV"].ToString();
                    txt_MK.Text = dr1["PASS"].ToString();
                }
                else
                {
                    MessageBox.Show("Tài khoản đã bị khóa");
                    txt_TTK.Text = txt_MK.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản");
            }
            dr1.Close();
            conn.Close();
        }

        private void Load_Treeview()
        {
            // load lên tree view nhân viên theo chức vụ
            string[] ChucVu = { "Quản lý", "Nhân viên bán hàng", "Nhân viên kỹ thuật" };
            trv_NV.Nodes.Clear();
            for (int i = 0; i < ChucVu.Length; i++)
            {
                TreeNode node = new TreeNode(ChucVu[i]);
                trv_NV.Nodes.Add(node);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN WHERE CHUCVU = N'" + ChucVu[i] + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TreeNode node1 = new TreeNode(dr["MA_NV"].ToString());
                    node1.Nodes.Add("Tên nhân viên: " + dr["TENNV"].ToString());
                    node1.Nodes.Add("Giới tính: " + dr["GIOITINH"].ToString());
                    node1.Nodes.Add("Số điện thoại: " + dr["SDT_NV"].ToString());
                    node1.Nodes.Add("Ngày sinh: " + Convert.ToDateTime(dr["NGAYSINH"]).ToString("dd-MM-yyyy"));
                    node1.Nodes.Add("Địa chỉ: " + dr["DIACHI_NV"].ToString());
                    node.Nodes.Add(node1);
                }
                dr.Close();
                conn.Close();
            }
        }

        private void txt_MaNV_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            // sửa thông tin nhân viên
            string MaNV = txt_MaNV.Text;
            if (MaNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE NHANVIEN SET TENNV = N'" + txt_TenNV.Text + "', GIOITINH = N'" + cb_GioiTinh.Text + "', CHUCVU = N'" + cob_ChucVu.Text + "', SDT_NV = '" + txt_SDT.Text + "', NGAYSINH = '" + dt_NgaySinh.Value.ToString("yyyy-MM-dd") + "', DIACHI_NV = N'" + txt_DiaChi.Text + "' WHERE MA_NV = '" + MaNV + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sửa thông tin nhân viên thành công");
            Load_Treeview();
            XoaThongTin_txt();
        }

        private void trv_NV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string MaNV = trv_NV.SelectedNode.Text;
            if (MaNV == "Quản lý" || MaNV == "Nhân viên bán hàng" || MaNV == "Nhân viên kỹ thuật")
            {
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN WHERE MA_NV = '" + MaNV + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_MaNV.Text = dr["MA_NV"].ToString();
                txt_TenNV.Text = dr["TENNV"].ToString();
                cb_GioiTinh.Text = dr["GIOITINH"].ToString();
                cob_ChucVu.Text = dr["CHUCVU"].ToString();
                txt_SDT.Text = dr["SDT_NV"].ToString();
                dt_NgaySinh.Value = DateTime.Parse(dr["NGAYSINH"].ToString());
                txt_DiaChi.Text = dr["DIACHI_NV"].ToString();
            }
            dr.Close();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM TAIKHOAN_NV WHERE MA_NV = '" + MaNV + "'", conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                if(dr1["IS_ACTIVE"].ToString() == "True")
                {
                    txt_TTK.Text = dr1["MA_NV"].ToString();
                    txt_MK.Text = dr1["PASS"].ToString();
                }
                else
                {
                    MessageBox.Show("Tài khoản đã bị khóa");
                    txt_TTK.Text = txt_MK.Text = "";
                }
            }
            dr1.Close();
            conn.Close();

        }

        private void btn_VoHieu_Click(object sender, EventArgs e)
        {
            string MaNV = txt_MaNV.Text;
            if (MaNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TAIKHOAN_NV WHERE MA_NV = @MaNV", conn);
            cmd.Parameters.AddWithValue("@MaNV", MaNV);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["IS_ACTIVE"].ToString() == "True")
                {
                    dr.Close();
                    SqlCommand cmd1 = new SqlCommand("UPDATE TAIKHOAN_NV SET IS_ACTIVE = 0 WHERE MA_NV = @MaNV", conn);
                    cmd1.Parameters.AddWithValue("@MaNV", MaNV);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Vô hiệu hóa tài khoản thành công");
                }
                else
                {
                    dr.Close();
                    SqlCommand cmd1 = new SqlCommand("UPDATE TAIKHOAN_NV SET IS_ACTIVE = 1 WHERE MA_NV = @MaNV", conn);
                    cmd1.Parameters.AddWithValue("@MaNV", MaNV);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Mở tài khoản thành công");
                }
            }
            else
            {
                dr.Close();
                MessageBox.Show("Không tìm thấy tài khoản");
            }
            conn.Close();
            Load_Treeview();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // xóa nhân viên
            string MaNV = txt_MaNV.Text;
            if (MaNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM NHANVIEN WHERE MA_NV = '" + MaNV + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Xóa nhân viên thành công");
            Load_Treeview();
            XoaThongTin_txt();
        }

        private void XoaThongTin_txt()
        {
            txt_MaNV.Text = txt_DiaChi.Text = txt_SDT.Text = txt_TenNV.Text = "";
            cb_GioiTinh.SelectedIndex = cob_ChucVu.SelectedIndex = 0;
            txt_TTK.Text = txt_MK.Text = "";
        }

        private void btn_XuatEx_Click(object sender, EventArgs e)
        {
            // xuất excel
            List<NhanVien> list = new List<NhanVien>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.MaNV = dr["MA_NV"].ToString();
                nhanVien.TenNV = dr["TENNV"].ToString();
                nhanVien.GioiTinh = dr["GIOITINH"].ToString();
                nhanVien.ChucVu = dr["CHUCVU"].ToString();
                nhanVien.SDT_NV = "'" + dr["SDT_NV"].ToString();
                nhanVien.NgaySinh = Convert.ToDateTime(dr["NGAYSINH"]).ToString("dd/MM/yyyy");
                nhanVien.DiaChi = dr["DIACHI_NV"].ToString();
                list.Add(nhanVien);
            }
            dr.Close();
            conn.Close();
            // xuất excel
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            app.Visible = true;
            worksheet.Cells[1, 1] = "Mã nhân viên";
            worksheet.Cells[1, 2] = "Tên nhân viên";
            worksheet.Cells[1, 3] = "Giới tính";
            worksheet.Cells[1, 4] = "Chức vụ";
            worksheet.Cells[1, 5] = "Số điện thoại";
            worksheet.Cells[1, 6] = "Ngày sinh";
            worksheet.Cells[1, 7] = "Địa chỉ";
            for (int i = 0; i < list.Count; i++)
            {
                worksheet.Cells[i + 2, 1] = list[i].MaNV;
                worksheet.Cells[i + 2, 2] = list[i].TenNV;
                worksheet.Cells[i + 2, 3] = list[i].GioiTinh;
                worksheet.Cells[i + 2, 4] = list[i].ChucVu;
                worksheet.Cells[i + 2, 5] = list[i].SDT_NV;
                worksheet.Cells[i + 2, 6] = list[i].NgaySinh;
                worksheet.Cells[i + 2, 7] = list[i].DiaChi;
            }

        }

        private void btn_XuatDS_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                conn.Open();

                // Truy vấn lấy tất cả dữ liệu khách hàng
                string query = "SELECT * FROM NHANVIEN";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Khởi tạo danh sách để chứa dữ liệu khách hàng
                List<NhanVien> listNhanVien = new List<NhanVien>();

                // Đọc dữ liệu và thêm vào danh sách
                while (reader.Read())
                {
                    listNhanVien.Add(new NhanVien
                    {
                        MaNV = reader["MA_NV"].ToString(),
                        TenNV = reader["TENNV"].ToString(),
                        ChucVu = reader["CHUCVU"].ToString(),
                        SDT_NV = reader["SDT_NV"].ToString(),
                        NgaySinh = reader["NGAYSINH"].ToString(),
                        DiaChi = reader["DIACHI_NV"].ToString(),
                        GioiTinh = reader["GIOITINH"].ToString()
                    });
                }

                // Đóng reader
                reader.Close();

                // Gọi phương thức để hiển thị báo cáo
                Report_NhanVien reportForm = new Report_NhanVien(listNhanVien);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối
                conn.Close();
            }
        }

        private void btn_XuatNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Mở kết nối
                conn.Open();

                // Truy vấn tìm kiếm dựa trên thông tin từ TextBox
                string query = "SELECT * FROM NHANVIEN WHERE 1=1";

                if (!string.IsNullOrEmpty(txt_MaNV.Text))
                    query += " AND MA_NV LIKE @MANV";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Thêm các tham số vào câu lệnh
                if (!string.IsNullOrEmpty(txt_MaNV.Text)) cmd.Parameters.AddWithValue("@MANV", "%" + txt_MaNV.Text.Trim() + "%");
               
                SqlDataReader reader = cmd.ExecuteReader();

                // Khởi tạo danh sách để chứa dữ liệu khách hàng
                List<NhanVien> listNhanVien = new List<NhanVien>();

                // Đọc dữ liệu và thêm vào danh sách
                while (reader.Read())
                {
                    listNhanVien.Add(new NhanVien
                    {
                        MaNV = reader["MA_NV"].ToString(),
                        TenNV = reader["TENNV"].ToString(),
                        ChucVu = reader["CHUCVU"].ToString(),
                        SDT_NV = reader["SDT_NV"].ToString(),
                        NgaySinh = reader["NGAYSINH"].ToString(),
                        DiaChi = reader["DIACHI_NV"].ToString(),
                        GioiTinh = reader["GIOITINH"].ToString()
                    });
                }

                // Đóng reader
                reader.Close();

                // Gọi phương thức để hiển thị báo cáo
                Report_NhanVien reportForm = new Report_NhanVien(listNhanVien);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối
                conn.Close();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ThongTin.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cb_KieuTimKiem.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn kiểu tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            trv_NV.Nodes.Clear();

            try
            {
                // Mở kết nối
                conn.Open();

                // Xác định cột cần tìm kiếm dựa vào giá trị ComboBox
                string column = string.Empty;
                switch (cb_KieuTimKiem.SelectedItem.ToString())
                {
                    case "Mã nhân viên":
                        column = "MA_NV";
                        break;
                    case "Tên nhân viên":
                        column = "TENNV";
                        break;
                    case "Số điện thoại":
                        column = "SDT_NV";
                        break;
                    default:
                        MessageBox.Show("Vui lòng chọn kiểu tìm kiếm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Truy vấn tìm kiếm
                string query = $"SELECT * FROM NHANVIEN WHERE {column} LIKE @SearchValue";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", "%" + txt_ThongTin.Text.Trim() + "%");
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TreeNode node = new TreeNode("Mã NV: " + dr["MA_NV"].ToString());
                            node.Nodes.Add("Tên: " + dr["TENNV"].ToString());
                            node.Nodes.Add("Giới tính: " + dr["GIOITINH"].ToString());
                            node.Nodes.Add("Chức vụ: " + dr["CHUCVU"].ToString());
                            node.Nodes.Add("SĐT: " + dr["SDT_NV"].ToString());
                            node.Nodes.Add("Ngày sinh: " + Convert.ToDateTime(dr["NGAYSINH"]).ToString("dd-MM-yyyy"));
                            node.Nodes.Add("Địa chỉ: " + dr["DIACHI_NV"].ToString());
                            trv_NV.Nodes.Add(node);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối
                conn.Close();
            }
        }

    }
}
