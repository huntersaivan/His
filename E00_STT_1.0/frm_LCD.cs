using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E00_Common;
using E00_Model;
using System.Runtime.InteropServices;

namespace E00_STT
{
    public partial class frm_LCD : DevComponents.DotNetBar.Office2007Form
    {
        #region Biến toàn cục
        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string lpszName, int hModule, int dwFlags);
        public SortedList<string, usc_MaTran> _lst = new SortedList<string, usc_MaTran>();
        public SortedList<string, usc_Dong> _lstDong = new SortedList<string, usc_Dong>();
        public static usc_MaTran _maTranCLD = new usc_MaTran();
        private usc_TieuDeDong uscTieuDe;
        private List<Color> lstco = new List<Color>();
        private clsBUS _bus = new clsBUS();
        private bool _isFullScreen = true;
        private DataTable _dtCauHinh = new DataTable();
        public frm_NhomLCD FrmPa;
        private const int CP_NOCLOSE_BUTTON = 0x200;

        #endregion

        #region Hàm Khởi tạo
        public frm_LCD()
        {
            InitializeComponent();
        }
        #endregion

        #region Phương thức
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public static void Load_DinhDang()
        {
            try
            {

                _maTranCLD.lblTieuDe.ForeColor = Color.White;
                _maTranCLD.lblTieuDe.BackColor = Color.Yellow;
            }
            catch
            {
            }
        }
        public usc_TieuDeDong UscTieuDe
        {
            get { return uscTieuDe; }
            set { uscTieuDe = value; }

        }
        public void Load_CauHinh(string Manhom)
        {

        }
        private void frm_LCD_Load(object sender, EventArgs e)
        {

        }
        public void showOnScreen(int screenNumber)
        {
            Screen[] screens = Screen.AllScreens;

            if (screenNumber >= 0 && screenNumber < screens.Length)
            {
                bool maximised = false;
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                    maximised = true;
                }
                Location = screens[screenNumber].WorkingArea.Location;
                if (maximised)
                {
                    WindowState = FormWindowState.Maximized;
                }
            }
        }
        public void ShowLCD(int dong, int cot)
        {
            try
            {
                this.Controls.Clear();
                int height = Screen.PrimaryScreen.Bounds.Height / dong;
                int width = Screen.PrimaryScreen.Bounds.Width / cot;

                for (int i = 0; i < dong; i++)
                {
                    for (int j = 0; j < cot; j++)
                    {
                        Panel x = new Panel();

                        x.Location = new Point(j * width, i * height);
                        x.Size = new System.Drawing.Size(width, height);
                        usc_MaTran usc = _lst.Values[i * cot + j];
                        usc.AlamRing += new EventHandler(allamring);
                        //usc.lblTieuDe.TextAlignment = _lst.Values[0].lblTieuDe.TextAlignment;
                        usc.Location = new Point(j * width, i * height);
                        usc.Dock = DockStyle.Fill;
                        x.Controls.Add(usc);
                        this.Controls.Add(x);
                    }
                }
            }
            catch
            {
            }
        }
        public void ShowLCD(int dong)
        {
            try
            {
                this.Controls.Clear();

                usc_TieuDeDong usctieude = this.uscTieuDe;
                usctieude.Dock = DockStyle.Top;
                this.uscTieuDe = usctieude;
                this.Controls.Add(usctieude);

                TableLayoutPanel x = new TableLayoutPanel();

                x.ColumnCount = 1;
                for (int i = 0; i < dong; i++)
                {
                    usc_Dong usc = _lstDong.Values[i];
                    usc.AlamRing += new EventHandler(allamring);
                    x.Controls.Add(usc, 0, i);
                    usc.Dock = DockStyle.Fill;
                }
                x.RowCount = dong;

                x.Dock = DockStyle.Fill;
                for (int i = 0; i < dong; i++)
                {
                    //usc.lblTieuDe.TextAlignment = _lst.Values[0].lblTieuDe.TextAlignment;
                    x.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / dong));

                }
                this.Controls.Add(x);

                x.BringToFront();
            }
            catch
            {
            }
        }
        #endregion

        #region Events

        private void cấuHìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmPa != null)
            {
                if (!_bus.CheckOpened(FrmPa.Text))
                {
                    FrmPa.Show();
                }
                else
                {
                    Application.OpenForms[FrmPa.Name].Show();
                    Application.OpenForms[FrmPa.Name].Focus();
                }

                foreach (usc_MaTran item in _lst.Values)
                {
                    item.timer1.Stop();
                }
                foreach (usc_Dong item in _lstDong.Values)
                {
                    item.timer1.Stop();
                }
                FrmPa.VisibleChanged += new EventHandler(FrmPa_VisibleChanged);
            }
            else
            {
                FrmPa.Focus();
            }
        }

        void FrmPa_VisibleChanged(object sender, EventArgs e)
        {
            foreach (usc_MaTran item in _lst.Values)
            {
                if (!string.IsNullOrEmpty(item.Makp))
                {
                    item.timer1.Start();
                }
            }
            foreach (usc_Dong item in _lstDong.Values)
            {
                if (!string.IsNullOrEmpty(item.Makp))
                {
                    item.timer1.Start();
                }
            }
        }

        private void frm_LCD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FrmPa != null)
            {

                #region Kiểm tra nếu màn hình phụ đang chạy thì tắt đi
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "frm_LCD1")
                    {
                        frm.Close();
                        break;
                    }
                } 
                #endregion

                #region Xử lý timer và truyền mã kp qua màn hình phụ
                FrmPa.lstMaKPShow = "";
                foreach (usc_MaTran item in _lst.Values)
                {
                    item.timer1.Stop();
                    FrmPa.lstMaKPShow += item.Makp + "_";
                }
                foreach (usc_Dong item in _lstDong.Values)
                {
                    item.timer1.Stop();
                    FrmPa.lstMaKPShow += item.Makp + "_";
                } 
                #endregion

                frm_LCD1 frm1 = new frm_LCD1(FrmPa.IDShow, FrmPa.lstMaKPShow);
                Screen[] screens = Screen.AllScreens;
                if (Screen.AllScreens.Length > 1)
                {
                    if (_isFullScreen)
                    {
                        frm1.WindowState = FormWindowState.Maximized;
                        frm1.Location = Screen.AllScreens[1].WorkingArea.Location;
                        frm1.Show();
                        FrmPa.Close();
                    }
                    else
                    {
                        frm1.Location = new Point(Screen.AllScreens[1].WorkingArea.Location.X + 25, Screen.AllScreens[1].WorkingArea.Location.Y + 10);
                        frm1.Width = Screen.AllScreens[1].WorkingArea.Width - 50;
                        frm1.Height = Screen.AllScreens[1].WorkingArea.Height - 10;
                        frm1.Tyle = (double)(frm1.Height) / this.Height;
                        frm1.Show();
                        FrmPa.Close();
                    }
                }
                else
                {
                    if (TA_MessageBox. MessageBox.Show("Chưa sử dụng màn hình phụ! \n Bạn có muốn tiếp tục không?", TA_MessageBox.MessageIcon.Question) == DialogResult.No)
                    {
                        this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.frm_LCD_FormClosing);
                        this.Close();
                        FrmPa.Close();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void allamring(object sender, EventArgs e)
        {
            try
            {
                PlaySound("wav\\wav1.wav", 0, 1);
            }
            catch (Exception)
            {
            }
        }

        private void chọnPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_lst.Count > 0)
            {
                string manhom = "";
                string makhu = "";
                int i = 1;
                foreach (usc_MaTran item in _lst.Values)
                {

                    if (i == 1)
                    {
                        frm_ChonCapSTT f = new frm_ChonCapSTT(2, i);
                        f.ShowDialog();
                        item.Makp = f.MaKP;
                        item.MaBS = f.MaBS;
                        manhom = f.Manhom;
                        makhu = f.Makhu;
                    }
                    else
                    {
                        frm_ChonCapSTT f = new frm_ChonCapSTT(2, i, manhom, makhu);
                        f.Height -= 30;
                        f.ShowDialog();
                        item.Makp = f.MaKP;
                        item.MaBS = f.MaBS;
                        manhom = f.Manhom;
                        makhu = f.Makhu;
                    }
                    i++;

                }

            }
            else if (_lstDong.Count > 0)
            {
                string manhom = "";
                string makhu = "";
                int i = 1;
                foreach (usc_Dong item in _lstDong.Values)
                {

                    if (i == 1)
                    {
                        frm_ChonCapSTT f = new frm_ChonCapSTT(2, i);
                        f.ShowDialog();
                        item.lblKhuVuc.Text = _bus.GetTenKP(f.MaKP);
                        item.Makp = f.MaKP;
                        manhom = f.Manhom;
                        makhu = f.Makhu;
                    }
                    else
                    {
                        frm_ChonCapSTT f = new frm_ChonCapSTT(2, i, manhom, makhu);
                        f.ShowDialog();
                        item.lblKhuVuc.Text = _bus.GetTenKP(f.MaKP);
                        item.Makp = f.MaKP;
                        manhom = f.Manhom;
                        makhu = f.Makhu;
                    }
                    i++;

                }
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.frm_LCD_FormClosing);
            this.Close();
            FrmPa.Close();
        }

        private void btnFullManHinh_Click(object sender, EventArgs e)
        {
            _isFullScreen = true;
            this.Close();
        }

        private void btnVuaManHinh_Click(object sender, EventArgs e)
        {
            _isFullScreen = false;
            this.Close();
        }

        #endregion


    }
}
