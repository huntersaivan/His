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

namespace HISQLHSBA
{
    /* Quản lý danh mục vị trí bao gồm:
        - Loại vị trí
        - Danh mục giá
        - Danh mục tầng
        - Danh mục ô */
    public partial class frm_DanhMucViTri : frm_DanhMuc
    {
        #region Biến toàn cục

        private Api_Common _api = new Api_Common();

        private int _rowIndex = 0;
        //Lưu chỉ số dòng datagridview
       
        private bool _isAdd = false;
        //Lưu trạng thái đang thêm mới

        private bool _isDesign = true;
        //lưu trạng thái đang xử lý giao diện sẽ không chạy những sự kiện khi load form

        private bool _isFind = true;
        //Lưu trạng thái đang tìm kiếm

        private string _userError = "";
        //Lưu lỗi người dùng

        private string _systemError = "";
        //Lưu lỗi hệ thống

        private string _lstID = "";
        //Lưu danh sách ID xóa nhiều

        private string _lstTen = "";
        //Lưu tên đối tượng cần xóa 

        #endregion

        #region Khởi tạo

        public frm_DanhMucViTri()
        {
            InitializeComponent();
            _api.KetNoi();
        }

        #endregion

        #region Phương thức

        #region Protected Override

        protected override void LoadData()
        {
            _isDesign = true;
            Load_Loai();          
            TimKiem();
            base.LoadData();
            _isDesign = false;
        }

        protected override void Them()
        {
            base.Them();
            _isAdd = true;
            txtTen.Text = "";
            chkTamNgung.Checked = false;
            if (slbLoai.txtMa.Text == "")
            {
                slbLoai.txtTen.Focus();
            }
            else
            {
                txtTen.Focus();
            }
        }

        protected override void Sua()
        {
            base.Sua();
            _isAdd = false;
            _isFind = false;
            Show_Chi_Tiet();
            txtTen.Focus();
        }

        protected override void Xoa()
        {
            try
            {
                if (_lstID.Length > 0)
                {
                    _lstID = _lstID.Substring(0, _lstID.Length - 1);
                    _lstTen = _lstTen.Substring(0, _lstTen.Length - 1);
                }
                else
                {
                    _lstID = dgvMain.SelectedRows[0].Cells["colID"].Value.ToString();
                    _lstTen = dgvMain.SelectedRows[0].Cells["colTen"].Value.ToString();
                }

                DialogResult rsl = TA_MessageBox.MessageBox.Show("Bạn có chắc chắn muốn xóa: \n" + _lstTen,
                      TA_MessageBox.MessageIcon.Question);

                if (rsl == System.Windows.Forms.DialogResult.Yes)
                {

                    if (_api.DeleteAll(ref _userError, ref _systemError,cls_DanhMucViTri.tb_TenBang,_lstID))
                    {
                        txtTen.Text = "";
                        TimKiem();
                        _lstID = _lstTen = "";
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

                if (string.IsNullOrEmpty(slbLoai.txtMa.Text) && string.IsNullOrEmpty(slbLoai.txtTen.Text))
                {
                    TA_MessageBox.MessageBox.Show("Loại không được để trống! Vui lòng nhập lại.",TA_MessageBox.MessageIcon.Error);
                    slbLoai.txtTen.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTen.Text))
                {
                    TA_MessageBox.MessageBox.Show("Loại không được để trống! Vui lòng nhập lại.", TA_MessageBox.MessageIcon.Error);
                    txtTen.Focus();
                    return;
                }

                #endregion

                Dictionary<string, string> lstData = new Dictionary<string, string>();             
                lstData.Add(cls_DanhMucViTri.col_Ten, txtTen.Text.Trim());
                lstData.Add(cls_DanhMucViTri.col_TenGoc, txtTen.Text.Trim());
                lstData.Add(cls_DanhMucViTri.col_Loai, slbLoai.txtMa.Text);
                lstData.Add(cls_DanhMucViTri.col_TamNgung, chkTamNgung.Checked ? "1" : "0");
                lstData.Add(cls_DanhMucViTri.col_TinhTrang, chkFull.Checked ? "1" : "0");
                lstData.Add(cls_DanhMucViTri.col_UserID, cls_System.sys_UserID);
                lstData.Add(cls_DanhMucViTri.col_NgayTao, (new Acc_Oracle()).Get_MMYY());
                lstData.Add(cls_DanhMucViTri.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_DanhMucViTri.col_NgayUD, (new Acc_Oracle()).Get_MMYY());
                //lst.Add(cls_DanhMucViTri.col_MaCHINEID, cls_Common);
                if (_isAdd)
                {
                    lstData.Add(cls_DanhMucViTri.col_Ma, cls_Common.BoDau(txtTen.Text.Trim()).Replace(" ", ""));
                    List<string> lstKiemTraTrung = new List<string>();                
                    lstKiemTraTrung.Add(cls_DanhMucViTri.col_Ten);
                    if (_api.Insert(ref _userError, ref _systemError, cls_DanhMucViTri.tb_TenBang
                                    ,lstData
                                    , lstKiemTraTrung
                                    , new List<string>()))
                    {
                        txtTen.Text = "";
                        TimKiem();
                        base.Luu();
                        slbLoai.Enabled = true;
                        btnThem.Focus();
                    }
                
                }
                else
                {
                    Dictionary<string, string> lst2 = new Dictionary<string, string>();
                    lst2.Add(cls_DanhMucViTri.col_ID, dgvMain.SelectedRows[0].Cells["colID"].Value.ToString());

                    if (_api.Update(ref _userError, ref _systemError, cls_DanhMucViTri.tb_TenBang
                                    , lstData
                                    , new List<string>()
                                    , lst2))
                    {
                        txtTen.Text = "";
                        _isFind = true;
                        TimKiem();
                        // dgvMain.Rows[_rowIndex].Selected = true;
                        base.Luu();
                        slbLoai.Enabled = true;
                        btnThem.Focus();
                    }
                }
            }
            catch
            {
            }
        }

        protected override void TimKiem()
        {
            try
            {

                if (slbLoai.txtMa.Text != "")
                {
                    Dictionary<string, string> dicLike = new Dictionary<string, string>();
                    if (txtTen.Text != "")
                    {
                        dicLike.Add(cls_DanhMucViTri.col_Ten, txtTen.Text);
                    }
                    else
                    {
                        dicLike.Add(cls_DanhMucViTri.col_Ten, _chuoiTimKiem);
                    }

                    Dictionary<string, string> dicEqual = new Dictionary<string, string>();
                    dicEqual.Add(cls_DanhMucViTri.col_Loai, slbLoai.txtMa.Text);

                    dgvMain.DataSource = _api.Search(ref _userError, ref _systemError, cls_DanhMucViTri.tb_TenBang,andLike : false, dicLike: dicLike, dicEqual: dicEqual,
                                                        orderByASC1: true, orderByName1: cls_DanhMucViTri.col_ID);
                    _count = dgvMain.RowCount;
                    base.TimKiem();
                }

            }
            catch
            {
                dgvMain.DataSource = null;
            }
        }

        #endregion

        #region Private

        #region Load loại danh mục vị trí
        private void Load_Loai()
        {
            try
            {
                //DataTable dtLoai = new DataTable();
                //dtLoai.Columns.Add("Ma");
                //dtLoai.Columns.Add("Ten");

                //DataRow row = dtLoai.NewRow();
                //row["Ma"] = "GIA";
                //row["Ten"] = "Giá";
                //dtLoai.Rows.Add(row);

                //row = dtLoai.NewRow();
                //row["Ma"] = "TANG";
                //row["Ten"] = "Tầng";
                //dtLoai.Rows.Add(row);

                //row = dtLoai.NewRow();
                //row["Ma"] = "O";
                //row["Ten"] = "Ô";
                //dtLoai.Rows.Add(row);

                //row = dtLoai.NewRow();
                //row["Ma"] = "Vitri";
                //row["Ten"] = "Danh mục vị trí";
                //dtLoai.Rows.Add(row);

                //slbLoai.DataSource = dtLoai;
                //slbLoai.txtMa.Text = dtLoai.Rows[0]["Ma"].ToString();
                //slbLoai.txtTen.Text = dtLoai.Rows[0]["Ten"].ToString();
                //slbLoai.his_SetSelectedIndex = 0;
                try
                {
                    List<string> list = new List<string>();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add(cls_DanhMucViTri.col_Loai, "Vitri");
                    list.Add(cls_DanhMucViTri.col_Ma);
                    list.Add(cls_DanhMucViTri.col_Ten);
                    this.slbLoai.DataSource = _api.Search(ref this._userError, ref this._systemError, cls_DanhMucViTri.tb_TenBang, null, -1, list, true, dic);
                    this.slbLoai.Show_Count = 10;
                    slbLoai.his_SetSelectedIndex = 0;
                }
                catch
                {
                }
            }
            catch
            {

            }
        } 
        #endregion

        #region Binding data lên textbox
        private void Show_Chi_Tiet()
        {
            try
            {
                txtTen.Text = dgvMain.SelectedRows[0].Cells["colTen"].Value.ToString();
            }
            catch
            {
                txtTen.Text = "";
            }
        } 
        #endregion

        #endregion

        #endregion

        #region Event

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isDesign) return;
                
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

                    //chọn cell thì check checkbox
                    DataGridViewCheckBoxCell cell = this.dgvMain.CurrentCell as DataGridViewCheckBoxCell;
                    if (cell != null)
                    {
                        cell.Value = cell.Value == null || !((bool)cell.Value);
                        this.dgvMain.RefreshEdit();
                        this.dgvMain.NotifyCurrentCellDirty(true);
                    }

                    //// bỏ checkall
                    if (dgvMain.Rows[e.RowIndex].Cells["colCheck"].Value != null)
                    {
                        if ((dgvMain.Rows[e.RowIndex].Cells["colCheck"].Value.ToString() == "False"))
                        {
                            chkAll.Checked = false;
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
            if (_isDesign) return;
            if (e.KeyCode == Keys.Enter)
            {
                btnLuu.Focus();
            }
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isDesign) return;
                _lstID = _lstTen = "";
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    dgvMain.Rows[i].DataGridView["colCheck", i].Value = !chkAll.Checked;
                    if (chkAll.Checked)
                    {
                        _lstID += string.Format("{0},", dgvMain.Rows[i].Cells["colID"].Value.ToString());
                        _lstTen += string.Format("{0}\n", dgvMain.Rows[i].Cells["colTen"].Value.ToString());
                    }
                }
            }
            catch { }
        }

        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_isDesign) return;
                if (e.ColumnIndex == dgvMain.Columns["colCheck"].Index)
                {
                    if (dgvMain.SelectedRows[0].Cells["colCheck"].Value.ToString() == "False")
                    {
                        if (_lstID.Contains(dgvMain.SelectedRows[0].Cells["colID"].Value.ToString()))
                        {
                            _lstID = _lstID.Replace(string.Format("{0},", dgvMain.SelectedRows[0].Cells["colID"].Value.ToString()), "");
                            _lstTen = _lstTen.Replace(string.Format("{0}\n", dgvMain.SelectedRows[0].Cells["colTen"].Value.ToString()), "");
                        }
                    }
                    else
                    {
                        if (!_lstID.Contains(dgvMain.SelectedRows[0].Cells["colID"].Value.ToString()))
                        {
                            _lstID += string.Format("{0},", dgvMain.SelectedRows[0].Cells["colID"].Value.ToString());
                            _lstTen += string.Format("{0}\n", dgvMain.SelectedRows[0].Cells["colTen"].Value.ToString());
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void dgvMain_DoubleClick(object sender, EventArgs e)
        {
            if (_isDesign) return;
            Show_Chi_Tiet();
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            if (_isFind)
            {
                if (_isDesign) return;
                TimKiem();
            }
        }

        private void slbNhom_HisSelectChange(object sender, EventArgs e)
        {
            if (_isFind)
            {
                if (_isDesign) return;
                TimKiem();
            }
            btnLuu.Focus();
        }

        private void slbLoai_HisSelectChange(object sender, EventArgs e)
        {
            if (_isDesign) return;
            txtTen.Text = "";
            TimKiem();
        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isDesign) return;
            if (e.KeyCode == Keys.Enter)
            {
                btnLuu.Focus();
            }
        }

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (_isDesign) return;
            Show_Chi_Tiet();
            this.txtTen.TextChanged -= new System.EventHandler(this.txtTen_TextChanged);
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isDesign) return;
            this.dgvMain.RefreshEdit();
            this.dgvMain.NotifyCurrentCellDirty(true);
        }

        #endregion

    }
}
