namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    partial class frm_LoadApp
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
            this.pn_load2 = new System.Windows.Forms.Panel();
            this.picb_bgr = new System.Windows.Forms.PictureBox();
            this.time_load = new System.Windows.Forms.Timer(this.components);
            this.pn_Load1 = new System.Windows.Forms.Panel();
            this.lb_Load = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picb_bgr)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_load2
            // 
            this.pn_load2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_load2.Location = new System.Drawing.Point(0, 286);
            this.pn_load2.Name = "pn_load2";
            this.pn_load2.Size = new System.Drawing.Size(636, 29);
            this.pn_load2.TabIndex = 2;
            // 
            // picb_bgr
            // 
            this.picb_bgr.Image = global::UNG_DUNG_QUAN_LY_XE_GAN_MAY.Properties.Resources.background;
            this.picb_bgr.Location = new System.Drawing.Point(231, 29);
            this.picb_bgr.Name = "picb_bgr";
            this.picb_bgr.Size = new System.Drawing.Size(163, 119);
            this.picb_bgr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picb_bgr.TabIndex = 3;
            this.picb_bgr.TabStop = false;
            // 
            // time_load
            // 
            this.time_load.Enabled = true;
            this.time_load.Interval = 20;
            this.time_load.Tick += new System.EventHandler(this.time_load_Tick);
            // 
            // pn_Load1
            // 
            this.pn_Load1.BackColor = System.Drawing.Color.SkyBlue;
            this.pn_Load1.Location = new System.Drawing.Point(0, 286);
            this.pn_Load1.Name = "pn_Load1";
            this.pn_Load1.Size = new System.Drawing.Size(42, 31);
            this.pn_Load1.TabIndex = 4;
            // 
            // lb_Load
            // 
            this.lb_Load.AutoSize = true;
            this.lb_Load.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Load.ForeColor = System.Drawing.Color.MediumBlue;
            this.lb_Load.Location = new System.Drawing.Point(48, 190);
            this.lb_Load.Name = "lb_Load";
            this.lb_Load.Size = new System.Drawing.Size(527, 36);
            this.lb_Load.TabIndex = 5;
            this.lb_Load.Text = "ỨNG DỤNG QUẢN LÝ XE GẮN MÁY";
            // 
            // frm_LoadApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 315);
            this.Controls.Add(this.lb_Load);
            this.Controls.Add(this.pn_Load1);
            this.Controls.Add(this.picb_bgr);
            this.Controls.Add(this.pn_load2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_LoadApp";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_LoadApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picb_bgr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pn_load2;
        private System.Windows.Forms.PictureBox picb_bgr;
        private System.Windows.Forms.Timer time_load;
        private System.Windows.Forms.Panel pn_Load1;
        private System.Windows.Forms.Label lb_Load;
    }
}

