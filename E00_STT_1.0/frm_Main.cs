using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DatabaseV2;

namespace E00_STT
{
    public partial class frm_Main : Form
    {

        #region Biến toàn cục
        clsBUS _bus = new clsBUS();

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem btnNhomKV;
        private System.Windows.Forms.ToolStripMenuItem btnKhuVuc;
        private System.Windows.Forms.ToolStripMenuItem btnPhongBan;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnNhomLCD;
        private System.Windows.Forms.ToolStripMenuItem btnCauHinhLCD;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem btnLayTT;
        private System.Windows.Forms.ToolStripMenuItem btnGoiSTT;
        private System.Windows.Forms.ToolStripMenuItem btnDinhNghia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem xuấtLCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tạoDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuất4LCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuất4LCDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chuKỳGiờToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tạoDanhSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lCDTuChonToolStripMenuItem;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #endregion

        #region Hàm khởi tạo
        public frm_Main()
        {
            InitializeComponent();
            //CreateVSpeechLibrary();
        }
        #endregion

        #region Phương thức
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDanhMuc = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnNhomKV = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKhuVuc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.chuKỳGiờToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tạoDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnNhomLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCauHinhLCD = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnDinhNghia = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tạoDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLayTT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGoiSTT = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.xuấtLCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuất4LCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuất4LCDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lCDTuChonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDanhMuc,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(896, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNhomKV,
            this.btnKhuVuc,
            this.btnPhongBan,
            this.chuKỳGiờToolStripMenuItem,
            this.tạoDatabaseToolStripMenuItem});
            this.btnDanhMuc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(75, 22);
            this.btnDanhMuc.Text = "Danh mục";
            // 
            // btnNhomKV
            // 
            this.btnNhomKV.Name = "btnNhomKV";
            this.btnNhomKV.Size = new System.Drawing.Size(153, 22);
            this.btnNhomKV.Text = "Nhóm khu vực";
            this.btnNhomKV.Click += new System.EventHandler(this.btnNhomKV_Click);
            // 
            // btnKhuVuc
            // 
            this.btnKhuVuc.Name = "btnKhuVuc";
            this.btnKhuVuc.Size = new System.Drawing.Size(153, 22);
            this.btnKhuVuc.Text = "Khu vực";
            this.btnKhuVuc.Click += new System.EventHandler(this.btnKhuVuc_Click);
            // 
            // btnPhongBan
            // 
            this.btnPhongBan.Name = "btnPhongBan";
            this.btnPhongBan.Size = new System.Drawing.Size(153, 22);
            this.btnPhongBan.Text = "Phòng ban";
            this.btnPhongBan.Click += new System.EventHandler(this.btnPhongBan_Click);
            // 
            // chuKỳGiờToolStripMenuItem
            // 
            this.chuKỳGiờToolStripMenuItem.Name = "chuKỳGiờToolStripMenuItem";
            this.chuKỳGiờToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.chuKỳGiờToolStripMenuItem.Text = "Chu kỳ giờ";
            this.chuKỳGiờToolStripMenuItem.Click += new System.EventHandler(this.chuKỳGiờToolStripMenuItem_Click);
            // 
            // tạoDatabaseToolStripMenuItem
            // 
            this.tạoDatabaseToolStripMenuItem.Name = "tạoDatabaseToolStripMenuItem";
            this.tạoDatabaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tạoDatabaseToolStripMenuItem.Text = "Tạo Database";
            this.tạoDatabaseToolStripMenuItem.Click += new System.EventHandler(this.tạoDatabaseToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNhomLCD,
            this.btnCauHinhLCD,
            this.testToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(93, 22);
            this.toolStripDropDownButton1.Text = "Cấu hình LCD";
            // 
            // btnNhomLCD
            // 
            this.btnNhomLCD.Name = "btnNhomLCD";
            this.btnNhomLCD.Size = new System.Drawing.Size(190, 22);
            this.btnNhomLCD.Text = "Nhóm LCD";
            this.btnNhomLCD.Click += new System.EventHandler(this.btnNhomLCD_Click);
            // 
            // btnCauHinhLCD
            // 
            this.btnCauHinhLCD.Name = "btnCauHinhLCD";
            this.btnCauHinhLCD.Size = new System.Drawing.Size(190, 22);
            this.btnCauHinhLCD.Text = "Cấu hình hiển thị CLD";
            this.btnCauHinhLCD.Visible = false;
            this.btnCauHinhLCD.Click += new System.EventHandler(this.btnCauHinhLCD_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDinhNghia,
            this.toolStripSeparator1,
            this.tạoDanhSáchToolStripMenuItem,
            this.btnLayTT,
            this.btnGoiSTT});
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(84, 22);
            this.toolStripDropDownButton2.Text = "Quản lý STT";
            // 
            // btnDinhNghia
            // 
            this.btnDinhNghia.Name = "btnDinhNghia";
            this.btnDinhNghia.Size = new System.Drawing.Size(155, 22);
            this.btnDinhNghia.Text = "Định nghĩa STT";
            this.btnDinhNghia.Click += new System.EventHandler(this.btnDinhNghia_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // tạoDanhSáchToolStripMenuItem
            // 
            this.tạoDanhSáchToolStripMenuItem.Name = "tạoDanhSáchToolStripMenuItem";
            this.tạoDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tạoDanhSáchToolStripMenuItem.Text = "Tạo danh sách";
            this.tạoDanhSáchToolStripMenuItem.Click += new System.EventHandler(this.tạoDanhSáchToolStripMenuItem_Click);
            // 
            // btnLayTT
            // 
            this.btnLayTT.Name = "btnLayTT";
            this.btnLayTT.Size = new System.Drawing.Size(155, 22);
            this.btnLayTT.Text = "Lấy STT";
            this.btnLayTT.Click += new System.EventHandler(this.btnLayTT_Click);
            // 
            // btnGoiSTT
            // 
            this.btnGoiSTT.Name = "btnGoiSTT";
            this.btnGoiSTT.Size = new System.Drawing.Size(155, 22);
            this.btnGoiSTT.Text = "Gọi STT";
            this.btnGoiSTT.Click += new System.EventHandler(this.btnGoiSTT_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xuấtLCDToolStripMenuItem,
            this.xuất4LCDToolStripMenuItem,
            this.xuất4LCDToolStripMenuItem1,
            this.lCDTuChonToolStripMenuItem});
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(42, 22);
            this.toolStripDropDownButton3.Text = "LCD";
            // 
            // xuấtLCDToolStripMenuItem
            // 
            this.xuấtLCDToolStripMenuItem.Name = "xuấtLCDToolStripMenuItem";
            this.xuấtLCDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xuấtLCDToolStripMenuItem.Text = "Xuất LCD";
            this.xuấtLCDToolStripMenuItem.Visible = false;
            this.xuấtLCDToolStripMenuItem.Click += new System.EventHandler(this.xuấtLCDToolStripMenuItem_Click);
            // 
            // xuất4LCDToolStripMenuItem
            // 
            this.xuất4LCDToolStripMenuItem.Name = "xuất4LCDToolStripMenuItem";
            this.xuất4LCDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xuất4LCDToolStripMenuItem.Text = "Xuất 2 LCD ";
            this.xuất4LCDToolStripMenuItem.Visible = false;
            this.xuất4LCDToolStripMenuItem.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // xuất4LCDToolStripMenuItem1
            // 
            this.xuất4LCDToolStripMenuItem1.Name = "xuất4LCDToolStripMenuItem1";
            this.xuất4LCDToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.xuất4LCDToolStripMenuItem1.Text = "Xuất 6 LCD";
            this.xuất4LCDToolStripMenuItem1.Click += new System.EventHandler(this.xuất4LCDToolStripMenuItem1_Click);
            // 
            // lCDTuChonToolStripMenuItem
            // 
            this.lCDTuChonToolStripMenuItem.Name = "lCDTuChonToolStripMenuItem";
            this.lCDTuChonToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lCDTuChonToolStripMenuItem.Text = "LCD tự chọn";
            this.lCDTuChonToolStripMenuItem.Click += new System.EventHandler(this.lCDTuChonToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 483);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Cấp và Gọi STT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        #endregion

        #region Events
        private void btnNhomKV_Click(object sender, EventArgs e)
        {
            frm_NhomKhuVuc frm = new frm_NhomKhuVuc();
            //frm.ShowDialog();
            frm.Show();
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            frm_KhuVuc frm = new frm_KhuVuc();
            //frm.ShowDialog();
            frm.Show();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            frm_PhongBan frm = new frm_PhongBan();
            //frm.ShowDialog();
            frm.Show();
        }

        private void btnNhomLCD_Click(object sender, EventArgs e)
        {
            frm_NhomLCD frm = new frm_NhomLCD();
            //frm.ShowDialog();
            //Screen[] screens = Screen.AllScreens;


            //if (Screen.AllScreens.Length > 1)
            //{
            //    frm.Location = Screen.AllScreens[1].WorkingArea.Location;
            //    frm.Width = Screen.AllScreens[1].WorkingArea.Width-10;
            //    frm.Height = Screen.AllScreens[1].WorkingArea.Height-10;
            //}
            //else
            //{
            //    frm.Location = Screen.AllScreens[0].WorkingArea.Location;
            //}
            frm.Show();
        }

        private void btnCauHinhLCD_Click(object sender, EventArgs e)
        {
            frm_CauHinhLCD frm = new frm_CauHinhLCD();
            //frm.ShowDialog();
            frm.Show();
        }

        private void btnDinhNghia_Click(object sender, EventArgs e)
        {
            frm_DinhNghiaSTT frm = new frm_DinhNghiaSTT();
            //frm.ShowDialog();
            frm.Show();
        }

        private void btnLayTT_Click(object sender, EventArgs e)
        {
            frm_CapSTT frm = new frm_CapSTT();
            //frm.ShowDialog();
            frm.Show();
        }

        private void btnGoiSTT_Click(object sender, EventArgs e)
        {
            frm_ChonCapSTT frm = new frm_ChonCapSTT(true);
            frm.lblBS.Visible = false;
            frm.slbBS.Visible = false;
            frm.Height -= 30;
            //frm.ShowDialog();
            frm.Show();
        }

        private void xuấtLCDToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //frmXuatLCD frm = new frmXuatLCD("PPhongA3", 1);
            //frm.Show();




            //frmXuatLCD frm = new frmXuatLCD();
            //frm.Show();

            //LibDal.AccessData dal = new LibDal.AccessData();
            //string sKhu = "01,02";
            //int i_userid = 1;
            //HISToltal.frmLCDtiepdonStt f = new HISToltal.frmLCDtiepdonStt(dal, true, i_userid, sKhu.ToString());
            //f.ShowDialog();

        }

        private void tạoDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TaoSoLieu frm = new DatabaseV2.frm_TaoSoLieu();
            frm.ShowDialog();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            //string MAPK1 = "";
            //string MAPK2 = "";
            //frm_ChonCapSTT f = new frm_ChonCapSTT(2);
            //f.ShowDialog();
            //MAPK1 = f.Makp1;
            //frm_ChonCapSTT f2 = new frm_ChonCapSTT(2);
            //f2.ShowDialog();
            //MAPK2 = f2.Makp1;

            //frmXuat2LCD frm = new frmXuat2LCD(MAPK1, 1, MAPK2);

            //Screen[] screens = Screen.AllScreens;


            //if (Screen.AllScreens.Length > 1)
            //{
            //    frm.Location = Screen.AllScreens[1].WorkingArea.Location;
            //}
            //else
            //{
            //    frm.Location = Screen.AllScreens[0].WorkingArea.Location;
            //}
            //frm.Show();



        }

        private void xuất4LCDToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            string MAPK1 = "";
            string MAPK2 = "";
            string MAPK3 = "";
            string MAPK4 = "";
            string MAPK5 = "";
            string MAPK6 = "";
            string manhom = "";
            string makhu = "";
            frm_ChonCapSTT f = new frm_ChonCapSTT(2, 1);
            f.ShowDialog();
            MAPK1 = f.MaKP;
            manhom = f.Manhom;
            makhu = f.Makhu;
            f = new frm_ChonCapSTT(2, 2, manhom, makhu);
            f.ShowDialog();
            MAPK2 = f.MaKP;
            manhom = f.Manhom;
            makhu = f.Makhu;
            f = new frm_ChonCapSTT(2, 2, manhom, makhu);
            f.ShowDialog();
            MAPK3 = f.MaKP;
            manhom = f.Manhom;
            makhu = f.Makhu;
            f = new frm_ChonCapSTT(2, 2, manhom, makhu);
            f.ShowDialog();
            MAPK4 = f.MaKP;
            manhom = f.Manhom;
            makhu = f.Makhu;
            f = new frm_ChonCapSTT(2, 2, manhom, makhu);
            f.ShowDialog();
            MAPK5 = f.MaKP;
            manhom = f.Manhom;
            makhu = f.Makhu;
            f = new frm_ChonCapSTT(2, 2, manhom, makhu);
            f.ShowDialog();
            MAPK6 = f.MaKP;
            manhom = f.Manhom;
            makhu = f.Makhu;
            frmXuat6LCD frm = new frmXuat6LCD(1, MAPK1, MAPK2, MAPK3, MAPK4, MAPK5, MAPK6);

            Screen[] screens = Screen.AllScreens;


            if (Screen.AllScreens.Length > 1)
            {
                frm.Location = Screen.AllScreens[1].WorkingArea.Location;
            }
            else
            {
                frm.Location = Screen.AllScreens[0].WorkingArea.Location;
            }
            frm.Show();

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTesst frm = new frmTesst();
            //frm.ShowDialog();
            frm.Show();
        }

        private void chuKỳGiờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DanhMucGio frm = new frm_DanhMucGio();
            frm.Show();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            _bus.DeleteDataCapSo();
        }

        private void tạoDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ChonCapSTT frm = new frm_ChonCapSTT(false);
            frm.Text = "Chọn quét số thứ tự";
            frm.lblBS.Visible = false;
            frm.slbBS.Visible = false;
            frm.Height -= 30;
            if (!_bus.CheckOpened(frm.Text))
            {
                frm.Show();
            }
            else
            {
                Application.OpenForms[frm.Name].Focus();
            }
        }

        private void lCDTuChonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ChonLCD frm = new frm_ChonLCD();
            if (!_bus.CheckOpened(frm.Text))
            {
                frm.Show();
            }
            else
            {
                Application.OpenForms[frm.Name].Focus();
            }
        } 
        #endregion
    }
}
