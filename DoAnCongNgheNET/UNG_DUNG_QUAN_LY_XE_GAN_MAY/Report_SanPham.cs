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
    public partial class Report_SanPham : Form
    {


        private void Report_SanPham_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
  
        public Report_SanPham(List<SanPham> danhSachSanPham)
        {
            InitializeComponent();
            LoadDataIntoReport(danhSachSanPham);
        }

        private void LoadDataIntoReport(List<SanPham> danhSachSanPham)
        {
            // Xóa dữ liệu cũ (nếu có)
            this.reportViewer1.LocalReport.DataSources.Clear();

            // Tạo một ReportDataSource từ danh sách 
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", danhSachSanPham);

            // Thêm ReportDataSource vào ReportViewer
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Thiết lập đường dẫn RDLC (nếu chưa thiết lập)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportPath = System.IO.Path.Combine(projectDirectory, @"..\..\Report_SanPham.rdlc");

            // Làm mới ReportViewer
            this.reportViewer1.RefreshReport();
        }
    }
}
