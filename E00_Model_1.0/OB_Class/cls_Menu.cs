using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.ComponentModel;
using System.Reflection;

namespace E00_Model
{
    
    public partial class cls_EnumMenu
    {
        public static string KyHieu_Menu_BenhAnDienTu = "BenhAnDienTu";
        public static string KyHieu_Menu_BaoCao = "BaoCao";

        public enum Menu_BenhAnDienTu
        {
            [Description("Phân quyền")]
            itePhanQuyen,
            [Description("Bệnh án điện tử")]
            iteBenhAnDienTu,
            [Description("Biên bản hội chẩn")]
            iteBienBanHoiChan,
            [Description("Phẫu thuật thủ thuật")]
            itePhauThuatThuThuat,
            [Description("Danh mục bệnh án")]
            iteDanhMucBenhAn
        }
        public enum Menu_BaoCao
        {
            [Description("D5. Nhà thuốc")]
            NhaThuoc_D05,
            [Description("D5.3 Thu tiền thuốc")]
            ThuTienThuoc_D0503,
            [Description("D5.8 Bảng kê xuất bán hàng")]
            BangKeBanHang_D0508,
            [Description("B20. Bảng kê thu viện phí")]
            BangKeVienPhi_B20,
            [Description("B20.7 Báo cáo thu viện phí chi tiết")]
            BCThuVienPhiCT_B2007,
            [Description("B20.9 Báo cáo thu chi ra viện")]
            BCThuChiRaVien_B2009,
            [Description("B21. Báo cáo tổng hợp")]
            BaoCaoTongHop_B21,
            [Description("B21.18. Báo cáo tổng hợp thu viện phí")]
            BCTHThuVienPhi_B2118
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
