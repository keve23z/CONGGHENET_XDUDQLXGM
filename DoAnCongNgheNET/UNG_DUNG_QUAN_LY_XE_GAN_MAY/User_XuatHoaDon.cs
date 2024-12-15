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

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class User_XuatHoaDon : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        public User_XuatHoaDon()
        {
            InitializeComponent();
        }
        public class sp
        {
            public string ma { get; set; }
            public int sl { get; set; }
        }
        public void loaddata()
        {
            string query = "select CTHD_XUAT.MAHD_XUAT, HD_XUAT_BAOHANH.NGAYXUAT, HD_XUAT_BAOHANH.TONGBILL_XUAT, KHACHHANG.TENKH " +
                "from CTHD_XUAT join HD_XUAT_BAOHANH on CTHD_XUAT.MAHD_XUAT=HD_XUAT_BAOHANH.MAHD_XUAT " +
                "join KHACHHANG on HD_XUAT_BAOHANH.SDT_KH=KHACHHANG.SDT_KH " +
                "where CTHD_XUAT.SOLAN_XUAT is null " +
                "group by CTHD_XUAT.MAHD_XUAT, HD_XUAT_BAOHANH.NGAYXUAT, HD_XUAT_BAOHANH.TONGBILL_XUAT, KHACHHANG.TENKH";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            dataGridView.CellFormatting += (sender, e) =>
            {
                if (dataGridView.Columns[e.ColumnIndex].Name == "NGAYXUAT" && e.Value != null)
                {
                    DateTime dateValue;
                    if (DateTime.TryParse(e.Value.ToString(), out dateValue))
                    {
                        e.Value = dateValue.ToString("dd-MM-yyyy");
                        e.FormattingApplied = true;
                    }
                }
            };
        }

        List<sp> originalList = new List<sp>();
        List<sp> temp = new List<sp>();
        public void loaddata1(string Ma)
        {
            try
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT SANPHAM.TEN_SP, CTHD_XUAT.SL_SANPHAM " +
                                                       "FROM SANPHAM JOIN CTHD_XUAT ON SANPHAM.MA_SP = CTHD_XUAT.MA_SP " +
                                                       "WHERE MAHD_XUAT = @Ma AND SOLAN_XUAT IS NULL", conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", Ma);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        originalList.Clear(); // Xóa dữ liệu cũ trong originalList

                        while (reader.Read())
                        {
                            sp item = new sp
                            {
                                ma = reader["TEN_SP"].ToString(),
                                sl = Convert.ToInt32(reader["SL_SANPHAM"])
                            };
                            originalList.Add(item);
                        }

                        if (originalList.Count > 0)
                        {
                            // Gán dữ liệu cho DataGridView và cấu hình các cột
                            loadgird1(originalList);

                            // Hiển thị các nút liên quan
                            //btnXSL.Visible = true;
                            btnXuat.Visible = true;
                            btnXSP.Visible = true;
                            btnXuatALL.Visible = true;
                            //txtSLX.Visible = true;

                            // Xóa giỏ hàng tạm thời
                            temp.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void loadgird1(List<sp> list)
        {
            dataGridView1.DataSource = null; // Xóa dữ liệu cũ
            dataGridView1.DataSource = list; // Gán dữ liệu mới
            dataGridView1.Columns["ma"].HeaderText = "Mã SP";
            dataGridView1.Columns["sl"].HeaderText = "SL";
            dataGridView1.Columns["ma"].Width = 170;
        }

        public void loadgird2(List<sp> list)
        {
            dataGridView2.DataSource = null; // Xóa dữ liệu cũ
            dataGridView2.DataSource = list; // Gán dữ liệu mới
            dataGridView2.Columns["ma"].HeaderText = "Mã SP";
            dataGridView2.Columns["sl"].HeaderText = "SL";
            dataGridView2.Columns["ma"].Width = 170;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                int i = dataGridView1.CurrentRow.Index;
                txtTenSP.Text = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                txtSL.Text = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();

            }
        }

        private void User_XuatHoaDon_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {

                int i = dataGridView.CurrentRow.Index;
                txtMaHD.Text = dataGridView.Rows[i].Cells[0].Value.ToString().Trim();
                loaddata1(dataGridView.Rows[i].Cells[0].Value.ToString().Trim());

            }
        }

        private void btnXSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để thêm vào giỏ.");
                return;
            }

            // Tìm sản phẩm trong originalList
            var productInOriginal = originalList.FirstOrDefault(item => item.ma == txtTenSP.Text);
            if (productInOriginal == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại trong danh sách gốc.");
                return;
            }

            // Tìm sản phẩm trong giỏ hàng (temp)
            var productInCart = temp.FirstOrDefault(item => item.ma == txtTenSP.Text);

            if (productInCart == null)
            {
                // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới toàn bộ số lượng
                temp.Add(new sp
                {
                    ma = productInOriginal.ma,
                    sl = productInOriginal.sl
                });
            }
            else
            {
                // Nếu sản phẩm đã có trong giỏ hàng, cộng thêm số lượng
                productInCart.sl += productInOriginal.sl;
            }

            // Loại bỏ sản phẩm khỏi danh sách gốc
            originalList.Remove(productInOriginal);

            // Cập nhật giao diện
            loadgird1(originalList);
            loadgird2(temp);

            // Thông báo thành công
            MessageBox.Show($"Đã chuyển toàn bộ sản phẩm '{txtTenSP.Text}' vào danh sách.");

        }

        private void btnXuatALL_Click(object sender, EventArgs e)
        {
            if (originalList.Count == 0)
            {
                MessageBox.Show("Danh sách gốc trống, không có sản phẩm để chuyển.");
                return;
            }

            // Duyệt qua từng sản phẩm trong originalList và chuyển qua giỏ hàng
            foreach (var product in originalList)
            {
                var productInCart = temp.FirstOrDefault(item => item.ma == product.ma);
                if (productInCart == null)
                {
                    // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                    temp.Add(new sp
                    {
                        ma = product.ma,
                        sl = product.sl
                    });
                }
                else
                {
                    // Nếu sản phẩm đã có trong giỏ hàng, cộng thêm số lượng
                    productInCart.sl += product.sl;
                }
            }

            // Xóa toàn bộ sản phẩm khỏi danh sách gốc
            originalList.Clear();

            // Cập nhật giao diện
            loadgird1(originalList); // Cập nhật danh sách gốc (trống)
            loadgird2(temp);         // Cập nhật giỏ hàng (đã thêm toàn bộ sản phẩm)

            // Thông báo thành công
            MessageBox.Show("Đã chuyển toàn bộ sản phẩm vào giỏ hàng.");

        }

        private async void btnXuat_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu giỏ hàng trống
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống, không có sản phẩm để xuất.");
                return;
            }

            // Kết nối cơ sở dữ liệu
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Lấy thông tin từ DataGridView
                        string tenSP = row.Cells["ma"]?.Value?.ToString();
                        int slSanPham;
                        if (!int.TryParse(row.Cells["sl"]?.Value?.ToString(), out slSanPham) || slSanPham <= 0)
                        {
                            MessageBox.Show($"Sản phẩm '{tenSP}' có số lượng không hợp lệ.");
                            continue;
                        }

                        if (string.IsNullOrEmpty(tenSP))
                        {
                            MessageBox.Show("Tên sản phẩm không hợp lệ.");
                            continue;
                        }

                        // Lấy mã sản phẩm từ tên sản phẩm
                        string maSP = null;
                        string findMaSPQuery = @"SELECT MA_SP FROM SANPHAM WHERE TEN_SP = @TEN_SP";

                        using (SqlCommand cmdFindMaSP = new SqlCommand(findMaSPQuery, conn))
                        {
                            cmdFindMaSP.Parameters.AddWithValue("@TEN_SP", tenSP);
                            var result = await cmdFindMaSP.ExecuteScalarAsync();
                            if (result == null)
                            {
                                MessageBox.Show($"Không tìm thấy mã sản phẩm cho '{tenSP}'.");
                                continue;
                            }
                            maSP = result.ToString();
                        }

                        // Lấy mã hóa đơn xuất từ DataGridView hoặc TextBox
                        string maHDXuat = txtMaHD?.Text;
                        if (string.IsNullOrEmpty(maHDXuat))
                        {
                            MessageBox.Show("Mã hóa đơn xuất không hợp lệ.");
                            continue;
                        }

                        // Kiểm tra số lần xuất sản phẩm
                        string checkQuery = @"
                SELECT ISNULL(MAX(SOLAN_XUAT), 0) 
                FROM CTHD_XUAT 
                WHERE MAHD_XUAT = @MAHD_XUAT AND MA_SP = @MA_SP";

                        int maxXuat = 0;
                        using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@MAHD_XUAT", maHDXuat);
                            cmdCheck.Parameters.AddWithValue("@MA_SP", maSP);
                            var result = await cmdCheck.ExecuteScalarAsync();
                            if (result != null) maxXuat = Convert.ToInt32(result);
                        }

                        // Cập nhật số lần xuất
                        int newXuat = maxXuat + 1;
                        string updateQuery = @"
                UPDATE CTHD_XUAT
                SET SOLAN_XUAT = @SOLAN_XUAT
                WHERE MAHD_XUAT = @MAHD_XUAT AND MA_SP = @MA_SP";

                        using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@SOLAN_XUAT", newXuat);
                            cmdUpdate.Parameters.AddWithValue("@MAHD_XUAT", maHDXuat);
                            cmdUpdate.Parameters.AddWithValue("@MA_SP", maSP);

                            int rowsAffected = await cmdUpdate.ExecuteNonQueryAsync();
                            if (rowsAffected == 0)
                            {
                                MessageBox.Show($"Không cập nhật được sản phẩm '{tenSP}' vào hóa đơn '{maHDXuat}'.");
                            }
                        }
                    }

                    MessageBox.Show("Cập nhật xuất hàng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
                temp.Clear();
                loadgird2(temp);
                loaddata();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để thêm vào giỏ.");
                return;
            }

            // Tìm sản phẩm trong originalList
            var productInOriginal = temp.FirstOrDefault(item => item.ma == txtTenSP.Text);
            if (productInOriginal == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại trong danh sách gốc.");
                return;
            }

            // Tìm sản phẩm trong giỏ hàng (temp)
            var productInCart = originalList.FirstOrDefault(item => item.ma == txtTenSP.Text);

            if (productInCart == null)
            {
                // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới toàn bộ số lượng
                originalList.Add(new sp
                {
                    ma = productInOriginal.ma,
                    sl = productInOriginal.sl
                });
            }
            else
            {
                // Nếu sản phẩm đã có trong giỏ hàng, cộng thêm số lượng
                productInCart.sl += productInOriginal.sl;
            }

            // Loại bỏ sản phẩm khỏi danh sách gốc
            temp.Remove(productInOriginal);

            // Cập nhật giao diện
            loadgird1(originalList);
            loadgird2(temp);

            // Thông báo thành công
            MessageBox.Show($"Đã chuyển toàn bộ sản phẩm '{txtTenSP.Text}' vào danh sách.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (temp.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống, không có sản phẩm để chuyển lại danh sách.");
                return;
            }

            // Duyệt qua từng sản phẩm trong giỏ hàng và chuyển về danh sách gốc
            foreach (var productInCart in temp)
            {
                // Tìm sản phẩm trong danh sách gốc (originalList)
                var productInOriginal = originalList.FirstOrDefault(item => item.ma == productInCart.ma);
                if (productInOriginal == null)
                {
                    // Nếu sản phẩm không có trong danh sách gốc, thêm mới
                    originalList.Add(new sp
                    {
                        ma = productInCart.ma,
                        sl = productInCart.sl
                    });
                }
                else
                {
                    // Nếu sản phẩm đã có trong danh sách gốc, cộng thêm số lượng
                    productInOriginal.sl += productInCart.sl;
                }
            }

            // Xóa toàn bộ sản phẩm khỏi giỏ hàng (temp)
            temp.Clear();

            // Cập nhật giao diện
            loadgird1(originalList);  // Cập nhật danh sách gốc
            loadgird2(temp);          // Cập nhật giỏ hàng (trống)

            // Thông báo thành công
            MessageBox.Show("Đã chuyển toàn bộ sản phẩm từ giỏ hàng về danh sách.");

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {

                int i = dataGridView2.CurrentRow.Index;
                txtTenSP.Text = dataGridView2.Rows[i].Cells[0].Value.ToString().Trim();
                txtSL.Text = dataGridView2.Rows[i].Cells[1].Value.ToString().Trim();
                //button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
        }
    }
}
