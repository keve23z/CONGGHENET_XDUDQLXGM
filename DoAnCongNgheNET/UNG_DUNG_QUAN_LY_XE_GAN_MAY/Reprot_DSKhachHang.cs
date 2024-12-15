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
    public partial class Reprot_DSKhachHang : Form
    {

        private void Reprot_DSKhachHang_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public Reprot_DSKhachHang(List<KhachHang> danhSachKhachHang)
        {
            InitializeComponent();
            LoadDataIntoReport(danhSachKhachHang);
        }

        private void LoadDataIntoReport(List<KhachHang> danhSachKhachHang)
        {
            // Xóa dữ liệu cũ (nếu có)
            this.reportViewer1.LocalReport.DataSources.Clear();

            // Tạo một ReportDataSource từ danh sách KhachHang
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", danhSachKhachHang);

            // Thêm ReportDataSource vào ReportViewer
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Thiết lập đường dẫn RDLC (nếu chưa thiết lập)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportPath = System.IO.Path.Combine(projectDirectory, @"..\..\Report_DSKhachHang.rdlc");

            // Làm mới ReportViewer
            this.reportViewer1.RefreshReport();
        }

   
    }
}
