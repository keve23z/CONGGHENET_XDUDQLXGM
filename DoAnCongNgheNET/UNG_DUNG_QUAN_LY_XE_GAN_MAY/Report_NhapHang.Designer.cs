namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    partial class Report_NhapHang
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1 = new UNG_DUNG_QUAN_LY_XE_GAN_MAY.HoaDonNhapDataSet();
            this.hDNHAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hD_NHAPTableAdapter = new UNG_DUNG_QUAN_LY_XE_GAN_MAY.DataSet1TableAdapters.HD_NHAPTableAdapter();
            this.cTHDNHAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cTHD_NHAPTableAdapter = new UNG_DUNG_QUAN_LY_XE_GAN_MAY.DataSet1TableAdapters.CTHD_NHAPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hDNHAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTHDNHAPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.hDNHAPBindingSource;
            reportDataSource2.Name = "DataSet3";
            reportDataSource2.Value = this.cTHDNHAPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UNG_DUNG_QUAN_LY_XE_GAN_MAY.Report_NhapHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hDNHAPBindingSource
            // 
            this.hDNHAPBindingSource.DataMember = "HD_NHAP";
            this.hDNHAPBindingSource.DataSource = this.dataSet1;
            // 
            // hD_NHAPTableAdapter
            // 
            this.hD_NHAPTableAdapter.ClearBeforeFill = true;
            // 
            // cTHDNHAPBindingSource
            // 
            this.cTHDNHAPBindingSource.DataMember = "CTHD_NHAP";
            this.cTHDNHAPBindingSource.DataSource = this.dataSet1;
            // 
            // cTHD_NHAPTableAdapter
            // 
            this.cTHD_NHAPTableAdapter.ClearBeforeFill = true;
            // 
            // Report_NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_NhapHang";
            this.Text = "Report_NhapHang";
            this.Load += new System.EventHandler(this.Report_NhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hDNHAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTHDNHAPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private HoaDonNhapDataSet dataSet1;
        private System.Windows.Forms.BindingSource hDNHAPBindingSource;
        private DataSet1TableAdapters.HD_NHAPTableAdapter hD_NHAPTableAdapter;
        private System.Windows.Forms.BindingSource cTHDNHAPBindingSource;
        private DataSet1TableAdapters.CTHD_NHAPTableAdapter cTHD_NHAPTableAdapter;
    }
}