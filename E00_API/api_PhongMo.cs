using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E00_Common;
using System.Data;
using E00_Model;

namespace E00_API
{
    public partial class api_PhongMo
    {
        #region Biến toàn cục
        public static Acc_Oracle _acc = new Acc_Oracle();
        private static Api_Common _api = new Api_Common();
        private static string _userError = "";
        private static string _systemError = "";

        #endregion

        #region Khởi tạo

        public api_PhongMo()
        {
            _api.KetNoi();
        }
        #endregion

        #region Phương thức
        #region Get

        #region Lấy thông tin khai bao phòng mổ
        /// <summary>
        ///  Lấy thông tin khai bao phòng mổ
        /// </summary>
        /// <Date>19/07/2018</Date>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <param name="maChiDinh">Truyền mã chỉ định</param>
        /// <returns></returns>
        public static DataTable Get_KhaiBaoChiDinh(string maChiDinh)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select a.MaChiDinh from {0}.{1}  a inner join {0}.{2} b on a.VaiTro = b.Ma inner join {0}.{1} c on a.MACHIDINH = c.ID	 where {3}='{4}'";
                sql = string.Format(sql, _acc.Get_User());
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region Lấy danh sách duyệt lịch PTTT
        /// <summary>
        /// Lấy danh sách duyệt lịch PTTT
        /// </summary>
        /// <param name="tuNgay">nhập từ ngày</param>
        /// <param name="denNgay">nhập dến ngày</param>
        /// <param name="duyet">nếu đã duyệt nhập true ngược lại nhập false</param>
        /// <returns></returns>
        public static DataTable GetDanhSachLichPTTT(string tuNgay, string denNgay, bool duyet, string mabn)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                sql = "select a.ID,f.MANV as MABS,f.HOTEN as BACSY,g.TEN as VAITRO,a.MAVAOVIEN,a.MAQL,f.MABOPHAN as MAKP,d.TENKP,to_char(a.NGAYHOICHAN,'dd/mm/yyyy HH24:mi:ss') as NGAYHOICHAN,a.MAICD,c.vviet,to_char(a.NGAYHOICHAN,'dd/mm/yyyy HH24:mi:ss') as NGAYTHUCHIEN,a.LOAI,e.DUYET " +
                    "from {0}.{1} a";
                sql += " inner join {0}.{2} b on a.mabn = b.MABN";
                sql += " inner join {0}.{3} c on a.MAICD = c.CICD10";
                sql += " inner join {0}.{4} d on a.makp= d.MAKP";
                sql += " inner join {8}.{5} e on a.id= e.id";
                sql += " inner join {0}.{6} f on e.MANV= f.MANV";
                sql += " left join {0}.{7} g on e.VAITRO= g.MA";
                sql += " where to_char(a.NGAYHOICHAN,'mm/dd/yyyy')>='" + tuNgay + "' and to_char(a.NGAYHOICHAN,'mm/dd/yyyy')<='" + denNgay + "' ";
                if (!duyet)
                {
                    sql += "  and e.Duyet='0' and e.Loai='HoiChan'";
                }
                else
                {
                    sql += "  and e.Duyet='1' and e.Loai='HoiChan'";
                }
                sql += " and a.MABN='{9}'";
                sql += "  order by a.NGAYHOICHAN";
                sql = string.Format(sql, _acc.Get_User(), cls_HoiChan.tb_TenBang, cls_BTDBN.tb_TenBang, cls_ICD10.tb_TenBang, cls_BTDKP_BV.tb_TenBang, cls_NhanVienPTTT.tb_TenBang, cls_NhanSu_LiLichNhanVien.tb_TenBang, cls_VaiTro.tb_TenBang, _acc.Get_UserMMYY(),mabn);
                dt = _acc.Get_Data(sql);
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region Lấy danh mục vai trò
        /// <summary>
        /// Lấy danh mục vai trò
        /// </summary>
        /// <returns>Datatable vai trò</returns>
        public static DataTable Get_VaiTro()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = _acc.Get_Data(string.Format("select  MA,TEN  from {0}.{1}", _acc.Get_User(), cls_VaiTro.tb_TenBang));
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region Lấy danh mục chỉ định
        public static DataTable Get_ChiDinh()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = _acc.Get_Data(string.Format("select  A.MA,A.TEN  from {0}.{1} a inner join {0}.V_DMTHONGTU b on a.id=b.ID_GIAVP where b.LOAI like '%T%' or b.LOAI like '%P%'"
                , _acc.Get_User(), cls_V_GiaVienPhi.tb_TenBang));
            }
            catch (Exception)
            {
            }
            return dt;
            
        }
        #endregion

        #region Lấy danh sách bác sỹ
        /// <summary>
        /// Lấy danh sách bác sỹ
        /// </summary>
        /// <Người>Nguyễn Văn Lợi</Người>
        /// <Ngày>21/07/2018</Ngày>
        /// <returns>Danh sách bác sỹ</returns>
        public static DataTable GetBacSy()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = _acc.Get_Data(string.Format("select  {0},{1}  from {2}.{3} order by {0}", cls_NhanSu_LiLichNhanVien.col_MaNhanVien,cls_NhanSu_LiLichNhanVien.col_HoTen, _acc.Get_User(), cls_NhanSu_LiLichNhanVien.tb_TenBang));
            }
            catch (Exception)
            {
            }
            return dt;

        }
        #endregion

        #region Lấy phụ cấp phẩu thuật thủ thuật theo bác sỹ
        /// <summary>
        /// Lấy phụ cấp phẩu thuật thủ thuật theo bác sỹ
        /// </summary>
        ///<Người>Nguyễn Văn Lợi</Người>
        ///<Ngày>21/07/2018</Ngày>
        /// <returns>Phụ cấp của bác sỹ được chọn</returns>
        public static DataTable Get_PhuCapBacSy(string MaBS)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = _acc.Get_Data(string.Format("select {0} as ViTri,sum({1}) as PHUCAP from (select distinct c.ID,f.{0},e.{1} from {2}.{3} a inner join {4}.{5} b on a.ID = b.ID  inner join {2}.{6} c on a.ID = b.ID  inner join {4}.{7} d on c.mavp = d.ID  inner join {4}.{8} e on d.ID = e.MAVP and a.VAITRO = e.vaitro  inner join {4}.{9} f on e.vaitro = f.ma  where a.loai = 'TuongTrinh' and a.{10}='{11}')x  GROUP BY {0} ", cls_VaiTro.col_TEN,cls_PhuCapPhongMo.col_PhuCap,_acc.Get_UserMMYY(),cls_NhanVienPTTT.tb_TenBang, _acc.Get_User(), cls_HoiChan.tb_TenBang,cls_V_ChiDinh.tb_TenBang,cls_V_GiaVienPhi.tb_TenBang,cls_PhuCapPhongMo.tb_TenBang, cls_VaiTro.tb_TenBang,cls_NhanVienPTTT.col_MaNV,MaBS));
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion
        #endregion

        #region Insert 

        #region Insert khai bao phụ cấp mổ
        public static void InsertKhaiBaoPhuCapMo(DataTable temp,List<string> lstDelete,string MaVP)
        {
            if (lstDelete.Count > 0)
            {
                for (int i = 0; i < lstDelete.Count; i++)
                {
                    string sql = "Delete {0}.{1} where {2}='{3}' and {4}='{5}'";
                    sql = string.Format(sql, _acc.Get_User(), cls_PhuCapPhongMo.tb_TenBang, cls_PhuCapPhongMo.col_MaVP, MaVP, cls_PhuCapPhongMo.col_VaiTro, lstDelete[i]);
                    _acc.Execute_Data(ref _userError, ref _systemError, sql);
                }
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                int ID = 0;
                if (_acc.Get_Data(string.Format("Select max(ID) from {0}.{1}", _acc.Get_User(), cls_PhuCapPhongMo.tb_TenBang)).Rows[0][0].ToString() == "")
                {
                    ID = 0;
                }
                else
                {
                    ID = int.Parse(_acc.Get_Data(string.Format("Select max(ID) from {0}.{1}", _acc.Get_User(), cls_PhuCapPhongMo.tb_TenBang)).Rows[0][0].ToString());
                }
                string sql = "insert into {0}.{1}({2},{3},{4},{5},{6}) values('{7}','{8}','{9}','{10}','{11}')";
                sql = string.Format(sql, _acc.Get_User(), cls_PhuCapPhongMo.tb_TenBang, cls_PhuCapPhongMo.col_ID, cls_PhuCapPhongMo.col_MaVP, cls_PhuCapPhongMo.col_PhuCap, cls_PhuCapPhongMo.col_TongTien, cls_PhuCapPhongMo.col_VaiTro,
                    ID + 1, "" + temp.Rows[i][cls_PhuCapPhongMo.col_MaVP] + "",
                    "" + temp.Rows[i][cls_PhuCapPhongMo.col_PhuCap] + "", "" + temp.Rows[i][cls_PhuCapPhongMo.col_TongTien] + "", "" + temp.Rows[i][cls_PhuCapPhongMo.col_VaiTro] + "");
                try
                {
                    if (_acc.Get_Data(string.Format("Select {0} from {1}.{2} where {3}='{4}' and {5}='{6}' and {7}='{8}'", cls_PhuCapPhongMo.col_ID, _acc.Get_User(), cls_PhuCapPhongMo.tb_TenBang, cls_PhuCapPhongMo.col_MaVP, "" + temp.Rows[i][cls_PhuCapPhongMo.col_MaVP] + "", cls_PhuCapPhongMo.col_VaiTro, "" + temp.Rows[i][cls_PhuCapPhongMo.col_VaiTro] + "",cls_PhuCapPhongMo.col_PhuCap, "" + temp.Rows[i][cls_PhuCapPhongMo.col_PhuCap] + "")).Rows[0][0].ToString() != "")
                    { }
                }
                catch (Exception)
                {
                 string sql2 = "Update {0}.{1} set {2}='{3}' where {4}='{5}' and {6}='{7}' ";
                    sql2 = string.Format(sql2, _acc.Get_User(), cls_PhuCapPhongMo.tb_TenBang, cls_PhuCapPhongMo.col_PhuCap,temp.Rows[i][cls_PhuCapPhongMo.col_PhuCap],cls_PhuCapPhongMo.col_MaVP, temp.Rows[i][cls_PhuCapPhongMo.col_MaVP],cls_PhuCapPhongMo.col_VaiTro, temp.Rows[i][cls_PhuCapPhongMo.col_VaiTro]);
                    if (_acc.Execute_Data(ref _userError, ref _systemError, sql2))
                    {
                        
                    }
                    else {
                        _acc.Execute_Data(ref _userError, ref _systemError, sql);
                    }
                }

            }
            TA_MessageBox.MessageBox.Show("Lưu thành công", TA_MessageBox.MessageIcon.Information);


        }
        #endregion
        #endregion

        #endregion
    }
}
