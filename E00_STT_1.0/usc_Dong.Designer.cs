namespace E00_STT
{
    partial class usc_Dong
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
            this.lblGoi = new DevComponents.DotNetBar.LabelX();
            this.lblBacSi = new DevComponents.DotNetBar.LabelX();
            this.pnlGoi = new System.Windows.Forms.Panel();
            this.pnlKhuVuc = new System.Windows.Forms.Panel();
            this.lblKhuVuc = new DevComponents.DotNetBar.LabelX();
            this.pnlCho = new System.Windows.Forms.Panel();
            this.lblCho = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlGoi.SuspendLayout();
            this.pnlKhuVuc.SuspendLayout();
            this.pnlCho.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGoi
            // 
            // 
            // 
            // 
            this.lblGoi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoi.Location = new System.Drawing.Point(0, 0);
            this.lblGoi.Name = "lblGoi";
            this.lblGoi.Size = new System.Drawing.Size(211, 87);
            this.lblGoi.TabIndex = 1;
            this.lblGoi.Text = "Vùng gọi";
            this.lblGoi.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblGoi.WordWrap = true;
            // 
            // lblBacSi
            // 
            // 
            // 
            // 
            this.lblBacSi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBacSi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBacSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBacSi.Location = new System.Drawing.Point(0, 47);
            this.lblBacSi.Name = "lblBacSi";
            this.lblBacSi.Size = new System.Drawing.Size(431, 40);
            this.lblBacSi.TabIndex = 2;
            this.lblBacSi.Text = "Bác sĩ";
            this.lblBacSi.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pnlGoi
            // 
            this.pnlGoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGoi.Controls.Add(this.lblGoi);
            this.pnlGoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGoi.Location = new System.Drawing.Point(442, 3);
            this.pnlGoi.Name = "pnlGoi";
            this.pnlGoi.Size = new System.Drawing.Size(213, 89);
            this.pnlGoi.TabIndex = 4;
            // 
            // pnlKhuVuc
            // 
            this.pnlKhuVuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKhuVuc.Controls.Add(this.lblKhuVuc);
            this.pnlKhuVuc.Controls.Add(this.lblBacSi);
            this.pnlKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKhuVuc.Location = new System.Drawing.Point(3, 3);
            this.pnlKhuVuc.Name = "pnlKhuVuc";
            this.pnlKhuVuc.Size = new System.Drawing.Size(433, 89);
            this.pnlKhuVuc.TabIndex = 4;
            // 
            // lblKhuVuc
            // 
            // 
            // 
            // 
            this.lblKhuVuc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(431, 47);
            this.lblKhuVuc.TabIndex = 3;
            this.lblKhuVuc.Text = "Khu vực";
            this.lblKhuVuc.TextChanged += new System.EventHandler(this.lblKhuVuc_TextChanged);
            // 
            // pnlCho
            // 
            this.pnlCho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCho.Controls.Add(this.lblCho);
            this.pnlCho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCho.Location = new System.Drawing.Point(661, 3);
            this.pnlCho.Name = "pnlCho";
            this.pnlCho.Size = new System.Drawing.Size(215, 89);
            this.pnlCho.TabIndex = 5;
            // 
            // lblCho
            // 
            // 
            // 
            // 
            this.lblCho.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCho.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCho.Location = new System.Drawing.Point(0, 0);
            this.lblCho.Name = "lblCho";
            this.lblCho.Size = new System.Drawing.Size(213, 87);
            this.lblCho.TabIndex = 4;
            this.lblCho.Text = "Vùng chờ";
            this.lblCho.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pnlKhuVuc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCho, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlGoi, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(879, 95);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // usc_Dong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "usc_Dong";
            this.Size = new System.Drawing.Size(879, 95);
            this.pnlGoi.ResumeLayout(false);
            this.pnlKhuVuc.ResumeLayout(false);
            this.pnlCho.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.LabelX lblGoi;
        public DevComponents.DotNetBar.LabelX lblBacSi;
        public System.Windows.Forms.Panel pnlGoi;
        public System.Windows.Forms.Panel pnlKhuVuc;
        public System.Windows.Forms.Panel pnlCho;
        public DevComponents.DotNetBar.LabelX lblCho;
        public DevComponents.DotNetBar.LabelX lblKhuVuc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer timer1;

    }
}
