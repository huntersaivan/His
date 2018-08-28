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
    public partial class frm_KhuVuc : frm_DanhMuc
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

        #endregion

        #region Khởi tạo

        public frm_KhuVuc()
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
            Load_NhomKhuVuc();
            TimKiem();
            base.LoadData();
            _isCheck = true;
        }

        protected override void Them()
        {
            base.Them();
            _isAdd = true;
            slbTen.clear();
            txtGhiChu.Text = "";
            chkTamNgung.Checked = false;
            slbNhomKV.txtTen.Focus();
        }

        protected override void Sua()
        {
            base.Sua();
            _isAdd = false;
           slbTen. txtTen.Focus();
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
                    int i = 0;
                    foreach (var item in _lstID.Split(','))
                    {
                        DataTable dt;
                        try
                        {
                            dt = ((DataTable)dgvMain.DataSource).Select("id = " + item).CopyToDataTable();
                        }
                        catch
                        {
                            dt = null;
                        }
                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                        lstWhere.Add(cls_STT_KhuVuc.col_ID, item);
                        if (dt != null && dt.Rows.Count > 0 && _bus.Get_PhongBan(dt.Rows[0][cls_STT_KhuVuc.col_Ma].ToString()).Rows.Count > 0)
                        {
                            TA_MessageBox.MessageBox.Show("Khu vực \"" + _lstTen.Split(',')[i] + "\" đang được tham chiếu bởi: " +
                                                            _bus.Get_PhongBan(dt.Rows[0][cls_STT_KhuVuc.col_Ma].ToString()).Rows.Count + " phòng. \nVui lòng xóa tất cả các phòng tham chiếu trước!"
                                                                ,TA_MessageBox.MessageIcon.Error);
                        }
                        else
                        {
                            _api.Delete(ref _userError, ref _systemError, cls_STT_KhuVuc.tb_TenBang, lstWhere);
                        }
                        i++;
                    }
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
            catch
            {
            }
        }

        protected override void Luu()
        {
            try
            {

                #region Kiểm tra dữ liệu bắt buộc nhập


                if (string.IsNullOrWhiteSpace(slbTen.txtTen.Text))
                {
                    TA_MessageBox.MessageBox.Show("Loại không được để trống! Vui lòng nhập lại.",TA_MessageBox.MessageIcon.Error);
                    slbTen.txtTen.Focus();
                    return;
                }

                #endregion

                Dictionary<string, string> lstData = new Dictionary<string, string>();
                lstData.Add(cls_STT_KhuVuc.col_STT, "0");

                lstData.Add(cls_STT_KhuVuc.col_Ten, slbTen.txtTen.Text.Trim());
                lstData.Add(cls_STT_KhuVuc.col_MaNhom, slbNhomKV.txtMa.Text.Trim());
                lstData.Add(cls_STT_KhuVuc.col_GhiChu, txtGhiChu.Text);
                lstData.Add(cls_STT_KhuVuc.col_TamNgung, chkTamNgung.Checked ? "1" : "0");
                lstData.Add(cls_STT_KhuVuc.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_KhuVuc.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                //lst.Add(cls_STT_KhuVuc.col_MaCHINEID, cls_Common);
                if (_isAdd)
                {
                    lstData.Add(cls_STT_KhuVuc.col_Ma, slbNhomKV.txtMa.Text.Trim() + "-" + (string.IsNullOrEmpty(slbTen.txtMa.Text) ? cls_Common.BoDau(slbTen.txtTen.Text.Trim()).Replace(" ", "") : slbTen.txtMa.Text));
                    lstData.Add(cls_STT_KhuVuc.col_UserID, cls_System.sys_UserID);
                    lstData.Add(cls_STT_KhuVuc.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_KhuVuc.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_KhuVuc.col_Ten);
                    lstKiemTraTrung.Add(cls_STT_KhuVuc.col_MaNhom);
                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_KhuVuc.tb_TenBang
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
                    lst2.Add(cls_STT_KhuVuc.col_ID, dgvMain.SelectedRows[0].Cells["colID"].Value.ToString());
                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_KhuVuc.col_NgayUD);

                    if (_api.Update(ref _userError, ref _systemError, cls_STT_KhuVuc.tb_TenBang, lstData, lstDateTime, lst2))
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
                slbNhomKV.SetTenByMa(dgvMain.SelectedRows[0].Cells["colMaNhom"].Value.ToString());


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
                Dictionary<string, string> dicLike = new Dictionary<string, string>();
                dicLike.Add(cls_STT_KhuVuc.col_Ma, txtTimKiem.Text);
                dicLike.Add(cls_STT_KhuVuc.col_Ten, txtTimKiem.Text);


                dgvMain.DataSource = _api.Search(ref _userError, ref _systemError, cls_STT_KhuVuc.tb_TenBang, andLike: false, dicLike: dicLike,
                                                    orderByASC1: true, orderByName1: cls_STT_KhuVuc.col_ID);
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

        private void Load_NhomKhuVuc()
        {
            try
            {
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_STT_NhomKhuVuc.col_TamNgung, "1");
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_STT_NhomKhuVuc.col_Ma);
                lstColumns.Add(cls_STT_NhomKhuVuc.col_Ten);

                slbNhomKV.DataSource = _api.Search(ref _userError, ref _systemError, cls_STT_NhomKhuVuc.tb_TenBang, lst: lstColumns, dicDifferent: dicD,
                                                    orderByASC1: true, orderByName1: cls_STT_NhomKhuVuc.col_Ten);
                colMaNhom.DataSource = slbNhomKV.DataSource;
                colMaNhom.DisplayMember = cls_STT_NhomKhuVuc.col_Ten;
                colMaNhom.ValueMember = cls_STT_NhomKhuVuc.col_Ma;
            }
            catch
            {
                slbNhomKV.DataSource = null;
            }
        }

        private void Load_KhuCLS()
        {
            try
            {
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                //
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_CDHA_DMLOAI.col_Id);
                lstColumns.Add(cls_CDHA_DMLOAI.col_Ten);
                

                DataTable dt = _api.Search(ref _userError, ref _systemError, cls_CDHA_DMLOAI.tb_TenBang, lst: lstColumns, 
                                                    orderByASC1: true, orderByName1: cls_CDHA_DMLOAI.col_Id);
                DataRow row = dt.NewRow();
                row[cls_CDHA_DMLOAI.col_Id] = "256";
                row[cls_CDHA_DMLOAI.col_Ten] = "X quang, CT scan, MRI";
                dt.Rows.Add(row);
                dt.AcceptChanges();
                slbTen.DataSource = dt;
            }
            catch
            {
                slbTen.DataSource = null;
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

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGhiChu.Focus();
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

        private void lblNhom_Click(object sender, EventArgs e)
        {
            frm_NhomKhuVuc frm = new frm_NhomKhuVuc();
            frm.ShowDialog();
            Load_NhomKhuVuc();
        }

        private void slbNhomKV_HisSelectChange(object sender, EventArgs e)
        {
            if (slbNhomKV.txtMa.Text == "CANLAMSANG")
            {
                Load_KhuCLS();
                slbTen.his_AddNew = false;
            }
            else
            {
                slbTen.DataSource = null;
                slbTen.his_AddNew = true;
            }
        }

        #endregion


    }
}
