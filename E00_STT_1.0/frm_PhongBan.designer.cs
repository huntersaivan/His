namespace E00_STT
{
    partial class frm_PhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhongBan));
            this.chkTamNgung = new E00_Control.his_CheckBoxX();
            this.lblKhuVuc = new E00_Control.his_LabelX(this.components);
            this.dgvMain = new E00_Control.his_DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSua = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colXoa = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhomKV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTamNgung = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMaNhomKhu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaKhu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.his_LabelX2 = new E00_Control.his_LabelX(this.components);
            this.txtGhiChu = new E00_Control.his_TextboxX();
            this.tlpControl = new System.Windows.Forms.TableLayoutPanel();
            this.slbKhuVuc = new E00_ControlNew.usc_SelectBox();
            this.slbTen = new E00_ControlNew.usc_SelectBox();
            this.his_LabelX1 = new E00_Control.his_LabelX(this.components);
            this.lblNhomKV = new E00_Control.his_LabelX(this.components);
            this.slbNhomKV = new E00_ControlNew.usc_SelectBox();
            this.lblTen = new E00_Control.his_LabelX(this.components);
            this.labelX1 = new E00_Control.his_LabelX(this.components);
            this.pnlButton.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlControl2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.tlpControl.SuspendLayout();
            this.slbNhomKV.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            // 
            // 
            // 
            this.txtTimKiem.Border.Class = "TextBoxBorder";
            this.txtTimKiem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTimKiem.Location = new System.Drawing.Point(7200, 3);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(7405, 3);
            // 
            // btnThem
            // 
            this.btnThem.Size = new System.Drawing.Size(70, 53);
            // 
            // pnlButton
            // 
            this.pnlButton.Size = new System.Drawing.Size(999, 55);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Location = new System.Drawing.Point(2, 95);
            this.pnlSearch.Size = new System.Drawing.Size(999, 32);
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
            this.pnlControl2.Controls.Add(this.tlpControl);
            this.pnlControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlControl2.Location = new System.Drawing.Point(2, 57);
            this.pnlControl2.Size = new System.Drawing.Size(999, 38);
            this.pnlControl2.TabIndex = 2;
            this.pnlControl2.Controls.SetChildIndex(this.tlpControl, 0);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkAll);
            this.pnlMain.Controls.Add(this.dgvMain);
            this.pnlMain.Location = new System.Drawing.Point(2, 127);
            this.pnlMain.Size = new System.Drawing.Size(999, 371);
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
            this.chkTamNgung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTamNgung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTamNgung.ForeColor = System.Drawing.Color.Black;
            this.chkTamNgung.Location = new System.Drawing.Point(900, 5);
            this.chkTamNgung.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.chkTamNgung.Name = "chkTamNgung";
            this.chkTamNgung.Size = new System.Drawing.Size(99, 26);
            this.chkTamNgung.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkTamNgung.TabIndex = 3;
            this.chkTamNgung.TabStop = false;
            this.chkTamNgung.Text = "Tạm ngừng";
            this.chkTamNgung.TextColor = System.Drawing.Color.Black;
            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.AutoSize = true;
            // 
            // 
            // 
            this.lblKhuVuc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKhuVuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhuVuc.ForeColor = System.Drawing.Color.Black;
            this.lblKhuVuc.IsNotNull = false;
            this.lblKhuVuc.Location = new System.Drawing.Point(265, 8);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(61, 18);
            this.lblKhuVuc.TabIndex = 5;
            this.lblKhuVuc.Text = "Khu vực:<font color=\"#ED1C24\">*</font>";
            this.lblKhuVuc.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblKhuVuc.Click += new System.EventHandler(this.lblKhuVuc_Click);
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
            this.colMaNhomKV,
            this.colMaNhom,
            this.colTen,
            this.colGhiChu,
            this.colTamNgung,
            this.colMaNhomKhu,
            this.colMaKhu});
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
            this.dgvMain.Size = new System.Drawing.Size(999, 371);
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
            // colMaNhomKV
            // 
            this.colMaNhomKV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMaNhomKV.DataPropertyName = "tennhomkhu";
            this.colMaNhomKV.HeaderText = "Nhóm khu vực";
            this.colMaNhomKV.Name = "colMaNhomKV";
            this.colMaNhomKV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaNhomKV.Width = 200;
            // 
            // colMaNhom
            // 
            this.colMaNhom.DataPropertyName = "tenkhu";
            this.colMaNhom.HeaderText = "Khu Vực";
            this.colMaNhom.MinimumWidth = 200;
            this.colMaNhom.Name = "colMaNhom";
            this.colMaNhom.ReadOnly = true;
            this.colMaNhom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaNhom.Width = 200;
            // 
            // colTen
            // 
            this.colTen.DataPropertyName = "Ten";
            this.colTen.HeaderText = "Phòng Ban";
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
            // colMaNhomKhu
            // 
            this.colMaNhomKhu.DataPropertyName = "manhomkv";
            this.colMaNhomKhu.HeaderText = "Mã Nhóm Khu";
            this.colMaNhomKhu.Name = "colMaNhomKhu";
            this.colMaNhomKhu.Visible = false;
            // 
            // colMaKhu
            // 
            this.colMaKhu.DataPropertyName = "manhom";
            this.colMaKhu.HeaderText = "Mã Khu";
            this.colMaKhu.Name = "colMaKhu";
            this.colMaKhu.Visible = false;
            this.colMaKhu.Width = 69;
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
            // 
            // 
            // 
            this.his_LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.his_LabelX2.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX2.IsNotNull = false;
            this.his_LabelX2.Location = new System.Drawing.Point(697, 8);
            this.his_LabelX2.Name = "his_LabelX2";
            this.his_LabelX2.Size = new System.Drawing.Size(55, 20);
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
            this.txtGhiChu.Location = new System.Drawing.Point(755, 6);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(142, 23);
            this.txtGhiChu.TabIndex = 3;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            // 
            // tlpControl
            // 
            this.tlpControl.ColumnCount = 10;
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlpControl.Controls.Add(this.chkTamNgung, 9, 1);
            this.tlpControl.Controls.Add(this.lblKhuVuc, 3, 1);
            this.tlpControl.Controls.Add(this.txtGhiChu, 8, 1);
            this.tlpControl.Controls.Add(this.his_LabelX2, 7, 1);
            this.tlpControl.Controls.Add(this.slbKhuVuc, 4, 1);
            this.tlpControl.Controls.Add(this.slbTen, 6, 1);
            this.tlpControl.Controls.Add(this.his_LabelX1, 5, 1);
            this.tlpControl.Controls.Add(this.lblNhomKV, 1, 1);
            this.tlpControl.Controls.Add(this.slbNhomKV, 2, 1);
            this.tlpControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpControl.Location = new System.Drawing.Point(0, 2);
            this.tlpControl.Name = "tlpControl";
            this.tlpControl.RowCount = 3;
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControl.Size = new System.Drawing.Size(999, 36);
            this.tlpControl.TabIndex = 6;
            // 
            // slbKhuVuc
            // 
            this.slbKhuVuc.DataSource = null;
            this.slbKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slbKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbKhuVuc.his_AddNew = false;
            this.slbKhuVuc.his_ColMa = null;
            this.slbKhuVuc.his_ColTen = null;
            this.slbKhuVuc.his_FontSize = 10F;
            this.slbKhuVuc.his_lblText = "Mã:";
            this.slbKhuVuc.his_lblTitle1_Bold = false;
            this.slbKhuVuc.his_lblTitle1_text = "labelX1";
            this.slbKhuVuc.his_lblTitle1_Visible = false;
            this.slbKhuVuc.his_lblTitle1_Width = 0;
            this.slbKhuVuc.his_lblVisible = false;
            this.slbKhuVuc.his_lblWidth = 0;
            this.slbKhuVuc.his_ShowCount = 10;
            this.slbKhuVuc.his_Showmin = 10;
            this.slbKhuVuc.his_TabLocation = 0;
            this.slbKhuVuc.his_TenReadonly = false;
            this.slbKhuVuc.his_TenReadOnly = false;
            this.slbKhuVuc.his_TenVisible = true;
            this.slbKhuVuc.his_TimeSearch = 200;
            this.slbKhuVuc.his_txtWidth = 0;
            this.slbKhuVuc.his_XoaMa = true;
            this.slbKhuVuc.Location = new System.Drawing.Point(330, 5);
            this.slbKhuVuc.Margin = new System.Windows.Forms.Padding(0);
            this.slbKhuVuc.Minlenght = 200;
            this.slbKhuVuc.Name = "slbKhuVuc";
            this.slbKhuVuc.Size = new System.Drawing.Size(142, 26);
            this.slbKhuVuc.TabIndex = 1;
            // 
            // slbTen
            // 
            this.slbTen.BackColor = System.Drawing.Color.White;
            this.slbTen.DataSource = null;
            this.slbTen.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.slbTen.his_Showmin = 10;
            this.slbTen.his_TabLocation = 0;
            this.slbTen.his_TenReadonly = false;
            this.slbTen.his_TenReadOnly = false;
            this.slbTen.his_TenVisible = true;
            this.slbTen.his_TimeSearch = 200;
            this.slbTen.his_txtWidth = 0;
            this.slbTen.his_XoaMa = true;
            this.slbTen.Location = new System.Drawing.Point(554, 6);
            this.slbTen.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.slbTen.Minlenght = 200;
            this.slbTen.Name = "slbTen";
            this.slbTen.Size = new System.Drawing.Size(140, 25);
            this.slbTen.TabIndex = 2;
            this.slbTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            // 
            // his_LabelX1
            // 
            // 
            // 
            // 
            this.his_LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.his_LabelX1.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX1.IsNotNull = false;
            this.his_LabelX1.Location = new System.Drawing.Point(475, 8);
            this.his_LabelX1.Name = "his_LabelX1";
            this.his_LabelX1.Size = new System.Drawing.Size(74, 20);
            this.his_LabelX1.TabIndex = 5;
            this.his_LabelX1.Text = "Phòng ban:";
            this.his_LabelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblNhomKV
            // 
            this.lblNhomKV.AutoSize = true;
            // 
            // 
            // 
            this.lblNhomKV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNhomKV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNhomKV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhomKV.ForeColor = System.Drawing.Color.Black;
            this.lblNhomKV.IsNotNull = false;
            this.lblNhomKV.Location = new System.Drawing.Point(13, 8);
            this.lblNhomKV.Name = "lblNhomKV";
            this.lblNhomKV.Size = new System.Drawing.Size(100, 18);
            this.lblNhomKV.TabIndex = 5;
            this.lblNhomKV.Text = "Nhóm khu vực:<font color=\"#ED1C24\">*</font>";
            this.lblNhomKV.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblNhomKV.Click += new System.EventHandler(this.lblNhomKV_Click);
            // 
            // slbNhomKV
            // 
            this.slbNhomKV.Controls.Add(this.lblTen);
            this.slbNhomKV.Controls.Add(this.labelX1);
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
            this.slbNhomKV.his_Showmin = 10;
            this.slbNhomKV.his_TabLocation = 0;
            this.slbNhomKV.his_TenReadonly = false;
            this.slbNhomKV.his_TenReadOnly = false;
            this.slbNhomKV.his_TenVisible = true;
            this.slbNhomKV.his_TimeSearch = 200;
            this.slbNhomKV.his_txtWidth = 0;
            this.slbNhomKV.his_XoaMa = true;
            this.slbNhomKV.Location = new System.Drawing.Point(120, 5);
            this.slbNhomKV.Margin = new System.Windows.Forms.Padding(0);
            this.slbNhomKV.Minlenght = 200;
            this.slbNhomKV.Name = "slbNhomKV";
            this.slbNhomKV.Size = new System.Drawing.Size(142, 26);
            this.slbNhomKV.TabIndex = 0;
            this.slbNhomKV.HisKeyUpEnter += new System.Windows.Forms.KeyEventHandler(this.slbNhomKV_HisKeyUpEnter);
            this.slbNhomKV.HisSelectChange += new E00_ControlNew.EventHandler(this.slbNhomKV_HisSelectChange);
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
            this.lblTen.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblTen.Name = "lblTen";
            this.lblTen.SingleLineColor = System.Drawing.Color.Black;
            this.lblTen.Size = new System.Drawing.Size(0, 26);
            this.lblTen.TabIndex = 0;
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
            this.labelX1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(0, 26);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "labelX1";
            this.labelX1.Visible = false;
            // 
            // frm_PhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1003, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frm_PhongBan";
            this.Text = "Phòng ban";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlButton.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlControl2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.tlpControl.ResumeLayout(false);
            this.tlpControl.PerformLayout();
            this.slbNhomKV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private E00_Control.his_CheckBoxX chkTamNgung;
        private E00_Control.his_LabelX lblKhuVuc;
        private E00_Control.his_DataGridView dgvMain;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAll;
        private E00_Control.his_LabelX his_LabelX2;
        private E00_Control.his_TextboxX txtGhiChu;
        private System.Windows.Forms.TableLayoutPanel tlpControl;
        private E00_ControlNew.usc_SelectBox slbKhuVuc;
        private E00_ControlNew.usc_SelectBox slbTen;
        private E00_Control.his_LabelX his_LabelX1;
        private E00_Control.his_LabelX lblNhomKV;
        private E00_ControlNew.usc_SelectBox slbNhomKV;
        private E00_Control.his_LabelX lblTen;
        private E00_Control.his_LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colSua;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhomKV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTamNgung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhomKhu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKhu;
    }
}
