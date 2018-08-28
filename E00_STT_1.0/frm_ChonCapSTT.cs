using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E00_Base;
using E00_Model;
using E00_Common;

namespace E00_STT
{
    public partial class frm_ChonCapSTT : frm_Base
    {

        #region Biến toàn cục

        private clsBUS _bus = new clsBUS();
        private DataTable _dtKhuVuc = new DataTable();
        private DataTable _dtPhong = new DataTable();
        private int _loai = -1;
        private string _maKP = "   ";
        private string _makhu = "";
        private bool _isCall = false;//đang gọi số
        private bool _isNotDanhSach = true;//false để mở form Lấy số từ danh sách bệnh nhân dược và cls.
        public string _maNoiCap = "";

        public string Makhu
        {
            get { return _makhu; }

        }
        private string _manhom = "";

        public string Manhom
        {
            get { return _manhom; }

        }
        public string MaKP
        {
            get { return _maKP; }
        }

        public string MaBS
        {
            get
            {
                return slbBS.txtTen.Text;
            }
        }
        #endregion

        #region Khởi tạo

        /// <summary>
        /// Vannq 13/04/2018
        /// </summary>
        /// <param name="danhSach">"false" để Cấp STT,"true" để chọn BN có toa</param>
        public frm_ChonCapSTT(bool danhSach)
        {
            InitializeComponent();
            _isNotDanhSach = danhSach;
        }
        public frm_ChonCapSTT(int loai)
        {
            InitializeComponent();

            _loai = loai;
        }
        public frm_ChonCapSTT(int loai, int Phongso)
        {
            InitializeComponent();
             this.Text = "Chọn phòng số " + Phongso;
            _loai = loai;
        }
        public frm_ChonCapSTT(int loai, int Phongso, string manhom, string makhu)
        {
            InitializeComponent();
            this.Text = "Chọn phòng số " + Phongso;
            _loai = loai;
            _makhu = makhu;
            _manhom = manhom;



        }

        #endregion

        #region Phương thức

        private void LoadData()
        {
            slbNhom.DataSource = _bus.Get_NhomKhuVuc(true);
            _dtKhuVuc = _bus.Get_KhuVuc(true);
            _dtPhong = _bus.Get_PhongBanNhomKhu();
            slbBS.Show_Count = 10;
            slbBS.DataSource = _bus.Get_BacSi();
        }

        #endregion

        #region Sự kiện

        private void frm_ChonCapSTT_Load(object sender, EventArgs e)
        {
            if (!_isNotDanhSach) btnDongY.Text = "Danh sách";
            LoadData();
        
            slbNhom.txtTen.Focus();
            if (!string.IsNullOrEmpty(_manhom))
            {
                slbNhom.SetTenByMa(_manhom);
            }
            if (!string.IsNullOrEmpty(_makhu))
            {
                slbKhu.SetTenByMa(_makhu);
                if (!(string.IsNullOrEmpty(slbKhu.txtTen.Text)))
                {
                    btnDongY.Enabled = true;
                }
                else
                {
                    btnDongY.Enabled = false;
                    slbPhong.clear();
                }
            }
        }

        private void slbNhom_HisSelectChange(object sender, EventArgs e)
        {
            slbKhu.clear();
            slbPhong.clear();
            try
            {
                if (slbNhom.txtMa.Text != "ALL")
                {
                    slbKhu.DataSource = _dtKhuVuc.Select(string.Format("MaNhom = '{0}'", slbNhom.txtMa.Text)).CopyToDataTable();
                }
                else
                {
                    slbKhu.DataSource = _bus.Get_KhuVuc(true);
                }
            }
            catch
            {
                slbKhu.DataSource = null;
            }
            try
            {
                slbPhong.DataSource = _dtPhong.Select(string.Format("MaNhomKhu = '{0}'", slbNhom.txtMa.Text)).CopyToDataTable();
            }
            catch
            {
                slbPhong.DataSource = null;
            }
        }

        private void slbKhu_HisSelectChange(object sender, EventArgs e)
        {
            try
            {
                slbPhong.clear();
                if (!(string.IsNullOrEmpty(slbKhu.txtTen.Text)))
                {
                    if (!_isCall)
                    {
                        btnDongY.Enabled = true;
                    }

                }
                else
                {
                    btnDongY.Enabled = false;
                    slbPhong.clear();
                }

                if (slbKhu.txtMa.Text == "")
                {
                    slbPhong.DataSource = _dtPhong.Select(string.Format("MaNhomKhu = '{0}'", slbNhom.txtMa.Text)).CopyToDataTable();
                }
                else
                {
                    slbPhong.DataSource = _dtPhong.Select(string.Format("MaNhom = '{0}'", slbKhu.txtMa.Text)).CopyToDataTable();
                }
            }
            catch
            {
                slbPhong.DataSource = null;
            }
        }

        private void slbPhong_HisSelectChange(object sender, EventArgs e)
        {
            try
            {
                if (_isCall)
                {
                    if (!(string.IsNullOrEmpty(slbPhong.txtTen.Text)))
                    {
                        btnDongY.Enabled = true;
                    }   
                    else
                    {
                        btnDongY.Enabled = false;
                    }
                }
            }
            catch
            {
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (_isNotDanhSach)
            {
                if (_loai == -1)
                {
                    frm_CapSTT frm = new frm_CapSTT(slbNhom.txtMa.Text, slbKhu.txtMa.Text, slbPhong.txtMa.Text);
                    this.Hide();
                    if (!_bus.CheckOpened(frm.Text))
                    {
                        frm.Show();
                    }
                    else
                    {
                        Application.OpenForms[frm.Name].Focus();
                    }
                    frm.FormClosed += delegate { this.Show(); };
                }
                else if (_loai == 1)
                {
                    if ((string.IsNullOrEmpty(slbPhong.txtMa.Text)))
                    {
                        _maNoiCap = "K" + slbKhu.txtMa.Text;
                    }
                    else
                    {
                        _maNoiCap = "P" + slbPhong.txtMa.Text;
                    }
                    this.Close();
                }
                else if (_loai == 2)
                {
                    string makp = "";
                    string tenpk = "";
                    if ((string.IsNullOrEmpty(slbPhong.txtMa.Text)))
                    {
                        makp = "K" + slbKhu.txtMa.Text;
                        tenpk = slbKhu.txtTen.Text;
                    }
                    else
                    {
                        makp = "P" + slbPhong.txtMa.Text;
                        tenpk = slbPhong.txtTen.Text;
                    }

                    this._maKP = makp;
                    _manhom = slbNhom.txtMa.Text;
                    _makhu = slbKhu.txtMa.Text;
                    this.Close();
                    return;
                }
            }
            else
            {
                string nhathuoc = _bus.GetNhaThuoc(slbNhom.txtMa.Text);
                frm_QuetDSCho f = new frm_QuetDSCho(slbKhu.txtTen.Text,slbPhong.txtTen.Text, slbKhu.txtMa.Text, slbPhong.txtMa.Text,nhathuoc);
                this.Hide();
                if (!_bus.CheckOpened(f.Text))
                {
                    f.Show();
                }
                else
                {
                    Application.OpenForms[f.Name].Focus();
                }
                f.FormClosed += delegate { this.Show(); };
            }
        }

        private void slbKhu_Validating(object sender, CancelEventArgs e)
        {

        }

        private void slbKhu_Validated(object sender, EventArgs e)
        {

        }

        private void slbKhu_HisSearchData(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
