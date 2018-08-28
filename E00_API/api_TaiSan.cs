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
        #region Biến toàn cục

        private Acc_Oracle _acc = new Acc_Oracle();
        private Api_Common _api = new Api_Common();
        private string _userError = string.Empty;
        private string _systemError = string.Empty;

        #endregion

        #region api_TaiSan (Khởi tạo)

        public api_TaiSan()
        {
            _api.KetNoi();
        }

        #endregion

        #region Phương thức

        #region Phương thức Insert

        #region Insert_NhapLL (Thêm mới phiếu nhập kho)
        /// <summary>
        /// Thêm mới phiếu nhập kho
        /// </summary>
        /// <author>Nguyễn Văn Long (Long Dài)</author>
        /// <date>2018/07/13</date>
        /// <param name="ma">Mã nhập LL</param>
        /// <param name="soPhieu">Số phiếu</param>
        /// <param name="ngayNhap">Ngày nhập</param>
        /// <param name="soHoaDon">Số hóa đơn</param>
        /// <param name="ngayHoaDon">Ngày hóa đơn</param>
        /// <param name="nguoiGiao">Người giao</param>
        /// <param name="maKho">Mã kho</param>
        /// <param name="maNhaCungCap">Mã nhà cung cấp</param>
        /// <param name="maNguoiNhan">Mã người nhận</param>
        /// <param name="ghiChu">Ghi chú</param>
        /// <returns></returns>
        public bool Insert_NhapLL(string ma, string soPhieu, string ngayNhap, string soHoaDon, string ngayHoaDon, string nguoiGiao
                                   , string maKho, string maNhaCungCap, string maNguoiNhan, string ghiChu)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                dicData.Add(cls_TaiSan_NhapLL.col_Ma, ma);
                dicData.Add(cls_TaiSan_NhapLL.col_SoPhieu, soPhieu);
                dicData.Add(cls_TaiSan_NhapLL.col_NgayNhap, ngayNhap);
                dicData.Add(cls_TaiSan_NhapLL.col_SoHoaDon, soHoaDon);
                dicData.Add(cls_TaiSan_NhapLL.col_NgayHoaDon, ngayHoaDon);
                dicData.Add(cls_TaiSan_NhapLL.col_NguoiGiao, nguoiGiao);
                dicData.Add(cls_TaiSan_NhapLL.col_MaKho, maKho);
                dicData.Add(cls_TaiSan_NhapLL.col_MaNhaCungCap, maNhaCungCap);
                dicData.Add(cls_TaiSan_NhapLL.col_MaNguoiNhan, maNguoiNhan);
                dicData.Add(cls_TaiSan_NhapLL.col_GhiChu, ghiChu);
                dicData.Add(cls_TaiSan_NhapLL.col_UserID, cls_System.sys_UserID);
                dicData.Add(cls_TaiSan_NhapLL.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TaiSan_NhapLL.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TaiSan_NhapLL.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TaiSan_NhapLL.col_MachineID, cls_Common.Get_MachineID());

                List<string> lstUnique = new List<string>();
                lstUnique.Add(cls_TaiSan_NhapLL.col_Ma);

                return _api.Insert(ref _userError, ref _systemError, cls_TaiSan_NhapLL.tb_TenBang, dicData, lstUnique, lstUnique, _acc.Get_User());
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Insert_NhapCT (Thêm mới nhập kho chi tiết)

        public bool Insert_NhapCT(string maNhapCT, string maNhapLL, string maTaiSan, decimal soLuong, decimal donGia, string ghiChu)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                dicData.Add(cls_TaiSan_NhapCT.col_Ma, maNhapCT);
                dicData.Add(cls_TaiSan_NhapCT.col_Ma_NhapLL, maNhapLL);
                dicData.Add(cls_TaiSan_NhapCT.col_MaTaiSan, maTaiSan);
                dicData.Add(cls_TaiSan_NhapCT.col_SoLuong, soLuong.ToString());
                dicData.Add(cls_TaiSan_NhapCT.col_SoLuongCon, soLuong.ToString());
                dicData.Add(cls_TaiSan_NhapCT.col_DonGia, donGia.ToString());
                dicData.Add(cls_TaiSan_NhapCT.col_ThanhTien, (soLuong * donGia).ToString());
                dicData.Add(cls_TaiSan_NhapCT.col_GhiChu, ghiChu);
                dicData.Add(cls_TaiSan_NhapCT.col_UserID, cls_System.sys_UserID);
                dicData.Add(cls_TaiSan_NhapCT.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TaiSan_NhapCT.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TaiSan_NhapCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TaiSan_NhapCT.col_MachineID, cls_Common.Get_MachineID());

                List<string> lstUnique = new List<string>();
                lstUnique.Add(cls_TaiSan_NhapLL.col_Ma);

                return _api.Insert(ref _userError, ref _systemError, cls_TaiSan_NhapCT.tb_TenBang, dicData, lstUnique, lstUnique);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Insert_BanGiao (Thêm bàn giao tài sản SuDungLL, SuDungCT)

        public bool Insert_BanGiao(ref string error, DataRowView view)
        {
            try
            {
                string maNhapCT = "";
                decimal soLuongCT = 0;
                int countCT = 0;
                List<string> lstUnique = new List<string>();
                lstUnique.Add(cls_TaiSan_SuDungLL.col_Ma);
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                Dictionary<string, string> dicSuDungCT = new Dictionary<string, string>();
                string user = _acc.Get_User();

                #region Cấp sử dụng tài sản thu hồi

                try
                {
                    DataRow drSuDungLL = XL_DONG.Doc(string.Format("Select * From {0}.{1} Where {2} = '{3}' AND {4} = '0' ORDER BY {2}"
                          , user, cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_MaVach, view[cls_TaiSan_SuDungLL.col_MaVach], cls_TaiSan_SuDungLL.col_SuDung));
                    if (drSuDungLL != null)
                    {
                        drSuDungLL[cls_TaiSan_SuDungLL.col_NgaySuDung] = view[cls_TaiSan_SuDungLL.col_NgaySuDung].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_SuDung] = "1";
                        drSuDungLL[cls_TaiSan_SuDungLL.col_UserUD] = cls_System.sys_UserID;
                        drSuDungLL[cls_TaiSan_SuDungLL.col_NgayUD] = _acc.Get_YYYYMMddHHmmss();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_MaKPSuDung] = view[cls_TaiSan_SuDungLL.col_MaKPSuDung].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_TenKPSuDung] = view[cls_TaiSan_SuDungLL.col_TenKPSuDung].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_MaNguoiSuDung] = view[cls_TaiSan_SuDungLL.col_MaNguoiSuDung].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_TenNguoiSuDung] = view[cls_TaiSan_SuDungLL.col_TenNguoiSuDung].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_MaKhu] = view[cls_TaiSan_SuDungLL.col_MaKhu].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_TenKhu] = view[cls_TaiSan_SuDungLL.col_TenKhu].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_MaTang] = view[cls_TaiSan_SuDungLL.col_MaTang].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_TenTang] = view[cls_TaiSan_SuDungLL.col_TenTang].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_MaPhongCongNang] = view[cls_TaiSan_SuDungLL.col_MaPhongCongNang].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_TenPhongCongNang] = view[cls_TaiSan_SuDungLL.col_TenPhongCongNang].ToString();
                        drSuDungLL[cls_TaiSan_SuDungLL.col_SoPhieu] = view[cls_TaiSan_SuDungLL.col_SoPhieu].ToString();
                        drSuDungLL.Table.TableName = cls_TaiSan_SuDungLL.tb_TenBang;
                        XL_BANG._schema = _acc.Get_User();

                        if (XL_DONG.Ghi(drSuDungLL, ref _systemError))
                        {
                            dicSuDungCT.Clear();
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_Ma, _acc.Get_MaMoi());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaSuDungLL, drSuDungLL[cls_TaiSan_SuDungLL.col_Ma].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaVach, drSuDungLL[cls_TaiSan_SuDungLL.col_MaVach].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaNguoiDung, drSuDungLL[cls_TaiSan_SuDungLL.col_MaNguoiSuDung].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayBatDau, drSuDungLL[cls_TaiSan_SuDungLL.col_NgaySuDung].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaTaiSan, drSuDungLL[cls_TaiSan_SuDungLL.col_MaTaiSan].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenTaiSan, drSuDungLL[cls_TaiSan_SuDungLL.col_TenTaiSan].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_UserID, cls_System.sys_UserID);
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MachineId, cls_Common.Get_MachineID());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_UserUD, cls_System.sys_UserID);
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKPQuanLy, drSuDungLL[cls_TaiSan_SuDungLL.col_MaKPQuanLy].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKPQuanLy, drSuDungLL[cls_TaiSan_SuDungLL.col_TenKPQuanLy].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKPSuDung, drSuDungLL[cls_TaiSan_SuDungLL.col_MaKPSuDung].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKPSuDung, drSuDungLL[cls_TaiSan_SuDungLL.col_TenKPSuDung].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaNguoiSuDung, drSuDungLL[cls_TaiSan_SuDungLL.col_MaNguoiSuDung].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenNguoiSuDung, drSuDungLL[cls_TaiSan_SuDungLL.col_TenNguoiSuDung].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKhu, drSuDungLL[cls_TaiSan_SuDungLL.col_MaKhu].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKhu, drSuDungLL[cls_TaiSan_SuDungLL.col_TenKhu].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaTang, drSuDungLL[cls_TaiSan_SuDungLL.col_MaTang].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenTang, drSuDungLL[cls_TaiSan_SuDungLL.col_TenTang].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaPhongCongNang, drSuDungLL[cls_TaiSan_SuDungLL.col_MaPhongCongNang].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenPhongCongNang, drSuDungLL[cls_TaiSan_SuDungLL.col_TenPhongCongNang].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_KyHieu, drSuDungLL[cls_TaiSan_SuDungLL.col_KyHieu].ToString());
                            dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_SoPhieu, drSuDungLL[cls_TaiSan_SuDungLL.col_SoPhieu].ToString());

                            if (_api.Insert(ref _userError, ref _systemError, cls_TaiSan_SuDungCT.tb_TenBang, dicSuDungCT, lstUnique, lstUnique))
                            {
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                }

                #endregion

                #region Tạo mã vạch và cấp sử dụng từ nhập CT
                DataTable dtNhapCT = XL_BANG.Doc(string.Format("Select * From {0}.{1} Where {2} = '{3}' AND {4} > 0 ORDER BY {5}"
                           , user, cls_TaiSan_NhapCT.tb_TenBang, cls_TaiSan_NhapCT.col_MaTaiSan, view[cls_TaiSan_SuDungLL.col_MaTaiSan]
                           , cls_TaiSan_NhapCT.col_SoLuongCon, cls_TaiSan_NhapCT.col_NgayTao));

                try
                {

                    #region Lấy thông tin nhập chi tiết

                    DataRow row = dtNhapCT.Rows[0];

                    soLuongCT = decimal.Parse(row[cls_TaiSan_NhapCT.col_SoLuongCon].ToString());
                    maNhapCT = row[cls_TaiSan_NhapCT.col_Ma].ToString();

                    #endregion

                    #region Kiểm tra và sử lý số lượng sử dụng và số lượng nhập chi tiết

                    row[cls_TaiSan_NhapCT.col_SoLuongCon] = soLuongCT - 1;

                    #endregion


                    #region Thêm sử dụng LL
                    dicData.Clear();
                    dicData.Add(cls_TaiSan_SuDungLL.col_Ma, _acc.Get_MaMoi());
                    dicData.Add(cls_TaiSan_SuDungLL.col_MaNhapCT, maNhapCT);
                    dicData.Add(cls_TaiSan_SuDungLL.col_MaVach, view[cls_TaiSan_SuDungLL.col_MaVach].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_MaTaiSan, row[cls_TaiSan_NhapCT.col_MaTaiSan].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_TenTaiSan, row[cls_TaiSan_NhapCT.col_TenTaiSan].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_NgaySuDung, view[cls_TaiSan_SuDungLL.col_NgaySuDung].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_SuDung, "1");

                    dicData.Add(cls_TaiSan_SuDungLL.col_UserID, cls_System.sys_UserID);
                    dicData.Add(cls_TaiSan_SuDungLL.col_MachineID, cls_Common.Get_MachineID());
                    dicData.Add(cls_TaiSan_SuDungLL.col_UserUD, cls_System.sys_UserID);
                    dicData.Add(cls_TaiSan_SuDungLL.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                    dicData.Add(cls_TaiSan_SuDungLL.col_NgayTao, _acc.Get_YYYYMMddHHmmss());

                    dicData.Add(cls_TaiSan_SuDungLL.col_MaKPQuanLy, view[cls_TaiSan_SuDungLL.col_MaKPQuanLy].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_TenKPQuanLy, view[cls_TaiSan_SuDungLL.col_TenKPQuanLy].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_MaKPSuDung, view[cls_TaiSan_SuDungLL.col_MaKPSuDung].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_TenKPSuDung, view[cls_TaiSan_SuDungLL.col_TenKPSuDung].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_MaNguoiSuDung, view[cls_TaiSan_SuDungLL.col_MaNguoiSuDung].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_TenNguoiSuDung, view[cls_TaiSan_SuDungLL.col_TenNguoiSuDung].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_MaKhu, view[cls_TaiSan_SuDungLL.col_MaKhu].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_TenKhu, view[cls_TaiSan_SuDungLL.col_TenKhu].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_MaTang, view[cls_TaiSan_SuDungLL.col_MaTang].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_TenTang, view[cls_TaiSan_SuDungLL.col_TenTang].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_MaPhongCongNang, view[cls_TaiSan_SuDungLL.col_MaPhongCongNang].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_TenPhongCongNang, view[cls_TaiSan_SuDungLL.col_TenPhongCongNang].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_KyHieu, view[cls_TaiSan_NhapCT.col_KyHieu].ToString());
                    dicData.Add(cls_TaiSan_SuDungLL.col_SoPhieu, view[cls_TaiSan_SuDungLL.col_SoPhieu].ToString());

                    #endregion

                    if (_api.Insert(ref _userError, ref _systemError, cls_TaiSan_SuDungLL.tb_TenBang, dicData, lstUnique, lstUnique))
                    {
                        #region Thêm sử dụng chi tiết

                        dicSuDungCT.Clear();
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_Ma, _acc.Get_MaMoi());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaSuDungLL, dicData[cls_TaiSan_SuDungLL.col_Ma].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaVach, dicData[cls_TaiSan_SuDungLL.col_MaVach].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaNguoiDung, dicData[cls_TaiSan_SuDungLL.col_MaNguoiSuDung].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayBatDau, dicData[cls_TaiSan_SuDungLL.col_NgaySuDung].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaTaiSan, dicData[cls_TaiSan_SuDungLL.col_MaTaiSan].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenTaiSan, dicData[cls_TaiSan_SuDungLL.col_TenTaiSan].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_UserID, cls_System.sys_UserID);
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MachineId, cls_Common.Get_MachineID());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_UserUD, cls_System.sys_UserID);
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKPQuanLy, dicData[cls_TaiSan_SuDungLL.col_MaKPQuanLy].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKPQuanLy, dicData[cls_TaiSan_SuDungLL.col_TenKPQuanLy].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKPSuDung, dicData[cls_TaiSan_SuDungLL.col_MaKPSuDung].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKPSuDung, dicData[cls_TaiSan_SuDungLL.col_TenKPSuDung].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaNguoiSuDung, dicData[cls_TaiSan_SuDungLL.col_MaNguoiSuDung].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenNguoiSuDung, dicData[cls_TaiSan_SuDungLL.col_TenNguoiSuDung].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKhu, dicData[cls_TaiSan_SuDungLL.col_MaKhu].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKhu, dicData[cls_TaiSan_SuDungLL.col_TenKhu].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaTang, dicData[cls_TaiSan_SuDungLL.col_MaTang].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenTang, dicData[cls_TaiSan_SuDungLL.col_TenTang].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaPhongCongNang, dicData[cls_TaiSan_SuDungLL.col_MaPhongCongNang].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenPhongCongNang, dicData[cls_TaiSan_SuDungLL.col_TenPhongCongNang].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_KyHieu, dicData[cls_TaiSan_SuDungLL.col_KyHieu].ToString());
                        dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_SoPhieu, dicData[cls_TaiSan_SuDungLL.col_SoPhieu].ToString());

                        if (_api.Insert(ref _userError, ref _systemError, cls_TaiSan_SuDungCT.tb_TenBang, dicSuDungCT, lstUnique, lstUnique))
                        {
                            countCT++;
                        }

                        #endregion
                    }

                }
                catch
                {
                }

                #endregion

                XL_BANG.Ghi(dtNhapCT, ref error);
                return countCT > 0;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Insert_KiemKeLL (Thêm phiếu kiểm kê)

        public string Insert_KiemKeLL(string soPhieu, string maDotKiemKe, string tenDotKiemKe)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                dicData.Add(cls_TaiSan_KiemKeLL.col_Ma, _acc.Get_Ma());
                dicData.Add(cls_TaiSan_KiemKeLL.col_SoPhieu, soPhieu);
                dicData.Add(cls_TaiSan_KiemKeLL.col_MaDotKiemKe, maDotKiemKe);
                dicData.Add(cls_TaiSan_KiemKeLL.col_TenDotKiemKe, tenDotKiemKe);

                dicData.Add(cls_TaiSan_KiemKeLL.col_UserID, cls_System.sys_UserID);
                dicData.Add(cls_TaiSan_KiemKeLL.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TaiSan_KiemKeLL.col_UserUD, dicData[cls_TaiSan_KiemKeLL.col_UserID]);
                dicData.Add(cls_TaiSan_KiemKeLL.col_NgayUD, dicData[cls_TaiSan_KiemKeLL.col_NgayTao]);
                dicData.Add(cls_TaiSan_KiemKeLL.col_MachineID, cls_Common.Get_MachineID());

                List<string> lstUnique = new List<string>();
                lstUnique.Add(cls_TaiSan_KiemKeLL.col_SoPhieu);

                if (_api.Insert(ref _userError, ref _systemError, cls_TaiSan_KiemKeLL.tb_TenBang, dicData, lstUnique, lstUnique))
                {
                    return dicData[cls_TaiSan_KiemKeLL.col_Ma].ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region Insert_KiemKeCT (Thêm phiếu kiểm kê chi tiết)

        public bool Insert_KiemKeCT(string maKiemKeLL, string soPhieu, string maVach, string maTaiSan, string maTrangThai, string tenTrangThai)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                dicData.Add(cls_TaiSan_KiemKeCT.col_Ma, _acc.Get_Ma());
                dicData.Add(cls_TaiSan_KiemKeCT.col_SoPhieu, soPhieu);
                dicData.Add(cls_TaiSan_KiemKeCT.col_MaKiemKeLL, maKiemKeLL);
                dicData.Add(cls_TaiSan_KiemKeCT.col_MaVach, maVach);
                dicData.Add(cls_TaiSan_KiemKeCT.col_MaTaiSan, maTaiSan);
                dicData.Add(cls_TaiSan_KiemKeCT.col_MaTrangThai, maTrangThai);
                dicData.Add(cls_TaiSan_KiemKeCT.col_TenTrangThai, tenTrangThai);

                dicData.Add(cls_TaiSan_KiemKeCT.col_UserID, cls_System.sys_UserID);
                dicData.Add(cls_TaiSan_KiemKeCT.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TaiSan_KiemKeCT.col_UserUD, dicData[cls_TaiSan_KiemKeCT.col_UserID]);
                dicData.Add(cls_TaiSan_KiemKeCT.col_NgayUD, dicData[cls_TaiSan_KiemKeCT.col_NgayTao]);
                dicData.Add(cls_TaiSan_KiemKeCT.col_MachineID, cls_Common.Get_MachineID());

                List<string> lstUnique = new List<string>();
                lstUnique.Add(cls_TaiSan_KiemKeCT.col_MaKiemKeLL);
                lstUnique.Add(cls_TaiSan_KiemKeCT.col_SoPhieu);
                lstUnique.Add(cls_TaiSan_KiemKeCT.col_MaVach);

                return _api.Insert(ref _userError, ref _systemError, cls_TaiSan_KiemKeCT.tb_TenBang, dicData, lstUnique, lstUnique);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Lưu thông tin người bàn giao, kiểm kê

        public bool Luu_NhanVienBanGiaoKiemKe(string loai, string soPhieu, string doiTuong, string maNhanVien, string tenNhanVien, string chucVu)
        {
            try
            {


                Dictionary<string, string> dicDanhMuc = new Dictionary<string, string>();
                Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                List<string> lstUnique = new List<string>();
                List<string> lstDateTime = new List<string>();

                dicDanhMuc.Add(cls_SYS_DanhMuc.col_MaNhom, maNhanVien);
                dicDanhMuc.Add(cls_SYS_DanhMuc.col_TenNhom, tenNhanVien);
                dicDanhMuc.Add(cls_SYS_DanhMuc.col_GhiChu, chucVu);

                dicWhere.Add(cls_SYS_DanhMuc.col_TenGoc, doiTuong);
                dicWhere.Add(cls_SYS_DanhMuc.col_Ten, soPhieu);
                dicWhere.Add(cls_SYS_DanhMuc.col_Loai, loai);
                dicWhere.Add(cls_SYS_DanhMuc.col_MaNhom, maNhanVien);

                if (_api.Search(ref _userError, ref _systemError, cls_SYS_DanhMuc.tb_TenBang, dicEqual: dicWhere).Rows.Count == 0)
                {
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_STT, "1");
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_Ma, DateTime.Now.ToString("yyMMddHHmmss") + (new Random()).Next(0001, 9999));
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_TenGoc, doiTuong);
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_Ten, soPhieu);
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_Loai, loai);
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_TamNgung, "0");
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_UserID, cls_System.sys_UserID);
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_UserUD, cls_System.sys_UserID);
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_MachineID, cls_Common.Get_MachineID());

                    lstUnique.Add(cls_SYS_DanhMuc.col_Loai);
                    lstUnique.Add(cls_SYS_DanhMuc.col_Ten);
                    lstUnique.Add(cls_SYS_DanhMuc.col_TenGoc);
                    lstUnique.Add(cls_SYS_DanhMuc.col_MaNhom);

                    if (_api.Insert(ref _userError, ref _systemError, cls_SYS_DanhMuc.tb_TenBang, dicDanhMuc, lstUnique, lstUnique))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_UserUD, cls_System.sys_UserID);
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                    dicDanhMuc.Add(cls_SYS_DanhMuc.col_MachineID, cls_Common.Get_MachineID());

                    lstDateTime.Add(cls_SYS_DanhMuc.col_NgayUD);

                    if (_api.Update(ref _userError, ref _systemError, cls_SYS_DanhMuc.tb_TenBang, dicDanhMuc, lstDateTime, dicWhere))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch 
            {
                return false;
            }
        }

        #endregion

        #endregion

        #region Phương thức Update

        public bool Update_NhapKho(string ma, string soPhieu, string ngayNhap, string soHoaDon, string ngayHoaDon, string nguoiGiao, string maKho, string maNhaCungCap
                                    , string maNguoiNhan, string ghiChu)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();

                dicData.Add(cls_TaiSan_NhapLL.col_SoPhieu, soPhieu);
                dicData.Add(cls_TaiSan_NhapLL.col_NgayNhap, ngayNhap);
                dicData.Add(cls_TaiSan_NhapLL.col_SoHoaDon, soHoaDon);
                dicData.Add(cls_TaiSan_NhapLL.col_NgayHoaDon, ngayHoaDon);
                dicData.Add(cls_TaiSan_NhapLL.col_NguoiGiao, nguoiGiao);
                dicData.Add(cls_TaiSan_NhapLL.col_MaKho, maKho);
                dicData.Add(cls_TaiSan_NhapLL.col_MaNhaCungCap, maNhaCungCap);
                dicData.Add(cls_TaiSan_NhapLL.col_MaNguoiNhan, maNguoiNhan);
                dicData.Add(cls_TaiSan_NhapLL.col_GhiChu, ghiChu);
                dicData.Add(cls_TaiSan_NhapLL.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TaiSan_NhapLL.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TaiSan_NhapLL.col_MachineID, cls_Common.Get_MachineID());

                //List<string> lstDateTime = new List<string>();
                //lstDateTime.Add(cls_TaiSan_NhapLL.col_NgayUD);

                Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_TaiSan_NhapLL.col_Ma, ma);

                return _api.UpdateAll(ref _userError, ref _systemError, cls_TaiSan_NhapLL.tb_TenBang, dicData, dicWhere);
            }
            catch
            {
                return false;
            }
        }

        public bool Update_NhapKhoCT(string maNhapCT, string maNhapLL, string maTaiSan, decimal soLuong, decimal soLuongCon, decimal donGia)
        {
            try
            {
                Dictionary<string, string> dicData = new Dictionary<string, string>();

                dicData.Add(cls_TaiSan_NhapCT.col_SoLuong, soLuong.ToString());
                dicData.Add(cls_TaiSan_NhapCT.col_SoLuongCon, soLuongCon.ToString());
                dicData.Add(cls_TaiSan_NhapCT.col_DonGia, donGia.ToString());
                dicData.Add(cls_TaiSan_NhapCT.col_ThanhTien, (soLuong * donGia).ToString());
                dicData.Add(cls_TaiSan_NhapCT.col_UserUD, cls_System.sys_UserID);
                dicData.Add(cls_TaiSan_NhapCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
                dicData.Add(cls_TaiSan_NhapCT.col_MachineID, cls_Common.Get_MachineID());

                List<string> lstDateTime = new List<string>();
                lstDateTime.Add(cls_TaiSan_NhapLL.col_NgayUD);

                Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_TaiSan_NhapCT.col_Ma, maNhapCT);
                dicWhere.Add(cls_TaiSan_NhapCT.col_Ma_NhapLL, maNhapLL);
                dicWhere.Add(cls_TaiSan_NhapCT.col_MaTaiSan, maTaiSan);

                bool x = _api.UpdateAll(ref _userError, ref _systemError, cls_TaiSan_NhapCT.tb_TenBang, dicData, dicWhere);
                return x;
            }
            catch
            {
                return false;
            }
        }

        public int Update_TaiSan(string serialNumber, string maVach)
        {
            try
            {
                int capNhat = 0;

                #region Cập nhật nhận tài sản

                DataRow row = XL_DONG.Doc(string.Format("Select * from {0}.{1} Where {2} = '{3}'"
                                                                  , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_MaVach, maVach));
                row[cls_TaiSan_SuDungLL.col_Serinumber] = serialNumber;
                row.Table.TableName = cls_TaiSan_SuDungLL.tb_TenBang;
                capNhat += XL_DONG.Ghi(row, ref _userError) ? 1 : 0;

                #endregion

                #region Cập nhật sử dụng tài sản

                //row = XL_DONG.Doc(string.Format("Select * from {0}.{1} Where {2} = '{3}'"
                //                                                 , _acc.Get_User(), cls_TaiSan_SuDungCT.tb_TenBang, cls_TaiSan_SuDungCT.col_Ma, maSuDung));
                //row[cls_TaiSan_SuDungCT.col_Serinumber] = serialNumber;
                //row.Table.TableName = cls_TaiSan_SuDungCT.tb_TenBang;
                //capNhat += XL_DONG.Ghi(row, ref _userError) ? 1 : 0;

                #endregion

                return capNhat;
            }
            catch
            {
                return 0;
            }
        }

        public int Update_TaiSan(string maTaiSan, string tenTaiSan, string kyHieu, string maLoaiTaiSan, string tenLoaiTaiSan, string quyCach)
        {
            try
            {
                int capNhat = 0;

                #region Cập nhật danh mục tài sản

                DataRow row = XL_DONG.Doc(string.Format("Select * from {0}.{1} Where {2} = '{3}'"
                                                    , _acc.Get_User(), cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_DanhMuc.col_Ma, maTaiSan));

                row[cls_TaiSan_DanhMuc.col_Ten] = tenTaiSan;
                row[cls_TaiSan_DanhMuc.col_KyHieu] = kyHieu;
                row[cls_TaiSan_DanhMuc.col_MaLoai] = maLoaiTaiSan;
                row[cls_TaiSan_DanhMuc.col_TenLoai] = tenLoaiTaiSan;
                row[cls_TaiSan_DanhMuc.col_QuyCach] = quyCach;

                row.Table.TableName = cls_TaiSan_DanhMuc.tb_TenBang;
                XL_BANG._schema = _acc.Get_User();

                if (XL_DONG.Ghi(row, ref _userError))
                {
                    capNhat++;
                }

                #endregion

                #region Cập nhật phiếu nhập tài sản chi tiết

                DataTable dtNhapCT = XL_BANG.Doc(string.Format("Select * from {0}.{1} Where {2} = '{3}'"
                                                    , _acc.Get_User(), cls_TaiSan_NhapCT.tb_TenBang, cls_TaiSan_NhapCT.col_MaTaiSan, maTaiSan));

                foreach (DataRow drNhapCT in dtNhapCT.Rows)
                {
                    drNhapCT[cls_TaiSan_NhapCT.col_TenTaiSan] = tenTaiSan;
                    drNhapCT[cls_TaiSan_NhapCT.col_KyHieu] = kyHieu;
                }


                row.Table.TableName = cls_TaiSan_NhapCT.tb_TenBang;
                XL_BANG._schema = _acc.Get_User();

                capNhat += XL_BANG.Ghi(dtNhapCT, ref _userError);

                #endregion

                #region Cập nhật nhận tài sản

                DataTable dtNhanTaiSan = XL_BANG.Doc(string.Format("Select * from {0}.{1} Where {2} = '{3}'"
                                                    , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_MaTaiSan, maTaiSan));

                foreach (DataRow drNhanTaiSan in dtNhanTaiSan.Rows)
                {
                    drNhanTaiSan[cls_TaiSan_SuDungLL.col_TenTaiSan] = tenTaiSan;
                    drNhanTaiSan[cls_TaiSan_SuDungLL.col_KyHieu] = kyHieu;
                }


                row.Table.TableName = cls_TaiSan_SuDungLL.tb_TenBang;
                XL_BANG._schema = _acc.Get_User();

                capNhat += XL_BANG.Ghi(dtNhanTaiSan, ref _userError);

                #endregion

                #region Cập nhật sử dụng tài sản

                DataTable dtSuDungTaiSan = XL_BANG.Doc(string.Format("Select * from {0}.{1} Where {2} = '{3}'"
                                                    , _acc.Get_User(), cls_TaiSan_SuDungCT.tb_TenBang, cls_TaiSan_SuDungCT.col_MaTaiSan, maTaiSan));

                foreach (DataRow drSuDungTaiSan in dtSuDungTaiSan.Rows)
                {
                    drSuDungTaiSan[cls_TaiSan_SuDungCT.col_TenTaiSan] = tenTaiSan;
                    drSuDungTaiSan[cls_TaiSan_SuDungCT.col_KyHieu] = kyHieu;
                }


                row.Table.TableName = cls_TaiSan_SuDungCT.tb_TenBang;
                XL_BANG._schema = _acc.Get_User();

                capNhat += XL_BANG.Ghi(dtSuDungTaiSan, ref _userError);

                #endregion

                //row[cls_TaiSan_DanhMuc.col_Serinumber] = serialNumber;

                return capNhat;
            }
            catch
            {
                return 0;
            }
        }

        // public bool Update_SuDung(ref string error, string maKP, string ngaySuDung, string maTaiSan, decimal soLuong, List<string> maVach, DataRowView view
        //, string maKPSuDung, string maNguoiDung)
        // {
        //     try
        //     {
        //         int countCT = 0;
        //         List<string> lstUnique = new List<string>();
        //         lstUnique.Add(cls_TaiSan_SuDungLL.col_Ma);
        //         Dictionary<string, string> dicData = new Dictionary<string, string>();
        //         Dictionary<string, string> dicSuDungCT = new Dictionary<string, string>();
        //         string user = _acc.Get_User();
        //         dicData.Add(cls_TaiSan_SuDungLL.col_UserID, cls_System.sys_UserID);
        //         dicData.Add(cls_TaiSan_SuDungLL.col_MachineID, cls_Common.Get_MachineID());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_UserUD, cls_System.sys_UserID);
        //         dicData.Add(cls_TaiSan_SuDungLL.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_NgayTao, _acc.Get_YYYYMMddHHmmss());

        //         dicData.Add(cls_TaiSan_SuDungLL.col_MaKPQuanLy, view[cls_TaiSan_SuDungLL.col_MaKPQuanLy].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_TenKPQuanLy, view[cls_TaiSan_SuDungLL.col_TenKPQuanLy].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_MaKPSuDung, view[cls_TaiSan_SuDungLL.col_MaKPSuDung].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_TenKPSuDung, view[cls_TaiSan_SuDungLL.col_TenKPSuDung].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_MaNguoiSuDung, view[cls_TaiSan_SuDungLL.col_MaNguoiSuDung].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_TenNguoiSuDung, view[cls_TaiSan_SuDungLL.col_TenNguoiSuDung].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_MaKhu, view[cls_TaiSan_SuDungLL.col_MaKhu].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_TenKhu, view[cls_TaiSan_SuDungLL.col_TenKhu].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_MaTang, view[cls_TaiSan_SuDungLL.col_MaTang].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_TenTang, view[cls_TaiSan_SuDungLL.col_TenTang].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_MaPhongCongNang, view[cls_TaiSan_SuDungLL.col_MaPhongCongNang].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_TenPhongCongNang, view[cls_TaiSan_SuDungLL.col_TenPhongCongNang].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_KyHieu, view[cls_TaiSan_SuDungLL.col_KyHieu].ToString());
        //         dicData.Add(cls_TaiSan_SuDungLL.col_SoPhieu, view[cls_TaiSan_SuDungLL.col_SoPhieu].ToString());


        //         #region Thêm sử dụng chi tiết
        //         if (_api.Insert(ref _userError, ref _systemError, cls_TaiSan_SuDungLL.tb_TenBang, dicData, lstUnique, lstUnique))
        //         {
        //         }
        //         if (maKPSuDung != "")
        //         {
        //             dicSuDungCT.Clear();
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_Ma, _acc.Get_MaMoi());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaSuDungLL, dicData[cls_TaiSan_SuDungLL.col_Ma].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaVach, dicData[cls_TaiSan_SuDungLL.col_MaVach].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaNguoiDung, maNguoiDung);
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayBatDau, ngaySuDung);
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaTaiSan, maTaiSan);
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenTaiSan, dicData[cls_TaiSan_SuDungLL.col_TenTaiSan].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_UserID, _acc.Get_User());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MachineId, cls_Common.Get_MachineID());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayTao, _acc.Get_YYYYMMddHHmmss());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_UserUD, cls_System.sys_UserID);
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_NgayUD, _acc.Get_YYYYMMddHHmmss());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKPQuanLy, dicData[cls_TaiSan_SuDungLL.col_MaKPQuanLy].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKPQuanLy, dicData[cls_TaiSan_SuDungLL.col_TenKPQuanLy].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKPSuDung, dicData[cls_TaiSan_SuDungLL.col_MaKPSuDung].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKPSuDung, dicData[cls_TaiSan_SuDungLL.col_TenKPSuDung].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaNguoiSuDung, dicData[cls_TaiSan_SuDungLL.col_MaNguoiSuDung].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenNguoiSuDung, dicData[cls_TaiSan_SuDungLL.col_TenNguoiSuDung].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaKhu, dicData[cls_TaiSan_SuDungLL.col_MaKhu].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenKhu, dicData[cls_TaiSan_SuDungLL.col_TenKhu].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaTang, dicData[cls_TaiSan_SuDungLL.col_MaTang].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenTang, dicData[cls_TaiSan_SuDungLL.col_TenTang].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_MaPhongCongNang, dicData[cls_TaiSan_SuDungLL.col_MaPhongCongNang].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_TenPhongCongNang, dicData[cls_TaiSan_SuDungLL.col_TenPhongCongNang].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_KyHieu, dicData[cls_TaiSan_SuDungLL.col_KyHieu].ToString());
        //             dicSuDungCT.Add(cls_TaiSan_SuDungCT.col_SoPhieu, _acc.Get_MaMoi());

        //             if (_api.Insert(ref _userError, ref _systemError, cls_TaiSan_SuDungCT.tb_TenBang, dicSuDungCT, lstUnique, lstUnique))
        //             {
        //                 countCT++;
        //             }
        //         }

        //         #endregion
        //         return countCT > 0;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }


        // public bool Update_SuDung(ref string error, string maSuDungLL, int suDung)
        // {
        //     try
        //     {

        //         DataRow row = XL_DONG.Doc(string.Format("Select * From {0}.{1} Where {2} = '{3}'", _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_Ma, maSuDungLL));
        //         row[cls_TaiSan_SuDungLL.col_SuDung] = suDung;

        //         return XL_DONG.Ghi(row, ref error);
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }

        public bool UpDate_KiemKe(string idSuDung, string maKiemKe, string tenKiemKe, string maTrangThai, string tenTrangThai)
        {
            try
            {
                DataRow row = XL_DONG.Doc(string.Format("Select * from {0}.{1} Where {2} = {3}"
                                            , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_ID, idSuDung));
                row[cls_TaiSan_SuDungLL.col_MaKiemKe] = maKiemKe;
                row[cls_TaiSan_SuDungLL.col_TenKiemKe] = tenKiemKe;

                row[cls_TaiSan_SuDungLL.col_MaTrangThai] = maTrangThai;
                row[cls_TaiSan_SuDungLL.col_TenTrangThai] = tenTrangThai;

                row.Table.TableName = cls_TaiSan_SuDungLL.tb_TenBang;
                XL_BANG._schema = _acc.Get_User();

                return XL_DONG.Ghi(row, ref _userError);
            }
            catch
            {
                return false;
            }
        }

        public bool UpDate_ThuHoi(string userUD, string maVach, string ngayThuHoi, bool thuHoi)
        {
            try
            {
                //DataRow rowSuDungCT = XL_DONG.Doc(string.Format("Select * from {0}.{1} Where {2} = '{3}' AND rownum = 1 order by {4} desc"
                //                            , _acc.Get_User(), cls_TaiSan_SuDungCT.tb_TenBang, cls_TaiSan_SuDungCT.col_MaVach, maVach, cls_TaiSan_SuDungCT.col_ID));
                DataRow rowSuDungCT = _acc.Get_Data(string.Format("Select * from {0}.{1} Where {2} = '{3}' AND rownum = 1 order by {4} desc", _acc.Get_User(), cls_TaiSan_SuDungCT.tb_TenBang, cls_TaiSan_SuDungCT.col_MaVach, maVach, cls_TaiSan_SuDungCT.col_ID)).Rows[0];
                rowSuDungCT[cls_TaiSan_SuDungCT.col_UserUD] = userUD;
                rowSuDungCT[cls_TaiSan_SuDungCT.col_NgayUD] = _acc.Get_YYYYMMddHHmmss();
                if (thuHoi)
                {
                    rowSuDungCT[cls_TaiSan_SuDungCT.col_NgayKetThuc] = ngayThuHoi;
                }
                else
                {
                    rowSuDungCT[cls_TaiSan_SuDungCT.col_NgayKetThuc] = DBNull.Value;
                }

                rowSuDungCT.Table.TableName = cls_TaiSan_SuDungCT.tb_TenBang;
                XL_BANG._schema = _acc.Get_User();

                if (XL_DONG.Ghi(rowSuDungCT, ref _userError))
                {

                    DataRow rowSuDungLL = XL_DONG.Doc(string.Format("Select * from {0}.{1} Where {2} = '{3}'"
                                                , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_MaVach, maVach));
                    rowSuDungLL[cls_TaiSan_SuDungLL.col_UserUD] = userUD;
                    rowSuDungLL[cls_TaiSan_SuDungLL.col_NgayUD] = _acc.Get_YYYYMMddHHmmss();
                    if (thuHoi)
                    {
                        rowSuDungLL[cls_TaiSan_SuDungLL.col_SuDung] = "0";
                    }
                    else
                    {
                        rowSuDungLL[cls_TaiSan_SuDungLL.col_SuDung] = "1";
                    }
                    rowSuDungLL.Table.TableName = cls_TaiSan_SuDungLL.tb_TenBang;
                    XL_BANG._schema = _acc.Get_User();

                    return XL_DONG.Ghi(rowSuDungLL, ref _userError);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Phương thức Delete

        public bool Delete_NhapKhoCT(string maNhapLL, string maTaiSan)
        {
            try
            {
                Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_TaiSan_NhapCT.col_Ma_NhapLL, maNhapLL);
                dicWhere.Add(cls_TaiSan_NhapCT.col_MaTaiSan, maTaiSan);
                return _api.Delete(ref _userError, ref _systemError, cls_TaiSan_NhapCT.tb_TenBang, dicWhere);
            }
            catch
            {
                return false;
            }
        }

        public bool Delete_KiemKeCT(string idKiemKeCT)
        {
            try
            {
                Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_TaiSan_KiemKeCT.col_ID, idKiemKeCT);
                return _api.Delete(ref _userError, ref _systemError, cls_TaiSan_KiemKeCT.tb_TenBang, dicWhere);
            }
            catch
            {
                return false;
            }
        }


        //public bool Delete_SuDungLL(string SoPhieu)
        //{
        //    try
        //    {
        //        Dictionary<string, string> dicWhere = new Dictionary<string, string>();
        //        dicWhere.Add(cls_TaiSan_SuDungLL.col_SoPhieu, SoPhieu);
        //        return _api.Delete(ref _userError, ref _systemError, cls_TaiSan_SuDungLL.tb_TenBang, dicWhere, _acc.Get_User());
        //    }
        //    catch { return false; }
        //}
        //public bool Delete_SuDungCT(string SoPhieu)
        //{
        //    try
        //    {
        //        Dictionary<string, string> dicWhere = new Dictionary<string, string>();
        //        dicWhere.Add(cls_TaiSan_SuDungCT.col_SoPhieu, SoPhieu);
        //        return _api.Delete(ref _userError, ref _systemError, cls_TaiSan_SuDungCT.tb_TenBang, dicWhere, _acc.Get_User());
        //    }
        //    catch { return false; }
        //}

        #region Xóa thông tin người bàn giao, kiểm kê

        public bool Delete_NhanVienBanGiaoKiemKe(string loai, string soPhieu, string doiTuong, string maNhanVien)
        {
            try
            {
                Dictionary<string, string> dicWhere = new Dictionary<string, string>();

                dicWhere.Add(cls_SYS_DanhMuc.col_TenGoc, doiTuong);
                dicWhere.Add(cls_SYS_DanhMuc.col_Ten, soPhieu);
                dicWhere.Add(cls_SYS_DanhMuc.col_Loai, loai);
                dicWhere.Add(cls_SYS_DanhMuc.col_MaNhom, maNhanVien);

                if (_api.Delete(ref _userError, ref _systemError, cls_SYS_DanhMuc.tb_TenBang, dicWhere))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #endregion

        #region Phương thức GetData

        #region Get_ThongTinTaiSan_ThuHoi (Lấy danh sách tài sản thu hồi)

        public DataTable Get_ThongTinTaiSan_ThuHoi(bool thuHoi, string maKhu, string maTang, string maPhong, string maDonViQL, string maDonViSD, string maNguoi
          , string maTaiSan, string kyHieu)
        {
            try
            {
                string sKiemKe = "";

                if (maKhu != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKhu, maKhu);
                }
                if (maTang != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaTang, maTang);
                }
                if (maPhong != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaPhongCongNang, maPhong);
                }
                if (maDonViQL != "")
                {
                    sKiemKe += string.Format(" AND b.{0} = '{1}'", cls_TaiSan_DanhMuc.col_MaKPQuanLy, maDonViQL);
                }
                if (maDonViSD != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKPSuDung, maDonViSD);
                }
                if (maNguoi != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaNguoiSuDung, maNguoi);
                }
                if (maTaiSan != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaTaiSan, maTaiSan);
                }
                if (kyHieu != "")
                {
                    sKiemKe += string.Format(" AND Upper(a.{0}) like Upper('%{1}%')", cls_TaiSan_SuDungLL.col_KyHieu, kyHieu);
                }
                if (thuHoi)
                {
                    sKiemKe = string.Format(" a.{0} = '0' ", cls_TaiSan_SuDungLL.col_SuDung) + sKiemKe;
                }
                else
                {
                    sKiemKe = string.Format(" a.{0} = '1' ", cls_TaiSan_SuDungLL.col_SuDung) + sKiemKe;
                }
                string query = string.Format(@"Select b.{6},b.{7},b.{8},to_char(a.{9},'dd/mm/yyyy hh24:mi:ss') AS NgayCapNhat,b.{10},b.{11} AS {12},b.{13} AS {14},a.*
                                                From {0}.{1} a join {0}.{2} b on a.{3} = b.{4} 
                                                Where {5}"
                                , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_SuDungLL.col_MaTaiSan
                                , cls_TaiSan_DanhMuc.col_Ma, sKiemKe, cls_TaiSan_DanhMuc.col_MaLoai, cls_TaiSan_DanhMuc.col_TenLoai
                                , cls_TaiSan_DanhMuc.col_QuyCach, cls_TaiSan_SuDungLL.col_NgayUD, cls_TaiSan_DanhMuc.col_KyHieu
                                , cls_TaiSan_DanhMuc.col_Ma, cls_TaiSan_SuDungLL.col_MaTaiSan
                                , cls_TaiSan_DanhMuc.col_Ten, cls_TaiSan_SuDungLL.col_TenTaiSan);
                return XL_BANG.Doc(query);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_SoLuongQuanLy (Lấy số lượng quản lý)
        public decimal Get_SoLuongQuanLy(string maDonViQuanLy, string maTaiSan)
        {
            try
            {
                string query = string.Format("Select Sum(a.{8}) As QuanLy From {0}.{1} a inner join {0}.{2} b on a.{3} = b.{4} Where b.{5} = '{6}' AND b.{4} = '{7}'"
                    , _acc.Get_User(), cls_TaiSan_NhapCT.tb_TenBang, cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_NhapCT.col_MaTaiSan
                    , cls_TaiSan_DanhMuc.col_Ma, cls_TaiSan_DanhMuc.col_MaKPQuanLy, maDonViQuanLy, maTaiSan, cls_TaiSan_NhapCT.col_SoLuong);
                return decimal.Parse(_acc.Get_Data(query).Rows[0]["QuanLy"].ToString());
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Get_SoLuongQuanLyConMoi (Lấy số lượng quản lý còn lại mới)
        public decimal Get_SoLuongQuanLyConMoi(string maDonViQuanLy, string maTaiSan)
        {
            try
            {
                string query = string.Format("Select Sum(a.{8}) As QuanLy From {0}.{1} a inner join {0}.{2} b on a.{3} = b.{4} Where b.{5} = '{6}' AND b.{4} = '{7}'"
                    , _acc.Get_User(), cls_TaiSan_NhapCT.tb_TenBang, cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_NhapCT.col_MaTaiSan
                    , cls_TaiSan_DanhMuc.col_Ma, cls_TaiSan_DanhMuc.col_MaKPQuanLy, maDonViQuanLy, maTaiSan, cls_TaiSan_NhapCT.col_SoLuongCon);

                return decimal.Parse(_acc.Get_Data(query).Rows[0]["QuanLy"].ToString());
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Get_TaiSan (Lấy danh sách tài sản theo mã quản lý)
        /// <summary>
        /// Lấy danh sách tài sản
        /// </summary>
        /// <author>Nguyễn Văn Long (Long Dài)</author>
        /// <Date>2018/07/02</Date>
        /// <param name="maKPQuanLy">Mã đơn vị quản lý, nếu để trống sẽ lấy tất cả tài sản</param>
        /// <returns>DataTable: Danh sách  tài sản gồm: Mã, tên</returns>
        public DataTable Get_TaiSan(string maKPQuanLy)
        {
            try
            {
                string sMaKPQuanLy = "";
                if (maKPQuanLy != "")
                {
                    sMaKPQuanLy = string.Format(" AND {0} = '{1}' ", cls_TaiSan_DanhMuc.col_MaKPQuanLy, maKPQuanLy);
                }

                string sSelect = string.Format("{0},{1}", cls_TaiSan_DanhMuc.col_Ma, cls_TaiSan_DanhMuc.col_Ten);
                string query = string.Format("Select {0} From {1}.{2} Where NVL({3},'') <> '1' {4} ORDER BY {5}"
                    , sSelect, _acc.Get_User(), cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_DanhMuc.col_TamNgung
                    , sMaKPQuanLy, cls_TaiSan_DanhMuc.col_Ten);
                return XL_BANG.Doc(query);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_MaTheoSoPhieu (Lấy mã theo số phiếu)

        public string Get_MaTheoSoPhieu(string table, string cotMa, string cotSoPhieu, string sophieu, string schema = "")
        {
            try
            {
                if (schema == "")
                {
                    schema = _acc.Get_User();
                }
                string query = string.Format("select {4} from {0}.{1} where rownum = 1 and {2} = '{3}' ",
                                            schema, table, cotSoPhieu, sophieu, cotMa);

                return _acc.Get_Data(query).Rows[0][cotMa].ToString();
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region Get_NhaCungCapTheoSoPhieu (Lấy thông tin nhà cung cấp theo số phiếu)
        /// <summary>
        /// Lấy thông tin nhà cung cấp theo số phiếu
        /// </summary>
        /// <author>Nguyễn Văn Long (Long Dài)</author>
        /// <Date>2018/07/12</Date>
        /// <param name="sophieu">Số phiếu</param>
        /// <returns></returns>
        public DataTable Get_NhaCungCapTheoSoPhieu(string sophieu)
        {
            try
            {
                string sql = string.Format("Select b.{0}, b.{1} From {2}.{3} a inner join  {2}.{4} b on a.{5} = b.{0} where a.{6} = '{7}'"
                                            , cls_SYS_DanhMuc.col_Ma, cls_SYS_DanhMuc.col_Ten, _acc.Get_User()
                                            , cls_TaiSan_NhapLL.tb_TenBang, cls_SYS_DanhMuc.tb_TenBang, cls_TaiSan_NhapLL.col_MaNhaCungCap
                                            , cls_TaiSan_NhapLL.col_SoPhieu, sophieu);
                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_TaiSanTheoMa (Lấy thông tin tài sản theo mã)
        /// <summary>
        /// Lấy thông tin tài sản theo mã
        /// </summary>
        /// <author>Nguyễn Văn Long (Long Dài)</author>
        /// <date>2018/07/12</date>
        /// <param name="maTaiSan">Mã tài sản</param>
        /// <returns></returns>
        public DataRow Get_TaiSanTheoMa(string maTaiSan)
        {
            try
            {
                DataTable dtTaiSan = new DataTable();
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_TaiSan_DanhMuc.col_Ma, maTaiSan);
                dtTaiSan = _api.Search(ref _userError, ref _systemError, cls_TaiSan_DanhMuc.tb_TenBang, dicEqual: dicE
                                                    , orderByASC1: true, orderByName1: cls_TaiSan_DanhMuc.col_Ma);
                return dtTaiSan.Rows[0];
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_NhanVien (Lấy nhân viên bàn giao/ kiểm kê)

        public DataTable Get_NhanVien(string loai, string doiTuong, string soPhieu)
        {
            try
            {
                DataTable dtDanhMuc = new DataTable();
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_SYS_DanhMuc.col_Loai, loai);
                dicE.Add(cls_SYS_DanhMuc.col_TenGoc, doiTuong);
                dicE.Add(cls_SYS_DanhMuc.col_Ten, soPhieu);

                dtDanhMuc = _api.Search(ref _userError, ref _systemError, cls_SYS_DanhMuc.tb_TenBang, dicEqual: dicE
                                                    , orderByASC1: true, orderByName1: cls_SYS_DanhMuc.col_Ma);
                return dtDanhMuc;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_NhanVien (Lấy nhân viên bàn giao/ kiểm kê)

        public string Get_DiaDiemKiemKe(string loai, string doiTuong, string soPhieu)
        {
            try
            {
                DataTable dtDanhMuc = new DataTable();
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_SYS_DanhMuc.col_Loai, loai);
                dicE.Add(cls_SYS_DanhMuc.col_TenGoc, doiTuong);
                dicE.Add(cls_SYS_DanhMuc.col_Ten, soPhieu);

                dtDanhMuc = _api.Search(ref _userError, ref _systemError, cls_SYS_DanhMuc.tb_TenBang, dicEqual: dicE
                                                    , orderByASC1: true, orderByName1: cls_SYS_DanhMuc.col_Ma);
                return dtDanhMuc.Rows[0][cls_SYS_DanhMuc.col_GhiChu].ToString();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_BanGiaoTaiSan (Lấy thông tin bàn giao theo số phiếu)
        /// <summary>
        /// Lấy thông tin bàn giao theo số phiếu
        /// </summary>
        /// <author>Nguyễn Văn Long (Long Dài)</author>
        /// <Date>2018/07/14</Date>
        /// <param name="soPhieu">Số phiếu bàn giao</param>
        /// <returns></returns>
        public DataTable Get_BanGiaoTaiSan(string soPhieu)
        {
            try
            {
                string sql = string.Format("Select b.{7},b.{8}, a.* from {0}.{1} a inner join {0}.{2} b on a.{3} = b.{4} Where {5} = '{6}'", _acc.Get_User()
                    , cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_DanhMuc.tb_TenBang
                    , cls_TaiSan_SuDungLL.col_MaTaiSan, cls_TaiSan_DanhMuc.col_Ma
                    , cls_TaiSan_SuDungLL.col_SoPhieu, soPhieu
                    , cls_TaiSan_DanhMuc.col_MaKPQuanLy, cls_TaiSan_DanhMuc.col_TenKPQuanLy);
                return _acc.Get_Data(sql);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_SoPhieuKiemKe (Lấy số phiếu kiểm kê)

        public DataTable Get_SoPhieuKiemKe(string maDotKiemKe)
        {
            try
            {
                string sql = string.Format("Select {0} AS Ma,{0} AS Ten from {1}.{2} where {3} = '{4}'"
                                    , cls_TaiSan_KiemKeLL.col_SoPhieu, _acc.Get_User(), cls_TaiSan_KiemKeLL.tb_TenBang
                                    , cls_TaiSan_KiemKeLL.col_MaDotKiemKe, maDotKiemKe);
                return XL_BANG.Doc(sql);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_ThongTinTaiSan (Lấy danh sách tài sản cần KIỂM KÊ theo đợt) -- Cũ
        /// <summary>
        /// Lấy danh sách tài sản cần KIỂM KÊ theo đợt
        /// </summary>
        /// <author>Nguyễn Văn Long (Long Dài)</author>
        /// <date>2018/07/02</date>
        /// <param name="maKiemKe">Mã kiểm kê</param>
        /// <param name="dot">Đợt này (true)</param>
        /// <param name="maKhu">Mã khu sử dụng</param>
        /// <param name="maTang">Mã tầng sử dụng</param>
        /// <param name="maPhong">Mã phòng sử dụng</param>
        /// <param name="maDonViQL">Mã đơn vị quản lý</param>
        /// <param name="maDonViSD">Mã đơn vị sử dụng</param>
        /// <param name="maNguoiSuDung">Mã người sử dụng</param>
        /// <param name="maTaiSan">Mã tài sản</param>
        /// <param name="kyHieu">Ký hiệu</param>
        /// <returns>DataTable</returns>
        public DataTable Get_ThongTinTaiSan(string maKiemKe, int dot, string maKhu, string maTang, string maPhong, string maDonViQL, string maDonViSD, string maNguoiSuDung
            , string maTaiSan, string kyHieu)
        {
            try
            {
                string sKiemKe = string.Format(" a.{0} = '1' ", cls_TaiSan_SuDungLL.col_SuDung);

                if (dot == 0)
                {
                    sKiemKe += string.Format(" AND (a.{0} <> '{1}' or a.{0} is null)", cls_TaiSan_SuDungLL.col_MaKiemKe, maKiemKe);
                }
                else if (dot == 1)
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKiemKe, maKiemKe);
                }

                if (maKhu != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKhu, maKhu);
                }
                if (maTang != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaTang, maTang);
                }
                if (maPhong != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaPhongCongNang, maPhong);
                }
                if (maDonViQL != "")
                {
                    sKiemKe += string.Format(" AND b.{0} = '{1}'", cls_TaiSan_DanhMuc.col_MaKPQuanLy, maDonViQL);
                }
                if (maDonViSD != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKPSuDung, maDonViSD);
                }
                if (maNguoiSuDung != "")
                {
                    sKiemKe += string.Format(" AND a.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaNguoiSuDung, maNguoiSuDung);
                }
                if (maTaiSan != "")
                {
                    sKiemKe += string.Format(" AND b.{0} = '{1}'", cls_TaiSan_DanhMuc.col_Ma, maTaiSan);
                }
                if (kyHieu != "")
                {
                    sKiemKe += string.Format(" AND Upper(a.{0}) like Upper('%{1}%')", cls_TaiSan_SuDungLL.col_KyHieu, kyHieu);
                }


                string query = string.Format(@"Select b.{6},b.{7},b.{8},to_char(a.{9},'dd/mm/yyyy hh24:mi:ss') AS NgayCapNhat,b.{10},b.{11} AS {12},b.{13} AS {14},a.*
                                                From {0}.{1} a join {0}.{2} b on a.{3} = b.{4} 
                                                Where {5}"
                                , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_SuDungLL.col_MaTaiSan
                                , cls_TaiSan_DanhMuc.col_Ma, sKiemKe, cls_TaiSan_DanhMuc.col_MaLoai, cls_TaiSan_DanhMuc.col_TenLoai
                                , cls_TaiSan_DanhMuc.col_QuyCach, cls_TaiSan_SuDungLL.col_NgayUD, cls_TaiSan_DanhMuc.col_KyHieu
                                , cls_TaiSan_DanhMuc.col_Ma, cls_TaiSan_SuDungLL.col_MaTaiSan
                                , cls_TaiSan_DanhMuc.col_Ten, cls_TaiSan_SuDungLL.col_TenTaiSan);
                return XL_BANG.Doc(query);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_TaiSanKiemKe (Lấy danh sách tài sản đã KIỂM KÊ theo số phiếu)

        public DataTable Get_TaiSanKiemKe(string maDotKiemKe, string soPhieu, string maDonViQL, string maTaiSan, string kyHieu
                                            , string maDonViSD, string maNguoiSuDung, string maKhu, string maTang, string maPhong)
        {
            try
            {
                string sKiemKe = string.Format(" sdll.{0} = '1'", cls_TaiSan_SuDungLL.col_SuDung);
                sKiemKe += string.Format(" AND (kkll.{0} = '{1}')", cls_TaiSan_KiemKeLL.col_MaDotKiemKe, maDotKiemKe);
                sKiemKe += string.Format(" AND kkll.{0} = '{1}'", cls_TaiSan_KiemKeLL.col_SoPhieu, soPhieu);


                if (maKhu != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKhu, maKhu);
                }
                if (maTang != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaTang, maTang);
                }
                if (maPhong != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaPhongCongNang, maPhong);
                }
                if (maDonViQL != "")
                {
                    sKiemKe += string.Format(" AND ts.{0} = '{1}'", cls_TaiSan_DanhMuc.col_MaKPQuanLy, maDonViQL);
                }
                if (maDonViSD != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKPSuDung, maDonViSD);
                }
                if (maNguoiSuDung != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaNguoiSuDung, maNguoiSuDung);
                }
                if (maTaiSan != "")
                {
                    sKiemKe += string.Format(" AND ts.{0} = '{1}'", cls_TaiSan_DanhMuc.col_Ma, maTaiSan);
                }
                if (kyHieu != "")
                {
                    sKiemKe += string.Format(" AND Upper(ts.{0}) like Upper('%{1}%')", cls_TaiSan_DanhMuc.col_KyHieu, kyHieu);
                }

                #region Code cũ
                //string query = string.Format(@"select distinct ts.{12} AS TenTaiSan,ts.{13} AS KyHieu,sdll.{14}
                //                                     ,ts.{15} AS QuyCach,kkct.{16},kkct.{17}
                //                                     , sdll.*,kkll.{0},kkll.{1} AS SoPhieuKiemKe
                //                                from {4}.{9} sdll
                //                                inner join {4}.{5} kkct on kkct.{3} = sdll.{2}
                //                                inner join {4}.{6} kkll on kkll.{8} = kkct.{7}
                //                                inner join {4}.{10} ts on ts.{11} = sdll.{18}
                //                                Where {19}"
                //                       , cls_TaiSan_KiemKeLL.col_MaDotKiemKe, cls_TaiSan_KiemKeLL.col_SoPhieu, cls_TaiSan_SuDungLL.col_MaVach//2
                //                       , cls_TaiSan_KiemKeCT.col_MaVach, _acc.Get_User(), cls_TaiSan_KiemKeCT.tb_TenBang, cls_TaiSan_KiemKeLL.tb_TenBang//6
                //                       , cls_TaiSan_KiemKeCT.col_MaKiemKeLL, cls_TaiSan_KiemKeLL.col_Ma, cls_TaiSan_SuDungLL.tb_TenBang//9
                //                       , cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_DanhMuc.col_Ma, cls_TaiSan_DanhMuc.col_Ten, cls_TaiSan_DanhMuc.col_KyHieu//13
                //                       , cls_TaiSan_SuDungLL.col_Serinumber, cls_TaiSan_DanhMuc.col_QuyCach, cls_TaiSan_KiemKeCT.col_MaTrangThai//16
                //                       , cls_TaiSan_KiemKeCT.col_TenTrangThai, cls_TaiSan_SuDungLL.col_MaTaiSan, sKiemKe); 
                #endregion
                #region Nguyễn Quốc Vạn 27/08/2018 Lấy thêm ID TaiSan_KiemKeCT
                string query = string.Format(@"select distinct ts.{12} AS TenTaiSan,ts.{13} AS KyHieu,sdll.{14}
                                                     ,ts.{15} AS QuyCach,kkct.{16},kkct.{17}
                                                     , sdll.*,kkll.{0},kkll.{1} AS SoPhieuKiemKe, kkct.{20} AS IDCT, ts.{21}, ts.{22}
                                                from {4}.{9} sdll
                                                inner join {4}.{5} kkct on kkct.{3} = sdll.{2}
                                                inner join {4}.{6} kkll on kkll.{8} = kkct.{7}
                                                inner join {4}.{10} ts on ts.{11} = sdll.{18}
                                                Where {19}"
                                        , cls_TaiSan_KiemKeLL.col_MaDotKiemKe, cls_TaiSan_KiemKeLL.col_SoPhieu, cls_TaiSan_SuDungLL.col_MaVach//2
                                        , cls_TaiSan_KiemKeCT.col_MaVach, _acc.Get_User(), cls_TaiSan_KiemKeCT.tb_TenBang, cls_TaiSan_KiemKeLL.tb_TenBang//6
                                        , cls_TaiSan_KiemKeCT.col_MaKiemKeLL, cls_TaiSan_KiemKeLL.col_Ma, cls_TaiSan_SuDungLL.tb_TenBang//9
                                        , cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_DanhMuc.col_Ma, cls_TaiSan_DanhMuc.col_Ten, cls_TaiSan_DanhMuc.col_KyHieu//13
                                        , cls_TaiSan_SuDungLL.col_Serinumber, cls_TaiSan_DanhMuc.col_QuyCach, cls_TaiSan_KiemKeCT.col_MaTrangThai//16
                                        , cls_TaiSan_KiemKeCT.col_TenTrangThai, cls_TaiSan_SuDungLL.col_MaTaiSan, sKiemKe,cls_TaiSan_KiemKeCT.col_ID//20
                                        , cls_TaiSan_DanhMuc.col_MaLoai, cls_TaiSan_DanhMuc.col_TenLoai); 
                #endregion


                return _acc.Get_Data(query);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Get_TaiSanChuaKiemKe (Lấy danh sách tài sản CHƯA KIỂM KÊ theo đợt)

        public DataTable Get_TaiSanChuaKiemKe(string maDotKiemKe, string maDonViQL, string maTaiSan, string kyHieu
                                            , string maDonViSD, string maNguoiSuDung, string maKhu, string maTang, string maPhong)
        {
            try
            {
                string sDotKiemKe = string.Format(" kkll2.{0} = '{1}'", cls_TaiSan_KiemKeLL.col_MaDotKiemKe, maDotKiemKe);

                string sKiemKe = string.Format(" sdll.{0} = '1'", cls_TaiSan_SuDungLL.col_SuDung);

                if (maKhu != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKhu, maKhu);
                }
                if (maTang != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaTang, maTang);
                }
                if (maPhong != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaPhongCongNang, maPhong);
                }
                if (maDonViQL != "")
                {
                    sKiemKe += string.Format(" AND ts.{0} = '{1}'", cls_TaiSan_DanhMuc.col_MaKPQuanLy, maDonViQL);
                }
                if (maDonViSD != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaKPSuDung, maDonViSD);
                }
                if (maNguoiSuDung != "")
                {
                    sKiemKe += string.Format(" AND sdll.{0} = '{1}'", cls_TaiSan_SuDungLL.col_MaNguoiSuDung, maNguoiSuDung);
                }
                if (maTaiSan != "")
                {
                    sKiemKe += string.Format(" AND ts.{0} = '{1}'", cls_TaiSan_DanhMuc.col_Ma, maTaiSan);
                }
                if (kyHieu != "")
                {
                    sKiemKe += string.Format(" AND Upper(ts.{0}) like Upper('%{1}%')", cls_TaiSan_DanhMuc.col_KyHieu, kyHieu);
                }

                string query = string.Format(@"select distinct ts.{12} AS TenTaiSan,ts.{13} AS KyHieu,sdll.{14} AS SeriNumber,ts.{15} AS QuyCach
                                                     , sdll.*,kkll.{0},ts.{18},ts.{19},sdll.{20}
                                                     
                                                from {4}.{9} sdll
                                                left join {4}.{5} kkct on kkct.{3} = sdll.{21}
                                                left join {4}.{6} kkll on kkll.{8} = kkct.{7}
                                                left join {4}.{10} ts on ts.{11} = sdll.{2}
                                                Where sdll.{21} not in (select kkct2.{3} from {4}.{5} kkct2 Join {4}.{6} kkll2 on kkct2.{7} = kkll2.{8} where {16})
                                                    AND {17}"
                                , cls_TaiSan_KiemKeLL.col_MaDotKiemKe, cls_TaiSan_KiemKeLL.col_SoPhieu, cls_TaiSan_SuDungLL.col_MaTaiSan//2
                                , cls_TaiSan_KiemKeCT.col_MaVach, _acc.Get_User(), cls_TaiSan_KiemKeCT.tb_TenBang, cls_TaiSan_KiemKeLL.tb_TenBang//6
                                , cls_TaiSan_KiemKeCT.col_MaKiemKeLL, cls_TaiSan_KiemKeLL.col_Ma, cls_TaiSan_SuDungLL.tb_TenBang//9
                                , cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_DanhMuc.col_Ma//11
                                , cls_TaiSan_DanhMuc.col_Ten, cls_TaiSan_DanhMuc.col_KyHieu, cls_TaiSan_SuDungLL.col_Serinumber, cls_TaiSan_DanhMuc.col_QuyCach//15
                                , sDotKiemKe, sKiemKe, cls_TaiSan_DanhMuc.col_MaLoai, cls_TaiSan_DanhMuc.col_TenLoai, cls_TaiSan_SuDungLL.col_Serinumber//20
                                , cls_TaiSan_SuDungLL.col_MaVach);//21

                return _acc.Get_Data(query);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        public DataTable Get_TaiSanNhap()
        {
            try
            {
                string sSelect = string.Format("{0},{1},sum({2}) as SoLuong", cls_TaiSan_NhapCT.col_MaTaiSan, cls_TaiSan_NhapCT.col_TenTaiSan, cls_TaiSan_NhapCT.col_SoLuongCon);
                string sGroup = string.Format("{0},{1}", cls_TaiSan_NhapCT.col_MaTaiSan, cls_TaiSan_NhapCT.col_TenTaiSan);
                string query = string.Format("Select {0} From {1}.{2} group by {3} ", sSelect, _acc.Get_User(), cls_TaiSan_NhapCT.tb_TenBang, sGroup);
                return XL_BANG.Doc(query);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_TaiSanSuDung(string maKPQuanLy)
        {
            try
            {
                string sSelect = string.Format("{0},{1},count({0}) as SoLuong,{2}"
                    , cls_TaiSan_SuDungLL.col_MaTaiSan, cls_TaiSan_SuDungLL.col_TenTaiSan, cls_TaiSan_SuDungLL.col_MaKPQuanLy);
                string sGroup = string.Format("{0},{1},{2}", cls_TaiSan_SuDungLL.col_MaTaiSan, cls_TaiSan_SuDungLL.col_TenTaiSan, cls_TaiSan_SuDungLL.col_MaKPQuanLy);
                string query = "";
                if (maKPQuanLy != "")
                {
                    query = string.Format("Select {0} From {1}.{2} where {3} = '0' AND {4} = '{5}' group by {6} ", sSelect, _acc.Get_User()
                                                        , cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_SuDung, cls_TaiSan_SuDungLL.col_MaKPQuanLy, maKPQuanLy, sGroup);
                }
                else
                {
                    query = string.Format("Select {0} From {1}.{2} where {3} = '0' group by {4} ", sSelect, _acc.Get_User()
                                                            , cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_SuDung, sGroup);
                }
                return XL_BANG.Doc(query);
            }
            catch
            {
                return null;
            }
        }

        public List<string> Get_SoLuongQuanLyConCu(string maDonViQuanLy, string maTaiSan)
        {
            List<string> lst = new List<string>();
            try
            {
                string query = string.Format(@"Select a.{9} From {0}.{1} a 
                                                                        inner join {0}.{2} b on a.{3} = b.{4} 
                                                                        Where b.{5} = '{6}' AND b.{4} = '{7}' AND a.{8} = '0'"
                     , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_SuDungLL.col_MaTaiSan
                     , cls_TaiSan_DanhMuc.col_Ma, cls_TaiSan_DanhMuc.col_MaKPQuanLy, maDonViQuanLy, maTaiSan, cls_TaiSan_SuDungLL.col_SuDung
                     , cls_TaiSan_SuDungLL.col_MaVach);

                DataTable dtMaVach = _acc.Get_Data(query);
                foreach (DataRow item in dtMaVach.Rows)
                {
                    lst.Add(item[cls_TaiSan_SuDungLL.col_MaVach].ToString());
                }
            }
            catch
            {
            }
            return lst;
        }

        public string Get_SoLuongDaSuDung(string maDonViSuDung, string maTaiSan)
        {
            try
            {
                string query = string.Format("Select Count(*) As SoLuongSuDung From {0}.{1} Where {2} = '{3}' AND {4} = '{5}' AND {6} = '1'"
                                            , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_MaKPSuDung, maDonViSuDung
                                            , cls_TaiSan_SuDungLL.col_MaTaiSan, maTaiSan, cls_TaiSan_SuDungLL.col_SuDung);
                return XL_DONG.Doc(query)["SoLuongSuDung"].ToString();
            }
            catch
            {
                return "0";
            }
        }

        public string Get_SoLuongSuDung(string maDonViSuDung, string maTaiSan)
        {
            try
            {
                string query = string.Format("Select Count(*) As SoLuongSuDung From {0}.{1} Where {2} = '{3}' AND {4} = '{5}' AND {6} = '1'"
                                            , _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang, cls_TaiSan_SuDungLL.col_MaKPSuDung, maDonViSuDung
                                            , cls_TaiSan_SuDungLL.col_MaTaiSan, maTaiSan, cls_TaiSan_SuDungLL.col_SuDung);
                return XL_DONG.Doc(query)["SoLuongSuDung"].ToString();
            }
            catch
            {
                return "0";
            }
        }

        public string Get_KyHieu(string maTaiSan)
        {
            try
            {
                string query = string.Format("Select {0} From {1}.{2} Where {3} = '{4}'"
                                            , cls_TaiSan_DanhMuc.col_KyHieu, _acc.Get_User(), cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_DanhMuc.col_Ma, maTaiSan);
                return XL_DONG.Doc(query)[cls_TaiSan_DanhMuc.col_KyHieu].ToString();
            }
            catch
            {
                return "";
            }
        }

        public DataTable Get_SoPhieuTuNhaCC(string nhacc)
        {
            try
            {
                string sSelect = string.Format("{0} as Ma, {0} as Ten ", cls_TaiSan_NhapLL.col_SoPhieu);
                string sWhere = string.Format("{0} = '{1}'", cls_TaiSan_NhapLL.col_MaNhaCungCap, nhacc);
                string query = string.Format("Select {0} From {1}.{2} where {3} ", sSelect, _acc.Get_User(), cls_TaiSan_NhapLL.tb_TenBang, sWhere);
                return XL_BANG.Doc(query);

                //string sSelect = string.Format("{0},{1},{2},{3}", cls_TaiSan_NhapCT.col_Ma, cls_TaiSan_NhapCT.col_TenTaiSan, cls_TaiSan_NhapCT.col_SoLuongCon, cls_TaiSan_NhapCT.col_MaTaiSan);
                //string query = string.Format("Select {0} From {1}.{2} ", sSelect, _acc.Get_User(), cls_TaiSan_NhapCT.tb_TenBang);
                //return XL_BANG.Doc(query);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_TaiSanTheoPhieuNhap(string sophieu)
        {
            try
            {
                string sSelect = string.Format("select c.{0} AS {1}, a.*,(a.{2} - a.{3}) AS SoLuongMin,0 AS Sua "
                                                 , cls_TaiSan_DanhMuc.col_Ten, cls_TaiSan_NhapCT.col_TenTaiSan
                                                 , cls_TaiSan_NhapCT.col_SoLuong, cls_TaiSan_NhapCT.col_SoLuongCon);

                string sFrom = string.Format(" from {0}.{1} a inner join {0}.{2} b on a.{3} = b.{4} inner join {0}.{5} c on a.{6} = c.{7}"
                                                , _acc.Get_User(), cls_TaiSan_NhapCT.tb_TenBang, cls_TaiSan_NhapLL.tb_TenBang
                                                , cls_TaiSan_NhapCT.col_Ma_NhapLL, cls_TaiSan_NhapLL.col_Ma
                                                , cls_TaiSan_DanhMuc.tb_TenBang, cls_TaiSan_NhapCT.col_MaTaiSan, cls_TaiSan_DanhMuc.col_Ma);

                string sWhere = string.Format(" where b.{0} = '{1}' ORDER BY a.{2}"
                                    , cls_TaiSan_NhapLL.col_SoPhieu, sophieu, cls_TaiSan_NhapCT.col_TenTaiSan);

                string squery = sSelect + sFrom + sWhere;
                return _acc.Get_Data(squery);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_TatCaSophieuNhap()
        {
            try
            {

                string sql = string.Format("select distinct sophieu as ma, sophieu as ten from {0}.{1} order by sophieu", _acc.Get_User(), cls_TaiSan_NhapLL.tb_TenBang);
                DataTable dt = _acc.Get_Data(sql);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_CauTrucImportNhapTaISan()
        {
            try
            {
                //DataTable dt = _acc.Get_Data("select A.ID,A.MA,A.SOPHIEU,A.NGAYNHAP,A.MANCC,B.MA_NHAPLL,B.MATAISAN,B.TENTAISAN,B.SOLUONG,B.SOLUONGCON,B.KYHIEU from hisbvnhitp.taisan_nhapll A inner join hisbvnhitp.taisan_nhapct B on A.MA=B.MA_NHAPLL");
                DataTable dtNhapTaISan = new DataTable();
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapLL.col_ID);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapLL.col_Ma);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapLL.col_SoPhieu);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapLL.col_NgayNhap);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapLL.col_MaNhaCungCap);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapCT.col_Ma_NhapLL);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapCT.col_MaTaiSan);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapCT.col_TenTaiSan);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapCT.col_SoLuong);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapCT.col_SoLuongCon);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapCT.col_KyHieu);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapCT.col_DonGia);
                dtNhapTaISan.Columns.Add(cls_TaiSan_NhapCT.col_ThanhTien);


                return dtNhapTaISan;
            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_TatCaSophieuSuDung()
        {
            try
            {

                string sql = string.Format("select distinct sophieu as ma, sophieu as ten from {0}.{1} order by sophieu", _acc.Get_User(), cls_TaiSan_SuDungLL.tb_TenBang);
                DataTable dt = _acc.Get_Data(sql);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataRow Get_NhapCTTheoMa(string maNhapCT)
        {
            try
            {
                DataTable dtNhapCT = new DataTable();
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_TaiSan_NhapCT.col_Ma, maNhapCT);
                dtNhapCT = _api.Search(ref _userError, ref _systemError, cls_TaiSan_NhapCT.tb_TenBang, dicEqual: dicE
                                                    , orderByASC1: true, orderByName1: cls_TaiSan_NhapCT.col_Ma);
                return dtNhapCT.Rows[0];
            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_SuDungLLTheoSoPhieu(string soPhieu)
        {
            try
            {
                DataTable dtSuDungLL = new DataTable();
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_TaiSan_SuDungLL.col_SoPhieu, soPhieu);
                dtSuDungLL = _api.Search(ref _userError, ref _systemError, cls_TaiSan_SuDungLL.tb_TenBang, dicEqual: dicE
                                                    , orderByASC1: true, orderByName1: cls_TaiSan_SuDungLL.col_Ma);
                return dtSuDungLL;
            }
            catch
            {
                return null;
            }
        }

        #region Load tài sản đã nhập

        public DataTable Get_TaiSanTheoSoPhieuCT(string soPhieu)
        {
            try
            {
                string sql = string.Format("select * from {0}.{1} ", _acc.Get_User(), cls_TaiSan_NhapLL.tb_TenBang);
                return _acc.Get_Data(sql);

            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Báo cáo nhập xuất tồn
        public DataTable Get_BaoCaoNhapXuatTon(string tuNgay, string DenNgay)
        {
            try
            {
                string sql = "select Tentaisan, sum(TongNhap) as TongNhap,sum(DaXuat) as DaXuat,sum(TongNhap-DaXuat)as ConLai from (";
                sql += "select TENTAISAN,count(MA)as TongNhap,CAST(0 as int) as DaXuat,CAST(0 as int) as ConLai  from HISBVNHITP.Taisan_sudungll where NgayTao>=TO_DATE('" + tuNgay + "','DD/MM/YYYY') and NgayTao<=TO_DATE('" + DenNgay + "','DD/MM/YYYY')";
                sql += " group by TENTAISAN UNION";
                sql += "                    select Tentaisan,CAST(0 as int) as TongNhap,count(MA) as DaXuat,CAST(0 as int) as ConLai from HISBVNHITP.Taisan_sudungll where SuDung=1 and NgayTao>=TO_DATE('" + tuNgay + "','DD/MM/YYYY') and NgayTao<=TO_DATE('" + DenNgay + "','DD/MM/YYYY')";
                sql += "                    group by Tentaisan";
                sql += "                    )x group by Tentaisan";
                DataTable dt = _acc.Get_Data(sql);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #endregion

        #endregion

    }
}
