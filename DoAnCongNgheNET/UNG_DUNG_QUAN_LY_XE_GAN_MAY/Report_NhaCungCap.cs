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
    public partial class Report_NhaCungCap : Form
    {

        private void Report_NhaCungCap_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public Report_NhaCungCap(List<NhaCungCap> danhSachNhaCungCap)
        {
            InitializeComponent();
            LoadDataIntoReport(danhSachNhaCungCap);
        }

        private void LoadDataIntoReport(List<NhaCungCap> danhSachNhaCungCap)
        {
            // Xóa dữ liệu cũ (nếu có)
            this.reportViewer1.LocalReport.DataSources.Clear();

            // Tạo một ReportDataSource từ danh sách 
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", danhSachNhaCungCap);

            // Thêm ReportDataSource vào ReportViewer
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Thiết lập đường dẫn RDLC (nếu chưa thiết lập)
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportPath = System.IO.Path.Combine(projectDirectory, @"..\..\Report_NhaCungCap.rdlc");

            // Làm mới ReportViewer
            this.reportViewer1.RefreshReport();
        }
    }
}
