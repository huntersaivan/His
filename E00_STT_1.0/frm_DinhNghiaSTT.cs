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

namespace E00_STT
{
    public partial class frm_DinhNghiaSTT : frm_DanhMuc
    {

        #region Biến toàn cục

        private int _rowIndex = 0;
        private Api_Common _api = new Api_Common();
        private bool _isAdd = false;
        private string _userError = "";
        private string _systemError = "";
        private string _lstID = "";
        private string _lstTen = "";
        private bool _isLoadForm = false;//Trạng thái đang load form sẽ không chạy sự kiện control
        private clsBUS _bus = new clsBUS();
        private DataTable _dtTimeZone = new DataTable();
        private DataTable _dtKhuVuc = new DataTable();
        private DataTable _dtPhong = new DataTable();

        #endregion

        #region Khởi tạo

        public frm_DinhNghiaSTT()
        {
            InitializeComponent();
            _api.KetNoi();
        }

        #endregion

        #region Phương thức

        #region Protected Override

        protected override void LoadData()
        {
            _isLoadForm = false;
            Load_ChuKy();
            slbNhomKV.DataSource = _bus.Get_NhomKhuVuc("");
            slbKhuVuc.DataSource = _dtKhuVuc = _bus.Get_KhuVuc(true);
            slbPhong.DataSource = _dtPhong = _bus.Get_PhongBanNhomKhu();
            Load_DinhDangNgay();
            Load_ChuKyGio();
            HidenTimeZone(false);
            TimKiem();
            base.LoadData();
            _isLoadForm = true;
        }

        protected override void Them()
        {
            base.Them();
            _isAdd = true;
            slbNhomKV.txtMa.Text =
            slbNhomKV.txtTen.Text =
            slbKhuVuc.txtMa.Text =
            slbKhuVuc.txtTen.Text =
            slbPhong.txtMa.Text =
            slbPhong.txtTen.Text =
            txtDienGiai.Text =
            txtChieuDai.Text =
            txtChuoiCoDinh.Text =
            txtDauNganCach.Text =
            slbChuKy.txtMa.Text =
            slbChuKy.txtTen.Text =
            txtBuocNhay.Text =
            txtSoBatDau.Text =
            txtSoHienTai.Text =
            txtSoToiDa.Text =
            txtSoMau.Text =
            txtLanCuoi.Text = "";

            chkTamNgung.Checked =
                chkDauNganCach.Checked =
                chkDinhDangNgay.Checked =
                chkChuKy.Checked = false;
            slbChuKy.Enabled = false;
            slbNhomKV.txtTen.Focus();
        }

        protected override void Sua()
        {
            base.Sua();
            _isAdd = false;
            slbNhomKV.txtTen.Focus();
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
                    _lstTen = dgvMain.SelectedRows[0].Cells["colMaNoiCap"].Value.ToString();
                }

                DialogResult rsl = TA_MessageBox.MessageBox.Show("Bạn có chắc chắn muốn xóa: \n" + _lstTen
                     , TA_MessageBox.MessageIcon.Question);

                if (rsl == System.Windows.Forms.DialogResult.Yes)
                {

                    if (_api.DeleteAll(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, _lstID))
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

                if (chk_DinhNghiaGioPhutGiay.Checked)
                {
                    if (string.IsNullOrWhiteSpace(slbNhomKV.txtMa.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Nhóm khu vực không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        slbNhomKV.txtTen.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(slbKhuVuc.txtMa.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Khu vực không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        slbKhuVuc.txtTen.Focus();
                        return;
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(slbNhomKV.txtMa.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Nhóm khu vực không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        slbNhomKV.txtTen.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(slbKhuVuc.txtMa.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Khu vực không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        slbKhuVuc.txtTen.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtChieuDai.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Chiều dài không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        txtChieuDai.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(slbChuKy.txtTen.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Chu kỳ đặt lại không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        slbChuKy.txtTen.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtBuocNhay.Text))
                    {
                        TA_MessageBox.MessageBox.Show("bước nhảy không được để trống! Vui lòng nhập lại.",TA_MessageBox.MessageIcon.Error);
                        txtBuocNhay.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtSoBatDau.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Số bắt đầu không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        txtSoBatDau.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtSoHienTai.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Số hiện tại không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        txtSoHienTai.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtSoToiDa.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Số tối đa không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                        txtSoToiDa.Focus();
                        return;
                    }

                    int nHienTai = 0;
                    bool bHientai = int.TryParse(txtSoHienTai.Text.Trim(), out nHienTai);
                    int nBatDau = 0;
                    bool bBatDau = int.TryParse(txtSoBatDau.Text.Trim(), out nBatDau);
                    if (bHientai && bBatDau && nHienTai < nBatDau)
                    {
                        TA_MessageBox.MessageBox.Show("Số hiện tại không thể nhỏ hơn số bắt đầu! Vui lòng nhập lại.",  TA_MessageBox.MessageIcon.Error);
                        txtSoHienTai.Focus();
                        return;
                    }
                }
                #endregion

                string diengiai = "";
                if(chk_DinhNghiaGioPhutGiay.Checked)
                {
                    diengiai = "hhmmss";
                }
                else
                {
                    diengiai = txtDienGiai.Text == "hhmmss" ? "hhmmss." : txtDienGiai.Text;
                }

                Dictionary<string, string> lstData = new Dictionary<string, string>();
                lstData.Add(cls_STT_DinhNghia.col_STT, "0");
                lstData.Add(cls_STT_DinhNghia.col_MaNhomKV, slbNhomKV.txtMa.Text);
                lstData.Add(cls_STT_DinhNghia.col_MaKhuVuc, slbKhuVuc.txtMa.Text);
                string maNoiCap;
                if (string.IsNullOrEmpty(slbPhong.txtTen.Text))
                {
                    maNoiCap = cls_STT_KhuVucPhong.col_KhuVuc + slbKhuVuc.txtMa.Text;
                }
                else
                {
                    maNoiCap = cls_STT_KhuVucPhong.col_Phong + slbPhong.txtMa.Text;
                }
                lstData.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                lstData.Add(cls_STT_DinhNghia.col_MaNoiCap, maNoiCap);//vannq
                lstData.Add(cls_STT_DinhNghia.col_DienGiai, diengiai);
                lstData.Add(cls_STT_DinhNghia.col_TamNgung, chkTamNgung.Checked ? "1" : "0");
                lstData.Add(cls_STT_DinhNghia.col_ChieuDai, txtChieuDai.Text);
                lstData.Add(cls_STT_DinhNghia.col_ChuoiCoDinh, txtChuoiCoDinh.Text);
                lstData.Add(cls_STT_DinhNghia.col_CoDauNganCach, chkDauNganCach.Checked ? "1" : "0");
                lstData.Add(cls_STT_DinhNghia.col_DauNganCach, txtDauNganCach.Text);
                lstData.Add(cls_STT_DinhNghia.col_CoDinhDangNgay, chkDinhDangNgay.Checked ? "1" : "0");
                if (chkDinhDangNgay.Checked)
                {
                    lstData.Add(cls_STT_DinhNghia.col_DinhDangNgay, slbDinhDangNgay.txtTen.Text);
                }
                if (slbTimeZone.Visible == true)
                {
                    lstData.Add(cls_STT_DinhNghia.col_IdTimeZone, slbTimeZone.txtMa.Text);
                }
                lstData.Add(cls_STT_DinhNghia.col_CoChuKy, chkChuKy.Checked ? "1" : "0");
                lstData.Add(cls_STT_DinhNghia.col_ChuKy, slbChuKy.txtMa.Text);
                lstData.Add(cls_STT_DinhNghia.col_BuocNhay, txtBuocNhay.Text);
                lstData.Add(cls_STT_DinhNghia.col_SoBatDau, txtSoBatDau.Text);
                lstData.Add(cls_STT_DinhNghia.col_SoHienTai, txtSoHienTai.Text);
                lstData.Add(cls_STT_DinhNghia.col_SoToiDa, txtSoToiDa.Text);

                lstData.Add(cls_STT_DinhNghia.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_DinhNghia.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                //lst.Add(cls_STT_DinhNghia.col_MaCHINEID, cls_Common);
                if (_isAdd)
                {
                    lstData.Add(cls_STT_DinhNghia.col_UserID, cls_System.sys_UserID);
                    lstData.Add(cls_STT_DinhNghia.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_DinhNghia.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_DinhNghia.col_MaKhuVuc);
                    lstKiemTraTrung.Add(cls_STT_DinhNghia.col_MaNhomKV);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang
                                    , lstData
                                    , lstKiemTraTrung
                                    , new List<string>()))
                    {
                        TimKiem();
                        if (dgvMain.RowCount > 0)
                        {
                            dgvMain.Rows[dgvMain.RowCount - 1].Cells["colMaNoiCap"].Selected = true;
                        }
                        dgvMain.FirstDisplayedScrollingRowIndex = dgvMain.RowCount - 1;
                        base.Luu();
                        btnThem.Focus();
                    }
                }
                else
                {
                    Dictionary<string, string> lst2 = new Dictionary<string, string>();
                    lst2.Add(cls_STT_DinhNghia.col_ID, dgvMain.SelectedRows[0].Cells["colID"].Value.ToString());
                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                    if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstData, lstDateTime, lst2))
                    {
                        TimKiem();
                        dgvMain.Rows[_rowIndex].Selected = true;
                        base.Luu();
                        btnThem.Focus();
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
                slbNhomKV.SetTenByMa(dgvMain.SelectedRows[0].Cells["colMaNhomKhu"].Value.ToString());
                slbKhuVuc.SetTenByMa(dgvMain.SelectedRows[0].Cells["colMaKhu"].Value.ToString());
                if (dgvMain.SelectedRows[0].Cells["colMaNoiCap2"].Value.ToString().Substring(0, 1) == "P")
                {
                    slbPhong.SetTenByMa(dgvMain.SelectedRows[0].Cells["colMaNoiCap2"].Value.ToString().Substring(1));
                }
                else
                {
                    slbPhong.clear();
                }
                chk_DinhNghiaGioPhutGiay.Checked = dgvMain.SelectedRows[0].Cells["colDienGiai"].Value.ToString() == "hhmmss";
                txtDienGiai.Text = dgvMain.SelectedRows[0].Cells["colDienGiai"].Value.ToString();
                txtChieuDai.Text = dgvMain.SelectedRows[0].Cells["colChieuDai"].Value.ToString();
                txtChuoiCoDinh.Text = dgvMain.SelectedRows[0].Cells["colChuoiCoDinh"].Value.ToString();
                txtDauNganCach.Text = dgvMain.SelectedRows[0].Cells["colDauNganCach"].Value.ToString();
                slbDinhDangNgay.SetTenByMa(dgvMain.SelectedRows[0].Cells["colDinhDangNgay"].Value.ToString());
                slbChuKy.SetTenByMa(dgvMain.SelectedRows[0].Cells["colChuKy"].Value.ToString());
                txtBuocNhay.Text = dgvMain.SelectedRows[0].Cells["colBuocNhay"].Value.ToString();
                txtSoBatDau.Text = dgvMain.SelectedRows[0].Cells["colSoBatDau"].Value.ToString();
                txtSoHienTai.Text = dgvMain.SelectedRows[0].Cells["colSoHienTai"].Value.ToString();
                txtSoToiDa.Text = dgvMain.SelectedRows[0].Cells["colSoToiDa"].Value.ToString();
                txtLanCuoi.Text = dgvMain.SelectedRows[0].Cells["colNgayUD"].Value.ToString();
                if (dgvMain.SelectedRows[0].Cells["colChuKy"].Value.ToString() == "5")
                {
                    HidenTimeZone(true);
                }
                else
                {
                    HidenTimeZone(false);
                }
                slbTimeZone.SetTenByMa(dgvMain.SelectedRows[0].Cells["colIDTIMEZONE"].Value.ToString());
                try
                {
                    chkChuKy.Checked = dgvMain.SelectedRows[0].Cells["colCoChuKy"].Value.ToString() == "1";
                }
                catch { }
                try
                {
                    chkTamNgung.Checked = dgvMain.SelectedRows[0].Cells["colTamNgung"].Value.ToString() == "1";
                }
                catch { }
                base.Show_ChiTiet();
            }
            catch
            {
            }
        }

        protected override void TimKiem()
        {
            try
            {
                _lstID = _lstTen = "";
                //Dictionary<string, string> dicLike = new Dictionary<string, string>();
                //dicLike.Add(cls_STT_DinhNghia.col_Ma, txtTimKiem.Text);
                //dicLike.Add(cls_STT_DinhNghia.col_DienGiai, txtTimKiem.Text);
                dgvMain.DataSource = _bus.Get_DinhNghiaSQL(); // _api.Search(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, andLike: false, dicLike: dicLike,
                                                             // orderByASC1: true, orderByName1: cls_STT_DinhNghia.col_ID);
                _count = dgvMain.RowCount;
                if (_count > 0)
                {
                    dgvMain.Columns["colMaNoiCap"].Frozen = true;
                    dgvMain.Columns["colMaNoiCap"].Frozen = true;
                    dgvMain.Columns["colMaNoiCap"].Frozen = true;
                }
                base.TimKiem();
            }
            catch
            {
                dgvMain.DataSource = null;
            }
        }

        #endregion

        #region Private

        private void Load_ChuKyGio()
        {
            try
            {
                _dtTimeZone = new DataTable();
                //Dictionary<string, string> dicD = new Dictionary<string, string>();
                //dicD.Add(cls_STT_TimeZone.col_TamNgung, "1");
                //List<string> lstColumns = new List<string>();
                //lstColumns.Add(cls_STT_TimeZone.col_ID);
                //string sNameColumn = "";
                //if (cls_System.sys_Kieu == cls_System.sys_KieuAcc)
                //{       /// kiểu accc chưa phát triêrn

                //    throw new Exception("Chưa phát triển");

                //}
                //else if (cls_System.sys_Kieu == cls_System.sys_KieuSQL)
                //{
                //    #region Kiểu SQL Sever
                //    sNameColumn = "CONVERT(NVARCHAR(5)," + cls_STT_TimeZone.col_TimeBegin + ",8) " +
                //                          " + ' - ' +  CONVERT(NVARCHAR(5)," + cls_STT_TimeZone.col_TimeEnd + ",8) as TEN";

                //    #endregion
                //}
                //else if (cls_System.sys_Kieu == cls_System.sys_KieuORC)
                //{
                //    #region  kiểu oracle
                //    sNameColumn = "TO_CHAR(" + cls_STT_TimeZone.col_TimeBegin + ",'HH24:MI') " +
                //                          " || ' - ' ||  TO_CHAR(" + cls_STT_TimeZone.col_TimeEnd + ",'HH24:MI') as TEN";
                //    #endregion
                //}


                //lstColumns.Add(sNameColumn);
                //_dTaTimeZone = _api.Search(ref _userError, ref _systemError, cls_STT_TimeZone.tb_TenBang, lst: lstColumns, dicDifferent: dicD,
                //                                    orderByASC1: true, orderByName1: cls_STT_TimeZone.col_ID);
                _dtTimeZone = _bus.LoadChuKyGio();
                slbTimeZone.DataSource = _dtTimeZone;
                slbTimeZone.his_SetSelectedIndex = 0;
            }
            catch
            {
                slbTimeZone.DataSource = null;
            }
        }

        private void Load_DinhDangNgay()
        {
            slbDinhDangNgay.txtMa.Text = "1";
            slbDinhDangNgay.txtTen.Text = "ddMMyy";
        }

        private void Load_ChuKy()
        {
            DataTable dtaChuKy = new DataTable();
            dtaChuKy.Columns.Add("MA");
            dtaChuKy.Columns.Add("TEN");
            dtaChuKy.Rows.Add("5", "Giờ");
            dtaChuKy.Rows.Add("1", "Ngày");
            dtaChuKy.Rows.Add("2", "Tuần");
            dtaChuKy.Rows.Add("3", "Tháng");
            dtaChuKy.Rows.Add("4", "Năm");
            slbChuKy.DataSource = dtaChuKy;
            colChuKy.DataSource = dtaChuKy;
            colChuKy.DisplayMember = cls_STT_KhuVuc.col_Ten;
            colChuKy.ValueMember = cls_STT_KhuVuc.col_Ma;
        }

        private string SoTiepTheo()
        {
            try
            {
                //string soTiepTheo = "";
                //soTiepTheo = txtChuoiCoDinh.Text;
                //soTiepTheo += txtDauNganCach.Text;
                //soTiepTheo += _bus.Get_curDate().ToString(slbDinhDangNgay.txtTen.Text);
                //if (int.Parse(txtChieuDai.Text) < soTiepTheo.Length + txtSoToiDa.Text.Length)
                //{
                //    return "";
                //}
                //soTiepTheo += (int.Parse(txtSoHienTai.Text) + int.Parse(txtBuocNhay.Text)).ToString().PadLeft(int.Parse(txtChieuDai.Text) - soTiepTheo.Length, '0');

                //return soTiepTheo;
                return _bus.CapSTT(int.Parse(txtChieuDai.Text), txtChuoiCoDinh.Text, txtDauNganCach.Text, slbDinhDangNgay.txtTen.Text
                                    , int.Parse(txtBuocNhay.Text), int.Parse(txtSoHienTai.Text), int.Parse(txtSoToiDa.Text));
            }
            catch
            {
                return "";
            }
        }

        private void HidenTimeZone(bool showTime)
        {
            slbTimeZone.Visible = showTime;
            his_LabelX19.Visible = showTime;
        }

        #endregion

        #endregion

        #region Event

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.RowCount > 0 && e.RowIndex > -1)
            {
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
        }

        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_isLoadForm)
                {
                    if (e.ColumnIndex == dgvMain.Columns["colCheck"].Index)
                    {
                        if (dgvMain.Rows[e.RowIndex].Cells["colCheck"].Value.ToString() == "False")
                        {
                            if (_lstID.Contains(dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()))
                            {
                                _lstID = _lstID.Replace(string.Format("{0},", dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()), "");
                                _lstTen = _lstTen.Replace(string.Format("\n{0}", dgvMain.Rows[e.RowIndex].Cells["colMaNoiCap"].Value.ToString()), "");
                            }
                        }
                        else
                        {
                            if (!_lstID.Contains(dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()))
                            {
                                _lstID += string.Format("{0},", dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                                _lstTen += string.Format("\n{0}", dgvMain.Rows[e.RowIndex].Cells["colMaNoiCap"].Value.ToString());
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLuu.Focus();
            }
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            try
            {
                _lstID =
                    _lstTen = "";
                _isLoadForm = false;
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    dgvMain.Rows[i].DataGridView["colCheck", i].Value = !chkAll.Checked;
                    if (!chkAll.Checked)
                    {
                        _lstID += string.Format("{0},", dgvMain.Rows[i].Cells["colID"].Value.ToString());
                        _lstTen += string.Format("\n{0}", dgvMain.Rows[i].Cells["colMaNoiCap"].Value.ToString());
                    }
                }
                _isLoadForm = true;
            }
            catch { }
        }

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            Show_ChiTiet();
        }

        private void dgvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void slbChuKy_HisValueChange(object sender, EventArgs e)
        {
            if (slbChuKy.DataSource != null && slbChuKy.DataSource.Rows.Count > 0)
            {
                if (slbChuKy.txtMa.Text == "5")
                {
                    HidenTimeZone(true);
                    slbTimeZone.Focus();
                }
                else
                {
                    HidenTimeZone(false);
                }
            }
        }

        private void lblNhom_Click(object sender, EventArgs e)
        {
            frm_NhomKhuVuc frm = new frm_NhomKhuVuc();
            frm.ShowDialog();
            slbNhomKV.DataSource = _bus.Get_NhomKhuVuc("");
        }

        private void lblKhuVuc_Click(object sender, EventArgs e)
        {
            frm_KhuVuc frm = new frm_KhuVuc();
            frm.ShowDialog();
            slbKhuVuc.DataSource = _dtKhuVuc = _bus.Get_KhuVuc(slbNhomKV.txtMa.Text);
        }

        private void lblPhongBan_Click(object sender, EventArgs e)
        {
            frm_PhongBan frm = new frm_PhongBan();
            frm.ShowDialog();
            slbPhong.DataSource = _dtPhong = _bus.Get_PhongBanNhomKhu();
        }

        private void chkNganCach_CheckedChanged(object sender, EventArgs e)
        {
            txtDauNganCach.Enabled = chkDauNganCach.Checked;
        }

        private void chkDinhDang_CheckedChanged(object sender, EventArgs e)
        {
            slbDinhDangNgay.Enabled = chkDinhDangNgay.Checked;
        }

        private void chkChuKy_CheckedChanged(object sender, EventArgs e)
        {
            slbChuKy.Enabled = chkChuKy.Enabled;
        }

        private void txtHienTai_TextChanged(object sender, EventArgs e)
        {
            txtSoMau.Text = SoTiepTheo();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(slbNhomKV.txtMa.Text))
            {
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                #region Kiểm tra các số cấp lại có khám xong hoặc đang khám ko?
                string sSttHienTai = SoTiepTheo();
                DataTable dtaSTT = _bus.Get_STTDaCap(slbNhomKV.txtMa.Text, sSttHienTai);
                if (dtaSTT != null && dtaSTT.Rows.Count > 0)
                {
                    #region Kiểm tra có STT đang khám ko
                    if (dtaSTT.Select(cls_STT_CapSo.col_TrangThai + " = '" + cls_STT_KhuVucPhong.col_DangGoi + "'").Length > 0)
                    {
                        TA_MessageBox.MessageBox.Show("Đang khám bệnh nhân có STT này", TA_MessageBox.MessageIcon.Warning);
                        return;
                    }
                    #endregion

                    #region  Xóa các số đã cấp mà chưa khám

                    string _lstIDDelCapSo = string.Empty;
                    foreach (DataRow row in dtaSTT.Select())
                    {
                        _lstIDDelCapSo += string.Format("{0},", row[cls_STT_CapSo.col_ID].ToString());
                    }
                    if (_lstIDDelCapSo.Length > 1)
                    {
                        _lstIDDelCapSo = _lstIDDelCapSo.Substring(0, _lstIDDelCapSo.Length - 1);
                    }
                    if (_api.DeleteAll(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, _lstIDDelCapSo))
                    {
                        TA_MessageBox.MessageBox.Show("Reset lại số thứ tự thành công", TA_MessageBox.MessageIcon.Information);
                        return;
                    }
                    #endregion
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Không có số thứ tự reset", TA_MessageBox.MessageIcon.Information);
                    return;
                }
                #endregion
            }
        }

        private void slbChuKy_HisSelectChange(object sender, EventArgs e)
        {
            if (slbChuKy.DataSource != null && slbChuKy.DataSource.Rows.Count > 0)
            {
                if (slbChuKy.txtMa.Text == "5")
                {
                    HidenTimeZone(true);
                }
                else
                {
                    HidenTimeZone(false);
                }
            }
        }

        private void slbNhom_HisSelectChange(object sender, EventArgs e)
        {
            try
            {
                slbKhuVuc.DataSource = _dtKhuVuc.Select(string.Format("MaNhom = '{0}'", slbNhomKV.txtMa.Text)).CopyToDataTable();
            }
            catch
            {
                slbKhuVuc.DataSource = null;
            }
            try
            {
                slbPhong.DataSource = _dtPhong.Select(string.Format("MaNhomKhu = '{0}'", slbNhomKV.txtMa.Text)).CopyToDataTable();
            }
            catch
            {
                slbPhong.DataSource = null;
            }
            slbKhuVuc.clear();
            slbPhong.clear();
        }

        private void slbKhuVuc_HisSelectChange(object sender, EventArgs e)
        {
            if (slbKhuVuc.txtMa.Text == "")
            {
                try
                {
                    slbPhong.DataSource = _dtPhong.Select(string.Format("MaNhomKhu = '{0}'", slbNhomKV.txtMa.Text)).CopyToDataTable();
                }
                catch
                {
                    slbPhong.DataSource = null;
                }
            }
            else
            {
                try
                {
                    slbPhong.DataSource = _dtPhong.Select(string.Format("MaNhom = '{0}'", slbKhuVuc.txtMa.Text)).CopyToDataTable();
                }
                catch
                {
                    slbPhong.DataSource = null;
                }
            }
            slbPhong.clear();
        }

        #endregion

        private void chk_DinhNghiaGioPhutGiay_CheckedChanged(object sender, EventArgs e)
        {
            pnlAn.Visible = chk_DinhNghiaGioPhutGiay.Checked;
            if (chk_DinhNghiaGioPhutGiay.Checked)
            {
                txtDienGiai.Enabled = false;
                txtDienGiai.Text = "hhmmss";
            }
            else
            {
                txtDienGiai.Enabled = true;
                txtDienGiai.Text = "";
                txtDienGiai.Text = txtDienGiai.Text == "hhmmss" ? "hhmmss." : txtDienGiai.Text;
            }
        }
    }
}
