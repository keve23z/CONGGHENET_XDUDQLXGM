namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    partial class User_NhapHang
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_NhapHang = new System.Windows.Forms.Label();
            this.grb_PhieuNhap = new System.Windows.Forms.GroupBox();
            this.dt_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.cb_NCC = new System.Windows.Forms.ComboBox();
            this.lb_NCC = new System.Windows.Forms.Label();
            this.btn_TaoPN = new System.Windows.Forms.Button();
            this.lb_MaHD1 = new System.Windows.Forms.Label();
            this.txt_MaHD1 = new System.Windows.Forms.TextBox();
            this.lb_NgayNhap = new System.Windows.Forms.Label();
            this.grb_CTNH = new System.Windows.Forms.GroupBox();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.cb_TenHang = new System.Windows.Forms.ComboBox();
            this.lb_MaHD2 = new System.Windows.Forms.Label();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.lb_TenHang = new System.Windows.Forms.Label();
            this.lb_SoLuong = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.txt_GiaNhap = new System.Windows.Forms.TextBox();
            this.txt_MaHD2 = new System.Windows.Forms.TextBox();
            this.lb_GiaNhap = new System.Windows.Forms.Label();
            this.grb_DSSP = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.grb_DSSPDD = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.picb_SanPham = new System.Windows.Forms.PictureBox();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_In = new System.Windows.Forms.Button();
            this.lb_ThongTT2 = new System.Windows.Forms.Label();
            this.lb_TongSL1 = new System.Windows.Forms.Label();
            this.lb_ThongTT1 = new System.Windows.Forms.Label();
            this.lb_TongSL2 = new System.Windows.Forms.Label();
            this.grb_PhieuNhap.SuspendLayout();
            this.grb_CTNH.SuspendLayout();
            this.grb_DSSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.grb_DSSPDD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb_SanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_NhapHang
            // 
            this.lb_NhapHang.AutoSize = true;
            this.lb_NhapHang.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NhapHang.ForeColor = System.Drawing.Color.MediumBlue;
            this.lb_NhapHang.Location = new System.Drawing.Point(429, 14);
            this.lb_NhapHang.Name = "lb_NhapHang";
            this.lb_NhapHang.Size = new System.Drawing.Size(200, 36);
            this.lb_NhapHang.TabIndex = 8;
            this.lb_NhapHang.Text = "NHẬP HÀNG";
            // 
            // grb_PhieuNhap
            // 
            this.grb_PhieuNhap.BackColor = System.Drawing.Color.LightBlue;
            this.grb_PhieuNhap.Controls.Add(this.dt_NgayNhap);
            this.grb_PhieuNhap.Controls.Add(this.cb_NCC);
            this.grb_PhieuNhap.Controls.Add(this.lb_NCC);
            this.grb_PhieuNhap.Controls.Add(this.btn_TaoPN);
            this.grb_PhieuNhap.Controls.Add(this.lb_MaHD1);
            this.grb_PhieuNhap.Controls.Add(this.txt_MaHD1);
            this.grb_PhieuNhap.Controls.Add(this.lb_NgayNhap);
            this.grb_PhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_PhieuNhap.ForeColor = System.Drawing.Color.DarkBlue;
            this.grb_PhieuNhap.Location = new System.Drawing.Point(24, 64);
            this.grb_PhieuNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_PhieuNhap.Name = "grb_PhieuNhap";
            this.grb_PhieuNhap.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_PhieuNhap.Size = new System.Drawing.Size(1061, 156);
            this.grb_PhieuNhap.TabIndex = 16;
            this.grb_PhieuNhap.TabStop = false;
            this.grb_PhieuNhap.Text = "Phiếu nhập";
            // 
            // dt_NgayNhap
            // 
            this.dt_NgayNhap.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dt_NgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dt_NgayNhap.Enabled = false;
            this.dt_NgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_NgayNhap.Location = new System.Drawing.Point(573, 34);
            this.dt_NgayNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt_NgayNhap.Name = "dt_NgayNhap";
            this.dt_NgayNhap.Size = new System.Drawing.Size(223, 27);
            this.dt_NgayNhap.TabIndex = 26;
            // 
            // cb_NCC
            // 
            this.cb_NCC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_NCC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_NCC.FormattingEnabled = true;
            this.cb_NCC.Location = new System.Drawing.Point(423, 90);
            this.cb_NCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_NCC.Name = "cb_NCC";
            this.cb_NCC.Size = new System.Drawing.Size(225, 28);
            this.cb_NCC.TabIndex = 25;
            // 
            // lb_NCC
            // 
            this.lb_NCC.AutoSize = true;
            this.lb_NCC.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NCC.Location = new System.Drawing.Point(277, 97);
            this.lb_NCC.Name = "lb_NCC";
            this.lb_NCC.Size = new System.Drawing.Size(130, 21);
            this.lb_NCC.TabIndex = 19;
            this.lb_NCC.Text = "Nhà Cung Cấp";
            // 
            // btn_TaoPN
            // 
            this.btn_TaoPN.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_TaoPN.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaoPN.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_TaoPN.Image = global::UNG_DUNG_QUAN_LY_XE_GAN_MAY.Properties.Resources.Download_from_the_Cloud_1;
            this.btn_TaoPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TaoPN.Location = new System.Drawing.Point(856, 34);
            this.btn_TaoPN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_TaoPN.Name = "btn_TaoPN";
            this.btn_TaoPN.Size = new System.Drawing.Size(167, 71);
            this.btn_TaoPN.TabIndex = 14;
            this.btn_TaoPN.Text = "Tạo Hoá Đơn";
            this.btn_TaoPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TaoPN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_TaoPN.UseVisualStyleBackColor = false;
            this.btn_TaoPN.Click += new System.EventHandler(this.btn_TaoPN_Click);
            // 
            // lb_MaHD1
            // 
            this.lb_MaHD1.AutoSize = true;
            this.lb_MaHD1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaHD1.Location = new System.Drawing.Point(32, 34);
            this.lb_MaHD1.Name = "lb_MaHD1";
            this.lb_MaHD1.Size = new System.Drawing.Size(114, 21);
            this.lb_MaHD1.TabIndex = 11;
            this.lb_MaHD1.Text = "Mã Hoá Đơn";
            // 
            // txt_MaHD1
            // 
            this.txt_MaHD1.Enabled = false;
            this.txt_MaHD1.Location = new System.Drawing.Point(171, 32);
            this.txt_MaHD1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_MaHD1.Name = "txt_MaHD1";
            this.txt_MaHD1.Size = new System.Drawing.Size(193, 27);
            this.txt_MaHD1.TabIndex = 27;
            // 
            // lb_NgayNhap
            // 
            this.lb_NgayNhap.AutoSize = true;
            this.lb_NgayNhap.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgayNhap.Location = new System.Drawing.Point(447, 34);
            this.lb_NgayNhap.Name = "lb_NgayNhap";
            this.lb_NgayNhap.Size = new System.Drawing.Size(104, 21);
            this.lb_NgayNhap.TabIndex = 10;
            this.lb_NgayNhap.Text = "Ngày Nhập";
            // 
            // grb_CTNH
            // 
            this.grb_CTNH.BackColor = System.Drawing.Color.LightBlue;
            this.grb_CTNH.Controls.Add(this.btn_Sua);
            this.grb_CTNH.Controls.Add(this.btn_Xoa);
            this.grb_CTNH.Controls.Add(this.cb_TenHang);
            this.grb_CTNH.Controls.Add(this.lb_MaHD2);
            this.grb_CTNH.Controls.Add(this.txt_SoLuong);
            this.grb_CTNH.Controls.Add(this.lb_TenHang);
            this.grb_CTNH.Controls.Add(this.lb_SoLuong);
            this.grb_CTNH.Controls.Add(this.btn_Them);
            this.grb_CTNH.Controls.Add(this.txt_GiaNhap);
            this.grb_CTNH.Controls.Add(this.txt_MaHD2);
            this.grb_CTNH.Controls.Add(this.lb_GiaNhap);
            this.grb_CTNH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_CTNH.ForeColor = System.Drawing.Color.DarkBlue;
            this.grb_CTNH.Location = new System.Drawing.Point(24, 244);
            this.grb_CTNH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_CTNH.Name = "grb_CTNH";
            this.grb_CTNH.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_CTNH.Size = new System.Drawing.Size(1061, 185);
            this.grb_CTNH.TabIndex = 22;
            this.grb_CTNH.TabStop = false;
            this.grb_CTNH.Text = "Chi Tiết Nhập Hàng";
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_Sua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(877, 110);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(109, 39);
            this.btn_Sua.TabIndex = 30;
            this.btn_Sua.Text = "SỬA";
            this.btn_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(933, 50);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(109, 39);
            this.btn_Xoa.TabIndex = 29;
            this.btn_Xoa.Text = "XOÁ";
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // cb_TenHang
            // 
            this.cb_TenHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_TenHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TenHang.FormattingEnabled = true;
            this.cb_TenHang.Location = new System.Drawing.Point(505, 50);
            this.cb_TenHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_TenHang.Name = "cb_TenHang";
            this.cb_TenHang.Size = new System.Drawing.Size(265, 28);
            this.cb_TenHang.TabIndex = 28;
            this.cb_TenHang.SelectedIndexChanged += new System.EventHandler(this.cb_TenHang_SelectedIndexChanged);
            // 
            // lb_MaHD2
            // 
            this.lb_MaHD2.AutoSize = true;
            this.lb_MaHD2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaHD2.Location = new System.Drawing.Point(5, 53);
            this.lb_MaHD2.Name = "lb_MaHD2";
            this.lb_MaHD2.Size = new System.Drawing.Size(114, 21);
            this.lb_MaHD2.TabIndex = 27;
            this.lb_MaHD2.Text = "Mã Hoá Đơn";
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoLuong.Location = new System.Drawing.Point(505, 118);
            this.txt_SoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(265, 27);
            this.txt_SoLuong.TabIndex = 21;
            // 
            // lb_TenHang
            // 
            this.lb_TenHang.AutoSize = true;
            this.lb_TenHang.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenHang.Location = new System.Drawing.Point(393, 58);
            this.lb_TenHang.Name = "lb_TenHang";
            this.lb_TenHang.Size = new System.Drawing.Size(91, 21);
            this.lb_TenHang.TabIndex = 19;
            this.lb_TenHang.Text = "Tên Hàng";
            // 
            // lb_SoLuong
            // 
            this.lb_SoLuong.AutoSize = true;
            this.lb_SoLuong.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SoLuong.Location = new System.Drawing.Point(393, 118);
            this.lb_SoLuong.Name = "lb_SoLuong";
            this.lb_SoLuong.Size = new System.Drawing.Size(92, 21);
            this.lb_SoLuong.TabIndex = 18;
            this.lb_SoLuong.Text = "Số Lượng";
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_Them.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(808, 50);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(109, 39);
            this.btn_Them.TabIndex = 14;
            this.btn_Them.Text = "THÊM";
            this.btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // txt_GiaNhap
            // 
            this.txt_GiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GiaNhap.Location = new System.Drawing.Point(141, 118);
            this.txt_GiaNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_GiaNhap.Name = "txt_GiaNhap";
            this.txt_GiaNhap.Size = new System.Drawing.Size(223, 27);
            this.txt_GiaNhap.TabIndex = 13;
            // 
            // txt_MaHD2
            // 
            this.txt_MaHD2.Enabled = false;
            this.txt_MaHD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaHD2.Location = new System.Drawing.Point(141, 53);
            this.txt_MaHD2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_MaHD2.Name = "txt_MaHD2";
            this.txt_MaHD2.Size = new System.Drawing.Size(223, 27);
            this.txt_MaHD2.TabIndex = 12;
            this.txt_MaHD2.TextChanged += new System.EventHandler(this.txt_MaHD2_TextChanged);
            // 
            // lb_GiaNhap
            // 
            this.lb_GiaNhap.AutoSize = true;
            this.lb_GiaNhap.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_GiaNhap.Location = new System.Drawing.Point(5, 121);
            this.lb_GiaNhap.Name = "lb_GiaNhap";
            this.lb_GiaNhap.Size = new System.Drawing.Size(88, 21);
            this.lb_GiaNhap.TabIndex = 10;
            this.lb_GiaNhap.Text = "Giá Nhập";
            // 
            // grb_DSSP
            // 
            this.grb_DSSP.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grb_DSSP.BackColor = System.Drawing.Color.LightBlue;
            this.grb_DSSP.Controls.Add(this.dataGridView);
            this.grb_DSSP.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_DSSP.ForeColor = System.Drawing.Color.SteelBlue;
            this.grb_DSSP.Location = new System.Drawing.Point(24, 448);
            this.grb_DSSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_DSSP.Name = "grb_DSSP";
            this.grb_DSSP.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_DSSP.Size = new System.Drawing.Size(408, 287);
            this.grb_DSSP.TabIndex = 23;
            this.grb_DSSP.TabStop = false;
            this.grb_DSSP.Text = "DANH SÁCH SẢN PHẨM TỒN";
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Enabled = false;
            this.dataGridView.Location = new System.Drawing.Point(12, 31);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(379, 240);
            this.dataGridView.TabIndex = 31;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // grb_DSSPDD
            // 
            this.grb_DSSPDD.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grb_DSSPDD.BackColor = System.Drawing.Color.LightBlue;
            this.grb_DSSPDD.Controls.Add(this.dataGridView1);
            this.grb_DSSPDD.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_DSSPDD.ForeColor = System.Drawing.Color.SteelBlue;
            this.grb_DSSPDD.Location = new System.Drawing.Point(677, 448);
            this.grb_DSSPDD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_DSSPDD.Name = "grb_DSSPDD";
            this.grb_DSSPDD.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_DSSPDD.Size = new System.Drawing.Size(408, 287);
            this.grb_DSSPDD.TabIndex = 24;
            this.grb_DSSPDD.TabStop = false;
            this.grb_DSSPDD.Text = "DANH SÁCH SẢN PHẨM ĐƠN ĐẶT";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(379, 240);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // picb_SanPham
            // 
            this.picb_SanPham.BackColor = System.Drawing.Color.LightSkyBlue;
            this.picb_SanPham.Location = new System.Drawing.Point(447, 448);
            this.picb_SanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picb_SanPham.Name = "picb_SanPham";
            this.picb_SanPham.Size = new System.Drawing.Size(219, 137);
            this.picb_SanPham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picb_SanPham.TabIndex = 23;
            this.picb_SanPham.TabStop = false;
            // 
            // btn_Luu
            // 
            this.btn_Luu.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_Luu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Luu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Luu.Location = new System.Drawing.Point(475, 606);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(155, 39);
            this.btn_Luu.TabIndex = 31;
            this.btn_Luu.Text = "LƯU";
            this.btn_Luu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Luu.UseVisualStyleBackColor = false;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_In
            // 
            this.btn_In.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_In.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_In.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_In.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_In.Location = new System.Drawing.Point(475, 667);
            this.btn_In.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(155, 39);
            this.btn_In.TabIndex = 32;
            this.btn_In.Text = "IN";
            this.btn_In.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_In.UseVisualStyleBackColor = false;
            this.btn_In.Click += new System.EventHandler(this.btn_In_Click);
            // 
            // lb_ThongTT2
            // 
            this.lb_ThongTT2.AutoSize = true;
            this.lb_ThongTT2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongTT2.ForeColor = System.Drawing.Color.Red;
            this.lb_ThongTT2.Location = new System.Drawing.Point(805, 756);
            this.lb_ThongTT2.Name = "lb_ThongTT2";
            this.lb_ThongTT2.Size = new System.Drawing.Size(24, 25);
            this.lb_ThongTT2.TabIndex = 51;
            this.lb_ThongTT2.Text = "0";
            // 
            // lb_TongSL1
            // 
            this.lb_TongSL1.AutoSize = true;
            this.lb_TongSL1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TongSL1.ForeColor = System.Drawing.Color.Red;
            this.lb_TongSL1.Location = new System.Drawing.Point(29, 756);
            this.lb_TongSL1.Name = "lb_TongSL1";
            this.lb_TongSL1.Size = new System.Drawing.Size(217, 25);
            this.lb_TongSL1.TabIndex = 49;
            this.lb_TongSL1.Text = "TỔNG SỐ LƯỢNG:";
            // 
            // lb_ThongTT1
            // 
            this.lb_ThongTT1.AutoSize = true;
            this.lb_ThongTT1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongTT1.ForeColor = System.Drawing.Color.Red;
            this.lb_ThongTT1.Location = new System.Drawing.Point(524, 756);
            this.lb_ThongTT1.Name = "lb_ThongTT1";
            this.lb_ThongTT1.Size = new System.Drawing.Size(241, 25);
            this.lb_ThongTT1.TabIndex = 48;
            this.lb_ThongTT1.Text = "TỔNG THÀNH TIỀN:";
            // 
            // lb_TongSL2
            // 
            this.lb_TongSL2.AutoSize = true;
            this.lb_TongSL2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TongSL2.ForeColor = System.Drawing.Color.Red;
            this.lb_TongSL2.Location = new System.Drawing.Point(267, 756);
            this.lb_TongSL2.Name = "lb_TongSL2";
            this.lb_TongSL2.Size = new System.Drawing.Size(24, 25);
            this.lb_TongSL2.TabIndex = 50;
            this.lb_TongSL2.Text = "0";
            // 
            // User_NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.lb_ThongTT2);
            this.Controls.Add(this.lb_TongSL1);
            this.Controls.Add(this.lb_ThongTT1);
            this.Controls.Add(this.lb_TongSL2);
            this.Controls.Add(this.btn_In);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.picb_SanPham);
            this.Controls.Add(this.grb_DSSPDD);
            this.Controls.Add(this.grb_DSSP);
            this.Controls.Add(this.grb_CTNH);
            this.Controls.Add(this.grb_PhieuNhap);
            this.Controls.Add(this.lb_NhapHang);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "User_NhapHang";
            this.Size = new System.Drawing.Size(1107, 800);
            this.Load += new System.EventHandler(this.User_NhapHang_Load);
            this.grb_PhieuNhap.ResumeLayout(false);
            this.grb_PhieuNhap.PerformLayout();
            this.grb_CTNH.ResumeLayout(false);
            this.grb_CTNH.PerformLayout();
            this.grb_DSSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.grb_DSSPDD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picb_SanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_NhapHang;
        private System.Windows.Forms.GroupBox grb_PhieuNhap;
        private System.Windows.Forms.Label lb_NCC;
        private System.Windows.Forms.Button btn_TaoPN;
        private System.Windows.Forms.Label lb_MaHD1;
        private System.Windows.Forms.TextBox txt_MaHD1;
        private System.Windows.Forms.Label lb_NgayNhap;
        private System.Windows.Forms.GroupBox grb_CTNH;
        private System.Windows.Forms.TextBox txt_SoLuong;
        private System.Windows.Forms.Label lb_TenHang;
        private System.Windows.Forms.Label lb_SoLuong;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.TextBox txt_GiaNhap;
        private System.Windows.Forms.TextBox txt_MaHD2;
        private System.Windows.Forms.Label lb_GiaNhap;
        private System.Windows.Forms.ComboBox cb_NCC;
        internal System.Windows.Forms.DateTimePicker dt_NgayNhap;
        private System.Windows.Forms.ComboBox cb_TenHang;
        private System.Windows.Forms.Label lb_MaHD2;
        private System.Windows.Forms.GroupBox grb_DSSP;
        private System.Windows.Forms.GroupBox grb_DSSPDD;
        private System.Windows.Forms.PictureBox picb_SanPham;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_In;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lb_ThongTT2;
        private System.Windows.Forms.Label lb_TongSL1;
        private System.Windows.Forms.Label lb_ThongTT1;
        private System.Windows.Forms.Label lb_TongSL2;
    }
}
