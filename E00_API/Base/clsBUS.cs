using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using E00_Common;
using E00_Model;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Xml;
using E00_System;
using System.Globalization;
using TA_MessageBox;

namespace E00_API.Base
{
    public partial class clsBUS
    {
        #region Khởi tạo biến
        public Api_Common _api;
        public Acc_Oracle _acc;
        public LibDal.AccessData _aDal = new LibDal.AccessData();
        DataTable _dataTable = new DataTable();

        private string userError = "";
        private string systemError = "";
        public string _user;
        private string schema = "";
        #endregion

        #region Khởi tạo
        public clsBUS()
        {
            _acc = new Acc_Oracle();
            _api = new Api_Common();
            _api.KetNoi();
            schema = _acc.Get_UserMMYY();
            _user = _acc.Get_User();
        }
        #endregion

        #region Cấp Mã bệnh nhân tự động
        public bool Exist(string owner, string name, string type)
        {

            var sql = string.Format(@"SELECT * FROM all_objects
                                    WHERE UPPER(owner) = '{0}' 
                                        AND UPPER(object_name) = '{1}'
                                        AND UPPER(object_type) = '{2}'"
                        , owner.ToUpper()
                        , name.ToUpper()
                        , type.ToUpper());
            using (DataTable dt = _acc.Get_Data(sql))
            {
                return (dt != null && dt.Rows.Count > 0);
            }
        }
        public bool Execute(ref string userError, ref string systemError, List<string> lst)
        {
            if (string.IsNullOrWhiteSpace((string.Concat(lst))))//không có query
                return true;
            #region NET 4.0
            //string query = string.Join(" "
            //                            , lst.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => string.Format("EXECUTE IMMEDIATE '{0}';", x.Replace("'", "''")))); 
            #endregion
            string query = string.Join(" "
                                    , (from x in lst where !string.IsNullOrWhiteSpace(x) select string.Format("EXECUTE IMMEDIATE '{0}';", x.Replace("'", "''"))).ToArray());


            var sql = @"BEGIN " + query + "END;";

            return _acc.Execute_Data(ref userError, ref systemError, sql);

        }
        public bool KiemTraFunc()
        {
            string _userError = string.Empty;
            string _systemError = string.Empty;
            var sql = !Exist(_acc.Get_User(), "CAPTUDONGMABN", "FUNCTION")
                                ? string.Format(@"create or replace FUNCTION {0}.{1}
                                                      ( 
                                                      in_num  number,
                                                        in_yy number)
                
                                                    RETURN number AS
                                                    c number;
                                                    d number;
                                                    begin
                                                            c := 1;
                                                            d := in_num;
                                                           loop
                                                            select count(*)  into c from btdbn where mabn=in_yy || LPAD(d,6,'0');
                                                            exit when c = 0;
                                                            d := d+ 1;
                                                            end loop;
                                                            return d;

                                                   END;"
                                                , _acc.Get_User(), "CAPTUDONGMABN")
                                 : "";
            {
                if (!string.IsNullOrWhiteSpace(sql)
                    && !Execute(ref _userError, ref _systemError, new List<string> { sql }))
                {
                    TA_MessageBox.MessageBox.Show("Error when creating function CAPTUDONGMABN "
                                                    + Environment.NewLine
                                                    + _systemError
                                                   , TA_MessageBox.MessageIcon.Error);
                    return false;
                }
                return true;
            }
        }
        public int CapMaBN(int yy, int loai, int userid, bool update)
        {
			if (_aDal==null)
			{
				_aDal = new LibDal.AccessData();
			}
            string sql = string.Empty;
            int ma = 0;
            userid = int.Parse(userid.ToString() + _aDal.iRownum.ToString());

            DataTable dt = _acc.Get_Data("select stt from " + _acc.Get_User() + ".capmabn where yy=" + yy + " and loai=" + loai + " and userid=" + userid);
            if (dt.Rows.Count > 0)
            {
                ma = int.Parse(dt.Rows[0]["stt"].ToString());

            }
            else
            {
                ma++;
            }
            sql = string.Format("SELECT {0}.{1}({2},{3}) FROM DUAL"
                                   , _acc.Get_User(), "CAPTUDONGMABN"
                                   , ma, yy);
            using (DataTable dtResult = _acc.Get_Data(sql))
            {
                ma = int.Parse(dtResult.Rows[0][0].ToString());
                if (update) _aDal.upd_capmabn(yy, loai, userid, ma);
                return ma;
            }
        }
        #endregion

        #region Kiểm tra XML và xuất dữ liệu

        public static bool CheckBN4()
        {
            bool kq = false;
            if (!System.IO.Directory.Exists("..//..//DataXml//"))
            {
                return kq;
            }
            else
            {
                if (System.IO.Directory.Exists("..//..//DataXml//BADT_CALL_BN.xml"))
                {
                    kq = true;
                }
                else
                {
                    return kq;
                }
            }
            return kq;
        }

        public bool CreateCallBADT(string sMaBenhNhan, string sMaBenhAn, string sMAQL)
        {
            bool kq = true;
            try
            {
                DataSet ds = new DataSet();
                DataTable CallBADT = new DataTable();
                CallBADT.Columns.Add("MABN");
                CallBADT.Columns.Add("MABA");
                CallBADT.Columns.Add("MAQL");

                DataRow row = CallBADT.NewRow();
                row["MABN"] = sMaBenhNhan;
                row["MABA"] = sMaBenhAn;
                row["MAQL"] = sMAQL;
                CallBADT.Rows.Add(row);
                ds.Tables.Add(CallBADT);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    TA_MessageBox.MessageBox.Show(String.Format("Không có số liệu !!!!!!"), TA_MessageBox.MessageIcon.Error);
                }
                if (!System.IO.Directory.Exists("..//..//DataXml//"))
                {
                    System.IO.Directory.CreateDirectory("..//..//DataXml//");
                }

                ds.WriteXml("..//..//DataXml//BADT_CALL_BN.xml", XmlWriteMode.WriteSchema);
            }
            catch
            {
                kq = false;
            }

            return kq;
        }

        public DataTable IncludeDataBADT()
        {
            DataTable dtKq = new DataTable();
            XmlReader xmlFile;
            xmlFile = XmlReader.Create("..//..//DataXml//BADT_CALL_BN.xml", new XmlReaderSettings());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count >= 0)
            {
                dtKq = ds.Tables[0];
            }
            return dtKq;
        }

        public void DeleteCallBADT()
        {
            if (System.IO.Directory.Exists("..//..//DataXml//"))
            {
                if (System.IO.Directory.Exists("..//..//DataXml//BADT_CALL_BN.xml"))
                {
                    System.IO.Directory.Delete("..//..//DataXml//BADT_CALL_BN.xml");
                }
            }
        }

        public void CallExe(string path)
        {
            if (System.IO.Directory.Exists(path) && path.Substring(path.Length - 4, 4).ToUpper() == ".EXE")
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        public string nvl(object sValue, bool isnumber)
        {
            string kq = "";

            if (sValue == null)
            {
                if (isnumber)
                {
                    kq = "0";
                }
            }
            else
            {
                kq = sValue.ToString();
            }
            return kq;
        }
        #endregion

        #region Phương thức
        public bool Ins_BTDBN(DataRow row)
        {
            #region BTDBN Insert bệnh nhân
            try
            {
                //string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4}, {5}, {6},{7},{8},{9},{10},{11},{12},{13}) VALUES (:{1}, :{2}, to_timestamp(:{3},'dd/MM/yyyy'), :{4}, :{5}, :{6}, :{7}, :{8}, :{9}, :{10}, :{11}, :{12}, :{13})",
                //               Acc_Oracle._user + "." + cls_BTDBN.tb_TenBang
                //               , cls_BTDBN.col_MaBN//1
                //               , cls_BTDBN.col_HoTen//2
                //               , cls_BTDBN.col_NgaySinh//3
                //               , cls_BTDBN.col_NamSinh//4
                //               , cls_BTDBN.col_Phai//5
                //               , cls_BTDBN.col_MaNN//6
                //               , cls_BTDBN.col_MaDanToc//7
                //               , cls_BTDBN.col_Thon//8
                //               , cls_BTDBN.col_MaTT//9
                //               , cls_BTDBN.col_MaQU//10
                //               , cls_BTDBN.col_MaPhuongXa//11
                //               , cls_BTDBN.col_HoTenKDau//12
                //               , cls_BTDBN.col_SoThe//13
                //                );
                string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4}, {5}, {6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})",
                               Acc_Oracle._user + "." + cls_BTDBN.tb_TenBang
                               , cls_BTDBN.col_MaBN//1
                               , cls_BTDBN.col_HoTen//2
                               , cls_BTDBN.col_NgaySinh//3
                               , cls_BTDBN.col_NamSinh//4
                               , cls_BTDBN.col_Phai//5
                               , cls_BTDBN.col_MaNN//6
                               , cls_BTDBN.col_MaDanToc//7
                               , cls_BTDBN.col_Thon//8
                               , cls_BTDBN.col_MaTT//9
                               , cls_BTDBN.col_MaQU//10
                               , cls_BTDBN.col_MaPhuongXa//11
                               , cls_BTDBN.col_HoTenKDau//12
                               , cls_BTDBN.col_SoThe//13
                               , cls_BTDBN.col_VanHoaBo//14
                               , cls_BTDBN.col_VanHoaMe//15
                                , cls_BTDBN.col_MaNNBo//16
                               , cls_BTDBN.col_MaNNMe//17
                               , cls_BTDBN.col_HoTenCha//18
                               , cls_BTDBN.col_HoTenMe//19
                               , cls_BTDBN.col_CMNDCha//20
                               , cls_BTDBN.col_CMNDMe//21
                               , cls_BTDBN.col_DienThoaiCha//22
                               , cls_BTDBN.col_DienThoaiMe//23
                                );
                string usererr = "";
                string syserr = "";
                sql += " VALUES ('" + nvl(row[cls_BTDBN.col_MaBN], false) + "','"
                       + nvl(row[cls_BTDBN.col_HoTen], false) + "',to_timestamp('"
                       + nvl(row[cls_BTDBN.col_NgaySinh], false) + "','yyyy-mm-dd'),'"
                       + nvl(row[cls_BTDBN.col_NamSinh], false) + "','"
                       + nvl(row[cls_BTDBN.col_Phai], false) + "','"
                       + nvl(row[cls_BTDBN.col_MaNN], false) + "','"
                       + nvl(row[cls_BTDBN.col_MaDanToc], false) + "','"
                       + nvl(row[cls_BTDBN.col_Thon], false) + "','"
                       + nvl(row[cls_BTDBN.col_MaTT], false) + "','"
                       + nvl(row[cls_BTDBN.col_MaQU], false) + "','"
                       + nvl(row[cls_BTDBN.col_MaPhuongXa], false) + "','"
                       + nvl(row[cls_BTDBN.col_HoTenKDau], false) + "','"

                       + nvl(row[cls_BTDBN.col_SoThe], false) + "','"
                       + nvl(row[cls_BTDBN.col_VanHoaBo], false) + "','"
                       + nvl(row[cls_BTDBN.col_VanHoaMe], false) + "','"
                       + nvl(row[cls_BTDBN.col_MaNNBo], false) + "','"
                       + nvl(row[cls_BTDBN.col_MaNNMe], false) + "','"
                       + nvl(row[cls_BTDBN.col_HoTenCha], false) + "','"
                       + nvl(row[cls_BTDBN.col_HoTenMe], false) + "','"
                        + nvl(row[cls_BTDBN.col_CMNDCha], false) + "','"
                         + nvl(row[cls_BTDBN.col_CMNDMe], false) + "','"
                          + nvl(row[cls_BTDBN.col_DienThoaiCha], false) + "','"
                           + nvl(row[cls_BTDBN.col_DienThoaiMe], false) + "')"
                       ;
                var rts = _acc.Execute_Data(ref usererr, ref syserr, sql);
                //if (_acc.Execute_Data(ref usererr, ref syserr, sql, Set_OracleParameter(row)))
                if (rts)
                {

                    return true;
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Thêm thông tin bệnh nhân thất bại!", TA_MessageBox.MessageIcon.Warning);
                    return false;
                }
            }
            catch
            {
                return false;
            }

            #endregion
        }
		public string Get_yyyymmddhhmissrdstt()
		{
			Random random = new Random();
			return _acc.Get_Data("select to_char(sysdate,'yymmddhh24miss') from dual", null).Rows[0][0].ToString() + random.Next(100000, 999999);
		}
		public long Get_yyyymmddhhmissrdsttLong()
		{
			Random random = new Random();
			return long.Parse(_acc.Get_Data("select to_char(sysdate,'yymmddhh24miss') from dual", null).Rows[0][0].ToString())+ random.Next(100000, 999999);
		}
		public string Get_DiaChiBenhNhan(string maBenhNhan)
        {
            string diaChi = "";
            try
            {
                #region lấy giá trị trong database
                var mmyy = _acc.Get_MMYY();
                var user = _acc.Get_User();

                var sql = string.Format("SELECT "
                            + "nt.{10}, to_char(nt.{11} ,'dd/mm/yyyy hh24:mi') as Ngay,bn.MaDanToc,nt.MaVaoVien,pxa.MaPhuongXa,quan.MaQu,tt.MaTT,nt.MaKP"
                            + ",bn.{12}, bn.{13}, bn.{14},kp.tenkp"
                            + ",dt.{15}"
                            + ",bn.{16}, bn.{17},pxa.{18}, quan.{19}, tt.{20}"
                            + ",dt.{21}"
                            + ",bhyt.{22}, bhyt.{23}"
                            + ",qh.{24} as HOTEN_QUANHE, qh.{25} as DIACHI_QUANHE, qh.{26} as DIENTHOAI_QUANHE "
                            + ",ngt.{27} as MA_ICD_NOIGIOITHIEU,ngt.{28} as CHANDOAN_NOIGIOITHIEU "
                        + "FROM "
                            + user + ".{0} nt "
                            + "LEFT JOIN " + user + ".btdkp_bv kp ON nt.makp = kp.makp "
                            + "LEFT JOIN " + user + ".{1} bn ON nt.{10} = bn.{29} "
                            + "LEFT JOIN " + user + ".{2} dt ON bn.{30} = dt.{31} "
                            + "LEFT JOIN " + user + ".{3} pxa ON  bn.{32} = pxa.{33} "
                            + "LEFT JOIN " + user + ".{4} quan ON bn.{34} = quan.{35} "
                            + "LEFT JOIN " + user + ".{5} tt ON bn.{36} = tt.{37} "

                            + "LEFT JOIN " + user + ".{7} ngt ON nt.{40} = ngt.{41} "
                            + "LEFT JOIN " + user + mmyy + ".{8} bhyt ON nt.{40} = bhyt.{42} "
                            + "LEFT JOIN " + user + mmyy + ".{9} qh ON nt.{40} = qh.{43} "
                            + "LEFT JOIN " + user + ".{6} dt ON nt.{38} = dt.{39} "
                        + "WHERE "
                            + "nt.{10} = '" + maBenhNhan + "'"
                            + " Order by nt.MaQL DESC"
                            , "BenhAnNGTR"          //0
                            , cls_BenhNhan.tb_TenBang        // 1
                            , cls_DanToc.tb_TenBang          // 2
                            , cls_PhuongXa.tb_TenBang         // 3
                            , cls_Quan.tb_TenBang            // 4
                            , cls_TinhThanh.tb_TenBang       // 5
                            , cls_DoiTuong.tb_TenBang        // 6
                            , cls_NoiGioiThieu.tb_TenBang    // 7
                            , cls_BaoHiemYTe.tb_TenBang      // 8
                            , cls_QuanHe.tb_TenBang          // 9
                            , cls_TiepDon.col_MaBN           // 10
                            , cls_TiepDon.col_Ngay           // 11
                            , cls_BenhNhan.col_HoTen         // 12
                            , cls_BenhNhan.col_NgaySinh      // 13
                            , cls_BenhNhan.col_Phai           // 14
                            , cls_DanToc.col_DanToc          // 15
                            , cls_BenhNhan.col_SoNha         // 16
                            , cls_BenhNhan.col_Thon          // 17
                            , cls_PhuongXa.col_TenPXa        // 18
                            , cls_Quan.col_TenQuan           // 19
                            , cls_TinhThanh.col_TenTT        // 20
                            , cls_DoiTuong.col_DoiTuong      // 21
                            , cls_BaoHiemYTe.col_SoThe       // 22
                            , cls_BaoHiemYTe.col_DenNgay     // 23
                            , cls_QuanHe.col_HoTen           // 24
                            , cls_QuanHe.col_DiaChi          // 25
                            , cls_QuanHe.col_DienThoai       // 26
                            , cls_NoiGioiThieu.col_MaICD     // 27
                            , cls_NoiGioiThieu.col_ChanDoan  // 28

                            , cls_BenhNhan.col_MaBN          // 29
                            , cls_BenhNhan.col_MaDanToc      // 30
                            , cls_DanToc.col_MaDanToc        // 31
                            , cls_BenhNhan.col_MaPhuongXa    // 32
                            , cls_PhuongXa.col_MaPhuongXa    // 33
                            , cls_BenhNhan.col_MaQu          // 34
                            , cls_Quan.col_MaQu              // 35
                            , cls_BenhNhan.col_MaTT          // 36
                            , cls_TinhThanh.col_MaTT         // 37
                            , cls_DanToc.col_MaDoiTuong      // 38
                            , cls_DoiTuong.col_MaDoiTuong    // 39
                            , cls_TiepDon.col_MaQL           // 40
                            , cls_NoiGioiThieu.col_MaQL      // 41
                            , cls_BaoHiemYTe.col_MaQL        // 42
                            , cls_QuanHe.col_MaQL            // 43
                            );


                DataTable dt = _acc.Get_Data(sql);
                #endregion
                if (dt.Rows.Count <= 0) return null;
                DataRow row = dt.Rows[0];
                if (row != null)
                {

                    string SoNha = row[cls_BenhNhan.col_SoNha].ToString();
                    string ThonPho = row[cls_BenhNhan.col_Thon].ToString();

                    string XaPhuong = row[cls_PhuongXa.col_TenPXa].ToString();
                    string MaXaPhuong = row[cls_PhuongXa.col_MaPhuongXa].ToString();

                    string Huyen = row[cls_Quan.col_TenQuan].ToString();
                    string MaHuyen = row[cls_Quan.col_MaQu].ToString();

                    string MaTinh = row[cls_TinhThanh.col_MaTT].ToString();
                    string TinhThanhPho = row[cls_TinhThanh.col_TenTT].ToString();

                    if (!string.IsNullOrEmpty(SoNha))
                    {
                        diaChi += SoNha + ", ";
                    }
                    if (!string.IsNullOrEmpty(ThonPho))
                    {
                        diaChi += ThonPho + ", ";
                    }
                    if (!string.IsNullOrEmpty(XaPhuong))
                    {
                        diaChi += XaPhuong + ", ";
                    }
                    if (!string.IsNullOrEmpty(Huyen))
                    {
                        diaChi += Huyen + ", ";
                    }
                    if (!string.IsNullOrEmpty(TinhThanhPho))
                    {
                        diaChi += TinhThanhPho + ", ";
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return diaChi.Substring(0, diaChi.Length - 2);
        }
        public string Get_DiaChiBenhNhanNoiTru(string maBenhNhan)
        {
            string s = "";
            DataTable btdbn = new DataTable();
            btdbn = _acc.Get_Data_Faster("select * from " + _acc.Get_User() + ".btdbn where mabn='" + maBenhNhan + "'");
            if (btdbn.Rows.Count > 0)
            {
                s += btdbn.Rows[0]["thon"].ToString() + ",";
                string maphuongxa = btdbn.Rows[0]["maphuongxa"].ToString();
                if (!string.IsNullOrEmpty(maphuongxa))
                {
                    s += _acc.Get_Data("select * from " + _acc.Get_User() + ".btdpxa where maphuongxa='" + maphuongxa + "'").Rows[0]["tenpxa"].ToString() + ",";
                }
                string maqu = btdbn.Rows[0]["maqu"].ToString();
                if (!string.IsNullOrEmpty(maqu))
                {
                    s += _acc.Get_Data("select * from " + _acc.Get_User() + ".btdquan where maqu='" + maqu + "'").Rows[0]["tenquan"].ToString() + ",";
                }
                string matt = btdbn.Rows[0]["matt"].ToString();
                if (!string.IsNullOrEmpty(matt))
                {
                    s += _acc.Get_Data("select * from " + _acc.Get_User() + ".btdtt where matt='" + matt + "'").Rows[0]["tentt"].ToString() + ".";
                }
            }
            return s;
        }
        public string Get_Tuoi(string ngaySinh)
        {
            try
            {
                int num; DateTime time = new DateTime();
                string now = (new E00_Common.Acc_Oracle()).Get_DDMMYYYY();
                try
                {
                    time = DateTime.ParseExact(ngaySinh.Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                }
                catch (Exception)
                {

                    time = DateTime.ParseExact(ngaySinh.Substring(0, 10), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                DateTime time2 = DateTime.ParseExact(now, "ddMMyyyy", CultureInfo.InvariantCulture); ;//(string.Format("{0}-{1}-{2}", (new E00_Common.Acc_Oracle()).Get_DDMMYYYY().Substring(4, 4), this.Acc_Oracle.Get_DDMMYYYY().Substring(2, 2), this.Acc_Oracle.Get_DDMMYYYY().Substring(0, 2)));
                TimeSpan span = (TimeSpan)(time2 - time);
                if ((time2.Year - time.Year) >= 6)
                {
                    num = time2.Year - time.Year;
                    return (num.ToString() + " tuổi");
                }
                if ((((time2.Year - time.Year) * 12) + (time2.Month - time.Month)) >= 2)
                {
                    num = ((time2.Year - time.Year) * 12) + (time2.Month - time.Month);
                    return (num.ToString() + " th\x00e1ng");
                }
                if (span.Days >= 1)
                {
                    return (span.Days.ToString() + " ng\x00e0y");
                }
                return (span.Hours.ToString() + " giờ");
            }
            catch
            {
                return "";
            }

        }
        public bool Ins_QuanHe(DataRow row)
        {
            string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4},{5}) VALUES (:{1}, :{2}, :{3}, :{4},:{5})",
                                               schema + "." + cls_QuanHe.tb_TenBang
                                               , cls_QuanHe.col_MaQL//1
                                               , "QUANHE"//2
                                               , cls_QuanHe.col_HoTen//3
                                               , cls_QuanHe.col_DiaChi//4
                                               , cls_QuanHe.col_DienThoai//5

                                                );
            string usererr = "";
            string syserr = "";
            if (_acc.Execute_Data(ref userError, ref syserr, sql, Set_OracleParameter(row)))
            {
                return true;
            }
            else
            {
                TA_MessageBox.MessageBox.Show("Thêm thông tin liên hệ không thành công!", TA_MessageBox.MessageIcon.Error);
                return false;
            }
        }


        public bool Ins_NoiGioiThieu(DataRow row)
        {
            string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4}) VALUES (:{1}, :{2}, :{3},:{4})",
                                                          schema + "." + cls_NoiGioiThieu.tb_TenBang
                                                          , cls_NoiGioiThieu.col_MaQL
                                                          , "MABV"
                                                          , cls_NoiGioiThieu.col_ChanDoan
                                                          , cls_NoiGioiThieu.col_MaICD
                                                           );
            string usererr = "";
            string syserr = "";
            if (_acc.Execute_Data(ref usererr, ref syserr, sql, Set_OracleParameter(row)))
            {
                //_benhVienGioiThieu = usc_SelectBoxTuyenTren.txtTen.Text;
                return true;
            }
            else
            {
                TA_MessageBox.MessageBox.Show("Thêm thông tin nơi giới thiệu bệnh nhân không thành công!", TA_MessageBox.MessageIcon.Error);
                return false;
            }
        }

        public bool Ins_ChanDoanKemTheo(string str, DataRow row)
        {
            string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4},{5},{6}) VALUES (:{1},:{2},:{3},:{4},:{5},:{6})",
                                                       schema + "." + cls_ChanDoanKemTheo.tb_TenBang
                                                       , cls_ChanDoanKemTheo.col_Id
                                                       , cls_ChanDoanKemTheo.col_MaQL
                                                       , cls_ChanDoanKemTheo.col_Loai
                                                       , cls_ChanDoanKemTheo.col_ChanDoan
                                                       , cls_ChanDoanKemTheo.col_MaICD
                                                       , cls_ChanDoanKemTheo.col_Stt
                                                        );
            string usererr = "";
            string syserr = "";
            if (!string.IsNullOrEmpty(str))
            {
                if (_acc.Execute_Data(ref usererr, ref syserr, sql, Set_OracleParameter(row)))
                {
                    return true;
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Thêm thông tin chẩn đoán kèm theo bệnh nhân không thành công!", TA_MessageBox.MessageIcon.Error);
                    return false;
                }
            }
            return false;
        }

        public OracleParameter[] Set_OracleParameter(DataRow row)
        {
            OracleParameter[] result;
            try
            {
                OracleParameter[] arr = new OracleParameter[row.Table.Columns.Count];
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    arr[i] = new OracleParameter(":" + row.Table.Columns[i], row[row.Table.Columns[i]]);
                }
                result = arr;
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public bool Ins_TiepDon(DataRow row)
        {
            #region Tiếp Đón Insert bệnh nhân
            try
            {
                string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4}, {5}, {6},{7},{8},{9},{10}) VALUES (:{1}, :{2}, :{3}, :{4}, to_timestamp(:{5},'yyyy-mm-dd'), :{6}, :{7}, :{8}, :{9}, :{10})",
                               schema + "." + cls_TiepDon.tb_TenBang
                               , cls_TiepDon.col_MaBN//1
                               , cls_TiepDon.col_MaVaoVien//2
                               , cls_TiepDon.col_MaQL//3
                               , cls_TiepDon.col_MaKP//4
                               , cls_TiepDon.col_Ngay//5
                               , cls_TiepDon.col_MaDoiTuong//6
                               , cls_TiepDon.col_SoVaoVien//7
                               , cls_TiepDon.col_TuoiVao//8
                               , cls_TiepDon.col_USERID//9
                               , cls_TiepDon.col_NoiTiepDon//10
                                );
                string usererr = "";
                string syserr = "";
                if (_acc.Execute_Data(ref usererr, ref syserr, sql, Set_OracleParameter(row)))
                {
                    return true;
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Thêm thông tin tiếp đón thất bại!", TA_MessageBox.MessageIcon.Error);
                    return false;
                }
            }
            catch
            {
                return false;
            }

            #endregion
        }

        public bool Ins_LienHe(DataRow row)
        {
            #region Liên hệ Insert bệnh nhân
            try
            {
                string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4}, {5}, {6},{7},{8}) VALUES (:{1}, :{2}, :{3}, :{4}, :{5}, :{6}, :{7}, :{8})",
                               schema + "." + cls_LienHe.tb_TenBang
                               , cls_LienHe.col_MaQL//1
                               , cls_LienHe.col_Thon//2
                               , cls_LienHe.col_ChoLam//3
                               , cls_LienHe.col_MaTT//4
                               , cls_LienHe.col_MaQU//5
                               , cls_LienHe.col_MaPhuongXa//6
                               , cls_LienHe.col_TuoiVao//7
                               , cls_LienHe.col_BNMoi//8
                                );
                string usererr = "";
                string syserr = "";
                if (_acc.Execute_Data(ref usererr, ref syserr, sql, Set_OracleParameter(row)))
                {
                    return true;
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Thêm thông tin liên hệ thất bại!", TA_MessageBox.MessageIcon.Error);
                    return false;
                }
            }
            catch
            {
                return false;
            }

            #endregion
        }

        public bool Ins_SuKien(DataRow row)
        {
            #region sự kiện Insert bệnh nhân
            try
            {
                string sql = String.Format("INSERT INTO {0} ( {1} , {2}, {3}, {4}) VALUES (:{1}, :{2}, :{3}, :{4})",
                               Acc_Oracle._user + "." + cls_SuKien.tb_TenBang
                               , cls_SuKien.col_MaBN//1
                               , cls_SuKien.col_MaTiepDon//2
                               , cls_SuKien.col_MaCap//3
                               , cls_SuKien.col_NoiTiepDon//4
                                );
                string usererr = "";
                string syserr = "";
                if (_acc.Execute_Data(ref usererr, ref syserr, sql, Set_OracleParameter(row)))
                {
                    return true;
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Thêm thông tin sự kiện thất bại!", TA_MessageBox.MessageIcon.Error);
                    return false;
                }
            }
            catch
            {
                return false;
            }

            #endregion
        }

        public void UpdateSTT(string yy, int userid, int sttMaBN)
        {
			if (_aDal == null)
			{
				_aDal = new LibDal.AccessData();
			}
			_aDal.upd_capmabn(int.Parse(yy), 1, userid, sttMaBN);
        }

        public int GetUserID(int sys_UserID)
        {
			if (_aDal == null)
			{
				_aDal = new LibDal.AccessData();
			}
			int UserID = 0;
            UserID = int.Parse((sys_UserID).ToString() + _aDal.iRownum.ToString());
            return UserID;
        }

        public string GetYear()
        {
			if (_aDal == null)
			{
				_aDal = new LibDal.AccessData();
			}
			return _aDal.ngayhienhanh_server.Substring(8, 2);
        }

        public bool Execute_Insert(ref string userError, ref string systemError, string queryInsert, bool ignoreException = true)
        {
            if (string.IsNullOrEmpty(queryInsert))
            {
                return true;
            }
            string str = string.Join(" ", (from x in queryInsert.Split(new char[] { ';' })
                                           where !string.IsNullOrWhiteSpace(x)
                                           select string.Format("BEGIN EXECUTE IMMEDIATE q'[{0}]'; {1} END;", x.Replace("]", ")").Replace("[", "("), ignoreException ? "EXCEPTION WHEN others THEN null;" : string.Empty)).ToArray<string>());
            string str2 = "BEGIN " + str + "END;";
            return _acc.Execute_Data(ref userError, ref systemError, str2, null);
        }
        public string Tuoivao(string ngayvao, string ngaysinh)
        {
            string _Tuoi = "";
            if (ngaysinh == null || ngaysinh == "")
            {
                return "0";
            }
            int namht = DateTime.Now.Year;
            int thanght = DateTime.Now.Month;
            int ngayht = DateTime.Now.Day;
            int gioht = DateTime.Now.Hour;
            int nam = int.Parse(ngaysinh.Substring(6, 4));
            int thang = int.Parse(ngaysinh.Substring(3, 2));
            int ngay = int.Parse(ngaysinh.Substring(0, 2));
            int gio = (ngaysinh.Length > 10) ? int.Parse(ngaysinh.Substring(11, 2)) : 0;
            if (ngayvao != "")
            {
                namht = int.Parse(ngayvao.Substring(6, 4));
                thanght = int.Parse(ngayvao.Substring(3, 2));
                ngayht = int.Parse(ngayvao.Substring(0, 2));
                gioht = int.Parse(ngayvao.Substring(11, 2));
            }
            string tuoi;
            if (nam == namht)
            {
                if (thang == thanght)
                {
                    if (ngay == ngayht)
                    {
                        tuoi = "3/" + (gioht - gio);
                    }
                    else
                    {
                        tuoi = "2/" + (ngayht - ngay);
                    }
                }
                else
                {
                    tuoi = "1/" + (thanght - thang);
                }
            }
            else
            {
                tuoi = "0/" + (namht - nam);
            }
            string iTuoi = "";
            if (int.Parse(tuoi.Substring(0, 1)) < 0)
            {
                iTuoi = "0";
            }
            else
            {
                iTuoi = int.Parse(tuoi.Substring(0, 1)).ToString(); ;
            }

            _Tuoi = "0000" + tuoi.Substring(2);
            _Tuoi = _Tuoi.Substring(_Tuoi.Length - 3, 3) + iTuoi;
            return tuoi;
        }

        #endregion

        #region Public

        #region Find missing number in sequence
        public DataTable FindMissingNum(string col, string tbl, string schema = "")
        {
            string sql = string.Format(@"SELECT min_a - 1 + level
                                         FROM ( SELECT MIN({0}) min_a
                                                       , MAX({0}) max_a
                                              FROM {1}.{2}
                                          )
                                  CONNECT BY LEVEL <= max_a - min_a + 1
                                    MINUS
                                   SELECT {0}
                                     FROM {1}.{2}"
                        , col.Trim()
                        , _acc.Get_User() + schema
                        , tbl.Trim());
            return _acc.Get_Data(sql);
        }
        #endregion

        #region Auto generating ID
        public string GenerateID(string tbName, string colName, string schema = "")
        {
            int nid;
            string sid;
            try
            {
                using (DataTable dt = FindMissingNum(colName, tbName, schema))
                {
                    if (dt != null && dt.Rows.Count > 0
                        && int.TryParse(dt.Rows[0][0].ToString(), out nid))
                    {
                        return dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        var sql = string.Format("SELECT MAX({0}) FROM {1}.{2}"
                                                , colName
                                                , _acc.Get_User() + schema
                                                , tbName);
                        sid = _acc.Get_Data(sql).Rows[0][0].ToString();
                        if (int.TryParse(sid, out nid))
                            return (++nid).ToString();
                        else
                            return "1";
                    }
                }
            }
            catch (Exception ex)
            {
				TA_MessageBox.MessageBox.Show(ex.Message);
				return "1";
            }

        }
        #endregion

        #region Get MachineID
        public string GetMachineID()
        {
            return _acc.Get_Data(@"SELECT SYS_CONTEXT('USERENV','IP_ADDRESS')||'+'||Userenv('TERMINAL')||'+'||SYS_CONTEXT('USERENV','MODULE') FROM dual").Rows[0][0].ToString();
        }
        #endregion

        #region Get current server DateTime yyyy/MM/dd hh:mm:ss
        public string GetCurrentDate()
        {
            return _acc.Get_Data(@"SELECT TO_CHAR(SYSDATE,'yyyy/MM/dd hh24:mi:ss') FROM dual").Rows[0][0].ToString();
        }
        #endregion

        // #region Auto generate Mã on AD_CHINHSACHDUYET
        //        public string AutoGenerateMa_ChinhSach(string madt)
        //        {
        //            string ma = string.Empty;

        //            string sql = string.Format(@"SELECT MAX(SUBSTR({2},INSTR({2},'_',-1) + 1)) FROM {0}.{1}
        //                                        WHERE UPPER({3}) = UPPER('{4}')
        //                                        GROUP BY {3}"
        //                                        , _acc.Get_User()
        //                                        , cls_ChinhSachDuyet.tb_TenBang
        //                                        , cls_ChinhSachDuyet.col_Ma
        //                                        , cls_ChinhSachDuyet.col_MaDoiTuongDuyet
        //                                        , madt);
        //            using (DataTable dt = _acc.Get_Data(sql))
        //            {
        //                if (dt != null && dt.Rows.Count > 0)
        //                {
        //                    return string.Concat(madt, "_", Convert.ToString(dt.Rows[0][0]));
        //                }
        //                else return string.Concat(madt, "_1");
        //            }
        //        }
        //        #endregion

        #region DATABASE

        #region Generate WHERE CLAUSE
        string GetWHERE_CLAUSE(List<Tuple<string, string, string, string>> lstWhere, Dictionary<string, bool> dictDate4Where, ref List<OracleParameter> lstParameter)
        {
            var partWhere = "";
            #region WHERE CLAUSE
            #region GROUP AND/OR DOES NOT MAKE SENSE, NOT DYNAMIC. INSTEAD OF THAT, ADDDING SEQUENCE AND/OR
            //var query = lstWhere.GroupBy(x => x.Item1).Select(y => y.Key).ToList(); //group 4 key
            //int first = 0;//first will clear 1st key, 2nd & above will add key  
            //string where = "";// where part
            //for (int i = 0; i < query.Count; i++)
            //{
            //    var grp = lstWhere.Where(x => x.Item1 == query[i]).ToList();
            //    var grpStr = string.Join(query[i] + " ", grp.Select(x => x.Item2 + " " + x.Item3 + " " + ":" + i.ToString() + " "));
            //    if (i > 0)
            //    {
            //        where += query[i] + " " + grpStr;
            //    }
            //    else
            //        where += grpStr;
            #endregion
            bool formatWhere = (dictDate4Where != null && dictDate4Where.Count > 0);//need format?
            var dictDate4Where2 = new Dictionary<string, bool>();
            if (formatWhere)
                dictDate4Where2 = new Dictionary<string, bool>(dictDate4Where, StringComparer.OrdinalIgnoreCase);//Dict ignore case
            if (lstWhere != null && lstWhere.Count > 0)
            {
                for (int i = 0; i < lstWhere.Count; i++)
                {
                    var str = string.Format("{0} {1} :{2} "
                                            , ((formatWhere && dictDate4Where2.ContainsKey(lstWhere[i].Item2))
                                                ? "TO_CHAR(" + lstWhere[i].Item2 + ",'dd/MM/yyyy" + (dictDate4Where2[lstWhere[i].Item2]
                                                                                                        ? " hh24:mi:ss')"
                                                                                                        : "')")//true = date + time, false = date only
                                                : lstWhere[i].Item2)
                                            , lstWhere[i].Item3
                                            , i.ToString());//using number as name of parameter for distinct to value in SET CLAUSE
                    if (i > 0)
                    {
                        partWhere += lstWhere[i].Item1 + " " + str;
                    }
                    else
                        partWhere += str;

                    #region Parameter 4 Where
                    lstParameter.Add(new OracleParameter(":" + i.ToString(), lstWhere[i].Item4));
                    #endregion
                }
            }

            #endregion
            return partWhere;

        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userError">User's error message</param>
        /// <param name="systemError">Dev's error message</param>
        /// <param name="tbName">Table name</param>
        /// <param name="lstWhere">List of ColName & Value in WHERE CLAUSE, example: (AND,[COL],=,[VALUE])</param>
        /// <param name="dictDate4Where">ColName : bool (true: including time, otherwise date only) for format Datime in WHERE CLAUSE</param>
        /// <param name="schema"></param>
        /// <returns></returns>
        public bool Delete(ref string userError, ref string systemError, string tbName
                                , List<Tuple<string, string, string, string>> lstWhere = null
                                , Dictionary<string, bool> dictDate4Where = null, string schema = null)
        {
            string partWhere = "";
            var sql = "";
            List<OracleParameter> lstParameter = new List<OracleParameter>();
            try
            {
                partWhere = GetWHERE_CLAUSE(lstWhere, dictDate4Where, ref lstParameter);
                sql = "DELETE FROM "
                            + _acc.Get_User()
                            + (string.IsNullOrWhiteSpace(schema) ? "" : schema)
                            + "." + tbName + " ";

                if (lstWhere != null
                        && lstWhere.Count > 0
                        && !string.IsNullOrWhiteSpace(partWhere))
                {
                    sql += " WHERE " + partWhere;
                }
            }
            catch (Exception ex)
            {
                userError = "Error while generating query!";
                systemError = ex.Message;
                return false;
            }

            try
            {
                return _acc.Execute_Data(ref userError, ref systemError, sql, lstParameter.ToArray());
            }
            catch (Exception ex)
            {
                userError = "Error while deleting!";
                systemError = ex.Message;
                return false;
            }
        }
        #endregion

        #endregion

        #endregion
    }
}
