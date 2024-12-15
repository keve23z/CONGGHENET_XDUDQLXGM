using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Report_KhachHang : Form
    {
        public Report_KhachHang(List<KhachHang> danhSachKhachHang, List<HoaDon> danhSachhoadon)
        {
            InitializeComponent();
            LoadDataIntoReport(danhSachKhachHang,danhSachhoadon);
        }

        private void LoadDataIntoReport(List<KhachHang> danhSachKhachHang,List<HoaDon> danhSachhoadon)
        {
            // Xóa dữ liệu cũ (nếu có)
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Clear();

            // Tạo một ReportDataSource từ danh sách KhachHang
            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", danhSachKhachHang);
            ReportDataSource reportDataSource2 = new ReportDataSource("DataSet2", danhSachhoadon);
            // Thêm ReportDataSource vào ReportViewer
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            // Thiết lập đường dẫn RDLC (nếu chưa thiết lập)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportPath = System.IO.Path.Combine(projectDirectory, @"..\..\ReportKH.rdlc");

            // Làm mới ReportViewer
            this.reportViewer1.RefreshReport();
        }

        private void Report_KhachHang_Load(object sender, EventArgs e)
        {
            // Đảm bảo luôn làm mới khi load form
            this.reportViewer1.RefreshReport();
        }
    }
}
