using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E00_Model
{
    public static class cls_TaiSan_DanhMuc
    {

        #region Cấu trúc bảng danh mục tài sản
        //Thực hiện: Nguyễn Văn Long (Long Dài) 14/05/2018
        
        public static string tb_TenBang = "TAISAN_DANHMUC";

        public static string col_ID = "ID";
        public static string col_Ma = "MA";
        public static string col_Ten = "TEN";
        public static string col_KyHieu = "KYHIEU";
        public static string col_MaLoai = "MALOAI";
        public static string col_TenLoai = "TENLOAI";
        public static string col_NuocSanXuat = "NUOCSANXUAT";
        public static string col_NamSanXuat = "NAMSANXUAT";
        public static string col_MaVachSanXuat = "MAVACHSANXUAT";
        public static string col_QuyCach = "QUYCACH";
        public static string col_TaiLieu = "TAILIEU";
        public static string col_TamNgung = "TAMNGUNG";
        public static string col_UserID = "USERID";
        public static string col_NgayTao = "NGAYTAO";
        public static string col_UserUD = "USERUD";
        public static string col_NgayUD = "NGAYUD";
        public static string col_MachineID = "MACHINEID"; 

        #endregion

        #region Thêm đơn vị quản lý
        //Người yêu cầu: Nguyễn Trần Thanh Hải
        //Thực hiện: Nguyễn Văn Lợi 15/06/2018

        public static string col_MaKPQuanLy = "MAKPQUANLY";
        public static string col_TenKPQuanLy = "TENKPQUANLY";

        #endregion

    }
}
