using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E00_Model 
{
    public  class cls_reportBenhAnNoiTru
    {
        // Lý do vào viện
        private string lyDoVaoVien;
        private string lyDoVaoVienVaoNgayThu;

        //Quá trình bệnh lý
        private string khoiPhatDienBien;
        private string trieuChungKemTheo;
        private string soCuuXuTriTuyenTruoc;
        private string benhSu;


        //Tiền sử bệnh
        private string theLucTuNhoDenNay;
        private string benhMacVaPhuongPhapDieuTri;
        private string diUng;
        private string yeuToKhoiPhat;
        private string mucDo;
        private string benhDaMac;
        private string benhLienQuanDiUng;


        //Quá trình sinh trưởng
        private string conThu1;
        private string conThu2;
        private string tienThai1;
        private string tienThai2;
        private string tienThai3;
        private string tienThai4;
        private string tinhTrangKhiSinh;
        private string canNangLucSinh;
        private string diTatBamSinh;
        private string phatTrienTinhThanVanDong;
        private string nuoiDuong;
        private string caiSuaThangThu;
        private string chamSoc;
        private string tiemChungTheoLich;


        //Khám bệnh - Toàn thân
        private string mach;
        private string nhietDo;
        private string huyetAp;
        private string nhipTho;
        private string canNang;
        private string chieuCao;
        private string vongDau;
        private string vongNguc;
        private string bMI;
        private string triGiac;
        private string glasgow;
        private string diem;
        private string niemMac;
        private string moi;
        private string matNuoc;
        private string dinhDuong;
        private string hachTuyenGiap;


        // Các cơ quan - tuần hoàn
        private string tim;
        private string machMau;
        private string tuoiMau;
        private string tuanHoan;


        // Các cơ quan - Hô hấp
        private string longNguc;
        private string phoi;
        private string hoHap;


        // Các cơ quan - Tiêu hóa
        private string bung;
        private string ganLach;
        private string tieuHoa;
        private string thanTietLieuSinhDuc;
        private string thanKinh;
        private string coXuongKhop;
        private string taiMuiHongRangHamMatMat;
        private string dinhDuongCacCoQuan;
        private string benhLy;



        // Các xét nghiệm CLS
        private string xetNghiem;
        private string xQuang;
        private string cTScanMRI;
        private string xetNghiemKhac;


        // Tóm tắt bệnh án
        private string lyDoNhapVien;
        private string lamSangPhatHien;
        private string tomTatHoiChung;
        private string tomTatBenhAn;


        // Chẩn đoán vào khoa điều trị
        private string maBenhChinh;
        private string tenBenhChinh;
        private string maBenhKemTheo;
        private string tenBenhkemTheo;
        private string phanBiet;


        //Tiên lượng
        private string tienLuong;


        //Hướng điều trị
        private string hoiSucHoHap;
        private string chongSocTruyenMau;
        private string khangSinhGiamDau;
        private string phauThuatThuThuat;
        private string huongDieuTri;
        private string ngayLamBenhAn;     
        private string bacSiLamBenhAn;


        //Tổng kết bệnh án
        private string benhLyVaDienBienLamSang;
        private string ketQuaXetNghiemCanLamSang;
        private string phuongPhapDieuTri;
        private string tinhTrangNguoiBenhRaVien;     
        private string huongDieuTriVaCheDoTiepTheo;


        //Hồ sơ phim ảnh
        private string soToXQuang;
        private string soToCTScanner;
        private string soToSieuAm;
        private string soToXetNghiem;
        private string soToKhac;
        private string soToToanBoHoSo;
        private string tenNguoiGiaoHoSo;
        private string tenNguoiNhanHoSo;
        private string tenBacSiDieuTri;










        public string LyDoVaoVien
        {
            get
            {
                return lyDoVaoVien;
            }

            set
            {
                lyDoVaoVien = value;
            }
        }
        
        public string LyDoVaoVienvaoNgayThu
        {
            get
            {
                return lyDoVaoVienVaoNgayThu;
            }

            set
            {
                lyDoVaoVienVaoNgayThu = value;
            }
        }
        public string KhoiPhatDienBien
        {
            get
            {
                return khoiPhatDienBien;
            }

            set
            {
                khoiPhatDienBien = value;
            }
        }
        
        public string TrieuChungKemTheo
        {
            get
            {
                return trieuChungKemTheo;
            }

            set
            {
                trieuChungKemTheo = value;
            }
        }
        
        public string SoCuuXuTriTuyenTruoc
        {
            get
            {
                return soCuuXuTriTuyenTruoc;
            }

            set
            {
                soCuuXuTriTuyenTruoc = value;
            }
        }
        
        public string BenhSu
        {
            get
            {
                return benhSu;
            }

            set
            {
                benhSu = value;
            }
        }
        
        public string TheLucTuNhoDenNay
        {
            get
            {
                return theLucTuNhoDenNay;
            }

            set
            {
                theLucTuNhoDenNay = value;
            }
        }
        
        public string BenhMacVaPhuongPhapDieuTri
        {
            get
            {
                return benhMacVaPhuongPhapDieuTri;
            }

            set
            {
                benhMacVaPhuongPhapDieuTri = value;
            }
        }
        
        public string DiUng
        {
            get
            {
                return diUng;
            }

            set
            {
                diUng = value;
            }
        }
        
        public string YeuToKhoiPhat
        {
            get
            {
                return yeuToKhoiPhat;
            }

            set
            {
                yeuToKhoiPhat = value;
            }
        }
        
        public string MucDo
        {
            get
            {
                return mucDo;
            }

            set
            {
                mucDo = value;
            }
        }
        
        public string BenhDaMac
        {
            get
            {
                return benhDaMac;
            }

            set
            {
                benhDaMac = value;
            }
        }
        
        public string BenhLienQuanDiUng
        {
            get
            {
                return benhLienQuanDiUng;
            }

            set
            {
                benhLienQuanDiUng = value;
            }
        }
        
        public string ConThu1
        {
            get
            {
                return conThu1;
            }

            set
            {
                conThu1 = value;
            }
        }
        public string ConThu2
        {
            get
            {
                return conThu2;
            }

            set
            {
                conThu2 = value;
            }
        }
        public string TienThai1
        {
            get
            {
                return tienThai1;
            }

            set
            {
                tienThai1 = value;
            }
        }
        public string TienThai2
        {
            get
            {
                return tienThai2;
            }

            set
            {
                tienThai2 = value;
            }
        }
        public string TienThai3
        {
            get
            {
                return tienThai3;
            }

            set
            {
                tienThai3 = value;
            }
        }
        public string TienThai4
        {
            get
            {
                return tienThai4;
            }

            set
            {
                tienThai4 = value;
            }
        }
        public string TinhTrangKhiSinh
        {
            get
            {
                return tinhTrangKhiSinh;
            }

            set
            {
                tinhTrangKhiSinh = value;
            }
        }
        
        public string CanNangLucSinh
        {
            get
            {
                return canNangLucSinh;
            }

            set
            {
                canNangLucSinh = value;
            }
        }
        public string DiTatBamSinh
        {
            get
            {
                return diTatBamSinh;
            }

            set
            {
                diTatBamSinh = value;
            }
        }
        
        public string PhatTrienTinhThanVanDong
        {
            get
            {
                return phatTrienTinhThanVanDong;
            }

            set
            {
                phatTrienTinhThanVanDong = value;
            }
        }
        
        public string NuoiDuong
        {
            get
            {
                return nuoiDuong;
            }

            set
            {
                nuoiDuong = value;
            }
        }
        
        public string CaiSuaThangThu
        {
            get
            {
                return caiSuaThangThu;
            }

            set
            {
                caiSuaThangThu = value;
            }
        }
        public string ChamSoc
        {
            get
            {
                return chamSoc;
            }

            set
            {
                chamSoc = value;
            }
        }
        
        public string TiemChungTheoLich
        {
            get
            {
                return tiemChungTheoLich;
            }

            set
            {
                tiemChungTheoLich = value;
            }
        }
        
        public string Mach
        {
            get
            {
                return mach;
            }

            set
            {
                mach = value;
            }
        }
        public string NhietDo
        {
            get
            {
                return nhietDo;
            }

            set
            {
                nhietDo = value;
            }
        }
        public string HuyetAp
        {
            get
            {
                return huyetAp;
            }

            set
            {
                huyetAp = value;
            }
        }
        public string NhipTho
        {
            get
            {
                return nhipTho;
            }

            set
            {
                nhipTho = value;
            }
        }
        public string CanNang
        {
            get
            {
                return canNang;
            }

            set
            {
                canNang = value;
            }
        }
        public string ChieuCao
        {
            get
            {
                return chieuCao;
            }

            set
            {
                chieuCao = value;
            }
        }
        public string VongDau
        {
            get
            {
                return vongDau;
            }

            set
            {
                vongDau = value;
            }
        }
        public string VongNguc
        {
            get
            {
                return vongNguc;
            }

            set
            {
                vongNguc = value;
            }
        }
        public string BMI
        {
            get
            {
                return bMI;
            }

            set
            {
                bMI = value;
            }
        }
        public string TriGiac
        {
            get
            {
                return triGiac;
            }

            set
            {
                triGiac = value;
            }
        }
        
        public string Glasgow
        {
            get
            {
                return glasgow;
            }

            set
            {
                glasgow = value;
            }
        }
        public string Diem
        {
            get
            {
                return diem;
            }

            set
            {
                diem = value;
            }
        }
        

        public string NiemMac
        {
            get
            {
                return niemMac;
            }

            set
            {
                niemMac = value;
            }
        }

        

        public string Moi
        {
            get
            {
                return moi;
            }

            set
            {
                moi = value;
            }
        }

        

        public string MatNuoc
        {
            get
            {
                return matNuoc;
            }

            set
            {
                matNuoc = value;
            }
        }

        

        public string DinhDuong
        {
            get
            {
                return dinhDuong;
            }

            set
            {
                dinhDuong = value;
            }
        }

        

        public string HachTuyenGiap
        {
            get
            {
                return hachTuyenGiap;
            }

            set
            {
                hachTuyenGiap = value;
            }
        }

        

        public string Tim
        {
            get
            {
                return tim;
            }

            set
            {
                tim = value;
            }
        }

        public string MachMau
        {
            get
            {
                return MachMau1;
            }

            set
            {
                MachMau1 = value;
            }
        }

        

        public string MachMau1
        {
            get
            {
                return machMau;
            }

            set
            {
                machMau = value;
            }
        }

        

        public string TuoiMau
        {
            get
            {
                return tuoiMau;
            }

            set
            {
                tuoiMau = value;
            }
        }

        

        public string TuanHoan
        {
            get
            {
                return tuanHoan;
            }

            set
            {
                tuanHoan = value;
            }
        }

        

        public string LongNguc
        {
            get
            {
                return longNguc;
            }

            set
            {
                longNguc = value;
            }
        }

        

        public string Phoi
        {
            get
            {
                return phoi;
            }

            set
            {
                phoi = value;
            }
        }

        

        public string HoHap
        {
            get
            {
                return hoHap;
            }

            set
            {
                hoHap = value;
            }
        }

        

        public string Bung
        {
            get
            {
                return bung;
            }

            set
            {
                bung = value;
            }
        }

        

        public string GanLach
        {
            get
            {
                return ganLach;
            }

            set
            {
                ganLach = value;
            }
        }

        

        public string TieuHoa
        {
            get
            {
                return tieuHoa;
            }

            set
            {
                tieuHoa = value;
            }
        }

        

        public string ThanTietLieuSinhDuc
        {
            get
            {
                return thanTietLieuSinhDuc;
            }

            set
            {
                thanTietLieuSinhDuc = value;
            }
        }

        

        public string ThanKinh
        {
            get
            {
                return thanKinh;
            }

            set
            {
                thanKinh = value;
            }
        }

        

        public string CoXuongKhop
        {
            get
            {
                return coXuongKhop;
            }

            set
            {
                coXuongKhop = value;
            }
        }

        

        public string TaiMuiHongRangHamMatMat
        {
            get
            {
                return taiMuiHongRangHamMatMat;
            }

            set
            {
                taiMuiHongRangHamMatMat = value;
            }
        }

        

        public string DinhDuongCacCoQuan
        {
            get
            {
                return dinhDuongCacCoQuan;
            }

            set
            {
                dinhDuongCacCoQuan = value;
            }
        }

        

        public string BenhLy
        {
            get
            {
                return benhLy;
            }

            set
            {
                benhLy = value;
            }
        }

        

        public string XetNghiem
        {
            get
            {
                return xetNghiem;
            }

            set
            {
                xetNghiem = value;
            }
        }

        

        public string XQuang
        {
            get
            {
                return xQuang;
            }

            set
            {
                xQuang = value;
            }
        }

        

        public string CTScanMRI
        {
            get
            {
                return cTScanMRI;
            }

            set
            {
                cTScanMRI = value;
            }
        }

        

        public string XetNghiemKhac
        {
            get
            {
                return xetNghiemKhac;
            }

            set
            {
                xetNghiemKhac = value;
            }
        }

        

        public string LyDoNhapVien
        {
            get
            {
                return lyDoNhapVien;
            }

            set
            {
                lyDoNhapVien = value;
            }
        }

        public string LamSangPhatHien
        {
            get
            {
                return lamSangPhatHien;
            }

            set
            {
                lamSangPhatHien = value;
            }
        }

        

        public string TomTatHoiChung
        {
            get
            {
                return tomTatHoiChung;
            }

            set
            {
                tomTatHoiChung = value;
            }
        }

        

        public string TomTatBenhAn
        {
            get
            {
                return tomTatBenhAn;
            }

            set
            {
                tomTatBenhAn = value;
            }
        }

        

        public string MaBenhChinh
        {
            get
            {
                return maBenhChinh;
            }

            set
            {
                maBenhChinh = value;
            }
        }

        public string TenBenhChinh
        {
            get
            {
                return tenBenhChinh;
            }

            set
            {
                tenBenhChinh = value;
            }
        }

        public string MaBenhKemTheo
        {
            get
            {
                return maBenhKemTheo;
            }

            set
            {
                maBenhKemTheo = value;
            }
        }
        public string TenBenhkemTheo
        {
            get
            {
                return tenBenhkemTheo;
            }

            set
            {
                tenBenhkemTheo = value;
            }
        }
        public string PhanBiet
        {
            get
            {
                return phanBiet;
            }

            set
            {
                phanBiet = value;
            }
        }

        

        public string TienLuong
        {
            get
            {
                return tienLuong;
            }

            set
            {
                tienLuong = value;
            }
        }

        

        public string HoiSucHoHap
        {
            get
            {
                return hoiSucHoHap;
            }

            set
            {
                hoiSucHoHap = value;
            }
        }

        public string ChongSocTruyenMau
        {
            get
            {
                return chongSocTruyenMau;
            }

            set
            {
                chongSocTruyenMau = value;
            }
        }

        public string KhangSinhGiamDau
        {
            get
            {
                return khangSinhGiamDau;
            }

            set
            {
                khangSinhGiamDau = value;
            }
        }

        public string PhauThuatThuThuat
        {
            get
            {
                return phauThuatThuThuat;
            }

            set
            {
                phauThuatThuThuat = value;
            }
        }

        public string HuongDieuTri
        {
            get
            {
                return huongDieuTri;
            }

            set
            {
                huongDieuTri = value;
            }
        }

        public string NgayLamBenhAn
        {
            get { return ngayLamBenhAn; }
            set { ngayLamBenhAn = value; }
        }

        public string BacSiLamBenhAn
        {
            get
            {
                return bacSiLamBenhAn;
            }

            set
            {
                bacSiLamBenhAn = value;
            }
        }

        public string BenhLyVaDienBienLamSang
        {
            get
            {
                return benhLyVaDienBienLamSang;
            }

            set
            {
                benhLyVaDienBienLamSang = value;
            }
        }

        

        public string KetQuaXetNghiemCanLamSang
        {
            get
            {
                return ketQuaXetNghiemCanLamSang;
            }

            set
            {
                ketQuaXetNghiemCanLamSang = value;
            }
        }

       

        public string PhuongPhapDieuTri
        {
            get
            {
                return phuongPhapDieuTri;
            }

            set
            {
                phuongPhapDieuTri = value;
            }
        }


        public string TinhTrangNguoiBenhRaVien
        {
            get { return tinhTrangNguoiBenhRaVien; }
            set { tinhTrangNguoiBenhRaVien = value; }
        }
        public string HuongDieuTriVaCheDoTiepTheo
        {
            get
            {
                return huongDieuTriVaCheDoTiepTheo;
            }

            set
            {
                huongDieuTriVaCheDoTiepTheo = value;
            }
        }

        

        public string SoToXQuang
        {
            get
            {
                return soToXQuang;
            }

            set
            {
                soToXQuang = value;
            }
        }

        public string SoToCTScanner
        {
            get
            {
                return soToCTScanner;
            }

            set
            {
                soToCTScanner = value;
            }
        }

        public string SoToSieuAm
        {
            get
            {
                return soToSieuAm;
            }

            set
            {
                soToSieuAm = value;
            }
        }

        public string SoToXetNghiem
        {
            get
            {
                return soToXetNghiem;
            }

            set
            {
                soToXetNghiem = value;
            }
        }

        public string SoToKhac
        {
            get
            {
                return soToKhac;
            }

            set
            {
                soToKhac = value;
            }
        }

        public string SoToToanBoHoSo
        {
            get
            {
                return soToToanBoHoSo;
            }

            set
            {
                soToToanBoHoSo = value;
            }
        }

        public string TenNguoiGiaoHoSo
        {
            get
            {
                return tenNguoiGiaoHoSo;
            }

            set
            {
                tenNguoiGiaoHoSo = value;
            }
        }

        public string TenNguoiNhanHoSo
        {
            get
            {
                return tenNguoiNhanHoSo;
            }

            set
            {
                tenNguoiNhanHoSo = value;
            }
        }

        public string TenBacSiDieuTri
        {
            get
            {
                return tenBacSiDieuTri;
            }

            set
            {
                tenBacSiDieuTri = value;
            }
        }

        
    }
}
