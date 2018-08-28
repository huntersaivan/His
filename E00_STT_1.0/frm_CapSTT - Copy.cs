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
using E00_System;
using E00_Common;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Media;
using System.Runtime.InteropServices;

namespace E00_STT
{
    public partial class frm_CapSTT : frm_Base
    {

        #region Biến toàn cục

        private clsBUS _bus = new clsBUS();
        private string _maNhom = "";
        private string _maKhu = "";
        private string _maPhong = "";
        private DataTable _dtKhuVuc = new DataTable();
        private DataTable _dtPhong = new DataTable();

        private Api_Common _api = new Api_Common();
        private string _userError = "";
        private string _systemError = "";
        private string _idCapSTT = "";

        #endregion

        #region Khởi tạo

        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string lpszName, int hModule, int dwFlags);

        public frm_CapSTT()
        {
            InitializeComponent();
            //this.Left = 500;
            //this.Top = 500;
        }

        public frm_CapSTT(string maNhom, string maKhu, string maPhong)
        {
            InitializeComponent();
            _maNhom = maNhom;
            _maKhu = maKhu;
            _maPhong = maPhong;
            this.Height = 100;
        }

        #endregion

        #region Phương thức

        private void LoadData()
        {
            slbNhom.DataSource = _bus.Get_NhomKhuVuc(_maNhom);
            _dtKhuVuc = _bus.Get_KhuVuc(true);
            _dtPhong = _bus.Get_PhongBanNhomKhu();
        }

        private bool CapSTT()
        {
            DataRow drCapSo = null;
            string stt = "";
            try
            {
                Dictionary<string, string> lstData = new Dictionary<string, string>();
                if (slbKhu.txtMa.Text == "ALL")
                {
                    frm_CapSTTTatCa frm = new frm_CapSTTTatCa(slbNhom.txtMa.Text, "");
                    frm.ShowDialog();
                }
                if (slbPhong.txtMa.Text != "")
                {
                    lstData.Add(cls_STT_CapSo.col_MaNoiCap, cls_STT_KhuVucPhong.col_Phong + slbPhong.txtMa.Text);

                }
                else if (slbKhu.txtMa.Text != "")
                {
                    lstData.Add(cls_STT_CapSo.col_MaNoiCap, cls_STT_KhuVucPhong.col_KhuVuc + slbKhu.txtMa.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn khu hoặc Phòng");
                    slbKhu.txtTen.Focus();
                    return false;
                }

                try
                {
                    Dictionary<string, string> dicE = new Dictionary<string, string>();
                    dicE.Add(cls_STT_DinhNghia.col_Ma, lstData[cls_STT_CapSo.col_MaNoiCap]);

                    drCapSo = _api.Search(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, andLike: false, dicLike: dicE,
                                                   orderByASC1: true, orderByName1: cls_STT_DinhNghia.col_ID).Rows[0];

                    stt = _bus.CapSTT(int.Parse(drCapSo[cls_STT_DinhNghia.col_ChieuDai].ToString())
                                               , drCapSo[cls_STT_DinhNghia.col_ChuoiCoDinh].ToString()
                                               , drCapSo[cls_STT_DinhNghia.col_DauNganCach].ToString()
                                               , drCapSo[cls_STT_DinhNghia.col_DinhDangNgay].ToString()
                                     , int.Parse(drCapSo[cls_STT_DinhNghia.col_BuocNhay].ToString())
                                     , int.Parse(drCapSo[cls_STT_DinhNghia.col_SoHienTai].ToString())
                                     , int.Parse(drCapSo[cls_STT_DinhNghia.col_SoToiDa].ToString()));
                }
                catch
                {
                }
                if (stt == "")
                {
                    return false;
                }
                lstData.Add(cls_STT_CapSo.col_STT, stt);

                lstData.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_ChuaGoi);
                lstData.Add(cls_STT_CapSo.col_TamNgung, "0");
                lstData.Add(cls_STT_CapSo.col_UuTien, chkUuTien.Checked ? "1" : "0");
                lstData.Add(cls_STT_CapSo.col_UserID, cls_System.sys_UserID);
                lstData.Add(cls_STT_CapSo.col_NgayTao, (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                lstData.Add(cls_STT_CapSo.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_CapSo.col_NgayUD, (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                List<string> lstKiemTraTrung = new List<string>();
                lstKiemTraTrung.Add(cls_STT_CapSo.col_MaNoiCap);
                lstKiemTraTrung.Add(cls_STT_CapSo.col_STT);
                lstKiemTraTrung.Add(cls_STT_CapSo.col_TrangThai);

                if (_api.Insert(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang
                                , lstData
                                , lstKiemTraTrung
                                , new List<string>()))
                {
                    Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                    lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, (int.Parse(drCapSo[cls_STT_DinhNghia.col_SoHienTai].ToString())
                                                             + int.Parse(drCapSo[cls_STT_DinhNghia.col_BuocNhay].ToString())).ToString());
                    lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                    Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                    lstWhere.Add(cls_STT_DinhNghia.col_Ma, lstData[cls_STT_CapSo.col_MaNoiCap]);
                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                    if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                    {
                        string tenphong = "";
                        if (string.IsNullOrEmpty(slbPhong.txtTen.Text))
                        {
                            tenphong = slbKhu.txtTen.Text;
                        }
                        else
                        {
                            tenphong = slbPhong.txtTen.Text;
                        }

                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("TEN");
                        dt.Columns.Add("NGAY");
                        dt.Columns.Add("SO");
                        dt.Columns.Add("UT");
                        dt.Rows.Add();
                        ds.Tables.Add(dt);
                        ds.Tables[0].Rows[0]["TEN"] = tenphong;
                        ds.Tables[0].Rows[0]["NGAY"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        ds.Tables[0].Rows[0]["SO"] = stt;
                        ds.Tables[0].Rows[0]["UT"] = chkUuTien.Checked ? "1" : "0";
                        if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                        ds.WriteXml("..//xml//rptSttdangky.xml", XmlWriteMode.WriteSchema);


                        ReportDocument oRpt = new ReportDocument();
                        oRpt.Load("..\\..\\..\\Report\\sttkham.rpt", OpenReportMethod.OpenReportByDefault);
                        oRpt.SetDataSource(ds);
                        frm_ReportSTT frm = new frm_ReportSTT(oRpt);
                        frm.ShowDialog();
                        //MessageBox.Show(stt);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Sự kiện

        private void frm_CapSTT_Load(object sender, EventArgs e)
        {

            LoadData();
            if (_maPhong != "")
            {
                // txtTuSo.Text = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_ChuaGoi, ref _idCapSTT);
                txtTuSo.Text = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_KhuVuc + _maKhu, cls_STT_KhuVucPhong.col_ChuaGoi, ref _idCapSTT);
            }
            else if (_maKhu != "")
            {
                txtTuSo.Text = _bus.Get_STT(cls_STT_KhuVucPhong.col_KhuVuc + _maKhu, cls_STT_KhuVucPhong.col_ChuaGoi, ref _idCapSTT);
            }
            txtTuSo.Text = txtTuSo.Text + " ~ " + txtTuSo.Text;

            if (_maKhu == "" && _maPhong == "")
            {
                btnGoi.Enabled =
                    txtTuSo.Enabled =
                    btnGoiLai.Enabled = false;
                txtTuSo.Text = "";
            }
            else
            {
                btnGoi.Enabled =
                   txtTuSo.Enabled =
                   btnGoiLai.Enabled = true;

                slbNhom.SetTenByMa(_maNhom);
                slbKhu.SetTenByMa(_maKhu);
                slbPhong.SetTenByMa(_maPhong);
            }

        }

        private void slbNhom_HisSelectChange(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = _dtKhuVuc.Select(string.Format("MaNhom = '{0}'", slbNhom.txtMa.Text)).CopyToDataTable();
                DataRow row = dt.NewRow();
                row[cls_STT_KhuVuc.col_Ma] = "ALL";
                row[cls_STT_KhuVuc.col_Ten] = "Tất cả";
                dt.Rows.Add(row);
                slbKhu.DataSource = dt;
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

        private void btnCap_Click(object sender, EventArgs e)
        {
            CapSTT();
        }

        private void btnGoi_Click(object sender, EventArgs e)
        {
            try
            {
                PlaySound("..\\..\\wav\\wav1.wav", 0, 1);
            }
            catch (Exception)
            {
            }

            if (_maPhong != "" || slbPhong.txtMa.Text != "")
            {
                //txtTuSo.Text = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_ChuaGoi, ref _idCapSTT);
                _maPhong = slbPhong.txtMa.Text;
                _maKhu = slbKhu.txtMa.Text;
                txtTuSo.Text = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_KhuVuc + _maKhu, cls_STT_KhuVucPhong.col_ChuaGoi, ref _idCapSTT);
            }
            else if (_maKhu != "" || slbKhu.txtMa.Text != "")
            {
                _maKhu = slbKhu.txtMa.Text;
                txtTuSo.Text = _bus.Get_STT(cls_STT_KhuVucPhong.col_KhuVuc + _maKhu, cls_STT_KhuVucPhong.col_ChuaGoi, ref _idCapSTT);
            }
            txtTuSo.Text = txtTuSo.Text + " ~ " + txtTuSo.Text;
        }

        private void btnExten_Click(object sender, EventArgs e)
        {
            if (this.Height == 100)
            {
                this.Height = 180;
            }
            else
            {
                this.Height = 100;
            }
        }

        private void btnGoiLai_Click(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        #endregion
    }
}
