namespace E00_STT
{
    partial class frm_DanhMucGio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DanhMucGio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkTamNgung = new E00_Control.his_CheckBoxX();
            this.his_LabelX2 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX1 = new E00_Control.his_LabelX(this.components);
            this.dgvMain = new E00_Control.his_DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSua = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colXoa = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colTimeBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTamNgung = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtiTimeBegin = new E00_Control.his_DateTimeInput();
            this.dtiTimeEnd = new E00_Control.his_DateTimeInput();
            this.pnlButton.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlControl2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            // 
            // 
            // 
            // 
            // txtTimKiem
            // 
            // 
            // 
            // 
            this.txtTimKiem.Border.Class = "TextBoxBorder";
            this.txtTimKiem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTimKiem.Location = new System.Drawing.Point(404, 3);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(609, 3);
            // 
            // pnlButton
            // 
            this.pnlButton.Size = new System.Drawing.Size(634, 53);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Location = new System.Drawing.Point(2, 91);
            this.pnlSearch.Size = new System.Drawing.Size(634, 32);
            // 
            // lblKetQua
            // 
            // 
            // 
            // 
            this.lblKetQua.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKetQua.Size = new System.Drawing.Size(318, 26);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(357, 2);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(286, 2);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(215, 2);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(144, 2);
            // 
            // pnlControl2
            // 
            this.pnlControl2.Controls.Add(this.dtiTimeEnd);
            this.pnlControl2.Controls.Add(this.dtiTimeBegin);
            this.pnlControl2.Controls.Add(this.chkTamNgung);
            this.pnlControl2.Controls.Add(this.his_LabelX2);
            this.pnlControl2.Controls.Add(this.his_LabelX1);
            this.pnlControl2.Size = new System.Drawing.Size(634, 36);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkAll);
            this.pnlMain.Controls.Add(this.dgvMain);
            this.pnlMain.Location = new System.Drawing.Point(2, 123);
            this.pnlMain.Size = new System.Drawing.Size(634, 169);
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.chkAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAll.CheckSignSize = new System.Drawing.Size(17, 15);
            this.chkAll.Location = new System.Drawing.Point(6, 4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(23, 21);
            this.chkAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAll.TabIndex = 33;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
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
            this.chkTamNgung.Location = new System.Drawing.Point(377, 7);
            this.chkTamNgung.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.chkTamNgung.Name = "chkTamNgung";
            this.chkTamNgung.Size = new System.Drawing.Size(88, 26);
            this.chkTamNgung.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkTamNgung.TabIndex = 9;
            this.chkTamNgung.Text = "Tạm ngưng";
            this.chkTamNgung.TextColor = System.Drawing.Color.Black;
            // 
            // his_LabelX2
            // 
            // 
            // 
            // 
            this.his_LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX2.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX2.IsNotNull = false;
            this.his_LabelX2.Location = new System.Drawing.Point(200, 8);
            this.his_LabelX2.Name = "his_LabelX2";
            this.his_LabelX2.Size = new System.Drawing.Size(55, 20);
            this.his_LabelX2.TabIndex = 11;
            this.his_LabelX2.Text = "Kết thúc :";
            this.his_LabelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // his_LabelX1
            // 
            // 
            // 
            // 
            this.his_LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX1.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX1.IsNotNull = false;
            this.his_LabelX1.Location = new System.Drawing.Point(4, 8);
            this.his_LabelX1.Name = "his_LabelX1";
            this.his_LabelX1.Size = new System.Drawing.Size(74, 20);
            this.his_LabelX1.TabIndex = 10;
            this.his_LabelX1.Text = "Bắt đầu :";
            this.his_LabelX1.TextAlignment = System.Drawing.StringAlignment.Far;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
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
            this.colTimeBegin,
            this.colTimeEnd,
            this.colTamNgung});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowHeadersWidth = 40;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(634, 169);
            this.dgvMain.TabIndex = 34;
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
            this.colID.Width = 45;
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
            // colTimeBegin
            // 
            this.colTimeBegin.DataPropertyName = "TIMEBEGIN";
            dataGridViewCellStyle3.Format = "t";
            dataGridViewCellStyle3.NullValue = null;
            this.colTimeBegin.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTimeBegin.HeaderText = "Thời gian bắt đầu";
            this.colTimeBegin.MinimumWidth = 200;
            this.colTimeBegin.Name = "colTimeBegin";
            this.colTimeBegin.ReadOnly = true;
            this.colTimeBegin.Width = 200;
            // 
            // colTimeEnd
            // 
            this.colTimeEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTimeEnd.DataPropertyName = "TIMEEND";
            dataGridViewCellStyle4.Format = "t";
            this.colTimeEnd.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTimeEnd.HeaderText = "Thời gian kết thúc";
            this.colTimeEnd.MinimumWidth = 100;
            this.colTimeEnd.Name = "colTimeEnd";
            this.colTimeEnd.ReadOnly = true;
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
            // dtiTimeBegin
            // 
            // 
            // 
            // 
            this.dtiTimeBegin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTimeBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTimeBegin.ButtonDropDown.Visible = true;
            this.dtiTimeBegin.CustomFormat = "hh:mm";
            this.dtiTimeBegin.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector;
            this.dtiTimeBegin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiTimeBegin.IsPopupCalendarOpen = false;
            this.dtiTimeBegin.Location = new System.Drawing.Point(84, 10);
            // 
            // 
            // 
            this.dtiTimeBegin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeBegin.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtiTimeBegin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeBegin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTimeBegin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTimeBegin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTimeBegin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeBegin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTimeBegin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTimeBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTimeBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTimeBegin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeBegin.MonthCalendar.DisplayMonth = new System.DateTime(2015, 6, 1, 0, 0, 0, 0);
            this.dtiTimeBegin.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTimeBegin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeBegin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTimeBegin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeBegin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTimeBegin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeBegin.MonthCalendar.TodayButtonVisible = true;
            this.dtiTimeBegin.MonthCalendar.Visible = false;
            this.dtiTimeBegin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTimeBegin.Name = "dtiTimeBegin";
            this.dtiTimeBegin.Size = new System.Drawing.Size(110, 20);
            this.dtiTimeBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTimeBegin.TabIndex = 12;
            this.dtiTimeBegin.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            // 
            // dtiTimeEnd
            // 
            // 
            // 
            // 
            this.dtiTimeEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTimeEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTimeEnd.ButtonDropDown.Visible = true;
            this.dtiTimeEnd.CustomFormat = "hh:mm";
            this.dtiTimeEnd.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector;
            this.dtiTimeEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiTimeEnd.IsPopupCalendarOpen = false;
            this.dtiTimeEnd.Location = new System.Drawing.Point(261, 10);
            // 
            // 
            // 
            this.dtiTimeEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtiTimeEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTimeEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTimeEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeEnd.MonthCalendar.DisplayMonth = new System.DateTime(2015, 6, 1, 0, 0, 0, 0);
            this.dtiTimeEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTimeEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTimeEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeEnd.MonthCalendar.TodayButtonVisible = true;
            this.dtiTimeEnd.MonthCalendar.Visible = false;
            this.dtiTimeEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTimeEnd.Name = "dtiTimeEnd";
            this.dtiTimeEnd.Size = new System.Drawing.Size(110, 20);
            this.dtiTimeEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTimeEnd.TabIndex = 13;
            this.dtiTimeEnd.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiTimeEnd.Enter += new System.EventHandler(this.dtiTimeEnd_Enter);
            // 
            // frm_DanhMucGio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 294);
            this.Name = "frm_DanhMucGio";
            this.Text = "frm_DanhMucGio";
            this.pnlButton.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlControl2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeEnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX chkAll;
        private E00_Control.his_CheckBoxX chkTamNgung;
        private E00_Control.his_LabelX his_LabelX2;
        private E00_Control.his_LabelX his_LabelX1;
        private E00_Control.his_DataGridView dgvMain;
        private E00_Control.his_DateTimeInput dtiTimeEnd;
        private E00_Control.his_DateTimeInput dtiTimeBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colSua;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeEnd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTamNgung;
    }
}