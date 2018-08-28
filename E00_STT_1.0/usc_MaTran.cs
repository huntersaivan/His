using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Media;
using System.Runtime.InteropServices;
using E00_Common;
using System.Threading;

namespace E00_STT
{
    public partial class usc_MaTran : UserControl
    {

        #region Biến toàn cục
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        public LabelX lblGoi;
        public Panel pnlTieuDe;
        public Panel pnlGoi;
        public Panel pnlKhuVuc;
        public LabelX lblTieuDe;
        public Panel pnlCho;
        public LabelX lblKhuVuc;

        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer timer1;
        private TableLayoutPanel tlpVungCho;
        private string _maKP = "";
        private string _maBS = "";
        private int soluongCho = 1;
        public List<LabelX> _lstLBcho = new List<LabelX>();
        private clsBUS _bus = new clsBUS();
        public Color curren;
        public event EventHandler AlamRing;
        public bool changecolo = false;
        private List<ColorPickerButton> _lstMau = new List<ColorPickerButton>();
        #endregion

        #region Hàm khởi tạo

        public string Makp
        {

            get
            {
                return _maKP;
            }
            set
            {
                _maKP = value;
                if (!string.IsNullOrEmpty(value))
                {
                    lblKhuVuc.Text = _bus.GetTenKP(_maKP);
                    timer1.Start();
                }
            }
        }

        public int SoluongCho
        {
            get { return soluongCho; }
            set
            {
                if (_lstLBcho.Count > 0)
                {
                    LabelX term = _lstLBcho[0];
                    _lstLBcho.Clear();
                    tlpVungCho.Controls.Clear();
                    tlpVungCho.RowCount = value;
                    this.tlpVungCho.RowStyles.Clear();
                    for (int i = 0; i < value; i++)
                    {
                        soluongCho = value;
                        LabelX lbl1 = new LabelX();
                        lbl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                        lbl1.Dock = System.Windows.Forms.DockStyle.Top;
                        lbl1.Height = tlpVungCho.Height / value;
                        this.tlpVungCho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, lbl1.Height));
                        lbl1.Location = new System.Drawing.Point(0, lbl1.Height * i);
                        lbl1.Name = "lblCho" + i;
                        lbl1.Margin = new System.Windows.Forms.Padding(1);
                        lbl1.BackColor = term.BackColor;
                        lbl1.Font = term.Font;
                        lbl1.Text = "Vùng chờ";
                        lbl1.ForeColor = term.ForeColor;
                        _lstLBcho.Add(lbl1);
                        tlpVungCho.Controls.Add(lbl1, 0, i);
                    }
                }
                else
                {
                    _lstLBcho.Clear();
                    tlpVungCho.Controls.Clear();
                    tlpVungCho.RowCount = value;
                    this.tlpVungCho.RowStyles.Clear();
                    for (int i = 0; i < value; i++)
                    {
                        soluongCho = value;
                        LabelX lbl1 = new LabelX();
                        lbl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                        lbl1.Dock = System.Windows.Forms.DockStyle.Top;
                        lbl1.Height = tlpVungCho.Height / value;
                        this.tlpVungCho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, lbl1.Height));
                        lbl1.Location = new System.Drawing.Point(0, lbl1.Height * i);
                        lbl1.Name = "lblCho" + i;
                        lbl1.Margin = new System.Windows.Forms.Padding(1);
                        lbl1.Text = "";
                        lbl1.BackColor = Color.Black;
                        _lstLBcho.Add(lbl1);
                        tlpVungCho.Controls.Add(lbl1, 0, i);
                    }
                }
            }
        }

        public List<ColorPickerButton> LstMau
        {

            set { _lstMau = value; }
        }

        public double thoigian
        {

            set
            {
                timer2.Interval = Convert.ToInt32(value * 1000);
            }
        }

        public string MaBS
        {
            get
            {
                return _maBS;
            }

            set
            {
                _maBS = value;
                if (!string.IsNullOrEmpty(value))
                {
                    lblBacSi.Text = value;
                }
            }
        }

        public usc_MaTran()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch
            {

            }
        }
        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblGoi = new DevComponents.DotNetBar.LabelX();
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new DevComponents.DotNetBar.LabelX();
            this.pnlGoi = new System.Windows.Forms.Panel();
            this.pnlKhuVuc = new System.Windows.Forms.Panel();
            this.lblKhuVuc = new DevComponents.DotNetBar.LabelX();
            this.pnlCho = new System.Windows.Forms.Panel();
            this.tlpVungCho = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlBS = new System.Windows.Forms.Panel();
            this.lblBacSi = new DevComponents.DotNetBar.LabelX();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTieuDe.SuspendLayout();
            this.pnlGoi.SuspendLayout();
            this.pnlKhuVuc.SuspendLayout();
            this.pnlCho.SuspendLayout();
            this.pnlBS.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGoi
            // 
            // 
            // 
            // 
            this.lblGoi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGoi.Location = new System.Drawing.Point(0, 0);
            this.lblGoi.Name = "lblGoi";
            this.lblGoi.Size = new System.Drawing.Size(525, 49);
            this.lblGoi.TabIndex = 1;
            this.lblGoi.Text = "Vùng gọi";
            this.lblGoi.TextChanged += new System.EventHandler(this.lblGoi_TextChanged);
            // 
            // pnlTieuDe
            // 
            this.pnlTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(527, 57);
            this.pnlTieuDe.TabIndex = 4;
            // 
            // lblTieuDe
            // 
            // 
            // 
            // 
            this.lblTieuDe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(525, 55);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "MỜI BỆNH NHÂN SỐ";
            // 
            // pnlGoi
            // 
            this.pnlGoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGoi.Controls.Add(this.lblGoi);
            this.pnlGoi.Location = new System.Drawing.Point(0, 57);
            this.pnlGoi.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGoi.Name = "pnlGoi";
            this.pnlGoi.Size = new System.Drawing.Size(527, 51);
            this.pnlGoi.TabIndex = 4;
            // 
            // pnlKhuVuc
            // 
            this.pnlKhuVuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKhuVuc.Controls.Add(this.lblKhuVuc);
            this.pnlKhuVuc.Location = new System.Drawing.Point(0, 278);
            this.pnlKhuVuc.Margin = new System.Windows.Forms.Padding(0);
            this.pnlKhuVuc.Name = "pnlKhuVuc";
            this.pnlKhuVuc.Size = new System.Drawing.Size(527, 65);
            this.pnlKhuVuc.TabIndex = 4;
            // 
            // lblKhuVuc
            // 
            // 
            // 
            // 
            this.lblKhuVuc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(525, 63);
            this.lblKhuVuc.TabIndex = 3;
            this.lblKhuVuc.Text = "Khu vực";
            // 
            // pnlCho
            // 
            this.pnlCho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCho.Controls.Add(this.tlpVungCho);
            this.pnlCho.Location = new System.Drawing.Point(0, 108);
            this.pnlCho.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCho.Name = "pnlCho";
            this.pnlCho.Size = new System.Drawing.Size(527, 170);
            this.pnlCho.TabIndex = 5;
            // 
            // tlpVungCho
            // 
            this.tlpVungCho.ColumnCount = 1;
            this.tlpVungCho.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVungCho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVungCho.Location = new System.Drawing.Point(0, 0);
            this.tlpVungCho.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVungCho.Name = "tlpVungCho";
            this.tlpVungCho.Size = new System.Drawing.Size(525, 168);
            this.tlpVungCho.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pnlBS
            // 
            this.pnlBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBS.Controls.Add(this.lblBacSi);
            this.pnlBS.Location = new System.Drawing.Point(0, 343);
            this.pnlBS.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBS.Name = "pnlBS";
            this.pnlBS.Size = new System.Drawing.Size(527, 47);
            this.pnlBS.TabIndex = 6;
            // 
            // lblBacSi
            // 
            // 
            // 
            // 
            this.lblBacSi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBacSi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBacSi.Location = new System.Drawing.Point(0, 0);
            this.lblBacSi.Name = "lblBacSi";
            this.lblBacSi.Size = new System.Drawing.Size(525, 45);
            this.lblBacSi.TabIndex = 2;
            this.lblBacSi.Text = "Bác sĩ";
            this.lblBacSi.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(790, 390);
            this.tlpMain.TabIndex = 7;
            // 
            // usc_MaTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlCho);
            this.Controls.Add(this.pnlGoi);
            this.Controls.Add(this.pnlKhuVuc);
            this.Controls.Add(this.pnlBS);
            this.Controls.Add(this.pnlTieuDe);
            this.Name = "usc_MaTran";
            this.Size = new System.Drawing.Size(790, 390);
            this.Load += new System.EventHandler(this.usc_MaTran_Load);
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlGoi.ResumeLayout(false);
            this.pnlKhuVuc.ResumeLayout(false);
            this.pnlCho.ResumeLayout(false);
            this.pnlBS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region Phương thức
        private void checknew()
        {
            try
            {
                if (!(string.IsNullOrEmpty(_maKP)))
                {
                    DataTable tmp = _bus.GetSoGoi(_maKP);
                    if (tmp != null && tmp.Rows.Count > 0)
                    {
                        string stext = "";
                        if (tmp.Rows.Count == 1)
                        {
                            if (!string.IsNullOrEmpty(tmp.Rows[0][3].ToString()))
                            {
                                stext = tmp.Rows[0][0].ToString() + ": " + tmp.Rows[0][3].ToString();
                            }
                            else
                            {
                                stext = tmp.Rows[0][0].ToString();
                            }
                        }
                        else
                        {
                            if ("1" == tmp.Rows[0][2].ToString())
                            {
                                stext = tmp.Rows[0][0].ToString() + " UT " + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString() + " UT ";
                            }
                            else
                            {
                                stext = tmp.Rows[0][0].ToString() + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString();
                            }
                        }

                        if ((("1" == tmp.Rows[0][1].ToString()) && (lblGoi.Text != stext)) || ("5" == tmp.Rows[0][1].ToString()))
                        {
                            lblGoi.Text = stext;
                            if (this.AlamRing != null)
                            {
                                this.AlamRing(null, null);
                            }
                            curren = lblGoi.ForeColor;
                            changecolo = true;
                            timer2.Start();

                        }
                    }
                    else
                    {
                        lblGoi.Text = "";
                    }

                    string cho = _bus.GetSoGoiTiepTheo(_maKP, soluongCho);
                    if (_maKP[0] =='P' && string.IsNullOrEmpty(cho))
                    {
                       string _maKPTMP = "K" + (_maKP.Split('-')[0] + "-" + _maKP.Split('-')[1]).Remove(0, 1);
                        cho = _bus.GetSoGoiTiepTheo(_maKPTMP, soluongCho);

                    }
                    for (int i = 0; i < _lstLBcho.Count; i++)
                    {
                        try
                        {
                            _lstLBcho[i].Text = cho.Split(';')[i];
                        }
                        catch
                        {
                            _lstLBcho[i].Text = "";
                        }
                    }

                }
            }
            catch { }
        }

        public void LoadVitri(DataTable dtvitri)
        {
            if (dtvitri != null && dtvitri.Rows.Count > 0)
            {
                tlpMain.Controls.Clear();
                // tlpMain.RowStyles.Clear();
                int i = 0;
                foreach (DataRow item in dtvitri.Rows)
                {
                    if (item["Tamngung"].ToString() == "0")
                    {
                        string vung = item["Ma"].ToString().Substring(0, 2);
                        switch (vung)
                        {
                            case "TD":
                                tlpMain.Controls.Add(pnlTieuDe, 0, i);
                                break;
                            case "VG":
                                tlpMain.Controls.Add(pnlGoi, 0, i);
                                break;
                            case "VC":
                                tlpMain.Controls.Add(pnlCho, 0, i);
                                break;
                            case "KV":
                                tlpMain.Controls.Add(pnlKhuVuc, 0, i);
                                break;
                            case "BS":
                                tlpMain.Controls.Add(pnlBS, 0, i);
                                break;
                            default:
                                break;
                        }
                    }
                    i++;
                }

            }
            else
            {

                tlpMain.Controls.Add(pnlTieuDe, 0, 0);
                tlpMain.Controls.Add(pnlGoi, 0, 1);
                tlpMain.Controls.Add(pnlKhuVuc, 0, 2);
                tlpMain.Controls.Add(pnlCho, 0, 3);
                tlpMain.Controls.Add(pnlBS, 0, 4);
            }
        }
        #endregion

        #region Events

        private void timer2_Tick(object sender, EventArgs e)
        {
            changecolo = false;
            timer2.Stop();
            lblGoi.ForeColor = curren;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread(checknew);
            t.Start();
        }

        private void lblBacSi_TextChanged(object sender, EventArgs e)
        {
            lblGoi.Text = "";
        }

        private void lblBacSi_VisibleChanged(object sender, EventArgs e)
        {
            //if (lblBacSi.Visible)
            //{
            //    pnlKhuVuc.Height = lblBacSi.Height + lblKhuVuc.Height;
            //}
            //else
            //{
            //    pnlKhuVuc.Height = lblKhuVuc.Height;
            //}
        }

        private void usc_MaTran_Load(object sender, EventArgs e)
        {
            pnlKhuVuc.Dock = DockStyle.Fill;
            pnlTieuDe.Dock = DockStyle.Fill;
            pnlGoi.Dock = DockStyle.Fill;
            pnlCho.Dock = DockStyle.Fill;
            pnlBS.Dock = DockStyle.Fill;
        }

        private void lblGoi_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblGoi.Text)) return;
            if (lblGoi.Width < System.Windows.Forms.TextRenderer.MeasureText(lblGoi.Text,
                                     new Font(lblGoi.Font.FontFamily, lblGoi.Font.Size, lblGoi.Font.Style)).Width ||
                                     lblGoi.Height - 10 < System.Windows.Forms.TextRenderer.MeasureText(lblGoi.Text,
                                     new Font(lblGoi.Font.FontFamily, lblGoi.Font.Size, lblGoi.Font.Style)).Height)
            {
                while (lblGoi.Width < System.Windows.Forms.TextRenderer.MeasureText(lblGoi.Text,
                     new Font(lblGoi.Font.FontFamily, lblGoi.Font.Size, lblGoi.Font.Style)).Width
                     || (lblGoi.Height - 10 < System.Windows.Forms.TextRenderer.MeasureText(lblGoi.Text,
                     new Font(lblGoi.Font.FontFamily, lblGoi.Font.Size, lblGoi.Font.Style)).Height))
                {
                    lblGoi.Font = new Font(lblGoi.Font.FontFamily, lblGoi.Font.Size - 0.5f, lblGoi.Font.Style);
                }
            }
            else
            {
                while (lblGoi.Width > System.Windows.Forms.TextRenderer.MeasureText(lblGoi.Text,
                    new Font(lblGoi.Font.FontFamily, lblGoi.Font.Size, lblGoi.Font.Style)).Width
                    && (lblGoi.Height - 10 > System.Windows.Forms.TextRenderer.MeasureText(lblGoi.Text,
                    new Font(lblGoi.Font.FontFamily, lblGoi.Font.Size, lblGoi.Font.Style)).Height))
                {
                    lblGoi.Font = new Font(lblGoi.Font.FontFamily, lblGoi.Font.Size + 0.5f, lblGoi.Font.Style);
                }
            }
        }
        #endregion

    }
}
