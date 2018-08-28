namespace E00_STT
{
    partial class frm_NhomKhuVuc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NhomKhuVuc));
            this.chkTamNgung = new E00_Control.his_CheckBoxX();
            this.txtTen = new E00_Control.his_TextboxX();
            this.lblTenKyHieu = new E00_Control.his_LabelX(this.components);
            this.dgvMain = new E00_Control.his_DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSua = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colXoa = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoai = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTamNgung = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.his_LabelX2 = new E00_Control.his_LabelX(this.components);
            this.txtGhiChu = new E00_Control.his_TextboxX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.slbLoai = new E00_ControlNew.usc_SelectBox();
            this.his_LabelX1 = new E00_Control.his_LabelX(this.components);
            this.pnlButton.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlControl2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            // 
            // 
            // 
            this.txtTimKiem.Border.Class = "TextBoxBorder";
            this.txtTimKiem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTimKiem.Location = new System.Drawing.Point(1370, 6);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(1577, 6);
            // 
            // btnThem
            // 
            this.btnThem.Size = new System.Drawing.Size(70, 53);
            // 
            // pnlButton
            // 
            this.pnlButton.Size = new System.Drawing.Size(1015, 55);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Location = new System.Drawing.Point(2, 96);
            this.pnlSearch.Size = new System.Drawing.Size(1015, 32);
            // 
            // lblKetQua
            // 
            // 
            // 
            // 
            this.lblKetQua.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKetQua.Location = new System.Drawing.Point(1253, 9);
            this.lblKetQua.Size = new System.Drawing.Size(111, 15);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Size = new System.Drawing.Size(70, 53);
            // 
            // btnLuu
            // 
            this.btnLuu.Size = new System.Drawing.Size(70, 53);
            // 
            // btnXoa
            // 
            this.btnXoa.Size = new System.Drawing.Size(70, 53);
            // 
            // btnSua
            // 
            this.btnSua.Size = new System.Drawing.Size(70, 53);
            // 
            // pnlControl2
            // 
            this.pnlControl2.Controls.Add(this.tableLayoutPanel1);
            this.pnlControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlControl2.Location = new System.Drawing.Point(2, 57);
            this.pnlControl2.Size = new System.Drawing.Size(1015, 39);
            this.pnlControl2.TabIndex = 2;
            this.pnlControl2.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkAll);
            this.pnlMain.Controls.Add(this.dgvMain);
            this.pnlMain.Location = new System.Drawing.Point(2, 128);
            this.pnlMain.Size = new System.Drawing.Size(1015, 370);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(503, 1);
            this.btnThoat.Size = new System.Drawing.Size(70, 53);
            // 
            // lblIn
            // 
            this.lblIn.Location = new System.Drawing.Point(502, 1);
            this.lblIn.Size = new System.Drawing.Size(1, 53);
            // 
            // btnTienIch
            // 
            this.btnTienIch.Location = new System.Drawing.Point(432, 1);
            this.btnTienIch.Size = new System.Drawing.Size(70, 53);
            // 
            // btnIn
            // 
            this.btnIn.Size = new System.Drawing.Size(74, 53);
            // 
            // chkTamNgung
            // 
            this.chkTamNgung.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkTamNgung.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkTamNgung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTamNgung.ForeColor = System.Drawing.Color.Black;
            this.chkTamNgung.Location = new System.Drawing.Point(918, 5);
            this.chkTamNgung.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.chkTamNgung.Name = "chkTamNgung";
            this.chkTamNgung.Size = new System.Drawing.Size(93, 26);
            this.chkTamNgung.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkTamNgung.TabIndex = 2;
            this.chkTamNgung.Text = "Tạm ngừng";
            this.chkTamNgung.TextColor = System.Drawing.Color.Black;
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTen.Border.Class = "TextBoxBorder";
            this.txtTen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen.ForeColor = System.Drawing.Color.Black;
            this.txtTen.Location = new System.Drawing.Point(124, 6);
            this.txtTen.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(255, 23);
            this.txtTen.TabIndex = 0;
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // lblTenKyHieu
            // 
            this.lblTenKyHieu.AutoSize = true;
            // 
            // 
            // 
            this.lblTenKyHieu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTenKyHieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenKyHieu.ForeColor = System.Drawing.Color.Black;
            this.lblTenKyHieu.IsNotNull = false;
            this.lblTenKyHieu.Location = new System.Drawing.Point(23, 8);
            this.lblTenKyHieu.Name = "lblTenKyHieu";
            this.lblTenKyHieu.Size = new System.Drawing.Size(96, 18);
            this.lblTenKyHieu.TabIndex = 5;
            this.lblTenKyHieu.Text = "Nhóm khu vực:<font color=\"#ED1C24\">*</font>";
            this.lblTenKyHieu.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeight = 28;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colCheck,
            this.colSua,
            this.colXoa,
            this.colMa,
            this.colTen,
            this.colLoai,
            this.colGhiChu,
            this.colTamNgung});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowHeadersWidth = 40;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1015, 370);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellValueChanged);
            this.dgvMain.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMain_DataError);
            this.dgvMain.SelectionChanged += new System.EventHandler(this.dgvMain_SelectionChanged);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "Id";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            this.colID.Width = 41;
            // 
            // colCheck
            // 
            this.colCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 32;
            // 
            // colSua
            // 
            this.colSua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSua.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.colSua.HeaderText = "";
            this.colSua.HoverImage = ((System.Drawing.Image)(resources.GetObject("colSua.HoverImage")));
            this.colSua.Image = ((System.Drawing.Image)(resources.GetObject("colSua.Image")));
            this.colSua.Name = "colSua";
            this.colSua.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSua.Text = null;
            this.colSua.ToolTipText = "Sửa";
            this.colSua.Width = 25;
            // 
            // colXoa
            // 
            this.colXoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.colXoa.HeaderText = "";
            this.colXoa.HoverImage = ((System.Drawing.Image)(resources.GetObject("colXoa.HoverImage")));
            this.colXoa.Image = ((System.Drawing.Image)(resources.GetObject("colXoa.Image")));
            this.colXoa.Name = "colXoa";
            this.colXoa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colXoa.Text = null;
            this.colXoa.ToolTipText = "Xóa dòng đang chọn";
            this.colXoa.Width = 25;
            // 
            // colMa
            // 
            this.colMa.DataPropertyName = "MA";
            this.colMa.HeaderText = "Mã";
            this.colMa.Name = "colMa";
            this.colMa.ReadOnly = true;
            this.colMa.Visible = false;
            this.colMa.Width = 47;
            // 
            // colTen
            // 
            this.colTen.DataPropertyName = "Ten";
            this.colTen.HeaderText = "Nhóm Khu Vực";
            this.colTen.MinimumWidth = 300;
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            this.colTen.Width = 300;
            // 
            // colLoai
            // 
            this.colLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLoai.DataPropertyName = "maloai";
            this.colLoai.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colLoai.HeaderText = "Loại Nhóm";
            this.colLoai.Name = "colLoai";
            this.colLoai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLoai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLoai.Width = 83;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.HeaderText = "Ghi Chú";
            this.colGhiChu.MinimumWidth = 300;
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            // 
            // colTamNgung
            // 
            this.colTamNgung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTamNgung.DataPropertyName = "TAMNGUNG";
            this.colTamNgung.FillWeight = 10F;
            this.colTamNgung.HeaderText = "Tạm Ngừng";
            this.colTamNgung.MinimumWidth = 99;
            this.colTamNgung.Name = "colTamNgung";
            this.colTamNgung.ReadOnly = true;
            this.colTamNgung.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTamNgung.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTamNgung.Width = 99;
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.chkAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAll.CheckSignSize = new System.Drawing.Size(17, 15);
            this.chkAll.Location = new System.Drawing.Point(6, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(23, 21);
            this.chkAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAll.TabIndex = 32;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // his_LabelX2
            // 
            this.his_LabelX2.AutoSize = true;
            // 
            // 
            // 
            this.his_LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.his_LabelX2.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX2.IsNotNull = false;
            this.his_LabelX2.Location = new System.Drawing.Point(602, 8);
            this.his_LabelX2.Name = "his_LabelX2";
            this.his_LabelX2.Size = new System.Drawing.Size(52, 18);
            this.his_LabelX2.TabIndex = 5;
            this.his_LabelX2.Text = "Ghi chú:";
            this.his_LabelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGhiChu.Border.Class = "TextBoxBorder";
            this.txtGhiChu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.ForeColor = System.Drawing.Color.Black;
            this.txtGhiChu.Location = new System.Drawing.Point(660, 6);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(255, 23);
            this.txtGhiChu.TabIndex = 1;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTenKyHieu, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTen, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkTamNgung, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.his_LabelX2, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1015, 36);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.slbLoai);
            this.panel1.Controls.Add(this.his_LabelX1);
            this.panel1.Location = new System.Drawing.Point(399, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 26);
            this.panel1.TabIndex = 6;
            // 
            // slbLoai
            // 
            this.slbLoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slbLoai.DataSource = null;
            this.slbLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbLoai.his_AddNew = false;
            this.slbLoai.his_ColMa = null;
            this.slbLoai.his_ColTen = null;
            this.slbLoai.his_FontSize = 10F;
            this.slbLoai.his_lblText = "Mã:";
            this.slbLoai.his_lblTitle1_Bold = false;
            this.slbLoai.his_lblTitle1_text = "labelX1";
            this.slbLoai.his_lblTitle1_Visible = false;
            this.slbLoai.his_lblTitle1_Width = 0;
            this.slbLoai.his_lblVisible = false;
            this.slbLoai.his_lblWidth = 0;
            this.slbLoai.his_ShowCount = 10;
            this.slbLoai.his_TabLocation = 0;
            this.slbLoai.his_TenReadonly = false;
            this.slbLoai.his_TenReadOnly = false;
            this.slbLoai.his_TenVisible = true;
            this.slbLoai.his_txtWidth = 0;
            this.slbLoai.his_XoaMa = true;
            this.slbLoai.Location = new System.Drawing.Point(45, 1);
            this.slbLoai.Margin = new System.Windows.Forms.Padding(0);
            this.slbLoai.Name = "slbLoai";
            this.slbLoai.Size = new System.Drawing.Size(155, 23);
            this.slbLoai.TabIndex = 8;
            // 
            // his_LabelX1
            // 
            this.his_LabelX1.AutoSize = true;
            // 
            // 
            // 
            this.his_LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX1.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX1.IsNotNull = false;
            this.his_LabelX1.Location = new System.Drawing.Point(11, 3);
            this.his_LabelX1.Name = "his_LabelX1";
            this.his_LabelX1.Size = new System.Drawing.Size(31, 18);
            this.his_LabelX1.TabIndex = 6;
            this.his_LabelX1.Text = "Loại:";
            this.his_LabelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // frm_NhomKhuVuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1019, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frm_NhomKhuVuc";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlButton.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlControl2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private E00_Control.his_CheckBoxX chkTamNgung;
        private E00_Control.his_TextboxX txtTen;
        private E00_Control.his_LabelX lblTenKyHieu;
        private E00_Control.his_DataGridView dgvMain;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAll;
        private E00_Control.his_LabelX his_LabelX2;
        private E00_Control.his_TextboxX txtGhiChu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private E00_Control.his_LabelX his_LabelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colSua;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTamNgung;
        private E00_ControlNew.usc_SelectBox slbLoai;
    }
}
