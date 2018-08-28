using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using E00_Common;
using E00_Helpers.Helpers;
using E00_Model;

namespace E00_API
{
   public class api_HaoPhi
    {
        private static readonly Api_Common _api = new Api_Common();
        private static readonly Acc_Oracle _acc = new Acc_Oracle();

        #region bQuanlynguon => Danh sahchs tồn kho dự trù

        /// <summary>
        /// Danh sahchs tồn kho dự trù
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        /// <param name="pmmyy">Tháng</param>
        /// <param name="pMakho">Mã Kho</param>
        /// <param name="pMaNguon">Ma Nguồn</param>
        /// <param name="pNhom">Nhóm</param>
        public static DataTable GetDSTonKhothDutru(string pmmyy, string pMakho, string pMaNguon, int pNhom)
        {
            int num = GetSLLeTheoNhom(pNhom);
            string sql = string.Concat(new object[] { "select 0 as stt,d.id MaNguon, d.ten as tennguon,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,c.ten as tenkho,trunc(a.tondau+a.slnhap-a.slxuat-case when a.slyeucau>0 then a.slyeucau else 0 end,", num, ") as soluong,b.id,a.Makho,b.bhyt,b.mahc,a.manguon,0 as tutruc,b.manhom,b.madoituong,DMHang.Ten TenHang,b.id mabd, 0 TUTRUC from ",
                _acc.Get_User(), pmmyy, ".d_tonkhoth a,",
                _acc.Get_User(), ".d_dmbd b  LEFT OUTER JOIN ",
                _acc.Get_User(),".d_dmhang DMHang on b.MAHANG = DMHang.ID,",
                _acc.Get_User(), ".d_dmkho c,",
                _acc.Get_User(),".d_dmnguon d where a.mabd=b.id and a.Makho=c.id and a.manguon=d.id" });
            if (pMakho != "")
            {
                sql = sql + " and a.Makho in (" + pMakho.Substring(0, pMakho.Length - 1) + ")";
            }
            if (pMaNguon != "")
            {
                sql = sql + " and a.manguon in (" + pMaNguon.Substring(0, pMaNguon.Length - 1) + ")";
            }
            if (bSort_mabd)
            {
                sql = sql + " order by b.ma";
            }
            else
            {
                sql = sql + " order by b.ten";
            }
            DataTable dt = _acc.Get_Data(sql);
            DataTable dt1 = _acc.Get_Data("select mmyy from " + _acc.Get_User() + ".tables where substr(mmyy,3,2)||substr(mmyy,1,2)>'" + pmmyy.Substring(2, 2) + pmmyy.Substring(0, 2) + "'");
            foreach (DataRow row in dt1.Rows)
            {
                string str = row["mmyy"].ToString();
                sql = "select Makho,mabd,manguon,sum(slxuat+case when slyeucau>0 then slyeucau else 0 end) as soluong from " + _acc.Get_User() + str + ".d_tonkhoth where slxuat+case when slyeucau>0 then slyeucau else 0 end>0";
                if (pMakho != "")
                {
                    sql = sql + " and Makho in (" + pMakho.Substring(0, pMakho.Length - 1) + ")";
                }
                if (pMaNguon != "")
                {
                    sql = sql + " and manguon in (" + pMaNguon.Substring(0, pMaNguon.Length - 1) + ")";
                }
                sql = sql + " group by Makho,mabd,manguon";
                DataTable dt2 = _acc.Get_Data(sql);
                foreach (DataRow row2 in dt2.Rows)
                {
                    DataRow row3 = getrowbyid(dt, string.Concat(new object[] { "Makho=", int.Parse(row2["Makho"].ToString()), " and id=", int.Parse(row2["mabd"].ToString()), " and manguon=", int.Parse(row2["manguon"].ToString()) }));
                    if (row3 != null)
                    {
                        row3["soluong"] = decimal.Parse(row3["soluong"].ToString()) - decimal.Parse(row2["soluong"].ToString());
                    }
                }
            }
            return dt;
        }
        public DataTable get_tutrucct_dutru(int nhom, string mmyy, int makp, string makho, string manguon, int tutruc)
        {
            string user = _acc.Get_User();
            string str2 = user + mmyy;
            //this.upd_tontutruc(mmyy, nhom, makp);
            string sql = "select a.oid as stt,d.ten as tennguon,b.ma,trim(b.ten)||' '||b.hamluong as ten,t.losx,t.sothe,b.dang,";
            sql = sql + "c.ten as tenkho,a.tondau+a.slnhap-a.slxuat as soluong,b.id,a.makho,b.bhyt,b.mahc,t.manguon,";
            sql = sql + "1 tutruc,b.manhom,b.tenhc,a.stt as sttt ";
            sql = sql + " from " + str2 + ".d_tutrucct a," + user + ".d_dmbd b," + user + ".d_dmkho c," + user + ".d_dmnguon d," + user + ".d_dmnhom e," + str2 + ".d_theodoi t";
            sql = sql + " where a.stt=t.id and a.mabd=b.id and b.manhom=e.id and a.makho=c.id and t.manguon=d.id and a.makp=" + makp;
            sql = sql + " and e.theodoi=1";
            if (tutruc == 1)
            {
               sql = sql + " and b.tutruc=1";
            }
            if (makho != "")
            {
                sql = sql + " and a.makho in (" + makho.Substring(0, makho.Length - 1) + ")";
            }
            if (manguon != "")
            {
                sql = sql + " and t.manguon in (" + manguon.Substring(0, manguon.Length - 1) + ")";
            }
            sql = sql + " order by b.ten";
            DataTable dt = _acc.Get_Data(sql);
            DataTable dt2 = _acc.Get_Data("select mmyy from " + user + ".tables where substr(mmyy,3,2)||substr(mmyy,1,2)>'" + mmyy.Substring(2, 2) + mmyy.Substring(0, 2) + "'");
            if(dt2 != null)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    string str4 = row["mmyy"].ToString();
                    str2 = user + str4;
                   sql = string.Concat(new object[] { "select a.stt,a.makho,a.mabd,t.manguon,sum(a.slxuat+case when a.slyeucau>0 then a.slyeucau else 0 end) as soluong from ", str2, ".d_tutrucct a,", user, ".d_dmbd b,", user, ".d_dmnhom c,", str2, ".d_theodoi t where a.sttt=t.id and a.mabd=b.id and b.manhom=c.id and a.slxuat+case when a.slyeucau>0 then a.slyeucau else 0 end>0 and a.makp=", makp });
                    sql = sql + " and c.theodoi=1";
                    if (tutruc == 1)
                    {
                        sql = sql + " and b.tutruc=1";
                    }
                    if (makho != "")
                    {
                        sql = sql + " and a.makho in (" + makho.Substring(0, makho.Length - 1) + ")";
                    }
                    if (manguon != "")
                    {
                        sql = sql + " and t.manguon in (" + manguon.Substring(0, manguon.Length - 1) + ")";
                    }
                    sql = sql + " group by a.stt,a.makho,a.mabd,t.manguon";
                    DataTable dt3 = _acc.Get_Data(sql);
                    if(dt3 != null)
                    {
                        foreach (DataRow row2 in dt3.Rows)
                        {
                            DataRow row3 = getrowbyid(dt, string.Concat(new object[] { "sttt=", long.Parse(row2["stt"].ToString()), " and makho=", int.Parse(row2["makho"].ToString()), " and id=", int.Parse(row2["mabd"].ToString()), " and manguon=", int.Parse(row2["manguon"].ToString()) }));
                            if (row3 != null)
                            {
                                row3["soluong"] = decimal.Parse(row3["soluong"].ToString()) - decimal.Parse(row2["soluong"].ToString());
                            }
                        }
                    }

                }
            }
            
            return dt;
        }
        public static DataTable GetDSTonKhothDutru(string mmyy, int makp, string makho, string manguon, int tutruc, int nhom)
        {
            string user = _acc.Get_User() ;
            string str2 = user + mmyy;
            string sql = "select rownum as stt,d.ten tennguon,b.ma,trim(b.ten)||' '||b.hamluong as ten,t.losx,t.sothe,b.dang,";
            sql = sql + "c.ten as tenkho,a.tondau+a.slnhap-a.slxuat as soluong,b.id,a.makho,b.bhyt,b.mahc,t.manguon,";
            sql = sql + "1 as tutruc,b.manhom,b.tenhc,a.stt as sttt ";
            sql = sql + " from " + str2 + ".d_tutrucct a," + user + ".d_dmbd b," + user + ".d_dmkho c," + user + ".d_dmnguon d," + user + ".d_dmnhom e," + str2 + ".d_theodoi t";
            sql = sql + " where a.mabd=b.id and b.manhom=e.id and a.makho=c.id and t.manguon=d.id and a.makp=" + makp;
            sql = sql + " and a.makho=c.id and a.stt=t.id ";
            //sql = sql + " and c.theodoi=1";
            if (tutruc == 1)
            {
                sql = sql + " and b.tutruc=1";
            }
            if (makho != "")
            {
                sql = sql + " and a.makho in (" + makho.Substring(0, makho.Length - 1) + ")";
            }
            if (manguon != "")
            {
                sql = sql + " and t.manguon in (" + manguon.Substring(0, manguon.Length - 1) + ")";
            }
            sql = sql + " order by b.ten";
            DataTable dt = _acc.Get_Data(sql);
            DataTable dt1 = _acc.Get_Data("select mmyy from " + user + ".tables where substr(mmyy, 3, 2) || substr(mmyy, 1, 2) > '" + mmyy.Substring(2, 2) + mmyy.Substring(0, 2) + "'");
            foreach (DataRow row in dt1.Rows)
            {
                string str4 = row["mmyy"].ToString();
                sql = string.Concat(new object[] { "select a.stt,a.makho,a.mabd,t.manguon,sum(a.slxuat) as soluong from ", str2, ".d_tutrucct a,", user, ".d_dmbd b,", user, ".d_dmnhom c,", str2, ".d_theodoi t where a.mabd=b.id and b.manhom=c.id and a.stt=t.id and a.slxuat>0 and a.makp=", makp });
                //sql = sql + " and c.theodoi=1";
                if (tutruc == 1)
                {
                    sql = sql + " and b.tutruc=1";
                }
                if (makho != "")
                {
                    sql = sql + " and a.makho in (" + makho.Substring(0, makho.Length - 1) + ")";
                }
                if (manguon != "")
                {
                    sql = sql + " and t.manguon in (" + manguon.Substring(0, manguon.Length - 1) + ")";
                }
                sql = sql + " group by a.stt,a.makho,a.mabd,t.manguon";
                foreach (DataRow row2 in _acc.Get_Data(sql).Rows)
                {
                    DataRow[] row3 = dt.Select("stt="+ Helper.ConvertSToLong(row2["stt"]) + " and makho="+ Helper.ConvertSToIn(""+row2["makho"]) + " and id="+ Helper.ConvertSToIn(""+row2["mabd"]) + " and manguon="+ Helper.ConvertSToIn(row2["manguon"]) );
                    if(row3 != null)
                    {
                        if (row3.Count() > 0)
                        {
                            row3[0]["soluong"] = Helper.ConvertSToDob(row3[0]["soluong"]) - Helper.ConvertSToDob(row2["soluong"]);
                        }
                    }
                    
                }
            }
            return dt;
        }

        #endregion

        #region GetSLLeTheoNhom

        #endregion

        #region GetSLLeTheoNhom => Lấy số lượng lẻ trong thông số

        /// <summary>
        /// Lấy số lượng lẻ trong thông số
        /// </summary>
        /// <author>TinNT</author>
        /// <date>28072018</date>
        /// <param name="pNhom">Nhóm</param>
        public static int GetSLLeTheoNhom(int pNhom)
        {
            DataTable table = _acc.Get_Data("select "+ cls_D_ThonSo.col_TEN + " from " + _acc.Get_User() + ".d_thongso where id=57 and nhom=" + pNhom);
            if (table == null) return 2;
            else
            if (table.Rows.Count == 0)
            {
                return 2;
            }
            return Helper.ConvertSToIn(""+ table.Rows[0][0]);
        }
        #endregion
        public static bool bSort_mabd
        {
            get
            {
                return (Thongso("c101") == "1");
            }
        }

        public static DataRow getrowbyid(DataTable pData, string exp)
        {
            try
            {
                return pData.Select(exp)[0];
            }
            catch
            {
                return null;
            }
        }


        #region Thongso => Đọc thông tin thông số trừ file xml

        /// <summary>
        /// Đọc thông tin thông số trừ file xml
        /// </summary>
        /// <author>TinNT</author>
        /// <date>28072018</date>
        /// <param name="pTenfile">Tên file xml</param>
        /// <param name="pCot">Cột lấy</param>
        /// <param name="pCot">Cột lấy</param>
        /// <param name="pSql">Câu lệnh SQL</param>
        public static string Thongso(string pTenfile, string pCot)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"..\..\..\xml\" + pTenfile + ".xml");
                return document.GetElementsByTagName(pCot).Item(0).InnerText;
            }
            catch
            {
                return "";
            }
        }
        public static string Thongso(string pSql)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"..\..\..\xml\d_thongso.xml");
                return document.GetElementsByTagName(pSql).Item(0).InnerText;
            }
            catch
            {
                DataSet ds = new DataSet();
                ds.ReadXml(@"..\..\..\xml\d_thongso.xml");
                DataColumn column = new DataColumn
                {
                    ColumnName = pSql,
                    DataType = Type.GetType("System.String")
                };
                ds.Tables[0].Columns.Add(column);
                ds.Tables[0].Rows[0][pSql] = "0";
                ds.WriteXml(@"..\..\..\xml\d_thongso.xml");
                return "0";
            }
        }
        #endregion

        #region GetDoiTuong => Danh sách đối tượng

        /// <summary>
        /// Danh sách đối tượng
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        public static DataTable GetDSDoiTuong()
        {
            try
            {
                string sql = @"SELECT MADOITUONG, DOITUONG, NGUON, LOAI, MANHOM, MAKHO
                FROM "+ _acc.Get_User() +".D_DOITUONG " +
                @"WHERE(HIDE = 0)
                ORDER BY MADOITUONG";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }
        #endregion

        #region GetDSMaKho => Danh sách mã kho

        /// <summary>
        /// Danh sách mã kho
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        /// <param name="pMaKhos">Danh sách mã kho</param>
        /// <param name="pMaNhom">Mã nhóm</param>
        public static DataTable GetDSMaKho(string pMaKhos, int pMaNhom)
        {
            try
            {
                string sql = @"select * from " + _acc.Get_User() + ".d_dmkho where nhom=" + pMaNhom;
                if (pMaKhos != "") sql += " and id in (" + pMaKhos.Substring(0, pMaKhos.Length - 1) + ")";
                sql += " order by stt";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }

        #endregion

        #region GetDSPhieuDuyet => Danh sách phiếu duyệt

        /// <summary>
        /// Danh sách phiếu duyệt
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        /// <param name="DuyetID">Mã Duyệt</param>
        /// <param name="pMMYY">tháng</param>
        public static DataTable GetDSPhieuDuyet(string DuyetID, string pMMYY)
        {
            try
            {
                string sql = @"select a.id, a.sophieu, c.ghichu, b.done,a.idduyet";
                sql += " from " + _acc.Get_User() + pMMYY + ".d_haophill a inner join " + _acc.Get_User() + pMMYY + ".d_duyet b on a.idduyet=b.id ";
                sql += " left join " + _acc.Get_User() + pMMYY + ".d_dausinhton c on a.id=c.iddutru ";
                sql += " where b.id=" + DuyetID + " order by a.id";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }

        #endregion

        #region GetDSPhieuHTVT => Danh sách phiếu hoàn trả theo id duyệt

        /// <summary>
        /// Danh sách phiếu hoàn trả theo id duyệt
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        /// <param name="pDuyetID">Mã Duyệt</param>
        /// <param name="pMMYY">tháng</param>
        public static DataTable GetDSPhieuHTVT(string pDuyetID, string pMMYY)
        {
            try
            {
                string sql = @"select a.id,a.mabn,' ' as hoten,a.maql,a.idkhoa,a.lydo,c.ghichu ";

                sql += " from " + _acc.Get_User() + pMMYY + ".d_hoantrall a inner join " + _acc.Get_User() + pMMYY + ".d_duyet b on a.idduyet=b.id ";
                sql += " left join " + _acc.Get_User() + pMMYY + ".d_dausinhton c on a.id=c.iddutru ";
                sql += " where a.maql=0 ";
                sql += " and a.thuoc=2 and b.id=" + pDuyetID + " order by a.id";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }

        #endregion

        #region GetDSChiTietPhieu => Danh sách chi tiết phiếu

        /// <summary>
        /// Danh sách chi tiết phiếu
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        /// <param name="pIPhieu">Danh sách mã kho</param>
        /// <param name="pMMYY">Mã nhóm</param>
        public static DataTable GetDSChiTietPhieu(string pIPhieu, string pMMYY)
        {
            try
            {
                string sql = @"select a.stt,e.doituong,a.mabd,b.ma,trim(b.ten) || ' ' || b.hamluong as ten,b.tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,a.madoituong,a.makho,'' as cachdung,b.mahc,a.manguon,a.tutruc,0 as idvpkhoa,1 as solan,1 as lan,0 as done ";
                    sql += " from " + _acc.Get_User() + pMMYY + ".d_haophict a," + _acc.Get_User() + ".d_dmbd b," + _acc.Get_User() + ".d_doituong e," + _acc.Get_User() + ".d_dmkho f where a.mabd=b.id and a.madoituong=e.madoituong and a.makho=f.id and a.id=" + pIPhieu + " order by a.stt";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }

        #endregion

        #region GetDSMaNguon => Danh sách mã kho

        /// <summary>
        /// Danh sách mã kho
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        /// <param name="pQlNguon">Trạng thái quản lý nguồn</param>
        /// <param name="pMaNhom">Mã nhóm</param>
        public static DataTable GetDSMaNguon(int pMaNhom)
        {
            try
            {
                string sql = "";
                if (bQuanlynguon(pMaNhom))
                    sql = "select ID, TEN, NHOM, STT, LOAI, LOAIBC, KETOAN from " + _acc.Get_User() + ".d_dmnguon where nhom=" + pMaNhom + " order by stt";
                else sql = "select ID, TEN, NHOM, STT, LOAI, LOAIBC, KETOAN from " + _acc.Get_User() + ".d_dmnguon where id=0 or nhom=" + pMaNhom + " order by stt";
           
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }

        #endregion

        #region bQuanlynguon => Trạng thái quản lý nguồn
        /// <summary>
        /// Trạng thái quản lý nguồn
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        /// <param name="pMaNhom">Mã nhóm</param>
        public static bool bQuanlynguon(int pNhom)
        {
           
            try
            {
                string sql = string.Concat(new object[] { "select ten from ", _acc.Get_User(), ".d_thongso where id=17 and nhom=", pNhom });
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    return (table.Rows.Count != 0) && (table.Rows[0][0].ToString() == "1");
                }
                return false;
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return false;
            }
        }
        #endregion

        #region Get_stt_haophi => lấy số thứ tự hao phí
        /// <summary>
        /// lấy số thứ tự hao phí
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pMaNhom">Mã nhóm</param>
        /// <param name="pMakp">Mã Khoa phòng</param>
        /// <param name="mmyy">tháng</param>
        public static string Get_stt_haophi(int pNhom, int pMakp, string mmyy, int pLoai)
        {
            int num = 1;
            try
            {
                string sql = string.Concat(new object[] { "select max(to_number(substr(b.sophieu,1,3),'999')) as so from ", _acc.Get_User(), mmyy, ".d_duyet a,", _acc.Get_User(), mmyy, ".d_haophill b where a.id=b.idduyet and a.makp=", pMakp });
                sql = sql + " and a.nhom=" + pNhom + " and a.loai=" + pLoai;
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    
                    try
                    {
                        if (table.Rows.Count > 0)
                        {
                            if ("" + table.Rows[0]["so"] != "")
                            {
                                num = int.Parse(table.Rows[0]["so"].ToString()) + 1;
                                 return num.ToString().PadLeft(3, '0');
                            }
                        }
                    }
                    catch
                    {
                        num.ToString().PadLeft(3, '0');
                    }
                }
                return num.ToString().PadLeft(3, '0');
            }
            catch
            {
                return num.ToString().PadLeft(3, '0');
            }
        }
        #endregion

        #region GetTTThucXuat => lấy thông tin thực xuất
        /// <summary>
        /// lấy thông tin thực xuất
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pid">Xuaats</param>
        /// <param name="mmyy">tháng</param>
        public static DataTable GetTTThucXuat(long pid, string pmmyy)
        {
            try
            {
                string sql = "select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien from " + _acc.Get_User() + pmmyy + ".d_thucxuat a," + _acc.Get_User() + pmmyy + ".d_theodoi b where a.sttt=b.id and a.id=" + pid ;
                return  _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Delect_d_xuatsdct => Xóa thông tin bảng d_xuatsdct
        /// <summary>
        /// Xóa thông tin bảng d_xuatsdct
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pid">mã d_xuatsdct</param>
        /// <param name="mmyy">tháng</param>
        public static int Delect_d_xuatsdct(long pid, string pmmyy)
        {
            try
            {

                string sql = "delete from " + _acc.Get_User() + pmmyy + ".d_xuatsdct where id = " + pid;
                return _acc.Execute_Data_Return(sql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region Delect_d_thucxuat => Xóa thông tin bảng d_thucxuat
        /// <summary>
        /// Xóa thông tin bảng d_thucxuat
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pid">mã d_thucxuat</param>
        /// <param name="mmyy">tháng</param>
        public static int Delect_d_thucxuat(long pid, string pmmyy)
        {
            try
            {

                string sql = "delete from " + _acc.Get_User() + pmmyy + ".d_thucxuat where id = " + pid;
                return _acc.Execute_Data_Return(sql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region Delect_d_thucxuat => Xóa thông tin bảng d_xuatsdll
        /// <summary>
        /// Xóa thông tin bảng d_xuatsdll
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pid">mã d_xuatsdll</param>
        /// <param name="mmyy">tháng</param>
        public static int Delect_d_xuatsdll(long pid, string pmmyy)
        {
            try
            {

                string sql = "delete from " + _acc.Get_User() + pmmyy + ".d_xuatsdll where id = " + pid;
                return _acc.Execute_Data_Return(sql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region Delect_d_dausinhton => Xóa thông tin bảng d_dausinhton
        /// <summary>
        /// Xóa thông tin bảng d_dausinhton
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pid">mã d_xuatsdll</param>
        /// <param name="mmyy">tháng</param>
        public static int Delect_d_dausinhton(long pid, string pmmyy)
        {
            try
            {

                string sql = "delete from " + _acc.Get_User() + pmmyy + ".d_dausinhton where id = " + pid;
                return _acc.Execute_Data_Return(sql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region GetTTd_duyet => lấy thông tin d_duyet
        /// <summary>
        /// lấy thông tin d_duyet
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pid">Xuaats</param>
        /// <param name="mmyy">tháng</param>
        public static DataTable GetTTd_duyet(string pMaNhom,string pSNgay, string pmmyy, string pLoai,string IPhieu, string pMaKP)
        {
            try
            {
                string sql = "select id from " + _acc.Get_User() + pmmyy + ".d_duyet where nhom=" + pMaNhom + " and to_char(ngay,'dd/mm/yyyy')='" + pSNgay + "'" + " and loai=" + pLoai + " and phieu=" + IPhieu + " and makhoa=" + pMaKP;

                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Getd_dmkhoTheoKho => lấy thông tin Getd_dmkhoTheoKho
        /// <summary>
        /// lấy thông tin Getd_dmkhoTheoKho
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pDSMaKho">danh sách kho</param>
        public static DataTable Getd_dmkhoTheoKho(string pDSMaKho)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".d_dmkho where id in (" + pDSMaKho.Substring(0, pDSMaKho.Length - 1) + ")";

                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Delect_d_haophict => Xóa thông tin bảng d_haophict
        /// <summary>
        /// Xóa thông tin bảng d_haophict
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pid">mã d_haophict</param>
        /// <param name="mmyy">tháng</param>
        /// <param name="pSTT">STT</param>
        public static int Delect_d_haophict(long pid, string pmmyy,string pStt)
        {
            try
            {
                string sql = "delete from " + _acc.Get_User() + pmmyy  + ".d_haophict where id=" + pid + " and stt=" + pStt;
                return _acc.Execute_Data_Return(sql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region Getd_haophict => d_haophict
        /// <summary>
        /// lấy thông tin d_duyet
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pid">mã d_haophict</param>
        /// <param name="mmyy">tháng</param>
        /// <param name="pSTT">STT</param>
        public static DataTable GetTTd_haophict(long pid, string pmmyy, string pStt)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User()+ pmmyy + ".d_haophict where id=" + pid + " and stt=" + pStt;

                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region GetTTd_dmkho => lấy thông tin kho theo danh sách
        /// <summary>
        /// lấy thông tin kho theo danh sách
        /// </summary>
        /// <author>TinNT</author>
        /// <date>31072018</date>
        /// <param name="pDSKho">danh sách kho</param>
        public static DataTable GetTTd_dmkho(string pDSKho)
        {
            try
            {
                string sql = "select * from " + _acc.Get_User() + ".d_dmkho where id in (" + pDSKho.Substring(0, pDSKho.Length - 1) + ")";
                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region GetDSThuocTheoGoi => Lấy danh sách thuốc theo gói
        /// <summary>
        /// Lấy danh sách thuốc theo gói
        /// </summary>
        /// <author>TinNT</author>
        /// <date>02082018</date>
        /// <param name="pLoai">Loại</param>
        /// <param name="pAll">Hiển thị tất cả</param>
        public static DataTable GetDSThuocTheoGoi(string pLoai, bool pAll)
        {
            try
            {
                string sql = "";
                if(pAll)
                    sql = "select * from " + _acc.Get_User() + ".d_theodonll where mabs is null and ghichu<>' ' order by ghichu";
                else
                    sql = "select * from " + _acc.Get_User() + ".d_theodonll where mabs is null and ghichu<>' ' and stt = " + pLoai + " order by ghichu";
                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region GetDSThuocCTTheoGoi => Lấy danh sách thuốc chi tiết theo gói
        /// <summary>
        /// ấy danh sách thuốc chi tiết theo gói
        /// </summary>
        /// <author>TinNT</author>
        /// <date>02082018</date>
        /// <param name="pLoai">Loại</param>
        /// <param name="pIDPack">mã gói</param>
        public static DataTable GetDSThuocCTTheoGoi(int pLoai, string pIDPack)
        {
            try
            {
                #region Phạm Thế Mỹ 170606 Sữa ' ' thành null
               string sql = "select 1 Selected, b.mabd,a.ma,trim(a.ten)||null||a.hamluong as ten,a.dang,";
                #endregion

                if (pLoai == -1) sql += "a.tenhc,";
                else sql += "c.ten as tenhc,";
                sql += "b.soluong,b.cachdung,a.mahc, b.c2 lan,b.songay, b.c1 ngay,b.songay songayOrg,b.soluong soluongOrg";
                sql += " from " + _acc.Get_User() + ".d_dmbd a," + _acc.Get_User() + ".d_theodonct b," + _acc.Get_User() + ".d_dmhang c ";
                sql += " where a.id=b.mabd and a.mahang=c.id and b.id=" + pIDPack;
                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region GetDSLyDo => Lấy danh sách lys do
        /// <summary>
        /// Lấy danh sách lys do
        /// </summary>
        /// <author>TinNT</author>
        /// <date>02082018</date>
        /// <param name="pNhom">nhoms</param>
        public static DataTable GetDSLyDo(int pNhom)
        {
            try
            {
                string sql = "select* from " + _acc.Get_User() + ".d_dmlydo where nhom=" + pNhom + " order by stt";

                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion
        public static bool Upd_haophill(string d_mmyy, long d_id, long d_idduyet, string d_sophieu)
        {

            string sql = @"declare pIDDUYET Number := " + d_idduyet + "; " +
                        " pSOPHIEU VARCHAR2(8 BYTE) := '" + d_sophieu + "';" +
                        " pID Number:=" + d_id + ";" +
                        @"l_cnt Number:=0;
                        begin
                        SELECT COUNT(*)
                          INTO l_cnt "+
                        " FROM "+ _acc.Get_User() + d_mmyy + ".D_HAOPHILL WHERE id = pID; "+
                        @"if (l_cnt > 0) then
                        begin
                          UPDATE " + _acc.Get_User() + d_mmyy + ".D_HAOPHILL SET IDDUYET = pIDDUYET, SOPHIEU = pSOPHIEU WHERE (ID = pID);" +
                        @"end;
                        else
                          INSERT INTO "+ _acc.Get_User() + d_mmyy + ".D_HAOPHILL(ID, IDDUYET, SOPHIEU)VALUES (pID, pIDDUYET, pSOPHIEU);" +
                        @"end if;
                        end;";
            return _acc.Execute_Data_Return(sql) > 0;
        }
        public static bool Upd_haophill(string d_mmyy, string d_id, string d_idduyet)
        {
            string sql = @"update " + _acc.Get_User() + d_mmyy + ".d_duyet set done=" + d_id + " where id=" + d_idduyet ;
            return _acc.Execute_Data_Return(sql) > 0;
        }
        public static bool Upd_d_duyetkho(string d_mmyy, string i_duyet, string d_idduyet, string pMakho)
        {
            string sql = @"update " + _acc.Get_User() + d_mmyy + ".d_duyetkho set done = " + i_duyet + " where idduyet = " + d_idduyet + " and makho = " + pMakho;
            return _acc.Execute_Data_Return(sql) > 0;
        }

        #region GetDSPhieuHT => Lấy danh sách phiếu hoàn trả
        /// <summary>
        /// Lấy danh sách phiếu hoàn trả
        /// </summary>
        /// <author>TinNT</author>
        /// <date>06082018</date>
        /// <param name="pmmyy">Tháng</param>
        /// <param name="pIDDuyet">mã duyệt</param>
        public static DataTable GetDSPhieuHT(string pmmyy, string pIDDuyet)
        {
            try
            {
                string xxx = _acc.Get_User() + pmmyy;
                string sql = "select a.id,a.mabn,' ' as hoten,a.maql,a.idkhoa,a.lydo,c.ghichu ";
                sql += " from " + xxx + ".d_hoantrall a inner join " + xxx + ".d_duyet b on a.idduyet=b.id ";
                sql += " left join " + xxx + ".d_dausinhton c on a.id=c.iddutru ";
                sql += " where a.maql=0 ";
                sql += " and a.thuoc=2 and b.id=" + pIDDuyet + " order by a.id";

                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region GetDSChiTietPhieuHT => Danh sách chi tiết phiếu hoàn trả

        /// <summary>
        /// Danh sách chi tiết phiếu hoàn trả
        /// </summary>
        /// <author>TinNT</author>
        /// <date>30072018</date>
        /// <param name="pIPhieu">Danh sách mã kho</param>
        /// <param name="pMMYY">Mã nhóm</param>
        public static DataTable GetDSChiTietPhieuHT(string pIPhieu, string pMMYY)
        {
            try
            {
                string sql = @"select a.stt,e.doituong,a.mabd,b.ma,trim(b.ten) || ' ' || b.hamluong as ten,b.tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,a.madoituong,a.makho,'' as cachdung,b.mahc,a.manguon,a.tutruc,0 as idvpkhoa,1 as solan,1 as lan,0 as done ";
                sql += " from " + _acc.Get_User() + pMMYY + ".d_hoantract a," + _acc.Get_User() + ".d_dmbd b," + _acc.Get_User() + ".d_doituong e," + _acc.Get_User() + ".d_dmkho f where a.mabd=b.id and a.madoituong=e.madoituong and a.makho=f.id and a.id=" + pIPhieu + " order by a.stt";
                return _acc.Get_Data(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi :" + ex.Message);
                return null;
            }

        }

        #endregion

    }

}
