using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E00_Common;
using System.Data;
using E00_Model;

namespace E00_API
{
    public partial class api_KhamBenh
    {
        #region Biến toàn cục
        public static Acc_Oracle _acc = new Acc_Oracle();
        private static Api_Common _api = new Api_Common();
        #endregion

        #region Khởi tạo

        public api_KhamBenh()
        {
            _api.KetNoi();
        }
        #endregion

        #region Phương thức
        #region Lấy danh sách phòng khám bệnh nhân đã khám hoặc điều trị
        /// <summary>
        /// Lấy danh sách phòng khám bệnh nhân đã khám hoặc điều trị
        /// </summary>
        /// <Date>25/06/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <param name="maBN">truyền MaBN</param>
        /// <param name="tuNgay">Ngày vào từ</param>
        /// <param name="denNgay">Đến ngày</param>
        /// <returns></returns>
        public static DataTable Get_BenhNhanPhongKham(string maBN, string tuNgay, string denNgay)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Format(
                       "select CAST(0 as float)as TINHTRANG,A.NGAY,B.TENKP,CAST('' as NVARCHAR2(50))as TENBS,CAST('' as NVARCHAR2(200))as CHANDOAN from {0}.tiepdon A inner join {1}.Btdkp_Bv B on A.MAKP = B.MAKP " +
                       "where A.MABN = '" + maBN + "' and MAQLKHAMBENH> 0 and A.Ngay between to_date('" + tuNgay +
                       "', 'DD/MM/YYYY') and to_date('" + denNgay + "','DD/MM/YYYY')"
                       + "group by NGAY,TENKP union all"
                       + " select CAST(1 as float) as TINHTRANG,A.NGAY,B.TENKP,C.HOTEN as TENBS,A.CHANDOAN  from {0}.Benhanpk A inner join {1}.Btdkp_Bv B on A.MAKP = B.MAKP inner join  {1}.Dmbs C on A.MABS=C.MA " +
                       "where A.MABN = '" + maBN + "' and A.Ngay between to_date('" + tuNgay +
                       "', 'DD/MM/YYYY') and to_date('" + denNgay + "','DD/MM/YYYY')"
                       + "group by NGAY,TENKP,HOTEN,CHANDOAN"
                       + " union all"
                       + " select CAST(2 as float) as TINHTRANG,A.NGAY,B.TENKP,C.HOTEN as TENBS,A.CHANDOAN from {0}.BENHANNGTR A inner join {1}.Btdkp_Bv B on A.MAKP = B.MAKP"
                       + " inner join {1}.BTDBN C on A.MABN = C.MABN"
                       + " where A.MABN = '" + maBN + "' and A.Ngay between to_date('" + tuNgay +
                       "', 'DD/MM/YYYY') and to_date('" + denNgay + "','DD/MM/YYYY')"
                       + " group by NGAY,TENKP,HOTEN,CHANDOAN"
                       + " union all"
                       + " select CAST(3 as float) as TINHTRANG,A.NGAY,B.TENKP,C.HOTEN as TENBS,A.CHANDOAN from {0}.BENHANDT A inner join {1}.Btdkp_Bv B on A.MAKP = B.MAKP"
                       + " inner join {1}.BTDBN C on A.MABN = C.MABN"
                       + " where A.MABN = '" + maBN + "' and A.Ngay between to_date('" + tuNgay +
                       "', 'DD/MM/YYYY') and to_date('" + denNgay + "','DD/MM/YYYY')"
                       + " union all"
                       + " select CAST(4 as float) as TINHTRANG,A.NGAY,B.TENKP,C.HOTEN as TENBS,A.CHANDOAN from {0}.BENHANCC A inner join {1}.Btdkp_Bv B on A.MAKP = B.MAKP"
                       + " inner join {1}.BTDBN C on A.MABN = C.MABN"
                       + " where A.MABN = '" + maBN + "' and A.Ngay between to_date('" + tuNgay +
                       "', 'DD/MM/YYYY') and to_date('" + denNgay + "','DD/MM/YYYY')"
                       + " group by NGAY,TENKP,HOTEN,CHANDOAN", _acc.Get_UserMMYY(), _acc.Get_User());
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region Lấy thông tin hành chính bệnh nhân
        /// <summary>
        ///  Lấy thông tin hành chính bệnh nhân
        /// </summary>
        /// <Date>25/06/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <param name="maBN">Truyền mã bệnh nhân</param>
        /// <returns></returns>
        public static DataTable Get_ThongTinBenhNhan(string maBN)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select A.MABN,A.HOTEN,A.NAMSINH,A.PHAI,E.Dantoc,A.SONHA,A.THON,B.Tenpxa,C.Tenquan,D.Tentt,F.Tennn,Round((TO_DATE('21/06/2018','DD/MM/YYYY')-A.NgaySinh)/365,0) as TUOI,A.MANN,A.MAPHUONGXA,A.MAQU,A.MATT,A.MADANTOC,A.NGAYSINH,A.HOTENCHA,A.HOTENME,A.NSCHA,A.NSME,A.VANHOA_BO,A.VANHOA_ME,A.DIENTHOAICHA,A.DIENTHOAIME,A.MANN_BO,A.MANN_ME from {1}.btdbn A";
                sql += " inner join {1}.Btdpxa B on A.MAPHUONGXA = B.MAPHUONGXA";
                sql += " inner join {1}.Btdquan C on A.Maqu = C.Maqu";
                sql += " inner join {1}.Btdtt D on A.Matt = D.Matt";
                sql += " inner join {1}.btddt E on A.Madantoc = E.Madantoc";
                sql += "  left join {1}.Btdnn_Bv F on A.MANN = F.MANN";
                sql += " where A.mabn = '{0}'";
                sql = string.Format(sql, maBN, _acc.Get_User());
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region Lấy thông tin BHYT theo mã bệnh nhân và đối tượng
        /// <summary>
        /// Lấy thông tin BHYT theo mã bệnh nhân và đối tượng
        /// </summary>
        /// <Date>25/06/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <param name="maBN">Truyền vào mã bệnh nhân</param>
        /// <param name="loaidt">truyền vào loại cần lấy thông tin</param>
        /// <returns></returns>
        public static DataTable Get_ThongTinBHYT(string maBN, int loaidt)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select A.mabn,b.MAQL,a.hoten,a.namsinh,a.ngaysinh,a.matt,a.maqu,b.madoituong,b.ngay,d.sothe,d.tungay,d.denngay,d.sudung,d.ngaytrinh,d.ngayduyet,d.ngaygiahan,d.ngay1,d.ngay2,d.ngay3,d.mienchitra,d.ngaymienchitra,d.kiemtra,d.traituyen,d.mabv from {1}.btdbn a";
                switch (loaidt)
                {
                    case 0:
                        sql += " left join {2}.tiepdon b on a.mabn = b.mabn";
                        break;
                    case 1:
                        sql += " left join {2}.benhanpk  b on a.mabn = b.mabn";
                        break;
                    case 2:
                        sql += " left join {1}.BENHANNGTR  b on a.mabn = b.mabn";
                        break;
                    case 3:
                        sql += " left join {1}.BENHANDT  b on a.mabn = b.mabn";
                        break;
                    case 4:
                        sql += " left join {1}.BENHANCC  b on a.mabn = b.mabn";
                        break;
                }
                sql += " left join {2}.BHYT d on A.MABN = d.mabn";
                sql += " where A.mabn = '{0}'";
                sql += " group by A.mabn,b.MAQL,a.hoten,a.namsinh,a.ngaysinh,a.matt,a.maqu,b.madoituong,d.sothe,b.ngay,d.tungay,d.denngay,d.sudung,d.ngaytrinh,d.ngayduyet,d.ngaygiahan,d.ngay1,d.ngay2,d.ngay3,d.mienchitra,d.ngaymienchitra,d.kiemtra,d.traituyen,d.mabv";
                sql = string.Format(sql, maBN, _acc.Get_User(), _acc.Get_UserMMYY());
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region Lấy danh sách đối tượng
        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// <Date>25/06/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <returns>Trả về Datatable DoiTuong</returns>
        public static DataTable Get_DanhMucDoiTuong()
        {
            DataTable dt = new DataTable();
            string sql = "select Madoituong,doituong from {0}.Doituong";
            sql = string.Format(sql, _acc.Get_User());
            dt = _acc.Get_Data(sql);
            return dt;
        }
        #endregion

        #region Lấy danh sách nơi khám chữa bệnh
        /// <summary>
        /// Lấy danh sách nơi khám chữa bệnh
        /// </summary>
        /// <Date>25/06/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <returns>Trả về Datatable nơi đăng ký khám chữa bệnh</returns>
        public static DataTable Get_NoiDKKCB()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select MABV,TENBV from {0}.dmnoicapbhyt";
                sql = string.Format(sql, _acc.Get_User());
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region Lấy danh sách tổng bệnh nhân có trong phòng khám theo ngày
        /// <summary>
        /// Lấy danh sách tổng bệnh nhân có trong phòng khám theo ngày
        /// </summary>
        /// <Date>25/06/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <param name="Ngay">Ngày cần lấy</param>
        /// <returns>Trả về Datatable tổng bệnh nhân có trong phòng khám</returns>
        public static DataTable Get_DanhSachBenhNhanPhongKham(string Ngay)
        {
            DataTable dt = new DataTable();
            try
            {

                string sql = "select a.makp,b.tenkp,sum(1) as tongso,sum(case when a.done is null then 1 else 0 end) as chua,sum(case when a.done='x' then 1 else 0 end) as DAKHAM,";
                sql += " sum(case when a.done='?' then 1 else 0 end) as dichvu,sum(case when a.done is not null then 1 else 0 end) as xong, b.TRANGTHAI";
                sql += " from {0}.tiepdon a,{1}.btdkp_bv b where a.makp=b.makp and a.noitiepdon in (0,1,5) and b.loai=1";
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='{2}'";
                sql += " group by a.makp,b.tenkp, b.TRANGTHAI order by b.tenkp";
                sql = string.Format(sql, _acc.Get_UserMMYY(), _acc.Get_User(), Ngay);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }

            return dt;
        }
        #endregion


        #region Lấy danh sách bệnh nhân được xủ trí chuyển phòng khám theo ngày
        /// <summary>
        /// Lấy danh sách bệnh nhân được xử trí theo ngày
        /// </summary>
        /// <Date>25/06/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <param name="Ngay">Ngày cần lấy</param>
        /// <param name="Loai">Load=1 là lấy bệnh nhân chưa khám : Loai=0 là lấy bệnh nhân đã khám bệnh</param>
        /// <returns></returns>
        public static DataTable Get_DanhSachBenhNhanChuyenPK(string Ngay, string Loai)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "select a.MABN,a.MAQL, b.HOTEN,b.NGAYSINH,H.MaKP as MAKPCD,H.TENKP as TENKPCD,d.TENKP as PHONGKHAMCHUYEN,A.MaKP,F.TEN AS LYDOCHUYEN,G.DOITUONG from {0}.tiepdon a"
                    + " inner join {1}.BTDBN b on a.MABN = b.MABN"
                    + " inner join {1}.BTDKP_BV d on a.MAKP = d.MAKP"
                    + " inner join hisbvnhitp.XUTRIKB F on a.XUTRI = F.MA"
                    + " inner join hisbvnhitp.DOITUONG G on a.MADOITUONG = G.MADOITUONG"
                    + " inner join hisbvnhitp.BTDKP_BV H on a.MAKPCHUYEN = H.MAKP"
                    + " where  to_char(a.ngay,'dd/mm/yyyy')='{2}'  and a.done is null";
                if (Loai == "1")
                {
                    sql += " and noitiepdon=1 and  a.sovaovien is null and (a.XUTRI = '11' or a.XUTRI = '8')";
                }
                sql = string.Format(sql, _acc.Get_UserMMYY(), _acc.Get_User(), Ngay);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }

            return dt;
        }
        #endregion

        #region Lấy danh sách khoa phòng ngoại trú bệnh viện theo loại
        /// <summary>
        /// Lấy danh sách khoa phòng ngoại trú bệnh viện theo loại
        /// </summary>
        /// <Date>25/06/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <returns>Trả về Datatable danh sách phòng khám theo loại(loai=0 là bệnh án nội trú: loai=1 là bệnh án ngoại trú) </returns>
        public static DataTable Get_BTDKP_BV(string maBN)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "select a.MAKP,a.TENKP,a.TRANGTHAI from {0}.BTDKP_BV a inner join {2}.tiepdon b on a.makp= b.makp where b.mabn='{1}' and NOITIEPDON=1";
                sql = string.Format(sql, _acc.Get_User(), maBN, _acc.Get_UserMMYY());
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }

            return dt;
        }
        #endregion

        #region Lấy thông tin hủy bệnh nhân

        public static DataTable Get_HuyThongTinBenhNhan(string maLoai, string maBN)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "select c.mabn,a.maql,c.hoten,to_char(a.ngay, 'dd/mm/yyyy HH24:mm:ss') as NGAY,c.namsinh,b.MAKP,b.tenKP from ";
                switch (maLoai)
                {
                    case "0":
                        sql += " {0}.tiepdon a ";
                        break;
                    case "1":
                        sql += " {0}.benhanpk a";
                        break;
                    case "2":
                        sql += " {1}.benhanngtr a ";
                        break;
                    case "3":
                        break;
                    case "4":
                        sql += " {1}.nhapkhoa a ";
                        break;
                    case "5":
                        sql += " {0}.pttt a ";
                        break;
                    case "6":
                        sql += " {1}.xuatkhoa a ";
                        break;
                    case "7":
                        sql += " {1}.xuatvien a ";
                        break;
                    case "8":
                        sql += " {1}.hiendien a ";
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "12":
                        break;
                    case "13":
                        sql += " {1}.benhancc a ";
                        break;
                    case "14":
                        break;
                    case "15":
                        break;
                }
                sql += " inner join {1}.btdkp_bv b on a.makp = b.makp";
                sql += " inner join {1}.btdbn c on a.mabn = c.mabn where a.mabn = '{2}'";
                sql = String.Format(sql, _acc.Get_UserMMYY(), _acc.Get_User(), maBN);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }

        #endregion

        #region Lấy danh sách nghề nghiệp
        /// <summary>
        /// Lấy danh sách khoa phòng ngoại trú bệnh viện theo loại
        /// </summary>
        /// <Date>02/07/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        public static DataTable Get_NgheNghiep()
        {
            string sql = "select MANN,TENNN from {0}.{1}";
            DataTable dt = new DataTable();
            sql = string.Format(sql, _acc.Get_User(),cls_BoTuDienNgheNghiep.tb_TenBang);
            dt = _acc.Get_Data(sql);
            return dt;
        }

        #endregion

        #region Lấy cấu hình form Khám bệnh
        /// <summary>
        /// Lấy danh sách khoa phòng ngoại trú bệnh viện theo loại
        /// </summary>
        /// <Date>02/07/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        public static DataTable Get_CauHinh(string SYSPARAID)
        {
            DataTable dt = new DataTable();
            try
            {

                string sql = "select SYSPARAID,SYSPARANAME,VALUE from {0}.{1} where {2}='{3}'";
                sql = string.Format(sql, _acc.Get_User(), cls_Option.tb_TenBang, cls_Option.col_SYSPARAID, SYSPARAID);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }

        #endregion

        #region Lấy cấu hình form Khám bệnh
        /// <summary>
        /// Lấy danh sách khoa phòng ngoại trú bệnh viện theo loại
        /// </summary>
        /// <Date>02/07/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        public static DataTable Get_ThongTinTaiKhoanBHYT()
        {
            DataTable dt = new DataTable();
            try
            {

                string sql = "select TaiKhoan from {0}.{1} where {2}='{3}'";
                sql = string.Format(sql, _acc.Get_User(), cls_MatKhauBHYT.tb_TenBang, cls_MatKhauBHYT.col_TaiKhoan, "79532_BV");
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }

        #endregion

        #region Lấy danh sách nhân viên PTTT    
        /// <summary>
        /// Lấy danh sách nhân viên PTTT    
        /// </summary>
        /// <Date>06/07/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        public static DataTable Get_NhanVienPTTT()
        {
            DataTable dt = new DataTable();
            try
            {

                string sql = "select a.ID,a.MANV,c.TEN as VAITRO,c.MA as MAVAITRO,a.LOAI,b.HOTEN from {0}.{1} a inner join {0}.{2} b on a.{3} = b.{3} inner join {0}.{4} c on a.{5} = c.{6} ";
                sql = string.Format(sql, _acc.Get_User(),cls_NhanVienPTTT.tb_TenBang,cls_NhanSu_LiLichNhanVien.tb_TenBang,cls_NhanVienPTTT.col_MaNV,cls_VaiTro.tb_TenBang,cls_NhanVienPTTT.col_VaiTro,cls_VaiTro.col_Ma);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }

        #endregion

        #region Lấy lịch sử vào viện theo mã bệnh nhân
        public static DataTable Get_LichSuVaoVien(string mabn)
        {
            DataTable dt = new DataTable();
            try
            {

                string sql = "Select MAQL,NGAY,MAKP,CHANDOAN,MAICD,MABS,KETQUA,SOLUUTRU,TTLUCRV from {0}.{1} where {2}='{3}'";
                sql = string.Format(sql,_acc.Get_User(),cls_XuatVien.tb_TenBang,cls_XuatVien.col_MaBN,mabn);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion
        #region Lấy danh sách tỉnh thành theo mã viết tắt
        public static DataTable Get_TinhThanhVietTat()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select a.VIETTAT,CONCAT(concat(c.TENTT,' '),concat(CONCAT(b.TENQUAN,' '),a.TENPXA)) as TEN,a.MAQU,b.MATT  from {0}.{1} a inner join {0}.{2} b on a.MAQU = b.MAQU  inner join {0}.{3} c on b.MATT = c.MATT";
                sql = string.Format(sql, _acc.Get_User(), cls_BoTuDienPhuongXa.tb_TenBang, cls_BoTuDienQuanHuyen.tb_TenBang,cls_BoTuDienTinhThanh.tb_TenBang);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region Lấy thông tin ra viện theo mã quản lý
        public static DataTable Get_ThongTinRaVien(string maql)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select MAQL,NGAY,MAKP,CHANDOAN,MAICD,MABS,KETQUA,SOLUUTRU,TTLUCRV  from {0}.{1} where {2}='{3}'";
                sql = string.Format(sql, _acc.Get_User(), cls_XuatVien.tb_TenBang, cls_XuatVien.col_MaQL, maql);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion
        #endregion
    }
}
