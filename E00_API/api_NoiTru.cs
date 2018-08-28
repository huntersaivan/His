using System;
using System.Collections.Generic;
using System.Data;
using E00_API.Base;
using E00_Common;
using E00_Model;
using E00_System;
using E00_Helpers;
using TA_MessageBox;
using System.Data.OracleClient;
using E00_Helpers.Format;
using E00_Helpers.Helpers;

namespace E00_API
{
   public class api_NoiTru
    {
        //**-----------------------------------------------------------------

        #region Member

        public static readonly Acc_Oracle _acc = new Acc_Oracle();
        private static readonly Api_Common _api = new Api_Common();
        private static readonly LibDal.AccessData _api1 = new LibDal.AccessData();
        private static readonly LibMedi.AccessData _libMediAccessData = new LibMedi.AccessData() ;
        private static string _userError = string.Empty;
        private static string _systemError = string.Empty;
        public static LibMedi.AccessData LibMediAccessData { get { return _libMediAccessData; } }
        #endregion

        //**-----------------------------------------------------------------

        #region Constructor
        public api_NoiTru()
        {

        }
        #endregion

        //**-----------------------------------------------------------------

        #region Public Method

        #region Get Data
        public decimal get_mabn(int yy, int loai, int userid, bool update)
        {
            string[] textArray1;
            int num = 0;
            update = false;
            userid = int.Parse(userid.ToString() + 1);
            DataTable table = _acc.Get_Data(string.Concat(new object[] { "select stt from ", _acc.Get_User(), ".capmabn where yy=", yy, " and loai=", loai, " and userid=", userid }));
            if(table != null) {
                if (table.Rows.Count > 0)
                {
                    num = int.Parse(table.Rows[0]["stt"].ToString());
                }
            }
            else
            {
                try
                {
                    table = _acc.Get_Data(string.Concat(new object[] { "select max(stt) stt from ", _acc.Get_User(), ".capmabn where yy=", yy, " and loai=", loai }));
                    if (table.Rows.Count > 0)
                    {
                        num = int.Parse(table.Rows[0]["stt"].ToString());
                    }
                }
                catch
                {
                    num++;
                }
                update = true;
            }
            Label_018B:
            textArray1 = new string[] { "select mabn from ", _acc.Get_User(), ".btdbn where mabn='", yy.ToString().PadLeft(2, '0'), num.ToString().PadLeft(6, '0'), "'" };
            string sql = string.Concat(textArray1);
            sql = sql + " union all ";
            object[] objArray3 = new object[] { sql, "select to_char(stt) mabn from ", _acc.Get_User(), ".capmabn where stt=", num, " and yy=", yy, " and userid<>", userid };
            sql = string.Concat(objArray3);
            table = _acc.Get_Data(sql);
            if (table.Rows.Count > 0)
            {
                num++;
                update = true;
                goto Label_018B;
            }
            if (update)
            {
                upd_capmabn(yy, loai, userid, num);
            }
            return num;
        }
        public void upd_capmabn(int m_yy, int m_loai, int m_userid, int m_stt)
        {
            try
            {
                string sql = "update " + _acc.Get_User() + ".capmabn set stt=:m_stt where yy=:m_yy and loai=:m_loai and userid=:m_userid";
               //CloseConnection();
               // cmd = new OracleCommand(sql, con);
               // cmd.CommandType = CommandType.Text;
               // cmd.Parameters.Add("m_stt", OracleDbType.Decimal).Value = m_stt;
               // cmd.Parameters.Add("m_yy", OracleDbType.Decimal).Value = m_yy;
               // cmd.Parameters.Add("m_loai", OracleDbType.Decimal).Value = m_loai;
               // cmd.Parameters.Add("m_userid", OracleDbType.Decimal).Value = m_userid;
               // int num = cmd.ExecuteNonQuery();
               // cmd.Dispose();
               // if (num == 0)
               // {
               //     sql = "insert into " + user + ".capmabn(yy,stt,loai,userid) values (:m_yy,:m_stt,:m_loai,:m_userid)";
               //     cmd = new OracleCommand(sql, con);
               //     cmd.CommandType = CommandType.Text;
               //     cmd.Parameters.Add("m_yy", OracleDbType.Decimal).Value = m_yy;
               //     cmd.Parameters.Add("m_stt", OracleDbType.Decimal).Value = m_stt;
               //     cmd.Parameters.Add("m_loai", OracleDbType.Decimal).Value = m_loai;
               //     cmd.Parameters.Add("m_userid", OracleDbType.Decimal).Value = m_userid;
               //     cmd.ExecuteNonQuery();
               //     cmd.Dispose();
               // }
               // CloseConnectionFinally();
            }
            catch
            {
            }
        }
        public static string AutoGenerateMaBN()
        {
            clsBUS _phuongThuc = new clsBUS();
            LibDal.AccessData libDal_AccessData = new LibDal.AccessData();
            string yy = libDal_AccessData.ngayhienhanh_server.Substring(8, 2);
            int stt = _phuongThuc.CapMaBN(int.Parse(libDal_AccessData.ngayhienhanh_server.Substring(8, 2)), 1, int.Parse(cls_System.sys_UserID != "" ? cls_System.sys_UserID : "0"), true);
            return yy + stt.ToString().PadLeft(6, '0');
        }
        public static string AutoGenerateNumberSoNhapVien(Acc_Oracle _acc)
        {
            try
            {
                string sql = "select TO_CHAR(SYSDATE, MaSO.NAM) NamValue,MaSO.*  from " + _acc.Get_User() + ".MASO_DANHMUC MaSO where Ma ='SVV' and (MaSO.HIDE = 0)";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        int so = int.Parse("" + table.Rows[0]["DANGGHI"]) + int.Parse("" + table.Rows[0]["NHAY"]);
                        string chuoi = so.ToString(("" + table.Rows[0]["SO"]).Replace('x', '0'));
                        string result = ("" + table.Rows[0]["FORMAT"]).Replace("" + table.Rows[0]["NAM"], "" + table.Rows[0]["NamValue"]).Replace("" + table.Rows[0]["SO"], chuoi);
                        int row = _acc.Execute_Data_Return("update " + _acc.Get_User() + ".MASO_DANHMUC set DANGGHI = " + so + " where Ma ='SVV'");
                        return result;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message,MessageIcon.Error,"Lỗi");
                return "";
            }
        }
        public static DataTable GetDanhMucBenhAnNoiTruTheoMa(string maKP)
        {
            string sql = string.Empty;
            try
            {
                //sql = "select maba from " + _acc.Get_User() + ".btdkp_bv where makp='" + maKP + "'";
                //string listMa = string.Empty;
                //DataTable tempTable = _acc.Get_Data(sql);
                //if (tempTable != null)
                //{
                //    if (tempTable.Rows.Count > 0)
                //    {
                //        listMa = "" + tempTable.Rows[0][0];
                //        sql = "select * from " + _acc.Get_User() + ".dmbenhan_bv where loaiba=1 and maba in (" + listMa + ")" + " order by maba";
                //        return _acc.Get_Data(sql);
                //    }
                //}
                return GetDanhMucBenhAnNoiTruAll();
            }
            catch
            {
                return GetDanhMucBenhAnNoiTruAll();
            }
        }
        public static DataTable GetDanhMucBenhAnNoiTruXK()
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btdkp_bv where makp<>'01' order by makp";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message,MessageIcon.Error);
                return null;
            }
        }
        public static DataTable GetDanhMucBenhAnNoiTruAll()
        {
            string sql = string.Empty;
            try
            {
                sql = "select * from " + _acc.Get_User() + ".dmbenhan_bv where loaiba=1 order by maba";
                string listMa = string.Empty;
                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        public static DataTable GetDanhSachBenhNhanChoTheoKP(string s_makp, int soNgay, string query)
        {
            try
            {
                string stime = "'" + _libMediAccessData.f_ngay + "'";
                string ngay = _libMediAccessData.ngayhienhanh_server.Substring(0, 10);
                string sql = "select HienDien.mabn as msbn,HC_SOSINH.PARA,HC_SOSINH.NHOMMAU,HC_SOSINH.MAME,HC_SOSINH.DELAN, BTD_BenhNhan.*,to_char(HienDien.ngay,'dd/mm/yyyy') as ngayvv, HienDien.* " +
                    " from " + _acc.Get_User() + ".hiendien HienDien, " + _acc.Get_User() + ".btdbn BTD_BenhNhan LEFT OUTER JOIN HISBVNHITP.HCSOSINH HC_SOSINH ON BTD_BenhNhan.MABN = HC_SOSINH.MABN where HienDien.mabn=BTD_BenhNhan.mabn and HienDien.nhapkhoa=0 and HienDien.xuatkhoa=0";
                if(!string.IsNullOrEmpty(s_makp))sql += " and HienDien.makp='" + s_makp + "'";
                sql += " and " + _libMediAccessData.for_ngay("HienDien.ngay", stime) + " between to_date('" + ngay + "'," + stime + ")-" + soNgay + " and to_date('" + ngay + "'," + stime + ")+" + soNgay;
                if(!string.IsNullOrEmpty(query))
                {
                    if(query.IndexOf("%")> -1)
                    sql += " and ((HienDien.mabn like '" + query + "') or (BTD_BenhNhan.hoten like '" + query + "'))";
                    else
                        sql += " and ((HienDien.mabn = '" + query + "') or (BTD_BenhNhan.hoten = '" + query + "'))";
                }

                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachBenhNhanChoNhapVien(int maba,int soNgay,DateTime day, string query)
        {
            try
            {
                string stime = "'" + _libMediAccessData.f_ngay + "'";
                string sql = "SELECT '' as sothe, BenhAnDT.mabn AS msbn,HC_SOSINH.PARA,HC_SOSINH.NHOMMAU,HC_SOSINH.MAME,HC_SOSINH.DELAN,BTD_BenhNhan.*,TO_CHAR(BenhAnDT.ngay, 'dd/mm/yyyy') AS ngayvv,BenhAnDT.*" +
                    " from " + _acc.Get_User() + ".benhandt BenhAnDT," + _acc.Get_User() + ".btdbn BTD_BenhNhan LEFT OUTER JOIN "+ _acc.Get_User() + ".HCSOSINH HC_SOSINH ON BTD_BenhNhan.MABN = HC_SOSINH.MABN where (ROWNUM < "+ soNgay + ") AND (BenhAnDT.SOVAOVIEN is null) AND BenhAnDT.mabn=BTD_BenhNhan.mabn ";

                if (day != null)
                {
                    if (day != DateTime.MinValue)
                    {
                        string ngay = day.Date.ToString("dd/MM/yyyy");
                        sql += " and (to_char(BenhAnDT.ngay, 'mmyyyy') = " + day.Month.ToString().PadLeft(2,'0') + day.Year + ")";
                    }
                }
                if(maba > 0)
                {
                    sql += " and (BenhAnDT.MABA =" + maba + ")";
                }

                //sql += " and " + _libMediAccessData.for_ngay("BenhAnDT.ngay", stime) + " between to_date('" + ngay + "'," + stime + ")-" + soNgay + " and to_date('" + ngay + "'," + stime + ")+" + soNgay;
                if (!string.IsNullOrEmpty(query))
                {
                    //sql += " and ((BenhAnDT.mabn like '" + query + "') or (BTD_BenhNhan.hoten like '" + query + "'))";
                    if (query.IndexOf("%") > -1)
                        sql += " and ((UPPER(BenhAnDT.mabn) like '" + query.ToUpper() + "') or (UPPER(BTD_BenhNhan.hoten) like '" + query.ToUpper() + "'))";
                    else
                        sql += " and ((UPPER(BenhAnDT.mabn) like '%" + query.ToUpper() + "%') or (UPPER(BTD_BenhNhan.hoten) like '%" + query.ToUpper() + "%'))";
                }
                sql += " order BY BenhAnDT.ngay DESC";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachBNChoNhapVien(int soNgay,DateTime tungay, DateTime denngay, string query)
        {
            try
            {
                string stime = "'" + _libMediAccessData.f_ngay + "'";
                string sql = "SELECT '' as sothe, BenhAnDT.mabn AS msbn,HC_SOSINH.PARA,HC_SOSINH.NHOMMAU,HC_SOSINH.MAME,HC_SOSINH.DELAN,BTD_BenhNhan.*,TO_CHAR(BenhAnDT.ngay, 'dd/mm/yyyy') AS ngayvv,BenhAnDT.*" +
                    " from " + _acc.Get_User() + ".benhandt BenhAnDT," + _acc.Get_User() + ".btdbn BTD_BenhNhan LEFT OUTER JOIN " + _acc.Get_User() + ".HCSOSINH HC_SOSINH ON BTD_BenhNhan.MABN = HC_SOSINH.MABN where (ROWNUM < " + soNgay + ") AND (BenhAnDT.SOVAOVIEN is null) AND BenhAnDT.mabn=BTD_BenhNhan.mabn ";
                //sql += " and " + _libMediAccessData.for_ngay("BenhAnDT.ngay", stime) + " between to_date('" + ngay + "'," + stime + ")-" + soNgay + " and to_date('" + ngay + "'," + stime + ")+" + soNgay;
                if (denngay != DateTime.MinValue)
                {
                    sql += " and (BenhAnDT.ngay > to_date('" + tungay.Date.ToString("MM/dd/yyyy") + "','mm/dd/yyyy')) and (BenhAnDT.ngay < to_date('" + denngay.ToString("MM/dd/yyyy") + "','mm/dd/yyyy'))";
                    
                }

                if (!string.IsNullOrEmpty(query))
                {
                    //sql += " and ((BenhAnDT.mabn like '" + query + "') or (BTD_BenhNhan.hoten like '" + query + "'))";
                    if (query.IndexOf("%") > -1)
                        sql += " and ((UPPER(BenhAnDT.mabn) like '" + query.ToUpper() + "') or (UPPER(BTD_BenhNhan.hoten) like '" + query.ToUpper() + "'))";
                    else
                        sql += " and ((UPPER(BenhAnDT.mabn) like '%" + query.ToUpper() + "%') or (UPPER(BTD_BenhNhan.hoten) like '%" + query.ToUpper() + "%'))";
                }
                sql += " order BY BenhAnDT.ngay DESC";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachBenhNhanChoNhapKhoa(string maKP, int soNgay, DateTime day, string query)
        {
            try
            {
                string stime = "'" + _libMediAccessData.f_ngay + "'";
                string sql = "SELECT Hien_Dien.makp,  BTD_BenhNhan.mabn AS msbn,HC_SOSINH.PARA,HC_SOSINH.NHOMMAU,HC_SOSINH.MAME,HC_SOSINH.DELAN,TO_CHAR(Hien_Dien.ngay, 'dd/mm/yyyy') AS ngayvv, "
                                +" BTD_BenhNhan.*,BenhAnDT.* FROM "+ _acc.Get_User() + ".HCSOSINH HC_SOSINH RIGHT OUTER JOIN "+ _acc.Get_User() + ".BENHANDT BenhAnDT RIGHT OUTER JOIN "
                                +"" + _acc.Get_User() + ".BTDBN BTD_BenhNhan INNER JOIN "+ _acc.Get_User() + ".HIENDIEN Hien_Dien ON BTD_BenhNhan.MABN = Hien_Dien.MABN ON BenhAnDT.MAQL = Hien_Dien.MAQL ON HC_SOSINH.MABN = BTD_BenhNhan.MABN "
                                + " WHERE(ROWNUM < "+ soNgay + ") And(Hien_Dien.XUATKHOA = 0) AND(Hien_Dien.NHAPKHOA = 0) AND (NOT BenhAnDT.SOVAOVIEN is null)";

                if (day != null)
                {
                    if (day != DateTime.MinValue)
                    {
                        string ngay = day.Date.ToString("dd/MM/yyyy");
                        sql += " and (to_char(Hien_Dien.ngay, 'mmyyyy') = " + day.Month.ToString().PadLeft(2, '0') + day.Year + ")";
                    }
                }
                if (maKP.Length > 0)
                {
                    sql += " and (Hien_Dien.MAKP ='" + maKP + "')";
                }

                if (!string.IsNullOrEmpty(query))
                {
                    if (query.IndexOf("%") > -1)
                        sql += " and ((UPPER(BenhAnDT.mabn) like '" + query.ToUpper() + "') or (UPPER(BTD_BenhNhan.hoten) like '" + query.ToUpper() + "'))";
                    else
                        sql += " and ((UPPER(BenhAnDT.mabn) like '%" + query.ToUpper() + "%') or (UPPER(BTD_BenhNhan.hoten) like '%" + query.ToUpper() + "%'))";
                }
                sql += " ORDER BY Hien_Dien.NGAY DESC ";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachBenhNhanChoNhapKhoaFT(string maKP, int soNgay, DateTime fromDay, DateTime toDay, string query)
        {
            try
            {
                string stime = "'" + _libMediAccessData.f_ngay + "'";
                string sql = "SELECT Hien_Dien.makp,  BTD_BenhNhan.mabn AS msbn,HC_SOSINH.PARA,HC_SOSINH.NHOMMAU,HC_SOSINH.MAME,HC_SOSINH.DELAN,TO_CHAR(Hien_Dien.ngay, 'dd/mm/yyyy') AS ngayvv, "
                                + " BTD_BenhNhan.*,BenhAnDT.* FROM " + _acc.Get_User() + ".HCSOSINH HC_SOSINH RIGHT OUTER JOIN " + _acc.Get_User() + ".BENHANDT BenhAnDT RIGHT OUTER JOIN "
                                + "" + _acc.Get_User() + ".BTDBN BTD_BenhNhan INNER JOIN " + _acc.Get_User() + ".HIENDIEN Hien_Dien ON BTD_BenhNhan.MABN = Hien_Dien.MABN ON BenhAnDT.MAQL = Hien_Dien.MAQL ON HC_SOSINH.MABN = BTD_BenhNhan.MABN "
                                + " WHERE(ROWNUM < " + soNgay + ") And(Hien_Dien.XUATKHOA = 0) AND(Hien_Dien.NHAPKHOA = 0) AND (NOT BenhAnDT.SOVAOVIEN is null)";

                if (toDay != DateTime.MinValue && fromDay != DateTime.MinValue)
                {
                    sql += " and (Hien_Dien.ngay > to_date('" + fromDay.Date.ToString("MM/dd/yyyy") + "','mm/dd/yyyy')) and (Hien_Dien.ngay < to_date('" + toDay.ToString("MM/dd/yyyy") + "','mm/dd/yyyy'))";
                }
                if (maKP.Length > 0)
                {
                    sql += " and (Hien_Dien.MAKP ='" + maKP + "')";
                }

                if (!string.IsNullOrEmpty(query))
                {
                    if (query.IndexOf("%") > -1)
                        sql += " and ((UPPER(BenhAnDT.mabn) like '" + query.ToUpper() + "') or (UPPER(BTD_BenhNhan.hoten) like '" + query.ToUpper() + "'))";
                    else
                        sql += " and ((UPPER(BenhAnDT.mabn) like '%" + query.ToUpper() + "%') or (UPPER(BTD_BenhNhan.hoten) like '%" + query.ToUpper() + "%'))";
                }
                sql += " ORDER BY Hien_Dien.NGAY DESC ";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachBenhNhanChoXuatKhoa(string maKP, int soNgay, DateTime day, string query)
        {
            try
            {
                string stime = "'" + _libMediAccessData.f_ngay + "'";
                string sql = "SELECT Hien_Dien.makp,  BTD_BenhNhan.mabn AS msbn,HC_SOSINH.PARA,HC_SOSINH.NHOMMAU,HC_SOSINH.MAME,HC_SOSINH.DELAN,TO_CHAR(Hien_Dien.ngay, 'dd/mm/yyyy') AS ngayvv, "
                                + " BTD_BenhNhan.*,BenhAnDT.* FROM " + _acc.Get_User() + ".HCSOSINH HC_SOSINH RIGHT OUTER JOIN " + _acc.Get_User() + ".BENHANDT BenhAnDT RIGHT OUTER JOIN "
                                + "" + _acc.Get_User() + ".BTDBN BTD_BenhNhan INNER JOIN " + _acc.Get_User() + ".HIENDIEN Hien_Dien ON BTD_BenhNhan.MABN = Hien_Dien.MABN ON BenhAnDT.MAQL = Hien_Dien.MAQL ON HC_SOSINH.MABN = BTD_BenhNhan.MABN "
                                + " WHERE(ROWNUM < " + soNgay + ") And(Hien_Dien.XUATKHOA = 0) AND(Hien_Dien.NHAPKHOA = 1)";

                if (day != null)
                {
                    if (day != DateTime.MinValue)
                    {
                        string ngay = day.Date.ToString("dd/MM/yyyy");
                        sql += " and (to_char(Hien_Dien.ngay, 'mmyyyy') = " + day.Month.ToString().PadLeft(2, '0') + day.Year + ")";
                    }
                }
                if (maKP.Length > 0)
                {
                    sql += " and (Hien_Dien.MAKP ='" + maKP + "')";
                }

                if (!string.IsNullOrEmpty(query))
                {
                    if (query.IndexOf("%") > -1)
                        sql += " and ((UPPER(BenhAnDT.mabn) like '" + query.ToUpper() + "') or (UPPER(BTD_BenhNhan.hoten) like '" + query.ToUpper() + "'))";
                    else
                        sql += " and ((UPPER(BenhAnDT.mabn) like '%" + query.ToUpper() + "%') or (UPPER(BTD_BenhNhan.hoten) like '%" + query.ToUpper() + "%'))";
                }
                sql += " ORDER BY Hien_Dien.NGAY DESC ";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachBenhNhanChoXuatVien(string maKP, int soNgay, DateTime day, string query)
        {
            try
            {
                string stime = "'" + _libMediAccessData.f_ngay + "'";
                string sql = "SELECT Hien_Dien.makp,  BTD_BenhNhan.mabn AS msbn,HC_SOSINH.PARA,HC_SOSINH.NHOMMAU,HC_SOSINH.MAME,HC_SOSINH.DELAN,TO_CHAR(Hien_Dien.ngay, 'dd/mm/yyyy') AS ngayvv, "
                                + " BTD_BenhNhan.*,BenhAnDT.* FROM " + _acc.Get_User() + ".HCSOSINH HC_SOSINH RIGHT OUTER JOIN " + _acc.Get_User() + ".BENHANDT BenhAnDT RIGHT OUTER JOIN "
                                + "" + _acc.Get_User() + ".BTDBN BTD_BenhNhan INNER JOIN " + _acc.Get_User() + ".HIENDIEN Hien_Dien ON BTD_BenhNhan.MABN = Hien_Dien.MABN ON BenhAnDT.MAQL = Hien_Dien.MAQL ON HC_SOSINH.MABN = BTD_BenhNhan.MABN "
                                + " WHERE(ROWNUM < " + soNgay + ") And(Hien_Dien.XUATKHOA = 0) AND(Hien_Dien.NHAPKHOA = 1)";

                if (day != null)
                {
                    if (day != DateTime.MinValue)
                    {
                        string ngay = day.Date.ToString("dd/MM/yyyy");
                        sql += " and (to_char(Hien_Dien.ngay, 'mmyyyy') = " + day.Month.ToString().PadLeft(2, '0') + day.Year + ")";
                    }
                }
                if (maKP.Length > 0)
                {
                    sql += " and (Hien_Dien.MAKP ='" + maKP + "')";
                }

                if (!string.IsNullOrEmpty(query))
                {
                    if (query.IndexOf("%") > -1)
                        sql += " and ((UPPER(BenhAnDT.mabn) like '" + query.ToUpper() + "') or (UPPER(BTD_BenhNhan.hoten) like '" + query.ToUpper() + "'))";
                    else
                        sql += " and ((UPPER(BenhAnDT.mabn) like '%" + query.ToUpper() + "%') or (UPPER(BTD_BenhNhan.hoten) like '%" + query.ToUpper() + "%'))";
                }
                sql += " ORDER BY Hien_Dien.NGAY DESC ";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachDotPhatThuoc()
        {
            try
            {
                string sql = "select  MA,TEN,THOIGIAN, NHOM from " + _acc.Get_User() + ".DMDOTPHATTHUOT";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanToc()
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btddt order by madantoc";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetNgheNghiep()
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btdnn_bv order by mann";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetTinhTP()
        {
            try
            {
                string sql = "select* from " + _acc.Get_User() + ".btdtt order by matt";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetQuocTich()
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".dmquocgia order by ma";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetTQuanXa()
        {
            try
            {
                string sql = "select a.tentt||' - '||b.tenquan||' - '||c.tenpxa as TEN,c.MAPHUONGXA,c.VIETTAT from "+ _acc.Get_User()+ ".btdtt a,"+ _acc.Get_User() + ".btdquan b,"+ _acc.Get_User()+ ".btdpxa c where a.matt=b.matt and b.maqu=c.maqu order by c.maphuongxa";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetTPhuongXa()
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btdpxa order by maphuongxa";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetTPhuongXaTheoMaQuan(string MaQuan)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btdpxa where maqu = '"+ MaQuan + "' order by maphuongxa";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetQuanHuyen()
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btdquan order by maqu";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetQuanHuyenTheoMaTT(string maTT)
        {
            try
            {
                string sql = "select MAQU,MATT,TENQUAN,TENQUANKDAU from "+ _acc.Get_User() + ".btdquan where matt = '"+ maTT + "' order by maqu";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetNoiGioiThieu()
        {
            try
            {
                string sql = "select* from " + _acc.Get_User() + ".dentu order by ma";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetNhanBNTu()
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".nhantu order by ma";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetKhoaNhan()
        {
            try
            {
                string sql = "select MAKP,TENKP, LOAI from "+ _acc.Get_User() + ".BTDKP_BV where LOAI = 0";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachKhoa(string s_makp)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btdkp_bv where makp<>'01' and loai=0 ";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += "order by makp";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static string GetTenKhoa(string pMakp)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btdkp_bv where makp = '" + pMakp +"'";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return "" + table.Rows[0]["TenKP"];
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return "";
            }

        }
        public static DataTable GetDanhSachDoiTuong()
        {
            try
            {
                string sql = "select a.*, to_char(madoituong,'9999D') as madoituong1 from " + _acc.Get_User() + ".doituong a order by madoituong";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachNgheNghiep()
        {
            try
            {
                string sql = "select* from " + _acc.Get_User() + ".btdnn_bv where mannbo<>'01' order by mann";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachNhomMau()
        {
            try
            {
                string sql = "select* from " + _acc.Get_User() + ".dmnhommau";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachBenhVien()
        {
            try
            {
                string sql = "select MABV,TENBV,DIACHI from " + _acc.Get_User() + ".dstt where mabv<>'" + _libMediAccessData.Mabv + "'" + " order by mabv";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachChuanDoanBenh()
        {
            try
            {
                string sql = "select CICD10, NVL(VVIET, Vanh) VVIET from " + _acc.Get_User() + ".icd10 where Hide = 0";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachBacSy()
        {
            try
            {
                string sql = "select MA, HOTEN, MAKP, MAPK, NHOM, VIETTAT,MA ||' - '||HOTEN MATEN from " + _acc.Get_User() + ".dmbs";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static string GetTenBacSy(string pMaBS)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".dmbs where ma = '" + pMaBS +"'";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return "" + table.Rows[0]["hoten"];
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return "";
            }

        }
        public static DataTable GetDanhSachBVTBH()
        {
            try
            {
                string sql = "select mabv,tenbv from " + _acc.Get_User() + ".dmnoicapbhyt";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }

        public static string GetDTenBVTBH(string pMaBV)
        {
            try
            {
                if (pMaBV == null) return "";
                if (pMaBV.Length == 0) return "";
                string sql = "select mabv,tenbv from " + _acc.Get_User() + ".dmnoicapbhyt where mabv = '" +pMaBV + "'";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return "" + table.Rows[0]["tenbv"];
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return "";
            }

        }
        public static DataTable GetDanhSachLichSuKhamChuaBenh(string p_mabn)
        {
            try
            {
                string sql = "select maql,chandoan,mavaovien,lanthu,BenhAnDT.ngay NgayVVOrg,TO_CHAR(BenhAnDT.ngay, 'dd/mm/yyyy') AS ngayvv,TO_CHAR(BenhAnDT.ngayrv, 'dd/mm/yyyy') as NgayRV from " + _acc.Get_User() + ".benhandt where loaiba=1 and mabn = '" + p_mabn + "' order by ngay desc";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachLoaiTuyen()
        {
            try
            {
                string sql = "select ID,ten from " + _acc.Get_User() + ".dmtraituyen";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachCacLanVaoKhoa(string p_mabn)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".NHAPKHOA where mabn = '"+ p_mabn + "'";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static string GetDanhSachBenhKemTheo(string p_maQL)
        {
            try
            {
                string sql = "select maicd from " + _acc.Get_User() + ".cdkemtheo where loai = 1 and maql = " + p_maQL + " order by stt";
                DataTable table=  _acc.Get_Data(sql);
                if(table != null)
                {
                    if(table.Rows.Count > 0)
                    {
                        return ""+table.Rows[0][0];
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return "";
            }
        }
        public static DataTable GetDanhSachGiayCV()
        {
            try
            {
                string sql = "SELECT ID,TEN FROM "+ _acc.Get_User() + ".DMLOAIDT where HIDE = 1 ORDER BY STT";
                return _acc.Get_Data(sql);
               
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataRow GetDanhSachQuanHeYte(string p_maQL)
        {
            try
            {
                string sql = "select NoiGioiThieu.maicd,NoiGioiThieu.chandoan,NoiGioiThieu.mabv  as mabvGT,TMaQL.MaQL,BaoHiemYT.sothe,BaoHiemYT.tungay,BaoHiemYT.denngay,BaoHiemYT.mabv,BaoHiemYT.TRAITUYEN,BaoHiemYT.MIENCHITRA,BaoHiemYT.NGAYMIENCHITRA,BaoHiemYT.LOAIDT,QuanHe.* from (select column_value as MaQL  "
                             + "from table(sys.dbms_debug_vc2coll("+ p_maQL +"))) TMaQL "
                             +"LEFT OUTER JOIN "+ _acc.Get_User() + ".bhyt BaoHiemYT " 
                             +"ON BaoHiemYT.MAQL = TMaQL.MaQL LEFT OUTER JOIN "+ _acc.Get_User() + ".quanhe QuanHe  " 
                             + "ON QuanHe.MAQL = TMaQL.MaQL LEFT OUTER JOIN "+ _acc.Get_User() + ".noigioithieu NoiGioiThieu ON NoiGioiThieu.MAQL = TMaQL.MaQL ";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return  table.Rows[0];
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataRow GetThongTinKT_SoSinh(string p_maBN)
        {
            try
            {
                string sql = "select SoSinh.*, TTKThai.PARA  from (select column_value as MaBN "
                             + "from table(sys.dbms_debug_vc2coll("+p_maBN +"))) TMaBN "
                             + "LEFT OUTER JOIN "+ _acc.Get_User() + ".ddsosinh SoSinh "
                             + "ON SoSinh.MaBN = TMaBN.MaBN LEFT OUTER JOIN "+ _acc.Get_User() +".ttkhamthai TTKThai "
                             + "ON TTKThai.MaBN = TMaBN.MaBN ";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static string Get_Soluutru(string s_mabn)
        {
            string s_soluutru = "";
            string sql = " select a.mabn, b.maql, c.soluutru " +
                " from " + _acc.Get_User() + ".btdbn a, " + _acc.Get_User() + ".benhandt b, " + _acc.Get_User() + ".lienhe c where a.mabn=b.mabn and b.maql=c.maql and c.soluutru is not null" +
                " and a.mabn='" + s_mabn + "' order by b.maql desc ";
            DataTable table = _acc.Get_Data(sql);
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    return ""+table.Rows[0]["soluutru"];
                }
            }
            return s_soluutru;
        }
        public static bool CheckedExist_TheBH(string p_MaBVDKBH)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".dmnoicapbhyt where mabv='" + p_MaBVDKBH + "'";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    return table.Rows.Count > 0;
                    
                }
                return false;
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return false;
            }

        }
        public static DataRow GetThongTin_tiepdon(string m_ngay, string p_MaBN)
        {
            try
            {
                if (!_libMediAccessData.bMmyy(_libMediAccessData.mmyy(m_ngay))) return null;
            string xxx = _acc.Get_User() + _libMediAccessData.mmyy(m_ngay);
            string  sql = "select * from " + xxx + ".tiepdon where mabn='" + p_MaBN + "' and to_char(ngay,'dd/mm/yyyy')='" + m_ngay + "'";
            sql += " order by ngay desc";
            DataTable table = _acc.Get_Data(sql);
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    return table.Rows[0];
                }
            }
            return null;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static bool GetTrangThaiPhong(int mabenhan)
        {
            try
            {
              
                string sql = "select phong from " + _acc.Get_User() + ".dmbenhan_bv where maba=" + mabenhan + "";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return (""+table.Rows[0]["phong"]) == "1";
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return false;
            }

        }
        public static DataRow GetThongTin_XuatKhoa(long id, string makp)
        {
            try
            {
                string sql = @"SELECT BA_LUUTRU.MAQL MaBA_LUUTRU,BA_LUUTRU.SOCT, BA_LUUTRU.SOXQ, BA_LUUTRU.SOXN,BA_LUUTRU.SOKHAC,BA_LUUTRU.CHAMSOC,
                        BA_LUUTRU.MRI,BA_LUUTRU.SOSA,BA_LUUTRU.SODT,BA_LUUTRU.YLENH, HEN.MAQL MAQLHEN,HEN.SoNgay,HEN.Loai LoaiHenLai,HEN.GHICHU, CDKEM_THEO.MAICD MaBenhKemTheo, XUATKHOA.ID XUATKHOA_ID,Nhap_Khoa.ID Nhap_Khoa_ID, XUATKHOA.NGAY, XUATKHOA.KETQUA, XUATKHOA.TTLUCRK, XUATKHOA.CHANDOAN, XUATKHOA.MAICD, XUATKHOA.MABS, 
                         XUATKHOA.BIENCHUNG, XUATKHOA.TAIBIEN, XUATKHOA.GIAIPHAU, XUATKHOA.CSCHANDOAN, XUATKHOA.THUOC, XUATKHOA.MATRAI, 
                         XUATKHOA.TRAGIUONG, Nhap_Khoa.KHOACHUYEN, Nhap_Khoa.CHANDOAN CHANDOAN_NK, Nhap_Khoa.MAICD MAICD_NK, Nhap_Khoa.TRUCTIEP, Nhap_Khoa.LAN, Nhap_Khoa.GIUONG, 
                         Nhap_Khoa.TUOIVAO, Nhap_Khoa.NGAY Ngay_NK, Nhap_Khoa.MAQL, Nhap_Khoa.MAKP, CDNGUYENNHAN.MAICD MAICD_NguyenNhan, 
                         CDNGUYENNHAN.CHANDOAN CHANDOAN_NguyenNhan, CHUYENVIEN.LOAIBV, CHUYENVIEN.MABV
                         FROM            " + _acc.Get_User() +".NHAPKHOA  Nhap_Khoa LEFT OUTER JOIN " +
                         _acc.Get_User()+".CHUYENVIEN ON Nhap_Khoa.MAQL = CHUYENVIEN.MAQL LEFT OUTER JOIN " +
                         _acc.Get_User()+".CDNGUYENNHAN ON Nhap_Khoa.ID = CDNGUYENNHAN.ID LEFT OUTER JOIN " +
                         _acc.Get_User()+".XUATKHOA ON Nhap_Khoa.ID = XUATKHOA.ID LEFT OUTER JOIN (SELECT ID, LOAI, CHANDOAN, MAICD FROM "+
                         _acc.Get_User() + ".CDKEMTHEO WHERE        (LOAI = 3))  CDKEM_THEO ON Nhap_Khoa.ID = CDKEM_THEO.ID LEFT OUTER JOIN" +
                         _acc.Get_User() + ".HEN ON Nhap_Khoa.MAQL = HEN.MAQL LEFT OUTER JOIN" +
                         _acc.Get_User() + ".BA_LUUTRU ON Nhap_Khoa.MAQL = BA_LUUTRU.MAQL " +
                         "WHERE        (Nhap_Khoa.MAQL = " + id + ") AND (Nhap_Khoa.MAKP = '" + makp + "')";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static DataTable GetDanhSachKPTheoBAKP(string makp, string maba)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".btdkp_bv where makp<>'01' and maba like '%" + maba.PadLeft(2, '0') + "%'";
                if (makp != "")
                {
                    string s = makp.Replace(",", "','");
                    sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += " order by makp";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataTable GetDanhSachKetQuaDieuTri()
        {
            try
            {
                string sql = "SELECT MA, TEN, MABH FROM "+ _acc.Get_User() +".KETQUA ORDER BY MA";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachTaiBien()
        {
            try
            {
                string sql = "SELECT MA, TEN FROM " + _acc.Get_User() + ".taibien ORDER BY MA";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachGiaiPhau()
        {
            try
            {
                string sql = "SELECT MA, TEN FROM " + _acc.Get_User() + ".gphaubenh ORDER BY MA";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachTrangThaiRaVien()
        {
            try
            {
                string sql = "SELECT MA, TEN FROM " + _acc.Get_User() + ".ttxk ORDER BY MA";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataTable GetDanhSachLoaiBenhVien()
        {
            try
            {
                string sql = "SELECT MA, TEN FROM " + _acc.Get_User() + ".loaibv ORDER BY MA";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
        }
        public static DataRow GetThongTin_BenhNhan(string p_MaBN)
        {
            try
            {
                string sql = @"SELECT        BTDBN.MABN, BTDBN.HOTEN, BTDBN.NGAYSINH, BTDBN.NAMSINH, BTDBN.PHAI, BTDBN.MANN, BTDBN.MADANTOC, 
                         BTDBN.SONHA, BTDBN.THON, BTDBN.CHOLAM, BTDBN.MATT, BTDBN.MAQU, BTDBN.MAPHUONGXA, BTDBN.HOTENKDAU, 
                         BTDBN.NAM, BTDBN.TUVONG, BTDBN.USERID, BTDBN.NGAYUD, BTDBN.SOBENHAN, BTDBN.SOCMND, BTDBN.MANV, 
                         BTDBN.DOCTHAN, BTDBN.MANNSK, BTDBN.MATO, BTDBN.DONVI, BTDBN.MACHINEID, BTDBN.SOTHE, 
                         BTDBN.CHUYENTRUNGGIAN, BTDBN.HOTENCHA, BTDBN.NSCHA, BTDBN.HOTENME, BTDBN.NSME, BTDBN.TINHCACH, 
                         BTDBN.GHICHU, BTDBN.VANHOA_BO, BTDBN.VANHOA_ME, BTDBN.MANN_BO, BTDBN.MANN_ME, BTDBN.DIENTHOAICHA, 
                         BTDBN.DIENTHOAIME, BTDBN.CMNDCHA, BTDBN.CMNDME, BTDBN.ROWID, HCSOSINH.MAME, HCSOSINH.PARA, 
                         HCSOSINH.NHOMMAU, HCSOSINH.NS_BO, HCSOSINH.HOTEN_BO, HCSOSINH.DELAN, HCSOSINH.NS_ME, HCSOSINH.HOTEN_ME
                         FROM " + _acc.Get_User() + ".BTDBN LEFT OUTER JOIN " + _acc.Get_User() +".HCSOSINH ON BTDBN.MABN = HCSOSINH.MABN WHERE(BTDBN.MABN = '"+ p_MaBN + "')";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static DataRow GetThongTin_VaoVien(string p_MaQL)
        {
            try
            {
                string sql = @"SELECT      TMaQL.MAVT,  TMaQL.MABN, TMaQL.MAVAOVIEN, TMaQL.MAQL, TMaQL.MAKP, TMaQL.NGAY, TMaQL.DENTU, TMaQL.NHANTU, TMaQL.LANTHU, TMaQL.MADOITUONG, TMaQL.CHANDOAN, TMaQL.MAICD, TMaQL.MABS, TMaQL.SOVAOVIEN, 
                         TMaQL.LOAIBA, TMaQL.USERID, TMaQL.NGAYUD, TMaQL.CSCHANDOAN, TMaQL.NGAYRV, TMaQL.SONGAY, TMaQL.DONGIA, TMaQL.KHU, TMaQL.MABA, TMaQL.MAKPS, TMaQL.MACHINEID, TMaQL.KIEMTRA, 
                         TMaQL.TINHCACH, NoiGioiThieu.MAICD  MAICD_NoiGT, NoiGioiThieu.CHANDOAN  CHANDOAN_NoiGT, NoiGioiThieu.MABV  mabvGT, BaoHiemYT.SOTHE, BaoHiemYT.TUNGAY, BaoHiemYT.DENNGAY, BaoHiemYT.MABV, 
                         BaoHiemYT.TRAITUYEN, BaoHiemYT.MIENCHITRA, BaoHiemYT.NGAYMIENCHITRA, BaoHiemYT.LOAIDT, QuanHe.QUANHE, QuanHe.HOTEN, QuanHe.DIACHI, QuanHe.DIENTHOAI, QuanHe.PHUONGTIEN, 
                         QuanHe.NGAYUD  Expr3, QuanHe.MACHINEID  Expr4, QuanHe.SOCMND, CDKEM_THEO.MAICD  MAICD_KemTheo, CDKEM_THEO.CHANDOAN  CHANDOAN_KemTheo, TTKHAMTHAI.PARA, 
                         DDSOSINH.APGAR1, DDSOSINH.APGAR5, DDSOSINH.APGAR10, DDSOSINH.CANNANG, DDSOSINH.CAO, DDSOSINH.VONGDAU
                         FROM            " + _acc.Get_UserMMYY() +".BHYT  BaoHiemYT RIGHT OUTER JOIN "+
                         " (SELECT      DMbenhan_bv.MAVT,  MABN, MAVAOVIEN, MAQL, MAKP, NGAY, DENTU, NHANTU, LANTHU, MADOITUONG, CHANDOAN, MAICD, MABS, SOVAOVIEN, LOAIBA, USERID, NGAYUD, CSCHANDOAN, NGAYRV, SONGAY, DONGIA, KHU, MABA, " +
                         " MAKPS, MACHINEID, KIEMTRA, TINHCACH " +
                         " FROM            " + _acc.Get_User() + ".BENHANDT " +
                         " LEFT OUTER JOIN (select MaBA MaBA1 ,MaVT from " + _acc.Get_User() + ".dmbenhan_bv) DMbenhan_bv on BENHANDT.MABA = DMbenhan_bv.MaBA1 " +
                         " WHERE        (MAQL = '" + p_MaQL +"'))  TMaQL LEFT OUTER JOIN " +
                         _acc.Get_User() +".TTKHAMTHAI ON TMaQL.MAQL = "+ _acc.Get_User() + ".TTKHAMTHAI.MAQL LEFT OUTER JOIN " +
                         _acc.Get_User() +".DDSOSINH ON TMaQL.MAQL = "+ _acc.Get_User() + ".DDSOSINH.MAQL LEFT OUTER JOIN " +
                         " (SELECT        LOAI, MAICD, STT, CHANDOAN, MAQL " +
                         " FROM            " + _acc.Get_User() + ".CDKEMTHEO " +
                         " WHERE        (LOAI = 1))  CDKEM_THEO ON TMaQL.MAQL = CDKEM_THEO.MAQL ON BaoHiemYT.MAQL = TMaQL.MAQL LEFT OUTER JOIN " +
                         _acc.Get_User() + ".QUANHE  QuanHe ON TMaQL.MAQL = QuanHe.MAQL LEFT OUTER JOIN " +
                         _acc.Get_User() +".NOIGIOITHIEU  NoiGioiThieu ON TMaQL.MAQL = NoiGioiThieu.MAQL";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static DataRow Get_BenhNhanTheoMa(string p_MaBN)
        {
            try
            {
                string sql = @"SELECT MAQL,MABN, SOVAOVIEN FROM " + _acc.Get_User() +".BENHANDT where mabn = '"+ p_MaBN + "'";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static DataRow Get_BTDBenhNhanTheoMa(string p_MaBN)
        {
            try
            {
                string sql = @"SELECT * FROM " + _acc.Get_User() + ".btdbn where mabn = '" + p_MaBN + "'";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static DataRow CheckNhapVien(string p_MaBN)
        {
            try
            {
                string sql = @"SELECT MAQL,MABN, SOVAOVIEN FROM " + _acc.Get_User() + ".BENHANDT where mabn = '" + p_MaBN + "' and not sovaovien is null";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static DataRow Get_BenhNhanNKTheoMa(string p_MaBN)
        {
            try
            {
                string sql = @"SELECT MAQL,MABN FROM " + _acc.Get_User() + ".hiendien where mabn = '" + p_MaBN + "'"; //+ "' and xuatkhoa =0 and nhapkhoa = 0";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static DataRow Get_BenhNhanNK(string p_MaBN)
        {
            try
            {
                string sql = @"SELECT       to_char(ngayvv,'dd/mm/yyyy hh:mm') NgayVV, HIENDIEN.ID, HIENDIEN.MABN, HIENDIEN.MAVAOVIEN, HIENDIEN.MAQL, HIENDIEN.MAKP, HIENDIEN.NGAYVV, HIENDIEN.NGAY, 
                         BTDKP_BV.TENKP
                        FROM            "+ _acc.Get_User() +".HIENDIEN INNER JOIN "+
                                             _acc.Get_User() + ".BTDKP_BV ON HIENDIEN.MAKP = BTDKP_BV.MAKP "+
                        "WHERE        (HIENDIEN.MABN = '" + p_MaBN + "') AND (HIENDIEN.XUATKHOA = 0) AND (HIENDIEN.NHAPKHOA = 1)";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Lỗi : ");
                return null;
            }

        }
        public static DataTable Get_DanhSachBenhNhanXuatVien()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = _acc.Get_Data(string.Format("select b.mabn,b.HOTEN,a.NGAY from {0}.xuatvien a inner join {0}.BTDBN b on a.mabn = b.MABN", _acc.Get_User()));
            }
            catch (Exception)
            {
            }
            return dt;

        }
        public static string Get_ThongTinTheBeoHiem(string sobh,string p_MaBN,bool pDenngay_sothe, string pNgayVV, string pUnitnity)
        {
            try
            {
                string sql = "";
                    if (sobh.Substring(2, 1) == "1" && pDenngay_sothe)
                    sql = "select sothe,tungay,denngay,ngay1,ngay2,ngay3,mabv,traituyen,mienchitra,ngaymienchitra from "+ _acc.Get_User() +".bhyt where mabn='" + p_MaBN + "' and denngay>=to_date('" + pNgayVV + "','" + pUnitnity + "') order by maql desc";
                else
                    sql = "select sothe,tungay,denngay,ngay1,ngay2,ngay3,mabv,traituyen,mienchitra,ngaymienchitra from " + _acc.Get_User() + ".bhyt where mabn='" + p_MaBN + "' order by maql desc";
               
                return sql;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return "";
            }

        }
        public static DataRow SetNhapKhoa(string pMaQuanLy, string pKhoaNhap,string pNgaygioVK)
        {
            try
            {
                string sql = @"select id from " + _acc.Get_User() + ".nhapkhoa where maql=" + pMaQuanLy + " and makp='" + pKhoaNhap + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + pNgaygioVK + "'";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return null;
            }
        }
        public static DataTable Get_DanhSachDMGiuong()
        {
            try
            {
                string sql = "select a.*,b.chenhlech,c.dichvu from " + _acc.Get_User() + ".dmgiuong a," + _acc.Get_User() + ".v_giavp b," + _acc.Get_User() + ".dmphong c where a.id=b.id and a.idphong=c.id";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }
            
        }
        public static DataTable Get_DoiTuongNK()
        {
            try
            {
                string sql = "select a.*,to_char(madoituong,'9999D') as madoituong1 from " + _acc.Get_User() + ".doituong a";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        public static DataRow Get_ThongTinNhapKhoa(string maql)
        {
            try
            {
                string sql = @"SELECT        NHAPKHOA.ID, NHAPKHOA.MABN, NHAPKHOA.MAQL, NHAPKHOA.MAKP, NHAPKHOA.MABA, NHAPKHOA.NGAY, NHAPKHOA.TUOIVAO, 
                         NHAPKHOA.GIUONG, NHAPKHOA.KHOACHUYEN, NHAPKHOA.CHANDOAN, NHAPKHOA.MAICD, NHAPKHOA.MABS, NHAPKHOA.LAN, 
                         NHAPKHOA.TRUCTIEP, NHAPKHOA.CSCHANDOAN, NHAPKHOA.MAKPS, CD_KEMTHEO.MAICD  MAICD_KT, CD_KEMTHEO.CHANDOAN AS CHANDOAN_KT
                            FROM           "+ _acc.Get_User() +".NHAPKHOA LEFT OUTER JOIN "
                            + _acc.Get_User() + ".CDKEMTHEO CD_KEMTHEO ON NHAPKHOA.MAQL = CD_KEMTHEO.MAQL " +
                            "WHERE(NHAPKHOA.MAQL = '"+ maql + "')";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        return table.Rows[0];
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                //TA_MessageBox.MessageBox.Show("Lỗi : ");
                return null;
            }
            

        }
        public static string Get_MaBATheoMaVT(string pMaVT)
        {
            string sql = " select MaBA ,MaVT from " + _acc.Get_User() + ".dmbenhan_bv where mavt = '"+ pMaVT +"'";
            DataTable table = _acc.Get_Data(sql);
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    return "" + table.Rows[0]["MaBA"];
                }
            }
            return "";
        }

        #endregion

        #region Set Data
        public static bool upd_hiendien(long m_id, string m_mabn, long m_mavaovien, long m_maql, string m_makp, string m_ngayvv, string m_ngay, string m_giuong, string m_mabs, string m_maicd, string m_noichuyen)
        {
            try
            {
                string sql = "update " + _acc.Get_User() + ".hiendien set makp='" + m_makp + "',ngay=TO_DATE('" + Helper.ConvertSToDtimeFDDMMYYYY(m_ngayvv).ToString(Formats.FormatSHDateTime) + "','YYYY/MM/DD HH24:MI:SS' ),giuong='" + m_giuong
               + "',mabs='" + m_mabs + "',maicd='" + m_maicd + "',noichuyen='" + m_noichuyen + "' where id=" + m_id;

                int num = _acc.Execute_Data_Return(sql);

                if (num == 0)
                {
                    sql = "insert into " + _acc.Get_User() + ".hiendien(id,mabn,mavaovien,maql,makp,ngayvv,ngay,giuong,mabs,maicd,noichuyen,nhapkhoa,xuatkhoa) values " +
                        "(" + m_id + "," + m_mabn + "," + m_mavaovien + "," + m_maql + ",'" + m_makp + "',TO_DATE('" + Helper.ConvertSToDtimeFDDMMYYYY(m_ngayvv).ToString(Formats.FormatSHDateTime) + "','YYYY/MM/DD HH24:MI:SS' ),TO_DATE('" + Helper.ConvertSToDtimeFDDMMYYYY(m_ngay).ToString(Formats.FormatSHDateTime) + "','YYYY/MM/DD HH24:MI:SS' )," +
                        " '" + m_giuong + "','" + m_mabs + "','" + m_maicd + "','" + m_noichuyen + "',0,0)";
                    num = _acc.Execute_Data_Return(sql);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
           
            return false;
        }

        public static bool UpdateBaoHiemYT(clsBUS phuongthuc, long pMaQuanLy,string pMaBenhNhan,string pMaTheBH,string pNgayHetHanTheBH,string pNgaySuDungTheBH, string pMaBVDKKBaoHiem, bool pMienChiTra, string pNgayMienChiTra,string pLoaiDT)
        {
            Dictionary<string, string> eQual = new Dictionary<string, string>();
            DateTime date = E00_Helpers.Helpers.Helper.ConvertSToDtimeFDDMMYYYY(pNgayHetHanTheBH);
            if(date == DateTime.MinValue)
            {
                pNgayHetHanTheBH = "";
            }else
            {
                pNgayHetHanTheBH = date.ToString(E00_Helpers.Format.Formats.FDateYYMMDD);
            }

            date = E00_Helpers.Helpers.Helper.ConvertSToDtimeFDDMMYYYY(pNgaySuDungTheBH);
            if (date == DateTime.MinValue)
            {
                pNgaySuDungTheBH = "";
            }
            else
            {
                pNgaySuDungTheBH = date.ToString(E00_Helpers.Format.Formats.FDateYYMMDD);
            }
            date = E00_Helpers.Helpers.Helper.ConvertSToDtimeFDDMMYYYY(pNgayMienChiTra);
            if (date == DateTime.MinValue)
            {
                pNgayMienChiTra = "";
            }
            else
            {
                pNgayMienChiTra = date.ToString(E00_Helpers.Format.Formats.FDateYYMMDD);
            }

            DataTable bhyt = new DataTable();
            eQual.Clear();
            eQual.Add(cls_BaoHiemYTe.col_MaBN.ToUpper(), pMaBenhNhan);
            bhyt = _api.Search(ref _userError, ref _systemError, cls_BaoHiemYTe.tb_TenBang,schema: _acc.Get_UserMMYY(), dicEqual: eQual);
            if (bhyt != null && bhyt.Rows.Count > 0)
            {
                string michitra = pMienChiTra == true ? "1" : "0";
                string sql = "update " + _acc.Get_UserMMYY() + "." + cls_BHYT.tb_TenBang +
                       " set " + cls_BHYT.col_SoThe + "='" + pMaTheBH + "'," + cls_BHYT.col_DenNgay + "=to_date('" + pNgayHetHanTheBH + "','" + E00_Helpers.Format.Formats.FDateyymmdd + "')" +
                       "," + cls_BHYT.col_MaBV + "='" + pMaBVDKKBaoHiem + "'," + cls_BHYT.col_TuNgay + "= to_date('" + pNgaySuDungTheBH + "','" + E00_Helpers.Format.Formats.FDateyymmdd + "')" +
                       ", " + cls_BHYT.col_MienChiTra + "= '" + michitra + "'" +
                       ", " + cls_BHYT.col_NgayMienChiTra + "= to_date('" + pNgayMienChiTra + "','" + E00_Helpers.Format.Formats.FDateyymmdd + "')" +
                       ", " + cls_BHYT.col_LoaiDT + "= '" + pLoaiDT + "'" +
                       " where " + cls_BHYT.col_MaBn + "='" + pMaBenhNhan + "'";
                return _acc.Execute_Data(ref _userError, ref _systemError, sql, null);
            }
            else
            {
                try
                {
                    DataTable _dataTable = new DataTable();
                    _dataTable.Columns.Add(cls_BHYT.col_MaBn);
                    _dataTable.Columns.Add(cls_BHYT.col_MaQL);
                    _dataTable.Columns.Add(cls_BHYT.col_SoThe);
                    _dataTable.Columns.Add(cls_BHYT.col_DenNgay);
                    _dataTable.Columns.Add(cls_BHYT.col_MaBV);
                    _dataTable.Columns.Add(cls_BHYT.col_TuNgay);

                    DataRow row = _dataTable.NewRow();
                    row[cls_BHYT.col_MaBn] = pMaBenhNhan;
                    row[cls_BHYT.col_MaQL] = pMaQuanLy;
                    row[cls_BHYT.col_SoThe] = pMaTheBH;
                    row[cls_BHYT.col_DenNgay] = pNgayHetHanTheBH;
                    row[cls_BHYT.col_MaBV] = pMaBVDKKBaoHiem;
                    row[cls_BHYT.col_TuNgay] = pNgaySuDungTheBH;
                    string userError = "", systemError = "";
                    string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4}, {5},{6}) VALUES (:{1}, :{2}, :{3}, to_timestamp(:{4},'yyyy-mm-dd'), :{5}, to_timestamp(:{6},'yyyy-mm-dd'))",

                                                       _acc.Get_UserMMYY() + "." + cls_BHYT.tb_TenBang
                                                       , cls_BHYT.col_MaBn
                                                       , cls_BHYT.col_MaQL
                                                       , cls_BHYT.col_SoThe
                                                       , cls_BHYT.col_DenNgay
                                                       , cls_BHYT.col_MaBV
                                                       , cls_BHYT.col_TuNgay
                                                        );
                    if (_acc.Execute_Data(ref userError, ref systemError, sql,E00_Helpers.Helpers.Helper.Set_OracleParameter(row)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

            }



        }
        public static bool UpdateTrangThaiGiuong(string id)
        {
            try
            {
                if (id != "")
                {
                    string sql = "update " + _acc.Get_User() + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + id;
                    return _acc.Execute_Data(ref _userError, ref _systemError, sql, null);
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
            


        }

        public static bool Update_nhapkhoa(long m_id, string m_mabn, long m_mavaovien, long m_maql, string m_makp, int m_maba, string m_ngayvv, string m_ngay, string m_tuoivao, string m_giuong, string m_khoachuyen, string m_chandoan, string m_maicd, string m_mabs, int m_lan, int m_userid, long idgiuong)
        {
            try
            {
               
                string sql = "update " + _acc.Get_User() + ".nhapkhoa set makp='" + m_makp
              + "',maba=" + m_maba + ",ngay=TO_DATE('" + Helper.ConvertSToDtimeFDDMMYYYYHHMM(m_ngayvv).ToString(Formats.FormatSHDateTime) + "','YYYY/MM/DD HH24:MI:SS' ),tuoivao='" + m_tuoivao
              + "' ,giuong='" + m_giuong + "',khoachuyen='" + m_khoachuyen + "',chandoan=N'" + m_chandoan + "',maicd='" + m_maicd + "',mabs='" + m_mabs + "',lan=" + m_lan + " where id=" + m_id;

                int num = _acc.Execute_Data_Return(sql);

                if (num == 0)
                {
                    sql = "insert into " + _acc.Get_User() + ".nhapkhoa(id,mabn,maql,makp,maba,ngay,tuoivao,giuong,khoachuyen,chandoan,maicd,mabs,lan,userid,ngayud)";
                    sql += " values (" + m_id + "," + m_mabn + "," + m_maql + ",'" + m_makp + "'," + m_maba + ",TO_DATE('" + Helper.ConvertSToDtimeFDDMMYYYYHHMM(m_ngayvv).ToString(Formats.FormatSHDateTime) + "','YYYY/MM/DD HH24:MI:SS' ),'"
                    + m_tuoivao + "','" + m_giuong + "','" + m_khoachuyen + "', '" + m_chandoan + "','" + m_maicd + "','" + m_mabs + "','" + m_lan + "' ," + m_userid + ",sysdate)";
                    num = _acc.Execute_Data_Return(sql);
                }
                if (idgiuong != 0)
                    _acc.Execute_Data_Return("update " + _acc.Get_User() + ".hiendien set NHAPKHOA = 1, idgiuong=" + idgiuong + " ,MAKP = '" + m_makp + "' where maql=" + m_maql);
                else
                    _acc.Execute_Data_Return("update " + _acc.Get_User() + ".hiendien set NHAPKHOA = 1,MAKP = '"+ m_makp + "' where maql=" + m_maql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        #endregion

        #endregion

        //**-----------------------------------------------------------------
    }
}
