using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Report_NhanVien : Form
    {

        public Report_NhanVien(List<NhanVien> danhSachNhanVien)
        {
            InitializeComponent();
            LoadDataIntoReport(danhSachNhanVien);
        }

        private void LoadDataIntoReport(List<NhanVien> danhSachNhanVien)
        {
            // Xóa dữ liệu cũ (nếu có)
            this.reportViewer1.LocalReport.DataSources.Clear();

            // Tạo một ReportDataSource từ danh sách KhachHang
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", danhSachNhanVien);

            // Thêm ReportDataSource vào ReportViewer
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Thiết lập đường dẫn RDLC (nếu chưa thiết lập)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportPath = System.IO.Path.Combine(projectDirectory, @"..\..\Report_NhanVien.rdlc");

            // Làm mới ReportViewer
            this.reportViewer1.RefreshReport();
        }

        private void Report_NhanVien_Load(object sender, EventArgs e)
        {
            // Đảm bảo luôn làm mới khi load form
            this.reportViewer1.RefreshReport();
        }

    }
}
