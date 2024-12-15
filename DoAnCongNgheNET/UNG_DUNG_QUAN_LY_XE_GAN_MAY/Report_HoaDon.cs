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
    public partial class Report_HoaDon : Form
    {

        private void Report_HoaDon_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public Report_HoaDon(List<HoaDonXuat> hoadon, List<CTHDXuat> danhSachhoadon)
        {
            InitializeComponent();
            LoadDataIntoReport(hoadon, danhSachhoadon);
        }

        private void LoadDataIntoReport(List<HoaDonXuat> hoadon, List<CTHDXuat> danhSachhoadon)
        {
            // Xóa dữ liệu cũ (nếu có)
            this.reportViewer1.LocalReport.DataSources.Clear();

            // Tạo một ReportDataSource từ danh sách KhachHang
            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", hoadon);
            ReportDataSource reportDataSource3 = new ReportDataSource("DataSet2", danhSachhoadon);
            // Thêm ReportDataSource vào ReportViewer
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            // Thiết lập đường dẫn RDLC (nếu chưa thiết lập)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

        }
    }
}