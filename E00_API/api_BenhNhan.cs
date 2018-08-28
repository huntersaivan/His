using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using E00_Common;
using E00_Model;
using System.Data.OracleClient;
using System.Globalization;
using E00_BUS;

namespace E00_API
{
    public partial class api_BenhNhan
    {
        #region Biến toàn cục
        private bus_BenhNhan _busBenhNhan = new bus_BenhNhan();
        private bus_Duoc _busDuoc = new bus_Duoc();
        #endregion

        #region Khởi tạo
        public api_BenhNhan()
        {

        }

        #endregion

        #region Phương thức
        public int NamSinh(string ngayvao, int ituoi, int iloai)
        {
            return _busBenhNhan.NamSinh(ngayvao, ituoi, iloai);
        }
        #region InsertData

        public bool Insert_XuatVien(string m_mabn, decimal m_maql, string m_makp, string m_ngay, int m_ketqua, int m_ttlucrv, string m_chandoan, string m_maicd, string m_mabs, string m_soluutru, int m_bienchung, int m_taibien, int m_giaiphau, int m_userid, int m_matrai)
        {
            try
            {
                return _busBenhNhan.Insert_XuatVien(m_mabn, m_maql, m_makp, m_ngay, m_ketqua, m_ttlucrv, m_chandoan, m_maicd, m_mabs, m_soluutru, m_bienchung, m_taibien, m_giaiphau, m_userid, m_matrai);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region UpdateData
        public bool UpdateOrInsertDThucXuat(string mmyy, decimal id, decimal sttt, int maDoiTuong, int maKho, int maBD, decimal soLuong, decimal stt, decimal giaBan, decimal viTri)
        {
            if (_busDuoc.Update_D_ThucXuat(mmyy, id, sttt, maDoiTuong, maKho, maBD, soLuong, stt, giaBan, viTri))
            {
                return _busDuoc.Insert_D_ThucXuat(mmyy, id, sttt, maDoiTuong, maKho, maBD, soLuong, stt, giaBan, viTri);
            }
            return false;
        }

        public bool Update_XuatVien(string m_mabn, decimal m_maql, string m_makp, string m_ngay, int m_ketqua, int m_ttlucrv, string m_chandoan, string m_maicd, string m_mabs, string m_soluutru, int m_bienchung, int m_taibien, int m_giaiphau, int m_userid, int m_matrai)
        {
            try
            {
                return _busBenhNhan.Update_XuatVien(m_mabn, m_maql, m_makp, m_ngay, m_ketqua, m_ttlucrv, m_chandoan, m_maicd, m_mabs, m_soluutru, m_bienchung, m_taibien, m_giaiphau, m_userid, m_matrai);
            }
            catch
            {
                return false;
            }
        }


        #endregion


        #region LoadData

        public DataTable Get_DanhSachBenhNhanXuatVien()
        {
            return _busBenhNhan.Get_DanhSachBenhNhanXuatVien();
        }
        public DataTable GetDanhMucGiuong()
        {
            return _busBenhNhan.GetDanhMucGiuong();
        }

        public DataTable GetDanhMucDoiTuong(bool BSO)
        {
            try
            {
                string sql = "";
                if (BSO)
                {
                    sql = cls_DoiTuong.col_MaDoiTuong + " <> 1";
                }
                DataTable ret = _busBenhNhan.GetDanhMucDoiTuong();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable GetDanhMucKhoaPhongBenhVien(string maKP, string loai)
        {
            try
            {
                string sql = cls_BTDKP_BV.col_MaKP + " = '" + maKP + "' " + (loai != "" ? " and loai = '" + loai + "'" : "");

                DataTable ret = _busBenhNhan.GetDanhMucKhoaPhongBenhVien();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucKhoaPhongBenhVienDen(string maKP, string loai)
        {
            try
            {
                string sql = cls_BTDKP_BV.col_MaKP + " <> '" + maKP + "' and loai = '" + loai + "' and makp <> '01'";

                DataTable ret = _busBenhNhan.GetDanhMucKhoaPhongBenhVien();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucKhoaPhongBenhVienNgoaiTru(string maKP, string loai)
        {
            try
            {
                string sql = cls_BTDKP_BV.col_MaKP + " <> '" + maKP + "' and loai = '" + loai + "'";

                DataTable ret = _busBenhNhan.GetDanhMucKhoaPhongBenhVien();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucNoiChuyenDen(string maKP)
        {
            try
            {
                string sql = cls_BTDKP_BV.col_MaKP + " <> '" + maKP + "' and loai = 0";

                DataTable ret = _busBenhNhan.GetDanhMucKhoaPhongBenhVien();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucNoiChuyenDenXuatVien(string maKP)
        {
            try
            {
                string sql = "";
                if (maKP != "")
                {
                    string s = maKP.Replace(",", "','");
                    sql = cls_BTDKP_BV.col_MaKP + " <> '01' and loai = 0 and makp in ('"+ s.Substring(0, s.Length - 3) +"')";
                }
                else
                {
                    sql = cls_BTDKP_BV.col_MaKP + " <> '01' and loai = 0";
                    
                }

                DataTable ret = _busBenhNhan.GetDanhMucKhoaPhongBenhVien();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucICD10()
        {
            return _busBenhNhan.GetDanhMucICD10();
        }

        public DataTable GetDanhMucBenhAnBenhVien(string maBA)
        {
            try
            {
                string sql = "";
                if (!string.IsNullOrEmpty(maBA))
                {
                    sql = cls_DMBenhAn_BV.col_MABA + " in (" + maBA + ") and loaiba = 1";
                }
                else
                {
                    sql = " loaiba = 1 ";
                }

                DataTable ret = _busBenhNhan.GetDanhMucBenhAnBenhVien();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucNgheNghiepBenhVien(string maNNBO, bool isTreEm16, bool isTreEm6)
        {
            try
            {
                string sql = "";
                if (!string.IsNullOrEmpty(maNNBO) && !isTreEm16 && isTreEm6)
                {
                    sql = cls_BTDNN_BV.col_MANNBO + " = '" + maNNBO + "'";
                }
                else if (!string.IsNullOrEmpty(maNNBO) && !isTreEm16 && !isTreEm6)
                {
                    sql = cls_BTDNN_BV.col_MANNBO + " in (" + maNNBO + ")";
                }
                else if (!string.IsNullOrEmpty(maNNBO) && isTreEm16 && !isTreEm6)
                {
                    sql = cls_BTDNN_BV.col_MANNBO + " <> '" + maNNBO + "'";
                }
                else
                {
                    sql = " ";
                }

                DataTable ret = _busBenhNhan.GetDanhMucNgheNghiepBenhVien();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucDanToc()
        {
            return _busBenhNhan.GetDanhMucDanToc();
        }

        public DataTable GetDanhMucTinhThanh()
        {
            return _busBenhNhan.GetDanhMucTinhThanh();
        }

        public DataTable GetDanhMucQuanHuyen(string maTT)
        {
            try
            {
                string sql = "";
                if (!string.IsNullOrEmpty(maTT))
                {
                    sql = cls_BoTuDienQuanHuyen.col_MaTT + " = '" + maTT + "'";
                }

                DataTable ret = _busBenhNhan.GetDanhMucQuanHuyen();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucPhuongXa(string maQU)
        {
            try
            {
                string sql = "";
                if (!string.IsNullOrEmpty(maQU))
                {
                    sql = cls_BoTuDienPhuongXa.col_MaQu + " = '" + maQU + "'";
                }

                DataTable ret = _busBenhNhan.GetDanhMucPhuongXa();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucQuocGia()
        {
            return _busBenhNhan.GetDanhMucQuocGia();
        }

        public DataTable GetDanhMucDenTu()
        {
            return _busBenhNhan.GetDanhMucDenTu();
        }

        public DataTable GetDanhMucNhanTu()
        {
            return _busBenhNhan.GetDanhMucNhanTu();
        }

        public DataTable GetDanhMucKetQua()
        {
            return _busBenhNhan.GetDanhMucKetQua();
        }

        public DataTable GetDanhMucTinhTrangXuatKhoa()
        {
            return _busBenhNhan.GetDanhMucTinhTrangXuatKhoa();
        }

        public DataTable GetDanhMucBacSi(string maNV, string maNghiViec)
        {
            try
            {
                string sql = "";
                if (!string.IsNullOrEmpty(maNV))
                {
                    sql = cls_BacSi.col_NHOM + " not in  (" + maNV + "," + maNghiViec + ")";
                }

                DataTable ret = _busBenhNhan.GetDanhMucBacSi();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucBacSiTheoKhoaPhong(string maKP)
        {
            try
            {
                string sql = "";
                if (!string.IsNullOrEmpty(maKP))
                {
                    sql = "makp = '" +maKP+ "'";
                }

                DataTable ret = _busBenhNhan.GetDanhMucBacSi();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucLoaiBenhVien()
        {
            return _busBenhNhan.GetDanhMucLoaiBenhVien();
        }

        public DataTable GetDanhMucNhomMau()
        {
            return _busBenhNhan.GetDanhMucNhomMau();
        }

        public DataTable GetDanhMucTenVien(string maBV, string maLoai, string maBV2)
        {
            try
            {
                string sql = "";
                if (maBV != "" && maLoai != "")
                {
                    sql = " substr(maloai,1,1)='2' and mabv like '" + maBV + "%'" + " and mabv<>'" + maBV2 + "'";
                }
                else if (maBV != "" && maLoai == "")
                {
                    sql = "  mabv like '" + maBV + "%'" + " and mabv<>'" + maBV2 + "'";
                }
                else
                {

                }

                DataTable ret = _busBenhNhan.GetDanhMucTenVien();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucBenhNhan(string maBN)
        {
            try
            {
                string sql = "";

                DataTable ret = _busBenhNhan.GetDanhMucBenhNhan(maBN);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetHCNHI(string maBN)
        {
            try
            {
                string sql = "";
                //if (maBN != "")
                //{
                //    sql = "  mabn ='" + maBN + "'";
                //}
                //else
                //{

                //}

                DataTable ret = _busBenhNhan.GetHCNHI(maBN);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetHCSoSinh(string maBN)
        {
            try
            {
                string sql = "";
                //if (maBN != "")
                //{
                //    sql = "  mabn ='" + maBN + "'";
                //}
                //else
                //{

                //}

                DataTable ret = _busBenhNhan.GetHCSoSinh(maBN);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetBenhAnDT(string loaiBA, string maBN)
        {
            try
            {
                string sql = "";
                //if (loaiBA != "" && maBN != "")
                //{
                //    sql = "  loaiba ='" + loaiBA + "' and mabn = '" + maBN + "'";
                //}
                //else if (loaiBA != "" && maBN == "")
                //{
                //    sql = "  loaiba ='" + loaiBA + "'";
                //}

                DataTable ret = _busBenhNhan.GetBenhAnDT( maBN);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetBenhAnDT2(string maBN)
        {
            try
            {
                string sql = "";
                //if (loaiBA != "" && maBN != "")
                //{
                //    sql = "  loaiba ='" + loaiBA + "' and mabn = '" + maBN + "'";
                //}
                //else if (loaiBA != "" && maBN == "")
                //{
                //    sql = "  loaiba ='" + loaiBA + "'";
                //}

                DataTable ret = _busBenhNhan.GetBenhAnDT2(maBN);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinTiepDonTheoNgay(string maBN, string ngay, string mmyy)
        {
            return _busBenhNhan.GetThongTinTiepDonTheoNgay(maBN, ngay, mmyy);
        }

        public DataTable GetBenhAnDT(string loaiBA, decimal maQL)
        {
            try
            {
                string sql = "";
                //if (loaiBA != "" && maQL != 0)
                //{
                //    sql = "  loaiba ='" + loaiBA + "' and maql = '" + maQL + "'";
                //}

                DataTable ret = _busBenhNhan.GetBenhAnDT3(maQL);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucQuanHe(decimal maQL)
        {
            try
            {
                string sql = "";


                DataTable ret = _busBenhNhan.GetDanhMucQuanHe(maQL);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinQuanHeTheoThang(decimal maQL, string mmyy)
        {
            return _busBenhNhan.GetThongTinQuanHeTheoThang(maQL, mmyy);
        }

        public DataTable GetThongTinBHYTTheoThang(decimal maQL, string mmyy)
        {
            return _busBenhNhan.GetThongTinBHYTTheoThang(maQL, mmyy);
        }

        public DataTable GetThongTinKhamThaiTheoThang(decimal maQL, string mmyy)
        {
            return _busBenhNhan.GetThongTinKhamThaiTheoThang(maQL, mmyy);
        }

        public DataTable GetThongTinBHYT(decimal maQL)
        {
            try
            {
                string sql = "";


                DataTable ret = _busBenhNhan.GetThongTinBHYT(maQL);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinKhamThai(long maQL)
        {
            try
            {
                string sql = "  maql =" + maQL;


                DataTable ret = _busBenhNhan.GetThongTinKhamThai();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinNoiGioiThieu(long maQL)
        {
            try
            {
                string sql = "";


                DataTable ret = _busBenhNhan.GetDanhMucNoiGioiThieu(maQL);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetThongTinTiepDon(string maBN, string mmyy)
        {
            return _busBenhNhan.GetThongTinTiepDon(maBN, mmyy);
        }

        public DataTable GetThongTinSanKhoa(long maQL)
        {
            try
            {
                string sql = "  maql =" + maQL;


                DataTable ret = _busBenhNhan.GetThongTinSanKhoa();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinNhapKhoa(string maKP, long maQL)
        {
            try
            {
                string sql = "";
                if (maKP != "")
                {
                    sql = "  makp ='" + maKP + "' and maql = " + maQL;
                }

                DataTable ret = _busBenhNhan.GetThongTinNhapKhoa(maKP, maQL);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinNhapKhoaTheoNgay(string maKP, long maQL, string ngay)
        {
            try
            {
                string sql = "";
                if (maKP != "" && ngay != "")
                {
                    sql = "  makp ='" + maKP + "' and maql = " + maQL + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay + "'";
                }

                DataTable ret = _busBenhNhan.GetThongTinNhapKhoaTheoNgay( maKP, maQL, ngay);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinNhapKhoaTheoMaQL(long maQL)
        {
            try
            {
                string sql = "";

                DataTable ret = _busBenhNhan.GetThongTinNhapKhoaTheoMaQL( maQL);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinXuatKhoa(long id)
        {
            try
            {
                string sql = "";

                DataTable ret = _busBenhNhan.GetThongTinXuatKhoa(id);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucCDNguyenNhan(long id)
        {
            try
            {
                string sql = " id = " + id;

                DataTable ret = _busBenhNhan.GetDanhMucCDNguyenNhan();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucCDkemTheo(long id)
        {
            try
            {
                string sql = " loai = 3 and  id = " + id;

                DataTable ret = _busBenhNhan.GetDanhMucCDkemTheo();
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDanhMucChuyenVien(long maQL)
        {
            try
            {
                string sql = "";

                DataTable ret = _busBenhNhan.GetDanhMucChuyenVien(maQL);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinXuatVien(long maQL)
        {
            try
            {
                string sql = ""; ;

                DataTable ret = _busBenhNhan.GetThongTinXuatVien(maQL);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinBHYT(string maBN, string ngay)
        {
            try
            {

                string sql = "";

                DataTable ret = _busBenhNhan.GetThongTinBHYT2(maBN, ngay);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetThongTinBHYT3(string maBN)
        {
            try
            {

                string sql = "";

                DataTable ret = _busBenhNhan.GetThongTinBHYT3(maBN);
                if (ret.Rows.Count > 0)
                {
                    ret = ret.Select(sql).CopyToDataTable();
                }

                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDataNgayTienThuoc(string maBN, long maQL, string mmyy)
        {
            return _busBenhNhan.GetDataNgayTienThuoc(maBN, maQL, mmyy);
        }

        public DataTable GetTongSoLuongTienThuoc(string maBN, long maQL, string mmyy, string ngay)
        {
            return _busBenhNhan.GetTongSoLuongTienThuoc(maBN, maQL, mmyy, ngay);
        }

        public DataTable GetMaKPHienDien(long maQL, string maKP)
        {
            return _busBenhNhan.GetMaKPHienDien(maQL, maKP);
        }

        public DataTable GetDaTaThuocBHYTLL(int nhom, long maQL, string mmyy)
        {
            return _busBenhNhan.GetDaTaThuocBHYTLL(nhom, maQL, mmyy);
        }

        public DataTable GetThongTinHienDien(string maBN, long maQL, string noiChuyen)
        {
            return _busBenhNhan.GetThongTinHienDien(maBN, maQL, noiChuyen);
        }

        public DataTable GetThongTinPhongGiuong(long idKhoa)
        {
            return _busBenhNhan.GetThongTinPhongGiuong(idKhoa);
        }
        #endregion

        #region CheckData


        #endregion

        #region DeleteData
        public bool DeleteThongTinHienDien(decimal id)
        {
            return _busBenhNhan.DeleteThongTinHienDien(id);
        }

        public bool DeleteThongTinChuyenKhoa(decimal id)
        {
            return _busBenhNhan.DeleteThongTinChuyenKhoa(id);
        }

        public bool DeleteThongTinCDKemTheo(decimal id)
        {
            return _busBenhNhan.DeleteThongTinCDKemTheo(id);
        }

        public bool DeleteThongTinChuyenVien(long maQL)
        {
            return _busBenhNhan.DeleteThongTinChuyenVien(maQL);
        }

        public bool DeleteThongTinCDNguyenNhan(decimal id)
        {
            return _busBenhNhan.DeleteThongTinCDNguyenNhan(id);
        }
        #endregion

        #endregion
    }
}
