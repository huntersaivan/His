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
using DevComponents.DotNetBar;

namespace E00_STT
{
    public partial class frm_LCD1 : DevComponents.DotNetBar.Office2007Form
    {

        #region Biến toàn cục

        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string lpszName, int hModule, int dwFlags);
        public SortedList<string, usc_MaTran> _lst = new SortedList<string, usc_MaTran>();
        public SortedList<string, usc_Dong> _lstDong = new SortedList<string, usc_Dong>();
        public static usc_MaTran _maTranCLD = new usc_MaTran();
        private usc_TieuDeDong uscTieuDe;
        private Api_Common _api = new Api_Common();
        private clsBUS _bus = new clsBUS();
        private double _tyle = 1;
        private DataTable _tbvung = new DataTable();
        private List<Color> lstco = new List<Color>();
        private string _userError = "";
        private string _systemError = "";
        private int count = 0;
        private FontStyle _fontStype;
        private DataRow _drDinhDang;
        private DataTable _dtNhomLCD = new DataTable();
        private DataTable _dtCauHinh = new DataTable();
        private frm_NhomLCD frmLCD = new frm_NhomLCD();
        private usc_MaTran _uscMaTran = new usc_MaTran();
        private usc_Dong _uscDong = new usc_Dong();
        private string _lstMaKP;
        private int _loai;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        #endregion

        #region Khởi tạo
        public frm_LCD1()
        {
            InitializeComponent();
        }
        public frm_LCD1(string ID)
        {
            InitializeComponent();
            GetData(ID);

        }
        public frm_LCD1(string ID, string lstKP)
        {
            InitializeComponent();
            GetData(ID);
            _lstMaKP = lstKP;

        }
        #endregion

        #region Phương thức

        #region protected
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        #endregion

        #region Public
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
                int height = this.Height / dong;
                int width = this.Width / cot;

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
        public usc_TieuDeDong UscTieuDe
        {
            get { return uscTieuDe; }
            set { uscTieuDe = value; }

        }
        public double Tyle
        {
            set
            {
                _tyle = value;
            }
        }
        #endregion

        #region private
        private void Get_CauHinh()
        {
            try
            {
                _dtCauHinh = _api.Search(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang);
            }
            catch
            {
                _dtCauHinh = null;
            }
        }
        private void GetData(string ID)
        {
            try
            {
                Dictionary<string, string> dicLike = new Dictionary<string, string>();
                dicLike.Add(cls_STT_NhomLCD.col_ID, ID);

                _dtNhomLCD = _api.Search(ref _userError, ref _systemError, cls_STT_NhomLCD.tb_TenBang, andEqual: true, dicEqual: dicLike);
            }
            catch
            {
            }
        }
        private void Show_ChiTiet()
        {
            if (_dtNhomLCD == null || _dtNhomLCD.Rows.Count == 0)
            {
                TA_MessageBox.MessageBox.Show("loi");
                return;
            }
            try
            {
                _loai = int.Parse(_dtNhomLCD.Rows[0][cls_STT_NhomLCD.col_Loai].ToString());
                double thoigian = double.Parse(_dtNhomLCD.Rows[0][cls_STT_NhomLCD.col_ThoiGianChuyenMau].ToString());
                timer1.Interval = Convert.ToInt32(thoigian * 1000);
                int SoDong = int.Parse(_dtNhomLCD.Rows[0][cls_STT_NhomLCD.col_SoDong].ToString());
                int SoCot = int.Parse(_dtNhomLCD.Rows[0][cls_STT_NhomLCD.col_SoCot].ToString());
                if (_loai == 0)
                {
                    Set_ListMaTran(_uscMaTran, SoDong, SoCot);
                    ShowLCD(SoDong, SoCot);
                }
                else
                {
                    Set_ListMaTran(_uscDong, SoDong);
                    ShowLCD(SoDong);
                }

                DataTable dtViTri;
                try
                {
                    dtViTri = _dtCauHinh.Select(string.Format("MaNhom = '{0}'", _dtNhomLCD.Rows[0][cls_STT_NhomLCD.col_Ma].ToString()), "vitri asc").CopyToDataTable();

                    if (_loai == 0)
                    {

                        foreach (usc_MaTran item in _lst.Values)
                        {
                            item.LoadVitri(dtViTri);
                        }
                    }


                }
                catch
                {
                    dtViTri = new DataTable();
                    if (_loai == 0)
                    {

                        foreach (usc_MaTran item in _lst.Values)
                        {
                            item.LoadVitri(dtViTri);
                        }
                    }
                }

                string[] str = _dtNhomLCD.Rows[0][cls_STT_NhomLCD.col_MaMau].ToString().Split('~');
                lstco.Clear();
                int soluongmau = str.Length;
                //   Mau(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    lstco.Add(Color.FromArgb(int.Parse(str[i])));
                }

                #region Load Tieu De
                LoadTieuDe("TD");
                LoadTieuDe("VG");
                LoadTieuDe("VC");
                LoadTieuDe("KV");
                LoadTieuDe("BS");
                #endregion

            }
            catch
            {

            }
        }
        private void LoadTieuDe(string Ma)
        {
            try
            {
                //string Ma = ((DataRowView)cboVung.ComboBox.Items[cboVung.ComboBox.SelectedIndex])["Ma"].ToString();
                _drDinhDang = _dtCauHinh.Select(string.Format("Ma like '{0}%' and MaNhom = '{1}'", Ma
                    , _dtNhomLCD.Rows[0][cls_STT_NhomLCD.col_Ma].ToString())).CopyToDataTable().Rows[0];
            }
            catch
            {
                _drDinhDang = null;
            }
            int mavung = int.Parse(_tbvung.Select("MA = '" + Ma + "'")[0]["So"].ToString());
            Load_CauHinh(mavung);
        }
        private void Set_Font(string fontName, float fontSize, int _maVung)
        {
            if (_loai == 0)
            {
                foreach (usc_MaTran item in _lst.Values)
                {
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.Font = new Font(fontName, fontSize);
                            break;
                        case 2:
                            foreach (LabelX lb in item._lstLBcho)
                            {
                                lb.Font = new Font(fontName, fontSize);
                            }
                            break;
                        case 3:
                            item.lblKhuVuc.Font = new Font(fontName, fontSize);
                            break;
                        case 4:
                            item.lblBacSi.Font = new Font(fontName, fontSize);
                            break;
                        default:
                            item.lblTieuDe.Font = new Font(fontName, fontSize);
                            break;
                    }
                }
            }
            else if (_loai == 1)
            {
                foreach (usc_Dong item in _lstDong.Values)
                {
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.Font = new Font(fontName, fontSize);
                            break;
                        case 2:
                            item.lblCho.Font = new Font(fontName, fontSize);
                            break;
                        case 3:
                            item.lblKhuVuc.Font = new Font(fontName, fontSize);
                            break;
                        case 4:
                            item.lblBacSi.Font = new Font(fontName, fontSize);
                            break;
                        default:
                            UscTieuDe.lblMoiSo.Font = new Font(fontName, fontSize);
                            UscTieuDe.lblSoTT.Font = new Font(fontName, fontSize);
                            UscTieuDe.lblTenPK.Font = new Font(fontName, fontSize);

                            break;
                    }
                }
            }

        }
        private void Set_Font(bool bold, bool italia, bool underline, int _maVung)
        {
            if (_loai == 0)
            {
                switch (_maVung)
                {
                    case 1:
                        _fontStype = _lst.Values[0].lblGoi.Font.Style;
                        break;
                    case 2:
                        try
                        {
                            _fontStype = _lst.Values[0]._lstLBcho[0].Font.Style;
                        }
                        catch
                        {
                            _fontStype = FontStyle.Bold;
                        }
                        break;
                    case 3:
                        _fontStype = _lst.Values[0].lblKhuVuc.Font.Style;
                        break;
                    case 4:
                        _fontStype = _lst.Values[0].lblBacSi.Font.Style;
                        break;
                    default:
                        _fontStype = _lst.Values[0].lblTieuDe.Font.Style;
                        break;
                }

                if (bold)
                {
                    _fontStype = _fontStype | FontStyle.Bold;
                }
                else if (_fontStype.ToString().Contains(FontStyle.Bold.ToString()))
                {
                    _fontStype = _fontStype ^ FontStyle.Bold;
                }

                if (italia)
                {
                    _fontStype = _fontStype | FontStyle.Italic;
                }
                else if (_fontStype.ToString().Contains(FontStyle.Italic.ToString()))
                {
                    _fontStype = _fontStype ^ FontStyle.Italic;
                }

                if (underline)
                {
                    _fontStype = _fontStype | FontStyle.Underline;
                }
                else if (_fontStype.ToString().Contains(FontStyle.Underline.ToString()))
                {
                    _fontStype = _fontStype ^ FontStyle.Underline;
                }

                foreach (usc_MaTran item in _lst.Values)
                {
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.Font = new Font(item.lblGoi.Font, _fontStype);
                            break;
                        case 2: //item.lblCho.Font = new Font(item.lblCho.Font, _fontStype);
                            foreach (LabelX lb in item._lstLBcho)
                            {
                                lb.Font = new Font(lb.Font, _fontStype);
                            }
                            break;
                        case 3:
                            item.lblKhuVuc.Font = new Font(item.lblKhuVuc.Font, _fontStype);
                            break;
                        case 4:
                            item.lblBacSi.Font = new Font(item.lblBacSi.Font, _fontStype);
                            break;
                        default:
                            item.lblTieuDe.Font = new Font(item.lblTieuDe.Font, _fontStype);
                            break;
                    }
                }
            }
            else if (_loai == 1)
            {
                switch (_maVung)
                {
                    case 1:
                        _fontStype = _lstDong.Values[0].lblGoi.Font.Style;
                        break;
                    case 2:
                        _fontStype = _lstDong.Values[0].lblCho.Font.Style;
                        break;
                    case 3:
                        _fontStype = _lstDong.Values[0].lblKhuVuc.Font.Style;
                        break;
                    case 4:
                        _fontStype = _lstDong.Values[0].lblBacSi.Font.Style;
                        break;
                    default:
                        _fontStype = UscTieuDe.lblMoiSo.Font.Style;
                        break;
                }

                if (bold)
                {
                    _fontStype = _fontStype | FontStyle.Bold;
                }
                else if (_fontStype.ToString().Contains(FontStyle.Bold.ToString()))
                {
                    _fontStype = _fontStype ^ FontStyle.Bold;
                }

                if (italia)
                {
                    _fontStype = _fontStype | FontStyle.Italic;
                }
                else if (_fontStype.ToString().Contains(FontStyle.Italic.ToString()))
                {
                    _fontStype = _fontStype ^ FontStyle.Italic;
                }

                if (underline)
                {
                    _fontStype = _fontStype | FontStyle.Underline;
                }
                else if (_fontStype.ToString().Contains(FontStyle.Underline.ToString()))
                {
                    _fontStype = _fontStype ^ FontStyle.Underline;
                }

                foreach (usc_Dong item in _lstDong.Values)
                {
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.Font = new Font(item.lblGoi.Font, _fontStype);
                            break;
                        case 2:
                            item.lblCho.Font = new Font(item.lblCho.Font, _fontStype);
                            break;
                        case 3:
                            item.lblKhuVuc.Font = new Font(item.lblKhuVuc.Font, _fontStype);
                            break;
                        case 4:
                            item.lblBacSi.Font = new Font(item.lblBacSi.Font, _fontStype);
                            break;
                        default:
                            UscTieuDe.lblMoiSo.Font = new Font(UscTieuDe.lblMoiSo.Font, _fontStype); ;
                            UscTieuDe.lblSoTT.Font = new Font(UscTieuDe.lblSoTT.Font, _fontStype); ;
                            UscTieuDe.lblTenPK.Font = new Font(UscTieuDe.lblTenPK.Font, _fontStype); ;
                            break;
                    }
                }
            }

        }
        private void Load_CauHinh(int _maVung)
        {
            int hienthi = int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_TamNgung].ToString());
            try
            {
                #region Hiển thị


                if (_loai == 0)
                {
                    foreach (usc_MaTran item in _lst.Values)
                    {
                        bool giatri = hienthi == 0;
                        switch (_maVung)
                        {
                            case 1:
                                item.lblGoi.Visible = giatri;
                                item.pnlGoi.Visible = giatri;
                                break;
                            case 2:
                                item.pnlCho.Visible = giatri;
                                foreach (var lb in item._lstLBcho)
                                {
                                    lb.Visible = giatri;
                                }
                                break;
                            case 3:
                                item.lblKhuVuc.Visible = giatri;
                                item.lblKhuVuc.Visible = giatri;
                                break;
                            case 4:
                                item.lblBacSi.Visible = giatri;
                                item.pnlBS.Visible = giatri;
                                break;
                            default:
                                item.lblTieuDe.Visible = giatri;
                                item.pnlTieuDe.Visible = giatri;
                                break;
                        }
                    }
                }
                else if (_loai == 1)
                {
                    foreach (usc_Dong item in _lstDong.Values)
                    {
                        bool giatri = hienthi == 0;
                        switch (_maVung)
                        {
                            case 1:
                                item.lblGoi.Visible = giatri;
                                break;
                            case 2:
                                item.lblCho.Visible = giatri;
                                break;
                            case 3:
                                item.lblKhuVuc.Visible = giatri;
                                break;
                            case 4:
                                item.lblBacSi.Visible = giatri;
                                break;
                            default:
                                break;
                        }
                    }
                }
                #endregion
            }
            catch
            {

            }

            #region chieu cao
            try
            {
                int chieucao = (int)(int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_ChieuCao].ToString()) * _tyle);
                if (_loai == 0)
                {
                    foreach (usc_MaTran item in _lst.Values)
                    {
                        switch (_maVung)
                        {
                            case 1:
                                if (item.pnlGoi.Visible)
                                {
                                    item.pnlGoi.Height = chieucao;
                                }
                                else
                                {
                                    item.pnlGoi.Height = 0;
                                }
                                break;
                            case 2:
                                if (item.pnlGoi.Visible)
                                {
                                    item.pnlCho.Height = chieucao;
                                }
                                else
                                {
                                    item.pnlCho.Height = 0;
                                }
                                break;
                            case 3:
                                if (item.pnlKhuVuc.Visible)
                                {
                                    item.pnlKhuVuc.Height = chieucao;
                                }
                                else
                                {
                                    item.pnlKhuVuc.Height = 0;
                                }
                                break;
                            case 4:
                                if (item.pnlBS.Visible)
                                {
                                    item.pnlBS.Height = item.lblBacSi.Height = chieucao;

                                }
                                else
                                {
                                    item.pnlBS.Height = item.lblBacSi.Height = 0;
                                }
                                break;
                            default:
                                if (item.pnlTieuDe.Visible)
                                {
                                    item.lblTieuDe.Height = item.pnlTieuDe.Height = chieucao;
                                }
                                else
                                {
                                    item.lblTieuDe.Height = item.pnlTieuDe.Height = 0;
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {

            }
            #endregion

            #region số lượng
            try
            {
                int soluongcho = int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_SoLuong].ToString());
                if (_loai == 0)
                {
                    if (_maVung == 2)
                    {

                        foreach (usc_MaTran item in _lst.Values)
                        {
                            item.SoluongCho = soluongcho;
                        }
                    }
                }
            }
            catch
            {

            }
            #endregion

            #region font + size
            try
            {
                string font = _drDinhDang[cls_STT_CauHinhLCD.col_Font].ToString();
                float Size = float.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_Size].ToString());
                Set_Font(font, Size, _maVung);
            }
            catch
            {

            }
            #endregion

            #region aligment
            try
            {

                int so = int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_DinhDang].ToString());
                switch (so)
                {
                    case 1:
                        Set_Font(true, false, false, _maVung);

                        break;
                    case 2:
                        Set_Font(false, true, false, _maVung);
                        break;
                    case 3:
                        Set_Font(false, false, true, _maVung);

                        break;
                    case 4:

                        Set_Font(true, true, false, _maVung);
                        break;
                    case 5:

                        Set_Font(true, false, true, _maVung);
                        break;
                    case 6:

                        Set_Font(false, true, true, _maVung);
                        break;
                    case 7:
                        Set_Font(true, true, true, _maVung);

                        break;
                    default:
                        Set_Font(false, false, false, _maVung);
                        break;
                }

            }
            catch
            {

            }
            #endregion

            #region Load Alignment
            try
            {
                StringAlignment Alignment = new StringAlignment();
                if (!string.IsNullOrEmpty(_drDinhDang[cls_STT_CauHinhLCD.col_CanLe].ToString()))
                {
                    switch (_drDinhDang[cls_STT_CauHinhLCD.col_CanLe].ToString()[0])
                    {
                        case 'N':
                            Alignment = StringAlignment.Near;
                            break;

                        case 'C':
                            Alignment = StringAlignment.Center;
                            break;
                        case 'F':
                            Alignment = StringAlignment.Far;
                            break;
                        default:
                            Alignment = StringAlignment.Center;
                            break;
                    }
                }


                if (_loai == 0)
                {
                    foreach (usc_MaTran item in _lst.Values)
                    {
                        switch (_maVung)
                        {
                            case 1:
                                item.lblGoi.TextAlignment = Alignment;
                                break;
                            case 2: //item.lblCho.TextAlignment = Alignment;
                                foreach (LabelX lb in item._lstLBcho)
                                {
                                    lb.TextAlignment = Alignment;
                                }
                                break;
                            case 3:
                                item.lblKhuVuc.TextAlignment = Alignment;
                                break;
                            case 4:
                                item.lblBacSi.TextAlignment = Alignment;
                                break;
                            default:
                                item.lblTieuDe.TextAlignment = Alignment;
                                break;
                        }
                    }
                }
                else if (_loai == 1)
                {
                    foreach (usc_Dong item in _lstDong.Values)
                    {
                        switch (_maVung)
                        {
                            case 1:
                                item.lblGoi.TextAlignment = Alignment;
                                break;
                            case 2:
                                item.lblCho.TextAlignment = Alignment;
                                //foreach (LabelX lb in _uscMaTran._lstLBcho)
                                //{
                                //    lb.TextAlignment = Alignment;
                                //}
                                break;
                            case 3:
                                item.lblKhuVuc.TextAlignment = Alignment;
                                break;
                            case 4:
                                item.lblBacSi.TextAlignment = Alignment;
                                break;
                            default:
                                item.lblKhuVuc.TextAlignment = Alignment;
                                break;
                        }
                    }
                }
            }
            catch
            {

            }
            #endregion

            #region Load màu nền
            try
            {
                Color color = Color.FromArgb(int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_MauNen].ToString()));

                if (_loai == 0)
                {
                    foreach (usc_MaTran item in _lst.Values)
                    {
                        switch (_maVung)
                        {
                            case 1:
                                item.lblGoi.BackColor = color;
                                break;
                            case 2:
                                foreach (LabelX lb in item._lstLBcho)
                                {
                                    lb.BackColor = color;
                                }
                                break;
                            case 3:
                                item.lblKhuVuc.BackColor = color;
                                break;
                            case 4:
                                item.lblBacSi.BackColor = color;
                                break;
                            default:
                                item.lblTieuDe.BackColor = color;
                                break;
                        }
                    }
                }
                else if (_loai == 1)
                {
                    foreach (usc_Dong item in _lstDong.Values)
                    {
                        switch (_maVung)
                        {
                            case 1:
                                item.lblGoi.BackColor = color;
                                break;
                            case 2:
                                item.lblCho.BackColor = color;
                                //foreach (LabelX lb in _uscMaTran._lstLBcho)
                                //{
                                //    lb.BackColor = color;
                                //}
                                break;
                            case 3:
                                item.lblKhuVuc.BackColor = color;
                                break;
                            case 4:
                                item.lblBacSi.BackColor = color;
                                break;
                            default:
                                item.lblKhuVuc.BackColor = color;
                                break;
                        }
                    }
                }
            }
            catch
            {

            }
            #endregion

            #region Load màu chữ
            try
            {
                Color color = Color.FromArgb(int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_MauChu].ToString()));

                if (_loai == 0)
                {
                    foreach (usc_MaTran item in _lst.Values)
                    {
                        switch (_maVung)
                        {
                            case 1:
                                item.lblGoi.ForeColor = color;
                                break;
                            case 2: //item.lblCho.ForeColor = color;
                                foreach (LabelX lb in item._lstLBcho)
                                {
                                    lb.ForeColor = color;
                                }
                                break;
                            case 3:
                                item.lblKhuVuc.ForeColor = color;
                                break;
                            case 4:
                                item.lblBacSi.ForeColor = color;
                                break;
                            default:
                                item.lblTieuDe.ForeColor = color;
                                break;
                        }
                    }
                }
                else if (_loai == 1)
                {
                    foreach (usc_Dong item in _lstDong.Values)
                    {
                        switch (_maVung)
                        {
                            case 1:
                                item.lblGoi.ForeColor = color;
                                break;
                            case 2:
                                item.lblCho.ForeColor = color;
                                //foreach (LabelX lb in _uscMaTran._lstLBcho)
                                //{
                                //    lb.ForeColor = color;
                                //}
                                break;
                            case 3:
                                item.lblKhuVuc.ForeColor = color;
                                break;
                            case 4:
                                item.lblBacSi.ForeColor = color;
                                break;
                            default:
                                item.lblKhuVuc.ForeColor = color;
                                break;
                        }
                    }
                }
            }
            catch
            {

            }
            #endregion
        }

        #region Set ma trận LCD
        private void Set_ListMaTran(usc_MaTran uscMaTran00, int dong, int cot)
        {
            if (dong * cot == _lst.Values.Count)
            {
                return;
            }

            _lst.Clear();

            int height = this.Height / dong;
            int width = this.Width / cot;
            usc_MaTran usc;

            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        usc = uscMaTran00;
                    }
                    else
                    {
                        usc = new usc_MaTran();

                    }
                    usc.Name = "lcd" + (i * cot + j).ToString().PadLeft(5, '0');
                    usc.Location = new Point(j * width, i * height);
                    usc.AlamRing += new System.EventHandler(usc_AlamRing);
                    usc.Dock = DockStyle.Fill;
                    _lst.Add(usc.Name, usc);
                }
            }
            //Load_DinhDang();
        }
        private void Set_ListMaTran(usc_Dong uscMaTran00, int dong)
        {
            if (dong == _lstDong.Values.Count)
            {
                return;
            }

            _lstDong.Clear();

            UscTieuDe = new usc_TieuDeDong();
            int height = this.Height / dong;

            usc_Dong usc;

            for (int i = 0; i < dong; i++)
            {

                if (i == 0)
                {
                    usc = uscMaTran00;
                }
                else
                {
                    usc = new usc_Dong();

                }
                usc.Name = "lcd" + i;
                //sc.Location = new Point(j * width, i * height);
                usc.AlamRing += new System.EventHandler(usc_AlamRing);
                usc.Dock = DockStyle.Top;
                _lstDong.Add(usc.Name, usc);

            }
            // Load_DinhDang();
        }
        #endregion 
        #endregion

        #endregion

        #region Events

        private void frm_LCD_Load(object sender, EventArgs e)
        {
            _tbvung.Columns.Add("MA");
            _tbvung.Columns.Add("So");
            _tbvung.Columns.Add("Ten");
            _tbvung.Rows.Add("VG", "1", "Vùng Gọi");
            _tbvung.Rows.Add("TD", "5", "Tiêu Đề");
            _tbvung.Rows.Add("VC", "2", "Vùng Chờ");
            _tbvung.Rows.Add("BS", "4", "Bác Sĩ");
            _tbvung.Rows.Add("KV", "3", "Khu Vực");
            _api.KetNoi();
            Get_CauHinh();
            Show_ChiTiet();
            if (!string.IsNullOrEmpty(_lstMaKP))
            {
                if (_loai == 0)
                {
                    int i = 0;
                    foreach (usc_MaTran item in _lst.Values)
                    {
                        item.Makp = _lstMaKP.Split('_')[i];
                        i++;
                    }
                }
                else
                {
                    int i = 0;
                    foreach (usc_Dong item in _lstDong.Values)
                    {
                        item.Makp = _lstMaKP.Split('_')[i];
                        i++;
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (tocDo == 1)
            //{

            //}
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
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
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                Color cl = new Color();
                if (lstco.Count > 1)
                {
                    cl = lstco[count];
                    if (_loai == 0)
                    {
                        foreach (usc_MaTran item in _lst.Values)
                        {
                            if (item.changecolo)
                            {
                                item.lblGoi.ForeColor = cl;
                            }
                        }
                    }
                    else if (_loai == 1)
                    {
                        foreach (usc_Dong item in _lstDong.Values)
                        {
                            if (item.changecolo)
                            {
                                item.lblGoi.ForeColor = cl;
                            }
                        }
                    }
                }
                count++;
                if (lstco.Count - 1 <= count)
                {
                    count = 0;
                }
            }
            catch
            { }
        }
        private void frm_LCD1_Resize(object sender, EventArgs e)
        {

        }
        private void usc_AlamRing(object sender, EventArgs e)
        {
            try
            {
                PlaySound("..\\..\\wav\\wav1.wav", 0, 1);
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
