namespace E00_STT
{
    partial class frm_CauHinhLCD
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
            this.usc_CauHinh1 = new TAEditor.usc_CauHinh();
            this.SuspendLayout();
            // 
            // usc_CauHinh1
            // 
            this.usc_CauHinh1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.usc_CauHinh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usc_CauHinh1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usc_CauHinh1.Location = new System.Drawing.Point(0, 0);
            this.usc_CauHinh1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usc_CauHinh1.Name = "usc_CauHinh1";
            this.usc_CauHinh1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.usc_CauHinh1.Size = new System.Drawing.Size(1012, 448);
            this.usc_CauHinh1.TabIndex = 0;
            // 
            // frm_CauHinhLCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 448);
            this.Controls.Add(this.usc_CauHinh1);
            this.DoubleBuffered = true;
            this.Name = "frm_CauHinhLCD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình LCD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_CauHinhLCD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TAEditor.usc_CauHinh usc_CauHinh1;
    }
}