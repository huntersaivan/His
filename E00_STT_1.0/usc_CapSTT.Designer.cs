namespace E00_STT
{
    partial class usc_CapSTT
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
            this.lblGhiChu = new DevComponents.DotNetBar.LabelX();
            this.lblKhu = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // lblGhiChu
            // 
            // 
            // 
            // 
            this.lblGhiChu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGhiChu.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblGhiChu.Location = new System.Drawing.Point(0, 50);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.PaddingLeft = 5;
            this.lblGhiChu.Size = new System.Drawing.Size(658, 30);
            this.lblGhiChu.TabIndex = 0;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // lblKhu
            // 
            // 
            // 
            // 
            this.lblKhu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKhu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhu.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblKhu.Location = new System.Drawing.Point(0, 0);
            this.lblKhu.Name = "lblKhu";
            this.lblKhu.PaddingLeft = 5;
            this.lblKhu.Size = new System.Drawing.Size(658, 50);
            this.lblKhu.TabIndex = 0;
            this.lblKhu.Text = "KHU VỰC";
            // 
            // usc_CapSTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblKhu);
            this.Controls.Add(this.lblGhiChu);
            this.Name = "usc_CapSTT";
            this.Size = new System.Drawing.Size(658, 80);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.LabelX lblGhiChu;
        public DevComponents.DotNetBar.LabelX lblKhu;

    }
}
