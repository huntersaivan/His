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
    public partial class frm_NhomKhuVuc : frm_DanhMuc
    {
        #region Biến toàn cục

        private int _rowIndex = 0;
        private Api_Common _api = new Api_Common();
        private clsBUS _bus = new clsBUS();
        private bool _isAdd = false;
        private string _userError = "";
        private string _systemError = "";
        private string _lstID = "";
        private string _lstTen = "";
        private bool _isCheck = false;

        #endregion

        #region Khởi tạo

        public frm_NhomKhuVuc()
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
            LoadLoaiNhomkhu();
            TimKiem();
            base.LoadData();
            _isCheck = true;
        }

        protected override void Them()
        {
            base.Them();
            _isAdd = true;
            txtTen.Text =
                txtGhiChu.Text = "";
            chkTamNgung.Checked = false;
            txtTen.Focus();
        }

        protected override void Sua()
        {
            base.Sua();
            _isAdd = false;
            txtTen.Focus();
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
                        lstWhere.Add(cls_STT_NhomKhuVuc.col_ID, item);
                        if (dt != null && dt.Rows.Count > 0 && _bus.Get_KhuVuc(dt.Rows[0][cls_STT_NhomKhuVuc.col_Ma].ToString()).Rows.Count > 0)
                        {
                            TA_MessageBox.MessageBox.Show("Nhóm khu vực \"" + _lstTen.Split(',')[i] + "\" đang được tham chiếu bởi: " +
                                                            _bus.Get_KhuVuc(dt.Rows[0][cls_STT_NhomKhuVuc.col_Ma].ToString()).Rows.Count + " Khu vực vui lòng xóa các tham chiếu trước!"
                                                              ,TA_MessageBox.MessageIcon.Error);
                        }
                        else
                        {
                            _api.Delete(ref _userError, ref _systemError, cls_STT_NhomKhuVuc.tb_TenBang, lstWhere);
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


                if (string.IsNullOrEmpty(txtTen.Text))
                {
                    TA_MessageBox.MessageBox.Show("Tên không được để trống! Vui lòng nhập lại.",TA_MessageBox.MessageIcon.Error);
                    txtTen.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(slbLoai.txtMa.Text))
                {
                    TA_MessageBox.MessageBox.Show("Loại không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                    slbLoai.Focus();
                    return;
                }

                #endregion

                Dictionary<string, string> lstData = new Dictionary<string, string>();
                lstData.Add(cls_STT_NhomKhuVuc.col_STT, "0");

               

                lstData.Add(cls_STT_NhomKhuVuc.col_Ten, txtTen.Text.Trim());
                lstData.Add(cls_STT_NhomKhuVuc.col_GhiChu, txtGhiChu.Text);
                lstData.Add(cls_STT_NhomKhuVuc.col_TamNgung, chkTamNgung.Checked ? "1" : "0");
                lstData.Add(cls_STT_NhomKhuVuc.col_MaLoai, slbLoai.txtMa.Text);

                lstData.Add(cls_STT_NhomKhuVuc.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_NhomKhuVuc.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                //lst.Add(cls_STT_NhomKhuVuc.col_MaCHINEID, cls_Common);
                if (_isAdd)
                {
                    lstData.Add(cls_STT_NhomKhuVuc.col_Ma, cls_Common.BoDau(txtTen.Text.Trim()).Replace(" ", ""));
                    lstData.Add(cls_STT_NhomKhuVuc.col_UserID, cls_System.sys_UserID);
                    lstData.Add(cls_STT_NhomKhuVuc.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_NhomKhuVuc.col_Ma);
                    lstKiemTraTrung.Add(cls_STT_NhomKhuVuc.col_Ten);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_NhomKhuVuc.tb_TenBang
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
                    lst2.Add(cls_STT_NhomKhuVuc.col_ID, dgvMain.SelectedRows[0].Cells["colID"].Value.ToString());
                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_NhomKhuVuc.col_NgayUD);

                    if (_api.Update(ref _userError, ref _systemError, cls_STT_NhomKhuVuc.tb_TenBang, lstData, lstDateTime, lst2))
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
                txtTen.Text = dgvMain.SelectedRows[0].Cells["colTen"].Value.ToString();
                txtGhiChu.Text = dgvMain.SelectedRows[0].Cells["colGhiChu"].Value.ToString();
                try
                {
                    chkTamNgung.Checked = dgvMain.SelectedRows[0].Cells["colTamNgung"].Value.ToString() == "1";
                }
                catch { }
                try
                {
                    slbLoai.SetTenByMa(dgvMain.SelectedRows[0].Cells["colLoai"].Value.ToString());
                }
                catch { }
                base.Show_ChiTiet();
            }
            catch
            {
                txtTen.Text =
                     txtGhiChu.Text = "";
            }
        }

        protected override void TimKiem()
        {
            try
            {
                _lstID = _lstTen = "";
                Dictionary<string, string> dicLike = new Dictionary<string, string>();
                dicLike.Add(cls_STT_NhomKhuVuc.col_Ma, txtTimKiem.Text);
                dicLike.Add(cls_STT_NhomKhuVuc.col_Ten, txtTimKiem.Text);

                dgvMain.DataSource = _api.Search(ref _userError, ref _systemError, cls_STT_NhomKhuVuc.tb_TenBang, andLike: false, dicLike: dicLike,
                                                    orderByASC1: true, orderByName1: cls_STT_NhomKhuVuc.col_ID);
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

        private void LoadLoaiNhomkhu()
        {
            DataTable dtLoai = new DataTable();
            dtLoai.Columns.Add("Ma");
            dtLoai.Columns.Add("Ten");

            DataRow row = dtLoai.NewRow();
            row["Ma"] = "HUONGDAN";
            row["Ten"] = "Hướng dẫn";
            dtLoai.Rows.Add(row);

            row = dtLoai.NewRow();
            row["Ma"] = "TIEPDON";
            row["Ten"] = "Tiếp đón";
            dtLoai.Rows.Add(row);

            row = dtLoai.NewRow();
            row["Ma"] = "PHONGKHAM";
            row["Ten"] = "Phòng khám";
            dtLoai.Rows.Add(row);

            row = dtLoai.NewRow();
            row["Ma"] = "NHATHUOC";
            row["Ten"] = "Nhà thuốc";
            dtLoai.Rows.Add(row);

            row = dtLoai.NewRow();
            row["Ma"] = "CANLAMSANG";
            row["Ten"] = "Cận lâm sàng";
            dtLoai.Rows.Add(row);

            row = dtLoai.NewRow();
            row["Ma"] = "VIENPHI";
            row["Ten"] = "Viện phí";
            dtLoai.Rows.Add(row);

            slbLoai.DataSource = dtLoai;

            colLoai.DataSource = dtLoai;
            colLoai.DisplayMember = "Ten";
            colLoai.ValueMember = "Ma";
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

        #endregion

    }
}
