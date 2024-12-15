using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Configuration;
using System.Data.SqlClient;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Admin_QuanLyHD : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        public Admin_QuanLyHD()
        {
            InitializeComponent();
        }
            //CREATE TABLE HD_XUAT_BAOHANH(
            //MAHD_XUAT CHAR(8) PRIMARY KEY, --Mã hóa đơn xuất(độ dài tối đa 8 ký tự)
            //SDT_KH CHAR(10) NOT NULL, --Số điện thoại khách hàng(khóa ngoại từ bảng KHACHHANG)
            //MA_NV CHAR(6) NOT NULL, --Mã nhân viên(khóa ngoại từ bảng NHANVIEN)
            //TONGBILL_XUAT DECIMAL(18, 2), --Tổng số tiền hóa đơn xuất
            //PHUONGTHUCGIAODICH NVARCHAR(50), --Phương thức giao dịch
            //NGAYXUAT DATE NOT NULL, --Ngày xuất hàng
            //FOREIGN KEY(SDT_KH) REFERENCES KHACHHANG(SDT_KH),
            //FOREIGN KEY(MA_NV) REFERENCES NHANVIEN(MA_NV)
            //);
            // CREATE TABLE HD_NHAP(
            //MAHD_NHAP CHAR(8) PRIMARY KEY, --Mã hóa đơn nhập(độ dài tối đa 8 ký tự)
            //MA_NCC CHAR(6) NOT NULL, --Mã nhà cung cấp(khóa ngoại từ bảng NHACUNGCAP)
            //MA_NV CHAR(6) NOT NULL, --Mã nhân viên(khóa ngoại từ bảng NHANVIEN)
            //TONGBILL_NHAP DECIMAL(18, 2), --Tổng số tiền hóa đơn nhập
            //NGAYNHAP DATE NOT NULL, --Ngày nhập hàng
            //FOREIGN KEY(MA_NCC) REFERENCES NHACUNGCAP(MA_NCC),
            //FOREIGN KEY(MA_NV) REFERENCES NHANVIEN(MA_NV)
            //);

            // thêm cột ở cuối phân biệt hóa đơn nhập và hóa đơn xuất

            // load danh sách hóa đơn lên datagridview

        private void Load_HD_NHAP()
        {
            string query = "SELECT * FROM HD_NHAP";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
        }

        private void Load_HD_XUAT()
        {
            string query = "SELECT * FROM HD_XUAT_BAOHANH";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
        }

        private void Admin_QuanLyHD_Load(object sender, EventArgs e)
        {
            Load_HD_XUAT();
            radio_HD_Xuat.Checked = true;
        }

        private void radio_HD_Nhap_CheckedChanged(object sender, EventArgs e)
        {
            Load_HD_NHAP();
        }

        private void radio_HD_Xuat_CheckedChanged(object sender, EventArgs e)
        {
            Load_HD_XUAT();
        }

        private void LocHD_Xuat()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string column = "";
            string additionalCondition = ""; // Điều kiện bổ sung cho lọc nhà cung cấp
            SqlCommand cmd = new SqlCommand();

            // Kiểm tra nếu ComboBox TNCC có giá trị được chọn
            if (cb_TNCC.SelectedItem != null && !string.IsNullOrEmpty(txt_ThongTin.Text))
            {
                switch (cb_TNCC.SelectedItem.ToString())
                {
                    case "Mã nhân viên":
                        column = "MA_NV";
                        break;
                    case "Mã hóa đơn":
                        column = "MAHD_XUAT";
                        break;
                    case "Phương thức giao dịch":
                        column = "PHUONGTHUCGIAODICH";
                        break;
                    default:
                        return;
                }
                additionalCondition = $" AND {column} LIKE @ThongTin"; // Thêm điều kiện lọc
                cmd.Parameters.AddWithValue("@ThongTin", "%" + txt_ThongTin.Text.Trim() + "%");
            }

            // Lọc theo thời gian bắt đầu và kết thúc
            string query = $"SELECT * FROM HD_XUAT_BAOHANH WHERE NGAYXUAT BETWEEN @start AND @end {additionalCondition}";
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@start", dateTimePicker_BatDau.Value);
            cmd.Parameters.AddWithValue("@end", dateTimePicker_KetThuc.Value);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;

            conn.Close();
        }


        private void LocHD_Nhap()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string column = "";
            string additionalCondition = ""; // Điều kiện bổ sung cho lọc nhà cung cấp
            SqlCommand cmd = new SqlCommand();

            // Kiểm tra nếu ComboBox TNCC có giá trị được chọn
            if (cb_TNCC.SelectedItem != null && !string.IsNullOrEmpty(txt_ThongTin.Text))
            {
                switch (cb_TNCC.SelectedItem.ToString())
                {
                    case "Mã nhân viên":
                        column = "MA_NV";
                        break;
                    case "Mã hóa đơn":
                        column = "MAHD_NHAP";
                        break;
                    default:
                        return;
                }
                additionalCondition = $" AND {column} LIKE @ThongTin"; // Thêm điều kiện lọc
                cmd.Parameters.AddWithValue("@ThongTin", "%" + txt_ThongTin.Text.Trim() + "%");
            }
            // lọc theo time pickker bắt đầu và kết thúc (dd/mm/yyyy)
            string query = $"SELECT * FROM HD_NHAP WHERE NGAYNHAP BETWEEN @start AND @end {additionalCondition}  ";
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@start", dateTimePicker_BatDau.Value);
            cmd.Parameters.AddWithValue("@end", dateTimePicker_KetThuc.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
        }

        private bool check_date()
        {
            if (dateTimePicker_BatDau.Value > dateTimePicker_KetThuc.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            if (!check_date())
            {
                return;
            }
            if (radio_HD_Xuat.Checked)
            {
                LocHD_Xuat();
            }
            if(radio_HD_Nhap.Checked)
            {
                LocHD_Nhap();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // hiển thị thông tin chi tiết hóa đơn
            int i = dataGridView.CurrentRow.Index;
            if(radio_HD_Xuat.Checked)
            {
                txt_HoaDon.Text = dataGridView.Rows[i].Cells[0].Value.ToString();
                txt_MaNhanVien.Text = dataGridView.Rows[i].Cells[2].Value.ToString();
                txt_TongBill.Text = dataGridView.Rows[i].Cells[3].Value.ToString();
                dt_NgayHoaDon.Value = Convert.ToDateTime(dataGridView.Rows[i].Cells[5].Value.ToString());
            }
            if (radio_HD_Nhap.Checked)
            {
                txt_HoaDon.Text = dataGridView.Rows[i].Cells[0].Value.ToString();
                txt_MaNhanVien.Text = dataGridView.Rows[i].Cells[2].Value.ToString();
                txt_TongBill.Text = dataGridView.Rows[i].Cells[3].Value.ToString();
                dt_NgayHoaDon.Value = Convert.ToDateTime(dataGridView.Rows[i].Cells[4].Value.ToString());
            }
        }

        private bool check_HD()
        {
            if (txt_HoaDon.Text == "" || txt_MaNhanVien.Text == "" || txt_TongBill.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txt_TongBill.Text, out decimal bill))
            {
                MessageBox.Show("Tổng bill phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (!check_HD())
            {
                return;
            }
            if (radio_HD_Nhap.Checked) {
                string query = "DELETE FROM HD_NHAP WHERE MAHD_NHAP = @MAHD_NHAP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAHD_NHAP", txt_HoaDon.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Load_HD_NHAP();
            }
            if (radio_HD_Xuat.Checked)
            {
                string query = "DELETE FROM HD_XUAT_BAOHANH WHERE MAHD_XUAT = @MAHD_XUAT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAHD_XUAT", txt_HoaDon.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Load_HD_XUAT();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            // sửa thông tin hóa đơn
            if (!check_HD())
            {
                return;
            }
            if (radio_HD_Nhap.Checked)
            {
                string query = "UPDATE HD_NHAP SET MA_NV = @MA_NV, TONGBILL_NHAP = @TONGBILL_NHAP, NGAYNHAP = @NGAYNHAP WHERE MAHD_NHAP = @MAHD_NHAP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_NV", txt_MaNhanVien.Text);
                cmd.Parameters.AddWithValue("@TONGBILL_NHAP", txt_TongBill.Text);
                cmd.Parameters.AddWithValue("@NGAYNHAP", dt_NgayHoaDon.Value);
                cmd.Parameters.AddWithValue("@MAHD_NHAP", txt_HoaDon.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Load_HD_NHAP();
            }
            if (radio_HD_Xuat.Checked)
            {
                string query = "UPDATE HD_XUAT_BAOHANH SET MA_NV = @MA_NV, TONGBILL_XUAT = @TONGBILL_XUAT, NGAYXUAT = @NGAYXUAT WHERE MAHD_XUAT = @MAHD_XUAT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_NV", txt_MaNhanVien.Text);
                cmd.Parameters.AddWithValue("@TONGBILL_XUAT", txt_TongBill.Text);
                cmd.Parameters.AddWithValue("@NGAYXUAT", dt_NgayHoaDon.Value);
                cmd.Parameters.AddWithValue("@MAHD_XUAT", txt_HoaDon.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Load_HD_XUAT();
            }
        }

        private void Xuat_Excel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview";
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if(dataGridView.Rows[i].Cells[j].Value != null)
                        worksheet.Cells[i + 2, j + 1] = "'" + dataGridView.Rows[i].Cells[j].Value.ToString();
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }

        private void CLEAR()
        {
            txt_HoaDon.Text = "";
            txt_MaNhanVien.Text = "";
            txt_TongBill.Text = "";
            dt_NgayHoaDon.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLEAR();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
