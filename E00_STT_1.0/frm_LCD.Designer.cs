namespace E00_STT
{
    partial class frm_LCD
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
            this.CntMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cấuHìnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chọnPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChuyenManHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFullManHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVuaManHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.CntMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // CntMain
            // 
            this.CntMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cấuHìnhToolStripMenuItem,
            this.chọnPhòngToolStripMenuItem,
            this.btnChuyenManHinh,
            this.btnThoat});
            this.CntMain.Name = "CntMain";
            this.CntMain.Size = new System.Drawing.Size(194, 114);
            // 
            // cấuHìnhToolStripMenuItem
            // 
            this.cấuHìnhToolStripMenuItem.Name = "cấuHìnhToolStripMenuItem";
            this.cấuHìnhToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cấuHìnhToolStripMenuItem.Text = "Cấu Hình";
            this.cấuHìnhToolStripMenuItem.Click += new System.EventHandler(this.cấuHìnhToolStripMenuItem_Click);
            // 
            // chọnPhòngToolStripMenuItem
            // 
            this.chọnPhòngToolStripMenuItem.Name = "chọnPhòngToolStripMenuItem";
            this.chọnPhòngToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.chọnPhòngToolStripMenuItem.Text = "Chọn Phòng";
            this.chọnPhòngToolStripMenuItem.Click += new System.EventHandler(this.chọnPhòngToolStripMenuItem_Click);
            // 
            // btnChuyenManHinh
            // 
            this.btnChuyenManHinh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFullManHinh,
            this.btnVuaManHinh});
            this.btnChuyenManHinh.Name = "btnChuyenManHinh";
            this.btnChuyenManHinh.Size = new System.Drawing.Size(193, 22);
            this.btnChuyenManHinh.Text = "Chuyển màn hình phụ";
            // 
            // btnFullManHinh
            // 
            this.btnFullManHinh.Name = "btnFullManHinh";
            this.btnFullManHinh.Size = new System.Drawing.Size(148, 22);
            this.btnFullManHinh.Text = "Full màn hình";
            this.btnFullManHinh.Click += new System.EventHandler(this.btnFullManHinh_Click);
            // 
            // btnVuaManHinh
            // 
            this.btnVuaManHinh.Name = "btnVuaManHinh";
            this.btnVuaManHinh.Size = new System.Drawing.Size(148, 22);
            this.btnVuaManHinh.Text = "Vừa màn hình";
            this.btnVuaManHinh.Click += new System.EventHandler(this.btnVuaManHinh_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(193, 22);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frm_LCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 510);
            this.ContextMenuStrip = this.CntMain;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_LCD";
            this.Text = "frm_LCD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_LCD_FormClosing);
            this.Load += new System.EventHandler(this.frm_LCD_Load);
            this.CntMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CntMain;
        private System.Windows.Forms.ToolStripMenuItem btnChuyenManHinh;
        private System.Windows.Forms.ToolStripMenuItem cấuHìnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chọnPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnThoat;
        private System.Windows.Forms.ToolStripMenuItem btnFullManHinh;
        private System.Windows.Forms.ToolStripMenuItem btnVuaManHinh;
    }
}