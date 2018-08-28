using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E00_Common;
using E00_Model;
using E00_System;
using System.Data;

namespace E00_API
{
    public partial class api_TaiSan
    {
        #region Khai báo biến
        private Acc_Oracle _acc = new Acc_Oracle();
        private Api_Common _api = new Api_Common();
        Dictionary<string, string> dicData = new Dictionary<string, string>();
        List<string> lstDate = new List<string>();
        List<string> lstIsNotNull = new List<string>();
        List<string> lstUnique = new List<string>();
        Dictionary<string, string> dicWhere = new Dictionary<string, string>();
        List<string> lstCotSearch = new List<string>();
        private DataTable _dtSearch;
        private string _userError = string.Empty;
        private string _systemError = string.Empty;
        
        #endregion

        #region Khởi tạo
        public api_TaiSan()
        {
            _api.KetNoi();
        }
        #endregion

        #region Phương thức
        #region frmSuDungTaiSan
        #region Insert
        /// <summary>
        /// Lưu vào bảng TS_SuDungLL
        /// <author>Võ Thanh Duy</Người>
        /// <Date>2018/05/02</Date>
        /// </summary>
        public bool Insert_SuDung(string ma, string maNhapCT, string maVach, string maKP, string maNguoiNhan,string ngayKetThuc, string maTaiSan, string tenTaiSan, string ngaySuDung, bool suDung)
        {
            try
            {
                dicData = new Dictionary<string, string>();
                dicData.Add(cls_TS_SuDungLL.col_Ma, ma);
                dicData.Add(cls_TS_SuDungLL.col_MaNhapCT, maNhapCT);
                dicData.Add(cls_TS_SuDungLL.col_MaVach, maVach);
                dicData.Add(cls_TS_SuDungLL.col_MaKhoaPhong, maKP);
                dicData.Add(cls_TS_SuDungLL.col_MaNguoiNhan, maNguoiNhan);
                //dicData.Add(cls_TS_SuDungLL.col_SoLuong, soLuong != null ? soLuong.ToString() : "0");
                dicData.Add(cls_TS_SuDungLL.col_NgayKetThuc, ngayKetThuc);
                dicData.Add(cls_TS_SuDungLL.col_MaTaiSan, maTaiSan);
                dicData.Add(cls_TS_SuDungLL.col_TenTaiSan, tenTaiSan);
                dicData.Add(cls_TS_SuDungLL.col_NgaySuDung, ngaySuDung);
                dicData.Add(cls_TS_SuDungLL.col_SuDung, suDung ? "1" : "0");
                dicData.Add(cls_TS_SuDungLL.col_UserID, cls_System.sys_UserID);
                dicData.Add(cls_TS_SuDungLL.col_MachineID, cls_Common.Get_MachineID());
                dicData.Add(cls_TS_SuDungCT.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TS_SuDungCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TS_SuDungLL.col_NgayTao, _acc.Get_YYYYMMddHHmmss());

                lstIsNotNull = new List<string>();

                lstUnique = new List<string>();
                lstUnique.Add(cls_TS_SuDungLL.col_Ma);

                return _api.Insert(ref _userError, ref _systemError, cls_TS_SuDungLL.tb_TenBang, dicData, lstUnique, lstIsNotNull, _acc.Get_UserMMYY());
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Insert_BanGiao(string ma, string maSuDungLL, string maVach, string maNguoiDung, string ngayBatDau,
                                    string ngayKetThuc, string maTaiSan, string tenTaiSan)
        {
            try
            {
                dicData = new Dictionary<string, string>();
                dicData.Add(cls_TS_SuDungCT.col_Ma, ma);
                dicData.Add(cls_TS_SuDungCT.col_MaSuDungLL, maSuDungLL);
                dicData.Add(cls_TS_SuDungCT.col_MaVach, maVach);
                dicData.Add(cls_TS_SuDungCT.col_MaNguoiDung, maNguoiDung);
                dicData.Add(cls_TS_SuDungCT.col_NgayBatDau, ngayBatDau);
                dicData.Add(cls_TS_SuDungCT.col_NgayKetThuc, ngayKetThuc);
                dicData.Add(cls_TS_SuDungCT.col_MaTaiSan, maTaiSan);
                dicData.Add(cls_TS_SuDungCT.col_TenTaiSan, tenTaiSan);
                dicData.Add(cls_TS_SuDungCT.col_UserID, _acc.Get_User());
                dicData.Add(cls_TS_SuDungCT.col_MachineId, cls_Common.Get_MachineID());
                dicData.Add(cls_TS_SuDungCT.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TS_SuDungCT.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TS_SuDungCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());

                lstIsNotNull = new List<string>();

                lstUnique = new List<string>();
                lstUnique.Add(cls_TS_SuDungCT.col_Ma);

                return _api.Insert(ref _userError, ref _systemError, cls_TS_SuDungCT.tb_TenBang, dicData, lstUnique, lstIsNotNull, _acc.Get_UserMMYY());
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Search
        public DataTable Search_SuDung(string chuoiTimKiem)
        {
            try
            {
                string sqlSearch = "";
                if (!string.IsNullOrWhiteSpace(chuoiTimKiem))
                {
                    sqlSearch = "";
                }
                else
                {
                    sqlSearch = "";
                }
                _dtSearch = new DataTable();
                _acc.Get_UserMMYY();

                return _dtSearch;

            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Thực hiện khi gọi sự kiện xóa
        /// </summary>
        /// <author>Võ Thanh Duy</author>
        /// <Date>2018/05/03</Date>
        public bool Xoa_SuDung(string lstID)
        {
            try
            {
                return _api.DeleteAll(ref _userError, ref _systemError, cls_TS_SuDungLL.tb_TenBang, lstID.Trim(','), _acc.Get_UserMMYY());
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa_BanGiao(string lstIDLL)
        {
            try
            {
                string sqlXoa = string.Format( "delete {0}.TS_SuDungCT where {1} in ({2})"
                                                ,_acc.Get_UserMMYY()
                                                ,cls_TS_SuDungCT.col_MaSuDungLL
                                                , lstIDLL.Trim(',')
                                            );
                return _acc.Execute_Data(ref _userError, ref _systemError, sqlXoa);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Update
        public bool Update_SuDung(string ma, string maNhapCT, string maVach, string maKP, string maNguoiNhan, string ngayKetThuc, string maTaiSan, string tenTaiSan, string ngaySuDung, bool suDung)
        {
            try
            {
                dicData = new Dictionary<string, string>();
               
                dicData.Add(cls_TS_SuDungLL.col_MaNhapCT, maNhapCT);
                dicData.Add(cls_TS_SuDungLL.col_MaVach, maVach);
                dicData.Add(cls_TS_SuDungLL.col_MaKhoaPhong, maKP);
                dicData.Add(cls_TS_SuDungLL.col_MaNguoiNhan, maNguoiNhan);
                //dicData.Add(cls_TS_SuDungLL.col_SoLuong, soLuong != null ? soLuong.ToString() : "0");
                dicData.Add(cls_TS_SuDungLL.col_NgayKetThuc, ngayKetThuc);
                dicData.Add(cls_TS_SuDungLL.col_MaTaiSan, maTaiSan);
                dicData.Add(cls_TS_SuDungLL.col_TenTaiSan, tenTaiSan);
                dicData.Add(cls_TS_SuDungLL.col_NgaySuDung, ngaySuDung);
                dicData.Add(cls_TS_SuDungLL.col_SuDung, suDung ? "1" : "0");
                dicData.Add(cls_TS_SuDungLL.col_MachineID, cls_Common.Get_MachineID());
                dicData.Add(cls_TS_SuDungCT.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TS_SuDungCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());

                lstDate = new List<string>();
                lstDate.Add(cls_TS_SuDungLL.col_NgayUD);

                dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_TS_SuDungLL.col_Ma, ma);

                return _api.Update(ref _userError, ref _systemError, cls_TS_SuDungLL.tb_TenBang, dicData, lstDate, dicWhere, _acc.Get_UserMMYY());
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update_BanGiao(string ma, string maSuDungLL, string maVach, string maNguoiDung, string ngayBatDau,
                                    string ngayKetThuc, string maTaiSan, string tenTaiSan)
        {
            try
            {
                dicData = new Dictionary<string, string>();
                dicData.Add(cls_TS_SuDungCT.col_MaSuDungLL, maSuDungLL);
                dicData.Add(cls_TS_SuDungCT.col_MaVach, maVach);
                dicData.Add(cls_TS_SuDungCT.col_MaNguoiDung, maNguoiDung);
                dicData.Add(cls_TS_SuDungCT.col_NgayBatDau, ngayBatDau);
                dicData.Add(cls_TS_SuDungCT.col_NgayKetThuc, ngayKetThuc);
                dicData.Add(cls_TS_SuDungCT.col_MaTaiSan, maTaiSan);
                dicData.Add(cls_TS_SuDungCT.col_TenTaiSan, tenTaiSan);
                dicData.Add(cls_TS_SuDungCT.col_MachineId, cls_Common.Get_MachineID());
                dicData.Add(cls_TS_SuDungCT.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TS_SuDungCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());

                lstDate = new List<string>();
                lstDate.Add(cls_TS_SuDungCT.col_NgayUD);

                dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_TS_SuDungCT.col_Ma, ma);

                return _api.Update(ref _userError, ref _systemError, cls_TS_SuDungCT.tb_TenBang, dicData, lstDate, dicWhere, _acc.Get_UserMMYY());
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #endregion

        #region frmNhapTaiSan
        #region Insert
        public bool Insert_NhapKho(string ma, string soPhieu, string ngayNhap, string soHoaDon, string ngayHoaDon, string nguoiGiao, string maKho, string maNhaCungCap
                                    , string maNguoiNhan, string ghiChu)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                dicData.Add(cls_TS_NhapLL.col_Ma, ma);
                dicData.Add(cls_TS_NhapLL.col_SoPhieu, soPhieu);
                dicData.Add(cls_TS_NhapLL.col_NgayNhap, ngayNhap);
                dicData.Add(cls_TS_NhapLL.col_SoHoaDon, soHoaDon);
                dicData.Add(cls_TS_NhapLL.col_NgayHoaDon, ngayHoaDon);
                dicData.Add(cls_TS_NhapLL.col_NguoiGiao, nguoiGiao);
                dicData.Add(cls_TS_NhapLL.col_MaKho, maKho);
                dicData.Add(cls_TS_NhapLL.col_MaNhaCungCap, maNhaCungCap);
                dicData.Add(cls_TS_NhapLL.col_MaNguoiNhan, maNguoiNhan);
                dicData.Add(cls_TS_NhapLL.col_GhiChu, ghiChu);
                dicData.Add(cls_TS_NhapLL.col_UserID, cls_System.sys_UserID);
                dicData.Add(cls_TS_NhapLL.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TS_NhapLL.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TS_NhapLL.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TS_NhapLL.col_MachineID, cls_Common.Get_MachineID());

                List<string> lstUnique = new List<string>();
                lstUnique.Add(cls_TS_NhapLL.col_Ma);

                return _api.Insert(ref _userError, ref _systemError, cls_TS_NhapLL.tb_TenBang, dicData, lstUnique, lstUnique, _acc.Get_UserMMYY());
            }
            catch
            {
                return false;
            }
        }

        public bool Insert_NhapKhoCT(string ma, string maNhapLL, string maTaiSan, string tenTaiSan, string donViTinh, decimal soLuong, decimal donGia, string ghiChu)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                dicData.Add(cls_TS_NhapCT.col_Ma, ma);
                dicData.Add(cls_TS_NhapCT.col_Ma_NhapLL, maNhapLL);
                dicData.Add(cls_TS_NhapCT.col_MaTaiSan, maTaiSan);
                dicData.Add(cls_TS_NhapCT.col_TenTaiSan, tenTaiSan);
                dicData.Add(cls_TS_NhapCT.col_DonViTinh, donViTinh);
                dicData.Add(cls_TS_NhapCT.col_SoLuong, soLuong.ToString());
                dicData.Add(cls_TS_NhapCT.col_SoLuongCon, soLuong.ToString());
                dicData.Add(cls_TS_NhapCT.col_DonGia, donGia.ToString());
                dicData.Add(cls_TS_NhapCT.col_ThanhTien, (soLuong * donGia).ToString());
                dicData.Add(cls_TS_NhapCT.col_GhiChu, ghiChu);
                dicData.Add(cls_TS_NhapCT.col_UserID, cls_System.sys_UserID);
                dicData.Add(cls_TS_NhapCT.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TS_NhapCT.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TS_NhapCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TS_NhapCT.col_MachineID, cls_Common.Get_MachineID());

                List<string> lstUnique = new List<string>();
                lstUnique.Add(cls_TS_NhapCT.col_Ma);

                return _api.Insert(ref _userError, ref _systemError, cls_TS_NhapCT.tb_TenBang, dicData, lstUnique, lstUnique, _acc.Get_UserMMYY());
            }
            catch
            {
                return false;
            }
        }
        
        #endregion

        #region Search
        public DataTable Search_NhapKho(string chuoiTimKiem)
        {
            try
            {
                string sqlSearch = "";
                if (!string.IsNullOrWhiteSpace(chuoiTimKiem))
                {
                    sqlSearch = "";
                }
                else
                {
                    sqlSearch = "";
                }
                _dtSearch = new DataTable();
                _acc.Get_UserMMYY();

                return _dtSearch;

            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Thực hiện khi gọi sự kiện xóa
        /// </summary>
        /// <author>Võ Thanh Duy</author>
        /// <Date>2018/05/03</Date>
        public bool Xoa_NhapLL(string lstID)
        {
            try
            {
                return _api.DeleteAll(ref _userError, ref _systemError, cls_TS_NhapLL.tb_TenBang, lstID.Trim(','), _acc.Get_UserMMYY());
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa_NhapCT(string lstIDLL)
        {
            try
            {
                string sqlXoa = string.Format("delete {0}.TS_NhapCT where {1} in ({2})"
                                                , _acc.Get_UserMMYY()
                                                , cls_TS_NhapCT.col_Ma_NhapLL
                                                , lstIDLL.Trim(',')
                                            );
                return _acc.Execute_Data(ref _userError, ref _systemError, sqlXoa);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Update
        public bool Update_NhapKho(string ma, string soPhieu, string ngayNhap, string soHoaDon, string ngayHoaDon, string nguoiGiao, string maKho, string maNhaCungCap
                                    , string maNguoiNhan, string ghiChu)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                dicData.Add(cls_TS_NhapLL.col_SoPhieu, soPhieu);
                dicData.Add(cls_TS_NhapLL.col_NgayNhap, ngayNhap);
                dicData.Add(cls_TS_NhapLL.col_SoHoaDon, soHoaDon);
                dicData.Add(cls_TS_NhapLL.col_NgayHoaDon, ngayHoaDon);
                dicData.Add(cls_TS_NhapLL.col_NguoiGiao, nguoiGiao);
                dicData.Add(cls_TS_NhapLL.col_MaKho, maKho);
                dicData.Add(cls_TS_NhapLL.col_MaNhaCungCap, maNhaCungCap);
                dicData.Add(cls_TS_NhapLL.col_MaNguoiNhan, maNguoiNhan);
                dicData.Add(cls_TS_NhapLL.col_GhiChu, ghiChu);
                dicData.Add(cls_TS_NhapLL.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TS_NhapLL.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TS_NhapLL.col_MachineID, cls_Common.Get_MachineID());

                lstDate = new List<string>();
                lstDate.Add(cls_TS_NhapLL.col_NgayUD);

                dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_TS_NhapLL.col_Ma, ma);
                return _api.Update(ref _userError, ref _systemError, cls_TS_NhapLL.tb_TenBang, dicData, lstDate, dicWhere, _acc.Get_UserMMYY());
            }
            catch
            {
                return false;
            }
        }

        public bool Update_NhapKhoCT(string ma, string maNhapLL, string maTaiSan, string tenTaiSan, string donViTinh, decimal soLuong, decimal donGia, string ghiChu)
        {
            try
            {
                dicData = new Dictionary<string, string>();
                dicData.Add(cls_TS_NhapCT.col_Ma, ma);
                dicData.Add(cls_TS_NhapCT.col_Ma_NhapLL, maNhapLL);
                dicData.Add(cls_TS_NhapCT.col_MaTaiSan, maTaiSan);
                dicData.Add(cls_TS_NhapCT.col_TenTaiSan, tenTaiSan);
                dicData.Add(cls_TS_NhapCT.col_DonViTinh, donViTinh);
                dicData.Add(cls_TS_NhapCT.col_SoLuong, soLuong.ToString());
                dicData.Add(cls_TS_NhapCT.col_SoLuongCon, soLuong.ToString());
                dicData.Add(cls_TS_NhapCT.col_DonGia, donGia.ToString());
                dicData.Add(cls_TS_NhapCT.col_ThanhTien, (soLuong * donGia).ToString());
                dicData.Add(cls_TS_NhapCT.col_GhiChu, ghiChu);
                dicData.Add(cls_TS_NhapCT.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TS_NhapCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TS_NhapCT.col_MachineID, cls_Common.Get_MachineID());

                lstDate = new List<string>();
                lstDate.Add(cls_TS_NhapCT.col_NgayUD);

                dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_TS_NhapCT.col_Ma, ma);
                return _api.Update(ref _userError, ref _systemError, cls_TS_NhapCT.tb_TenBang, dicData, lstDate, dicWhere, _acc.Get_UserMMYY());

            }
            catch
            {
                return false;
            }
        }

        #endregion

        #endregion

        #endregion

    }
}
