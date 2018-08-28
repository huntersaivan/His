namespace HISQLHSBA
{
    partial class frmReportXuatBNRaVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportXuatBNRaVien));
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new DevComponents.DotNetBar.ButtonX();
            this.butKetthuc = new DevComponents.DotNetBar.ButtonX();
            this.slbKhoaPhong = new E00_ControlNew.usc_SelectBox();
            this.lblTen = new E00_Control.his_LabelX(this.components);
            this.labelX1 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX1 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX2 = new E00_Control.his_LabelX(this.components);
            this.label66 = new System.Windows.Forms.Label();
            this.slbKhoaPhong.SuspendLayout();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(233, 36);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(96, 22);
            this.den.TabIndex = 12;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(81, 36);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(96, 22);
            this.tu.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(171, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "đến ngày :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Từ ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.Location = new System.Drawing.Point(105, 63);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(77, 25);
            this.butIn.TabIndex = 60;
            this.butIn.Text = " &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butKetthuc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.Location = new System.Drawing.Point(183, 63);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(77, 25);
            this.butKetthuc.TabIndex = 59;
            this.butKetthuc.Text = "&Kết thúc";
            // 
            // slbKhoaPhong
            // 
            this.slbKhoaPhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.slbKhoaPhong.Controls.Add(this.lblTen);
            this.slbKhoaPhong.Controls.Add(this.labelX1);
            this.slbKhoaPhong.Controls.Add(this.his_LabelX1);
            this.slbKhoaPhong.Controls.Add(this.his_LabelX2);
            this.slbKhoaPhong.DataSource = null;
            this.slbKhoaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbKhoaPhong.his_AddNew = false;
            this.slbKhoaPhong.his_ColMa = null;
            this.slbKhoaPhong.his_ColTen = null;
            this.slbKhoaPhong.his_FontSize = 10F;
            this.slbKhoaPhong.his_lblText = "Mã:";
            this.slbKhoaPhong.his_lblTitle1_Bold = false;
            this.slbKhoaPhong.his_lblTitle1_text = "labelX1";
            this.slbKhoaPhong.his_lblTitle1_Visible = false;
            this.slbKhoaPhong.his_lblTitle1_Width = 0;
            this.slbKhoaPhong.his_lblVisible = false;
            this.slbKhoaPhong.his_lblWidth = 0;
            this.slbKhoaPhong.his_ShowCount = 10;
            this.slbKhoaPhong.his_TabLocation = 0;
            this.slbKhoaPhong.his_TenReadonly = false;
            this.slbKhoaPhong.his_TenVisible = true;
            this.slbKhoaPhong.his_txtWidth = 0;
            this.slbKhoaPhong.his_XoaMa = true;
            this.slbKhoaPhong.Location = new System.Drawing.Point(81, 7);
            this.slbKhoaPhong.Margin = new System.Windows.Forms.Padding(0);
            this.slbKhoaPhong.Name = "slbKhoaPhong";
            this.slbKhoaPhong.Size = new System.Drawing.Size(264, 23);
            this.slbKhoaPhong.TabIndex = 61;
            // 
            // lblTen
            // 
            this.lblTen.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTen.ForeColor = System.Drawing.Color.Black;
            this.lblTen.IsNotNull = false;
            this.lblTen.Location = new System.Drawing.Point(0, 0);
            this.lblTen.Margin = new System.Windows.Forms.Padding(4);
            this.lblTen.Name = "lblTen";
            this.lblTen.SingleLineColor = System.Drawing.Color.Black;
            this.lblTen.Size = new System.Drawing.Size(0, 23);
            this.lblTen.TabIndex = 4;
            this.lblTen.Text = "Mã:";
            this.lblTen.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblTen.Visible = false;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.IsNotNull = false;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(0, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "labelX1";
            this.labelX1.Visible = false;
            // 
            // his_LabelX1
            // 
            this.his_LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX1.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX1.IsNotNull = false;
            this.his_LabelX1.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX1.Margin = new System.Windows.Forms.Padding(4);
            this.his_LabelX1.Name = "his_LabelX1";
            this.his_LabelX1.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX1.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX1.TabIndex = 4;
            this.his_LabelX1.Text = "Mã:";
            this.his_LabelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            this.his_LabelX1.Visible = false;
            // 
            // his_LabelX2
            // 
            // 
            // 
            // 
            this.his_LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX2.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.his_LabelX2.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX2.IsNotNull = false;
            this.his_LabelX2.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX2.Name = "his_LabelX2";
            this.his_LabelX2.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX2.TabIndex = 3;
            this.his_LabelX2.Text = "his_LabelX2";
            this.his_LabelX2.Visible = false;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.Location = new System.Drawing.Point(13, 11);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(68, 13);
            this.label66.TabIndex = 62;
            this.label66.Text = "Khoa phòng:";
            // 
            // frmReportXuatBNRaVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 94);
            this.Controls.Add(this.slbKhoaPhong);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Name = "frmReportXuatBNRaVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo nhận hồ sơ";
            this.Load += new System.EventHandler(this.frmReportXuatBNRaVien_Load);
            this.slbKhoaPhong.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker den;
        private System.Windows.Forms.DateTimePicker tu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX butIn;
        private DevComponents.DotNetBar.ButtonX butKetthuc;
        private E00_ControlNew.usc_SelectBox slbKhoaPhong;
        private E00_Control.his_LabelX lblTen;
        private E00_Control.his_LabelX labelX1;
        private E00_Control.his_LabelX his_LabelX1;
        private E00_Control.his_LabelX his_LabelX2;
        private System.Windows.Forms.Label label66;
    }
}