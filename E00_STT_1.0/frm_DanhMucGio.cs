using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E00_Base;
using E00_Common;
using E00_Model;
using E00_System;

namespace E00_STT
{

    public partial class frm_DanhMucGio : frm_DanhMuc
    {
        #region Khai báo biến toàn cục
        private Acc_Oracle _acc = new Acc_Oracle();
        private Api_Common _api = new Api_Common();
        private clsBUS _bus = new clsBUS();
        private string _userError, _systemError, _id = string.Empty;
        private int _rowIndex = 0;
        private bool _isAdd = false;
        private string _lstID = "";
        private string _lstTen = "";
        private bool _isCheck = false;
        #endregion

        #region Khởi tạo
        public frm_DanhMucGio()
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
            TimKiem();
            base.LoadData();
            _isCheck = true;
        }

        protected override void Them()
        {
            base.Them();
            _isAdd = true;
            dtiTimeBegin.Value = new DateTime(_bus.Get_curDate().Year, _bus.Get_curDate().Month, _bus.Get_curDate().Day, 0, 0, 0);
            dtiTimeEnd.Value = new DateTime(_bus.Get_curDate().Year, _bus.Get_curDate().Month, _bus.Get_curDate().Day, 0, 0, 0);
            chkTamNgung.Checked = false;
            dtiTimeBegin.Focus();
        }

        protected override void Sua()
        {
            base.Sua();
            _isAdd = false;
            txtTimKiem.Focus();
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
                    _lstTen = dgvMain.SelectedRows[0].Cells["colTimeBegin"].Value.ToString() + " - " + dgvMain.SelectedRows[0].Cells["colTimeEnd"].Value.ToString();
                }

                DialogResult rsl = TA_MessageBox. MessageBox.Show("Bạn có chắc chắn muốn xóa: \n" + _lstTen
                     ,TA_MessageBox.MessageIcon.Question);

                if (rsl == System.Windows.Forms.DialogResult.Yes)
                {

                    if (_api.DeleteAll(ref _userError, ref _systemError, cls_STT_TimeZone.tb_TenBang, _lstID))
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

                if (dtiTimeBegin.Value == dtiTimeEnd.Value)
                {
                    TA_MessageBox.MessageBox.Show("Thời gian bắt đầu và thời gian kết thúc bằng nhau", TA_MessageBox.MessageIcon.Error);
                    dtiTimeEnd.Focus();
                    return;
                }

                #endregion

                Dictionary<string, string> lstData = new Dictionary<string, string>();
                lstData.Add(cls_STT_TimeZone.col_TimeBegin, dtiTimeBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                lstData.Add(cls_STT_TimeZone.col_TimeEnd, dtiTimeEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                lstData.Add(cls_STT_TimeZone.col_TamNgung, chkTamNgung.Checked ? "1" : "0");
                lstData.Add(cls_STT_TimeZone.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_TimeZone.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                if (_isAdd)
                {
                    lstData.Add(cls_STT_TimeZone.col_UserID, cls_System.sys_UserID);
                    lstData.Add(cls_STT_TimeZone.col_NgayTao, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    List<string> lstKiemTraTrung = new List<string>();
                    lstKiemTraTrung.Add(cls_STT_TimeZone.col_TimeBegin);

                    if (_api.Insert(ref _userError, ref _systemError, cls_STT_TimeZone.tb_TenBang
                                    , lstData
                                    , lstKiemTraTrung
                                    , new List<string>()))
                    {
                        TimKiem();
                        if (dgvMain.RowCount > 0)
                        {
                            dgvMain.Rows[dgvMain.RowCount - 1].Cells["colTimeBegin"].Selected = true;
                        }
                        dgvMain.FirstDisplayedScrollingRowIndex = dgvMain.RowCount - 1;
                        base.Luu();
                        btnThem.Focus();
                    }
                }
                else
                {
                    Dictionary<string, string> lst2 = new Dictionary<string, string>();
                    lst2.Add(cls_STT_TimeZone.col_ID, dgvMain.SelectedRows[0].Cells["colID"].Value.ToString());
                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_TimeZone.col_NgayUD);
                    lstDateTime.Add(cls_STT_TimeZone.col_TimeBegin);
                    lstDateTime.Add(cls_STT_TimeZone.col_TimeEnd);
                    if (_api.Update(ref _userError, ref _systemError, cls_STT_TimeZone.tb_TenBang, lstData, lstDateTime, lst2))
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
                try
                {
                    dtiTimeBegin.Value = DateTime.Parse(dgvMain.SelectedRows[0].Cells["colTimeBegin"].Value.ToString());
                    dtiTimeEnd.Value = DateTime.Parse(dgvMain.SelectedRows[0].Cells["colTimeEnd"].Value.ToString());
                    try
                    {
                        chkTamNgung.Checked = dgvMain.SelectedRows[0].Cells["colTamNgung"].Value.ToString() == "1";
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                base.Show_ChiTiet();
            }
            catch
            {
                DateTime dtaNull = new DateTime(_bus.Get_curDate().Year, _bus.Get_curDate().Month, _bus.Get_curDate().Day, 0, 0, 0);
                dtiTimeBegin.Value = dtiTimeEnd.Value = dtaNull;
            }

        }

        protected override void TimKiem()
        {
            try
            {
                _lstID = _lstTen = "";
                Dictionary<string, string> dicLike = new Dictionary<string, string>();
                dicLike.Add(cls_STT_TimeZone.col_TimeBegin, txtTimKiem.Text);
                dicLike.Add(cls_STT_TimeZone.col_TimeEnd, txtTimKiem.Text);


                dgvMain.DataSource = _api.Search(ref _userError, ref _systemError, cls_STT_TimeZone.tb_TenBang, andLike: false, dicLike: dicLike,
                                                    orderByASC1: true, orderByName1: cls_STT_TimeZone.col_ID);
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
                if (_isCheck)
                {
                    if (e.ColumnIndex == dgvMain.Columns["colCheck"].Index)
                    {
                        if (dgvMain.Rows[e.RowIndex].Cells["colCheck"].Value.ToString() == "False")
                        {
                            if (_lstID.Contains(dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()))
                            {
                                _lstID = _lstID.Replace(string.Format("{0},", dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()), "");
                                //_lstTen = _lstTen.Replace(string.Format("\n{0} ", dgvMain.SelectedRows[0].Cells["colTimeBegin"].Value.ToString() + " - " + dgvMain.SelectedRows[0].Cells["colTimeEnd"].Value.ToString()), "");
                                _lstTen = _lstTen.Replace(string.Format("\n{0} ", DateTime.Parse(dgvMain.SelectedRows[0].Cells["colTimeBegin"].Value.ToString()).ToString("HH:mm") + " - " + DateTime.Parse(dgvMain.SelectedRows[0].Cells["colTimeEnd"].Value.ToString()).ToString("HH:mm")), "");
                            }
                        }
                        else
                        {
                            if (!_lstID.Contains(dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString()))
                            {
                                _lstID += string.Format("{0},", dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                                //_lstTen += string.Format("\n{0} ", dgvMain.SelectedRows[0].Cells["colTimeBegin"].Value.ToString() + " - " + dgvMain.SelectedRows[0].Cells["colTimeEnd"].Value.ToString());
                                _lstTen += string.Format("\n{0} ", DateTime.Parse(dgvMain.SelectedRows[0].Cells["colTimeBegin"].Value.ToString()).ToString("HH:mm") + " - " + DateTime.Parse(dgvMain.SelectedRows[0].Cells["colTimeEnd"].Value.ToString()).ToString("HH:mm"));
                            }
                        }
                    }
                }
            }
            catch
            {
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
                        //_lstTen += string.Format("\n{0} ", dgvMain.Rows[i].Cells["colTimeBegin"].Value.ToString() + " - " + dgvMain.Rows[i].Cells["colTimeEnd"].Value.ToString());
                        _lstTen += string.Format("\n{0} ", DateTime.Parse(dgvMain.Rows[i].Cells["colTimeBegin"].Value.ToString()).ToString("HH:mm") + " - " + DateTime.Parse(dgvMain.Rows[i].Cells["colTimeEnd"].Value.ToString()).ToString("HH:mm"));
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

        private void dtiTimeEnd_Enter(object sender, EventArgs e)
        {
            btnLuu.Focus();
        }
        #endregion

    }
}
