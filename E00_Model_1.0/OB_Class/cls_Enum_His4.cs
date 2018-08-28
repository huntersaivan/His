using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.ComponentModel;
using System.Reflection;

namespace E00_Model
{
    public partial class cls_Enum_His4
    {
        public enum Menu_BenhAnDienTu_4
        {
            [Description("Bệnh án điện tử")]
            btnBenhAnDienTu,
            [Description("Tờ điều trị")]
            btnToDieuTri,
            [Description("Khám sức khỏe")]
            btnKhamSucKhoe,
            [Description("Danh mục")]
            btnDanhMuc,
            [Description("Danh mục chung")]
            btnDanhMucChung,
            [Description("Danh mục chi tiết")]
            btnDanhMucChiTiet,
            [Description("Danh mục bảng dữ liệu")]
            btnDanhMucBangDuLieu,
            [Description("Tiện ích")]
            btnTienIch,
            [Description("Tạo số liệu")]
            btnTaoSolieu
        }

        public enum Menu_VienPhi_4
        {
            [Description("Thanh toán ngoại trú")]
            btnThanhToanNgoaiTru,
            [Description("Thu tạm ứng")]
            btnThuTamUng,
            [Description("Quyển sổ")]
            btnQuyenSo,
            [Description("Chọn sổ 2")]
            btnChonSo2,
            [Description("Tìm hóa đơn")]
            btnTimHoaDon,
            [Description("Danh mục giá viện phí chi tiết")]
            btnDanhMucGiaVienPhiChiTiet          
        }

        public enum Menu_QuanlyPhongGiuong
        {
            [Description("Quản lý giường")]
            btnQuanLyGiuong,
            [Description("Chuyển giường")]
            btnChuyenGiuong,
            [Description("Khai báo phòng")]
            btnKhaiBaoPhong,
            [Description("Khai báo giường")]
            btnKhaiBaoGiuong,
            [Description("Khai báo loại giường")]
            btnKhaiBaoLoaiGiuong,
            [Description("Danh sách Blacklist")]
            btnDanhSachBlackList,
            [Description("Thống kê")]
            btnThongKe
        }

        public enum btnBaoDongMain
        {
            [Description("Báo động")]
            btnBaoDong,
            [Description("Danh mục mức độ")]
            btnDMMucDo,
            [Description("Danh mục báo động")]
            btnDMBaoDong,
            [Description("Danh mục trạng thái báo động")]
            btnDMTrangThaiBaoDong,
            [Description("Danh mục phòng báo động")]
            btnDMPhongBaoDong
        }
    }
}
