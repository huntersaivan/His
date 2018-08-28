namespace E00_STT
{
    partial class frm_ChonLCD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChonLCD));
            this.slbLCD = new E00_ControlNew.usc_SelectBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkVuaManHinh = new System.Windows.Forms.CheckBox();
            this.btnThoat = new E00_Control.his_ButtonX2();
            this.btnChon = new E00_Control.his_ButtonX2();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // slbLCD
            // 
            this.slbLCD.DataSource = null;
            this.slbLCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbLCD.his_AddNew = false;
            this.slbLCD.his_ColMa = null;
            this.slbLCD.his_ColTen = null;
            this.slbLCD.his_FontSize = 10F;
            this.slbLCD.his_lblText = "Mã:";
            this.slbLCD.his_lblTitle1_Bold = false;
            this.slbLCD.his_lblTitle1_text = "labelX1";
            this.slbLCD.his_lblTitle1_Visible = false;
            this.slbLCD.his_lblTitle1_Width = 0;
            this.slbLCD.his_lblVisible = false;
            this.slbLCD.his_lblWidth = 0;
            this.slbLCD.his_ShowCount = 10;
            this.slbLCD.his_TabLocation = 0;
            this.slbLCD.his_TenReadonly = false;
            this.slbLCD.his_TenReadOnly = false;
            this.slbLCD.his_TenVisible = true;
            this.slbLCD.his_txtWidth = 0;
            this.slbLCD.his_XoaMa = true;
            this.slbLCD.Location = new System.Drawing.Point(20, 28);
            this.slbLCD.Margin = new System.Windows.Forms.Padding(0);
            this.slbLCD.Name = "slbLCD";
            this.slbLCD.Size = new System.Drawing.Size(275, 23);
            this.slbLCD.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkVuaManHinh);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnChon);
            this.groupBox1.Controls.Add(this.slbLCD);
            this.groupBox1.Location = new System.Drawing.Point(3, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(307, 142);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn LCD";
            // 
            // chkVuaManHinh
            // 
            this.chkVuaManHinh.AutoSize = true;
            this.chkVuaManHinh.Location = new System.Drawing.Point(20, 58);
            this.chkVuaManHinh.Name = "chkVuaManHinh";
            this.chkVuaManHinh.Size = new System.Drawing.Size(107, 20);
            this.chkVuaManHinh.TabIndex = 2;
            this.chkVuaManHinh.Text = "Vừa màn hình";
            this.chkVuaManHinh.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(212, 94);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(85, 29);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnChon
            // 
            this.btnChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChon.Image = ((System.Drawing.Image)(resources.GetObject("btnChon.Image")));
            this.btnChon.Location = new System.Drawing.Point(120, 94);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(86, 29);
            this.btnChon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChon.TabIndex = 1;
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // frm_ChonLCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(323, 161);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChonLCD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn LCD";
            this.Load += new System.EventHandler(this.frm_ChonLCD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private E00_ControlNew.usc_SelectBox slbLCD;
        private System.Windows.Forms.GroupBox groupBox1;
        private E00_Control.his_ButtonX2 btnThoat;
        private E00_Control.his_ButtonX2 btnChon;
        private System.Windows.Forms.CheckBox chkVuaManHinh;
    }
}