using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using E00_Base;
using E00_Common;
using E00_Model;

using E00_System;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;

namespace E00_STT
{
    public partial class frm_NhomLCD : frm_DanhMuc
    {
        #region Biến toàn cục
        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string lpszName, int hModule, int dwFlags);
        private List<Color> lstco = new List<Color>();
        private string _lstMaKPShow = "";
        private string _IDShow = "";
        private int _rowIndex = 0;
        private Api_Common _api = new Api_Common();
        private clsBUS _bus = new clsBUS();
        private bool _isAdd = false;
        private bool _isLoadForm = false;
        private frm_LCD _frm;
        private string _userError = "";
        private string _systemError = "";
        private string _lstID = "";
        private string _lstTen = "";
        public static string Loai = "";
        private bool _isCheck = false;
        private int count = 0;
        usc_MaTran _uscMaTran = new usc_MaTran();
        usc_Dong _uscDong = new usc_Dong();
        private FontStyle _fontStype;
        private int _maVung = 0;
        private string _maNhomLCD = "";
        private DataTable _dtCauHinh = new DataTable();
        private DataRow _drDinhDang = null;
        #endregion

        #region Khởi tạo
        public frm_NhomLCD()
        {
            _isLoadForm = true;
            InitializeComponent();
            _api.KetNoi();
            _uscMaTran = new usc_MaTran();
            _uscDong = new usc_Dong();
            _isLoadForm = false;
            _frm = new frm_LCD();
            _frm.FrmPa = this;

        }

        #endregion

        #region Phương thức

        #region Protected Override
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }


        protected override void LoadData()
        {
            _isCheck = false;
            TimKiem();
            base.LoadData();
            _isCheck = true;
            //if ( cboLoai.SelectedIndex == -1)
            //{
            //    cboLoai.SelectedIndex = 0;
            //}

        }

        protected override void Them()
        {
            base.Them();
            _isAdd = true;
            txtTen.Text = "";
            itgSoDong.Value = 1;
            itgSoCot.Value = 1;


            cboLoai.SelectedIndex = 0;
            cboLoai_SelectedIndexChanged(null, null);
            chkTamNgung.Checked = false;
            cboLoai.Focus();
        }

        protected override void Sua()
        {
            base.Sua();
            _isAdd = false;
            txtTen.Focus();
            timer1.Stop();
            _lstMaKPShow = "";
            foreach (usc_MaTran item in _frm._lst.Values)
            {
                item.timer1.Stop();
                _lstMaKPShow += item.Makp + "_";
            }
            foreach (usc_Dong item in _frm._lstDong.Values)
            {
                item.timer1.Stop();
                _lstMaKPShow += item.Makp + "_";
            }


        }

        protected override void Xoa()
        {
            try
            {
                if (_lstID.Length > 1)
                {
                    _lstID = _lstID.Substring(0, _lstID.Length - 1);
                    _lstTen = _lstTen.Substring(0, _lstTen.Length - 1);
                }
                else
                {
                    _lstID = dgvMain.SelectedRows[0].Cells["colID"].Value.ToString();
                    _lstTen = dgvMain.SelectedRows[0].Cells["colTen"].Value.ToString();
                }

                DialogResult rsl = TA_MessageBox.MessageBox.Show("Bạn có chắc chắn muốn xóa: \n" + _lstTen
                    , TA_MessageBox.MessageIcon.Question);

                if (rsl == System.Windows.Forms.DialogResult.Yes)
                {

                    Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                    dicWhere.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, "'" + dgvMain.SelectedRows[0].Cells["colMa"].Value.ToString() + "'");
                    if (_api.DeleteAll(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang, dicWhere))
                    {

                    }
                    if (_api.DeleteAll(ref _userError, ref _systemError, cls_STT_NhomLCD.tb_TenBang, _lstID))
                    {
                        TimKiem();

                        if (_rowIndex <= (dgvMain.Rows.Count - 1))
                        {
                            dgvMain.Rows[_rowIndex].Selected = true;
                        }
                        else if (dgvMain.Rows.Count > 0)
                        {
                            dgvMain.Rows[dgvMain.Rows.Count - 1].Selected = true;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        protected override void Luu()
        {
            try
            {

                #region Kiểm tra dữ liệu bắt buộc nhập


                if (string.IsNullOrWhiteSpace(txtTen.Text))
                {
                    TA_MessageBox.MessageBox.Show("Loại không được để trống! Vui lòng nhập lại.", 
                        TA_MessageBox.MessageIcon.Error);
                    txtTen.Focus();
                    return;
                }

                #endregion

                Dictionary<string, string> lstData = new Dictionary<string, string>();
                lstData.Add(cls_STT_NhomLCD.col_STT, "0");

                _maNhomLCD = cls_Common.BoDau(txtTen.Text.Trim()).Replace(" ", "");
                lstData.Add(cls_STT_NhomLCD.col_Ma, _maNhomLCD);

                lstData.Add(cls_STT_NhomLCD.col_Ten, txtTen.Text.Trim());

                lstData.Add(cls_STT_NhomLCD.col_SoDong, itgSoDong.Value.ToString());
                lstData.Add(cls_STT_NhomLCD.col_SoCot, itgSoCot.Value.ToString());
                string mamau = "";
                for (int i = 0; i < flpMau.Controls.Count; i++)
                {
                    if (flpMau.Controls[i] is ColorPickerButton)
                    {
                        mamau += "~" + ((ColorPickerButton)flpMau.Controls[i]).SelectedColor.ToArgb();
                    }

                }
                if (mamau.Length > 0)
                {
                    mamau = mamau.Substring(1);
                }

                lstData.Add(cls_STT_NhomLCD.col_MaMau, mamau);
                lstData.Add(cls_STT_NhomLCD.col_Loai, cboLoai.SelectedIndex.ToString());
                lstData.Add(cls_STT_NhomLCD.col_TenLoai, cboLoai.SelectedItem.ToString());
                lstData.Add(cls_STT_NhomLCD.col_TamNgung, chkTamNgung.Checked ? "1" : "0");
                lstData.Add(cls_STT_NhomLCD.col_ThoiGianChuyenMau, dipThoiGian.Value.ToString().Replace(",", "."));

                lstData.Add(cls_STT_NhomLCD.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_NhomLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                //lst.Add(cls_STT_NhomLCD.col_MaCHINEID, cls_Common);
                if (_isAdd)
                {
                    //lstData.Add(cls_STT_NhomLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData.Add(cls_STT_NhomLCD.col_UserID, cls_System.sys_UserID);
                    lstData.Add(cls_STT_NhomLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_NhomLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_NhomLCD.col_Ten);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_NhomLCD.tb_TenBang
                                    , lstData
                                    , lstKiemTraTrung
                                    , new List<string>()))
                    {

                        //if (dgvMain.RowCount > 0)
                        //{
                        //    dgvMain.Rows[dgvMain.RowCount - 1].Cells["colTen"].Selected = true;
                        //}
                        //dgvMain.FirstDisplayedScrollingRowIndex = dgvMain.RowCount - 1;

                    }
                    else
                    {
                        lstData[cls_STT_NhomLCD.col_ThoiGianChuyenMau] = dipThoiGian.Value.ToString().Replace(".", ",");
                        _api.Insert(ref _userError, ref _systemError, cls_STT_NhomLCD.tb_TenBang
                                    , lstData
                                    , lstKiemTraTrung
                                    , new List<string>());
                    }
                }
                else
                {
                    Dictionary<string, string> lst2 = new Dictionary<string, string>();
                    lst2.Add(cls_STT_NhomLCD.col_ID, dgvMain.SelectedRows[0].Cells["colID"].Value.ToString());
                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_NhomLCD.col_NgayUD);

                    if (_api.Update(ref _userError, ref _systemError, cls_STT_NhomLCD.tb_TenBang, lstData, lstDateTime, lst2))
                    {

                        // dgvMain.Rows[_rowIndex].Selected = true;

                    }
                    else
                    {
                        lstData[cls_STT_NhomLCD.col_NgayUD] = (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss"));
                        lstData[cls_STT_NhomLCD.col_ThoiGianChuyenMau] = dipThoiGian.Value.ToString().Replace(".", ",");
                        if (_api.Update(ref _userError, ref _systemError, cls_STT_NhomLCD.tb_TenBang, lstData, lstDateTime, lst2))
                        {
                        }
                    }
                }
                timer1.Start();
                foreach (usc_MaTran item in _frm._lst.Values)
                {
                    if (!string.IsNullOrEmpty(item.Makp))
                    {
                        item.timer1.Start();
                    }
                }
                foreach (usc_Dong item in _frm._lstDong.Values)
                {
                    if (!string.IsNullOrEmpty(item.Makp))
                    {
                        item.timer1.Start();
                    }
                }
                Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, "'" + _maNhomLCD + "'");
                _api.DeleteAll(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang, dicWhere);

                Insert_TieuDe();
                Insert_VungGoi();
                Insert_VungCho();
                Insert_KhuVuc();
                Insert_BacSi();


                _isAdd = false;
                base.Luu();
                btnThem.Focus();
                LoadData();
                dgvMain.Rows[_rowIndex].Selected = true;

                if (cboLoai.SelectedIndex == 0)
                {
                    int i = 0;
                    foreach (usc_MaTran item in _frm._lst.Values)
                    {
                        item.Makp = lstMaKPShow.Split('_')[i];
                        i++;
                    }
                }
                else
                {
                    int i = 0;
                    foreach (usc_Dong item in _frm._lstDong.Values)
                    {
                        item.Makp = lstMaKPShow.Split('_')[i];
                        i++;
                    }
                }
            }
            catch
            {
            }
        }

        protected override void Show_ChiTiet()
        {
            try
            {

                try
                {
                    txtTen.Text = dgvMain.SelectedRows[0].Cells["colTen"].Value.ToString();
                }
                catch
                {
                    txtTen.Text = "";
                }

                try
                {
                    cboLoai.SelectedIndex = int.Parse(dgvMain.SelectedRows[0].Cells["colLoai"].Value.ToString());
                }
                catch
                {
                    cboLoai.SelectedItem = null;
                }
                try
                {
                    dipThoiGian.Value = double.Parse(dgvMain.SelectedRows[0].Cells["colThoiGian"].Value.ToString());
                }
                catch
                {
                    dipThoiGian.Value = 0.3;
                }
                try
                {
                    itgSoDong.Value = int.Parse(dgvMain.SelectedRows[0].Cells["colSoDong"].Value.ToString());
                }
                catch
                {
                    itgSoDong.Value = 0;
                }
                try
                {
                    itgSoCot.Value = int.Parse(dgvMain.SelectedRows[0].Cells["colSoCot"].Value.ToString());
                }
                catch
                {
                    itgSoCot.Value = 0;
                }


                try
                {
                    // chkTamNgung.Checked = dgvMain.SelectedRows[0].Cells["colTamNgung"].Value.ToString() == "1";
                }
                catch { }
                DataTable dtViTri;
                try
                {
                    dtViTri = _dtCauHinh.Select(string.Format("MaNhom = '{0}'", dgvMain.SelectedRows[0].Cells["colMa"].Value), "vitri asc").CopyToDataTable();

                    if (cboLoai.SelectedIndex == 0)
                    {

                        foreach (usc_MaTran item in _frm._lst.Values)
                        {
                            item.LoadVitri(dtViTri);
                        }
                    }


                }
                catch
                {
                    dtViTri = new DataTable();
                    if (cboLoai.SelectedIndex == 0)
                    {

                        foreach (usc_MaTran item in _frm._lst.Values)
                        {
                            item.LoadVitri(dtViTri);
                        }
                    }
                }
                try
                {

                    string[] str = dgvMain.SelectedRows[0].Cells["ColMamau"].Value.ToString().Split('~');
                    lstco.Clear();
                    itgMau.Value = str.Length;
                    Mau(str.Length);
                    for (int i = 0; i < str.Length; i++)
                    {
                        lstco.Add(Color.FromArgb(int.Parse(str[i])));
                        if (flpMau.Controls[i] is ColorPickerButton)
                        {
                            ((ColorPickerButton)flpMau.Controls[i]).SelectedColor = Color.FromArgb(int.Parse(str[i]));
                        }
                    }

                }
                catch { }
                for (int i = cboVung.Items.Count - 1; i >= 0; i--)
                {
                    cboVung.SelectedIndex = i;
                    //cboVung_SelectedIndexChanged(null, null);
                }
                cboVung.SelectedIndex = 0;
                base.Show_ChiTiet();
            }
            catch
            {
                txtTen.Text = "";
            }
        }

        protected override void BoQua()
        {
            _isAdd = false;
            base.BoQua();
        }

        protected override void TimKiem()
        {
            try
            {
                _lstID = _lstTen = "";
                Dictionary<string, string> dicLike = new Dictionary<string, string>();
                dicLike.Add(cls_STT_NhomLCD.col_Ma, txtTimKiem.Text);
                dicLike.Add(cls_STT_NhomLCD.col_Ten, txtTimKiem.Text);

                dgvMain.DataSource = _api.Search(ref _userError, ref _systemError, cls_STT_NhomLCD.tb_TenBang, andLike: false, dicLike: dicLike,
                                                    orderByASC1: true, orderByName1: cls_STT_NhomLCD.col_ID);
                _count = dgvMain.RowCount;
                base.TimKiem();
            }
            catch
            {
                dgvMain.DataSource = null;
            }
        }

        protected override void Thoat()
        {
            this.Hide();
        }

        #endregion


        public string lstMaKPShow
        {
            get
            {
                return _lstMaKPShow;
            }
            set
            {
                _lstMaKPShow = value;
            }
        }

        public string IDShow
        {
            get
            {
                return _IDShow;
            }

            set
            {
                _IDShow = value;
            }
        }

        #region Set dữ liệu vùng

        private void Set_Vung()
        {
            try
            {
                DataTable dtVung = new DataTable();
                dtVung.Columns.Add("Ma");
                dtVung.Columns.Add("Ten");

                DataRow row = dtVung.NewRow();
                row["Ma"] = "TD";
                row["Ten"] = "Tiếp đón";
                dtVung.Rows.Add(row);

                row = dtVung.NewRow();
                row["Ma"] = "VG";
                row["Ten"] = "Vùng gọi";
                dtVung.Rows.Add(row);

                row = dtVung.NewRow();
                row["Ma"] = "VC";
                row["Ten"] = "Vùng chờ";
                dtVung.Rows.Add(row);

                row = dtVung.NewRow();
                row["Ma"] = "KV";
                row["Ten"] = "Khu vực";
                dtVung.Rows.Add(row);

                row = dtVung.NewRow();
                row["Ma"] = "BS";
                row["Ten"] = "Bác sĩ";
                dtVung.Rows.Add(row);

                cboVung.ComboBox.DataSource = dtVung;
                cboVung.ComboBox.DisplayMember = "Ten";
                cboVung.ComboBox.ValueMember = "Ma";
                for (int i = 0; i < cboVung.Items.Count; i++)
                {
                    cboVung.SelectedIndex = i;

                }
                cboVung.SelectedIndex = 0;

            }
            catch
            {
            }
        }

        #endregion

        #region Get cấu hình

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

        #endregion

        private void Load_Font()
        {
            try
            {
                AutoCompleteStringCollection strings = new AutoCompleteStringCollection();
                foreach (FontFamily family in FontFamily.Families)
                {
                    this.cboFont.Items.Add(family.Name);
                    strings.Add(family.Name);
                }
                this.cboFont.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cboFont.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.cboFont.AutoCompleteCustomSource = strings;
            }
            catch
            {
            }
        }

        private void Load_CauHinhLCD()
        {
            try
            {
                cboHienThi.SelectedIndex = int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_TamNgung].ToString());
                //cboHienThi_SelectedIndexChanged(null, null);
            }
            catch
            {
                cboHienThi.SelectedIndex = 0;
            }
            //try
            //{
            //    cboSoLuong.SelectedIndex = int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_SoLuong].ToString());
            //    //cboSoLuong_SelectedIndexChanged(null, null);
            //}
            //catch
            //{
            //    cboSoLuong.SelectedIndex = 0;
            //}
            try
            {
                cboViTri.SelectedIndex = int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_ViTri].ToString()) - 1;
                // cboViTri_SelectedIndexChanged(null, null);
            }
            catch
            {
            }
            try
            {
                cboChieuCao.Text = _drDinhDang[cls_STT_CauHinhLCD.col_ChieuCao].ToString();
                cboChieuCao_Validated(null, null);
            }
            catch
            {
                cboChieuCao.Text = "";
            }
            try
            {
                cboSoLuong.Text = _drDinhDang[cls_STT_CauHinhLCD.col_SoLuong].ToString();

            }
            catch
            {
                cboSoLuong.Text = "";
            }
            try
            {
                cboFont.Text = _drDinhDang[cls_STT_CauHinhLCD.col_Font].ToString();
                cboFont_SelectedIndexChanged(null, null);
            }
            catch
            {
                cboFont.Text = "";
            }
            try
            {
                cboSize.Text = _drDinhDang[cls_STT_CauHinhLCD.col_Size].ToString();
                cboSize_TextChanged(null, null);
            }
            catch
            {
                cboSize.Text = "";
            }

            try
            {
                Clear_TextAlignment();
                int so = int.Parse(_drDinhDang[cls_STT_CauHinhLCD.col_DinhDang].ToString());
                switch (so)
                {
                    case 1:
                        boldButton.Checked = true;
                        break;
                    case 2:
                        italicButton.Checked = true;
                        break;
                    case 3:
                        underlineButton.Checked = true;
                        break;
                    case 4:
                        boldButton.Checked = true;
                        italicButton.Checked = true;
                        break;
                    case 5:
                        boldButton.Checked = true;
                        underlineButton.Checked = true;
                        break;
                    case 6:
                        italicButton.Checked = true;
                        underlineButton.Checked = true;
                        break;
                    case 7:
                        italicButton.Checked = true;
                        boldButton.Checked = true;
                        underlineButton.Checked = true;
                        break;
                    default:
                        italicButton.Checked = false;
                        boldButton.Checked = false;
                        underlineButton.Checked = false;
                        break;
                }
                Set_Font(boldButton.Checked, italicButton.Checked, underlineButton.Checked);
            }
            catch
            {

            }

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


                if (cboLoai.SelectedIndex == 0)
                {
                    foreach (usc_MaTran item in _frm._lst.Values)
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
                else if (cboLoai.SelectedIndex == 1)
                {
                    foreach (usc_Dong item in _frm._lstDong.Values)
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

                if (cboLoai.SelectedIndex == 0)
                {
                    foreach (usc_MaTran item in _frm._lst.Values)
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
                else if (cboLoai.SelectedIndex == 1)
                {
                    foreach (usc_Dong item in _frm._lstDong.Values)
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

                if (cboLoai.SelectedIndex == 0)
                {
                    foreach (usc_MaTran item in _frm._lst.Values)
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
                else if (cboLoai.SelectedIndex == 1)
                {
                    foreach (usc_Dong item in _frm._lstDong.Values)
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

        private void Load_DinhDang()
        {
            StringAlignment fnc;

            if (cboLoai.SelectedIndex == 0)
            {
                #region MATRAN
                usc_MaTran item = _frm._lst.Values[0];
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                //backColor = item.lblGoi.BackColor;
                                //foreColor = item.lblGoi.ForeColor;
                                fnc = item.lblGoi.TextAlignment;
                            }
                            break;
                        case 2:
                            {
                                //backColor = item.lblCho.BackColor;
                                //foreColor = item.lblCho.ForeColor;
                                //fnc = item.lblCho.TextAlignment;
                                try
                                {
                                    fnc = item._lstLBcho[0].TextAlignment;
                                }
                                catch
                                {
                                    fnc = StringAlignment.Near;
                                }
                            }
                            break;
                        case 3:
                            fnc = item.lblKhuVuc.TextAlignment;
                            break;
                        case 4:
                            fnc = item.lblBacSi.TextAlignment;
                            break;
                        default:
                            {
                                //backColor = item.lblTieuDe.BackColor;
                                //foreColor = item.lblTieuDe.ForeColor;
                                fnc = item.lblTieuDe.TextAlignment;
                            }
                            break;
                    }
                    _maVung = i;
                    Set_TextAlignment(fnc);
                    Set_BackColor(true);
                    Set_ForeColor(true);

                }
                #endregion 
            }
            else if (cboLoai.SelectedIndex == 1)
            {
                #region Dong
                usc_Dong item = _frm._lstDong.Values[0];
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                //backColor = item.lblGoi.BackColor;
                                //foreColor = item.lblGoi.ForeColor;
                                fnc = item.lblGoi.TextAlignment;
                            }
                            break;
                        case 2:
                            {
                                //backColor = item.lblCho.BackColor;
                                //foreColor = item.lblCho.ForeColor;
                                fnc = item.lblCho.TextAlignment;

                                //fnc = _uscMaTran._lstLBcho[0].TextAlignment;
                            }
                            break;
                        case 3:
                            fnc = item.lblKhuVuc.TextAlignment;
                            break;
                        case 4:
                            fnc = item.lblBacSi.TextAlignment;
                            break;
                        default:
                            {
                                //backColor = item.lblTieuDe.BackColor;
                                //foreColor = item.lblTieuDe.ForeColor;
                                fnc = item.lblKhuVuc.TextAlignment;
                            }
                            break;
                    }
                    _maVung = i;
                    Set_TextAlignment(fnc);
                    Set_BackColor(true);
                    Set_ForeColor(true);

                }
                #endregion
            }
        }

        private void Mau(int soMau)
        {
            System.ComponentModel.ComponentResourceManager resources2 = new System.ComponentModel.ComponentResourceManager(typeof(frm_NhomLCD));
            if (soMau < flpMau.Controls.Count)
            {
                foreach (ColorPickerButton item in flpMau.Controls)
                {
                    if (int.Parse(item.Name.Substring(3, item.Name.Length - 3)) >= soMau)
                    {
                        flpMau.Controls.Remove(item);
                    }
                }
            }
            else
            {
                for (int i = flpMau.Controls.Count; i < soMau; i++)
                {
                    ColorPickerButton cpButton = new ColorPickerButton();
                    cpButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
                    cpButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
                    cpButton.Name = "cpb" + i.ToString().PadLeft(5, '0');
                    cpButton.Image = ((System.Drawing.Image)(resources2.GetObject("colorPickerButton1.Image")));
                    cpButton.Location = new System.Drawing.Point(3, 3);
                    cpButton.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
                    cpButton.Size = new System.Drawing.Size(40, 23);
                    cpButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                    cpButton.SubItemsExpandWidth = 15;
                    cpButton.TabIndex = 34;


                    flpMau.Controls.Add(cpButton);
                }
            }
        }

        private void Clear_TextAlignment()
        {
            boldButton.Checked = italicButton.Checked = underlineButton.Checked = justifyLeftButton.Checked =
                 justifyCenterButton.Checked =
                 justifyRightButton.Checked = false;
        }

        private string Get_DinhDangFont(LabelX lbl)
        {
            try
            {
                int dinhDang = 0;
                if (lbl.Font.Style.ToString().Contains(FontStyle.Bold.ToString()))
                {
                    dinhDang = 1;
                }
                if (lbl.Font.Style.ToString().Contains(FontStyle.Italic.ToString()))
                {
                    dinhDang = 2;
                }
                if (lbl.Font.Style.ToString().Contains(FontStyle.Underline.ToString()))
                {
                    dinhDang = 3;
                }
                else if ((lbl.Font.Style.ToString().Contains(FontStyle.Bold.ToString())) && (lbl.Font.Style.ToString().Contains(FontStyle.Italic.ToString())))
                {
                    dinhDang = 4;
                }
                if ((lbl.Font.Style.ToString().Contains(FontStyle.Bold.ToString())) && (lbl.Font.Style.ToString().Contains(FontStyle.Underline.ToString())))
                {
                    dinhDang = 5;
                }
                if ((lbl.Font.Style.ToString().Contains(FontStyle.Underline.ToString())) && (lbl.Font.Style.ToString().Contains(FontStyle.Italic.ToString())))
                {
                    dinhDang = 6;
                }
                if ((lbl.Font.Style.ToString().Contains(FontStyle.Bold.ToString())) && (lbl.Font.Style.ToString().Contains(FontStyle.Underline.ToString())) && (lbl.Font.Style.ToString().Contains(FontStyle.Italic.ToString())))
                {
                    dinhDang = 7;
                }

                return dinhDang.ToString();
            }
            catch
            {
                return "0";
            }
        }

        #region  insert custom
        private bool Insert_TieuDe()
        {
            if (cboLoai.SelectedIndex == 0)
            {
                try
                {
                    _uscMaTran = _frm._lst.Values[0];

                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "TD" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscMaTran.lblTieuDe.Text);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscMaTran.lblTieuDe.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscMaTran.lblTieuDe.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscMaTran.lblTieuDe.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscMaTran.lblTieuDe.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscMaTran.lblTieuDe.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscMaTran.lblTieuDe));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscMaTran.pnlTieuDe.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, (_uscMaTran.tlpMain.GetPositionFromControl(_uscMaTran.pnlTieuDe).Row + 1).ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscMaTran.lblTieuDe.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
            else if (cboLoai.SelectedIndex == 1)
            {
                try
                {


                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "TD" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _frm.UscTieuDe.NoiDung);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _frm.UscTieuDe.lblTenPK.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _frm.UscTieuDe.lblTenPK.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _frm.UscTieuDe.lblTenPK.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _frm.UscTieuDe.lblTenPK.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _frm.UscTieuDe.lblTenPK.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_frm.UscTieuDe.lblTenPK));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _frm.UscTieuDe.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _frm.UscTieuDe.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private bool Insert_VungGoi()
        {

            if (cboLoai.SelectedIndex == 0)
            {
                try
                {
                    _uscMaTran = _frm._lst.Values[0];

                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "VG" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscMaTran.lblGoi.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscMaTran.lblGoi.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscMaTran.lblGoi.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscMaTran.lblGoi.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscMaTran.lblGoi.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscMaTran.lblGoi.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscMaTran.lblGoi));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscMaTran.pnlGoi.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, (_uscMaTran.tlpMain.GetPositionFromControl(_uscMaTran.pnlGoi).Row + 1).ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscMaTran.lblGoi.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }

                }
                catch
                {
                    return false;
                }
            }
            else if (cboLoai.SelectedIndex == 1)
            {
                try
                {
                    _uscDong = _frm._lstDong.Values[0];
                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "VG" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscDong.lblGoi.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscDong.lblGoi.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscDong.lblGoi.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscDong.lblGoi.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscDong.lblGoi.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscDong.lblGoi.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscDong.lblGoi));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscDong.pnlGoi.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscDong.lblGoi.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }

                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private bool Insert_VungCho()
        {
            try
            {
                if (cboLoai.SelectedIndex == 0)
                {
                    _uscMaTran = _frm._lst.Values[0];

                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    //lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    //lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "VC" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    //lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscMaTran.lblCho.Name);
                    //lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    //lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscMaTran.lblCho.Font.Name);
                    //lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscMaTran.lblCho.Font.Size.ToString());
                    //lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscMaTran.lblCho.BackColor.ToArgb().ToString());
                    //lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscMaTran.lblCho.ForeColor.ToArgb().ToString());
                    //lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscMaTran.lblCho.TextAlignment.ToString());
                    //lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscMaTran.lblCho.Height.ToString());
                    //lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscMaTran.lblCho));
                    //lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, _uscMaTran.SoluongCho.ToString());
                    //lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, "1");
                    //lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscMaTran.lblCho.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "VC" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscMaTran._lstLBcho[0].Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscMaTran._lstLBcho[0].Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscMaTran._lstLBcho[0].Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscMaTran._lstLBcho[0].BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscMaTran._lstLBcho[0].ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscMaTran._lstLBcho[0].TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscMaTran.pnlCho.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscMaTran._lstLBcho[0]));
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, _uscMaTran.SoluongCho.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, (_uscMaTran.tlpMain.GetPositionFromControl(_uscMaTran.pnlCho).Row + 1).ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscMaTran._lstLBcho[0].Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }

                }
                else
                    if (cboLoai.SelectedIndex == 1)
                {

                    _uscDong = _frm._lstDong.Values[0];
                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "VC" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscDong.lblCho.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscDong.lblCho.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscDong.lblCho.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscDong.lblCho.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscDong.lblCho.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscDong.lblCho.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscDong.lblCho));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscDong.lblCho.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscDong.lblCho.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool Insert_KhuVuc()
        {
            try
            {
                if (cboLoai.SelectedIndex == 0)
                {
                    _uscMaTran = _frm._lst.Values[0];


                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "KV" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscMaTran.lblKhuVuc.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscMaTran.lblKhuVuc.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscMaTran.lblKhuVuc.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscMaTran.lblKhuVuc.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscMaTran.lblKhuVuc.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscMaTran.lblKhuVuc.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscMaTran.pnlKhuVuc.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscMaTran.lblKhuVuc));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, (_uscMaTran.tlpMain.GetPositionFromControl(_uscMaTran.pnlKhuVuc).Row + 1).ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscMaTran.lblKhuVuc.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }

                }
                else
                    if (cboLoai.SelectedIndex == 1)
                {

                    _uscDong = _frm._lstDong.Values[0];

                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "KV" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscDong.lblKhuVuc.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscDong.lblKhuVuc.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscDong.lblKhuVuc.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscDong.lblKhuVuc.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscDong.lblKhuVuc.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscDong.lblKhuVuc.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscDong.lblKhuVuc.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscDong.lblKhuVuc));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscDong.lblKhuVuc.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }
                }
                return false;


            }
            catch
            {
                return false;
            }
        }

        private bool Insert_BacSi()
        {
            try
            {
                if (cboLoai.SelectedIndex == 0)
                {
                    _uscMaTran = _frm._lst.Values[0];

                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "BS" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscMaTran.lblBacSi.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscMaTran.lblBacSi.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscMaTran.lblBacSi.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscMaTran.lblBacSi.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscMaTran.lblBacSi.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscMaTran.lblBacSi.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscMaTran.pnlBS.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscMaTran.lblBacSi));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, (_uscMaTran.tlpMain.GetPositionFromControl(_uscMaTran.pnlBS).Row + 1).ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscMaTran.lblBacSi.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }


                }
                else
                    if (cboLoai.SelectedIndex == 1)
                {

                    _uscDong = _frm._lstDong.Values[0];

                    Dictionary<string, string> lstData2 = new Dictionary<string, string>();
                    lstData2.Add(cls_STT_CauHinhLCD.col_STT, "0");
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ma, "BS" + _bus.Get_curDate().ToString("ddMMyyHHmmss"));
                    lstData2.Add(cls_STT_CauHinhLCD.col_Ten, _uscDong.lblBacSi.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_MaNhomLCD, _maNhomLCD);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Font, _uscDong.lblBacSi.Font.Name);
                    lstData2.Add(cls_STT_CauHinhLCD.col_Size, _uscDong.lblBacSi.Font.Size.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauNen, _uscDong.lblBacSi.BackColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_MauChu, _uscDong.lblBacSi.ForeColor.ToArgb().ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_CanLe, _uscDong.lblBacSi.TextAlignment.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_ChieuCao, _uscDong.lblBacSi.Height.ToString());
                    lstData2.Add(cls_STT_CauHinhLCD.col_DinhDang, Get_DinhDangFont(_uscDong.lblBacSi));
                    lstData2.Add(cls_STT_CauHinhLCD.col_ViTri, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_SoLuong, "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_TamNgung, _uscDong.lblBacSi.Visible ? "0" : "1");
                    lstData2.Add(cls_STT_CauHinhLCD.col_GhiChu, "Cấu hình mới");
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserUD, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstData2.Add(cls_STT_CauHinhLCD.col_UserID, cls_System.sys_UserID);
                    lstData2.Add(cls_STT_CauHinhLCD.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_CauHinhLCD.col_MaNhomLCD);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_CauHinhLCD.tb_TenBang
                                       , lstData2
                                       , lstKiemTraTrung
                                       , new List<string>())
                        )
                    {
                        return true;
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show(_userError + _systemError);
                    }

                }
                return false;

            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Căn lề

        private void Set_TextAlignment(StringAlignment fnc)
        {
            if (cboLoai.SelectedIndex == 0)
            {
                foreach (usc_MaTran item in _frm._lst.Values)
                {
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.TextAlignment = fnc;
                            break;
                        case 2:
                            foreach (LabelX lb in item._lstLBcho)
                            {
                                lb.TextAlignment = fnc;
                            }
                            break;
                        case 3:
                            item.lblKhuVuc.TextAlignment = fnc;
                            break;
                        case 4:
                            item.lblBacSi.TextAlignment = fnc;
                            break;
                        default:
                            item.lblTieuDe.TextAlignment = fnc;
                            break;
                    }
                }
            }
            else if (cboLoai.SelectedIndex == 1)
            {
                foreach (usc_Dong item in _frm._lstDong.Values)
                {
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.TextAlignment = fnc;
                            break;
                        case 2:
                            item.lblCho.TextAlignment = fnc;
                            break;
                        case 3:
                            item.lblKhuVuc.TextAlignment = fnc;
                            break;
                        case 4:
                            item.lblBacSi.TextAlignment = fnc;
                            break;
                        default:
                            _frm.UscTieuDe.lblMoiSo.TextAlignment = fnc;
                            _frm.UscTieuDe.lblSoTT.TextAlignment = fnc;
                            _frm.UscTieuDe.lblTenPK.TextAlignment = fnc;

                            break;
                    }
                }
            }
        }

        #endregion

        #region Set màu nền

        private void Set_BackColor(bool isLoad)
        {
            Color color;
            if (cboLoai.SelectedIndex == 0)
            {
                switch (_maVung)
                {
                    case 1:
                        color = _frm._lst.Values[0].lblGoi.BackColor;
                        break;
                    case 2:
                        try
                        {
                            color = _frm._lst.Values[0]._lstLBcho[0].BackColor;
                        }
                        catch
                        {
                            color = Color.Black;
                        }
                        break;
                    case 3:
                        color = _frm._lst.Values[0].lblKhuVuc.BackColor;
                        break;
                    case 4:
                        color = _frm._lst.Values[0].lblBacSi.BackColor;
                        break;
                    default:
                        color = _frm._lst.Values[0].lblTieuDe.BackColor;
                        break;
                }
                if (!isLoad)
                {
                    ShowColorDialog(ref color);
                }

                foreach (usc_MaTran item in _frm._lst.Values)
                {

                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.BackColor = color;
                            break;
                        case 2: //item.lblCho.BackColor = color;
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
            else if (cboLoai.SelectedIndex == 1)
            {

                switch (_maVung)
                {
                    case 1:
                        color = _frm._lstDong.Values[0].lblGoi.BackColor;
                        break;
                    case 2:
                        color = _frm._lstDong.Values[0].lblCho.BackColor;
                        break;
                    case 3:
                        color = _frm._lstDong.Values[0].lblKhuVuc.BackColor;
                        break;
                    case 4:
                        color = _frm._lstDong.Values[0].lblBacSi.BackColor;
                        break;
                    default:
                        color = _frm.UscTieuDe.lblMoiSo.BackColor;
                        break;
                }
                if (!isLoad)
                {
                    ShowColorDialog(ref color);
                }

                foreach (usc_Dong item in _frm._lstDong.Values)
                {
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.BackColor = color;
                            break;
                        case 2:
                            item.lblCho.BackColor = color;
                            break;
                        case 3:
                            item.lblKhuVuc.BackColor = color;
                            break;
                        case 4:
                            item.lblBacSi.BackColor = color;
                            break;
                        default:
                            _frm.UscTieuDe.lblMoiSo.BackColor = color;
                            _frm.UscTieuDe.lblSoTT.BackColor = color;
                            _frm.UscTieuDe.lblTenPK.BackColor = color;

                            break;
                    }
                }

            }
        }

        #endregion

        #region Set màu chữ

        private void Set_ForeColor(bool isLoad)
        {
            if (cboLoai.SelectedIndex == 0)
            {
                Color color;
                switch (_maVung)
                {
                    case 1:
                        color = _frm._lst.Values[0].lblGoi.ForeColor;
                        break;
                    case 2:
                        try
                        {
                            color = _frm._lst.Values[0]._lstLBcho[0].ForeColor;
                        }
                        catch
                        {
                            color = Color.Black;
                        }
                        break;
                    case 3:
                        color = _frm._lst.Values[0].lblKhuVuc.ForeColor;
                        break;
                    case 4:
                        color = _frm._lst.Values[0].lblBacSi.ForeColor;
                        break;
                    default:
                        color = _frm._lst.Values[0].lblTieuDe.ForeColor;
                        break;
                }
                if (!isLoad)
                {
                    ShowColorDialog(ref color);
                }

                foreach (usc_MaTran item in _frm._lst.Values)
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
            else if (cboLoai.SelectedIndex == 1)
            {
                Color color;
                switch (_maVung)
                {
                    case 1:
                        color = _frm._lstDong.Values[0].lblGoi.ForeColor;
                        break;
                    case 2:
                        color = _frm._lstDong.Values[0].lblCho.ForeColor;
                        break;
                    case 3:
                        color = _frm._lstDong.Values[0].lblKhuVuc.ForeColor;
                        break;
                    case 4:
                        color = _frm._lstDong.Values[0].lblBacSi.ForeColor;
                        break;
                    default:
                        color = _frm.UscTieuDe.lblMoiSo.ForeColor;
                        break;
                }
                if (!isLoad)
                {
                    ShowColorDialog(ref color);
                }

                foreach (usc_Dong item in _frm._lstDong.Values)
                {
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.ForeColor = color;
                            break;
                        case 2:
                            item.lblCho.ForeColor = color;
                            break;
                        case 3:
                            item.lblKhuVuc.ForeColor = color;
                            break;
                        case 4:
                            item.lblBacSi.ForeColor = color;
                            break;
                        default:
                            _frm.UscTieuDe.lblMoiSo.ForeColor = color;
                            _frm.UscTieuDe.lblSoTT.ForeColor = color;
                            _frm.UscTieuDe.lblTenPK.ForeColor = color;


                            break;
                    }
                }

            }

        }

        #endregion

        #region Set font chữ

        private void Set_Font(string fontName, float fontSize)
        {
            try
            {
                if (cboLoai.SelectedIndex == 0)
                {
                    foreach (usc_MaTran item in _frm._lst.Values)
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
                else if (cboLoai.SelectedIndex == 1)
                {
                    foreach (usc_Dong item in _frm._lstDong.Values)
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
                                _frm.UscTieuDe.lblMoiSo.Font = new Font(fontName, fontSize);
                                _frm.UscTieuDe.lblSoTT.Font = new Font(fontName, fontSize);
                                _frm.UscTieuDe.lblTenPK.Font = new Font(fontName, fontSize);

                                break;
                        }
                    }
                }
            }
            catch
            { }
        }

        //try
        //    {
        //       FontFamily ff = new FontFamily(cboFont.Text);
        //       //lblTieuDe.Font = new Font(ff, float.Parse(cboSize.Text));
        //       _lbl.Font = new Font(ff, float.Parse(cboSize.Text));
        //    }
        //    catch
        //    {
        //    }

        private void Set_Font(bool bold, bool italia, bool underline)
        {
            if (cboLoai.SelectedIndex == 0)
            {
                switch (_maVung)
                {
                    case 1:
                        _fontStype = _frm._lst.Values[0].lblGoi.Font.Style;
                        break;
                    case 2:
                        try
                        {
                            _fontStype = _frm._lst.Values[0]._lstLBcho[0].Font.Style;
                        }
                        catch
                        {
                            _fontStype = FontStyle.Bold;
                        }
                        break;
                    case 3:
                        _fontStype = _frm._lst.Values[0].lblKhuVuc.Font.Style;
                        break;
                    case 4:
                        _fontStype = _frm._lst.Values[0].lblBacSi.Font.Style;
                        break;
                    default:
                        _fontStype = _frm._lst.Values[0].lblTieuDe.Font.Style;
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

                foreach (usc_MaTran item in _frm._lst.Values)
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
            else if (cboLoai.SelectedIndex == 1)
            {
                switch (_maVung)
                {
                    case 1:
                        _fontStype = _frm._lstDong.Values[0].lblGoi.Font.Style;
                        break;
                    case 2:
                        _fontStype = _frm._lstDong.Values[0].lblCho.Font.Style;
                        break;
                    case 3:
                        _fontStype = _frm._lstDong.Values[0].lblKhuVuc.Font.Style;
                        break;
                    case 4:
                        _fontStype = _frm._lstDong.Values[0].lblBacSi.Font.Style;
                        break;
                    default:
                        _fontStype = _frm.UscTieuDe.lblMoiSo.Font.Style;
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

                foreach (usc_Dong item in _frm._lstDong.Values)
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
                            _frm.UscTieuDe.lblMoiSo.Font = new Font(_frm.UscTieuDe.lblMoiSo.Font, _fontStype); ;
                            _frm.UscTieuDe.lblSoTT.Font = new Font(_frm.UscTieuDe.lblSoTT.Font, _fontStype); ;
                            _frm.UscTieuDe.lblTenPK.Font = new Font(_frm.UscTieuDe.lblTenPK.Font, _fontStype); ;
                            break;
                    }
                }
            }

        }

        #endregion

        #region Chọn màu

        private bool ShowColorDialog(ref Color color)
        {
            bool selected;
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.CustomColors = null;
                dlg.Color = color;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    selected = true;
                    color = dlg.Color;
                }
                else
                {
                    selected = false;
                }
            }
            return selected;
        }

        #endregion

        #region Set ma trận LCD

        private void Set_ListMaTran(usc_MaTran uscMaTran00, int dong, int cot)
        {
            if (dong * cot == _frm._lst.Values.Count)
            {
                return;
            }

            _frm._lst.Clear();

            int height = Screen.PrimaryScreen.Bounds.Height / dong;
            int width = Screen.PrimaryScreen.Bounds.Width / cot;
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
                        //usc = uscMaTran00;
                    }
                    usc.Name = "lcd" + (i * cot + j).ToString().PadLeft(5, '0');
                    usc.Location = new Point(j * width, i * height);
                    usc.AlamRing += new System.EventHandler(usc_AlamRing);
                    usc.Dock = DockStyle.Fill;
                    _frm._lst.Add(usc.Name, usc);
                }
            }
            Load_DinhDang();

        }
        #region phạm thế mỹ 31/01/2017
        private void Set_ListMaTran(usc_Dong uscMaTran00, int dong)
        {
            if (dong == _frm._lstDong.Values.Count)
            {
                return;
            }

            _frm._lstDong.Clear();

            _frm.UscTieuDe = new usc_TieuDeDong();
            int height = Screen.PrimaryScreen.Bounds.Height / dong;

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
                _frm._lstDong.Add(usc.Name, usc);

            }
            Load_DinhDang();
        }
        #endregion
        #endregion

        #endregion

        #region Sự kiện

        private void itgSoTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isLoadForm) return;
            if (e.KeyCode == Keys.Enter)
            {
                btnLuu.Focus();
            }
        }

        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                if (_isCheck)
                {
                    if (e.ColumnIndex == dgvMain.Columns["colCheck"].Index)
                    {
                        if (dgvMain.Rows[e.RowIndex].Cells["colCheck"].Value.ToString() == "False")
                        {
                            if (_lstID.Contains(dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()))
                            {
                                _lstID = _lstID.Replace(string.Format("{0},", dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()), "");
                                _lstTen = _lstTen.Replace(string.Format("\n{0}", dgvMain.Rows[e.RowIndex].Cells["colTen"].Value.ToString()), "");
                            }
                        }
                        else
                        {
                            if (!_lstID.Contains(dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()))
                            {
                                _lstID += string.Format("{0},", dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                                _lstTen += string.Format("\n{0}", dgvMain.Rows[e.RowIndex].Cells["colTen"].Value.ToString());
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isLoadForm) return;
            if (e.KeyCode == Keys.Enter)
            {
                itgSoDong.Focus();
            }
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                _lstID =
                    _lstTen = "";
                _isCheck = false;
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    dgvMain.Rows[i].DataGridView["colCheck", i].Value = !chkAll.Checked;
                    if (!chkAll.Checked)
                    {
                        _lstID += string.Format("{0},", dgvMain.Rows[i].Cells["colID"].Value.ToString());
                        _lstTen += string.Format("\n{0}", dgvMain.Rows[i].Cells["colTen"].Value.ToString());
                    }
                }
                _isCheck = true;
            }
            catch { }
        }

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            //Get_CauHinh();
            //Show_ChiTiet();
            //try
            //{
            //    _IDShow = dgvMain.SelectedRows[0].Cells["colID"].Value.ToString();
            //}
            //catch
            //{

            //}
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            #region phạm thế mỹ
            if (cboLoai.SelectedIndex == 0)
            {

                itgSoDong_ValueChanged(sender, e);

                lblSoDong.Visible =
                    itgSoDong.Visible = true;
                itgSoCot_ValueChanged(sender, e);
                lblChieuCao.Visible = cboChieuCao.Visible = lblSoCot.Visible =
                    itgSoCot.Visible = true;
            }
            else if (cboLoai.SelectedIndex == 1)
            {

                itgSoDong_ValueChanged(sender, e);
                lblSoDong.Visible =
                   itgSoDong.Visible = true;


                lblChieuCao.Visible = cboChieuCao.Visible = lblSoCot.Visible =
                    itgSoCot.Visible = false;

            }
            #endregion
            //else
            //{
            //    tlpControl.ColumnStyles[7].Width = 63;
            //    tlpControl.ColumnStyles[8].Width = 66;
            //    tlpControl.ColumnStyles[9].Width = 20;
            //    lblSoDong.Visible =
            //       itgSoDong.Visible = true;

            //    tlpControl.ColumnStyles[10].Width = 49;
            //    tlpControl.ColumnStyles[11].Width = 66;
            //    tlpControl.ColumnStyles[12].Width = 20;
            //    lblSoCot.Visible =
            //        itgSoCot.Visible = true;
            //}
            itgSoDong_ValueChanged(sender, e);
            cboVung_SelectedIndexChanged(sender, e);

        }

        private void frm_NhomLCD_Load(object sender, EventArgs e)
        {
            if (_isLoadForm) return;

            if (Screen.AllScreens.Length > 1)
            {

                _frm.WindowState = FormWindowState.Maximized;
                _frm.Location = Screen.AllScreens[0].WorkingArea.Location;
                _frm.Show();
            }
            else
            {
                _frm.WindowState = FormWindowState.Maximized;
                _frm.Location = Screen.AllScreens[0].WorkingArea.Location;
                _frm.Show();
            }
            Load_Font();
            for (int i = 6; i < 72; i++)
            {
                cboSize.Items.Add(i);
            }

            Get_CauHinh();
            Set_Vung();
        }

        private void itgSoDong_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            if (cboLoai.SelectedIndex == 0)
            {
                Set_ListMaTran(_uscMaTran, itgSoDong.Value, itgSoCot.Value);
                _frm.ShowLCD(itgSoDong.Value, itgSoCot.Value);

                for (int i = cboVung.Items.Count - 1; i >= 0; i--)
                {
                    switch (i)
                    {
                        case 0:
                            cboVung.SelectedIndex = i;
                            break;
                        case 1:
                            cboVung.SelectedIndex = i;
                            break;
                        case 2:
                            cboVung.SelectedIndex = 4;
                            break;
                        case 3:
                            cboVung.SelectedIndex = 3;
                            break;
                        default:
                            cboVung.SelectedIndex = 2;
                            break;
                    }

                    //cboVung_SelectedIndexChanged(null, null);

                }
                cboVung.SelectedIndex = 0;

            }
            else if (cboLoai.SelectedIndex == 1)
            {
                Set_ListMaTran(_uscDong, itgSoDong.Value);
                _frm.ShowLCD(itgSoDong.Value);
            }

        }

        private void itgSoCot_ValueChanged(object sender, EventArgs e)
        {

            if (_isLoadForm) return;
            if (cboLoai.SelectedIndex == 0)
            {
                Set_ListMaTran(_uscMaTran, itgSoDong.Value, itgSoCot.Value);
                _frm.ShowLCD(itgSoDong.Value, itgSoCot.Value);

                

                for (int i = cboVung.Items.Count - 1; i >= 0; i--)
                {
                    switch (i)
                    {
                        case 0:
                            cboVung.SelectedIndex = i;
                            break;
                        case 1:
                            cboVung.SelectedIndex = i;
                            break;
                        case 2:
                            cboVung.SelectedIndex = 4;
                            break;
                        case 3:
                            cboVung.SelectedIndex = 3;
                            break;
                        default:
                            cboVung.SelectedIndex = 2;
                            break;
                    }

                    //cboVung_SelectedIndexChanged(null, null);

                }
                cboVung.SelectedIndex = 0;

            }
        }

        private void itgSoDong_Leave(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                if (itgSoDong.Value < 0)
                {
                    itgSoDong.Value = 1;
                }
            }
            catch
            {
                itgSoDong.Value = 1;
            }
        }

        private void itgSoCot_Leave(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                if (itgSoCot.Value < 0)
                {
                    itgSoCot.Value = 1;
                }
            }
            catch
            {
                itgSoCot.Value = 1;
            }
        }

        private void itgMau_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            Mau(itgMau.Value);
        }

        private void cboVung_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (_isLoadForm) return;
            this.cboViTri.SelectedIndexChanged -= new System.EventHandler(this.cboViTri_SelectedIndexChanged);
            _maVung = cboVung.SelectedIndex;
            his_LabelX2.Visible = _maVung == 1;
            itgMau.Visible = _maVung == 1;
            flpMau.Visible = _maVung == 1;
            his_LabelX4.Visible = _maVung == 1;
            dipThoiGian.Visible = _maVung == 1;
            his_LabelX3.Visible = _maVung == 0;
            txtTieuDe.Visible = _maVung == 0;
            lblSoLuong.Visible = cboSoLuong.Visible = ((cboLoai.SelectedIndex == 0) && (_maVung == 2));
           // cboChieuCao.Enabled = _maVung != 2;

            if (_isAdd)
            {
               // cboViTri.SelectedIndex = cboVung.SelectedIndex;
                if (_maVung == 0)
                {
                    if (cboLoai.SelectedIndex == 0)
                    {
                        txtTieuDe.Text = _frm._lst.Values[0].lblTieuDe.Text;
                    }
                    else if (cboLoai.SelectedIndex == 1)
                    {
                        txtTieuDe.Text = _frm.UscTieuDe.NoiDung;
                    }

                }
            }

            try
            {
                string Ma = ((DataRowView)cboVung.ComboBox.Items[cboVung.ComboBox.SelectedIndex])["Ma"].ToString();
                _drDinhDang = _dtCauHinh.Select(string.Format("Ma like '{0}%' and MaNhom = '{1}'", Ma
                    , dgvMain.SelectedRows[0].Cells["colMa"].Value)).CopyToDataTable().Rows[0];
            }
            catch
            {
                _drDinhDang = null;
            }
            
            Load_CauHinhLCD();
            this.cboViTri.SelectedIndexChanged += new System.EventHandler(this.cboViTri_SelectedIndexChanged);
        }

        private void usc_AlamRing(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                PlaySound("..\\..\\wav\\wav1.wav", 0, 1);
            }
            catch (Exception)
            {
            }
        }

        #region Set font chữ

        private void boldButton_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            boldButton.Checked = !boldButton.Checked;
            Set_Font(boldButton.Checked, italicButton.Checked, underlineButton.Checked);
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            italicButton.Checked = !italicButton.Checked;
            Set_Font(boldButton.Checked, italicButton.Checked, underlineButton.Checked);
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            underlineButton.Checked = !underlineButton.Checked;
            Set_Font(boldButton.Checked, italicButton.Checked, underlineButton.Checked);
        }

        #endregion

        #region Set màu chữ

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            Set_ForeColor(false);
        }

        #endregion

        #region Set màu nền

        private void backColorButton_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            Set_BackColor(false);
        }

        #endregion

        #region Căn lề

        private void justifyLeftButton_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            Clear_TextAlignment();
            justifyLeftButton.Checked = !justifyLeftButton.Checked;
            if (justifyLeftButton.Checked)
            {
                Set_TextAlignment(StringAlignment.Near);
            }
        }

        private void justifyCenterButton_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            Clear_TextAlignment();
            justifyCenterButton.Checked = !justifyCenterButton.Checked;
            if (justifyCenterButton.Checked)
            {
                Set_TextAlignment(StringAlignment.Center);
            }
        }

        private void justifyRightButton_Click(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            Clear_TextAlignment();
            justifyRightButton.Checked = !justifyRightButton.Checked;
            if (justifyRightButton.Checked)
            {
                Set_TextAlignment(StringAlignment.Far);
            }
        }

        #endregion

        private void cboSize_TextChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                Set_Font(cboFont.SelectedItem.ToString(), float.Parse(cboSize.Text));
            }
            catch
            {
            }
        }

        private void flpMau_ControlAdded(object sender, ControlEventArgs e)
        {
            if (_isLoadForm) return;
            if (flpMau.Controls.Count > 12)
            {
                flpMau.Height = 90;
                pnlControl2.Height = 215;
            }
            else if (flpMau.Controls.Count > 6)
            {
                flpMau.Height = 60;
                pnlControl2.Height = 185;
            }
        }

        private void flpMau_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (_isLoadForm) return;
            if (flpMau.Controls.Count <= 6)
            {
                flpMau.Height = 30;
                pnlControl2.Height = 155;
            }
            else if (flpMau.Controls.Count <= 12)
            {
                flpMau.Height = 60;
                pnlControl2.Height = 185;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                Color cl = new Color();
                if (lstco.Count > 1)
                {
                    cl = lstco[count];



                    if (cboLoai.SelectedIndex == 0)
                    {
                        foreach (usc_MaTran item in _frm._lst.Values)
                        {
                            if (item.changecolo)
                            {
                                item.lblGoi.ForeColor = cl;
                            }
                        }
                    }
                    else if (cboLoai.SelectedIndex == 1)
                    {
                        foreach (usc_Dong item in _frm._lstDong.Values)
                        {
                            if (item.changecolo)
                            {
                                item.lblGoi.ForeColor = cl;
                            }
                        }
                    }
                }
                count++;
                if (flpMau.Controls.Count <= count)
                {
                    count = 0;
                }
            }
            catch
            { }
        }

        private void cboFont_TextChanged(object sender, EventArgs e)
        {
            //Set_Font(cboFont.SelectedItem.ToString());
        }

        private void cboHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            if (cboLoai.SelectedIndex == 0)
            {
                foreach (usc_MaTran item in _frm._lst.Values)
                {
                    bool giatri = cboHienThi.SelectedIndex == 0;
                    switch (_maVung)
                    {
                        case 1:
                            item.lblGoi.Visible = giatri;
                            //item.pnlGoi.Visible = giatri;
                            cboChieuCao.Text = giatri ? "30" : "0";
                            item.pnlGoi.Height = giatri ? item.pnlGoi.Height : 0;                            break;
                        case 2:
                            //item.pnlCho.Visible = giatri;
                            item.pnlCho.Height = giatri ? item.pnlCho.Height : 0;
                            foreach (var lb in item._lstLBcho)
                            {
                                lb.Visible = giatri;
                            }
                            break;
                        case 3:
                            item.lblKhuVuc.Visible = giatri;
                            item.lblKhuVuc.Height = giatri ? item.lblKhuVuc.Height : 0;
                            cboChieuCao.Text = giatri ? "30" : "0";
                            break;
                        case 4:
                            item.lblBacSi.Visible = giatri;
                            item.pnlBS.Visible = giatri;
                            item.pnlBS.Height = giatri ? item.pnlBS.Height : 0;
                            cboChieuCao.Text = giatri ? "30" : "0";
                            break;
                        default:
                            item.lblTieuDe.Visible = giatri;
                            item.pnlTieuDe.Visible = giatri;
                            item.pnlTieuDe.Height = giatri ? item.pnlTieuDe.Height : 0;
                            cboChieuCao.Text = giatri ? "30" : "0";
                            break;
                    }
                }
            }
            else if (cboLoai.SelectedIndex == 1)
            {
                foreach (usc_Dong item in _frm._lstDong.Values)
                {
                    bool giatri = cboHienThi.SelectedIndex == 0;
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
        }

        private void dipThoiGian_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                timer1.Interval = Convert.ToInt32(dipThoiGian.Value * 1000);
            }
            catch
            { }
        }

        private void cboViTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region code cũ
            //if (_isLoadForm) return;
            //if (cboLoai.SelectedIndex == 0)
            //{
            //    foreach (usc_MaTran item in _frm._lst.Values)
            //    {
            //        switch (_maVung)
            //        {
            //            case 1:
            //                item.lblGoi.Tag = cboViTri.SelectedItem.ToString();
            //                break;
            //            case 2: //item.lblCho.Tag = cboViTri.SelectedItem.ToString();
            //                foreach (var lb in item._lstLBcho)
            //                {
            //                    lb.Tag = cboViTri.SelectedItem.ToString();
            //                }
            //                break;
            //            case 3:
            //                item.lblKhuVuc.Tag = cboViTri.SelectedItem.ToString();
            //                break;
            //            case 4:
            //                item.lblBacSi.Tag = cboViTri.SelectedItem.ToString();
            //                break;
            //            default:
            //                item.lblTieuDe.Tag = cboViTri.SelectedItem.ToString();
            //                break;
            //        }
            //    }
            //}
            //else if (cboLoai.SelectedIndex == 1)
            //{
            //    foreach (usc_Dong item in _frm._lstDong.Values)
            //    {
            //        switch (_maVung)
            //        {
            //            case 1:
            //                item.lblGoi.Tag = cboViTri.SelectedItem.ToString();
            //                break;
            //            case 2:
            //                item.lblCho.Tag = cboViTri.SelectedItem.ToString();
            //                break;
            //            case 3:
            //                item.lblKhuVuc.Tag = cboViTri.SelectedItem.ToString();
            //                break;
            //            case 4:
            //                item.lblBacSi.Tag = cboViTri.SelectedItem.ToString();
            //                break;
            //            default:
            //                ;
            //                break;
            //        }
            //    }
            //} 
            #endregion

            DataTable dtViTri;
            try
            {
                dtViTri = _dtCauHinh.Select(string.Format("MaNhom = '{0}'", dgvMain.SelectedRows[0].Cells["colMa"].Value), "vitri asc").CopyToDataTable();
                string Ma = ((DataRowView)cboVung.ComboBox.Items[cboVung.ComboBox.SelectedIndex])["Ma"].ToString();
                DataRow dr = dtViTri.Select(string.Format("Ma like '{0}%' ", Ma))[0];
                if (cboLoai.SelectedIndex == 0)
                {

                    foreach (usc_MaTran item in _frm._lst.Values)
                    {
                        DataRow dr1;
                        try
                        {
                            dr1 = dtViTri.Select(string.Format("vitri = '{0}' ", cboViTri.Text))[0];
                        }
                        catch
                        {
                            dr1 = null;
                        }
                        string term = dr["vitri"].ToString();
                        dr["vitri"] = cboViTri.Text;
                        if (dr1 != null)
                        {
                            dr1["vitri"] = term;
                            dr1.AcceptChanges();
                        }
                        dr.AcceptChanges();
                        dtViTri.AcceptChanges();
                        dtViTri = dtViTri.Select(string.Format("MaNhom = '{0}'", dgvMain.SelectedRows[0].Cells["colMa"].Value), "vitri asc").CopyToDataTable();
                        item.LoadVitri(dtViTri);
                    }
                }


            }
            catch
            {
                dtViTri = new DataTable();
                if (cboLoai.SelectedIndex == 0)
                {

                    foreach (usc_MaTran item in _frm._lst.Values)
                    {
                        item.LoadVitri(dtViTri);
                    }
                }
            }
            //Get_CauHinh();
            //Show_ChiTiet();

        }

        private void txtTieuDe_Validated(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            if (cboLoai.SelectedIndex == 0)
            {


                foreach (usc_MaTran item in _frm._lst.Values)
                {

                    item.lblTieuDe.Text = txtTieuDe.Text;


                }
            }
            else if (cboLoai.SelectedIndex == 1)
            {

                _frm.UscTieuDe.NoiDung = txtTieuDe.Text;

            }

        }

        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            if (string.IsNullOrEmpty(cboFont.SelectedItem.ToString()) || string.IsNullOrEmpty(cboSize.Text)) return;
            Set_Font(cboFont.SelectedItem.ToString(), float.Parse(cboSize.Text));
        }

        private void cboChieuCao_Validated(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                int chieucao = int.Parse(cboChieuCao.Text);
                if (cboLoai.SelectedIndex == 0)
                {

                    foreach (usc_MaTran item in _frm._lst.Values)
                    {
                        switch (_maVung)
                        {
                            case 1:
                                if (item.pnlGoi.Visible)
                                {
                                    item.pnlGoi.Height = chieucao;
                                   // item.pnlCho.Height = item.Height - (item.pnlKhuVuc.Visible ? item.pnlKhuVuc.Height : 0) - (item.pnlBS.Visible ? item.pnlBS.Height : 0) - (item.pnlTieuDe.Visible ? item.pnlTieuDe.Height : 0) - (item.pnlGoi.Visible ? item.pnlGoi.Height : 0);
                                }
                                else
                                {
                                    item.pnlGoi.Height = 0;
                                   // item.pnlCho.Height = item.Height - item.pnlKhuVuc.Height - item.pnlBS.Height - item.pnlTieuDe.Height - item.pnlGoi.Height;
                                }
                                break;
                            case 2:
                                //item.pnlCho.Height = item.Height - item.pnlGoi.Height - item.pnlKhuVuc.Height - item.pnlTieuDe.Height - item.pnlBS.Height;
                                item.pnlCho.Height = chieucao;
                                ;
                                break;
                            case 3:
                                if (item.pnlKhuVuc.Visible)
                                {
                                    item.pnlKhuVuc.Height = chieucao;
                                    //item.pnlCho.Height = item.Height - item.pnlKhuVuc.Height - item.pnlBS.Height - item.pnlTieuDe.Height - item.pnlGoi.Height;
                                }
                                else
                                {
                                    item.pnlKhuVuc.Height = 0;
                                    //item.pnlCho.Height = item.Height - item.pnlKhuVuc.Height - item.pnlBS.Height - item.pnlTieuDe.Height - item.pnlGoi.Height;
                                }
                                break;
                            case 4:
                                if (item.pnlBS.Visible)
                                {
                                    item.pnlBS.Height = chieucao;
                                    //item.pnlCho.Height = item.Height - item.pnlKhuVuc.Height - item.pnlBS.Height - item.pnlTieuDe.Height - item.pnlGoi.Height;
                                }
                                else
                                {
                                    item.pnlBS.Height = 0;
                                    //item.pnlCho.Height = item.Height - item.pnlKhuVuc.Height - item.pnlBS.Height - item.pnlTieuDe.Height - item.pnlGoi.Height;
                                }
                                break;
                            default:
                                if (item.pnlTieuDe.Visible)
                                {
                                    item.pnlTieuDe.Height = chieucao;
                                    //item.pnlCho.Height = item.Height - item.pnlKhuVuc.Height - item.pnlBS.Height - item.pnlTieuDe.Height - item.pnlGoi.Height;
                                }
                                else
                                {
                                    item.pnlTieuDe.Height = 0;
                                    //item.pnlCho.Height = item.Height - item.pnlKhuVuc.Height - item.pnlBS.Height - item.pnlTieuDe.Height - item.pnlGoi.Height;
                                }
                                break;
                        }
                    }
                }

                string soLuongCho = _dtCauHinh.Select(string.Format("Ma like '{0}%' and MaNhom = '{1}'", "VC"
                      , dgvMain.SelectedRows[0].Cells["colMa"].Value)).CopyToDataTable().Rows[0]["soluong"].ToString();
                foreach (usc_MaTran item in _frm._lst.Values)
                {
                    item.SoluongCho = int.Parse(soLuongCho);
                }
            }
            catch (Exception)
            {


            }
        }

        private void cboSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadForm) return;
            try
            {
                int soluongcho = int.Parse(cboSoLuong.Text);
                if (cboLoai.SelectedIndex == 0)
                {
                    if (cboVung.SelectedIndex == 2)
                    //  if(true)
                    {

                        foreach (usc_MaTran item in _frm._lst.Values)
                        {
                            item.SoluongCho = soluongcho;
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.RowCount > 0 && e.RowIndex > -1)
            {
                if (_isLoadForm) return;
                try
                {
                    _rowIndex = e.RowIndex;
                    if (e.ColumnIndex == dgvMain.Columns["colSua"].Index)
                    {
                        Sua();
                    }
                    if (e.ColumnIndex == dgvMain.Columns["colXoa"].Index)
                    {
                        Xoa();
                    }
                    DataGridViewCheckBoxCell cell = this.dgvMain.CurrentCell as DataGridViewCheckBoxCell;
                    if (cell != null)
                    {
                        cell.Value = cell.Value == null || !((bool)cell.Value);
                        this.dgvMain.RefreshEdit();
                        this.dgvMain.NotifyCurrentCellDirty(true);
                    }
                }
                catch
                {
                }
            }

            try
            {
                _IDShow = dgvMain.SelectedRows[0].Cells["colID"].Value.ToString();
            }
            catch
            {

            }
           

            Get_CauHinh();
            Show_ChiTiet();

        }



        #endregion
       
    }
}
