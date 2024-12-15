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
using System.Net.NetworkInformation;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class User_HoaDon : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        private NhanVien CurrentNhanVien;
        private List<HoaDon> hoaDonXuats = new List<HoaDon>();
        private List<SanPham> sanPhams = new List<SanPham>();
        private List<KhachHang> khachHangs = new List<KhachHang>();

        public User_HoaDon(NhanVien currentNhanVien, List<HoaDon> hoaDonXuat, List<SanPham> sanPham, List<KhachHang> khachHang)
        {
            InitializeComponent();
            CurrentNhanVien = currentNhanVien;
            sanPhams=sanPham;
            hoaDonXuats = hoaDonXuat;
            khachHangs=khachHang;
        }
       
        //public void LoadHDX()
        //{
        //    conn.Open();
        //    SqlCommand cmd_HD = new SqlCommand("SELECT MAHD_XUAT,NGAYXUAT " +
        //                                        "FROM HD_XUAT_BAOHANH " +
        //                                        "WHERE MA_NV = '" + CurrentNhanVien.Login + "'", conn);
        //    SqlDataReader readerHD = cmd_HD.ExecuteReader();
        //    while (readerHD.Read())
        //    {
        //        HoaDon hoaDon = new HoaDon();
        //        hoaDon.MaHD = readerHD["MAHD_XUAT"].ToString();
        //        hoaDon.Ngay = Convert.ToDateTime(readerHD["NGAYXUAT"]).ToString("dd-MM-yyyy");
        //        hoaDonXuats.Add(hoaDon);
        //    }
        //    conn.Close();
        //}
        public string MaHDNew(List<HoaDon> hoaDons)
        {
            if (hoaDons == null || hoaDons.Count == 0)
            {
                
                return "HDX001";
            }
            string MaMax = hoaDons.OrderByDescending(hd => hd.MaHD).First().MaHD;
            int nextNumber = int.Parse(MaMax.Substring(3)) + 1; 
            MaMax = $"HDX{nextNumber.ToString("D3")}"; 
            return MaMax;
        }
        //public void LoadSP()
        //{
        //    conn.Open();
        //    SqlCommand cmd_HD = new SqlCommand("SELECT * " +
        //                                        "FROM SANPHAM ", conn);
        //    SqlDataReader readerHD = cmd_HD.ExecuteReader();
        //    while (readerHD.Read())
        //    {
        //        SanPham sanPham = new SanPham();
        //        sanPham.MaSP = readerHD["MA_SP"].ToString();
        //        sanPham.TenSP = readerHD["TEN_SP"].ToString();
        //        sanPham.MoTa = readerHD["MOTA_SP"].ToString();
        //        sanPham.SoLuong = int.Parse(readerHD["SOLUONG_SP"].ToString());
        //        sanPham.GiaBan = decimal.Parse(readerHD["GIA_BAN"].ToString());
        //        sanPham.GiaNhap = decimal.Parse(readerHD["GIA_NHAP"].ToString());
        //        sanPham.TgBaoHanh = int.Parse(readerHD["TGBAOHANH"].ToString());
        //        sanPham.AnhSP = readerHD["ANH_SP"].ToString();
        //        sanPham.MaLoai = readerHD["MA_LOAI"].ToString();
        //        sanPhams.Add(sanPham);
        //    }
        //    conn.Close();
        //}
        public void LoadSanPham(List<SanPham> sp)
        {
            //LoadSP();
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
        public void LoadKH()
        {
            cb_SDTKH.Items.Add("");
            foreach (KhachHang khach in khachHangs)
            {
                cb_SDTKH.Items.Add(khach.SDT_KH);
            }
            cb_SDTKH.SelectedIndex = 0;
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
        void LoadTong_Sl()
        {
            tong_bill = sp_dat.Sum(t => t.Tongtt);
            tong_sl = sp_dat.Sum(t => t.SOLUONG_SP);

            lb_ThongTT2.Text = tong_bill.ToString("N0");
            lb_TongSL2.Text = tong_sl.ToString();
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SanPham sanPham = new SanPham();
            int i;
            i = dataGridView.CurrentCell.RowIndex;
            sanPham = sanPhams.FirstOrDefault(t => t.MA_SP == dataGridView.Rows[i].Cells[0].Value.ToString());
            cb_TenHang.Text = sanPham.TEN_SP;
            //txt_GiaBan.Text=sanPham.GiaBan.ToString().Split('.')[0];
            //string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            //string imagePath = Path.Combine(projectPath, "image_xe", sanPham.AnhSP);
            //picb_SanPham.Image = Image.FromFile(imagePath);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            SanPham sanPham = new SanPham();
            int i = dataGridView1.CurrentCell.RowIndex;
            var cellValue = dataGridView1.Rows[i].Cells["TEN_SP"].Value;
            sanPham = sp_dat.FirstOrDefault(t => t.TEN_SP == cellValue.ToString());
            cb_TenHang.Text = sanPham.TEN_SP;
            txt_SoLuong.Text = sanPham.SOLUONG_SP.ToString();
        }
        private void User_HoaDon_Load(object sender, EventArgs e)
        {
            //LoadHDX();
            //LoadCB_SP();//bo
            LoadKH();
            LoadCB_SP();
            //LoadSanPham1(sp_dat);
            
        }
       
        private HoaDon hoaDon = new HoaDon();
        int slsp = 0, tong_sl = 0;
        decimal tong_bill = 0;
        List<SanPham> sp_dat = new List<SanPham>();
        private void btn_TaoHD_Click(object sender, EventArgs e)
        {
            if (btn_TaoHD.BackColor == Color.AliceBlue)
            {
                string Mamoi = MaHDNew(hoaDonXuats);
                txt_MaHD1.Text = Mamoi;
                btn_TaoHD.Text = "Tạo Hoá Đơn";
                //hoaDon.Ma_NV
                hoaDon.Ma_NV = CurrentNhanVien.Login;
                //hoaDon.Ngay
                hoaDon.Ngay= dt_NgayNhap.Value.ToString("yyyy-MM-dd");
                cb_SDTKH.Enabled = true;
                txt_TenKH.Enabled = true;
                btn_TaoHD.BackColor = Color.DarkBlue;
                btn_TaoHD.ForeColor = Color.White;
            }
            else
            {
                if (cb_SDTKH.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult r;
                r = MessageBox.Show($"Bạn có muốn tạo hoá đơn với Số Điện Thoại: {cb_SDTKH.Text} và Tên KH: {txt_TenKH.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No)
                {
                    return;
                }
                //hoaDon.MaHD
                hoaDon.MaHD = txt_MaHD1.Text;
                var selectedSDTKH = khachHangs.FirstOrDefault(t => t.SDT_KH == cb_SDTKH.Text);
                if (selectedSDTKH != null)
                {
                    //hoaDon.SDT_KH
                    hoaDon.SDT_KH = selectedSDTKH.SDT_KH;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Khach hang!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                btn_TaoHD.BackColor = Color.AliceBlue;
                btn_TaoHD.ForeColor = Color.FromArgb(0, 120, 215);
                txt_MaHD2.Text = hoaDon.MaHD;
                txt_MaHD1.Clear();
                cb_SDTKH.Text = "";
                txt_TenKH.Text = "";
                cb_SDTKH.Enabled = false;
                cb_TenHang.Enabled = true;
                txt_SoLuong.Enabled = true;
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
                txt_GiaBan.Text = sanPham.GIA_BAN.ToString().Split('.')[0];
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
                txt_GiaBan.Text = " ";
                picb_SanPham.Image = null; // Reset ảnh nếu không tìm thấy sản phẩm
                LoadSanPham(sanPhams);
            }
        }

        private void cb_SDTKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            var khachHang = khachHangs.FirstOrDefault(t => t.SDT_KH == cb_SDTKH.Text);
            
            if (khachHang != null)
            {
                txt_TenKH.Text=khachHang.TENKH.ToString();
            }
            else
            {
                txt_TenKH.Text = "";
            }
        }
        
        private void btn_LuuHD_Click(object sender, EventArgs e)
        {
            //hoaDon.PhuongThucGiaoDich
            if (rdo_TienMat.Checked)
            {
                hoaDon.PhuongThucGiaoDich = rdo_TienMat.Text;
            }
            else if (rdo_ATM.Checked)
            {
                hoaDon.PhuongThucGiaoDich = "Chuyển khoản";
            }
            else if (rdo_Khac.Checked)
            {

                hoaDon.PhuongThucGiaoDich = txt_Khac.Text;
            }

            if (string.IsNullOrWhiteSpace(hoaDon.PhuongThucGiaoDich))
            {
                MessageBox.Show("Phương thức giao dịch không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult r;
            r = MessageBox.Show($"Bạn có muốn lưu hoá đơn {txt_MaHD2.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                return;
            }
            conn.Open();
            string checkQuery = "SELECT COUNT(*) FROM HD_XUAT_BAOHANH WHERE MAHD_XUAT = @MaHD";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0) 
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
                return;
            }
            slsp = sp_dat.Count();
            hoaDonXuats.Add(hoaDon);
            //hoaDon.TongBill
            hoaDon.TongBill = tong_bill;
            string query = "INSERT INTO HD_XUAT_BAOHANH " +
               "VALUES (@MaHD, @SDT_KH, @Ma_NV, @TongBill, @PhuongThucGiaoDich, @NgayXuat)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
            cmd.Parameters.AddWithValue("@SDT_KH", hoaDon.SDT_KH);
            cmd.Parameters.AddWithValue("@Ma_NV", hoaDon.Ma_NV);
            cmd.Parameters.AddWithValue("@TongBill", hoaDon.TongBill);
            cmd.Parameters.AddWithValue("@PhuongThucGiaoDich", hoaDon.PhuongThucGiaoDich);
            cmd.Parameters.AddWithValue("@NgayXuat", hoaDon.Ngay);
            cmd.ExecuteNonQuery();
            conn.Close();

            // Xử lý các sản phẩm trong hóa đơn xuất
            if (slsp>0)
            {
                foreach (var sp in sp_dat)
                {
                    conn.Open();
                    string query1 = "INSERT INTO CTHD_XUAT (MAHD_XUAT, MA_SP, SL_SANPHAM, GIA_SP, NGAY_BD, NGAY_KT) " +
                    "VALUES (@MaHD, @MaSP, @SoLuong, @GiaBan, @Ngay, DATEADD(MONTH, @TgBaoHanh, @Ngay))";
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
                    cmd1.Parameters.AddWithValue("@MaSP", sp.MA_SP);
                    cmd1.Parameters.AddWithValue("@SoLuong", sp.SOLUONG_SP);
                    cmd1.Parameters.AddWithValue("@GiaBan", sp.GIA_BAN);
                    cmd1.Parameters.AddWithValue("@Ngay", hoaDon.Ngay);
                    cmd1.Parameters.AddWithValue("@TgBaoHanh", sp.TGBAOHANH);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
            }
            foreach (var sp in sanPhams)
            {
                conn.Open();
                string query2 = "UPDATE SANPHAM SET SOLUONG_SP = @SoLuong WHERE MA_SP = @MaSP";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@SoLuong", sp.SOLUONG_SP);
                cmd2.Parameters.AddWithValue("@MaSP", sp.MA_SP);
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            txt_MaHD2.Clear();
            cb_TenHang.Text = "";
            txt_GiaBan.Clear();
            txt_SoLuong.Clear();
            picb_SanPham.Image = null;
            dataGridView.Enabled = false;
            cb_TenHang.Enabled = false;
            txt_SoLuong.Enabled = false;
            sp_dat.Clear();
            rdo_ATM.Checked = false;
            rdo_Khac.Checked = false;
            rdo_TienMat.Checked = false;
            txt_Khac.Clear();
            MessageBox.Show("Hóa đơn đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSanPham1(sp_dat);
            LoadTong_Sl();
        }

        

        private void btn_XoaHD_Click(object sender, EventArgs e)
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
                SanPham sanPham1 = sanPhams.FirstOrDefault(t => t.TEN_SP == tensp);
                sanPham1.SOLUONG_SP += sanPhamToDelete.SOLUONG_SP;
                LoadSanPham(sanPhams);

                sp_dat.Remove(sanPhamToDelete);

                LoadSanPham1(sp_dat);

                MessageBox.Show($"Sản phẩm {tensp} đã được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTong_Sl();
        }

        private void btn_SuaHD_Click(object sender, EventArgs e)
        {
            string tensp = cb_TenHang.Text;
            if (string.IsNullOrEmpty(tensp))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r;
            r = MessageBox.Show($"Bạn có muốn sửa sản phẩm {tensp} với số lượng mới là: {txt_SoLuong.Text}?",
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

            SanPham sanPhamToUpdate = sp_dat.FirstOrDefault(sp => sp.TEN_SP == tensp);
            if (sanPhamToUpdate == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại trong danh sách đặt hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SanPham sanPham1 = sanPhams.FirstOrDefault(t => t.TEN_SP == tensp);
            if (sanPham1 == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sl == 0)
            {
                sanPham1.SOLUONG_SP += sanPhamToUpdate.SOLUONG_SP; 
                sp_dat.Remove(sanPhamToUpdate);             
                MessageBox.Show($"Sản phẩm {tensp} đã được xóa khỏi danh sách đặt hàng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                int chenhLech = sl - sanPhamToUpdate.SOLUONG_SP;

                if (sanPham1.SOLUONG_SP +sanPhamToUpdate.SOLUONG_SP < sl)
                {
                    MessageBox.Show("Số lượng trong kho không đủ để sửa đổi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sanPham1.SOLUONG_SP -= chenhLech; 
                sanPhamToUpdate.SOLUONG_SP = sl; 
                MessageBox.Show($"Sản phẩm {tensp} đã được cập nhật số lượng thành {sl}!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadSanPham(sanPhams);
            LoadSanPham1(sp_dat);
            LoadTong_Sl();
        }


        private void btn_ThemHD_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu số lượng
            if (string.IsNullOrEmpty(txt_SoLuong.Text))
            {
                MessageBox.Show("Phải nhập số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_SoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Phải nhập số lượng là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra sản phẩm có tồn tại trong danh sách gốc
            SanPham sanPham1 = sanPhams.FirstOrDefault(t => t.TEN_SP == cb_TenHang.Text);
            if (sanPham1 == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soLuong > sanPham1.SOLUONG_SP)
            {
                MessageBox.Show("Không đủ số lượng để mua!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận
            DialogResult r = MessageBox.Show($"Bạn có muốn thêm SP: {cb_TenHang.Text} với SL: {txt_SoLuong.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                return;
            }

            SanPham sanPham = sp_dat.FirstOrDefault(sp => sp.TEN_SP == cb_TenHang.Text);
            if (sanPham != null)
            {
                sanPham.SOLUONG_SP += soLuong;
            }
            else
            {
                sanPham = new SanPham
                {
                    MA_SP=sanPham1.MA_SP,
                    TEN_SP = sanPham1.TEN_SP,
                    SOLUONG_SP = soLuong,
                    GIA_BAN = sanPham1.GIA_BAN,
                    TGBAOHANH = sanPham1.TGBAOHANH
                };
                sp_dat.Add(sanPham);
            }

            sanPham1.SOLUONG_SP -= soLuong;

            LoadSanPham1(sp_dat);
            LoadSanPham(sanPhams); 
            LoadTong_Sl();
        }
        private void rdo_Khac_CheckedChanged(object sender, EventArgs e)
        {
            txt_Khac.Enabled = true;
        }

        private void rdo_TienMat_CheckedChanged(object sender, EventArgs e)
        {
            txt_Khac.Enabled = false;
            txt_Khac.Clear();
        }

        private void rdo_ATM_CheckedChanged(object sender, EventArgs e)
        {
            txt_Khac.Enabled = false;
            txt_Khac.Clear();
        }

        private void btn_InHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaHD2.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<HoaDonXuat> hoadon = new List<HoaDonXuat>();
            hoadon.Add(new HoaDonXuat {
                MAHD_XUAT = hoaDon.MaHD, 
                SDT_KH = hoaDon.SDT_KH,
                MA_NV = hoaDon.Ma_NV, 
                TONGBILL_XUAT = tong_bill, 
                NGAYXUAT = hoaDon.Ngay });
            List<CTHDXuat> cTHDNhaps = new List<CTHDXuat>();

            foreach (var sp in sp_dat)
            {
                cTHDNhaps.Add(new CTHDXuat
                {
                    MAHD_XUAT = hoaDon.MaHD,
                    MA_SP = sp.MA_SP,
                    SL_SANPHAM = sp.SOLUONG_SP,
                    GIA_SP = sp.GIA_NHAP
                });
            }
            Report_HoaDon report_hoadon = new Report_HoaDon(hoadon, cTHDNhaps);
            report_hoadon.Show();
        }

        private void txt_MaHD2_TextChanged(object sender, EventArgs e)
        {
            if (txt_MaHD2 == null || txt_MaHD2.Text == "" || txt_MaHD2.Text == null)
            {
                btn_ThemHD.Enabled = false;
                btn_SuaHD.Enabled = false;
                btn_XoaHD.Enabled = false;
            }
            else
            {
                btn_ThemHD.Enabled = true;
                btn_SuaHD.Enabled = true;
                btn_XoaHD.Enabled = true;
            }
        }
    }
}
