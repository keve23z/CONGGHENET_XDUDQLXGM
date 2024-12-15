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
    public partial class Report_NhapHang : Form
    {

        public Report_NhapHang(List<HoaDonNhap> hoadon, List<CTHDNhap> danhSachhoadon)
        {
            InitializeComponent();
            LoadDataIntoReport(hoadon,danhSachhoadon);
        }

        private void LoadDataIntoReport(List<HoaDonNhap> hoadon,List<CTHDNhap> danhSachhoadon)
        {
            // Xóa dữ liệu cũ (nếu có)
            this.reportViewer1.LocalReport.DataSources.Clear();

            // Tạo một ReportDataSource từ danh sách KhachHang
            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", hoadon);
            ReportDataSource reportDataSource3 = new ReportDataSource("DataSet3", danhSachhoadon);
            // Thêm ReportDataSource vào ReportViewer
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            // Thiết lập đường dẫn RDLC (nếu chưa thiết lập)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportPath = System.IO.Path.Combine(projectDirectory, @"..\..\Report_NhapHang.rdlc");

            // Làm mới ReportViewer
            this.reportViewer1.RefreshReport();
        }

        private void Report_NhapHang_Load(object sender, EventArgs e)
        {
            // Đảm bảo luôn làm mới khi load form
            this.reportViewer1.RefreshReport();
        }
    }
}
