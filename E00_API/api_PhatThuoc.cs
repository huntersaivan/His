using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using E00_Common;
using E00_Helpers.Common.Class;
using E00_Helpers.Format;

namespace E00_API
{
   public class api_PhatThuoc
    {

        private static readonly Api_Common _api = new Api_Common();
        private static readonly Acc_Oracle _acc = new Acc_Oracle();
        private static string _userError = string.Empty;
        private static string _systemError = string.Empty;

        #region TimKiemBNCapThuoc => Tìm thông tin bệnh nhân 
        /// <summary>
        /// Tìm thông tin bệnh nhân 
        /// </summary>
        /// <author>TinNT</author>
        /// <date>09082018</date>
        public static DataTable TimKiemBNCapThuoc(TieuChiTimBNEnum tieuchi, int pTop, string pMakp, string pQuery)
        {
            string sql = @"SELECT       BTDBN.MABN, BTDBN.HOTEN, BTDBN.NGAYSINH, BTDBN.NAMSINH, BTDBN.PHAI, BTDBN.MANN, BTDBN.MADANTOC, BTDBN.SOCMND, 
                         BTDBN.SOTHE, HIENDIEN.MAVAOVIEN, HIENDIEN.MAQL, HIENDIEN.MAKP, HIENDIEN.NGAYVV, HIENDIEN.XUATKHOA, 
                         BTDBN.SONHA, BTDBN.THON, BTDTT.TENTT, BTDQUAN.MATT,BTDQUAN.TENQUAN,HIENDIEN.CHANDOAN,BTDKP_BV.TenKP,btdpxa.TENPXA 
                         FROM  " +
                         _acc.Get_User()+ ".HIENDIEN INNER JOIN "+
                         _acc.Get_User() + ".BTDBN ON HIENDIEN.MABN = BTDBN.MABN LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDKP_BV ON HIENDIEN.MAKP = BTDKP_BV.MAKP LEFT OUTER JOIN "+
                         _acc.Get_User() + ".BTDQUAN ON BTDBN.MAQU = BTDQUAN.MAQU LEFT OUTER JOIN " +
                         _acc.Get_User() + ".btdpxa ON BTDBN.MAPHUONGXA = btdpxa.MAPHUONGXA LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDTT ON BTDBN.MATT = BTDTT.MATT";

            switch (tieuchi)
            {
                case TieuChiTimBNEnum.Tatca:
                    sql += " Where (ROWNUM < " + pTop + ")";
                 //   sql += " and (HIENDIEN.ngayvv > to_date('" + PTungay.Date.ToString("MM/dd/yyyy") + "','mm/dd/yyyy')) and (HIENDIEN.ngayvv < to_date('" + pDenngay.ToString("MM/dd/yyyy") + "','mm/dd/yyyy'))";

                    break;
                case TieuChiTimBNEnum.ConThuoc:
                    sql += @"						 LEFT OUTER JOIN (SELECT        D_XUATSDLL.MABN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL, SUM(D_XUATSDCT_1.SOLUONG - nvl(D_DaPhat.Received, 0))  QtyRemain
                    FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDLL INNER JOIN
                                             " + _acc.Get_UserMMYY() + @".D_XUATSDCT  D_XUATSDCT_1 ON D_XUATSDLL.ID = D_XUATSDCT_1.ID LEFT OUTER JOIN
                                                 (SELECT        D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD, SUM(D_SUDUNGCT.SOLUONG)  Received
                                                   FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDCT INNER JOIN
                                                                             " + _acc.Get_UserMMYY() + @".D_SUDUNGCT ON D_XUATSDCT.ID = D_SUDUNGCT.XUATSDCTID AND D_XUATSDCT.STT = D_SUDUNGCT.STT AND 
                                                                             D_XUATSDCT.MABD = D_SUDUNGCT.MABD
                                                   GROUP BY D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD)  D_DaPhat ON D_XUATSDCT_1.STT = D_DaPhat.STT AND 
                                             D_XUATSDCT_1.MABD = D_DaPhat.MABD AND D_XUATSDCT_1.ID = D_DaPhat.ID
                    GROUP BY D_XUATSDLL.MABN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL) DS_SLTon
						 ON HIENDIEN.MAQL = DS_SLTon.MAQL";
                    sql += " Where (ROWNUM < " + pTop + ")";
                 //   sql += " and (HIENDIEN.ngayvv > to_date('" + PTungay.Date.ToString("MM/dd/yyyy") + "','mm/dd/yyyy')) and (HIENDIEN.ngayvv < to_date('" + pDenngay.ToString("MM/dd/yyyy") + "','mm/dd/yyyy'))";
                    sql += " and (DS_SLTon.QtyRemain > 0 )";
                    break;
                case TieuChiTimBNEnum.HetThuoc:
                    sql += @"						 LEFT OUTER JOIN (SELECT        D_XUATSDLL.MABN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL, SUM(D_XUATSDCT_1.SOLUONG - nvl(D_DaPhat.Received, 0))  QtyRemain
                    FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDLL INNER JOIN
                                             " + _acc.Get_UserMMYY() + @".D_XUATSDCT  D_XUATSDCT_1 ON D_XUATSDLL.ID = D_XUATSDCT_1.ID LEFT OUTER JOIN
                                                 (SELECT        D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD, SUM(D_SUDUNGCT.SOLUONG)  Received
                                                   FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDCT INNER JOIN
                                                                             " + _acc.Get_UserMMYY() + @".D_SUDUNGCT ON D_XUATSDCT.ID = D_SUDUNGCT.XUATSDCTID AND D_XUATSDCT.STT = D_SUDUNGCT.STT AND 
                                                                             D_XUATSDCT.MABD = D_SUDUNGCT.MABD
                                                   GROUP BY D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD)  D_DaPhat ON D_XUATSDCT_1.STT = D_DaPhat.STT AND 
                                             D_XUATSDCT_1.MABD = D_DaPhat.MABD AND D_XUATSDCT_1.ID = D_DaPhat.ID
                    GROUP BY D_XUATSDLL.MABN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL) DS_SLTon
						 ON HIENDIEN.MAQL = DS_SLTon.MAQL";
                    sql += " Where (ROWNUM < " + pTop + ")";
                  //  sql += " and (HIENDIEN.ngayvv > to_date('" + PTungay.Date.ToString("MM/dd/yyyy") + "','mm/dd/yyyy')) and (HIENDIEN.ngayvv < to_date('" + pDenngay.ToString("MM/dd/yyyy") + "','mm/dd/yyyy'))";
                    sql += " and (DS_SLTon.QtyRemain < 0.000000000001 )";
                    break;
                default:
                    break;

            }

            
            if (!string.IsNullOrEmpty(pMakp) && pMakp != "ALL")
            {
                sql += " And (HIENDIEN.MAKP = '" + pMakp + "')";
            }
            if (!string.IsNullOrEmpty(pQuery))
            {
                //sql += " and ((BenhAnDT.mabn like '" + query + "') or (BTD_BenhNhan.hoten like '" + query + "'))";
                if (pQuery.IndexOf("%") > -1)
                    sql += " and ((UPPER(BTDBN.mabn) like '" + pQuery.ToUpper() + "') or (UPPER(BTDBN.hoten) like '" + pQuery.ToUpper() + "'))";
                else
                    sql += " and ((UPPER(BTDBN.mabn) like '%" + pQuery.ToUpper() + "%') or (UPPER(BTDBN.hoten) like '%" + pQuery.ToUpper() + "%'))";
            }
            
            return _acc.Get_Data(sql);
        }

        public static DataRow TimKiemBNCapThuoc(string pMaBN)
        {
            string sql = @"SELECT       BTDBN.MABN, BTDBN.HOTEN, BTDBN.NGAYSINH, BTDBN.NAMSINH, BTDBN.PHAI, BTDBN.MANN, BTDBN.MADANTOC, BTDBN.SOCMND, 
                         BTDBN.SOTHE, HIENDIEN.MAVAOVIEN, HIENDIEN.MAQL, HIENDIEN.MAKP, HIENDIEN.NGAYVV, HIENDIEN.XUATKHOA, 
                         BTDBN.SONHA, BTDBN.THON, BTDTT.TENTT, BTDQUAN.MATT,BTDQUAN.TENQUAN,HIENDIEN.CHANDOAN,BTDKP_BV.TenKP,btdpxa.TENPXA 
                         FROM  " +
                         _acc.Get_User() + ".HIENDIEN INNER JOIN " +
                         _acc.Get_User() + ".BTDBN ON HIENDIEN.MABN = BTDBN.MABN LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDKP_BV ON HIENDIEN.MAKP = BTDKP_BV.MAKP LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDQUAN ON BTDBN.MAQU = BTDQUAN.MAQU LEFT OUTER JOIN " +
                         _acc.Get_User() + ".btdpxa ON BTDBN.MAPHUONGXA = btdpxa.MAPHUONGXA LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDTT ON BTDBN.MATT = BTDTT.MATT Where BTDBN.MABN = '" + pMaBN +"'";

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
        public static DataRow TimKiemBNCapThuocMAQL(string pMaQL)
        {
            string sql = @"SELECT       BTDBN.MABN, BTDBN.HOTEN, BTDBN.NGAYSINH, BTDBN.NAMSINH, BTDBN.PHAI, BTDBN.MANN, BTDBN.MADANTOC, BTDBN.SOCMND, 
                         BTDBN.SOTHE, HIENDIEN.MAVAOVIEN, HIENDIEN.MAQL, HIENDIEN.MAKP, HIENDIEN.NGAYVV, HIENDIEN.XUATKHOA, 
                         BTDBN.SONHA, BTDBN.THON, BTDTT.TENTT, BTDQUAN.MATT,BTDQUAN.TENQUAN,HIENDIEN.CHANDOAN,BTDKP_BV.TenKP,btdpxa.TENPXA 
                         FROM  " +
                         _acc.Get_User() + ".HIENDIEN INNER JOIN " +
                         _acc.Get_User() + ".BTDBN ON HIENDIEN.MABN = BTDBN.MABN LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDKP_BV ON HIENDIEN.MAKP = BTDKP_BV.MAKP LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDQUAN ON BTDBN.MAQU = BTDQUAN.MAQU LEFT OUTER JOIN " +
                         _acc.Get_User() + ".btdpxa ON BTDBN.MAPHUONGXA = btdpxa.MAPHUONGXA LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDTT ON BTDBN.MATT = BTDTT.MATT Where HIENDIEN.MAQL = '" + pMaQL + "'";

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
        #endregion

        #region LichSuPhatThuotBN + LichSuPhatThuocBNCT => Thông tin lịch sử phát thuốc theo bệnh nhân
        /// <summary>
        /// Thông tin lịch sử phát thuốc theo bệnh nhân
        /// </summary>
        /// <author>TinNT</author>
        /// <date>09082018</date>
        public static DataTable LichSuPhatThuotBN(string pMAQL)
        {
            string sql = @"SELECT BTDKP_BV.TENKP, DMDOTPHATTHUOT.TEN TenDotPhat, D_SUDUNGLL.ID, D_SUDUNGLL.MAKP, D_SUDUNGLL.NGAYPHAT, 
                         To_char(D_SUDUNGLL.NGAYPHAT, 'dd/mm/yyyy')  FNGAYPHAT, D_SUDUNGLL.GHICHU, D_SUDUNGLL.DONE, D_SUDUNGLL.DOTPHATID, 
                         nvl(D_SUDUNGCT.Tong, 0)  TongSL, D_SUDUNGCT.SUDUNGID, D_SUDUNGCT.MAQL, D_SUDUNGCT.MAVAOVIEN, D_SUDUNGCT.MABN,D_SUDUNGLL.PHATBOI
                         FROM(SELECT        SUDUNGID, SUM(SOLUONG)  Tong, MAQL, MAVAOVIEN, MABN
                          FROM            " + _acc.Get_UserMMYY() + @".D_SUDUNGCT
                          GROUP BY SUDUNGID, MAQL, MAVAOVIEN, MABN)  D_SUDUNGCT LEFT OUTER JOIN
                         " + _acc.Get_UserMMYY() + @".D_SUDUNGLL ON D_SUDUNGCT.SUDUNGID = D_SUDUNGLL.ID LEFT OUTER JOIN
                         " + _acc.Get_User() + @".DMDOTPHATTHUOT ON D_SUDUNGLL.DOTPHATID = DMDOTPHATTHUOT.MA LEFT OUTER JOIN
                         " + _acc.Get_User() + @".BTDKP_BV ON D_SUDUNGLL.MAKP = BTDKP_BV.MAKP WHERE (D_SUDUNGCT.MAQL = "+ pMAQL + ")";
            return _acc.Get_Data(sql);
        }
        public static DataTable LichSuPhatThuocBNCT(string pMaQL)
        {
            string sql = @"SELECT  D_SUDUNGCT.MABD, HISBVNHITP.D_DMBD.TEN,D_SUDUNGCT.SOLUONG, D_SUDUNGCT.SOLUONGCONLAI,D_SUDUNGCT.SOLUONGDAPHAT,  D_SUDUNGCT.ID, D_SUDUNGCT.MAQL,D_SUDUNGCT.SUDUNGID,  to_char(D_SUDUNGLL.NGAYPHAT,'dd/mm/yyyy') FNGAYPHAT,  D_DMBD.DANG
                         FROM            " + _acc.Get_UserMMYY() + @".D_SUDUNGCT INNER JOIN
                         " + _acc.Get_UserMMYY() + @".D_SUDUNGLL ON D_SUDUNGCT.SUDUNGID = D_SUDUNGLL.ID INNER JOIN
                         " + _acc.Get_User() + @".D_DMBD ON MABD = D_DMBD.ID where  D_SUDUNGCT.MAQL = " + pMaQL;
            return _acc.Get_Data(sql);
        }
        #endregion

        #region TK_PhieuCapThuocBN => Tìm kiếm phiếu cấp thuốc theo bệnh nhân
        /// <summary>
        /// Tìm kiếm phiếu cấp thuốc theo bệnh nhân
        /// </summary>
        /// <author>TinNT</author>
        /// <date>10082018</date>
        /// <param name="pMaBN">Mã bệnh nhân</param>
        /// <param name="pNgay">ngày</param>
        public static DataTable TK_PhieuCapThuocBN(string pMaBN, DateTime pNgay)
        {
            string sql = @"SELECT        D_XUATSDLL.MABN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL, D_XUATSDLL.NGAYYLENH,D_XUATSDLL.Phieu, D_XUATSDCT_1.MAKHO, D_XUATSDCT_1.MABD, D_XUATSDCT_1.ID D_XUATSDCTID,D_XUATSDCT_1.STT D_XUATSDCTSTT,D_XUATSDCT_1.STTT,
                         D_XUATSDCT_1.SOLUONG QtyBooking,(D_XUATSDCT_1.SOLUONG - nvl(D_DaPhat.Received,0)) QtyRemain, D_XUATSDCT_1.STTDUYET,nvl(D_DaPhat.Received,0) QtyReceived, nvl(D_SUDUNGCT_1.SOLUONG,0) QtyActual, D_DMBD.MA, D_DMBD.TEN, D_DMBD.DANG, D_DMBD.HAMLUONG, 
                         D_DMBD.MANHOM, D_SUDUNGLL.NGAYPHAT, D_SUDUNGLL.GHICHU GHICHUSDLL, D_SUDUNGLL.DONE, D_SUDUNGLL.DOTPHATID,D_SUDUNGLL.ID D_SUDUNGLLID,D_SUDUNGCT_1.GHICHU, D_SUDUNGCT_1.ID D_SUDUNGCTID
                         FROM "
                         + _acc.Get_UserMMYY() +".D_SUDUNGCT  D_SUDUNGCT_1 RIGHT OUTER JOIN "
                         + _acc.Get_UserMMYY() +".D_XUATSDLL INNER JOIN "
                         + _acc.Get_UserMMYY() +".D_XUATSDCT D_XUATSDCT_1 ON D_XUATSDLL.ID = D_XUATSDCT_1.ID INNER JOIN "
                         + _acc.Get_User() + @".D_DMBD ON D_XUATSDCT_1.MABD = D_DMBD.ID LEFT OUTER JOIN   
                          (SELECT        D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD, SUM(D_SUDUNGCT.SOLUONG)  Received
                             FROM "
                         + _acc.Get_UserMMYY() +".D_XUATSDCT INNER JOIN "
                         + _acc.Get_UserMMYY() + @".D_SUDUNGCT ON D_XUATSDCT.ID = D_SUDUNGCT.XUATSDCTID AND D_XUATSDCT.STT = D_SUDUNGCT.STT AND 
                           D_XUATSDCT.MABD = D_SUDUNGCT.MABD 
                           GROUP BY D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD)  D_DaPhat ON D_XUATSDCT_1.STT = D_DaPhat.STT AND 
                           D_XUATSDCT_1.MABD = D_DaPhat.MABD AND D_XUATSDCT_1.ID = D_DaPhat.ID LEFT OUTER JOIN "
                         + _acc.Get_UserMMYY() + @".D_SUDUNGLL ON D_XUATSDLL.MABN = D_SUDUNGLL.MABN AND D_XUATSDLL.MAVAOVIEN = D_SUDUNGLL.MAVAOVIEN AND 
                         D_XUATSDLL.MAQL = D_SUDUNGLL.MAQL AND D_XUATSDLL.MAKP = D_SUDUNGLL.MAKP ON D_SUDUNGCT_1.MABD = D_XUATSDCT_1.MABD AND D_SUDUNGCT_1.ID = D_XUATSDCT_1.ID AND "
                         + " D_SUDUNGCT_1.STT = D_XUATSDCT_1.STT "
                         + " where D_XUATSDCT_1.SOLUONG > 0 AND D_XUATSDLL.MAQL =  " + pMaBN;

            
            return _acc.Get_Data(sql);
        }
        public static DataTable TK_PhieuCapThuocMAQL(string pMaQL, string pDotPhatID, string pNgayPhat)
        {
            string sql = @"SELECT        D_XUATSDLL.MABN,BTDBN.HOTEN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL, D_XUATSDLL.NGAYYLENH, D_XUATSDLL.PHIEU, 
                         D_XUATSDCT_1.MAKHO, D_XUATSDCT_1.MABD, D_XUATSDCT_1.ID  D_XUATSDCTID, D_XUATSDCT_1.STT  D_XUATSDCTSTT, D_XUATSDCT_1.STTT, D_XUATSDCT_1.SOLUONG  QtyBooking, 
                         nvl(D_SUDUNGCT_1.SOLUONGCONLAI, D_XUATSDCT_1.SOLUONG - nvl(D_DaPhat.Received, 0)) QtyRemain , D_XUATSDCT_1.STTDUYET,
                         nvl(D_SUDUNGCT_1.SOLUONGDAPHAT,nvl(D_DaPhat.Received, 0)) QtyReceived, nvl(D_SUDUNGCT_1.SOLUONG, 0)  QtyActual, 
                         D_DMBD.MA, D_DMBD.TEN, D_DMBD.DANG, D_DMBD.HAMLUONG, D_DMBD.MANHOM, 
                         D_SUDUNGLL.GHICHU  GHICHUSDLL, D_SUDUNGLL.DONE, D_SUDUNGLL.DOTPHATID, D_SUDUNGLL.ID  D_SUDUNGLLID, 
                         D_SUDUNGCT_1.GHICHU, D_SUDUNGCT_1.ID  D_SUDUNGCTID, D_SUDUNGLL.MAKP, D_SUDUNGLL.PHATBOI, BTDKP_BV.TENKP, 
                         DMDOTPHATTHUOT.TEN  TenDotPhat, DMDOTPHATTHUOT.THOIGIAN, D_DMBD.TENHC, DMBS.HOTEN  HOTENBACSY, DMBS.VIETTAT
                        FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDLL INNER JOIN
                                        " + _acc.Get_UserMMYY() + @".D_XUATSDCT  D_XUATSDCT_1 ON D_XUATSDLL.ID = D_XUATSDCT_1.ID LEFT OUTER JOIN
                                        " + _acc.Get_User() + @".D_DMBD ON D_XUATSDCT_1.MABD = D_DMBD.ID LEFT OUTER JOIN
                                        " + _acc.Get_UserMMYY() + @".D_SUDUNGLL LEFT OUTER JOIN
                                        " + _acc.Get_User() + @".DMBS ON D_SUDUNGLL.PHATBOI = DMBS.MA RIGHT OUTER JOIN
                                        (SELECT D_SUDUNGCT.* FROM " + _acc.Get_UserMMYY() + @".D_SUDUNGLL INNER JOIN
                                        " + _acc.Get_UserMMYY() + @".D_SUDUNGCT ON D_SUDUNGLL.ID = D_SUDUNGCT.SUDUNGID
                                        WHERE  (D_SUDUNGLL.DOTPHATID = '" + pDotPhatID + "') AND (to_char(D_SUDUNGLL.NGAYPHAT,'dd/mm/yyyy') = '" + pNgayPhat + @"') )  D_SUDUNGCT_1 ON D_SUDUNGLL.ID = D_SUDUNGCT_1.SUDUNGID ON D_XUATSDCT_1.STTT = D_SUDUNGCT_1.STTTXUATCT LEFT OUTER JOIN
                                        " + _acc.Get_User() + @".DMDOTPHATTHUOT ON D_SUDUNGLL.DOTPHATID = DMDOTPHATTHUOT.MA LEFT OUTER JOIN
                                        " + _acc.Get_User() + @".BTDKP_BV ON D_SUDUNGLL.MAKP = BTDKP_BV.MAKP LEFT OUTER JOIN
                                                        (SELECT        D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD, SUM(D_SUDUNGCT.SOLUONG)  Received
                                                        FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDCT INNER JOIN
                                                                        " + _acc.Get_UserMMYY() + @".D_SUDUNGCT ON D_XUATSDCT.STTT = D_SUDUNGCT.STTTXUATCT
                                                        GROUP BY D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD)  D_DaPhat ON D_XUATSDCT_1.STT = D_DaPhat.STT AND 
                                                    D_XUATSDCT_1.MABD = D_DaPhat.MABD AND D_XUATSDCT_1.ID = D_DaPhat.ID
                                       LEFT OUTER JOIN " + _acc.Get_User() + @".BTDBN ON BTDBN.MABN = D_XUATSDLL.MABN
                        WHERE        (D_XUATSDCT_1.SOLUONG > 0) AND (D_XUATSDLL.MAQL = " + pMaQL + ") ";
            return _acc.Get_Data(sql);
        }
        #endregion


        public static DataRow TimKiemPhieuPhat(string pDOTPHATID, DateTime pNGAYPHAT, string pMAKP)
        {
            string sql = @"SELECT        ID,MAKP, NGAYPHAT, DOTPHATID, GHICHU, DONE
                            FROM            " + _acc.Get_UserMMYY() + @".D_SUDUNGLL
                            WHERE         (DOTPHATID = '"+ pDOTPHATID + "') AND (TO_Char(NGAYPHAT, 'dd/mm/yyyy')  = '"+ pNGAYPHAT.ToString(Formats.FDateDMYHM) +"') AND (MAKP = '" + pMAKP + "')";

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
       

        #region UpdateCapThuocBN => Cập nhật thông tin phát thuốc
        /// <summary>
        /// Tìm thông tin bệnh nhân 
        /// </summary>
        /// <author>TinNT</author>
        /// <date>09082018</date>
        public static bool UpdateCapThuocLLBN(string pID, string pPHATBOI, string pNGAYPHAT, string pGHICHU, string pDOTPHATID,string pMAKP)
        {

            string sql = @"declare pID NUMBER(18,0):= " + pID + @";
	                        pPHATBOI VARCHAR2(14 BYTE) := '" + pPHATBOI + @"';
	                        pMAKP VARCHAR2(3 BYTE) := '"+ pMAKP + @"';
	                        pNGAYPHAT DATE :=to_date('" + pNGAYPHAT + @"','YYYY-MM-DD HH24:MI:SS');
	                        pGHICHU NVARCHAR2(254):=N'" + pGHICHU + @"';
	                        pUSERID NUMBER(7,0):= " + E00_System.cls_System.sys_UserID + @";
	                        pDOTPHATID VARCHAR2(2 BYTE) := '" + pDOTPHATID + @"';
                            l_cnt Number:=0;
                          begin
                            SELECT COUNT(*)
                              INTO l_cnt FROM " + _acc.Get_UserMMYY() + @".D_SUDUNGLL WHERE id = pID;
                              if (l_cnt > 0) then
                                begin
                                  UPDATE       " + _acc.Get_UserMMYY() + @".D_SUDUNGLL
                                  SET                PHATBOI = pPHATBOI, MAKP = pMAKP, NGAYPHAT = pNGAYPHAT, GHICHU = pGHICHU, DONE = 0, USERID = 1, USERUD = pUSERID, NGAYUD = sysdate, 
                                                           DOTPHATID = pDOTPHATID
                                  WHERE        (ID = pID) ;
                                end;
                              else
                                INSERT INTO " + _acc.Get_UserMMYY() + @".D_SUDUNGLL
                                                 (ID, PHATBOI, MAKP, NGAYPHAT, GHICHU, DONE, USERID, USERUD, NGAYUD, DOTPHATID, NGAYTAO)
                                VALUES          (pID, pPHATBOI,pMAKP,pNGAYPHAT,pGHICHU, 0, pUSERID,pUSERID, sysdate,pDOTPHATID,sysdate);
                              end if;
                            end;";
            return _acc.Execute_Data_Return(sql) > 0;
        }

        #endregion

        #region DeletePhieuPhatThuoc => Xóa phiếu phát thuốc
        /// <summary>
        /// Xóa phiếu phát thuốc
        /// </summary>
        /// <author>TinNT</author>
        /// <date>20082018</date>
        public static bool DeletePhieuPhatThuoc(string pID)
        {
            try
            {
                string sql = @"DELETE FROM " + _acc.Get_UserMMYY() + @".d_sudungct WHERE SUDUNGID = " + pID + @";
                            DELETE FROM " + _acc.Get_UserMMYY() + @".d_sudungll WHERE ID = " + pID;
                int row = _acc.Execute_Data_Return(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        #endregion


        #region UpdateDateilPhatThuoc => Cập nhật chi tiết thông tin phát thuốc
        /// <summary>
        ///  Cập nhật chi tiết thông tin phát thuốc
        /// </summary>
        /// <author>TinNT</author>
        /// <date>09082018</date>
        public static bool UpdateDateilPhatThuoc(string pID, string pSUDUNGID, string pMABD, string pSOLUONG, string pGHICHU, string pSTT,string pXuatCTID,string pSTTTXUATCT,string pSOLUONGCONLAI, string pSOLUONGDAPHAT)
        {
            try
            {
                
                string sql = @"declare
                pID NUMBER(18,0):= " + pID + @";
	            pSUDUNGID NUMBER(18,0) := " + pSUDUNGID + @";
                pXuatCTID NUMBER(18,0):= "+ pXuatCTID + @";
	            pMABD NUMBER(7,0) :=" + pMABD + @";
	            pSOLUONG NUMBER(12,4) :=" + pSOLUONG + @";
	            pGHICHU NVARCHAR2(254):= '" + pGHICHU + @"';
	            pUSERID NUMBER(7,0) :=" + E00_System.cls_System.sys_UserID + @";
	            pUSERUD NUMBER(7,0) := " + E00_System.cls_System.sys_UserID + @";
	            pSTT NUMBER(18,0) := " + pSTT + @";
                pSTTTXUATCT NUMBER(18,0):= "+ pSTTTXUATCT + @";
                pSOLUONGCONLAI NUMBER(12,0):= " + pSOLUONGCONLAI + @";
                pSOLUONGDAPHAT NUMBER(12,0):= " + pSOLUONGDAPHAT + @";

                l_cnt Number:=0;
                begin
                  SELECT COUNT(*)
                    INTO l_cnt FROM " + _acc.Get_UserMMYY() + @".D_SUDUNGCT WHERE id = pID;
                    if (l_cnt > 0) then
                      begin
                      MERGE INTO " + _acc.Get_UserMMYY() + @".D_SUDUNGCT DSUDUNGCT
                      USING ( select * from " + _acc.Get_UserMMYY() + @".D_XUATSDCT ) DXUATSDCT
                      ON ( DSUDUNGCT.STT = DXUATSDCT.STT AND DSUDUNGCT.XUATSDCTID = DXUATSDCT.ID)
                      WHEN MATCHED THEN 
                      UPDATE  SET  DSUDUNGCT.MAKHO = DXUATSDCT.MAKHO, DSUDUNGCT.MABD = DXUATSDCT.MABD, DSUDUNGCT.SOLUONG = pSOLUONG, 
                       DSUDUNGCT.STTDUYET = DXUATSDCT.STTDUYET, DSUDUNGCT.GIABAN = DXUATSDCT.GIABAN, DSUDUNGCT.SOLAN = 1, 
                       DSUDUNGCT.LAN = 1, DSUDUNGCT.GHICHU = pGHICHU,
                       DSUDUNGCT.USERUD = pUSERUD, DSUDUNGCT.NGAYUD = sysdate,DSUDUNGCT.SUDUNGID = pSUDUNGID ,DSUDUNGCT.STTTXUATCT = pSTTTXUATCT,DSUDUNGCT.SOLUONGCONLAI = pSOLUONGCONLAI,DSUDUNGCT.SOLUONGDAPHAT = pSOLUONGDAPHAT 
                       WHERE        (DSUDUNGCT.ID = pID);
                      end;
                    else
                      INSERT INTO " + _acc.Get_UserMMYY() + @".D_SUDUNGCT
                                                 (ID, XUATSDCTID, MAKHO, MABD, SOLUONG, STTDUYET, GIABAN, SOLAN, LAN, GHICHU, USERID, NGAYTAO, USERUD, NGAYUD, STT, SUDUNGID,STTTXUATCT,SOLUONGCONLAI,SOLUONGDAPHAT,MABN,MAVAOVIEN,MAQL)
                      SELECT        pID, D_XUATSDCT.ID, MAKHO, MABD, pSOLUONG, STTDUYET, GIABAN, 1, 1,pGHICHU , pUSERID, sysdate, pUSERID, sysdate, STT, pSUDUNGID ,pSTTTXUATCT,pSOLUONGCONLAI,pSOLUONGDAPHAT,D_XUATSDLL.MABN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL
                      FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDCT INNER JOIN
                                      " + _acc.Get_UserMMYY() + @".D_XUATSDLL ON D_XUATSDCT.ID = D_XUATSDLL.ID
                      WHERE        (D_XUATSDCT.ID = pXuatCTID) AND (D_XUATSDCT.STT = pSTT) AND (D_XUATSDCT.MABD = pMaBD);
                    end if;
                  end;";

                int row = _acc.Execute_Data_Return(sql);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        #endregion

        #region LS_PhieuCapThuocBN => Tìm kiếm phiếu cấp thuốc theo bệnh nhân
        /// <summary>
        /// Tìm kiếm phiếu cấp thuốc theo bệnh nhân
        /// </summary>
        /// <author>TinNT</author>
        /// <date>10082018</date>
        /// <param name="pMaBN">Mã bệnh nhân</param>
        /// <param name="pNgay">ngày</param>
        public static DataTable LS_PhieuCapThuocBN(string pD_SUDUNGLLID)
        {
            string sql = @"SELECT        D_XUATSDLL.MABN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL, D_XUATSDLL.NGAYYLENH, D_XUATSDLL.PHIEU, 
                         D_XUATSDCT_1.MAKHO, D_XUATSDCT_1.MABD, D_XUATSDCT_1.ID  D_XUATSDCTID, D_XUATSDCT_1.STT  D_XUATSDCTSTT, D_XUATSDCT_1.SOLUONG  QtyBooking, D_XUATSDCT_1.STTDUYET, 
                         nvl(D_SUDUNGCT_1.SOLUONG, 0)  QtyActual, HISBVNHITP.D_DMBD.MA, HISBVNHITP.D_DMBD.TEN, HISBVNHITP.D_DMBD.DANG, HISBVNHITP.D_DMBD.HAMLUONG, 
                         HISBVNHITP.D_DMBD.MANHOM, D_SUDUNGLL.NGAYPHAT, D_SUDUNGLL.GHICHU  GHICHUSDLL, D_SUDUNGLL.DONE, D_SUDUNGLL.DOTPHATID, 
                         D_SUDUNGLL.ID  D_SUDUNGLLID, D_SUDUNGCT_1.GHICHU, D_SUDUNGCT_1.ID  D_SUDUNGCTID,D_SUDUNGCT_1.STTTXUATCT,D_SUDUNGCT_1.SOLUONGCONLAI QtyRemain,D_SUDUNGCT_1.SOLUONGDAPHAT QtyReceived
                        FROM            " + _acc.Get_User() + @".D_DMBD INNER JOIN
                                                 " + _acc.Get_UserMMYY() + @".D_SUDUNGCT  D_SUDUNGCT_1 ON HISBVNHITP.D_DMBD.ID = D_SUDUNGCT_1.MABD INNER JOIN
                                                 " + _acc.Get_UserMMYY() + @".D_SUDUNGLL ON D_SUDUNGCT_1.SUDUNGID = D_SUDUNGLL.ID LEFT OUTER JOIN
                                                 " + _acc.Get_UserMMYY() + @".D_XUATSDLL INNER JOIN
                                                 " + _acc.Get_UserMMYY() + @".D_XUATSDCT  D_XUATSDCT_1 ON D_XUATSDLL.ID = D_XUATSDCT_1.ID ON D_SUDUNGCT_1.XUATSDCTID = D_XUATSDCT_1.ID AND 
                                                 D_SUDUNGCT_1.MABD = D_XUATSDCT_1.MABD AND D_SUDUNGCT_1.STT = D_XUATSDCT_1.STT
                        WHERE        (D_SUDUNGLL.ID ="+ pD_SUDUNGLLID + " )";


            return _acc.Get_Data(sql);
        }
        #endregion

        #region LichSuPhatTheoKhoa => Tìm thông tin phát thuốc theo khoa
        /// <summary>
        /// Tìm thông tin phát thuốc theo khoa
        /// </summary>
        /// <author>TinNT</author>
        /// <date>09082018</date>
        public static DataTable LichSuPhatTheoKhoa(string pMaKP, DateTime pNgay)
        {
            string sql = @"SELECT     to_char(D_SUDUNGLL.NGAYPHAT,'dd/mm/yyyy') FNgayPhat,  DMBS.HOTEN, D_SUDUNGLL.MAKP, D_SUDUNGLL.ID, D_SUDUNGLL.PHATBOI, D_SUDUNGLL.NGAYPHAT, D_SUDUNGLL.GHICHU, nvl(TotalCT.TotalBN,0) TotalBN, 
                         nvl(TotalCT.TotalQty,0) TotalQty, nvl(TotalCT.TotalBD,0) TotalDB, HISBVNHITP.DMDOTPHATTHUOT.TEN, HISBVNHITP.DMDOTPHATTHUOT.THOIGIAN
                            FROM            " + _acc.Get_User() + @".DMDOTPHATTHUOT RIGHT OUTER JOIN
                                                    " + _acc.Get_UserMMYY() + @".D_SUDUNGLL ON HISBVNHITP.DMDOTPHATTHUOT.MA = D_SUDUNGLL.DOTPHATID LEFT OUTER JOIN
                                                         (SELECT        SUDUNGID, COUNT(MABN)  TotalBN, SUM(SOLUONG)  TotalQty, COUNT(MABD)  TotalBD
                                                           FROM            " + _acc.Get_UserMMYY() + @".D_SUDUNGCT
                                                           GROUP BY SUDUNGID)  TotalCT ON D_SUDUNGLL.ID = TotalCT.SUDUNGID
                            left outer join " + _acc.Get_User() + @".DMBS on DMBS.MA = D_SUDUNGLL.PHATBOI
                            WHERE        (D_SUDUNGLL.MAKP = '" + pMaKP +"') AND (to_char(D_SUDUNGLL.NGAYPHAT,'dd/mm/yyyy') = '"+ pNgay.ToString(Formats.FDateDMYHM) + "')";

            return _acc.Get_Data(sql);
        }
        #endregion

        #region LichSuPhatTheoKhoa => Tìm thông tin bệnh nhân trong phiếu phát
        /// <summary>
        /// Tìm thông tin bệnh nhân trong phiếu phát
        /// </summary>
        /// <author>TinNT</author>
        /// <date>09082018</date>
        public static DataTable LichSuPhatTheoKhoa(string pSoPhieuPhat)
        {
            string sql = @"SELECT        D_XUATSDLL.MABN,BTDBN.HOTEN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL, D_XUATSDLL.NGAYYLENH, D_XUATSDLL.PHIEU, 
                         D_XUATSDCT_1.MAKHO, D_XUATSDCT_1.MABD, D_XUATSDCT_1.ID  D_XUATSDCTID, D_XUATSDCT_1.STT  D_XUATSDCTSTT, D_XUATSDCT_1.STTT, D_XUATSDCT_1.SOLUONG  QtyBooking, 
                         nvl(D_SUDUNGCT_1.SOLUONGCONLAI, D_XUATSDCT_1.SOLUONG - nvl(D_DaPhat.Received, 0)) QtyRemain , D_XUATSDCT_1.STTDUYET,
                         nvl(D_SUDUNGCT_1.SOLUONGDAPHAT,nvl(D_DaPhat.Received, 0)) QtyReceived, nvl(D_SUDUNGCT_1.SOLUONG, 0)  QtyActual, 
                         D_DMBD.MA, D_DMBD.TEN, D_DMBD.DANG, D_DMBD.HAMLUONG, D_DMBD.MANHOM, D_SUDUNGLL.NGAYPHAT, 
                         D_SUDUNGLL.GHICHU  GHICHUSDLL, D_SUDUNGLL.DONE, D_SUDUNGLL.DOTPHATID, D_SUDUNGLL.ID  D_SUDUNGLLID, 
                         D_SUDUNGCT_1.GHICHU, D_SUDUNGCT_1.ID  D_SUDUNGCTID, D_SUDUNGLL.MAKP, D_SUDUNGLL.PHATBOI, BTDKP_BV.TENKP, 
                         DMDOTPHATTHUOT.TEN  TenDotPhat, DMDOTPHATTHUOT.THOIGIAN, D_DMBD.TENHC, DMBS.HOTEN  HOTENBACSY, DMBS.VIETTAT
                        FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDLL INNER JOIN
                                        " + _acc.Get_UserMMYY() + @".D_XUATSDCT  D_XUATSDCT_1 ON D_XUATSDLL.ID = D_XUATSDCT_1.ID LEFT OUTER JOIN
                                        " + _acc.Get_User() + @".D_DMBD ON D_XUATSDCT_1.MABD = D_DMBD.ID LEFT OUTER JOIN
                                        " + _acc.Get_UserMMYY() + @".D_SUDUNGLL LEFT OUTER JOIN
                                        " + _acc.Get_User() + @".DMBS ON D_SUDUNGLL.PHATBOI = DMBS.MA RIGHT OUTER JOIN
                                        (SELECT D_SUDUNGCT.* FROM " + _acc.Get_UserMMYY() + @".D_SUDUNGLL INNER JOIN
                                        " + _acc.Get_UserMMYY() + @".D_SUDUNGCT ON D_SUDUNGLL.ID = D_SUDUNGCT.SUDUNGID
                                        )  D_SUDUNGCT_1 ON D_SUDUNGLL.ID = D_SUDUNGCT_1.SUDUNGID ON D_XUATSDCT_1.STTT = D_SUDUNGCT_1.STTTXUATCT LEFT OUTER JOIN
                                        " + _acc.Get_User() + @".DMDOTPHATTHUOT ON D_SUDUNGLL.DOTPHATID = DMDOTPHATTHUOT.MA LEFT OUTER JOIN
                                        " + _acc.Get_User() + @".BTDKP_BV ON D_SUDUNGLL.MAKP = BTDKP_BV.MAKP LEFT OUTER JOIN
                                                        (SELECT        D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD, SUM(D_SUDUNGCT.SOLUONG)  Received
                                                        FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDCT INNER JOIN
                                                                        " + _acc.Get_UserMMYY() + @".D_SUDUNGCT ON D_XUATSDCT.STTT = D_SUDUNGCT.STTTXUATCT
                                                        GROUP BY D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD)  D_DaPhat ON D_XUATSDCT_1.STT = D_DaPhat.STT AND 
                                                    D_XUATSDCT_1.MABD = D_DaPhat.MABD AND D_XUATSDCT_1.ID = D_DaPhat.ID
                                       LEFT OUTER JOIN " + _acc.Get_User() + @".BTDBN ON BTDBN.MABN = D_XUATSDLL.MABN
                        WHERE     (D_SUDUNGLL.ID = " + pSoPhieuPhat + ") ";
            return _acc.Get_Data(sql);
        }

        public static DataTable DSBenhNhanPhieuPhat(string pSoPhieuPhat)
        {
            string sql = @"SELECT       BTDBN.MABN, BTDBN.HOTEN, BTDBN.NGAYSINH, BTDBN.NAMSINH, BTDBN.PHAI, BTDBN.MANN, BTDBN.MADANTOC, BTDBN.SOCMND, 
                         BTDBN.SOTHE, HIENDIEN.MAVAOVIEN, HIENDIEN.MAQL, HIENDIEN.MAKP, HIENDIEN.NGAYVV, HIENDIEN.XUATKHOA, 
                         BTDBN.SONHA, BTDBN.THON, BTDTT.TENTT, BTDQUAN.MATT,BTDQUAN.TENQUAN,HIENDIEN.CHANDOAN,BTDKP_BV.TenKP,btdpxa.TENPXA 
                         FROM  " +
                         _acc.Get_User() + ".HIENDIEN INNER JOIN " +
                         _acc.Get_User() + ".BTDBN ON HIENDIEN.MABN = BTDBN.MABN LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDKP_BV ON HIENDIEN.MAKP = BTDKP_BV.MAKP LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDQUAN ON BTDBN.MAQU = BTDQUAN.MAQU LEFT OUTER JOIN " +
                         _acc.Get_User() + ".btdpxa ON BTDBN.MAPHUONGXA = btdpxa.MAPHUONGXA LEFT OUTER JOIN " +
                         _acc.Get_User() + ".BTDTT ON BTDBN.MATT = BTDTT.MATT  RIGHT OUTER JOIN " +
                         " ( SELECT SUDUNGID, MAQL, MAVAOVIEN, SUM(SOLUONG) TotalQty FROM " + _acc.Get_UserMMYY() + ".D_SUDUNGCT GROUP BY SUDUNGID, MAQL, MAVAOVIEN HAVING(SUDUNGID = "+ pSoPhieuPhat +")) BenhNhans"+
                         " on BenhNhans.MAQL = HIENDIEN.MAQL ";



            return _acc.Get_Data(sql);
        }
        #endregion

        #region DSBNCanPhatThuoc => Danh sách bênh nhân cần phát thuốc theo khoa - lấy để kiểm tra 
        /// <summary>
        /// Danh sách bênh nhân cần phát thuốc theo khoa - lấy để kiểm tra 
        /// </summary>
        /// <author>TinNT</author>
        /// <date>23082018</date>
        public static DataTable DSBNCanPhatThuoc(string pMaKP)
        {
            string sql = @"SELECT      HIENDIEN.MAKP,  D_XUATSDCT_1.MAKHO, D_XUATSDCT_1.MABD, D_XUATSDCT_1.ID  D_XUATSDCTID, D_XUATSDCT_1.STT  D_XUATSDCTSTT, D_XUATSDCT_1.STTT, D_XUATSDCT_1.SOLUONG  QtyBooking, 
                         D_XUATSDCT_1.SOLUONG - nvl(D_DaPhat.Received, 0)  QtyRemain, D_XUATSDCT_1.STTDUYET, nvl(D_DaPhat.Received, 0) 
                          QtyReceived, D_XUATSDLL.MABN, D_XUATSDLL.MAVAOVIEN, D_XUATSDLL.MAQL, D_XUATSDLL.NGAYYLENH,D_XUATSDLL.MAKHOA
                         FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDCT  D_XUATSDCT_1 INNER JOIN
                         " + _acc.Get_UserMMYY() + @".D_XUATSDLL ON D_XUATSDCT_1.ID = D_XUATSDLL.ID LEFT OUTER JOIN
                             (SELECT        D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD, SUM(D_SUDUNGCT_2.SOLUONG)  Received
                               FROM            " + _acc.Get_UserMMYY() + @".D_XUATSDCT INNER JOIN
                                                         " + _acc.Get_UserMMYY() + @".D_SUDUNGCT  D_SUDUNGCT_2 ON D_XUATSDCT.STTT = D_SUDUNGCT_2.XUATSDCTID
                               GROUP BY D_XUATSDCT.ID, D_XUATSDCT.STT, D_XUATSDCT.MABD)  D_DaPhat ON D_XUATSDCT_1.STT = D_DaPhat.STT AND 
                         D_XUATSDCT_1.MABD = D_DaPhat.MABD AND D_XUATSDCT_1.ID = D_DaPhat.ID
                         LEFT OUTER JOIN " + _acc.Get_User() + @".HIENDIEN on D_XUATSDLL.MAQL = HIENDIEN.MAQL
                         where HIENDIEN.MAKP = '"+ pMaKP  + "'";
            return _acc.Get_Data(sql);
        }


        #endregion
      
    }
}
