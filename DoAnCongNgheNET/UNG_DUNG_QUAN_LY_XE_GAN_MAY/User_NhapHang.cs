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
using System.IO;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class User_NhapHang : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        private NhanVien CurrentNhanVien;
        private List<HoaDon> hoaDonNhaps = new List<HoaDon>();
        private List<SanPham> sanPhams = new List<SanPham>();
        private List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
        //private HoaDon hoaDon = new HoaDon();
        public User_NhapHang(NhanVien currentNhanVien, List<HoaDon> hoaDonNhap, List<SanPham> sanPham, List<NhaCungCap> nhaCungCap)
        {
            InitializeComponent();
            CurrentNhanVien = currentNhanVien;
            sanPhams = sanPham;
            hoaDonNhaps = hoaDonNhap;
            nhaCungCaps = nhaCungCap;
        }
        public string MaHDNew(List<HoaDon> hoaDons)
        {
            if (hoaDons == null || hoaDons.Count == 0)
            {

                return "HDN001";
            }
            string MaMax = hoaDons.OrderByDescending(hd => hd.MaHD).First().MaHD;
            int nextNumber = int.Parse(MaMax.Substring(3)) + 1;
            MaMax = $"HDN{nextNumber.ToString("D3")}";
            return MaMax;
        }
        public void LoadSanPham(List<SanPham> sp)
        {
            //LoadSP();
            //if (sanPhams == null || sanPhams.Count == 0)
            //{
            //    MessageBox.Show("Không có sản phẩm nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            dataGridView.DataSource = null;
            dataGridView.DataSource = sp;

            dataGridView.Columns["TEN_SP"].HeaderText = "Tên SP";
            //dataGridView.Columns["SoLuong"].HeaderText = "SL";
            if (dataGridView.Columns["SOLUONG_SP"] != null)
            {
                dataGridView.Columns["SOLUONG_SP"].HeaderText = "SL";
                dataGridView.Columns["SOLUONG_SP"].Width = 9; // Điều chỉnh lại chiều rộng phù hợp
            }
            // Ẩn các cột không cần thiết
            dataGridView.Columns["MA_SP"].Visible = false;
            dataGridView.Columns["MOTA_SP"].Visible = false;
            dataGridView.Columns["GIA_NHAP"].Visible = false;
            dataGridView.Columns["TGBAOHANH"].Visible = false;
            dataGridView.Columns["ANH_SP"].Visible = false;
            dataGridView.Columns["MA_LOAI"].Visible = false;

            dataGridView.Columns["GIA_BAN"].Visible = false;
            dataGridView.Columns["Tongtt"].Visible = false;
        }
        public void LoadSanPham1(List<SanPham> sp)
        {
            //LoadSP();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sp;
            dataGridView1.Columns["TEN_SP"].HeaderText = "Tên SP";
            dataGridView1.Columns["SOLUONG_SP"].HeaderText = "SL";
            dataGridView1.Columns["TEN_SP"].Width = 15;
            dataGridView1.Columns["SOLUONG_SP"].Width = 7;

            //dataGridView1.Columns["Tongtt"].Width = 100;
            dataGridView1.Columns["MA_SP"].Visible = false;
            dataGridView1.Columns["MOTA_SP"].Visible = false;
            dataGridView1.Columns["GIA_NHAP"].Visible = false;
            dataGridView1.Columns["GIA_BAN"].Visible = false;
            dataGridView1.Columns["TGBAOHANH"].Visible = false;
            dataGridView1.Columns["ANH_SP"].Visible = false;
            dataGridView1.Columns["MA_LOAI"].Visible = false;
        }
        public void LoadNCC()
        {

            foreach (NhaCungCap nha in nhaCungCaps)
            {
                cb_NCC.Items.Add(nha.TenNCC);
            }
            cb_NCC.SelectedIndex = 0;
        }
        public void LoadCB_SP()
        {
            cb_TenHang.Items.Add("");
            foreach (SanPham sanPham in sanPhams)
            {
                cb_TenHang.Items.Add(sanPham.TEN_SP);
            }
            cb_TenHang.SelectedIndex = 0;
        }
        private HoaDon hoaDon = new HoaDon();
        int slsp = 0, tong_sl = 0;
        decimal tong_bill = 0;
        List<SanPham> sp_dat = new List<SanPham>();
        void LoadTong_Sl()
        {
            tong_bill = sp_dat.Sum(t => t.Tongtt);
            tong_sl = sp_dat.Sum(t => t.SOLUONG_SP);

            lb_ThongTT2.Text = tong_bill.ToString("N0");
            lb_TongSL2.Text = tong_sl.ToString();
        }
        private void User_NhapHang_Load(object sender, EventArgs e)
        {

            LoadNCC();
            LoadCB_SP();
            LoadSanPham(sanPhams);
            
        }

        private void btn_TaoPN_Click(object sender, EventArgs e)
        {
            if(btn_TaoPN.BackColor == Color.AliceBlue)
            {
                string Mamoi = MaHDNew(hoaDonNhaps);
                txt_MaHD1.Text = Mamoi;
                btn_TaoPN.Text = "Tạo Hoá Đơn";
                cb_NCC.Enabled = true;
                btn_TaoPN.BackColor = Color.DarkBlue;
                btn_TaoPN.ForeColor = Color.White;
                //hoaDon.Ma_NV
                hoaDon.Ma_NV = CurrentNhanVien.Login;
                //hoaDon.Ngay
                hoaDon.Ngay = dt_NgayNhap.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                if(cb_NCC==null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult r;
                r = MessageBox.Show($"Bạn có muốn tạo hoá đơn với Nhà Cung Cấp {cb_NCC.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No)
                {
                    return;
                }
                //hoaDon.MaHD
                hoaDon.MaHD = txt_MaHD1.Text;
                var selectedNCC = nhaCungCaps.FirstOrDefault(t => t.TenNCC == cb_NCC.Text);
                if (selectedNCC != null)
                {
                    hoaDon.MA_NCC = selectedNCC.MaNCC;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btn_TaoPN.BackColor = Color.AliceBlue;
                btn_TaoPN.ForeColor = Color.FromArgb(0, 120, 215);
                txt_MaHD2.Text = hoaDon.MaHD;
                txt_MaHD1.Clear();
                cb_NCC.Text = ""; 
                cb_NCC.Enabled = false;
                cb_TenHang.Enabled = true;
                txt_SoLuong.Enabled= true;
                txt_GiaNhap.Enabled = true;
                dataGridView.Enabled = true;
            }
           
        }

        private void cb_TenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sanPham = sanPhams.FirstOrDefault(t => t.TEN_SP == cb_TenHang.Text);

            if (sanPham != null)
            {
                LoadSanPham(sanPhams.Where(t => t.TEN_SP == sanPham.TEN_SP).ToList());
                txt_SoLuong.Clear();
                txt_GiaNhap.Clear();
                string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagePath = Path.Combine(projectPath, "image_xe", sanPham.ANH_SP);

                if (File.Exists(imagePath))
                {
                    picb_SanPham.Image = Image.FromFile(imagePath);
                }
                else
                {
                    picb_SanPham.Image = null; // Reset ảnh nếu không tìm thấy
                    MessageBox.Show("Không tìm thấy file ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txt_GiaNhap.Text = "";
                picb_SanPham.Image = null; // Reset ảnh nếu không tìm thấy sản phẩm
                LoadSanPham(sanPhams);
            }
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SanPham sanPham = new SanPham();
            int i;
            i = dataGridView.CurrentCell.RowIndex;
            sanPham = sanPhams.FirstOrDefault(t => t.MA_SP == dataGridView.Rows[i].Cells[0].Value.ToString());
            cb_TenHang.Text = sanPham.TEN_SP;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SanPham sanPham = new SanPham();
            int i = dataGridView1.CurrentCell.RowIndex;
            var cellValue = dataGridView1.Rows[i].Cells["TenSP"].Value;
            sanPham = sp_dat.FirstOrDefault(t => t.TEN_SP == cellValue.ToString());
            cb_TenHang.Text = sanPham.TEN_SP;
            txt_SoLuong.Text = sanPham.SOLUONG_SP.ToString();
            txt_GiaNhap.Text = sanPham.GIA_NHAP.ToString();
        }
        private bool TryParsePositiveInteger(string input, out int value, string fieldName)
        {
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show($"Vui lòng nhập {fieldName}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                value = 0;
                return false;
            }

            if (!int.TryParse(input, out value) || value <= 0)
            {
                MessageBox.Show($"{fieldName} phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                value = 0;
                return false;
            }

            return true;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string tenSP = cb_TenHang.Text;
            if (string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số lượng nhập vào
            if (!TryParsePositiveInteger(txt_SoLuong.Text, out int soLuong, "số lượng"))
            {
                return;
            }

            // Kiểm tra giá nhập
            if (!TryParsePositiveInteger(txt_GiaNhap.Text, out int giaNhap, "giá nhập"))
            {
                return;
            }

            // Kiểm tra sản phẩm có tồn tại trong danh sách gốc
            SanPham sanPham1 = sanPhams.FirstOrDefault(t => t.TEN_SP == tenSP);
            if (sanPham1 == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận
            DialogResult r = MessageBox.Show(
                $"Bạn có muốn thêm SP: {tenSP} với SL: {soLuong} và giá thành: {giaNhap}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                return;
            }

            // Kiểm tra và thêm/sửa sản phẩm trong danh sách đặt hàng
            SanPham sanPham = sp_dat.FirstOrDefault(sp => sp.TEN_SP == tenSP);
            if (sanPham != null)
            {
                sanPham.SOLUONG_SP += soLuong;
            }
            else
            {
                sanPham = new SanPham
                {
                    MA_SP = sanPham1.MA_SP,
                    TEN_SP = sanPham1.TEN_SP,
                    SOLUONG_SP = soLuong,
                    GIA_BAN = giaNhap
                };
                sp_dat.Add(sanPham);
            }

            // Cập nhật giao diện
            LoadSanPham1(sp_dat);
            LoadSanPham(sanPhams);
            LoadTong_Sl();

            MessageBox.Show($"Thêm sản phẩm {tenSP} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string tensp = cb_TenHang.Text;
            if (tensp == "")
                return;
            DialogResult r;
            r = MessageBox.Show($"Bạn có muốn xoá SP này: {tensp} ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                return;
            }

            SanPham sanPhamToDelete = sp_dat.FirstOrDefault(sp => sp.TEN_SP == tensp);

            if (sanPhamToDelete != null)
            {
                sp_dat.Remove(sanPhamToDelete);

                LoadSanPham1(sp_dat);

                MessageBox.Show($"Sản phẩm {tensp} đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTong_Sl();
            LoadSanPham(sanPhams);
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string tensp = cb_TenHang.Text;

            if (string.IsNullOrEmpty(tensp))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show($"Bạn có muốn sửa sản phẩm {tensp} với số lượng mới là: {txt_SoLuong.Text} và giá là: {txt_GiaNhap.Text} không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                return;
            }

            if (!int.TryParse(txt_SoLuong.Text, out int sl) || sl < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá nhập
            if (!TryParsePositiveInteger(txt_GiaNhap.Text, out int giaNhap, "giá nhập"))
            {
                return;
            }
            SanPham sanPhamToUpdate = sp_dat.FirstOrDefault(sp => sp.TEN_SP == tensp);
            if (sanPhamToUpdate == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại trong danh sách đặt hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sl == 0)
            {
                sp_dat.Remove(sanPhamToUpdate);
                MessageBox.Show($"Sản phẩm {tensp} đã được xóa khỏi danh sách đặt hàng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadSanPham1(sp_dat); 
                LoadTong_Sl(); 
                return; 
            }

            sanPhamToUpdate.SOLUONG_SP = sl;
            sanPhamToUpdate.GIA_NHAP=giaNhap;
            LoadSanPham1(sp_dat);
            LoadSanPham(sanPhams);
            LoadTong_Sl(); 

            MessageBox.Show($"Sản phẩm {tensp} đã được cập nhật thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_MaHD2_TextChanged(object sender, EventArgs e)
        {
            if (txt_MaHD2 == null || txt_MaHD2.Text == "" || txt_MaHD2.Text == null)
            {
                btn_Them.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
            }
            else
            {
                btn_Them.Enabled = true;
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
            }
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaHD2.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<HoaDonNhap> hoadonnhap = new List<HoaDonNhap>();
            hoadonnhap.Add( new HoaDonNhap { MAHD_NHAP=  hoaDon.MaHD, MA_NCC =  hoaDon.MA_NCC,MA_NV = hoaDon.Ma_NV,TONGBILL_NHAP= tong_bill,NGAYNHAP= hoaDon.Ngay });
            List<CTHDNhap> cTHDNhaps = new List<CTHDNhap>();

            foreach (var sp in sp_dat)
            {
                cTHDNhaps.Add(new CTHDNhap
                {
                    MAHD_NHAP = hoaDon.MaHD,
                    MA_SP = sp.MA_SP,
                    SL_NHAP = sp.SOLUONG_SP,
                    GIA_SP = sp.GIA_NHAP
                });
            }
            Report_NhapHang report_NhapHang = new Report_NhapHang(hoadonnhap,cTHDNhaps);
            report_NhapHang.Show();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show($"Bạn có muốn lưu hoá đơn {txt_MaHD2.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                return;
            }
            conn.Open();
            string checkQuery = "SELECT COUNT(*) FROM HD_NHAP WHERE MAHD_NHAP = @MaHD";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
                return;
            }

            hoaDonNhaps.Add(hoaDon);
            //hoaDon.TongBill
            hoaDon.TongBill = tong_bill;
            string query = "INSERT INTO HD_NHAP " +
               "VALUES (@MaHD, @MaNCC, @Ma_NV, @TongBill, @NgayNhap)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
            cmd.Parameters.AddWithValue("@MaNCC", hoaDon.MA_NCC);
            cmd.Parameters.AddWithValue("@Ma_NV", hoaDon.Ma_NV);
            cmd.Parameters.AddWithValue("@TongBill", hoaDon.TongBill);
            cmd.Parameters.AddWithValue("@NgayNhap", hoaDon.Ngay);
            cmd.ExecuteNonQuery();
            conn.Close();

            // Xử lý các sản phẩm trong hóa đơn xuất
            slsp = sp_dat.Count();
            if (slsp > 0)
            {
                foreach (var sp in sp_dat)
                {
                    conn.Open();
                    string query1 = "INSERT INTO CTHD_NHAP " +
                    "VALUES (@MaHD, @MaSP, @SoLuong, @GiaNhap)";
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
                    cmd1.Parameters.AddWithValue("@MaSP", sp.MA_SP);
                    cmd1.Parameters.AddWithValue("@SoLuong", sp.SOLUONG_SP);
                    cmd1.Parameters.AddWithValue("@GiaNhap", sp.GIA_NHAP);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
            }
            foreach (var sp in sanPhams)
            {
                foreach (var sp1 in sp_dat)
                {
                    if (sp.MA_SP == sp1.MA_SP)
                    {
                        sp.SOLUONG_SP = sp.SOLUONG_SP + sp1.SOLUONG_SP;
                        conn.Open();
                        string query2 = "UPDATE SANPHAM SET SOLUONG_SP = @SoLuong WHERE MA_SP = @MaSP";
                        SqlCommand cmd2 = new SqlCommand(query2, conn);
                        cmd2.Parameters.AddWithValue("@SoLuong", sp.SOLUONG_SP);
                        cmd2.Parameters.AddWithValue("@MaSP", sp.MA_SP);
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                    }
                }
            }
            txt_MaHD2.Clear();
            cb_TenHang.Text = "";
            txt_GiaNhap.Clear();
            txt_SoLuong.Clear();
            picb_SanPham.Image = null;
            dataGridView.Enabled = false;
            cb_TenHang.Enabled = false;
            txt_SoLuong.Enabled = false;

            dataGridView.Enabled = false;
            sp_dat.Clear();
            MessageBox.Show("Hóa đơn đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSanPham1(sp_dat);
            LoadTong_Sl();
        }

        
    }
}
