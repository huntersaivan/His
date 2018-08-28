using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E00_API.Base.Interface;

namespace E00_API.Contract
{
    public class NhapVienInfo : IInfo<NhapVienInfo>
    {
        //**---------------------------------------------------

        #region Member

        #region Thông tin hành chính
        public int MaBenhAn { get; set; }
        public string MaBenhNhan { get; set; }
        public Int64 MaQuanLy { get; set; }
        public string HovaTenBN { get; set; }
        public DateTime NgaySinh { get; set; }
        public int NamSinh { get; set; }
        public string LoaiNamSinh { get; set; }
        public string NamLichSu { get; set; }
        public int TuoiBN { get; set; }
        public string DonViTuoi { get; set; }
        public string GioiTinh { get; set; }
        public string MaNgheNghiep { get; set; }
        public string MaDanToc { get; set; }
        public string MaQuocTich { get; set; }
        public string MaTinhThanh { get; set; }
        public string SoNha { get; set; }
        public string ThonPho { get; set; }
        public string MaPhuongXa { get; set; }
        public string QuanHuyen { get; set; }
        public string NoiLamViec { get; set; }
        public string HoTenMe { get; set; }
        public string HoTenBo { get; set; }
        public string VanHoaMe { get; set; }
        public string VanHoaBo { get; set; }
        public string MaNgheNghiepMe { get; set; }
        public string MaNgheNghiepBo { get; set; }
        public int NamSinhBo { get; set; }
        public int NamSinhMe { get; set; }
        public string NhomMauMe { get; set; }
        public string MaQLyMe { get; set; }
        public int LanSinh { get; set; }
        public string Para { get; set; }
        #endregion

        #region Thông tin nhập viên
        public Int64 MaTiepDon { get; set; }
        public DateTime NgayVaoVien { get; set; }
        public DateTime NgayVaoKhoa { get; set; }
        public string NhanBNTu { get; set; }
        public string NoiGioiThieu { get; set; }
        public string MaCoQuanGioiThieu { get; set; }
        public int LanNhapVien { get; set; }
        public string Khoa { get; set; }
        public string NhapKhoa { get; set; }
        public string DoiTuong { get; set; }
        public string MaTheBH { get; set; }
        public DateTime NgaySuDungTheBH { get; set; }
        public DateTime NgayHetHanTheBH { get; set; }
        public string MaBVDKKBaoHiem { get; set; }
        public bool MienChiTra { get; set; }
        public DateTime NgayMienChiTra { get; set; }
        public string MaNhapVien { get; set; }
        public string MaVaoVien { get; set; }
        public string LoaiNguoiThan { get; set; }
        public string TenNguoiThan { get; set; }
        public string DiaChiNguoiThan { get; set; }
        public string SoDienThoaiNT { get; set; }

        public string ChanDoanVaoKhoa { get; set; }
        public string TenChanDoanVaoKhoa { get; set; }
        public string ChanDoanNoiChuyen { get; set; }
        public string ChanDoanNoiChuyenName { get; set; }
        public string BenhKemTheo { get; set; }
        public string TenBenhKemTheo { get; set; }
        public string CDKKBCapCuu { get; set; }
        public string CDKKBCapCuuTen { get; set; }
        public string MaBacSy { get; set; }
        public string TinhCach { get; set; }
        public string Giuong { get; set; }
        public string IDGiuong { get; set; }
        public string SoLuuTru { get; set; }
        public int LoaiKhamChuaBenh { get; set; }
        public string GiayCV { get; set; }

        #region Apgar
        public int Diem1Phut { get; set; }
        public int Diem5Phut { get; set; }
        public int Diem10Phut { get; set; }
        public int CanNang { get; set; }
        public int ChieuCao { get; set; }
        public int VongDau { get; set; }
        public DateTime ThoiGianBong { get; set; }
        public string TĐVH { get; set; }
        public string OldKhoaPhong { get; set; }
        #endregion
        
        public int LoaiNhap { get; set; }
        #endregion

        #region Thông tin xuất Khoa     
        public string MaKP_Xuat { get; set; }
        public Int64 ID_XuatKhoa { get; set; }
        public Int64 ID_NhapKhoa { get; set; }
        public DateTime NgayXuatKhoa { get; set; }
        public int TongNgayOVien { get; set; }
        public string KetQuaDieuTri { get; set; }
        public string Trai { get; set; }
        public string MaBenhChinh { get; set; }
        public string TenBenhChinh { get; set; }
        public int TaiBien { get; set; }
        public bool IsTaiBien { get; set; }
        public bool IsGiaiPhau { get; set; }
        public int GiaiPhau { get; set; }
        public string MaNguyenNhanBenh { get; set; }
        public string TenNguyenNhanBenh { get; set; }
        public string MaBenhKemTheoXK { get; set; }
        public string TenBenhKemTheoXK { get; set; }
        public string MaBacSyXuatKhoa { get; set; }
        public string TrangThaiXuatKhoa { get; set; }
        public string ChuyenVien { get; set; }
        public string MaBenhVienChuyen { get; set; }
        public bool IsBienChung { get; set; }
        public bool IsHenTaiKham { get; set; }
        public int ThoiGianHen { get; set; }
        public int LoaiThoiGianHen { get; set; }
        public string  GhiChuHenLai { get; set; }
        public int SoToDieuTri { get; set; }
        public int SoToCT { get; set; }
        public int SoToDienTim { get; set; }
        public int SoToChamSoc { get; set; }
        public int SoToMRI { get; set; }
        public int SoToXN { get; set; }
        public int SoToXQ { get; set; }
        public int SoToSA { get; set; }
        public int SoToKhac { get; set; }
        public string SoLuuTruXuatKhoa { get; set; }
        #endregion

        #endregion

        //**---------------------------------------------------

        #region Constructor
        public NhapVienInfo()
        {
            #region Thông tin hành chính
            MaBenhAn = 1;
            MaBenhNhan = "";
            HovaTenBN = "";
            NgaySinh = DateTime.MinValue;
            NamSinh = 0;
            LoaiNamSinh = "0";
            TuoiBN = 0;
            DonViTuoi = "";
            GioiTinh = "0";
            MaNgheNghiep = "";
            MaDanToc = "25";
            MaQuocTich = "VN";
            NgayVaoVien = DateTime.Now;
            NgayVaoKhoa = DateTime.Now;
            MaTinhThanh = "";
            SoNha = "";
            ThonPho = "";
            QuanHuyen = "";
            MaPhuongXa = "";
            NoiLamViec = "";
            HoTenMe = "";
            HoTenBo = "";
            VanHoaMe = "";
            VanHoaBo = "";
            MaNgheNghiepMe = "";
            MaNgheNghiepBo = "";
            NamSinhBo = 0;
            NamSinhMe = 0;
            NhomMauMe = "";
            MaQLyMe = "";
            NamLichSu = "";
            #endregion

            #region Thông tin nhập viện
            NhanBNTu = "";
            LanSinh = 1;
            Para = "00000000";
            NoiGioiThieu = "";
            MaCoQuanGioiThieu = "";
            LanNhapVien = 1;
            Khoa = "";
            NhapKhoa = "";
            DoiTuong = "2";
            MaTheBH = "";
            MienChiTra = false;
            NgayMienChiTra = DateTime.MinValue;
            MaNhapVien = "";
            MaVaoVien = "";
            LoaiNguoiThan = "";
            TenNguoiThan = "";
            DiaChiNguoiThan = "";
            SoDienThoaiNT = "";
            MaTiepDon = 0;
            ChanDoanNoiChuyen = "";
            ChanDoanNoiChuyenName = "";
            ChanDoanVaoKhoa = "";
            TenChanDoanVaoKhoa = "";
            BenhKemTheo = "";
            TenBenhKemTheo = "";
            CDKKBCapCuu = "";
            MaBacSy = "";
            TinhCach = "0";
            MaQuanLy = 0;
            Giuong = "";
            IDGiuong = "";
            SoLuuTru = "";
            CDKKBCapCuuTen = "";
            NgayHetHanTheBH = DateTime.MinValue;
            NgaySuDungTheBH = DateTime.MinValue;
            MaBVDKKBaoHiem = "";
            LoaiKhamChuaBenh = 0;
            GiayCV = "";
            Diem1Phut = 0;
            Diem5Phut = 0;
            Diem10Phut = 0;
            CanNang = 0;
            ChieuCao = 0;
            VongDau = 0;
            ThoiGianBong = DateTime.MinValue;
            TĐVH = "";
            OldKhoaPhong = "";
            LoaiNhap = 0;
            #endregion

            #region Thông tin Xuất khoa
            MaKP_Xuat = "";
            ID_XuatKhoa = 0;
            ID_NhapKhoa = 0;
            NgayXuatKhoa = DateTime.Now;
            TongNgayOVien = 1;
            KetQuaDieuTri = "";
            Trai = "";
            MaBenhChinh = "";
            TenBenhChinh = "";
            TaiBien = 0;
            GiaiPhau = 0;
            IsTaiBien = false;
            IsGiaiPhau = false;
            MaNguyenNhanBenh = "";
            TenNguyenNhanBenh = "";
            TrangThaiXuatKhoa = "";
            MaBenhKemTheoXK = "";
            TenBenhKemTheoXK = "";
            ChuyenVien = "";
            MaBenhVienChuyen = "";
            MaBacSyXuatKhoa = "";
            IsHenTaiKham = false;
            IsBienChung = false;
            ThoiGianHen = 0;
            LoaiThoiGianHen = 0;
            GhiChuHenLai = "";
            SoToDieuTri = 0;
            SoToCT = 0;
            SoToDienTim = 0;
            SoToChamSoc = 0;
            SoToMRI = 0;
            SoToXN = 0;
            SoToXQ = 0;
            SoToSA = 0;
            SoToKhac = 0;
            SoLuuTruXuatKhoa = "";
            #endregion
        }
        #endregion

        //**---------------------------------------------------

        #region Protected/Method
        public object ID { get { return ""; } set { } }
        public void Copy(NhapVienInfo info)
        {
            #region Thông tin hành chính
            MaBenhAn = info.MaBenhAn;
            MaBenhNhan = info.MaBenhNhan;
            HovaTenBN = info.HovaTenBN;
            NgaySinh = info.NgaySinh;
            NamSinh = info.NamSinh;
            LoaiNamSinh = info.LoaiNamSinh;
            TuoiBN = info.TuoiBN;
            DonViTuoi = info.DonViTuoi;
            GioiTinh = info.GioiTinh;
            MaNgheNghiep = info.MaNgheNghiep;
            MaDanToc = info.MaDanToc;
            MaQuocTich = info.MaQuocTich;
            NgayVaoVien = info.NgayVaoVien;
            NgayVaoKhoa = info.NgayVaoKhoa;
            MaTinhThanh = info.MaTinhThanh;
            SoNha = info.SoNha;
            ThonPho = info.ThonPho;
            QuanHuyen = info.QuanHuyen;
            MaPhuongXa = info.MaPhuongXa;
            NoiLamViec = info.NoiLamViec;
            HoTenMe = info.HoTenMe;
            HoTenBo = info.HoTenBo;
            VanHoaMe = info.VanHoaMe;
            VanHoaBo = info.VanHoaBo;
            MaNgheNghiepMe = info.MaNgheNghiepMe;
            MaNgheNghiepBo = info.MaNgheNghiepBo;
            NamSinhMe = info.NamSinhMe;
            NamSinhBo = info.NamSinhBo;
            NhomMauMe = info.NhomMauMe;
            MaQLyMe = info.MaQLyMe;
            LanSinh = info.LanSinh;
            Para = info.Para;
            NamLichSu = info.NamLichSu;
            #endregion

            #region Thông tin nhập viện
            NhanBNTu = info.NhanBNTu;
            NoiGioiThieu = info.NoiGioiThieu;
            MaCoQuanGioiThieu = info.MaCoQuanGioiThieu;
            LanNhapVien = info.LanNhapVien;
            Khoa = info.Khoa;
            info.NhapKhoa = info.NhapKhoa;
            DoiTuong = info.DoiTuong;
            MaTheBH = info.MaTheBH;
            MienChiTra = info.MienChiTra;
            NgayMienChiTra = info.NgayMienChiTra;
            MaNhapVien = info.MaNhapVien;
            MaVaoVien = info.MaVaoVien;
            LoaiNguoiThan = info.LoaiNguoiThan;
            TenNguoiThan = info.TenNguoiThan;
            DiaChiNguoiThan = info.DiaChiNguoiThan;
            SoDienThoaiNT = info.SoDienThoaiNT;
            MaTiepDon = info.MaTiepDon;
            ChanDoanNoiChuyen = info.ChanDoanNoiChuyen;
            ChanDoanNoiChuyenName = info.ChanDoanNoiChuyenName;
            ChanDoanVaoKhoa = info.ChanDoanVaoKhoa;
            TenChanDoanVaoKhoa = info.TenChanDoanVaoKhoa;
            BenhKemTheo = info.BenhKemTheo;
            TenBenhKemTheo = info.TenBenhKemTheo;
            CDKKBCapCuu = info.CDKKBCapCuu;
            MaBacSy = info.MaBacSy;
            TinhCach = info.TinhCach;
            MaQuanLy = info.MaQuanLy;
            Giuong = info.Giuong;
            IDGiuong = info.IDGiuong;
            SoLuuTru = info.SoLuuTru;
            CDKKBCapCuuTen = info.CDKKBCapCuuTen;
            NgayHetHanTheBH = info.NgayHetHanTheBH;
            NgaySuDungTheBH = info.NgaySuDungTheBH;
            MaBVDKKBaoHiem = info.MaBVDKKBaoHiem;
            LoaiKhamChuaBenh = info.LoaiKhamChuaBenh;
            GiayCV = info.GiayCV;

            Diem1Phut = info.Diem1Phut;
            Diem5Phut = info.Diem5Phut;
            Diem10Phut = info.Diem10Phut;
            CanNang = info.CanNang;
            ChieuCao = info.ChieuCao;
            VongDau = info.VongDau;
            ThoiGianBong = info.ThoiGianBong;
            TĐVH = info.TĐVH;
            OldKhoaPhong = info.OldKhoaPhong;
            LoaiNhap = info.LoaiNhap;
            #endregion

            #region Thông tin xuất khoa
            MaKP_Xuat = info.MaKP_Xuat;
            ID_XuatKhoa = info.ID_XuatKhoa;
            ID_NhapKhoa = info.ID_NhapKhoa;
            NgayXuatKhoa = info.NgayXuatKhoa;
            TongNgayOVien = info.TongNgayOVien;
            KetQuaDieuTri = info.KetQuaDieuTri;
            Trai = info.Trai;
            MaBenhChinh = info.MaBenhChinh;
            TenBenhChinh = info.TenBenhChinh;
            TaiBien = info.TaiBien;
            GiaiPhau = info.GiaiPhau;
            IsTaiBien = info.IsTaiBien;
            IsGiaiPhau = info.IsGiaiPhau;
            MaNguyenNhanBenh = info.MaNguyenNhanBenh;
            TenNguyenNhanBenh = info.TenNguyenNhanBenh;
            TrangThaiXuatKhoa = info.TrangThaiXuatKhoa;
            MaBenhKemTheoXK = info.MaBenhKemTheoXK;
            TenBenhKemTheoXK = info.TenBenhKemTheoXK;
            ChuyenVien = info.ChuyenVien;
            MaBenhVienChuyen = info.MaBenhVienChuyen;
            IsBienChung = info.IsBienChung;
            MaBacSyXuatKhoa = info.MaBacSyXuatKhoa;
            IsHenTaiKham = info.IsHenTaiKham;
            ThoiGianHen = info.ThoiGianHen;
            LoaiThoiGianHen = info.LoaiThoiGianHen;
            GhiChuHenLai = info.GhiChuHenLai;
            SoToDieuTri = info.SoToDieuTri;
            SoToCT = info.SoToCT;
            SoToDienTim = info.SoToDienTim;
            SoToChamSoc = info.SoToChamSoc;
            SoToMRI = info.SoToMRI;
            SoToXN = info.SoToXN;
            SoToXQ = info.SoToXQ;
            SoToSA = info.SoToSA;
            SoToKhac = info.SoToKhac;
            SoLuuTruXuatKhoa = info.SoLuuTruXuatKhoa;
            #endregion
        }
        #endregion

        //**---------------------------------------------------
    }
}
