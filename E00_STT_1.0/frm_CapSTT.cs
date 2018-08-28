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
using System.Globalization;

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
        private int sNumCall = 1;
        private string sIdBegin = "";
        private string sIdEnd = "";
        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string lpszName, int hModule, int dwFlags);
        private DataRow drCapSo = null;
        #endregion

        #region Khởi tạo

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
           // this.Height = 100;
        }

        #endregion

        #region Phương thức

        private void LoadData()
        {
            chkShowPrint.Checked = true;
            slbNhom.DataSource = _bus.Get_NhomKhuVuc(_maNhom);
            _dtKhuVuc = _bus.Get_KhuVuc(true);
            _dtPhong = _bus.Get_PhongBanNhomKhu();
        }

        private bool CapSTT()
        {

            DataRow drCapSo1 = null;
            string stt = "";
            string SMaNoiCap = "";
            try
            {
                Dictionary<string, string> lstData = new Dictionary<string, string>();
                if (slbKhu.txtMa.Text == "ALL" && slbNhom.txtMa.Text == "HUONGDAN")
                {
                    frm_CapSTTTatCa frm = new frm_CapSTTTatCa(slbNhom.txtMa.Text, slbKhu.txtMa.Text,slbKhu.txtTen.Text);
                    this.Close();
                    frm.Show();
                    frm.Focus();
                    return true;
                  //  this.Close();
                }
                #region Lấy mã nơi cấp
                if (slbPhong.txtMa.Text != "")
                {
                    SMaNoiCap = cls_STT_KhuVucPhong.col_Phong + slbPhong.txtMa.Text;

                }
                else if (slbKhu.txtMa.Text != "")
                {
                    SMaNoiCap = cls_STT_KhuVucPhong.col_KhuVuc + slbKhu.txtMa.Text;
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Bạn chưa chọn khu hoặc Phòng");
                    slbKhu.txtTen.Focus();
                    return false;
                } 
                #endregion

                if (!CheckChuKy(SMaNoiCap)) return false;
                #region Tạo bảng in
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("TEN");
                dt.Columns.Add("NGAY");
                dt.Columns.Add("SO");
                dt.Columns.Add("UT");
                ds.Tables.Add(dt);
                #endregion
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                List<string> lstKiemTraTrung = new List<string>();
                if (this.itgSoGoi.Value <= 1)
                {
                    this.itgSoGoi.Value = 1;
                }
                for (int i = 1; i <= this.itgSoGoi.Value; i++)
                {
                    _userError = "";
                    _systemError = "";
                    #region Cấp STT Cho từng bệnh nhân
                    stt = "";
                    try
                    {
                        dicE.Clear();
                        dicE.Add(cls_STT_DinhNghia.col_Ma, SMaNoiCap);

                        drCapSo1 = _api.Search(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, andEqual: false, dicEqual: dicE,
                                                       orderByASC1: true, orderByName1: cls_STT_DinhNghia.col_ID).Rows[0];

                        stt = _bus.CapSTT(int.Parse(drCapSo1[cls_STT_DinhNghia.col_ChieuDai].ToString())
                                                   , drCapSo1[cls_STT_DinhNghia.col_ChuoiCoDinh].ToString()
                                                   , drCapSo1[cls_STT_DinhNghia.col_DauNganCach].ToString()
                                                   , drCapSo1[cls_STT_DinhNghia.col_DinhDangNgay].ToString()
                                         , int.Parse(drCapSo1[cls_STT_DinhNghia.col_BuocNhay].ToString())
                                         , int.Parse(drCapSo1[cls_STT_DinhNghia.col_SoHienTai].ToString())
                                         , int.Parse(drCapSo1[cls_STT_DinhNghia.col_SoToiDa].ToString()));
                    }
                    catch
                    {
                    }
                    if (stt == "")
                    {
                        break;
                        //return false;
                    }
                    lstData.Clear();
                    lstData.Add(cls_STT_CapSo.col_MaNoiCap, SMaNoiCap);
                    lstData.Add(cls_STT_CapSo.col_STT, stt);

                    lstData.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_ChuaGoi);
                    lstData.Add(cls_STT_CapSo.col_TamNgung, "0");
                    lstData.Add(cls_STT_CapSo.col_UuTien, chkUuTien.Checked ? "1" : "0");
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
                        #region Insert vào table STTDANGKYCT vannq 09-05-2018

                        Dictionary<string, string> lstData1 = new Dictionary<string, string>();
                        lstData1.Add(cls_STT_DangKyCT.col_IDKhu, stt.Substring(0, 1));
                        lstData1.Add(cls_STT_DangKyCT.col_STT, stt);

                        lstData1.Add(cls_STT_DangKyCT.col_Done, "0");
                        lstData1.Add(cls_STT_DangKyCT.col_UuTien, chkUuTien.Checked ? "1" : "0");
                        lstData1.Add(cls_STT_DangKyCT.col_Ngay, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                        lstData1.Add(cls_STT_DangKyCT.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                        lstKiemTraTrung.Clear();
                        lstKiemTraTrung.Add(cls_STT_DangKyCT.col_IDKhu);
                        lstKiemTraTrung.Add(cls_STT_DangKyCT.col_STT);
                        lstKiemTraTrung.Add(cls_STT_DangKyCT.col_Done);

                        _api.Insert(ref _userError, ref _systemError, cls_STT_DangKyCT.tb_TenBang
                                    , lstData
                                    , lstKiemTraTrung
                                    , new List<string>());
                        if (_bus.GetTiepDon(slbNhom.txtMa.Text, cls_STT_NhomKhuVuc.col_MaLoai) == "HUONGDAN")
                        {
                            _bus.InsertSTTDangKyCT(stt.Substring(0, 1), stt, "0", chkUuTien.Checked ? "1" : "0", _bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss"), _bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        //else if (_bus.GetTiepDon(slbNhom.txtMa.Text, cls_STT_NhomKhuVuc.col_TiepDon) == "1")
                        //{
                        //    //vannq
                        //}


                        #endregion

                        Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                        lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, (int.Parse(drCapSo1[cls_STT_DinhNghia.col_SoHienTai].ToString())
                                                                 + int.Parse(drCapSo1[cls_STT_DinhNghia.col_BuocNhay].ToString())).ToString());
                        lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                        lstWhere.Add(cls_STT_DinhNghia.col_Ma, lstData[cls_STT_CapSo.col_MaNoiCap]);
                        List<string> lstDateTime = new List<string>();
                        lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                        if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate,lstDateTime, lstWhere))
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

                            DataRow Row = dt.NewRow();
                            Row["TEN"] = tenphong;
                            Row["NGAY"] = _bus.Get_curDate().ToString("dd/MM/yyyy HH:mm:ss");
                            Row["SO"] = stt;
                            Row["UT"] = chkUuTien.Checked ? "1" : "0";
                            dt.Rows.Add(Row);
                        }
                    }
                    #endregion
                }


                dt.AcceptChanges();

                if (dt.Rows.Count > 0)
                {
                    if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                    ds.WriteXml("..//xml//rptSttdangky.xml", XmlWriteMode.WriteSchema);
                    if (chkShowPrint.Checked)
                    {
                        ReportDocument oRpt = new ReportDocument();
                        oRpt.Load("..\\..\\..\\Report\\sttkham.rpt", OpenReportMethod.OpenReportByDefault);
                        oRpt.SetDataSource(ds);
                        frm_ReportSTT frm = new frm_ReportSTT(oRpt);
                        frm.ShowDialog(this);
                    }
                    else
                    {
                        ReportDocument rptDoc = new ReportDocument();
                        //ds.ReadXml("..\\..\\..\\Report\\sttkham.rpt", XmlReadMode.ReadSchema);
                        rptDoc.Load("..\\..\\..\\Report\\sttkham.rpt", OpenReportMethod.OpenReportByDefault);
                        rptDoc.SetDataSource(ds);
                        rptDoc.PrintToPrinter(1, false, 1, dt.Rows.Count);
                        rptDoc.Dispose();
                        ds.Dispose();
                        rptDoc.Close();
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch(Exception EX)
            {
                return false;
            }
        }

        private bool CheckChuKy(string SMaNoiCap)
        {
            try
            {
                drCapSo = null;
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Clear();
                dicE.Add(cls_STT_DinhNghia.col_Ma, SMaNoiCap);
                try
                {
                    drCapSo = _api.Search(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, andEqual: false, dicEqual: dicE,
                                                   orderByASC1: true, orderByName1: cls_STT_DinhNghia.col_ID).Rows[0];
                }
                catch
                {
                    drCapSo = null;
                }
                if (drCapSo == null)
                {
                    TA_MessageBox.MessageBox.Show("Nơi cấp số chưa được định nghĩa!\nVui lòng vào mục Quản lý STT -> Định nghĩa STT để định nghĩa cho nơi cấp số.",       TA_MessageBox.MessageIcon.Error);
                    return false;
                }
                if (drCapSo[cls_STT_DinhNghia.col_CoChuKy].ToString() == "1")
                {
                    if (drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "1") // ngay
                    {                                                                 
                        if (drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != _bus.Get_curDate().Day.ToString())
                        {
                            UpdateAllCapSo(SMaNoiCap);
                            Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                            lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                            lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                            lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, (_bus.Get_curDate().Day.ToString()));

                            Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                            lstWhere.Add(cls_STT_DinhNghia.col_Ma, SMaNoiCap);
                            List<string> lstDateTime = new List<string>();
                            lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                            if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                            {
                            }
                        }
                    }
                    else if (drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "2")
                    {
                        int iWeek = 0;
                        DateTime iDate;
                        GetWeekInYear(_bus.Get_curDate(), out iDate, out iWeek);
                        if (drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != iWeek.ToString())
                        {
                            UpdateAllCapSo(SMaNoiCap);
                            Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                            lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                            lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                            lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, (iWeek.ToString()));

                            Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                            lstWhere.Add(cls_STT_DinhNghia.col_Ma, SMaNoiCap);
                            List<string> lstDateTime = new List<string>();
                            lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                            if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                            {
                            }
                        }
                    }
                    else if (drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "3")
                    {
                        if (drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != _bus.Get_curDate().Month.ToString())
                        {
                            UpdateAllCapSo(SMaNoiCap);
                            Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                            lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                            lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                            lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, (_bus.Get_curDate().Month.ToString()));

                            Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                            lstWhere.Add(cls_STT_DinhNghia.col_Ma, SMaNoiCap);
                            List<string> lstDateTime = new List<string>();
                            lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                            if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                            {
                            }
                        }
                    }
                    else if (drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "4")
                    {
                        if (drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != _bus.Get_curDate().Year.ToString())
                        {
                            UpdateAllCapSo(SMaNoiCap);
                            Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                            lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                            lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                            lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, (_bus.Get_curDate().Year.ToString()));

                            Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                            lstWhere.Add(cls_STT_DinhNghia.col_Ma, SMaNoiCap);
                            List<string> lstDateTime = new List<string>();
                            lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                            if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                            {
                            }
                        }
                    }
                    // chu kỳ theo giờ
                    else if (drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "5" && drCapSo[cls_STT_DinhNghia.col_IdTimeZone].ToString() != "")
                    {
                        #region Lấy danh mục giờ
                        Dictionary<string, string> dicLike = new Dictionary<string, string>();
                        dicLike.Add(cls_STT_TimeZone.col_ID, drCapSo[cls_STT_DinhNghia.col_IdTimeZone].ToString());
                        DataTable _dtaTime = _api.Search(ref _userError, ref _systemError, cls_STT_TimeZone.tb_TenBang, andLike: false, dicLike: dicLike,
                                                        orderByASC1: true, orderByName1: cls_STT_TimeZone.col_ID);
                        #endregion
                        if (_dtaTime != null && _dtaTime.Rows.Count > 0)
                        {
                            try
                            {
                                DataRow row = _dtaTime.Select(cls_STT_TimeZone.col_ID + " = '" + drCapSo[cls_STT_DinhNghia.col_IdTimeZone].ToString() + "'")[0];
                                DateTime hourBegin = DateTime.Parse(row[cls_STT_TimeZone.col_TimeBegin].ToString());
                                DateTime hourEnd = DateTime.Parse(row[cls_STT_TimeZone.col_TimeEnd].ToString());

                                DateTime timeBegin = new DateTime(_bus.Get_curDate().Year, _bus.Get_curDate().Month, _bus.Get_curDate().Day, hourBegin.Hour, hourBegin.Minute, 0);
                                DateTime timeEnd = new DateTime(_bus.Get_curDate().Year, _bus.Get_curDate().Month, _bus.Get_curDate().Day, hourEnd.Hour, hourEnd.Minute, 59);
                                if (timeBegin <= _bus.Get_curDate() && _bus.Get_curDate() <= timeEnd)
                                {
                                    if (drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != "1")
                                    {
                                        UpdateAllCapSo(SMaNoiCap);
                                        Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                                        lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                                        lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                                        lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, "1");

                                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                                        lstWhere.Add(cls_STT_DinhNghia.col_Ma, SMaNoiCap);
                                        List<string> lstDateTime = new List<string>();
                                        lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                                        if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    if (drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != "0")
                                    {
                                        UpdateAllCapSo(SMaNoiCap);
                                        Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                                        lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                                        lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (_bus.Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                                        lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, "0");

                                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                                        lstWhere.Add(cls_STT_DinhNghia.col_Ma, SMaNoiCap);
                                        List<string> lstDateTime = new List<string>();
                                        lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                                        if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                                        {
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy ra thứ tự trong năm của tuần có chứa ngày nhập vào 
        /// với Culture mặc định là Culture hiện tại
        /// </summary>
        /// <param name="datetime">Ngày nhập vào</param>
        /// <returns>Trả về kiểu datetime là ngày đầu tuần, int là thứ tự của tuần hiện tại trong năm</returns>
        public void GetWeekInYear(DateTime datetime, out DateTime FirstDayOfWeek, out int CurrentWeek)
        {
            //string txt = "";
            CultureInfo myCI = new CultureInfo(System.Globalization.CultureInfo.CurrentCulture.LCID);//System.Globalization.CultureInfo.CurrentCulture.LCID lay theo he thong
            System.Globalization.Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            // Displays the number of the current week relative to the beginning of the year.
            //txt += string.Format("The CalendarWeekRule used for the current culture is {0}.", myCWR);
            //txt += "<br>" + string.Format("The FirstDayOfWeek used for the current culture is {0}.", myFirstDOW);
            CurrentWeek = myCal.GetWeekOfYear(_bus.Get_curDate(), myCWR, myFirstDOW);
            //txt += "<br>" + string.Format("Therefore, the current week is Week {0} of the current year.", CurrentWeek);
            FirstDayOfWeek = _bus.Get_curDate();
            while (FirstDayOfWeek.DayOfWeek != DayOfWeek.Monday) FirstDayOfWeek = FirstDayOfWeek.AddDays(-1); // tìm đầu tuần
            //txt += "<br>" + string.Format("The FirstDayOfWeek  for the current week is {0}.", FirstDayOfWeek.ToString("dd/MM/yyyy"));

            // Displays the total number of weeks in the current year.
            DateTime LastDay = new System.DateTime(_bus.Get_curDate().Year, 12, 31);
            //txt += "<br>" + string.Format("There are {0} weeks in the current year ({1}).", myCal.GetWeekOfYear(LastDay, myCWR, myFirstDOW), LastDay.Year);
            //return txt;
        }

        public void UpdateAllCapSo(string maNoiCap)
        {

            Dictionary<string, string> lstWhere = new Dictionary<string, string>();
            lstWhere.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);
            //lstWhere.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.);//vannq fix lỗi phải gọi lại
            Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
            lstUpdate.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DaGoi);

            bool bl = _api.UpdateAll(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstWhere);
        }


        #endregion

        #region Sự kiện

        private void frm_CapSTT_Load(object sender, EventArgs e)
        {

            LoadData();

            #region Gọi số bệnh nhân đang khám

            if (_maPhong != "")
            {
                sNumCall = itgSoGoi.Value;
                // txtTuSo.Text = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_ChuaGoi, ref _idCapSTT);
                txtTuSo.Text = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_KhuVuc + _maKhu, cls_STT_KhuVucPhong.col_ChuaGoi, ref sNumCall, ref sIdBegin, ref sIdEnd);
                itgSoGoi.Value = sNumCall;
            }
            #endregion

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
            string sTuSo = "";
            if (slbKhu.txtMa.Text == "")
            {
                TA_MessageBox.MessageBox.Show("Chưa chọn phòng, khu");
                return;
            }
            //if (itgSoGoi.Value <= 1)
            //{
            //    itgSoGoi.Value = 1;
            //    _idCapSTT = sIdEnd;
            //    if (_maPhong != "" || slbPhong.txtMa.Text != "")
            //    {
            //        _maPhong = slbPhong.txtMa.Text;
            //        _maKhu = slbKhu.txtMa.Text;
            //        sTuSo = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_KhuVuc + _maKhu, cls_STT_KhuVucPhong.col_ChuaGoi, ref _idCapSTT);
            //    }
            //    if (!string.IsNullOrWhiteSpace(sTuSo))
            //    {
            //        txtTuSo.Text = sTuSo + " ~ " + sTuSo;
            //    }
            //    else
            //    {
            //        TA_MessageBox.MessageBox.Show("Chưa cấp mới");
            //    }
            //}
            //else
            //{
            string SMaNoiCap = "";
            if (slbPhong.txtMa.Text != "")
            {
                SMaNoiCap = cls_STT_KhuVucPhong.col_Phong + slbPhong.txtMa.Text;

            }
            else if (slbKhu.txtMa.Text != "")
            {
                SMaNoiCap = cls_STT_KhuVucPhong.col_KhuVuc + slbKhu.txtMa.Text;
            }
            if (SMaNoiCap != "")
            {
                CheckChuKy(SMaNoiCap);
            }

            sNumCall = itgSoGoi.Value;
            if (_maPhong != "" || slbPhong.txtMa.Text != "" || slbKhu.txtMa.Text != "")
            {
                _maPhong = slbPhong.txtMa.Text;
                _maKhu = slbKhu.txtMa.Text;
                sTuSo = _bus.Get_STT(cls_STT_KhuVucPhong.col_Phong + _maPhong, cls_STT_KhuVucPhong.col_KhuVuc + _maKhu, cls_STT_KhuVucPhong.col_ChuaGoi, ref sNumCall, ref sIdBegin, ref sIdEnd);
            }
            if (!string.IsNullOrWhiteSpace(sTuSo) && sTuSo != "~")
            {
                txtTuSo.Text = sTuSo;
            }
            else
            {
                TA_MessageBox.MessageBox.Show("Chưa cấp mới");
            }
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
            if (_maPhong != "" || slbPhong.txtMa.Text != "")
            {
                _maPhong = slbPhong.txtMa.Text;
                _maKhu = slbKhu.txtMa.Text;
                _bus.ReCall_STT(ref sIdBegin);
            }
            else if (_maKhu != "" || slbKhu.txtMa.Text != "")
            {
                _maKhu = slbKhu.txtMa.Text;
                _bus.ReCall_STT(ref sIdBegin);
            }
        }

        private void itgSoGoi_Validated(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
