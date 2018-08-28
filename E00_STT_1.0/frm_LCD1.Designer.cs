namespace E00_STT
{
    partial class frm_LCD1
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
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chọnPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CntMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // CntMain
            // 
            this.CntMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem,
            this.chọnPhòngToolStripMenuItem});
            this.CntMain.Name = "CntMain";
            this.CntMain.Size = new System.Drawing.Size(142, 48);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // chọnPhòngToolStripMenuItem
            // 
            this.chọnPhòngToolStripMenuItem.Name = "chọnPhòngToolStripMenuItem";
            this.chọnPhòngToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.chọnPhòngToolStripMenuItem.Text = "Chọn Phòng";
            this.chọnPhòngToolStripMenuItem.Click += new System.EventHandler(this.chọnPhòngToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // frm_LCD1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 510);
            this.ContextMenuStrip = this.CntMain;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_LCD1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_LCD";
            this.Load += new System.EventHandler(this.frm_LCD_Load);
            this.Resize += new System.EventHandler(this.frm_LCD1_Resize);
            this.CntMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CntMain;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chọnPhòngToolStripMenuItem;
        public System.Windows.Forms.Timer timer1;
    }
}