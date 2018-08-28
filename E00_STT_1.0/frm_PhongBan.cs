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
    public partial class frm_PhongBan : frm_DanhMuc
    {

        #region Biến toàn cục
        private clsBUS _bus = new clsBUS();
        private int _rowIndex = 0;
        private Api_Common _api = new Api_Common();
        private bool _isAdd = false;
        private string _userError = "";
        private string _systemError = "";
        private string _lstID = "";
        private string _lstTen = "";
        private bool _isCheck = false;
        private DataTable _dtKhoaPhong = new DataTable();
        private DataTable _dtKhuVuc = new DataTable();

        #endregion

        #region Khởi tạo

        public frm_PhongBan()
        {
            InitializeComponent();
            _api.KetNoi();
        }

        #endregion

        #region Phương thức

        #region Protected Override

        protected override void LoadData()
        {
            _isCheck = false;
            slbNhomKV.DataSource = _bus.Get_NhomKhuVuc("");
            slbKhuVuc.DataSource = _dtKhuVuc = _bus.Get_KhuVuc(true);
            TimKiem();
           // Load_KhoaPhong();
            base.LoadData();
            _isCheck = true;
        }

        protected override void Them()
        {
            base.Them();
            _isAdd = true;
            slbKhuVuc.clear();
            slbNhomKV.clear();
            slbTen.clear();
            txtGhiChu.Text = "";
            chkTamNgung.Checked = false;
            slbNhomKV.txtTen.Select();

        }

        protected override void Sua()
        {
            base.Sua();
            _isAdd = false;
            slbTen.Focus();
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

                    if (_api.DeleteAll(ref _userError, ref _systemError, cls_STT_KhoaPhong.tb_TenBang, _lstID))
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

                if (string.IsNullOrWhiteSpace(slbNhomKV.txtTen.Text))
                {
                    TA_MessageBox.MessageBox.Show("Nhóm khu vực không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                    slbNhomKV.txtTen.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(slbKhuVuc.txtTen.Text))
                {
                    TA_MessageBox.MessageBox.Show("Khu vực không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                    slbKhuVuc.txtTen.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(slbTen.txtTen.Text))
                {
                    TA_MessageBox.MessageBox.Show("Tên không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                    slbTen.txtTen.Focus();
                    return;
                }

                #endregion

                Dictionary<string, string> lstData = new Dictionary<string, string>();
                lstData.Add(cls_STT_KhoaPhong.col_STT, "0");
                lstData.Add(cls_STT_KhoaPhong.col_Ten, slbTen.txtTen.Text.Trim());
                lstData.Add(cls_STT_KhoaPhong.col_MaNhom, slbKhuVuc.txtMa.Text.Trim());
                lstData.Add(cls_STT_KhoaPhong.col_MaNhomKV, slbNhomKV.txtMa.Text.Trim());
                lstData.Add(cls_STT_KhoaPhong.col_GhiChu, txtGhiChu.Text);
                lstData.Add(cls_STT_KhoaPhong.col_TamNgung, chkTamNgung.Checked ? "1" : "0");
                lstData.Add(cls_STT_KhoaPhong.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_KhoaPhong.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                //lst.Add(cls_STT_KhuVuc.col_MaCHINEID, cls_Common);
                if (_isAdd)
                {
                    lstData.Add(cls_STT_KhoaPhong.col_Ma, slbKhuVuc.txtMa.Text.Trim() + "-" + (string.IsNullOrEmpty(slbTen.txtMa.Text) ? cls_Common.BoDau(slbTen.txtTen.Text.Trim()).Replace(" ", "") : slbTen.txtMa.Text));
                    lstData.Add(cls_STT_KhoaPhong.col_UserID, cls_System.sys_UserID);
                    lstData.Add(cls_STT_KhoaPhong.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_KhoaPhong.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_KhoaPhong.col_Ten);
                    lstKiemTraTrung.Add(cls_STT_KhoaPhong.col_MaNhom);
                    lstKiemTraTrung.Add(cls_STT_KhoaPhong.col_MaNhomKV);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_KhoaPhong.tb_TenBang
                                    , lstData
                                    , lstKiemTraTrung
                                    , new List<string>()))
                    {
                        TimKiem();
                        if (dgvMain.RowCount > 0)
                        {
                            dgvMain.Rows[dgvMain.RowCount - 1].Cells["colTen"].Selected = true;
                        }
                        dgvMain.FirstDisplayedScrollingRowIndex = dgvMain.RowCount - 1;
                        base.Luu();
                        btnThem.Focus();
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show("Lỗi Không cập nhật được : " + _userError + " !", TA_MessageBox.MessageIcon.Error);
                    }
                }
                else
                {
                    Dictionary<string, string> lst2 = new Dictionary<string, string>();
                    lst2.Add(cls_STT_KhoaPhong.col_ID, dgvMain.SelectedRows[0].Cells["colID"].Value.ToString());
                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_KhoaPhong.col_NgayUD);

                    if (_api.Update(ref _userError, ref _systemError, cls_STT_KhoaPhong.tb_TenBang, lstData, lstDateTime, lst2))
                    {
                        TimKiem();
                        dgvMain.Rows[_rowIndex].Selected = true;
                        base.Luu();
                        btnThem.Focus();
                    }
                    else
                    {
                        TA_MessageBox.MessageBox.Show("Lỗi Không cập nhật được : " + _userError + " !", TA_MessageBox.MessageIcon.Error);
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
                    int.Parse(dgvMain.SelectedRows[0].Cells["colMa"].Value.ToString().Split('-')[2]);
                    slbTen.SetTenByMa(dgvMain.SelectedRows[0].Cells["colMa"].Value.ToString().Split('-')[2]);
                }
                catch
                {
                    slbTen.txtTen.Text = dgvMain.SelectedRows[0].Cells["colTen"].Value.ToString();
                }
                txtGhiChu.Text = dgvMain.SelectedRows[0].Cells["colGhiChu"].Value.ToString();
                try
                {
                    chkTamNgung.Checked = dgvMain.SelectedRows[0].Cells["colTamNgung"].Value.ToString() == "1";
                }
                catch { }
                slbNhomKV.SetTenByMa(dgvMain.SelectedRows[0].Cells["colMaNhomKhu"].Value.ToString());
                slbKhuVuc.SetTenByMa(dgvMain.SelectedRows[0].Cells["colMaKhu"].Value.ToString());

                base.Show_ChiTiet();
            }
            catch
            {
                slbTen.clear();
                txtGhiChu.Text = "";
            }
        }

        protected override void TimKiem()
        {
            try
            {
                _lstID = _lstTen = "";
                //Dictionary<string, string> dicLike = new Dictionary<string, string>();
                //dicLike.Add(cls_STT_KhoaPhong.col_Ma, txtTimKiem.Text);
                //dicLike.Add(cls_STT_KhoaPhong.col_Ten, txtTimKiem.Text);
                //dgvMain.DataSource = _api.Search(ref _userError, ref _systemError, cls_STT_KhoaPhong.tb_TenBang, andLike: false, dicLike: dicLike,
                //                                    orderByASC1: true, orderByName1: cls_STT_KhoaPhong.col_ID);

                dgvMain.DataSource = _bus.Get_PhongBanSQL();
                _count = dgvMain.RowCount;
                base.TimKiem();
            }
            catch
            {
                dgvMain.DataSource = null;
            }
        }

        #endregion

        #region Private

        private void Load_KhoaPhong()
        {
            try
            {
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_BTDKP_BV.col_Hide, "1");
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_BTDKP_BV.col_MaKP);
                lstColumns.Add(cls_BTDKP_BV.col_TenKP);

                _dtKhoaPhong = _api.Search(ref _userError, ref _systemError, cls_BTDKP_BV.tb_TenBang, lst: lstColumns, dicDifferent: dicD,
                                                    orderByASC1: true, orderByName1: cls_BTDKP_BV.col_TenKP);

                slbTen.DataSource = _dtKhoaPhong;
            }
            catch
            {

            }
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
                    else if (e.ColumnIndex == dgvMain.Columns["colXoa"].Index)
                    {
                        Xoa();
                    }
                    else
                    {
                        DataGridViewCheckBoxCell cell = this.dgvMain.CurrentCell as DataGridViewCheckBoxCell;
                        if (cell != null)
                        {
                            cell.Value = cell.Value == null || !((bool)cell.Value);
                            this.dgvMain.RefreshEdit();
                            this.dgvMain.NotifyCurrentCellDirty(true);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void itgSoTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLuu.Focus();
            }
        }

        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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
            Show_ChiTiet();
        }

        private void dgvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void lblKhuVuc_Click(object sender, EventArgs e)
        {
            frm_KhuVuc frm = new frm_KhuVuc();
            frm.ShowDialog();
            slbKhuVuc.DataSource = _dtKhuVuc = _bus.Get_KhuVuc(true);
            
        }

        private void lblNhomKV_Click(object sender, EventArgs e)
        {
            frm_NhomKhuVuc frm = new frm_NhomKhuVuc();
            frm.ShowDialog();
            slbNhomKV.DataSource = _bus.Get_NhomKhuVuc("");
            
        }

        private void slbTen_HisSelectChange(object sender, EventArgs e)
        {
            //if (slbTen.txtTen.Text != "")
            //{
            //    txtTen.Text = slbTen.txtTen.Text;
            //}
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Load_KhoaPhong();
        }

        private void slbNhomKV_HisSelectChange(object sender, EventArgs e)
        {
            try
            {
                slbKhuVuc.DataSource = _dtKhuVuc.Select(string.Format("MaNhom = '{0}'", slbNhomKV.txtMa.Text)).CopyToDataTable();
            }
            catch
            {
                slbKhuVuc.DataSource = null;
            }

            if (slbNhomKV.txtMa.Text == "PHONGKHAM")
            {
                Load_KhoaPhong();
                slbTen.his_AddNew = false;
            }
            else
            {
                slbTen.DataSource = null;
                slbTen.his_AddNew = true;
            }
        }

        private void slbNhomKV_HisKeyUpEnter(object sender, KeyEventArgs e)
        {
            SendKeys.Send("{Tab}");
            //Dừng con trỏ
        }


        #endregion


    }
}
