using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Admin_QuanLySP : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        //CREATE TABLE LOAISANPHAM(
        //MA_LOAI CHAR(7) PRIMARY KEY,  -- Mã loại sản phẩm(độ dài tối đa 10 ký tự)
        //TENLOAI NVARCHAR(100) NOT NULL     -- Tên loại sản phẩm(độ dài tối đa 100 ký tự)
        //);
        //    CREATE TABLE SANPHAM(
        //MA_SP CHAR(6) PRIMARY KEY,  -- Mã sản phẩm(độ dài tối đa 6 ký tự)
        //TEN_SP NVARCHAR(100) NOT NULL, -- Tên sản phẩm
        //MOTA_SP NVARCHAR(255),  -- Mô tả sản phẩm
        //SOLUONG_SP INT NOT NULL,  -- Số lượng sản phẩm
        //GIA_BAN DECIMAL(18,2) NOT NULL,  -- Giá bán
        //GIA_NHAP DECIMAL(18,2) NOT NULL,  -- Giá nhập
        //TGBAOHANH INT NOT NULL,  -- Thời gian bảo hành(tháng)
        //ANH_SP NVARCHAR(200),
        //MA_LOAI CHAR(7) NOT NULL,  -- Mã loại sản phẩm
        //);

        public Admin_QuanLySP()
        {
            InitializeComponent();
            Load_data();
            // load danh sách tên loại sản phẩm
            cob_Loai.Items.Clear();
            string query = "SELECT * FROM LOAISANPHAM";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cob_Loai.Items.Add(dr["TENLOAI"].ToString());
            }
        }

        private void btn_OpenPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadFileStream = new OpenFileDialog();
            uploadFileStream.Title = "Chọn ảnh sản phẩm";

            // Lấy đường dẫn thư mục hiện tại (bin\Debug hoặc bin\Release)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Di chuyển lên hai cấp để lấy thư mục dự án
            string projectRoot = Directory.GetParent(projectDirectory).Parent.Parent.FullName;

            // Đường dẫn tương đối tới thư mục "image_xe"
            string imageXeDir = Path.Combine(projectRoot, @"UNG_DUNG_QUAN_LY_XE_GAN_MAY\image_xe");

            // Kiểm tra và tạo thư mục "image_xe" nếu chưa tồn tại
            if (!Directory.Exists(imageXeDir))
            {
                Directory.CreateDirectory(imageXeDir);
            }

            // Gán đường dẫn "image_xe" làm thư mục mặc định cho dialog
            uploadFileStream.InitialDirectory = imageXeDir;
            uploadFileStream.Filter = "Image Files|*.png;*.jpg;*.jpeg";
            uploadFileStream.FilterIndex = 1;

            if (uploadFileStream.ShowDialog() == DialogResult.OK)
            {
                // Đường dẫn đầy đủ của file đích trong thư mục "image_xe"
                string destPath = Path.Combine(imageXeDir, uploadFileStream.SafeFileName);

                // Kiểm tra nếu file đã nằm trong thư mục "image_xe"
                if (!File.Exists(destPath) || !string.Equals(uploadFileStream.FileName, destPath, StringComparison.OrdinalIgnoreCase))
                {
                    // Sao chép file vào thư mục "image_xe"
                    File.Copy(uploadFileStream.FileName, destPath, true); // 'true' để ghi đè nếu file đã tồn tại
                }

                // Gán tên file (không bao gồm đường dẫn) vào txt_Anh
                txt_Anh.Text = uploadFileStream.SafeFileName;

                // Hiển thị hình ảnh trong PictureBox
                picb_SanPham.Image = Image.FromFile(destPath);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Load_data()
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.BackgroundColor = Color.White;
            // load thông tin sản phẩm lên datagridview gồm cả tên loại sản phẩm
            string query = "SELECT SP.MA_SP, SP.TEN_SP, SP.MOTA_SP, SP.SOLUONG_SP, SP.GIA_BAN, SP.GIA_NHAP, SP.TGBAOHANH, LSP.TENLOAI, SP.ANH_SP FROM SANPHAM SP JOIN LOAISANPHAM LSP ON SP.MA_LOAI = LSP.MA_LOAI";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            // ẩn cột hình ảnh
            dataGridView.Columns[8].Visible = false;
        }

        private void Admin_QuanLySP_Load(object sender, EventArgs e)
        {
            // load danh sách sảm phẩm lên datagridview
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dữ liệu từ datagridview đưa lên textbox
            int i;
            i = dataGridView.CurrentRow.Index;
            SanPham sp = new SanPham();
            sp.MA_SP = txt_MSP.Text = dataGridView.Rows[i].Cells[0].Value.ToString();
            sp.TEN_SP = txt_TenSP.Text = dataGridView.Rows[i].Cells[1].Value.ToString();
            cob_Loai.Text = dataGridView.Rows[i].Cells[7].Value.ToString();
            txt_TGBH.Text = dataGridView.Rows[i].Cells[6].Value.ToString();
            txt_SL.Text = dataGridView.Rows[i].Cells[3].Value.ToString();
            // bỏ số .00 ở cuối
            txt_MoTa.Text = dataGridView.Rows[i].Cells[2].Value.ToString();
            txt_GiaXuat.Text = dataGridView.Rows[i].Cells[4].Value.ToString().Split('.')[0];
            txt_GiaNhap.Text = dataGridView.Rows[i].Cells[5].Value.ToString().Split('.')[0];
            txt_Anh.Text = dataGridView.Rows[i].Cells[8].Value.ToString();
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(projectPath, "image_xe", dataGridView.Rows[i].Cells[8].Value.ToString());
            picb_SanPham.Image = Image.FromFile(imagePath);

        }

        // khi bấm esc thì clear các textbox
        private void Admin_QuanLySP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txt_MSP.Text = "";
                txt_TenSP.Text = "";
                cob_Loai.Text = "";
                txt_TGBH.Text = "";
                txt_GiaXuat.Text = "";
                txt_GiaNhap.Text = "";
                txt_Anh.Text = "";
                picb_SanPham.Image = null;
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            // thêm sản phẩm
            if (check_SP() == false)
            {
                return;
            }
            else
            {
                string query = "INSERT INTO SANPHAM VALUES(@MA_SP, @TEN_SP, @MOTA_SP, @SOLUONG_SP, @GIA_BAN, @GIA_NHAP, @TGBAOHANH, @ANH_SP, @MA_LOAI)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_SP", txt_MSP.Text);
                cmd.Parameters.AddWithValue("@TEN_SP", txt_TenSP.Text);
                cmd.Parameters.AddWithValue("@MOTA_SP", txt_MoTa.Text);
                cmd.Parameters.AddWithValue("@SOLUONG_SP", txt_SL.Text);
                cmd.Parameters.AddWithValue("@GIA_BAN", txt_GiaXuat.Text);
                cmd.Parameters.AddWithValue("@GIA_NHAP", txt_GiaNhap.Text);
                cmd.Parameters.AddWithValue("@TGBAOHANH", txt_TGBH.Text);
                cmd.Parameters.AddWithValue("@ANH_SP", txt_Anh.Text);
                string query2 = "SELECT MA_LOAI FROM LOAISANPHAM WHERE TENLOAI = @TENLOAI";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@TENLOAI", cob_Loai.Text);
                conn.Open();
                string ma_loai = cmd2.ExecuteScalar().ToString();
                cmd.Parameters.AddWithValue("@MA_LOAI", ma_loai);
                cmd.ExecuteNonQuery();
                conn.Close();
                Load_data();
                CLEAR();
            }
        }

        private bool check_SP()
        {
            if (txt_MSP.Text == "" || txt_TenSP.Text == "" || cob_Loai.Text == "" || txt_TGBH.Text == "" || txt_GiaXuat.Text == "" || txt_GiaNhap.Text == "" || txt_Anh.Text == "" || txt_SL.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // kiểm tra mã sản phẩm đã tồn tại chưa
            string query = "SELECT COUNT(*) FROM SANPHAM WHERE MA_SP = @MA_SP";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MA_SP", txt_MSP.Text);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            if (count > 0)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // kiểm tra mã loại sản phẩm có tồn tại không
            string query2 = "SELECT COUNT(*) FROM LOAISANPHAM WHERE TENLOAI = @TENLOAI";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@TENLOAI", cob_Loai.Text);
            conn.Open();
            int count2 = (int)cmd2.ExecuteScalar();
            conn.Close();
            if (count2 == 0)
            {
                MessageBox.Show("Loại sản phẩm không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // kiểm tra giá nhập và giá xuất
            if (decimal.TryParse(txt_GiaNhap.Text, out decimal giaNhap) == false || decimal.TryParse(txt_GiaXuat.Text, out decimal giaXuat) == false)
            {
                MessageBox.Show("Giá nhập và giá xuất phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // kiểm tra thời gian bảo hành
            if (int.TryParse(txt_TGBH.Text, out int tgBaoHanh) == false)
            {
                MessageBox.Show("Thời gian bảo hành phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // nếu các ô số lượng, giá nhập, giá xuất, thời gian bảo hành không phải là số hoặc bé hơn 0 thì thông báo hoặc bằng 0
            if (int.TryParse(txt_SL.Text, out int sl) == false || sl <= 0)
            {
                MessageBox.Show("Số lượng sản phẩm phải là số và lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (giaNhap <= 0 || giaXuat <= 0 || tgBaoHanh <= 0)
            {
                MessageBox.Show("Giá nhập, giá xuất và thời gian bảo hành phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // xóa sản phẩm
            if (txt_MSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(check_SP() == false)
            {
                return;
            }
            else
            {
                string query = "DELETE FROM SANPHAM WHERE MA_SP = @MA_SP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_SP", txt_MSP.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Load_data();
                CLEAR();
            }
        }

        private void CLEAR()
        {
            txt_MSP.Text = "";
            txt_TenSP.Text = "";
            cob_Loai.Text = "";
            txt_TGBH.Text = "";
            txt_GiaXuat.Text = "";
            txt_GiaNhap.Text = "";
            txt_Anh.Text = "";
            picb_SanPham.Image = null;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Truy vấn cập nhật
                string query = "UPDATE SANPHAM SET TEN_SP = @TEN_SP, MOTA_SP = @MOTA_SP, SOLUONG_SP = @SOLUONG_SP, " +
                               "GIA_BAN = @GIA_BAN, GIA_NHAP = @GIA_NHAP, TGBAOHANH = @TGBAOHANH, ANH_SP = @ANH_SP, " +
                               "MA_LOAI = @MA_LOAI WHERE MA_SP = @MA_SP";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_SP", txt_MSP.Text);
                cmd.Parameters.AddWithValue("@TEN_SP", txt_TenSP.Text);
                cmd.Parameters.AddWithValue("@MOTA_SP", txt_MoTa.Text ?? string.Empty);
                cmd.Parameters.AddWithValue("@SOLUONG_SP", int.TryParse(txt_SL.Text, out int sl) ? sl : 0);
                cmd.Parameters.AddWithValue("@GIA_BAN", decimal.TryParse(txt_GiaXuat.Text, out decimal giaBan) ? giaBan : 0);
                cmd.Parameters.AddWithValue("@GIA_NHAP", decimal.TryParse(txt_GiaNhap.Text, out decimal giaNhap) ? giaNhap : 0);
                cmd.Parameters.AddWithValue("@TGBAOHANH", int.TryParse(txt_TGBH.Text, out int tgBaoHanh) ? tgBaoHanh : 0);
                cmd.Parameters.AddWithValue("@ANH_SP", txt_Anh.Text ?? string.Empty);

                // Lấy MA_LOAI từ ComboBox
                string query2 = "SELECT MA_LOAI FROM LOAISANPHAM WHERE TENLOAI = @TENLOAI";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@TENLOAI", cob_Loai.Text);
                conn.Open();
                object maLoaiObj = cmd2.ExecuteScalar();
                if (maLoaiObj == null)
                {
                    MessageBox.Show("Loại sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmd.Parameters.AddWithValue("@MA_LOAI", maLoaiObj.ToString());

                // Thực thi truy vấn
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Sản phẩm đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_data();
                CLEAR();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btn_XuatEx_Click(object sender, EventArgs e)
        {
            // xuất excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Sản phẩm";
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    var cellValue = dataGridView.Rows[i].Cells[j].Value;
                    worksheet.Cells[i + 2, j + 1] = cellValue != null ? cellValue.ToString() : string.Empty;
                }
            }
        }

        private void btn_XuatDS_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                conn.Open();

                // Truy vấn lấy tất cả dữ liệu khách hàng
                string query = "SELECT * FROM SANPHAM";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Khởi tạo danh sách để chứa dữ liệu khách hàng
                List<SanPham> listSanPham = new List<SanPham>();

                // Đọc dữ liệu và thêm vào danh sách
                while (reader.Read())
                {
                    listSanPham.Add(new SanPham
                    {
                        MA_SP = reader["MA_SP"].ToString(),
                        TEN_SP = reader["TEN_SP"].ToString(),
                        MOTA_SP = reader["MOTA_SP"].ToString(),
                        SOLUONG_SP = Int32.Parse(reader["SOLUONG_SP"].ToString()),
                        GIA_BAN = decimal.Parse(reader["GIA_BAN"].ToString()),
                        GIA_NHAP = decimal.Parse(reader["GIA_NHAP"].ToString()),
                        TGBAOHANH = Int32.Parse(reader["TGBAOHANH"].ToString()),
                        ANH_SP = reader["ANH_SP"].ToString(),
                        MA_LOAI = reader["MA_LOAI"].ToString(),
                    });
                }

                // Đóng reader
                reader.Close();

                // Gọi phương thức để hiển thị báo cáo
                Report_SanPham reportForm = new Report_SanPham(listSanPham);
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

        private void btn_InSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MSP.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Mở kết nối
                conn.Open();

                // Truy vấn tìm kiếm dựa trên thông tin từ TextBox
                string query = "SELECT * FROM SANPHAM WHERE 1=1";

                if (!string.IsNullOrEmpty(txt_MSP.Text))
                    query += " AND MA_SP LIKE @MASP";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Thêm các tham số vào câu lệnh
                if (!string.IsNullOrEmpty(txt_MSP.Text)) cmd.Parameters.AddWithValue("@MASP", "%" + txt_MSP.Text.Trim() + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                // Khởi tạo danh sách để chứa dữ liệu khách hàng
                List<SanPham> listSanPham = new List<SanPham>();

                // Đọc dữ liệu và thêm vào danh sách
                while (reader.Read())
                {
                    listSanPham.Add(new SanPham
                    {
                        MA_SP = reader["MA_SP"].ToString(),
                        TEN_SP = reader["TEN_SP"].ToString(),
                        MOTA_SP = reader["MOTA_SP"].ToString(),
                        SOLUONG_SP = Int32.Parse(reader["SOLUONG_SP"].ToString()),
                        GIA_BAN = decimal.Parse(reader["GIA_BAN"].ToString()),
                        GIA_NHAP = decimal.Parse(reader["GIA_NHAP"].ToString()),
                        TGBAOHANH = Int32.Parse(reader["TGBAOHANH"].ToString()),
                        ANH_SP = reader["ANH_SP"].ToString(),
                        MA_LOAI = reader["MA_LOAI"].ToString(),
                    });
                }

                // Đóng reader
                reader.Close();

                // Gọi phương thức để hiển thị báo cáo
                Report_SanPham reportForm = new Report_SanPham(listSanPham);
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

            try
            {
                // Mở kết nối
                conn.Open();

                // Xác định cột cần tìm kiếm dựa vào giá trị ComboBox
                string column = "";
                switch (cb_KieuTimKiem.SelectedItem.ToString())
                {
                    case "Mã sản phẩm":
                        column = "MA_SP";
                        break;
                    case "Tên sản phẩm":
                        column = "TEN_SP";
                        break;

                    default:
                        MessageBox.Show("Vui lòng chọn kiểu tìm kiếm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Truy vấn tìm kiếm
                string query = $"SELECT * FROM SANPHAM WHERE {column} LIKE @SearchValue";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchValue", "%" + txt_ThongTin.Text.Trim() + "%");

                // Đổ dữ liệu vào DataTable
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gắn dữ liệu vào DataGridView
                dataGridView.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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