using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using E00_Model;
using E00_Common;
using E00_System;
using System.Globalization;

namespace E00_STT
{
    public partial class frm_QuetDSCho : E00_Base.frm_Base
    {

        #region Biến toàn cục
        private clsBUS _bus = new clsBUS();
        private Api_Common _api = new Api_Common();
        private Acc_Oracle _acc = new Acc_Oracle();
        private string _userError = "";
        private string _systemError = "";
        private string _maKhu = "";
        private string _maPhong = "";
        private string _tenPhong = "";
        private string _tenKhu = "";
        private DataTable _dtBNToa;//Lưu danh sách bệnh nhân được cho toa thuốc
        private DataTable _dtBNCapSo;//Lưu danh sách bệnh nhân được cấp số
        private DataTable _dtBNDaGoi;//Lưu danh sách bệnh nhân đã được gọi
        private DataRow _drCapSo = null;
        private int _sNumCall = 1;
        private string _sIdBegin = "";
        private string _sIdEnd = "";
        private bool _isOK = true;//lưu trạng thái kiểm tra bệnh nhân được cấp số hay không
        private string _loai = ""; //lưu trạng thái gọi form là nhà thuốc hoặc cls...
        private string _MaNoiCap = "";
        private string _maNoiChuyenSTT = "KCANLAMSANG-CLS1";
        #endregion

        #region Hàm khởi tạo

        public frm_QuetDSCho()
        {
            InitializeComponent();
        }

        public frm_QuetDSCho(string tenKhu, string tenPhong, string maKhu, string maPhong, string loai)
        {
            InitializeComponent();
            dgvLeft.AutoGenerateColumns = false;
            dgvCapSo.AutoGenerateColumns = false;
            dgvDaGoi.AutoGenerateColumns = false;
            _maKhu = maKhu;
            _maPhong = maPhong;
            _tenPhong = tenPhong;
            _tenKhu = tenKhu;
            _loai = loai;
            if (_maPhong != "")
            {
                _MaNoiCap = cls_STT_KhuVucPhong.col_Phong + _maPhong;

            }
            else if (_maKhu != "")
            {
                _MaNoiCap = cls_STT_KhuVucPhong.col_KhuVuc + _maKhu;
            }
            else
            {
                TA_MessageBox.MessageBox.Show("Bạn chưa chọn khu hoặc Phòng");
                return;
            }
            btnChuyenSTT.Visible = txtChuyenSTT.Visible = _loai == _bus._NHATHUOC;
        }
        #endregion

        #region Phương thức

        private void PrintSTT(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (chkInSTT.Checked)
                {
                    try
                    {
                        if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                        ds.WriteXml("..//xml//rptSttdangky.xml", XmlWriteMode.WriteSchema);
                        if (chkXemIn.Checked)
                        {
                            ReportDocument oRpt = new ReportDocument();
                            oRpt.Load("..\\..\\..\\Report\\sttkham.rpt", OpenReportMethod.OpenReportByDefault);
                            oRpt.SetDataSource(ds);
                            frm_ReportSTT frm = new frm_ReportSTT(oRpt);
                            frm.ShowDialog();
                        }
                        else
                        {
                            ReportDocument rptDoc = new ReportDocument();
                            //ds.ReadXml("..\\..\\..\\Report\\sttkham.rpt", XmlReadMode.ReadSchema);
                            rptDoc.Load("..\\..\\..\\Report\\sttkham.rpt", OpenReportMethod.OpenReportByDefault);
                            rptDoc.SetDataSource(ds);
                            rptDoc.PrintToPrinter(1, false, 1, ds.Tables[0].Rows.Count);
                            rptDoc.Dispose();
                            ds.Dispose();
                            rptDoc.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        TA_MessageBox.MessageBox.Show("Lỗi in report!\n" + ex.Message,       TA_MessageBox.MessageIcon.Error);
                    }
                }
            }
        }

        private void SetUuTien(bool isGoiSo)
        {
            if (dgvCapSo.RowCount < 1 ) return;
            if (isGoiSo || dgvCapSo.RowCount == 1)
            {
                Dictionary<string, string> lstData = new Dictionary<string, string>();
                List<string> lstDateTime = new List<string>();
                lstData.Add(cls_STT_CapSo.col_UuTien, "1");
                lstData.Add(cls_STT_CapSo.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_CapSo.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                lstWhere.Add(cls_STT_CapSo.col_ID, dgvCapSo["col_ID", 0].Value + "");

                lstDateTime.Clear();
                lstDateTime.Add(cls_STT_CapSo.col_NgayUD);
                bool bl = _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstData, lstDateTime, lstWhere);
            }
        }

        #endregion

        #region Events

        private void frm_QuetDSCho_Load(object sender, EventArgs e)
        {
            _dtBNToa = _bus.LoadDSBenhNhan(_loai, _MaNoiCap);
            _dtBNCapSo = _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false);
            _dtBNDaGoi = _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, true);
            dgvLeft.DataSource = _dtBNToa;
            if (_dtBNCapSo != null && _dtBNCapSo.Rows.Count > 0) dgvCapSo.DataSource = _dtBNCapSo.Select("", "" + cls_STT_CapSo.col_UuTien + " DESC," + cls_STT_CapSo.col_STT + " ASC").CopyToDataTable();
            dgvDaGoi.DataSource = _dtBNDaGoi;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string stt = "";
            if (String.IsNullOrWhiteSpace(txtMaBN.Text)) return;
            txtMaBN_Validated(null, null);
            if (_loai == _bus._CANLAMSANG)
            {
                stt = lblSTT.Text;
                chkInSTT.Checked = false;
            }
            if (!_isOK) return;
            if (_bus.CapSTT(_MaNoiCap, _tenKhu, _tenPhong, txtMaBN.Text, lblMaQL.Text, txtHoTen.Text, chkUuTien.Checked, chkInSTT.Checked, chkXemIn.Checked, ref stt))
            {
                if (_bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false) != null && _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false).Rows.Count > 0) dgvCapSo.DataSource = _dtBNCapSo = _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false).Select("", "" + cls_STT_CapSo.col_UuTien + " DESC," + cls_STT_CapSo.col_STT + " ASC").CopyToDataTable();
                dgvLeft.DataSource = _dtBNToa = _bus.LoadDSBenhNhan(_loai, _MaNoiCap);
                txtGioiTinh.Text = txtHoTen.Text = txtMaBN.Text = txtNamSinh.Text = lblSTT.Text = "";
                if (_loai == _bus._CANLAMSANG) SetUuTien(false);
            }
            txtMaBN.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtID.Text)) return;
            DataRow row = _bus.getrowbyid(_dtBNCapSo, "id = " + txtID.Text.Trim());
            if (row == null) return;
            if (TA_MessageBox.MessageBox.Show(String.Format("Bạn có chắc muốn xóa STT {0} của bệnh nhân {1} không?", row["stt"] + "", row["hoten"] + ""), TA_MessageBox.MessageIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_STT_CapSo.col_ID, row["id"] + "");
                if (_api.Delete(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, dicWhere))
                {
                    if (_bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false) != null && _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false).Rows.Count > 0) dgvCapSo.DataSource = _dtBNCapSo = _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false).Select("", "" + cls_STT_CapSo.col_UuTien + " DESC," + cls_STT_CapSo.col_STT + " ASC").CopyToDataTable();
                    dgvLeft.DataSource = _dtBNToa = _bus.LoadDSBenhNhan(_loai, _MaNoiCap);
                    txtGioiTinh.Text = txtHoTen.Text = txtMaBN.Text = txtNamSinh.Text = lblSTT.Text = "";
                }
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLeft_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaBN.Text = dgvLeft["colMaBn", dgvLeft.SelectedRows[0].Index].Value + "";
                txtHoTen.Text = dgvLeft["colHoTen", dgvLeft.SelectedRows[0].Index].Value + "";
                txtNamSinh.Text = dgvLeft["colNamSinh", dgvLeft.SelectedRows[0].Index].Value + "";
                txtGioiTinh.Text = dgvLeft["colGioiTinh", dgvLeft.SelectedRows[0].Index].Value + "" == "0" ? "Nam" : "Nữ";
                lblSTT.Text = dgvLeft["col_STT", dgvLeft.SelectedRows[0].Index].Value + "";
                txtMaBN.Focus();
            }
            catch
            { }
        }

        private void txtMaBN_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtMaBN.Text == "" || txtMaBN.Text.Trim().Length < 3) return;
                if (txtMaBN.Text.Trim().Length != 8) txtMaBN.Text = txtMaBN.Text.Substring(0, 2) + txtMaBN.Text.Substring(2).PadLeft(6, '0');
                DataRow row = _bus.getrowbyid(_dtBNToa, "mabn = " + txtMaBN.Text.Trim());
                if (row != null)
                {
                    txtMaBN.Text = row["mabn"] + "";
                    txtHoTen.Text = row["hoten"] + "";
                    txtNamSinh.Text = row["namsinh"] + "";
                    txtGioiTinh.Text = row["phai"] + "" == "0" ? "Nam" : "Nữ";
                    lblMaQL.Text = row["maql"] + "";
                    _isOK = true;
                    lblSTT.Text = row["stt_led"] + "";
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Không tìm thấy mã bệnh nhân này!",  TA_MessageBox.MessageIcon.Information);
                    txtMaBN.Text = txtHoTen.Text = txtGioiTinh.Text = txtNamSinh.Text = "";
                    txtMaBN.Focus();
                    _isOK = false;
                    return;
                }
            }
            catch { }
        }

        private void txtMaBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void dgvCapSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblSTT.Text = dgvCapSo["colSTT", dgvCapSo.SelectedRows[0].Index].Value + "";
                if (e.ColumnIndex == dgvCapSo.Columns["colInLai"].Index)
                {
                    #region Tạo bảng in
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("TEN");
                    dt.Columns.Add("NGAY");
                    dt.Columns.Add("SO");
                    dt.Columns.Add("UT");
                    dt.Columns.Add("MABN");
                    dt.Columns.Add("HOTEN");
                    ds.Tables.Add(dt);
                    #endregion

                    string tenphong = "";
                    if (string.IsNullOrEmpty(_tenPhong))
                    {
                        tenphong = _tenKhu;
                    }
                    else
                    {
                        tenphong = _tenPhong;
                    }

                    DataRow Row = dt.NewRow();
                    Row["TEN"] = tenphong;
                    Row["NGAY"] = _bus.Get_curDate().ToString("dd/MM/yyyy HH:mm:ss");
                    Row["SO"] = dgvCapSo["colSTT", dgvCapSo.SelectedRows[0].Index].Value + "";
                    Row["UT"] = dgvCapSo["colUuTien", dgvCapSo.SelectedRows[0].Index].Value + "";
                    Row["MABN"] = dgvCapSo["col_MaBN", dgvCapSo.SelectedRows[0].Index].Value + "";
                    Row["HOTEN"] = dgvCapSo["col_HoTen", dgvCapSo.SelectedRows[0].Index].Value + "";
                    dt.Rows.Add(Row);
                    dt.AcceptChanges();
                    PrintSTT(ds);
                }
            }
            catch
            { }
        }

        private void btnGoi_Click(object sender, EventArgs e)
        {
            try
            {
                txtGioiTinh.Text = txtHoTen.Text = txtMaBN.Text = txtNamSinh.Text = "";
                lblSTT.Text = dgvCapSo["colSTT", dgvCapSo.SelectedRows[0].Index].Value + "";
                if (_loai != _bus._CANLAMSANG) _bus.CheckChuKy(_MaNoiCap);

                _sNumCall = 1;

                string sTuSo = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_KhuVuc + _maKhu, cls_STT_KhuVucPhong.col_ChuaGoi, ref _sNumCall, ref _sIdBegin, ref _sIdEnd);

                if (string.IsNullOrWhiteSpace(sTuSo) || sTuSo == "~")
                {
                    TA_MessageBox.MessageBox.Show("Chưa cấp mới");
                    return;
                }
                else if( _loai == _bus._NHATHUOC) //nếu là quầy dược thì đẩy số đang gọi sang viện phí
                {
                    DataRow row = _dtBNCapSo.Select("STT = '" + sTuSo.Split('~')[0] + "'")[0];
                    if (row != null)
                    {
                        Dictionary<string, string> lstData = new Dictionary<string, string>();
                        List<string> lstKiemTraTrung = new List<string>();
                        lstData.Add(cls_STT_CapSo.col_MaNoiCap, _maNoiChuyenSTT);
                        lstData.Add(cls_STT_CapSo.col_STT, row["stt"] + "");
                        lstData.Add(cls_STT_CapSo.col_MaBN, row["mabn"] + "");
                        lstData.Add(cls_STT_CapSo.col_MaQL, row["maql"] + "");
                        lstData.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_ChuaGoi);
                        lstData.Add(cls_STT_CapSo.col_TamNgung, "0");
                        lstData.Add(cls_STT_CapSo.col_UuTien, "0");
                        lstData.Add(cls_STT_CapSo.col_UserID, cls_System.sys_UserID);
                        lstData.Add(cls_STT_CapSo.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                        lstData.Add(cls_STT_CapSo.col_UserUD, cls_System.sys_UserID);
                        lstData.Add(cls_STT_CapSo.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                        lstKiemTraTrung.Clear();
                        lstKiemTraTrung.Add(cls_STT_CapSo.col_MaNoiCap);
                        lstKiemTraTrung.Add(cls_STT_CapSo.col_STT);
                        lstKiemTraTrung.Add(cls_STT_CapSo.col_TrangThai);
                        lstKiemTraTrung.Add(cls_STT_CapSo.col_NgayTao);

                        if (_api.Insert(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang
                                        , lstData
                                        , lstKiemTraTrung
                                        , new List<string>()))
                        {

                        }
                    }
                }
                if (_bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false) != null && _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false).Rows.Count > 0)
                {
                    dgvCapSo.DataSource = _dtBNCapSo = _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false).Select("", "" + cls_STT_CapSo.col_UuTien + " DESC," + cls_STT_CapSo.col_STT + " ASC").CopyToDataTable();
                }
                dgvDaGoi.DataSource = _dtBNDaGoi = _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, true);
                dgvLeft.DataSource = _dtBNToa = _bus.LoadDSBenhNhan(_loai, _MaNoiCap);
                if (_loai == _bus._CANLAMSANG) SetUuTien(true);
                this.Text = string.IsNullOrEmpty(_bus.GetThongTinSoGoi(_MaNoiCap)) ? this.Text : _bus.GetThongTinSoGoi(_MaNoiCap);

                //-------------------------------------------------------------------nếu nơi gọi là cls thực hiện thì đẩy bệnh nhân vào ds chờ cận lâm sàng kết quả

            }
            catch
            { }
        }

        private void btnGoiLai_Click(object sender, EventArgs e)
        {
            _bus.ReCall_STT(ref _sIdBegin);
            this.Text = string.IsNullOrEmpty(_bus.GetThongTinSoGoi(_MaNoiCap)) ? this.Text : _bus.GetThongTinSoGoi(_MaNoiCap);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dgvLeft.DataSource = _dtBNToa = _bus.LoadDSBenhNhan(_loai, _MaNoiCap);
            if (_bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false) != null && _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false).Rows.Count > 0) dgvCapSo.DataSource = _dtBNCapSo = _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, false).Select("", "" + cls_STT_CapSo.col_UuTien + " DESC," + cls_STT_CapSo.col_STT + " ASC").CopyToDataTable();
        }

        private void chkInSTT_CheckedChanged(object sender, DevComponents.DotNetBar.CheckBoxChangeEventArgs e)
        {
            chkXemIn.Enabled = chkInSTT.Checked;
        }

        private void txtMaBN_Leave(object sender, EventArgs e)
        {
            btnLuu_Click(null, null);
        }

        private void dgvDaGoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvDaGoi.Columns["colGoiLai"].Index)
                {
                    string id = dgvDaGoi["colID1", dgvDaGoi.SelectedRows[0].Index].Value + "";
                    if (id == _sIdBegin)
                    {
                        _bus.ReCall_STT(ref _sIdBegin);
                        this.Text = string.IsNullOrEmpty(_bus.GetThongTinSoGoi(_MaNoiCap)) ? this.Text : _bus.GetThongTinSoGoi(_MaNoiCap);
                    }
                    else
                    {
                        _bus.ReCall_STT_ANY(ref _sIdBegin, id, string.IsNullOrEmpty(_maPhong) ? "K" + _maKhu : "P" + _maPhong);
                        this.Text = string.IsNullOrEmpty(_bus.GetThongTinSoGoi(_MaNoiCap)) ? this.Text : _bus.GetThongTinSoGoi(_MaNoiCap);
                    }
                    _dtBNDaGoi = _bus.Get_DSBNDaCapSTT(_maPhong, _maKhu, true);
                    txtMaBN.Focus();
                }
            }
            catch { }
        }

        private void dgvDaGoi_DataSourceChanged(object sender, EventArgs e)
        {
            if (_dtBNDaGoi != null)
            {
                lblCount.Text = dgvDaGoi.Rows.Count.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    dgvDaGoi.DataSource = _dtBNDaGoi;
                    return;
                }
                dgvDaGoi.DataSource = _dtBNDaGoi.Select(string.Format("mabn like '%{0}%' or hoten like '%{0}%' or hotenkdau like '%{1}%' or stt like '%{0}%'", txtTimKiem.Text.Trim(), cls_Common.BoDau(txtTimKiem.Text.Trim()).Replace(" ", ""))).CopyToDataTable();
            }
            catch
            {
                dgvDaGoi.DataSource = null;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txtMaBN.Focus();
        }

        private void btnChuyenSTT_Click(object sender, EventArgs e)
        {
            frm_ChonCapSTT frm = new frm_ChonCapSTT(1);
            frm.Text = "Chọn nơi chuyển số thứ tự";
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
            frm.FormClosed += delegate { _maNoiChuyenSTT = frm._maNoiCap == "" ? _maNoiChuyenSTT : frm._maNoiCap; };
        }

        private void dgvCapSo_DataSourceChanged(object sender, EventArgs e)
        {
            if (_loai == _bus._CANLAMSANG) dgvCapSo.Rows[0].DefaultCellStyle.BackColor = Color.Yellow;
        }

        #endregion


    }
}
