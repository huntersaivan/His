namespace E00_STT
{
    partial class frmTesst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTesst));
            this.btnBoQua = new DevComponents.DotNetBar.ButtonX();
            this.btnDongY = new DevComponents.DotNetBar.ButtonX();
            this.his_Slider1 = new E00_Control.his_Slider();
            this.usc_SelectBox1 = new E00_ControlNew.usc_SelectBox();
            this.SuspendLayout();
            // 
            // btnBoQua
            // 
            this.btnBoQua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBoQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoQua.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnBoQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoQua.Image")));
            this.btnBoQua.ImageFixedSize = new System.Drawing.Size(13, 13);
            this.btnBoQua.Location = new System.Drawing.Point(194, 158);
            this.btnBoQua.Margin = new System.Windows.Forms.Padding(4);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(90, 29);
            this.btnBoQua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBoQua.TabIndex = 10;
            this.btnBoQua.Text = "Bỏ qua";
            // 
            // btnDongY
            // 
            this.btnDongY.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDongY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDongY.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnDongY.Enabled = false;
            this.btnDongY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongY.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.Image")));
            this.btnDongY.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnDongY.Location = new System.Drawing.Point(99, 158);
            this.btnDongY.Margin = new System.Windows.Forms.Padding(4);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(90, 29);
            this.btnDongY.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDongY.TabIndex = 9;
            this.btnDongY.Text = "Đồng ý";
            // 
            // his_Slider1
            // 
            // 
            // 
            // 
            this.his_Slider1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_Slider1.Location = new System.Drawing.Point(65, 62);
            this.his_Slider1.Name = "his_Slider1";
            this.his_Slider1.Size = new System.Drawing.Size(150, 23);
            this.his_Slider1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.his_Slider1.TabIndex = 11;
            this.his_Slider1.Text = "his_Slider1";
            this.his_Slider1.Value = 0;
            // 
            // usc_SelectBox1
            // 
            this.usc_SelectBox1.DataSource = null;
            this.usc_SelectBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usc_SelectBox1.his_AddNew = false;
            this.usc_SelectBox1.his_ColMa = null;
            this.usc_SelectBox1.his_ColTen = null;
            this.usc_SelectBox1.his_FontSize = 10F;
            this.usc_SelectBox1.his_lblText = "Mã:";
            this.usc_SelectBox1.his_lblTitle1_Bold = false;
            this.usc_SelectBox1.his_lblTitle1_text = "labelX1";
            this.usc_SelectBox1.his_lblTitle1_Visible = false;
            this.usc_SelectBox1.his_lblTitle1_Width = 0;
            this.usc_SelectBox1.his_lblVisible = false;
            this.usc_SelectBox1.his_lblWidth = 0;
            this.usc_SelectBox1.his_ShowCount = 10;
            this.usc_SelectBox1.his_TabLocation = 0;
            this.usc_SelectBox1.his_TenReadonly = false;
            this.usc_SelectBox1.his_TenVisible = true;
            this.usc_SelectBox1.his_txtWidth = 0;
            this.usc_SelectBox1.his_XoaMa = true;
            this.usc_SelectBox1.Location = new System.Drawing.Point(31, 83);
            this.usc_SelectBox1.Margin = new System.Windows.Forms.Padding(0);
            this.usc_SelectBox1.Name = "usc_SelectBox1";
            this.usc_SelectBox1.Size = new System.Drawing.Size(157, 23);
            this.usc_SelectBox1.TabIndex = 12;
            // 
            // frmTesst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.usc_SelectBox1);
            this.Controls.Add(this.his_Slider1);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnDongY);
            this.Name = "frmTesst";
            this.Text = "frmTesst";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnBoQua;
        private DevComponents.DotNetBar.ButtonX btnDongY;
        private E00_Control.his_Slider his_Slider1;
        private E00_ControlNew.usc_SelectBox usc_SelectBox1;

    }
}