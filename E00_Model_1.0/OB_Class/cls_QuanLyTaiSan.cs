using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace E00_Model
{
    public partial class cls_QuanLyTaiSan
    {
        public static string _loaiTaiSan = "LoaiTaiSan";
        public static string _tenLoaiTaiSan = "Danh Mục Loại Tài Sản ";
        public static string _lyDoTangGiam = "LyDoTangGiam";
        public static string _tenLyDoTangGiam = "Danh Mục Lý Do Tăng Giảm";
        public static string _ngoaiTe = "NgoaiTe";
        public static string _tenNgoaiTe = "Danh Mục Ngoại Tệ";
        public static string _boPhanSuDung = "BoPhanSuDung";
        public static string _tenBoPhanSuDung = "Danh Mục Bộ Phận Sử Dụng";
        public static string _taiKhoan = "TaiKhoan";
        public static string _tenTaiKhoan = "Danh Mục Tài Khoản";
        public static string _danhMucPhi = "DanhMucPhi";
        public static string _tenDanhMucPhi = "Danh Mục Phí";
        public static string _nguonVon = "NguonVon";
        public static string _tenNguonVon = "Danh Mục Nguồn Vốn";
        public static string _phanNhom = "PhanNhom";
        public static string _tenPhanNhom = "Danh Mục Phân nhóm";
        public static string _nguonKinhPhi = "NguonKinhPhi";
        public static string _tenNguonKinhPhi = "Danh Mục Nguồn Kinh Phí";
        public static string _chuong = "Chuong";
        public static string _tenChuong = "Danh Mục Chương";
        public static string _mucTieuMuc = "MucTieuMuc";
        public static string _tenMucTieuMuc = "Danh Mục Mục - Tiểu Mục";
        public static string _nghiepVu = "NghiepVu";
        public static string _tenNghiepVu = "Danh Mục Nghiệp Vụ";
        public static string _coCauVon = "CoCauVon";
        public static string _tenCoCauVon = "Danh Mục Cơ Cấu Vốn";
        public static string _taiKhoanNganHang = "TaiKhoanNganHang";
        public static string _tenTaiKhoanNganHang = "Danh Mục Tài Khoản Ngân Hàng";
        public static string _capPhat = "CapPhat";
        public static string _tenCapPhat = "Danh Mục Cấp Phát";
        public static string _danhMucKhoan = "DanhMucKhoan";
        public static string _tenDanhMucKhoan = "Danh Mục Khoản";
        public static string _hoatDongSuNghiep = "HoatDongSuNghiep";
        public static string _tenHoatDongSuNghiep = "Danh Mục Hoạt Động Sự Nghiệp";
        public static string _maThongKe = "MaThongKe";
        public static string _tenMaThongKe = "Danh Mục Mã Thống Kê";
        public static string _vuViecCongTrinh = "VuViecCongTrinh";
        public static string _tenVuViecCongTrinh = "Danh Mục Vụ Việc - Công Trình";
        public static string _kieuKH = "KieuKH";
        public static string _tenKieuKH = "Kiểu KH";


        public DataTable Load_DanhMucQuanLyTaiSan()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Ma");
                dt.Columns.Add("Ten");

                DataRow row = dt.NewRow();
                row["Ma"] = _loaiTaiSan;
                row["Ten"] = _tenLoaiTaiSan;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _lyDoTangGiam;
                row["Ten"] = _tenLyDoTangGiam;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _ngoaiTe;
                row["Ten"] = _tenNgoaiTe;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _boPhanSuDung;
                row["Ten"] = _tenBoPhanSuDung;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _taiKhoan;
                row["Ten"] = _tenTaiKhoan;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _danhMucPhi;
                row["Ten"] = _tenDanhMucPhi;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _nguonVon;
                row["Ten"] = _tenNguonVon;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _phanNhom;
                row["Ten"] = _tenPhanNhom;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _nguonKinhPhi;
                row["Ten"] = _tenNguonKinhPhi;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _chuong;
                row["Ten"] = _tenChuong;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _mucTieuMuc;
                row["Ten"] = _tenMucTieuMuc;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _nghiepVu;
                row["Ten"] = _tenNghiepVu;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _coCauVon;
                row["Ten"] = _tenCoCauVon;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _taiKhoanNganHang;
                row["Ten"] = _tenTaiKhoanNganHang;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _capPhat;
                row["Ten"] = _tenCapPhat;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _danhMucKhoan;
                row["Ten"] = _tenDanhMucKhoan;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _hoatDongSuNghiep;
                row["Ten"] = _tenHoatDongSuNghiep;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _maThongKe;
                row["Ten"] = _tenMaThongKe;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _vuViecCongTrinh;
                row["Ten"] = _tenVuViecCongTrinh;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["Ma"] = _kieuKH;
                row["Ten"] = _tenKieuKH;
                dt.Rows.Add(row);

                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
