namespace DatabaseV2
{
    partial class frm_TaoSoLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaoSoLieu));
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnTaoSoLieu = new DevComponents.DotNetBar.ButtonX();
            this.btnTaoDuLieuMau = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(243, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 25);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Tooltip = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTaoSoLieu
            // 
            this.btnTaoSoLieu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTaoSoLieu.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnTaoSoLieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoSoLieu.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoSoLieu.Image")));
            this.btnTaoSoLieu.Location = new System.Drawing.Point(12, 12);
            this.btnTaoSoLieu.Name = "btnTaoSoLieu";
            this.btnTaoSoLieu.Size = new System.Drawing.Size(84, 25);
            this.btnTaoSoLieu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTaoSoLieu.TabIndex = 14;
            this.btnTaoSoLieu.Text = "Tạo cấu trúc";
            this.btnTaoSoLieu.Tooltip = "Tạo số liệu";
            this.btnTaoSoLieu.Click += new System.EventHandler(this.btnTaoSoLieu_Click);
            // 
            // btnTaoDuLieuMau
            // 
            this.btnTaoDuLieuMau.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTaoDuLieuMau.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnTaoDuLieuMau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoDuLieuMau.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoDuLieuMau.Image")));
            this.btnTaoDuLieuMau.Location = new System.Drawing.Point(118, 12);
            this.btnTaoDuLieuMau.Name = "btnTaoDuLieuMau";
            this.btnTaoDuLieuMau.Size = new System.Drawing.Size(103, 25);
            this.btnTaoDuLieuMau.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTaoDuLieuMau.TabIndex = 14;
            this.btnTaoDuLieuMau.Text = "Tạo dữ liệu mẫu";
            this.btnTaoDuLieuMau.Tooltip = "Tạo số liệu";
            this.btnTaoDuLieuMau.Click += new System.EventHandler(this.btnTaoDuLieuMau_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.buttonX1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX1.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
            this.buttonX1.Location = new System.Drawing.Point(3, 66);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(137, 25);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 14;
            this.buttonX1.Text = "Tạo cấu trúc SQL ";
            this.buttonX1.Tooltip = "Tạo số liệu";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frm_TaoSoLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 39);
            this.Controls.Add(this.btnTaoDuLieuMau);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnTaoSoLieu);
            this.Controls.Add(this.btnThoat);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "frm_TaoSoLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo số liệu";
            this.Load += new System.EventHandler(this.frm_TaoSoLieu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX btnThoat;
        public DevComponents.DotNetBar.ButtonX btnTaoSoLieu;
        public DevComponents.DotNetBar.ButtonX btnTaoDuLieuMau;
        public DevComponents.DotNetBar.ButtonX buttonX1;


    }
}