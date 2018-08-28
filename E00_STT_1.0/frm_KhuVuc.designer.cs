namespace E00_STT
{
    partial class frm_KhuVuc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_KhuVuc));
            this.chkTamNgung = new E00_Control.his_CheckBoxX();
            this.lblNhom = new E00_Control.his_LabelX(this.components);
            this.dgvMain = new E00_Control.his_DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSua = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colXoa = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhom = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTamNgung = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.his_LabelX2 = new E00_Control.his_LabelX(this.components);
            this.txtGhiChu = new E00_Control.his_TextboxX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.his_LabelX1 = new E00_Control.his_LabelX(this.components);
            this.slbNhomKV = new E00_ControlNew.usc_SelectBox();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.slbTen = new E00_ControlNew.usc_SelectBox();
            this.lblTen = new E00_Control.his_LabelX(this.components);
            this.labelX1 = new E00_Control.his_LabelX(this.components);
            this.pnlButton.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlControl2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.slbTen.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            // 
            // 
            // 
            this.txtTimKiem.Border.Class = "TextBoxBorder";
            this.txtTimKiem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTimKiem.Location = new System.Drawing.Point(-2136, 3);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(-1931, 3);
            // 
            // btnThem
            // 
            this.btnThem.Size = new System.Drawing.Size(70, 53);
            // 
            // pnlButton
            // 
            this.pnlButton.Size = new System.Drawing.Size(780, 55);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Location = new System.Drawing.Point(2, 96);
            this.pnlSearch.Size = new System.Drawing.Size(780, 32);
            // 
            // lblKetQua
            // 
            // 
            // 
            // 
            this.lblKetQua.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            this.pnlControl2.Size = new System.Drawing.Size(780, 39);
            this.pnlControl2.TabIndex = 2;
            this.pnlControl2.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkAll);
            this.pnlMain.Controls.Add(this.dgvMain);
            this.pnlMain.Location = new System.Drawing.Point(2, 128);
            this.pnlMain.Size = new System.Drawing.Size(780, 370);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(503, 1);
            this.btnThoat.Size = new System.Drawing.Size(70, 53);
            this.btnThoat.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2});
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
            this.chkTamNgung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTamNgung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTamNgung.ForeColor = System.Drawing.Color.Black;
            this.chkTamNgung.Location = new System.Drawing.Point(681, 5);
            this.chkTamNgung.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.chkTamNgung.Name = "chkTamNgung";
            this.chkTamNgung.Size = new System.Drawing.Size(99, 26);
            this.chkTamNgung.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkTamNgung.TabIndex = 3;
            this.chkTamNgung.Text = "Tạm ngừng";
            this.chkTamNgung.TextColor = System.Drawing.Color.Black;
            // 
            // lblNhom
            // 
            this.lblNhom.AutoSize = true;
            // 
            // 
            // 
            this.lblNhom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhom.ForeColor = System.Drawing.Color.Black;
            this.lblNhom.IsNotNull = false;
            this.lblNhom.Location = new System.Drawing.Point(23, 8);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(100, 18);
            this.lblNhom.TabIndex = 5;
            this.lblNhom.Text = "Nhóm khu vực:<font color=\"#ED1C24\">*</font>";
            this.lblNhom.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblNhom.Click += new System.EventHandler(this.lblNhom_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightCyan;
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMain.ColumnHeadersHeight = 28;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colCheck,
            this.colSua,
            this.colXoa,
            this.colMa,
            this.colMaNhom,
            this.colTen,
            this.colGhiChu,
            this.colTamNgung});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowHeadersWidth = 40;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(780, 370);
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
            // colMaNhom
            // 
            this.colMaNhom.DataPropertyName = "MaNhom";
            this.colMaNhom.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colMaNhom.HeaderText = "Nhóm Khu Vực";
            this.colMaNhom.MinimumWidth = 200;
            this.colMaNhom.Name = "colMaNhom";
            this.colMaNhom.ReadOnly = true;
            this.colMaNhom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaNhom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMaNhom.Width = 200;
            // 
            // colTen
            // 
            this.colTen.DataPropertyName = "Ten";
            this.colTen.HeaderText = "Khu Vực";
            this.colTen.MinimumWidth = 200;
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            this.colTen.Width = 200;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.HeaderText = "Ghi Chú";
            this.colGhiChu.MinimumWidth = 100;
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
            this.his_LabelX2.Location = new System.Drawing.Point(494, 8);
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
            this.txtGhiChu.Location = new System.Drawing.Point(552, 6);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(126, 23);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.Controls.Add(this.slbTen, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkTamNgung, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNhom, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.his_LabelX2, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.his_LabelX1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.slbNhomKV, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 36);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // his_LabelX1
            // 
            this.his_LabelX1.AutoSize = true;
            // 
            // 
            // 
            this.his_LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.his_LabelX1.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX1.IsNotNull = true;
            this.his_LabelX1.Location = new System.Drawing.Point(280, 8);
            this.his_LabelX1.Name = "his_LabelX1";
            this.his_LabelX1.Size = new System.Drawing.Size(62, 18);
            this.his_LabelX1.TabIndex = 5;
            this.his_LabelX1.Text = "Khu vực: <font color=\"#ED1C24\">*</font>";
            this.his_LabelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // slbNhomKV
            // 
            this.slbNhomKV.DataSource = null;
            this.slbNhomKV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slbNhomKV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbNhomKV.his_AddNew = false;
            this.slbNhomKV.his_ColMa = null;
            this.slbNhomKV.his_ColTen = null;
            this.slbNhomKV.his_FontSize = 10F;
            this.slbNhomKV.his_lblText = "Mã:";
            this.slbNhomKV.his_lblTitle1_Bold = false;
            this.slbNhomKV.his_lblTitle1_text = "labelX1";
            this.slbNhomKV.his_lblTitle1_Visible = false;
            this.slbNhomKV.his_lblTitle1_Width = 0;
            this.slbNhomKV.his_lblVisible = false;
            this.slbNhomKV.his_lblWidth = 0;
            this.slbNhomKV.his_ShowCount = 10;
            this.slbNhomKV.his_TabLocation = 0;
            this.slbNhomKV.his_TenReadonly = false;
            this.slbNhomKV.his_TenReadOnly = false;
            this.slbNhomKV.his_TenVisible = true;
            this.slbNhomKV.his_txtWidth = 0;
            this.slbNhomKV.his_XoaMa = true;
            this.slbNhomKV.Location = new System.Drawing.Point(131, 5);
            this.slbNhomKV.Margin = new System.Windows.Forms.Padding(0);
            this.slbNhomKV.Name = "slbNhomKV";
            this.slbNhomKV.Size = new System.Drawing.Size(126, 26);
            this.slbNhomKV.TabIndex = 0;
            this.slbNhomKV.HisSelectChange += new E00_ControlNew.EventHandler(this.slbNhomKV_HisSelectChange);
            // 
            // buttonItem1
            // 
            this.buttonItem1.GlobalItem = false;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // buttonItem2
            // 
            this.buttonItem2.GlobalItem = false;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            // 
            // slbTen
            // 
            this.slbTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slbTen.BackColor = System.Drawing.Color.White;
            this.slbTen.Controls.Add(this.lblTen);
            this.slbTen.Controls.Add(this.labelX1);
            this.slbTen.DataSource = null;
            this.slbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbTen.ForeColor = System.Drawing.Color.Black;
            this.slbTen.his_AddNew = true;
            this.slbTen.his_ColMa = null;
            this.slbTen.his_ColTen = null;
            this.slbTen.his_FontSize = 10F;
            this.slbTen.his_lblText = "Mã:";
            this.slbTen.his_lblTitle1_Bold = false;
            this.slbTen.his_lblTitle1_text = "labelX1";
            this.slbTen.his_lblTitle1_Visible = false;
            this.slbTen.his_lblTitle1_Width = 0;
            this.slbTen.his_lblVisible = false;
            this.slbTen.his_lblWidth = 0;
            this.slbTen.his_ShowCount = 10;
            this.slbTen.his_TabLocation = 0;
            this.slbTen.his_TenReadonly = false;
            this.slbTen.his_TenReadOnly = false;
            this.slbTen.his_TenVisible = true;
            this.slbTen.his_txtWidth = 0;
            this.slbTen.his_XoaMa = true;
            this.slbTen.Location = new System.Drawing.Point(347, 6);
            this.slbTen.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.slbTen.Name = "slbTen";
            this.slbTen.Size = new System.Drawing.Size(124, 23);
            this.slbTen.TabIndex = 33;
            // 
            // lblTen
            // 
            this.lblTen.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTen.ForeColor = System.Drawing.Color.Black;
            this.lblTen.IsNotNull = false;
            this.lblTen.Location = new System.Drawing.Point(0, 0);
            this.lblTen.Margin = new System.Windows.Forms.Padding(4);
            this.lblTen.Name = "lblTen";
            this.lblTen.SingleLineColor = System.Drawing.Color.Black;
            this.lblTen.Size = new System.Drawing.Size(0, 23);
            this.lblTen.TabIndex = 4;
            this.lblTen.Text = "Mã:";
            this.lblTen.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblTen.Visible = false;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.IsNotNull = false;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(0, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "labelX1";
            this.labelX1.Visible = false;
            // 
            // frm_KhuVuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(784, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frm_KhuVuc";
            this.Text = "Khu vực";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlButton.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlControl2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.slbTen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private E00_Control.his_CheckBoxX chkTamNgung;
        private E00_Control.his_LabelX lblNhom;
        private E00_Control.his_DataGridView dgvMain;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAll;
        private E00_Control.his_LabelX his_LabelX2;
        private E00_Control.his_TextboxX txtGhiChu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private E00_Control.his_LabelX his_LabelX1;
        private E00_ControlNew.usc_SelectBox slbNhomKV;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colSua;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMaNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTamNgung;
        private E00_ControlNew.usc_SelectBox slbTen;
        private E00_Control.his_LabelX lblTen;
        private E00_Control.his_LabelX labelX1;
    }
}
