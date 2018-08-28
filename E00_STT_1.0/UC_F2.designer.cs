namespace LCDPK.uc
{
    partial class UC_F2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlVunggoi = new DevComponents.DotNetBar.PanelEx();
            this.lblVunggoi = new DevComponents.DotNetBar.LabelX();
            this.pnkKhuvuc = new DevComponents.DotNetBar.PanelEx();
            this.lblKhuvuc = new DevComponents.DotNetBar.LabelX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.pnlVunggoi.SuspendLayout();
            this.pnkKhuvuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVunggoi
            // 
            this.pnlVunggoi.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlVunggoi.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlVunggoi.Controls.Add(this.lblVunggoi);
            this.pnlVunggoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVunggoi.Location = new System.Drawing.Point(260, 0);
            this.pnlVunggoi.Name = "pnlVunggoi";
            this.pnlVunggoi.Size = new System.Drawing.Size(133, 48);
            this.pnlVunggoi.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlVunggoi.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlVunggoi.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlVunggoi.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlVunggoi.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlVunggoi.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlVunggoi.Style.GradientAngle = 90;
            this.pnlVunggoi.TabIndex = 7;
            // 
            // lblVunggoi
            // 
            // 
            // 
            // 
            this.lblVunggoi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblVunggoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVunggoi.Location = new System.Drawing.Point(0, 0);
            this.lblVunggoi.Name = "lblVunggoi";
            this.lblVunggoi.Size = new System.Drawing.Size(133, 48);
            this.lblVunggoi.TabIndex = 1;
            this.lblVunggoi.Text = "Vùng gọi";
            this.lblVunggoi.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pnkKhuvuc
            // 
            this.pnkKhuvuc.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnkKhuvuc.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnkKhuvuc.Controls.Add(this.lblKhuvuc);
            this.pnkKhuvuc.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnkKhuvuc.Location = new System.Drawing.Point(0, 0);
            this.pnkKhuvuc.Name = "pnkKhuvuc";
            this.pnkKhuvuc.Size = new System.Drawing.Size(260, 48);
            this.pnkKhuvuc.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnkKhuvuc.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnkKhuvuc.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnkKhuvuc.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnkKhuvuc.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnkKhuvuc.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnkKhuvuc.Style.GradientAngle = 90;
            this.pnkKhuvuc.TabIndex = 6;
            // 
            // lblKhuvuc
            // 
            // 
            // 
            // 
            this.lblKhuvuc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKhuvuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhuvuc.Location = new System.Drawing.Point(0, 0);
            this.lblKhuvuc.Name = "lblKhuvuc";
            this.lblKhuvuc.Size = new System.Drawing.Size(260, 48);
            this.lblKhuvuc.TabIndex = 1;
            this.lblKhuvuc.Text = "Khu vực";
            this.lblKhuvuc.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 300;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // UC_F2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnlVunggoi);
            this.Controls.Add(this.pnkKhuvuc);
            this.Name = "UC_F2";
            this.Size = new System.Drawing.Size(393, 48);
            this.Load += new System.EventHandler(this.UC_F2_Load);
            this.pnlVunggoi.ResumeLayout(false);
            this.pnkKhuvuc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlVunggoi;
        private DevComponents.DotNetBar.PanelEx pnkKhuvuc;
        private DevComponents.DotNetBar.LabelX lblKhuvuc;
        private DevComponents.DotNetBar.LabelX lblVunggoi;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;


    }
}
