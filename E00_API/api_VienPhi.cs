using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E00_Common;
using System.Data;
using E00_Model;
using System.Globalization;

namespace E00_API
{
    public partial class api_VienPhi
    {
        #region Biến toàn cục
        public static Acc_Oracle _acc = new Acc_Oracle();
        private static Api_Common _api = new Api_Common();
        public static string _thongSoDoiTuongBaoHiem80 = "858";//80%
        public static string _thongSoDoiTuongBaoHiem95 = "856";//95%
        public static string _thongSoTienBaoHiem = "859";//15% lương cb (194999)
        public static string _thongSoBaoHiemTraiTuyen = "861";//60%

        #endregion

        #region Khởi tạo

        public api_VienPhi()
        {
            _api.KetNoi();
        }

        #endregion

        #region Phương thức
        #region Check bệnh nhân có tồn tại.
        public static bool Check_BenhNhan(string maBN)
        {
            bool BenhNhanTonTai = false;
            try
            {
                string sql = string.Format("select {0} from {1}.{2} where {3}='{4}'", cls_BTDBN.col_MaBN, _acc.Get_User(), cls_BTDBN.tb_TenBang, cls_BTDBN.col_MaBN, maBN);
                BenhNhanTonTai = _acc.Get_Data(sql).Rows[0][0].ToString()!="" ? true:false;
            }
            catch 
            {
                return false;
            }
            return BenhNhanTonTai;
        }
        #endregion

        #region Kiểm tra thông số bảo hiểm

        public static bool Check_ThongSoBaoHiem(string thongSo, string kiemTra)
        {
            if (thongSo == "" || kiemTra == "")
            {
                return false;
            }
            string[] s = thongSo.Split('+');
            for (int i = 0; i < s.Length; i++)
            {
                if (kiemTra.ToUpper() == s[i].ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Lấy thông số bảo hiểm y tế

        public static string Get_ThongSoBaoHiem(string IDThongSo)
        {
            try
            {
                string sql1 = @"SELECT TEN  FROM " + _acc.Get_User() + ".thongso where ID = " + IDThongSo;

                DataTable ds1 = new DataTable();
                ds1 = _acc.Get_Data(sql1);
                return ds1.Rows[0]["TEN"].ToString();
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region Lấy danh sách tháng năm

        public static List<string> Get_MMYY(DateTime tuNgay, DateTime denNgay)
        {
            List<string> lst = new List<string>();
            int thang = tuNgay.Month;
            int nam = tuNgay.Year;
            try
            {
                while ((thang > denNgay.Month && nam < denNgay.Year && thang <= 12)
                    || (thang <= denNgay.Month && nam <= denNgay.Year))
                {
                    lst.Add(thang.ToString().PadLeft(2, '0') + nam.ToString().Substring(2, 2));
                    if (nam < denNgay.Year && thang == 12)
                    {
                        thang = 1;
                        nam++;
                    }
                    else if (thang < 12)
                    {
                        thang++;
                    }
                    else
                    {
                        break;
                    }
                };
            }
            catch
            {
            }
            return lst;
        }

        #endregion

        #region Load công nợ

        public static void LoadCongNo(string MaBN, ref decimal TienCongNo, ref decimal TongTamUng, ref decimal TongHoaDon )
        {
            try
            {
                DataTable ds = new DataTable();
                string sql = "", aexp = "";
                aexp = "where a.mabn ='" + MaBN + "'";
                sql = "select rownum AS STT, a.mabn,to_char(a.ngay,'dd/mm/yyyy') as ngay,";
                sql += " a.tongtamung,a.tongcongno,a.tonghoadon, a.tiensudung, a.conlai";
                sql += " from " + _acc.Get_User() + ".v_congnoll a ";
                sql += aexp;
                ds = _acc.Get_Data(sql);

                if (ds != null && ds.Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Rows)
                    {
                        TienCongNo += decimal.Parse(dr["conlai"].ToString()) - decimal.Parse(dr["tiensudung"].ToString());
                        TongTamUng += decimal.Parse(dr["tongtamung"].ToString());
                        TongHoaDon += decimal.Parse(dr["tiensudung"].ToString());
                    }
                }
            }
            catch
            {
                TienCongNo = 0;
                TongTamUng = 0;
                TongHoaDon = 0;
            }
        }

        #endregion

        #region Lấy bảo hiểm y tế trái tuyến

        public static bool Get_BaoHiemTraiTuyen(string maBN, string maQL)
        {
           
            try
            {
                string sql = string.Format("SELECT TraiTuyen FROM " + _acc.Get_User() + ".bhyt where MaBN = '{0}' and MaQL in ({1})", maBN, maQL);
                DataTable ds1 = new DataTable();
                ds1 = _acc.Get_Data(sql);
                return ds1.Rows[0]["TraiTuyen"].ToString() == "1";
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Load dịch vụ theo đối tượng

        public static void Load_DichVu_DoiTuong(string maBN, ref decimal tongChiPhi, ref decimal daThanhToan, ref decimal soDuHienTai, ref decimal chiPhiBHYT
            , ref int phanTramBHYT, ref decimal BHYTTra, ref decimal benhNhanTra, DataTable _tbDichVu, string maDoiTuong)
        {
            DataTable _dtSearch = new DataTable();
            tongChiPhi = 0;
            daThanhToan = 0;
            BHYTTra = 0;
            try
            {
                try
                {
                    try
                    {
                        _dtSearch = _tbDichVu.Select("MaDoiTuong in (" + maDoiTuong + ")").CopyToDataTable();
                    }
                    catch
                    {
                        _dtSearch = _tbDichVu.Copy();//Tất cả
                    }

                    //if (cboTrangThai.SelectedIndex == 0) //Chưa thanh toán
                    //{
                    //    _dtSearch = _dtSearch.Select("Done = '0'").CopyToDataTable();
                    //}
                    //else if (cboTrangThai.SelectedIndex == 1)//Đã thanh toán
                    //{
                    //    _dtSearch = _dtSearch.Select("Done = '1'").CopyToDataTable();
                    //}

                    //if (rdbChiDinh.Checked)
                    //{
                    //    _dtSearch = _dtSearch.Select("LOAI = '1'").CopyToDataTable();
                    //}
                    //else if (rdbKhac.Checked)
                    //{
                    //    _dtSearch = _dtSearch.Select("LOAI <> '1'").CopyToDataTable();
                    //}
                }
                catch
                {
                    _dtSearch = null;
                    //lblTongTienKyQuy.Text = "0";
                    //lblTongChiPhi.Text = "0";
                    //lblSoTienConLai.Text = "0";
                    //lblBenhNhanTra.Text = "0";
                    //lblBHYTTra.Text = "0";
                    //lblDaThanhToan.Text = "0";
                    //return;
                }

                //dgvChidinh.AutoGenerateColumns = false;
                //dgvChidinh.DataSource = _dtSearch;

                foreach (DataRow r in _dtSearch.Rows)
                {
                    if (r["TONG"].ToString().Trim() != "")
                    {
                        try
                        {
                            tongChiPhi += decimal.Parse(r["TONG"].ToString());
                        }
                        catch
                        {
                        }
                        try
                        {
                            BHYTTra += decimal.Parse(r["BHYTTra"].ToString());
                        }
                        catch
                        {
                        }

                        try
                        {
                            if (r["Done"].ToString().Trim() == "1")
                            {
                                if (r["MaDoiTuong"].ToString().Trim() == "1")
                                {
                                    daThanhToan += decimal.Parse(r["TONG"].ToString()) - decimal.Parse(r["BHYTTra"].ToString());
                                }
                                else
                                {
                                    daThanhToan += decimal.Parse(r["TONG"].ToString());
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }

                benhNhanTra = (tongChiPhi - BHYTTra - daThanhToan);

                //lblTongTienKyQuy.Text = _soTienNap.ToString("N0");
                //lblPhanTram.Text = phanTramBHYT.ToString() + "%";
                //lblTongChiPhi.Text = tongChiPhi.ToString("N0");
                //lblBHYTTra.Text = BHYTTra.ToString("N0");

                //lblDaThanhToan.Text = daThanhToan.ToString("N0");
                //lblBenhNhanTra.Text = benhNhanTra.ToString("N0");

                //soDuHienTai = _soTienNap - benhNhanTra;

                //if (soDuHienTai < 0)
                //{
                //    lblSoDu.Text = "Nạp thêm: ";
                //    lblSoTienConLai.Text = soDuHienTai.ToString("N0");
                //}
                //else
                //{
                //    if (_daHoan)
                //    {
                //        lblSoDu.Text = "Đã hoàn:";
                //    }
                //    else
                //    {
                //        lblSoDu.Text = "Hoàn trả:";
                //    }
                //    lblSoTienConLai.Text = soDuHienTai.ToString("#,##0");
                //}
            }
            catch (Exception e)
            {
                //_log.WriteLogError("Lỗi - loadDGChiDinh" + e.ToString());
            }
        }

        #endregion

        #region Load dịch vụ
        public static void Load_DichVu(string maBN, string maVaoVien, string maQL, string ngayVaoVien, bool daRavien, string maDoiTuong, string soBHYT, ref decimal soTienNap, ref decimal tongChiPhi, ref decimal daThanhToan, ref decimal soDuHienTai, ref decimal chiPhiBHYT
       , ref int phanTramBHYT, ref decimal BHYTTra, ref decimal benhNhanTra, ref bool dahoan)
        {
            tongChiPhi = 0;
            soDuHienTai = 0;
            soTienNap = 0;
            chiPhiBHYT = 0;
            phanTramBHYT = 100;
            daThanhToan = 0;
            BHYTTra = 0;
            benhNhanTra = 0;

            bool daRaVien = false;
            DateTime ngay;
            string _mmyy = ngayVaoVien.Substring(3, 2) + ngayVaoVien.Substring(8, 2);
            ngay = DateTime.ParseExact(ngayVaoVien, "dd/MM/yyyy", new CultureInfo("en-US"));
            #region Tính tạm ứng

            try
            {
                List<string> lstMMyy = Get_MMYY(ngay, DateTime.Now);
                DataTable _dtTamUng = new DataTable();
                for (int i = 0; i < lstMMyy.Count; i++)
                {
                    string sql = string.Format("SELECT v.*, to_char(v.Ngay, 'yyyy-mm-dd hh24:mi:ss') NgayTamUng,b.SoBienLai"
                                      + " FROM {0}{1}.v_tamung v left join {0}{1}.v_ttrvll b on v.IDTTRV = b.ID"
                                      + " where v.mabn = '{2}' and v.MaVaoVien in ({3}) "
                                    , _acc.Get_User(), lstMMyy[i], maBN, maVaoVien);
                    _dtTamUng.Merge(_acc.Get_Data(sql));
                }
                foreach (DataRow r in _dtTamUng.Rows)
                {
                    try
                    {
                        soTienNap += decimal.Parse(r["SOTIEN"].ToString());
                        dahoan = r["Done"].ToString() == "1";
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            #endregion

            #region Tra cứu chi phí

            DataTable _tbDichVu = new DataTable();

            List<string> mmYY = Get_MMYY(ngay, DateTime.Now);
            for (int i = 0; i < mmYY.Count; i++)
            {
                _mmyy = mmYY[i];

                DataTable dt = new DataTable();

                string sql = string.Format(@"WITH TEMP AS (
                                                
                                                --Ngoại trú
                                                SELECT DISTINCT a.MaVaoVien,a.MaQL,b.ID, a.MABN, b.DONGIA GIA, b.SLYEUCAU SOLUONG , b.SLYEUCAU * b.DONGIA AS TONG, c.Ten, a.NGAY, 0 as LOAI,d.MaDoiTuong,d.DoiTuong
                                                        ,Case when b.MABD in (select MaVP from {0}{1}.v_ttrvct v1 left join {0}{1}.v_ttrvds v2 on v1.ID = v2.ID where v2.MaVaoVien in ({3}) )
                                                            then 1 else 0 end as Done
                                                        ,Case when b.MABD in (select MaVP from {0}{1}.v_ttrvct v1 left join {0}{1}.v_ttrvds v2 on v1.ID = v2.ID where v2.MaVaoVien in ({3}) )
                                                            then 'Đã thanh toán' else 'Chưa thanh toán' end as TrangThai
                                                        ,Case when d.MaDoiTuong = '1' then (b.SLYEUCAU * b.DONGIA)*{5}/100 else 0 end As BHYTTra
                                                        ,0 As BenhNhanTra
                                                        ,Case when b.MABD in (select MaVP from {0}{1}.v_ttrvct v1 left join {0}{1}.v_ttrvds v2 on v1.ID = v2.ID where v2.MaVaoVien in ({3}) )
                                                            then  (b.SLYEUCAU * b.DONGIA) else 0 end as DaTra
                                                         ,Case when b.ID in (select ID_ChiDinh from {0}.W_TRANSACTION where Patient_ID = '{2}') then '1' else '0' end as MaHDBank
                                                    ,Case when b.ID in (select ID_ChiDinh from {0}.W_TRANSACTION where Patient_ID = '{2}') then 'Đã tổng hợp' else 'Chưa tổng hợp' end as HDBank
                                                    , c.dang as dvt , nhvp.ten as nhomvp
                                                FROM {0}{1}.d_thuocbhytll a
                                                     left join {0}{1}.d_thuocbhytct b on a.ID = b.ID 
                                                     left join {0}.d_dmbd c on b.MABD = c.ID
                                                     left join {0}.D_dmnhom nh on c.manhom = nh.ID
                                                     left join {0}.V_nhomvp nhvp on nh.nhomvp = nhvp.ma
                                                     left join {0}.DoiTuong d on b.MaDoiTuong = d.MaDoiTuong
                                                     left join {0}{1}.bhytthuoc e on e.MaBD = b.MaBD
                                                WHERE a.MaVaoVien in ({3})
                                                     AND ( a.MADOITUONG <> 5 or a.MADOITUONG = 5)
                                                     AND (e.BHYTDuyet = '1' or b.MADOITUONG = 2)
                                                     --AND a.Loai <> '7' --Toa mua ngoài
                                                     --AND b.ID in ({4})

                                                -- Nội trú
                                                UNION ALL 
                                                SELECT DISTINCT a.MaVaoVien,a.MaQL,a.ID, a.MABN, a.GIAMUA GIA, a.SOLUONG, a.SOLUONG * a.GIAMUA AS TONG, c.TEN, a.NGAY, 0 as LOAI,d.MaDoiTuong,d.DoiTuong,a.Done
                                                        ,Case when a.Done = 1 then 'Đã thanh toán' else 'Chưa thanh toán' end as TrangThai
                                                        ,Case when d.MaDoiTuong = '1' then (a.SOLUONG * a.GIAMUA)*{5}/100 else 0 end As BHYTTra
                                                        ,0 As BenhNhanTra
                                                         ,Case when a.Done = 1  then  (a.SOLUONG * a.GIAMUA) else 0 end as DaTra
                                                         ,Case when a.ID in (select ID_ChiDinh from {0}.W_TRANSACTION where Patient_ID = '{2}') then '1' else '0' end as MaHDBank
                                                        ,Case when a.ID in (select ID_ChiDinh from {0}.W_TRANSACTION where Patient_ID = '{2}') then 'Đã tổng hợp' else 'Chưa tổng hợp' end as HDBank
                                                        , c.dang as dvt , nhvp.ten as nhomvp
                                                FROM {0}{1}.d_tienthuoc a
                                                     left join {0}.d_dmbd c on a.MABD = c.ID
                                                     left join {0}.D_dmnhom nh on c.manhom = nh.ID
                                                     left join {0}.V_nhomvp nhvp on nh.nhomvp = nhvp.ma
                                                     left join {0}.DoiTuong d on a.MaDoiTuong = d.MaDoiTuong
                                                WHERE ( a.MADOITUONG <> 5 or a.MADOITUONG = 5)
                                                    AND a.MaVaoVien in ({3})
                                                    AND  a.ID is Not NULL

                                                --Chỉ định
                                                UNION ALL
                                                SELECT DISTINCT a.MaVaoVien,a.MaQL,a.ID,a.MABN, giaCT.GIA GIA, a.SOLUONG, a.SOLUONG * giaCT.GIA AS TONG, giavp.TEN, a.NGAY, 1 as LOAI,d.MaDoiTuong,d.DoiTuong,a.PAID as Done
                                                    ,Case when a.PAID = 1 then 'Đã thanh toán' else 'Chưa thanh toán' end as TrangThai
                                                    ,Case when d.MaDoiTuong = '1' then (a.SOLUONG * giaCT.GIA)*{5}/100 else 0 end As BHYTTra
                                                    ,0 As BenhNhanTra
                                                    ,Case when a.PAID = 1  then  (a.SOLUONG * giaCT.GIA) else 0 end as DaTra
                                                    ,Case when a.ID in (select ID_ChiDinh from {0}.W_TRANSACTION where Patient_ID = '{2}') then '1' else '0' end as MaHDBank
                                                    ,Case when a.ID in (select ID_ChiDinh from {0}.W_TRANSACTION where Patient_ID = '{2}') then 'Đã tổng hợp' else 'Chưa tổng hợp' end as HDBank
                                                    , giavp.dvt as dvt , nhvp.ten as nhomvp
                                                FROM {0}{1}.v_chidinh a left join {0}.V_GIAVP giavp on a.MAVP = giavp.ID 
                                                                        left join {0}.V_GIAVPCT giaCT on a.MAVP = giaCT.ID_GiaVP 
                                                                        left join {0}.DoiTuong d on d.MaDoiTuong = giaCT.MaDoiTuong
                                                                        left join {0}.V_loaivp lvp on giavp.id_loai = lvp.id 
                                                                        left join {0}.V_nhomvp nhvp on lvp.id_nhom = nhvp.ma
                                                                        left join {0}{1}.v_ttrvct e on e.ID = a.IDTTRV
                                                                        left join  {0}.btdkp_bv f on e.MaKP = f.MaKP
                                                WHERE giaCT.MADOITUONG = a.MADOITUONG 
                                                        AND (a.MaVaoVien in ('{3}') or a.MaQL in ('{4}'))
                                                        AND a.ID is Not NULL
                                                       -- AND ((a.PAID = 1 and a.IDTTRV <> 0 and a.IDTTRV <> -1) OR a.PAID = 0 )
                                                        --AND  f.loai = 0 and f.mavp=0
                                                        )


                                                SELECT DISTINCT * FROM TEMP WHERE MaBN = '{2}' and SOLUONG > 0 order by MaHDBank,LOAI", _acc.Get_User(), _mmyy, maBN
                                                                                               , maVaoVien, maQL, 100);

                dt = _acc.Get_Data(sql);
                _tbDichVu.Merge(dt);

            }

            #endregion
            foreach (DataRow row in _tbDichVu.Rows)
            {
                try
                {
                    if (row["MaDoiTuong"].ToString() == "1")
                    {
                        chiPhiBHYT += decimal.Parse(row["BHYTTra"].ToString());
                    }
                }
                catch
                {
                }
            }

            #region Tính phần trăm BHYT

            bool _traiTuyen = Get_BaoHiemTraiTuyen(maBN, maQL);

            if (Check_ThongSoBaoHiem(Get_ThongSoBaoHiem(_thongSoDoiTuongBaoHiem95), maDoiTuong))
            {
                phanTramBHYT = 95;
            }
            else if (Check_ThongSoBaoHiem(Get_ThongSoBaoHiem(_thongSoDoiTuongBaoHiem80), maDoiTuong))
            {
                phanTramBHYT = 80;
            }
            else if (soBHYT.Length > 3)
            {
                phanTramBHYT = 100;
            }
            else
            {
                phanTramBHYT = 0;
            }
            try
            {
                if (chiPhiBHYT <= decimal.Parse(Get_ThongSoBaoHiem(_thongSoTienBaoHiem)) && soBHYT.Length > 3)
                {
                    phanTramBHYT = 100;
                }
            }
            catch
            {
            }
            if (_traiTuyen)
            {
                phanTramBHYT = phanTramBHYT * 6 / 10;
            }

            #endregion

            foreach (DataRow row in _tbDichVu.Rows)
            {
                try
                {
                    row["BHYTTra"] = decimal.Parse(row["BHYTTra"].ToString()) * phanTramBHYT / 100;
                    if (row["Done"].ToString() != "1")
                    {
                        row["BenhNhanTra"] = decimal.Parse(row["TONG"].ToString()) - decimal.Parse(row["DaTra"].ToString()) - decimal.Parse(row["BHYTTra"].ToString());
                    }
                }
                catch
                {
                }
            }
            try
            {
                Load_DichVu_DoiTuong(maBN, ref  tongChiPhi, ref  daThanhToan, ref  soDuHienTai, ref  chiPhiBHYT
                                        , ref  phanTramBHYT, ref  BHYTTra, ref  benhNhanTra, _tbDichVu, maDoiTuong);

            }
            catch (Exception e)
            {
                //_log.WriteLogError("Lỗi - loadDGChiDinh" + e.ToString());
            }
        }

        #endregion

        #endregion
    }
}