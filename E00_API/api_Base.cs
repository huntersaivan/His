using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using E00_Model;
using E00_Common;
using System.Globalization;

namespace E00_API
{
    public partial class api_Base
    {

        #region Biến toàn cục

        private Api_Common _api = new Api_Common(); 

        #endregion

        #region Khởi tạo

        public api_Base()
        {
            _api.KetNoi();
        } 

        #endregion

        #region Phương thức

        #region Load_DanhMucFull (Lấy tất cả thông tin của bảng SYS_DanhMuc theo mã loại)
        /// <summary>
        /// Lấy tất cả thông tin của bảng SYS_DanhMuc theo mã loại
        /// </summary>
        /// <author>Nguyễn Văn Long (Long dài)</author>
        /// <Date>17/05/2018</Date>
        /// <param name="userError">Trả về lỗi cho người dùng</param>
        /// <param name="systemError">Trả về lỗi của hệ thống</param>
        /// <param name="maLoai">Mã loại xác định dữ liệu</param>
        /// <returns></returns>
        public DataTable Load_DanhMucFull(ref string userError, ref string systemError, string maLoai)
        {
            try
            {
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_SYS_DanhMuc.col_Loai, maLoai);

                return _api.Search(ref userError, ref systemError, cls_SYS_DanhMuc.tb_TenBang, dicEqual: dicE, orderByName1: cls_SYS_DanhMuc.col_ID);
            }
            catch
            {
                return null;
            }
        }

       

        #endregion

        #region Load_DanhMuc (Lấy thông tin cột mà, tên của bảng SYS_DanhMuc theo mã loại)
        /// <summary>
        /// Lấy thông tin cột mà, tên của bảng SYS_DanhMuc theo mã loại
        /// </summary>
        /// <author>Nguyễn Văn Long</author>
        /// <Date>17/05/2018</Date>
        /// <param name="userError">Trả về lỗi cho người dùng</param>
        /// <param name="systemError">Trả về lỗi của hệ thống</param>
        /// <param name="maLoai">Mã loại xác định dữ liệu</param>
        /// <returns></returns>
        public DataTable Load_DanhMuc(ref string userError, ref string systemError, string maLoai)
        {
            try
            {
                Dictionary<string, string> dicE = new Dictionary<string, string>();
                dicE.Add(cls_SYS_DanhMuc.col_Loai, maLoai);

                List<string> lstCot = new List<string>();
                lstCot.Add(cls_SYS_DanhMuc.col_Ma);
                lstCot.Add(cls_SYS_DanhMuc.col_Ten);

                return _api.Search(ref userError, ref systemError, cls_SYS_DanhMuc.tb_TenBang, dicEqual: dicE, lst: lstCot, orderByName1: cls_SYS_DanhMuc.col_ID);
            }
            catch
            {
                return null;
            }
        }

        #endregion 


        #endregion

    }
}
