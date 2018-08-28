using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E00_Model
{
    public static class cls_BenhAnNgoaiTru
    {
        public static string tb_TenBang = "BADT_BenhAnNgoaiTru";

        public static string col_MaBN = "MaBN";//
        public static string col_MaQL = "MaQL";
        public static string col_MaLyDo = "MaLyDo";//
        public static string col_TenLyDo = "TenLyDo";//
        public static string col_LyDoKhac = "LyDoKhac";//
        public static string col_MaKhoiPhat = "MaKhoiPhat";//
        public static string col_TenKhoiPhat = "TenKhoiPhat";
        public static string col_KhoiPhatKhac = "KhoiPhatKhac";//
        public static string col_MaTrieuChung = "MaTrieuChung";//
        public static string col_TenTrieuChung = "TenTrieuChung";//
        public static string col_TrieuChungKhac = "TrieuChungKhac";//
        public static string col_MaSoCuu = "MaSoCuu";//
        public static string col_TenSoCuu = "TenSoCuu";//
        public static string col_SoCuuKhac = "SoCuuKhac";//
        public static string col_QuaTrinhKhac = "QuaTrinhKhac";//
        public static string col_MaDiUng = "MaDiUng";//
        public static string col_TenDiUng = "TenDiUng";//
        public static string col_YeuTo = "YeuTo";//
        public static string col_MaMucDo = "MaMucDo";//
        public static string col_TenMucDo = "TenMucDo";//
        public static string col_BanThanKhac = "BanThanKhac";//
        public static string col_MaBenhLienQuan = "MaBenhLienQuan";//
        public static string col_TenBenhLienQuan = "TenBenhLienQuan";//
        public static string col_BenhLienQuanKhac = "BenhLienQuanKhac";//
        public static string col_GiaDinhKhac = "GiaDinhKhac";//
        public static string col_Mach = "Mach";//
        public static string col_NhietDo = "NhietDo";//
        public static string col_HuyetAp = "HuyetAp";//
        public static string col_NhipTho = "NhipTho";//
        public static string col_CanNang = "CanNang";//
        public static string col_ChieuCao = "ChieuCao";//
        public static string col_MaTriGiac = "MaTriGiac";
        public static string col_TenTriGiac = "TenTriGiac";
        public static string col_TriGiacKhac = "TriGiacKhac";//
        public static string col_MaTheTrang = "MaTheTrang";
        public static string col_TenTheTrang = "TenTheTrang";
        public static string col_TheTrangKhac = "TheTrangKhac";//
        public static string col_MaTimMach = "MaTimMach";
        public static string col_TenTimMach = "TenTimMach";
        public static string col_TimMachKhac = "TimMachKhac";//
        public static string col_MaHoHap = "MaHoHap";
        public static string col_TenHoHap = "TenHoHap";
        public static string col_HoHapKhac = "HoHapKhac";//
        public static string col_MaTieuHoa = "MaTieuHoa";
        public static string col_TenTieuHoa = "TenTieuHoa";
        public static string col_TieuHoaKhac = "TieuHoaKhac";//
        public static string col_BatThuongKhac = "BatThuongKhac";
        public static string col_KetQuaLamSang = "KetQuaLamSang";
        public static string col_MaChanDoanBanDau = "MaChanDoanBanDau";
        public static string col_TenChanDoanBanDau = "TenChanDoanBanDau";//
        public static string col_DaXuLi = "DaXuLi";
        public static string col_MaChanDoanRaVien = "MaChanDoanRaVien";
        public static string col_TenChanDoanRaVien = "TenChanDoanRaVien";//
        public static string col_DieuTriTu = "DieuTriTu";
        public static string col_DieuTriDen = "DieuTriDen";//
        public static string col_TuqGiamDoc = "TuqGiamDoc";
        public static string col_MaBacSiTao = "MaBacSiTao";
        public static string col_TenBacSiTao = "TenBacSiTao";//
        public static string col_TongKetBenhLi = "TongKetBenhLi";
        public static string col_KetQuaXetNghiem = "KetQuaXetNghiem";
        public static string col_KetQuaXQuang = "KetQuaXQuang";
        public static string col_KetQuaCT = "KetQuaCT";
        public static string col_KetQuaKhac = "KetQuaKhac";
        public static string col_MaChanDoanBenhChinh = "MaChanDoanBenhChinh";
        public static string col_ChanDoanBenhChinh = "ChanDoanBenhChinh";
        public static string col_MaChanDoanBenhKemTheo = "MaChanDoanBenhKemTheo";
        public static string col_ChanDoanBenhKemTheo = "ChanDoanBenhKemTheo";
        public static string col_MaPhauThuat = "MaPhauThuat";
        public static string col_TenPhauThuat = "TenPhauThuat";
        public static string col_MaThuThuat = "MaThuThuat";
        public static string col_TenThuThuat = "TenThuThuat";
        public static string col_MaThuoc = "MaThuoc";
        public static string col_TenThuoc = "TenThuoc";
        public static string col_PhuongPhapKhac = "PhuongPhapKhac";
        public static string col_MaTinhTrangNguoiBenh = "MaTinhTrangNguoiBenh";
        public static string col_TenTinhTrangNguoiBenh = "TenTinhTrangNguoiBenh";
        public static string col_BoTaiKham = "BoTaiKham";
        public static string col_TinhTrangKhac = "TinhTrangKhac";
        public static string col_MaHuongDieuTri = "MaHuongDieuTri";
        public static string col_TenHuongDieuTri = "TenHuongDieuTri";
        public static string col_SoToXQuang = "SoToXQuang";
        public static string col_SoToCT = "SoToCT";
        public static string col_SoToSieuAm = "SoToSieuAm";
        public static string col_SoToXetNghiem = "SoToXetNghiem";
        public static string col_SoToKhac = "SoToKhac";
        public static string col_TongSoTo = "TongSoTo";
        public static string col_MaNguoiGiao = "MaNguoiGiao";
        public static string col_TenNguoiGiao = "TenNguoiGiao";
        public static string col_MaNguoiNhan = "MaNguoiNhan";
        public static string col_TenNguoiNhan = "TenNguoiNhan";
        public static string col_MaBacSiDieuTri = "MaBacSiDieuTri";
        public static string col_TenBacSiDieuTri = "TenBacSiDieuTri";
        public static string col_MaBacSiKetThuc = "MaBacSiKetThuc";
        public static string col_TenBacSiKetThuc = "TenBacSiKetThuc";
        public static string col_MaLoaiBenhAn = "MaLoaiBenhAn";
        public static string col_NgayVaoVien = "NgayVaoVien";
        public static string col_MaBenhSu = "MaBenhSu";
        public static string col_TenBenhSu = "TenBenhSu";
        public static string col_BenhSuKhac = "BenhSuKhac";
        public static string col_NgayThuMayCuaBenh = "songaybenhkhoiphat";
        public static string col_MaChanDoanBanDauKemTheo = "MaChanDoanBanDauKemTheo";
        public static string col_TenChanDoanBanDauKemTheo = "TenChanDoanBanDauKemTheo";
        public static string col_MucDoKhac = "MucDoKhac";
        public static string col_HuongDieuTriKhac = "HuongDieuTriKhac";
        public static string col_ID = "ID";
        public static string col_NgayTao = "NgayTao";
        public static string col_TrangThai = "TrangThai";
        public static string col_SuDung = "SuDung";
        public static string col_MaKP = "MaKP";
        public static string col_MaDT = "MaDT";
        public static string col_UserUD = "UserUD";//
        public static string col_NgayUD = "NgayUD";//
        public static string col_UserID = "UserID";//
       

    }
}
