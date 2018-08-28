using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using E00_Model;
using E00_Common;
using System.Threading;
using E00_System;
using System.Windows.Forms;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine; 
using CrystalDecisions.Shared;

namespace E00_STT
{
    public partial class clsBUS
    {

        #region Biến toàn cục

        private Api_Common _api = new Api_Common();
        private Acc_Oracle _acc = new Acc_Oracle();
        private string _userError = "";
        private string _systemError = "";
        public string _NHATHUOC = "NHATHUOC";
        public string _CANLAMSANG = "CANLAMSANG";
        public string _VIENPHI = "VIENPHI";
        public string _loaiCLS_TRAKQ = "TRAKETQUA";
        private DataRow _drCapSo = null;

        #endregion

        #region Khởi tạo

        public clsBUS()
        {
            _api.KetNoi();
        }

        #endregion

        #region Phương thức

        /// <summary>
        /// Lấy danh sách nhóm khu vực
        /// </summary>
        /// <param name="maNhomKhu"></param>
        /// <returns></returns>
        public DataTable Get_NhomKhuVuc(string maNhomKhu)
        {
            try
            {
                DataTable dt = new DataTable();
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_STT_NhomKhuVuc.col_TamNgung, "1");
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_STT_NhomKhuVuc.col_Ma);
                lstColumns.Add(cls_STT_NhomKhuVuc.col_Ten);
                lstColumns.Add(cls_STT_NhomKhuVuc.col_STT);

                dt = _api.Search(ref _userError, ref _systemError, cls_STT_NhomKhuVuc.tb_TenBang, lst: lstColumns, dicDifferent: dicD,
                                                     orderByASC1: true, orderByName1: cls_STT_NhomKhuVuc.col_Ten); ;
                if (maNhomKhu == "")
                {
                    return dt;
                }
                else
                {
                    Dictionary<string, string> dicE = new Dictionary<string, string>();
                    dicE.Add(cls_STT_NhomKhuVuc.col_Ma, maNhomKhu);
                    List<string> lstColumns2 = new List<string>();
                    lstColumns2.Add(cls_STT_NhomKhuVuc.col_STT);

                    DataRow row = _api.Search(ref _userError, ref _systemError, cls_STT_NhomKhuVuc.tb_TenBang, lst: lstColumns2, dicDifferent: dicD, dicEqual: dicE).Rows[0];
                    DataTable temp =  dt.Select(string.Format("STT >= {0} and MA = '{1}'", row[cls_STT_NhomKhuVuc.col_STT].ToString(), maNhomKhu)).CopyToDataTable();
                    return temp;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách nhóm khu vực thêm dòng tất cả
        /// </summary>
        /// <param name="tatCa"></param>
        /// <returns></returns>
        public DataTable Get_NhomKhuVuc(bool tatCa)
        {
            try
            {
                DataTable dt = new DataTable();
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_STT_NhomKhuVuc.col_TamNgung, "1");
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_STT_NhomKhuVuc.col_Ma);
                lstColumns.Add(cls_STT_NhomKhuVuc.col_Ten);
                lstColumns.Add(cls_STT_NhomKhuVuc.col_STT);

                dt = _api.Search(ref _userError, ref _systemError, cls_STT_NhomKhuVuc.tb_TenBang, lst: lstColumns, dicDifferent: dicD,
                                                     orderByASC1: true, orderByName1: cls_STT_NhomKhuVuc.col_Ten);
                if (tatCa)
                {
                    DataRow row = dt.NewRow();
                    row[cls_STT_KhuVuc.col_Ma] = "ALL";
                    row[cls_STT_KhuVuc.col_Ten] = "Tất cả";
                    dt.Rows.Add(row);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Load danh sách BS - Nguyễn Quốc Vạn
        /// </summary>
        /// <returns></returns>
        public DataTable Get_BacSi()
        {
            try
            {
                DataTable dt = new DataTable();
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_BacSi.col_Ma);
                lstColumns.Add(cls_BacSi.col_HoTen);
                dt = _api.Search(ref _userError, ref _systemError, cls_BacSi.tb_TenBang, lst: lstColumns, orderByASC1: true, orderByName1: cls_BacSi.col_HoTen);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy số đang gọi lên LCD 
        /// </summary>
        /// <param name="maNoiGoi"></param>
        /// <returns></returns>
        public DataTable GetSoGoi(string maNoiGoi)
        {
            string user = _acc.Get_User();

            string sql = "select a.stt, a.TRANGTHAI ,a.UUTIEN,b.HOTEN,a.id ";
            sql += " from " + user + ".stt_capso a ";
            sql += " left join " + user + ".BTDBN b on a.mabn = b.mabn ";
            sql += " where (a.TRANGTHAI=1 OR a.TRANGTHAI=5) ";
            if (maNoiGoi != "")
            {
                sql += " and  a.MaNoiCap ='" + maNoiGoi + "'";
            }
            sql += " and to_char(ngaytao, 'dd/mm/yyyy') = '" + Get_curDate().ToString("dd/MM/yyyy") + "'";//lấy số ngày hôm nay
            sql += " order by a.stt asc";
            DataTable tmp = XL_BANG.Doc(sql);
            return tmp;
        }

        /// <summary>
        /// Lấy danh sách chờ lên LCD
        /// </summary>
        /// <param name="_makp"></param>
        /// <param name="soluong"></param>
        /// <returns></returns>
        public string GetSoGoiTiepTheo(string _makp, int soluong)
        {
            string ret = "";
            string user = _acc.Get_User();
            string sql = "select a.stt,a.mabn,b.hoten";
            sql += " from " + user + ".stt_capso a ";
            sql += " left join " + user + ".btdbn b on a.mabn = b.mabn ";
            sql += " where a.TRANGTHAI=0 and a.UUTIEN =1";
            sql += " and to_char(ngaytao, 'dd/mm/yyyy') = '" + Get_curDate().ToString("dd/MM/yyyy") + "'";//lấy số ngày hôm nay
            if (_makp != "")
            {
                sql += " and  a.MaNoiCap ='" + _makp + "'";
            }
            sql += " order by a.stt asc";
            DataTable tmp = XL_BANG.Doc(sql);

            if (tmp != null)
            {
                sql = "select a.stt,a.mabn,b.hoten ";
                sql += " from " + user + ".stt_capso a ";
                sql += " left join " + user + ".btdbn b on a.mabn = b.mabn ";
                sql += " where a.TRANGTHAI=0 and a.UUTIEN =0";
                sql += " and to_char(ngaytao, 'dd/mm/yyyy') = '" + Get_curDate().ToString("dd/MM/yyyy") + "'";//lấy số ngày hôm nay
                if (_makp != "")
                {
                    sql += " and  a.MaNoiCap ='" + _makp + "'";
                }
                sql += " order by a.stt asc";
                DataTable tmp2 = XL_BANG.Doc(sql);

                if (tmp2 != null)
                {
                    tmp.Merge(tmp2);
                }

                if (tmp.Rows.Count > 0)
                {
                    ret = string.IsNullOrEmpty(tmp.Rows[0]["hoten"].ToString()) ? tmp.Rows[0]["stt"].ToString() : tmp.Rows[0]["stt"].ToString() + ": " + tmp.Rows[0]["hoten"].ToString();
                    if (soluong > 1 && (tmp.Rows.Count > 1))
                    {
                        int solan = soluong;
                        if (tmp.Rows.Count < soluong)
                        {
                            solan = tmp.Rows.Count;
                        }

                        for (int i = 1; i < solan; i++)
                        {
                            ret += string.IsNullOrEmpty(tmp.Rows[i]["hoten"].ToString()) ? ";" + tmp.Rows[i]["stt"].ToString() : ";" + tmp.Rows[i]["stt"].ToString() + ": " + tmp.Rows[i]["hoten"].ToString();
                        }
                    }
                }
            }


            return ret;
        }

        /// <summary>
        /// Lấy tên khoa phòng lên LCD
        /// </summary>
        /// <param name="maNoiGoi"></param>
        /// <returns></returns>
        public string GetTenKP(string maNoiGoi)
        {
            try
            {
                string tenkp = "";

                Dictionary<string, string> dicD = new Dictionary<string, string>();
                List<string> lstColumns = new List<string>();
                string tenbang = "";
                string cotsort = "";

                if (!string.IsNullOrEmpty(maNoiGoi) && maNoiGoi.Substring(0, 1).ToLower() == "p")
                {
                    lstColumns.Add(cls_STT_KhoaPhong.col_Ten);
                    dicD.Add(cls_STT_KhoaPhong.col_Ma, maNoiGoi.Substring(1));
                    tenbang = cls_STT_KhoaPhong.tb_TenBang;
                    cotsort = cls_STT_KhoaPhong.col_Ten;
                }
                else
                {
                    lstColumns.Add(cls_STT_KhuVuc.col_Ten);
                    dicD.Add(cls_STT_KhuVuc.col_Ma, maNoiGoi.Substring(1));
                    tenbang = cls_STT_KhuVuc.tb_TenBang;
                    cotsort = cls_STT_KhuVuc.col_Ten;
                }

                DataTable tmp = _api.Search(ref _userError, ref _systemError, tenbang, lst: lstColumns, dicEqual: dicD
                        , orderByASC2: true, orderByName2: cotsort);
                if (tmp != null && tmp.Rows.Count > 0)
                {
                    tenkp = tmp.Rows[0][0].ToString();
                }
                return tenkp;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Lấy danh sách khu vực
        /// </summary>
        /// <param name="tatCa">true để thêm dòng tất cả</param>
        /// <returns></returns>
        public DataTable Get_KhuVuc(bool tatCa)
        {
            try
            {
                DataTable dt = new DataTable();
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_STT_KhuVuc.col_TamNgung, "1");
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_STT_KhuVuc.col_Ma);
                lstColumns.Add(cls_STT_KhuVuc.col_Ten);
                lstColumns.Add(cls_STT_KhuVuc.col_MaNhom);

                dt = _api.Search(ref _userError, ref _systemError, cls_STT_KhuVuc.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                    , orderByASC1: true, orderByName1: cls_STT_KhuVuc.col_Ten);
                if (tatCa)
                {
                    DataRow row = dt.NewRow();
                    row[cls_STT_KhuVuc.col_Ma] = "ALL";
                    row[cls_STT_KhuVuc.col_Ten] = "Tất cả";
                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách khu vực theo mã nhóm khu vực
        /// </summary>
        /// <param name="maNhom"></param>
        /// <returns></returns>
        public DataTable Get_KhuVuc(string maNhom, bool tatCa = false)
        {
            try
            {
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_STT_KhuVuc.col_MaNhom, maNhom);
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_STT_KhuVuc.col_TamNgung, "1");
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_STT_KhuVuc.col_Ma);
                lstColumns.Add(cls_STT_KhuVuc.col_Ten);
                lstColumns.Add(cls_STT_KhuVuc.col_MaNhom);


                DataTable dt = _api.Search(ref _userError, ref _systemError, cls_STT_KhuVuc.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                    , dicEqual: dicE, orderByASC1: true, orderByName1: cls_STT_KhuVuc.col_Ten);
                if (tatCa)
                {
                    DataRow row = dt.NewRow();
                    row[cls_STT_KhuVuc.col_Ma] = "ALL";
                    row[cls_STT_KhuVuc.col_Ten] = "Tất cả";
                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <param name="tatCa"></param>
        /// <returns></returns>
        public DataTable Get_PhongBan(bool tatCa)
        {
            try
            {
                DataTable dt = new DataTable();
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_STT_KhoaPhong.col_TamNgung, "1");
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_STT_KhoaPhong.col_Ma);
                lstColumns.Add(cls_STT_KhoaPhong.col_Ten);
                lstColumns.Add(cls_STT_KhoaPhong.col_MaNhom);

                dt = _api.Search(ref _userError, ref _systemError, cls_STT_KhoaPhong.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                                                     , orderByASC1: true, orderByName1: cls_STT_KhoaPhong.col_Ten);
                if (tatCa)
                {
                    DataRow row = dt.NewRow();
                    row[cls_STT_KhuVuc.col_Ma] = "ALL";
                    row[cls_STT_KhuVuc.col_Ten] = "Tất cả";
                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Lấy danh schs phòng ban theo khu
        /// </summary>
        /// <param name="maKhu"></param>
        /// <returns></returns>
        public DataTable Get_PhongBan(string maKhu)
        {
            try
            {
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_STT_KhoaPhong.col_MaNhom, maKhu);
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_STT_KhoaPhong.col_TamNgung, "1");
                List<string> lstColumns = new List<string>();
                lstColumns.Add(cls_STT_KhoaPhong.col_Ma);
                lstColumns.Add(cls_STT_KhoaPhong.col_Ten);

                return _api.Search(ref _userError, ref _systemError, cls_STT_KhoaPhong.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                                                     , dicEqual: dicE, orderByASC1: true, orderByName1: cls_STT_KhoaPhong.col_Ten);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Lấy danh sách phòng ban theo nhóm khu
        /// </summary>
        /// <returns></returns>
        public DataTable Get_PhongBanNhomKhu()
        {
            try
            {
                string query = string.Format("SELECT a.Ma,a.Ten,a.STT,a.MaNhom,b.MaNhom AS MaNhomKhu"
                                          + " FROM {0}.{1} a inner join {0}.{2} b on a.MaNhom = b.Ma "
                                          + " WHERE a.{3} <> 1 ORDER BY a.Ten"
                                       , _acc.Get_User(), cls_STT_KhoaPhong.tb_TenBang, cls_STT_KhuVuc.tb_TenBang, cls_STT_KhoaPhong.col_TamNgung);

                return _acc.Get_Data(query);

            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_PhongBanSQL()
        {
            string sql = string.Format("select a.*,b.{8} TENKHU, c.{9} TENNHOMKHU  from {0}.{1} a left join {0}.{2} b on a.{4} = b.{5} left join {0}.{3} c on a.{6} = c.{7} where a.{10} = 0 order by a.{11} ",
                                        _acc.Get_User(),                       //0
                                        cls_STT_KhoaPhong.tb_TenBang,          //1
                                        cls_STT_KhuVuc.tb_TenBang,             //2
                                        cls_STT_NhomKhuVuc.tb_TenBang,         //3
                                        cls_STT_KhoaPhong.col_MaNhom,          //4
                                        cls_STT_KhuVuc.col_Ma,                 //5
                                        cls_STT_KhoaPhong.col_MaNhomKV,        //6
                                        cls_STT_NhomKhuVuc.col_Ma,             //7
                                        cls_STT_KhuVuc.col_Ten,                //8
                                        cls_STT_NhomKhuVuc.col_Ten,            //9
                                        cls_STT_KhoaPhong.col_TamNgung,        //10
                                        cls_STT_KhoaPhong.col_Ma               //11
                                        );
            return _acc.Get_Data(sql);        
        }

        public DataTable Get_DinhNghiaSQL()
        {
            string sql = string.Format("select a.*,b.{8} TENKHU, c.{9} TENNHOMKHU,d.{15} TENKHOAPHONG  from {0}.{1} a left join {0}.{2} b on a.{4} = b.{5} left join {0}.{3} c on a.{6} = c.{7} " +
                                        " left join {0}.{12} d on NVL(SUBSTR(a.{13}, 2, length(a.{13}) - 1) ,a.{13}) = d.{14}" +
                                        " where a.{10} = 0 order by a.{11} ",
                                        _acc.Get_User(),                       //0
                                        cls_STT_DinhNghia.tb_TenBang,          //1
                                        cls_STT_KhuVuc.tb_TenBang,             //2
                                        cls_STT_NhomKhuVuc.tb_TenBang,         //3
                                        cls_STT_DinhNghia.col_MaKhuVuc,          //4
                                        cls_STT_KhuVuc.col_Ma,                 //5
                                        cls_STT_DinhNghia.col_MaNhomKV,        //6
                                        cls_STT_NhomKhuVuc.col_Ma,             //7
                                        cls_STT_KhuVuc.col_Ten,                //8
                                        cls_STT_NhomKhuVuc.col_Ten,            //9
                                        cls_STT_DinhNghia.col_TamNgung,        //10
                                        cls_STT_DinhNghia.col_Ma,               //11
                                        cls_STT_KhoaPhong.tb_TenBang,           //12
                                        cls_STT_DinhNghia.col_MaNoiCap,         //13
                                        cls_STT_KhoaPhong.col_Ma,                //14
                                        cls_STT_KhoaPhong.col_Ten               //15
                                        );
            return _acc.Get_Data(sql);
        }

        /// <summary>
        /// Lấy số thứ tự đã cấp
        /// </summary>
        /// <param name="sMaNoiCap"></param>
        /// <param name="sSttReset"></param>
        /// <returns></returns>
        public DataTable Get_STTDaCap(string sMaNoiCap, string sSttReset)
        {
            try
            {
                string query = string.Format("SELECT a.ID,a.MANOICAP,a.TRANGTHAI,a.UUTIEN,a.STT,a.TAMNGUNG,a.USERID"
                                         + " FROM {0}.{1} a "
                                         + " WHERE a.{2} > '{3}' and a.{4} = '{5}' "
                                         + " ORDER BY a.TRANGTHAI"
                                      , _acc.Get_User(), cls_STT_CapSo.tb_TenBang, cls_STT_CapSo.col_STT, sSttReset
                                      , cls_STT_CapSo.col_MaNoiCap, sMaNoiCap);

                return _acc.Get_Data(query);
            }
            catch
            {
                return null;
            }
        }

        public DateTime Get_curDate()
        {
            try
            {
                string query = "";
                if (cls_System.sys_Kieu == cls_System.sys_KieuAcc)
                {       /// kiểu accc chưa phát triêrn

                    throw new Exception("Chưa phát triển");

                }
                else if (cls_System.sys_Kieu == cls_System.sys_KieuSQL)
                {
                    query = string.Format("SELECT GETDATE()");
                }
                else if (cls_System.sys_Kieu == cls_System.sys_KieuORC)
                {
                    query = string.Format("select SYSDATE from dual");
                }


                DataTable dt = _acc.Get_Data(query);
                if (dt.Rows.Count > 0)
                {
                    DateTime ret = DateTime.Parse(dt.Rows[0][0].ToString());
                    return ret;
                }

                return DateTime.Now;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public string CapSTT(int chieuDai, string chuoiCoDinh, string dauNganCach, string dinhDangNgay, int buocNhay, int soHienTai, int soToiDa)
        {
            try
            {
                string soTiepTheo = "";
                soTiepTheo = chuoiCoDinh;
                soTiepTheo += dauNganCach;
                if (dinhDangNgay != "")
                {
                    try
                    {
                        soTiepTheo += Get_curDate().ToString(dinhDangNgay);
                    }
                    catch
                    {
                    }
                }
                if (chieuDai < soTiepTheo.Length + soToiDa.ToString().Length)
                {
                    return "";
                }
                else if (soHienTai + buocNhay > soToiDa)
                {
                    return "";
                }
                soTiepTheo += (soHienTai + buocNhay).ToString().PadLeft(chieuDai - soTiepTheo.Length, '0');

                return soTiepTheo;
            }
            catch
            {
                return "";
            }
        }

        public string Get_STT(string maNoiCap, string sMaNoiCapCha, string trangThai, ref string id)
        {
            try
            {
                bool capNhat = false;
                if (id != "")
                {
                    Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                    lstWhere.Add(cls_STT_CapSo.col_ID, id);

                    Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                    lstUpdate.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DaGoi);

                    lstUpdate.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_CapSo.col_NgayUD);

                    capNhat = _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstDateTime, lstWhere);
                }
                if (id == "" || (id != "" && capNhat))
                {
                    Dictionary<string, string> dicE = new Dictionary<string, string>();
                    Dictionary<string, string> dicD = new Dictionary<string, string>();
                    dicD.Add(cls_STT_CapSo.col_TamNgung, "1");

                    List<string> lstColumns = new List<string>();
                    lstColumns.Add(cls_STT_CapSo.col_ID);
                    lstColumns.Add(cls_STT_CapSo.col_STT);
                    lstColumns.Add(cls_STT_CapSo.col_UuTien);
                    DataRow row;
                    try
                    {
                        try
                        {
                            dicE.Clear();
                            dicE.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);
                            dicE.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DangGoi);
                            // lay lai benh nhan dang goi
                            row = _api.Search(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                                                      , dicEqual: dicE, orderByASC1: false, orderByName1: cls_STT_CapSo.col_UuTien, orderByASC2: true, orderByName2: cls_STT_CapSo.col_STT)
                                                      .Rows[0];

                        }
                        catch (Exception)
                        {
                            // goi benh nhan moi
                            dicE.Clear();
                            dicE.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);
                            dicE.Add(cls_STT_CapSo.col_TrangThai, trangThai);
                            row = _api.Search(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                                                      , dicEqual: dicE, orderByASC1: false, orderByName1: cls_STT_CapSo.col_UuTien, orderByASC2: true, orderByName2: cls_STT_CapSo.col_STT)
                                                      .Rows[0];
                        }
                    }
                    catch (Exception)
                    {
                        dicE.Clear();
                        dicE.Add(cls_STT_CapSo.col_MaNoiCap, sMaNoiCapCha);
                        dicE.Add(cls_STT_CapSo.col_TrangThai, trangThai);

                        row = _api.Search(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                                             , dicEqual: dicE, orderByASC1: false, orderByName1: cls_STT_CapSo.col_UuTien, orderByASC2: true, orderByName2: cls_STT_CapSo.col_STT)
                                             .Rows[0];
                    }
                    id = row[cls_STT_CapSo.col_ID].ToString();

                    #region Cập nhật trạng thái thành đang gọi để không gọi lại
                    Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                    lstWhere.Add(cls_STT_CapSo.col_ID, id);

                    Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                    lstUpdate.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DangGoi);
                    lstUpdate.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);

                    lstUpdate.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_CapSo.col_NgayUD);
                    _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstDateTime, lstWhere);
                    #endregion
                    return row[cls_STT_CapSo.col_STT].ToString();
                }
                return "";
            }
            catch
            {
                id = "";
                return "";
            }
        }

        public string Get_STT(string maNoiCap, string sMaNoiCapCha, string trangThai, ref int sNumCall, ref string idBegin, ref string idEnd)
        {
            try
            {
                if (maNoiCap == "P") maNoiCap = sMaNoiCapCha;
                bool capNhat = false;
                string sSTTBegin = "";
                string sSTTEnd = "";
                if (idBegin != "")
                {
                    _systemError = "";
                    _userError = "";
                    Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                    lstWhere.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DangGoi);
                    lstWhere.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);
                    Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                    lstUpdate.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DaGoi);
                    lstUpdate.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

                    List<string> lstDateTime = new List<string>();
                    lstDateTime.Add(cls_STT_CapSo.col_NgayUD);

                    capNhat = _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstDateTime, lstWhere);//vannq
                }
                if (idBegin == "" || (idBegin != "" && capNhat))
                {
                    Dictionary<string, string> dicE = new Dictionary<string, string>();
                    Dictionary<string, string> dicD = new Dictionary<string, string>();
                    dicD.Add(cls_STT_CapSo.col_TamNgung, "1");

                    List<string> lstColumns = new List<string>();
                    lstColumns.Add(cls_STT_CapSo.col_ID);
                    lstColumns.Add(cls_STT_CapSo.col_STT);
                    lstColumns.Add(cls_STT_CapSo.col_UuTien);
                    lstColumns.Add(cls_STT_CapSo.col_NgayTao);
                    DataTable dta;
                    DataTable dtaBenhNhan;
                    try
                    {

                        dicE.Clear();
                        dicE.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);
                        dicE.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DangGoi);
                        // lay lai benh nhan dang goi
                        dtaBenhNhan = _api.Search(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                                                  , dicEqual: dicE, orderByASC1: false, orderByName1: cls_STT_CapSo.col_UuTien, orderByASC2: true, orderByName2: cls_STT_CapSo.col_NgayTao);
                        if (dtaBenhNhan != null && dtaBenhNhan.Rows.Count > 0)
                        {
                            // co benh nhan. chạy tiep
                        }
                        // goi benh nhan moi
                        else
                        {
                            dicE.Clear();
                            dicE.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);
                            dicE.Add(cls_STT_CapSo.col_TrangThai, trangThai);

                            DataTable dtaNew = _api.Search(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                                                      , dicEqual: dicE, orderByASC1: false, orderByName1: cls_STT_CapSo.col_UuTien, orderByASC2: true, orderByName2: cls_STT_CapSo.col_NgayTao);


                            if (dtaNew != null && dtaNew.Rows.Count > 0)
                            {
                                if (maNoiCap.Contains("-") && maNoiCap.Split('-')[0].Substring(1) == _CANLAMSANG)// sap xep theo stt
                                {
                                    dta = dtaNew.Select("", "" + cls_STT_CapSo.col_UuTien + " DESC," + cls_STT_CapSo.col_STT + " ASC").CopyToDataTable();
                                }
                                else
                                {
                                    dta = dtaNew.Select("", "" + cls_STT_CapSo.col_UuTien + " DESC," + cls_STT_CapSo.col_NgayTao + " ASC").CopyToDataTable();
                                }
                            }
                            else
                            {
                                dta = new DataTable();
                            }
                            //dta = _api.Search(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                            //                          , dicEqual: dicE, orderByASC1: false, orderByName1: cls_STT_CapSo.col_UuTien, orderByASC2: true, orderByName2: cls_STT_CapSo.col_STT);
                            if (dta != null && dta.Rows.Count > 0)
                            {
                                // có bệnh nhân. lấy số lượng theo num
                            }
                            // lấy bệnh nhân của khu
                            else
                            {
                                dicE.Clear();
                                dicE.Add(cls_STT_CapSo.col_MaNoiCap, sMaNoiCapCha);
                                dicE.Add(cls_STT_CapSo.col_TrangThai, trangThai);
                                dta = _api.Search(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lst: lstColumns, dicDifferent: dicD
                                                     , dicEqual: dicE, orderByASC1: false, orderByName1: cls_STT_CapSo.col_UuTien, orderByASC2: true, orderByName2: cls_STT_CapSo.col_NgayTao);
                            }

                            if (dta != null && dta.Rows.Count > 0)
                            {
                                // có bệnh nhân. lấy số lượng theo num
                                dtaBenhNhan = dta.Copy();
                                int sNumUuTien = dtaBenhNhan.Select(cls_STT_CapSo.col_UuTien + " = '1'").Length;

                                if (sNumCall <= dtaBenhNhan.Rows.Count)
                                {
                                    if (sNumUuTien > 0 && sNumUuTien <= sNumCall)
                                    {
                                        for (int i = sNumUuTien; i < dtaBenhNhan.Rows.Count; i++)
                                        {
                                            DataRow row = dtaBenhNhan.Rows[i];
                                            row.Delete();
                                        }
                                    }
                                    else
                                    {
                                        for (int i = sNumCall; i < dtaBenhNhan.Rows.Count; i++)
                                        {
                                            DataRow row = dtaBenhNhan.Rows[i];
                                            row.Delete();
                                        }
                                    }
                                }
                                else
                                {
                                    if (sNumUuTien > 0 && sNumUuTien <= dtaBenhNhan.Rows.Count)
                                    {
                                        for (int i = sNumUuTien; i < dtaBenhNhan.Rows.Count; i++)
                                        {
                                            DataRow row = dtaBenhNhan.Rows[i];
                                            row.Delete();
                                        }
                                    }
                                }

                                dtaBenhNhan.AcceptChanges();
                            }
                        }

                        if (dtaBenhNhan != null && dtaBenhNhan.Rows.Count > 0)
                        {
                            idBegin = dtaBenhNhan.Rows[0][cls_STT_CapSo.col_ID].ToString();
                            sSTTBegin = dtaBenhNhan.Rows[0][cls_STT_CapSo.col_STT].ToString();
                            try
                            {
                                idEnd = dtaBenhNhan.Rows[dtaBenhNhan.Rows.Count - 1][cls_STT_CapSo.col_ID].ToString();
                                sSTTEnd = dtaBenhNhan.Rows[dtaBenhNhan.Rows.Count - 1][cls_STT_CapSo.col_STT].ToString();
                                sNumCall = dtaBenhNhan.Rows.Count;
                            }
                            catch
                            {
                                idEnd = "";
                                sNumCall = 1;
                            }

                            UpdateTrangThaiCall(dtaBenhNhan, maNoiCap);
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    return sSTTBegin + "~" + sSTTEnd;
                }
                return sSTTBegin + "~" + sSTTEnd;
            }
            catch
            {
                idBegin = "";
                idEnd = "";
                return "";
            }
        }

        public void UpdateTrangThaiCall(DataTable sTable, string maNoiCap)
        {
            Dictionary<string, string> lstWhere = new Dictionary<string, string>();
            Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
            #region Cập nhật trạng thái thành đang gọi để không gọi lại

            foreach (DataRow row in sTable.Rows)
            {
                lstWhere.Clear();
                lstWhere.Add(cls_STT_CapSo.col_ID, row[cls_STT_CapSo.col_ID].ToString());
                lstUpdate.Clear();
                lstUpdate.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DangGoi);
                lstUpdate.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);
                lstUpdate.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                List<string> lstDateTime = new List<string>();
                lstDateTime.Add(cls_STT_CapSo.col_NgayUD);
                _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstDateTime, lstWhere);
            }

            #endregion
        }
        /// <summary>
        /// Gọi lại số
        /// </summary>
        /// <param name="id">id đang gọi</param>
        /// <returns></returns>
        public string ReCall_STT(ref string id)
        {
            try
            {
                bool capNhat = false;
                if (id != "")
                {
                    string sID = id;
                    Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                    Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                    List<string> lstDateTime = new List<string>();
                    #region Call bệnh nhân qua trạng thái delay
                    lstWhere.Clear();
                    lstWhere.Add(cls_STT_CapSo.col_ID, id);

                    lstUpdate.Clear();
                    lstUpdate.Add(cls_STT_CapSo.col_TrangThai, "5");
                    lstUpdate.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstDateTime.Clear();
                    lstDateTime.Add(cls_STT_CapSo.col_NgayUD);
                    capNhat = _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstDateTime, lstWhere);
                    #endregion
                    Thread t1 = new Thread((ThreadStart) =>
                    {
                        Thread.Sleep(500);
                        #region Call bệnh nhân đang gọi
                        lstWhere.Clear();
                        lstWhere.Add(cls_STT_CapSo.col_ID, sID);
                        lstUpdate.Clear();
                        lstUpdate.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DangGoi);
                        lstUpdate.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                        lstDateTime.Clear();
                        lstDateTime.Add(cls_STT_CapSo.col_NgayUD);

                        capNhat = _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstDateTime, lstWhere);
                        #endregion
                    });
                    t1.Start();
                }
                return "";
            }
            catch
            {
                id = "";
                return "";
            }
        }
        /// <summary>
        /// Gọi lại số bất kỳ Nguyễn QUốc Vạn
        /// </summary>
        /// <param name="id">số đang dọi</param>
        /// <param name="idGoiLai">số gọi lại</param>
        /// <param name="maNoiCap">nơi gọi số</param>
        public void ReCall_STT_ANY(ref string id, string idGoiLai, string maNoiCap)
        {
            try
            {
                bool capNhat = false;
                if (string.IsNullOrEmpty(id))
                {
                    DataTable tmp = GetSoGoi(maNoiCap);
                    if (tmp != null && tmp.Rows.Count > 0)
                    {
                        if (tmp.Rows.Count == 1)
                        {
                            if (!string.IsNullOrEmpty(tmp.Rows[0]["id"].ToString()))
                            {
                                id = tmp.Rows[0]["id"].ToString();
                            }
                            else
                            {
                                TA_MessageBox.MessageBox.Show("Không thể gọi lại bệnh nhân này!", TA_MessageBox.MessageIcon.Error);
                                return;
                            }
                        }
                    }
                }
                Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                List<string> lstDateTime = new List<string>();
                lstWhere.Add(cls_STT_CapSo.col_ID, id);
                lstUpdate.Add(cls_STT_CapSo.col_TrangThai, "2");
                lstUpdate.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                lstDateTime.Add(cls_STT_CapSo.col_NgayUD);
                capNhat = _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstDateTime, lstWhere);
                if (capNhat)
                {
                    lstWhere.Clear();
                    lstWhere.Add(cls_STT_CapSo.col_ID, idGoiLai);
                    lstUpdate.Clear();
                    lstUpdate.Add(cls_STT_CapSo.col_TrangThai, "1");
                    lstUpdate.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                    lstDateTime.Clear();
                    lstDateTime.Add(cls_STT_CapSo.col_NgayUD);
                    capNhat = _api.Update(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstDateTime, lstWhere);
                    if (capNhat)
                    {
                        id = idGoiLai;
                    }
                }
            }
            catch
            {
                id = "";
            }
        }

        /// <summary>
        /// Vannq 13/04/2018 Lấy danh sách CLS
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadDSBenhNhan(string loai, string maNoiCap)
        {
            try
            {
                string loaiCLS = "";
                string tu = DateTime.Now.ToString("dd/MM/yyyy");
                string den = DateTime.Now.ToString("dd/MM/yyyy");
                string sql = "select distinct a.mabn,a.maql,b.hoten,b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||', '||trim(k.tenpxa)||', '||trim(j.tenquan)||', '||trim(i.tentt) as diachi,b.cholam,";
                sql += " to_char(a.makp) as kp,c.tenkp,a.mabs,e.hoten as tenbs,";
                sql += " a.maicd,0 as sotien,l.nha,l.coquan,l.didong ";

                if (loai == _CANLAMSANG) // khu vực cận lâm sàng
                {
                    string makhu = "";
                    
                    if(maNoiCap.Contains("-"))
                    {
                        makhu = maNoiCap.Split('-')[1];
                        loaiCLS = maNoiCap.Split('-').Length == 3 ? maNoiCap.Split('-')[2] : "";
                    }
                    sql += " ,a.stt_led, a.ngay_cap_stt_led ";
                    sql += " from " + _acc.Get_UserMMYY() + ".v_chidinh a ";
                    sql += " inner join " + _acc.Get_User() + ".btdbn b on a.mabn=b.mabn ";
                    sql += " left join " + _acc.Get_User() + ".btdkp_bv c on a.makp=c.makp ";
                    sql += " left join " + _acc.Get_User() + ".dmbs e on a.mabs=e.ma ";
                    sql += " left join " + _acc.Get_User() + ".btdtt i on b.matt=i.matt ";
                    sql += " left join " + _acc.Get_User() + ".btdquan j on b.maqu=j.maqu ";
                    sql += " left join " + _acc.Get_User() + ".btdpxa k on b.maphuongxa=k.maphuongxa ";
                    sql += " left join " + _acc.Get_User() + ".dienthoai l on a.mabn=l.mabn ";
                    sql += " left join " + _acc.Get_User() + ".v_giavp o on a.mavp = o.id ";
                    sql += " left join " + _acc.Get_User() + ".V_LOAIVP p on o.ID_LOAI = p.ID ";
                    sql += " left join " + _acc.Get_User() + ".v_nhomvp q on p.ID_NHOM = q.ma ";
                    sql += " left join " + _acc.Get_User() + ".cdha_kythuat r on a.mavp = r.idvp ";
                    sql += " left join " + _acc.Get_User() + ".cdha_dmloai s on r.ID_LOAI = s.ID ";
                    sql += " where ";
                    if (loaiCLS == _loaiCLS_TRAKQ)
                    {
                        sql += " a.done=1 ";
                    }
                    else
                    {
                        sql += " a.done=0 ";
                    }
                    sql += " and s.id is not null and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy')";
                    sql += " and a.maql not in (select maql from " + _acc.Get_User() + ".stt_capso where maql is not null and manoicap = '" + maNoiCap + "'";
                    sql += " and to_date(to_char(ngaytao,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy'))";
                    if (!string.IsNullOrEmpty(makhu) && makhu.Trim() != "256")
                    {
                        sql += " and s.id = " + makhu;
                    }
                    else if (!string.IsNullOrEmpty(makhu) && makhu.Trim() == "256")
                    {
                        sql += " and s.id in (2,5,6) ";
                    }
                }
                else // khu vực khác
                { 
                    if (loai == _NHATHUOC)  // khu vực nhà thuốc
                    {
                        sql += " from " + _acc.Get_UserMMYY() + ".d_thuocbhytll a ";
                        sql += " inner join " + _acc.Get_UserMMYY() + ".d_thuocbhytct z on a.id = z.id ";
                    }
                    else if (loai == _VIENPHI) // khu viện phí
                    {
                        sql += " from " + _acc.Get_UserMMYY() + ".v_chidinh a ";
                    }
                    sql += "inner join " + _acc.Get_User() + ".btdbn b on a.mabn=b.mabn ";
                    sql += " left join " + _acc.Get_User() + ".btdkp_bv c on a.makp=c.makp ";
                    sql += " left join " + _acc.Get_User() + ".dmbs e on a.mabs=e.ma ";
                    sql += " left join " + _acc.Get_User() + ".btdtt i on b.matt=i.matt ";
                    sql += " left join " + _acc.Get_User() + ".btdquan j on b.maqu=j.maqu ";
                    sql += " left join " + _acc.Get_User() + ".btdpxa k on b.maphuongxa=k.maphuongxa ";
                    sql += " left join " + _acc.Get_User() + ".dienthoai l on a.mabn=l.mabn ";
                    sql += " where a.done=0 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy')";
                    if (loai == _NHATHUOC) //khu nhà thuốc
                    {
                        sql += " and (a.madoituong = 5 or (a.madoituong =1 and z.madoituong = 2)) ";
                    }
                    sql += " and a.maql not in (select maql from " + _acc.Get_User() + ".stt_capso where maql is not null and manoicap = '" + maNoiCap + "'";
                    sql += " and to_date(to_char(ngaytao,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy'))";
                    if (loai == _VIENPHI) // khu viện phí
                    {
                        sql += " and a.madoituong <> 1 ";
                        sql += " and a.mabn not in ( select distinct mabn ";
                        sql += " from " + _acc.Get_UserMMYY() + ".d_thuocbhytll a ";
                        sql += " inner join " + _acc.Get_UserMMYY() + ".d_thuocbhytct z on a.id = z.id ";
                        sql += " where a.done=0 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy'))";

                        #region Code cu

                        //sql += " UNION ALL ";//lấy BHYT có thuốc mua ngoài
                        //sql += " select distinct a.mabn,a.maql,b.hoten,b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||', '||trim(k.tenpxa)||', '||trim(j.tenquan)||', '||trim(i.tentt) as diachi,b.cholam,";
                        //sql += " to_char(a.makp) as kp,c.tenkp,a.mabs,e.hoten as tenbs,";
                        //sql += " a.maicd,0 as sotien,l.nha,l.coquan,l.didong ";
                        //sql += " from " + _acc.Get_UserMMYY() + ".d_thuocbhytll a ";
                        //sql += " inner join " + _acc.Get_UserMMYY() + ".d_thuocbhytct z on a.maql = z.id ";
                        //sql += "inner join " + _acc.Get_User() + ".btdbn b on a.mabn=b.mabn ";
                        //sql += " left join " + _acc.Get_User() + ".btdkp_bv c on a.makp=c.makp ";
                        //sql += " left join " + _acc.Get_User() + ".dmbs e on a.mabs=e.ma ";
                        //sql += " left join " + _acc.Get_User() + ".btdtt i on b.matt=i.matt ";
                        //sql += " left join " + _acc.Get_User() + ".btdquan j on b.maqu=j.maqu ";
                        //sql += " left join " + _acc.Get_User() + ".btdpxa k on b.maphuongxa=k.maphuongxa ";
                        //sql += " left join " + _acc.Get_User() + ".dienthoai l on a.mabn=l.mabn ";
                        //sql += " where a.done=0 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy')";
                        //sql += " and (a.madoituong =1 and z.madoituong = 2) ";
                        //sql += " and a.maql not in (select maql from " + _acc.Get_User() + ".stt_capso where maql is not null and manoicap = '" + maNoiCap + "'";
                        //sql += " and to_date(to_char(ngaytao,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy'))";

                        //sql += " UNION ALL ";// lấy chỉ định không toa thuốc. trừ chỉ định bhyt
                        //sql += " select distinct a.mabn,a.maql,b.hoten,b.namsinh,b.phai,trim(b.sonha)||' '||trim(b.thon)||', '||trim(k.tenpxa)||', '||trim(j.tenquan)||', '||trim(i.tentt) as diachi,b.cholam,";
                        //sql += " a.makp as kp,c.tenkp,a.mabs,e.hoten as tenbs,";
                        //sql += " a.maicd,0 as sotien,l.nha,l.coquan,l.didong ";
                        //sql += " from " + _acc.Get_UserMMYY() + ".v_chidinh a ";
                        //sql += "inner join " + _acc.Get_User() + ".btdbn b on a.mabn=b.mabn ";
                        //sql += " left join " + _acc.Get_User() + ".btdkp_bv c on a.makp=c.makp ";
                        //sql += " left join " + _acc.Get_User() + ".dmbs e on a.mabs=e.ma ";
                        //sql += " left join " + _acc.Get_User() + ".btdtt i on b.matt=i.matt ";
                        //sql += " left join " + _acc.Get_User() + ".btdquan j on b.maqu=j.maqu ";
                        //sql += " left join " + _acc.Get_User() + ".btdpxa k on b.maphuongxa=k.maphuongxa ";
                        //sql += " left join " + _acc.Get_User() + ".dienthoai l on a.mabn=l.mabn ";
                        //sql += " where a.done=0 and a.madoituong <> 1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy')";
                        //sql += " and a.maql not in (select maql from " + _acc.Get_User() + ".stt_capso where maql is not null and manoicap = '" + maNoiCap + "'";
                        //sql += " and to_date(to_char(ngaytao,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy'))";
                        //sql += " and a.maql not in ( select distinct maql ";
                        //sql += " from " + _acc.Get_UserMMYY() + ".d_thuocbhytll a ";
                        //sql += " inner join " + _acc.Get_UserMMYY() + ".d_thuocbhytct z on a.maql = z.id ";
                        //sql += " where a.done=0 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy')";
                        //sql += " and (a.madoituong = 5 or (a.madoituong =1 and z.madoituong = 2))) ";
                        //sql += " and a.maql not in (select maql from " + _acc.Get_User() + ".stt_capso where maql is not null and manoicap = '" + maNoiCap + "'";
                        //sql += " and to_date(to_char(ngaytao,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu + "','dd/mm/yyyy') and to_date('" + den + "','dd/mm/yyyy'))"; 
                        #endregion
                    } 
                }
                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Vannq 13/04/2018 Lấy row trong datatable
        /// </summary>
        /// <param name="dt">datatable truyền vào</param>
        /// <param name="exp">đk lọc</param>
        /// <returns></returns>
        public DataRow getrowbyid(DataTable dt, string exp)
        {
            System.Data.DataRow result;
            try
            {
                System.Data.DataRow[] r = dt.Select(exp);
                if (r.Length > 0)
                {
                    result = r[0];
                }
                else
                {
                    result = null;
                }
            }
            catch
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Nguyễn Quốc Vạn 14-05-2018
        /// </summary>
        /// <param name="maPhong">Mã phòng</param>
        /// <param name="maKhu">Mã khu vực</param>
        /// <param name="daGoi">Trạng thái để lấy bệnh nhân chưa gọi và đã gọi</param>
        /// <returns></returns>
        public DataTable Get_DSBNDaCapSTT(string maPhong, string maKhu, bool daGoi)
        {
            try
            {
                string SMaNoiCap = "";
                if (maPhong != "")
                {
                    SMaNoiCap = cls_STT_KhuVucPhong.col_Phong + maPhong;
                }
                else if (maKhu != "")
                {
                    SMaNoiCap = cls_STT_KhuVucPhong.col_KhuVuc + maKhu;
                }
                string query = string.Format("SELECT a.ID,a.MABN,a.MANOICAP,a.TRANGTHAI,a.UUTIEN,a.STT,a.TAMNGUNG,a.USERID,b.HOTEN,b.PHAI,b.NAMSINH,b.hotenkdau,a.maql "
                                         + " FROM {0}.{1} a "
                                         + " LEFT JOIN {0}.BTDBN b on a.MABN = b.MABN"
                                         + " WHERE a.TRANGTHAI in ({4}) and a.{2} = '{3}' "
                                         + " AND TO_CHAR(a.NGAYTAO,'dd/mm/yyyy') = '{5}' " //phải được lấy theo chu kỳ

                                      , _acc.Get_User() //0
                                      , cls_STT_CapSo.tb_TenBang //1
                                      , cls_STT_CapSo.col_MaNoiCap //2
                                      , SMaNoiCap //3
                                      , daGoi ? "1,2" : "0" //4
                                      , Get_curDate().ToString("dd/MM/yyyy")); //5
                query += " ORDER BY a.NGAYTAO";

                return _acc.Get_Data(query);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra form đang mở
        /// </summary>
        /// <param name="formtext">form.text</param>
        /// <returns></returns>
        public bool CheckOpened(string formtext)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == formtext)
                {
                    return true;
                }
            }
            return false;
        }

        public DataTable LoadChuKyGio()
        {
            try
            {
                string sNameColumn = "";
                if (cls_System.sys_Kieu == cls_System.sys_KieuAcc)
                {       /// kiểu accc chưa phát triêrn

                    throw new Exception("Chưa phát triển");

                }
                else if (cls_System.sys_Kieu == cls_System.sys_KieuSQL)
                {
                    #region Kiểu SQL Sever
                    sNameColumn = "CONVERT(NVARCHAR(5)," + cls_STT_TimeZone.col_TimeBegin + ",8) " +
                                          " + ' - ' +  CONVERT(NVARCHAR(5)," + cls_STT_TimeZone.col_TimeEnd + ",8) as TEN";

                    #endregion
                }
                else if (cls_System.sys_Kieu == cls_System.sys_KieuORC)
                {
                    #region  kiểu oracle
                    sNameColumn = "TO_CHAR(" + cls_STT_TimeZone.col_TimeBegin + ",'HH24:MI') " +
                                          " || ' - ' ||  TO_CHAR(" + cls_STT_TimeZone.col_TimeEnd + ",'HH24:MI') as TEN";
                    #endregion
                }
                string sql = string.Format("select id, {0} from {1}.STT_TIMEZONE WHERE TAMNGUNG <> '1' Order By ID ASC  ", sNameColumn, _acc.Get_User());
                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }

        public bool InsertSTTDangKyCT(string idKhu, string sTT, string done, string uuTien, string ngayTao, string ngaySua)
        {
            string sql = string.Format("INSERT INTO {0}.{1} ({2},{3},{4},{5},{6},{7}) VALUES ('{8}','{9}','{10}','{11}',TO_DATE('{12}','YYYY-MM-DD HH24:MI:SS'),TO_DATE('{13}','YYYY-MM-DD HH24:MI:SS'))",
                                        _acc.Get_User(),       //0
                                        cls_STT_DangKyCT.tb_TenBang,//1
                                        cls_STT_DangKyCT.col_IDKhu,//2
                                        cls_STT_DangKyCT.col_STT,//3
                                        cls_STT_DangKyCT.col_Done,//4
                                        cls_STT_DangKyCT.col_UuTien,//5
                                        cls_STT_DangKyCT.col_Ngay,//6
                                        cls_STT_DangKyCT.col_NgayUD,//7
                                        idKhu,//8
                                        sTT,//9
                                        done,//10
                                        uuTien,//11
                                        ngayTao,//12
                                        ngaySua);//13
            return _acc.Execute_Data(ref _userError, ref _systemError, sql);
        }

        public string GetTiepDon(string maNhomKV, string loaiSTT)
        {
            try
            {
                string sql = string.Format("select {0} from {1}.{2} where {3} = '{4}'", loaiSTT, _acc.Get_User(), cls_STT_NhomKhuVuc.tb_TenBang, cls_STT_NhomKhuVuc.col_Ma, maNhomKV);
                return _acc.Get_Data(sql).Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }

        public string GetNhaThuoc(string maNhomKV)
        {
            try
            {
                string sql = string.Format("select {0} from {1}.{2} where {3} = '{4}'", cls_STT_NhomKhuVuc.col_MaLoai, _acc.Get_User(), cls_STT_NhomKhuVuc.tb_TenBang, cls_STT_NhomKhuVuc.col_Ma, maNhomKV);
                return _acc.Get_Data(sql).Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }

        public string GetThongTinSoGoi(string maNoiCap)
        {
            DataTable tmp = GetSoGoi(maNoiCap);
            string strBN = "";
            if (tmp != null && tmp.Rows.Count > 0)
            {
                if (tmp.Rows.Count == 1)
                {
                    if (!string.IsNullOrEmpty(tmp.Rows[0][3].ToString()))
                    {
                        strBN = "Đang gọi bệnh nhân: ";
                        strBN += tmp.Rows[0][0].ToString() + ": " + tmp.Rows[0][3].ToString();

                    }
                    else
                    {
                        strBN = "Đang gọi bệnh nhân: ";
                        strBN += tmp.Rows[0][0].ToString();
                    }
                }
            }
            return strBN;
        }

        /// <summary>
        /// Cấp số thứ tự cho bn 15/04/2018
        /// </summary>
        /// <returns></returns>
        public bool CapSTT(string maNoiCap,string tenKhu, string tenPhong, string maBN, string maQL,string hoTen, bool uuTien, bool isPrint, bool isXemIn, ref  string Stt)
        {

            DataRow drCapSo1 = null;
            string stt = "";
            // string SMaNoiCap = "";
            try
            {
                Dictionary<string, string> lstData = new Dictionary<string, string>();
                if (maNoiCap.Contains("-") && maNoiCap.Split('-')[0].Substring(1) != _CANLAMSANG)
                {
                    if (!CheckChuKy(maNoiCap)) return false;
                }
                #region Tạo bảng in
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Table";
                dt.Columns.Add("TEN");
                dt.Columns.Add("NGAY");
                dt.Columns.Add("SO");
                dt.Columns.Add("UT",typeof(int));
                dt.Columns.Add("MABN");
                dt.Columns.Add("HOTEN");
                ds.Tables.Add(dt);
                #endregion
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                List<string> lstKiemTraTrung = new List<string>();
                _userError = "";
                _systemError = "";
                #region Cấp STT Cho bệnh nhân
                stt = "";
                try
                {
                    dicE.Clear();
                    dicE.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                    if (maNoiCap.Contains("-") && maNoiCap.Split('-')[0].Substring(1) == _CANLAMSANG)
                    {
                        stt = Stt;
                    }
                    else
                    {
                        drCapSo1 = _api.Search(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, andEqual: false, dicEqual: dicE,
                                                  orderByASC1: true, orderByName1: cls_STT_DinhNghia.col_ID).Rows[0];
                        if (drCapSo1[cls_STT_DinhNghia.col_DienGiai].ToString() != "hhmmss")
                        {
                            stt = CapSTT(int.Parse(drCapSo1[cls_STT_DinhNghia.col_ChieuDai].ToString())
                                                       , drCapSo1[cls_STT_DinhNghia.col_ChuoiCoDinh].ToString()
                                                       , drCapSo1[cls_STT_DinhNghia.col_DauNganCach].ToString()
                                                       , drCapSo1[cls_STT_DinhNghia.col_DinhDangNgay].ToString()
                                             , int.Parse(drCapSo1[cls_STT_DinhNghia.col_BuocNhay].ToString())
                                             , int.Parse(drCapSo1[cls_STT_DinhNghia.col_SoHienTai].ToString())
                                             , int.Parse(drCapSo1[cls_STT_DinhNghia.col_SoToiDa].ToString()));
                            Stt = stt;
                        }
                        else
                        {
                            stt = Stt;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                if (stt == "")
                {
                    return false;
                }
                lstData.Clear();
                lstData.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);
                lstData.Add(cls_STT_CapSo.col_STT, stt);
                lstData.Add(cls_STT_CapSo.col_MaBN, maBN);
                lstData.Add(cls_STT_CapSo.col_MaQL, maQL);
                lstData.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_ChuaGoi);
                lstData.Add(cls_STT_CapSo.col_TamNgung, "0");
                lstData.Add(cls_STT_CapSo.col_UuTien, uuTien ? "1" : "0");
                lstData.Add(cls_STT_CapSo.col_UserID, cls_System.sys_UserID);
                lstData.Add(cls_STT_CapSo.col_NgayTao, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                lstData.Add(cls_STT_CapSo.col_UserUD, cls_System.sys_UserID);
                lstData.Add(cls_STT_CapSo.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));

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
                    if (maNoiCap.Contains("-") && maNoiCap.Split('-')[0].Substring(1) == _CANLAMSANG)
                    {
                        string tenphong = string.IsNullOrEmpty(tenPhong) ? tenKhu : tenPhong;
                        DataRow Row = dt.NewRow();
                        Row["TEN"] = tenphong;
                        Row["NGAY"] = Get_curDate().ToString("dd/MM/yyyy HH:mm:ss");
                        Row["SO"] = stt;
                        Row["UT"] = uuTien ? 1 : 0;
                        Row["MABN"] = maBN;
                        Row["HOTEN"] = hoTen;
                        dt.Rows.Add(Row);
                        dt.AcceptChanges();
                    }
                    else
                    {
                        Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                        lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, (int.Parse(drCapSo1[cls_STT_DinhNghia.col_SoHienTai].ToString())
                                                                 + int.Parse(drCapSo1[cls_STT_DinhNghia.col_BuocNhay].ToString())).ToString());
                        lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                        lstWhere.Add(cls_STT_DinhNghia.col_Ma, lstData[cls_STT_CapSo.col_MaNoiCap]);
                        List<string> lstDateTime = new List<string>();
                        lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                        if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                        {
                            string tenphong = string.IsNullOrEmpty(tenPhong) ? tenKhu : tenPhong;
                            DataRow Row = dt.NewRow();
                            Row["TEN"] = tenphong;
                            Row["NGAY"] = Get_curDate().ToString("dd/MM/yyyy HH:mm:ss");
                            Row["SO"] = stt;
                            Row["UT"] = uuTien ? 1 : 0;
                            Row["MABN"] = maBN;
                            Row["HOTEN"] = hoTen;
                            dt.Rows.Add(Row);
                            dt.AcceptChanges();
                        }
                    }
                }
                #endregion
               // Stt = stt;
                PrintSTT(ds,isPrint,isXemIn);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckChuKy(string maNoiCap)
        {
            try
            {
                _drCapSo = null;
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Clear();
                dicE.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                try
                {
                    _drCapSo = _api.Search(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, andLike: false, dicLike: dicE,
                                                   orderByASC1: true, orderByName1: cls_STT_DinhNghia.col_ID).Rows[0];
                }
                catch
                {
                    _drCapSo = null;
                }
                if (_drCapSo == null)
                {
                    TA_MessageBox.MessageBox.Show("Nơi cấp số chưa được định nghĩa!\nVui lòng vào mục Quản lý STT -> Định nghĩa STT để định nghĩa cho nơi cấp số", TA_MessageBox.MessageIcon.Error);
                    return false;
                }
                if (_drCapSo[cls_STT_DinhNghia.col_DienGiai].ToString() == "hhmmss") return true;// định nghĩa theo h phút giây
                if (_drCapSo[cls_STT_DinhNghia.col_CoChuKy].ToString() != "1") return false;

                if (_drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "1") // ngay
                {
                    if (_drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != Get_curDate().Day.ToString())
                    {
                        UpdateAllCapSo(maNoiCap);
                        Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                        lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, _drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                        lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                        lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, (Get_curDate().Day.ToString()));

                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                        lstWhere.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                        List<string> lstDateTime = new List<string>();
                        lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                        if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                        {
                        }
                    }
                }
                else if (_drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "2")
                {
                    int iWeek = 0;
                    DateTime iDate;
                    GetWeekInYear(Get_curDate(), out iDate, out iWeek);
                    if (_drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != iWeek.ToString())
                    {
                        UpdateAllCapSo(maNoiCap);
                        Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                        lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, _drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                        lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                        lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, (iWeek.ToString()));

                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                        lstWhere.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                        List<string> lstDateTime = new List<string>();
                        lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                        if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                        {
                        }
                    }
                }
                else if (_drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "3")
                {
                    if (_drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != Get_curDate().Month.ToString())
                    {
                        UpdateAllCapSo(maNoiCap);
                        Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                        lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, _drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                        lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                        lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, (Get_curDate().Month.ToString()));

                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                        lstWhere.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                        List<string> lstDateTime = new List<string>();
                        lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                        if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                        {
                        }
                    }
                }
                else if (_drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "4")
                {
                    if (_drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != Get_curDate().Year.ToString())
                    {
                        UpdateAllCapSo(maNoiCap);
                        Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                        lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, _drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                        lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                        lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, (Get_curDate().Year.ToString()));

                        Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                        lstWhere.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                        List<string> lstDateTime = new List<string>();
                        lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                        if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                        {
                        }
                    }
                }
                // chu kỳ theo giờ
                else if (_drCapSo[cls_STT_DinhNghia.col_ChuKy].ToString() == "5" && _drCapSo[cls_STT_DinhNghia.col_IdTimeZone].ToString() != "")
                {
                    #region Lấy danh mục giờ
                    Dictionary<string, string> dicLike = new Dictionary<string, string>();
                    dicLike.Add(cls_STT_TimeZone.col_ID, _drCapSo[cls_STT_DinhNghia.col_IdTimeZone].ToString());
                    DataTable _dtaTime = _api.Search(ref _userError, ref _systemError, cls_STT_TimeZone.tb_TenBang, andLike: false, dicLike: dicLike,
                                                    orderByASC1: true, orderByName1: cls_STT_TimeZone.col_ID);
                    #endregion
                    if (_dtaTime != null && _dtaTime.Rows.Count > 0)
                    {

                        DataRow row = _dtaTime.Select(cls_STT_TimeZone.col_ID + " = '" + _drCapSo[cls_STT_DinhNghia.col_IdTimeZone].ToString() + "'")[0];
                        DateTime hourBegin = DateTime.Parse(row[cls_STT_TimeZone.col_TimeBegin].ToString());
                        DateTime hourEnd = DateTime.Parse(row[cls_STT_TimeZone.col_TimeEnd].ToString());

                        DateTime timeBegin = new DateTime(Get_curDate().Year, Get_curDate().Month, Get_curDate().Day, hourBegin.Hour, hourBegin.Minute, 0);
                        DateTime timeEnd = new DateTime(Get_curDate().Year, Get_curDate().Month, Get_curDate().Day, hourEnd.Hour, hourEnd.Minute, 59);
                        if (timeBegin <= Get_curDate() && Get_curDate() <= timeEnd)
                        {
                            if (_drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != "1")
                            {
                                UpdateAllCapSo(maNoiCap);
                                Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                                lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, _drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                                lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                                lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, "1");

                                Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                                lstWhere.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                                List<string> lstDateTime = new List<string>();
                                lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                                if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                                {
                                }
                            }
                        }
                        else
                        {
                            if (_drCapSo[cls_STT_DinhNghia.col_ChuKyHienTai].ToString() != "0")
                            {
                                UpdateAllCapSo(maNoiCap);
                                Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
                                lstUpdate.Add(cls_STT_DinhNghia.col_SoHienTai, _drCapSo[cls_STT_DinhNghia.col_SoBatDau].ToString());
                                lstUpdate.Add(cls_STT_DinhNghia.col_NgayUD, (Get_curDate().ToString("yyyy-MM-dd HH:mm:ss")));
                                lstUpdate.Add(cls_STT_DinhNghia.col_ChuKyHienTai, "0");

                                Dictionary<string, string> lstWhere = new Dictionary<string, string>();
                                lstWhere.Add(cls_STT_DinhNghia.col_Ma, maNoiCap);
                                List<string> lstDateTime = new List<string>();
                                lstDateTime.Add(cls_STT_DinhNghia.col_NgayUD);

                                if (_api.Update(ref _userError, ref _systemError, cls_STT_DinhNghia.tb_TenBang, lstUpdate, lstDateTime, lstWhere))
                                {
                                }
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

        public void DeleteDataCapSo()
        {
            try
            {
                string datetemp = Get_curDate().ToString("dd/MM/yyyy");
                string date = "01" + datetemp.Substring(2);
                string sql = string.Format("delete from {0}.stt_capso where to_date(to_char(ngaytao,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('{1}','dd/mm/yyyy')", _acc.Get_User(), date);
                if (datetemp.Substring(0, 2) != "01")
                {
                    _acc.Execute_Data(ref _userError, ref _systemError, sql);
                }
            }
            catch { }
        }

        private void UpdateAllCapSo(string maNoiCap)
        {

            Dictionary<string, string> lstWhere = new Dictionary<string, string>();
            lstWhere.Add(cls_STT_CapSo.col_MaNoiCap, maNoiCap);

            Dictionary<string, string> lstUpdate = new Dictionary<string, string>();
            lstUpdate.Add(cls_STT_CapSo.col_TrangThai, cls_STT_KhuVucPhong.col_DaGoi);

            _api.UpdateAll(ref _userError, ref _systemError, cls_STT_CapSo.tb_TenBang, lstUpdate, lstWhere);
        }

        private void GetWeekInYear(DateTime datetime, out DateTime FirstDayOfWeek, out int CurrentWeek)
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
            CurrentWeek = myCal.GetWeekOfYear(Get_curDate(), myCWR, myFirstDOW);
            //txt += "<br>" + string.Format("Therefore, the current week is Week {0} of the current year.", CurrentWeek);
            FirstDayOfWeek = Get_curDate();
            while (FirstDayOfWeek.DayOfWeek != DayOfWeek.Monday) FirstDayOfWeek = FirstDayOfWeek.AddDays(-1); // tìm đầu tuần
            //txt += "<br>" + string.Format("The FirstDayOfWeek  for the current week is {0}.", FirstDayOfWeek.ToString("dd/MM/yyyy"));

            // Displays the total number of weeks in the current year.
            DateTime LastDay = new System.DateTime(Get_curDate().Year, 12, 31);
            //txt += "<br>" + string.Format("There are {0} weeks in the current year ({1}).", myCal.GetWeekOfYear(LastDay, myCWR, myFirstDOW), LastDay.Year);
            //return txt;
        }

        private void PrintSTT(DataSet ds, bool isPrint, bool isXemIn)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (isPrint)
                {
                    try
                    {
                        if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                        ds.WriteXml("..//xml//rptSttdangky.xml", XmlWriteMode.WriteSchema);
                        if (isXemIn)
                        {
                            ReportDocument oRpt = new ReportDocument();
                            oRpt.Load("..\\..\\..\\Report\\rptSttdangky.rpt", OpenReportMethod.OpenReportByDefault);
                            oRpt.SetDataSource(ds);
                            frm_ReportSTT frm = new frm_ReportSTT(oRpt);
                            frm.Text = "rptSttdangky.rpt";
                            frm.ShowDialog();
                        }
                        else
                        {
                            ReportDocument rptDoc = new ReportDocument();
                            //ds.ReadXml("..\\..\\..\\Report\\sttkham.rpt", XmlReadMode.ReadSchema);
                            rptDoc.Load("..\\..\\..\\Report\\rptSttdangky.rpt", OpenReportMethod.OpenReportByDefault);
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

        #endregion

    }
}
