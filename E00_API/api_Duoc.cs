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
	public partial class api_Duoc
	{
		#region Biến toàn cục
		private bus_Duoc _busDuoc = new bus_Duoc();
		#endregion

		#region Khởi tạo
		public api_Duoc()
		{

		}

		#endregion

		#region Phương thức
		#region InsertData

		#endregion

		#region UpdateData
		#region Update số lượng thực
		/// <summary>
		/// Cập nhật số lượng thực
		/// </summary>
		/// <author>Phạm Thế Mỹ</author>
		/// <date>27/07/2018</date>
		/// <param name="table"></param>
		/// <param name="mmyy"></param>
		/// <param name="idDuyet"></param>
		/// <param name="table2"></param>
		/// <param name="ngay"></param>
		/// <returns></returns>
		public bool UpdateSoLuongThuc(string table, string mmyy, decimal idDuyet, string table2, string ngay)
		{
			try
			{
				return _busDuoc.UpdateSoLuongThuc(table, mmyy, idDuyet, table2, ngay);
			}
			catch (Exception)
			{
				return false;
			}
		} 
		#endregion

		public void UpdateDDuyet(string mmyy, int maKP, int nhom, int loai, int phieu, string ngay, string maKho)
		{
			try
			{
				_busDuoc.UpdateDDuyet(mmyy, maKP, nhom, loai, phieu, ngay, maKho);
			}
			catch (Exception)
			{
			}
		}

		public bool UpdateDTreoDuyet(decimal id, int stt)
		{
			return _busDuoc.UpdateDTreoDuyet(id, stt);
		}

		public void UpdateDTheoDoiDuyet(string mmyy, string ngay, int nhom, int loai, int makp, int done)
		{
			_busDuoc.UpdateDTheoDoiDuyet(mmyy, ngay, nhom, loai, makp, done);
			return;

		}

		public void Update_D_DuyetKhoDone(string tu, string den, int done, string id, string makho = "")
		{
			Dictionary<string, string> dicData = new Dictionary<string, string>();
			Dictionary<string, string> dicWhere = new Dictionary<string, string>();
			List<string> lstDateTime = new List<string>();
			dicData.Add(cls_D_DuyetKho.col_DONE, done.ToString());

			dicWhere.Add(cls_D_DuyetKho.col_IDDUYET, id);
			if (string.IsNullOrEmpty(makho))
			{
				dicWhere.Add(cls_D_DuyetKho.col_MAKHO, makho);
			}
			_busDuoc.Update_D_DuyetKho(tu, den, dicData, dicWhere, lstDateTime);
		}
		public DataRow GetRowbyId(DataTable dt, string exp)
		{
			return _busDuoc.GetRowbyId(dt, exp);
		}
		public DataTable Getd_dmbdtd(int maBd)
		{
			return _busDuoc.Getd_dmbdtd(maBd);
		}
		public void Update_D_DuyetDone(string tu, string den, int done, string id)
		{
			Dictionary<string, string> dicData = new Dictionary<string, string>();
			Dictionary<string, string> dicWhere = new Dictionary<string, string>();
			List<string> lstDateTime = new List<string>();

			dicData.Add(cls_D_Duyet.col_DONE, done.ToString());

			dicWhere.Add(cls_D_Duyet.col_ID, id);


			_busDuoc.Update_D_Duyet(tu, den, dicData, dicWhere, lstDateTime);
		}

		public bool UpdateOrInsertDDangDuyet(int d_nhom, string d_tu, string d_den, int d_loai, string d_makp)
		{
			if (!_busDuoc.UpdateDDangDuyet(d_nhom, d_tu, d_den, d_loai, d_makp))
			{
				return _busDuoc.InsertDDangDuyet(d_nhom, d_tu, d_den, d_loai, d_makp);
			}
			return true;

		}
		public bool UpdateOrInsertNgayDuyet(string mmyy, int nhom, int loai, int phieu, int maKP, string ngay, decimal idDuyet, string maKho, string sttDuyet)
		{
			if (!_busDuoc.Update_D_NgayDuyet(mmyy, nhom, loai, phieu, maKP, ngay, idDuyet, maKho, sttDuyet))
			{
				return _busDuoc.Insert_D_NgayDuyet(mmyy, nhom, loai, phieu, maKP, ngay, idDuyet, maKho, sttDuyet);
			}
			return true;
		}
		public bool UpdateOrInsertDDaDuyet(string mmyy, int nhom, string ngay, int maKP, int loai, int phieu, int maKho, int duyetTreoLe)
		{
			if (!_busDuoc.Update_D_DaDuyet(mmyy, nhom, ngay, maKP, loai, phieu, maKho, duyetTreoLe))
			{
				return _busDuoc.Insert_D_DaDuyet(mmyy, nhom, ngay, maKP, loai, phieu, maKho, duyetTreoLe);
			}
			return true;

		}
		public bool UpdateOrInsertDXuatSDLL(string mmyy, decimal id, int nhom, string maBenhNhan, decimal maVaoVien, decimal maQL, decimal idKhoa, string ngay, int loai, int phieu, int maKP, int userID, decimal idDuyet, int thuoc, int maKhoa, int lyDo, int lk, string ghiChu, string ngayYLenh, string maBS, string maICD)
		{
			if (!_busDuoc.Update_D_XuatSDLL(mmyy, id, nhom, maBenhNhan, maVaoVien, maQL, idKhoa, ngay, loai, phieu, maKP, userID, idDuyet, thuoc, maKhoa, lyDo, lk, ghiChu, ngayYLenh, maBS, maICD))
			{
				return _busDuoc.Insert_D_XuatSDLL(mmyy, id, nhom, maBenhNhan, maVaoVien, maQL, idKhoa, ngay, loai, phieu, maKP, userID, idDuyet, thuoc, maKhoa, lyDo, lk, ghiChu, ngayYLenh, maBS, maICD);
			}
			return true;

		}
		public bool UpdateOrInsertDThucXuat(string mmyy, decimal id, decimal sttt, int maDoiTuong, int maKho, int maBD, decimal soLuong, decimal stt, decimal giaBan, decimal viTri)
		{
			if (!_busDuoc.Update_D_ThucXuat(mmyy, id, sttt, maDoiTuong, maKho, maBD, soLuong, stt, giaBan, viTri))
			{
				return _busDuoc.Insert_D_ThucXuat(mmyy, id, sttt, maDoiTuong, maKho, maBD, soLuong, stt, giaBan, viTri);
			}
			return true;

		}
		public bool caculated_tonkhoth(string _mmyy, int nhom, int loai)
		{
			return _busDuoc.caculated_tonkhoth(_mmyy, nhom, loai);
		}
		public void phieu_dutru(DataTable dt, string s_mmyy, string s_ngay, int i_nhom, int i_makp, int i_loai, int i_phieu, bool bPhattron, int i_thuoc, string s_kho, int itable, bool bBuhaophi, bool _b1kho, int i_userid, string file2)
		{
			_busDuoc.phieu_dutru(dt, s_mmyy, s_ngay, i_nhom, i_makp, i_loai, i_phieu, bPhattron, i_thuoc, s_kho, itable, bBuhaophi, _b1kho, i_userid, file2);
		}
		#endregion


		#region LoadData
		public DataTable GetDanhMucBietDuoc(int nhom)
		{
			try
			{
				return _busDuoc.GetDanhMucBietDuoc().Select(cls_D_DMBD.col_NHOM + " ='" + nhom + "'").CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetNgayTheoDoiDuyet(string mmyy, int nhom, int loai, int maKP)
		{
			try
			{
				return _busDuoc.GetNgayTheoDoiDuyet(mmyy).Select(cls_D_TheoDoiDuyet.col_NHOM + " ='" + nhom + "' and " + cls_D_TheoDoiDuyet.col_LOAI + "='" + loai + "' and " + cls_D_TheoDoiDuyet.col_MAKP + "='" + maKP + "'", cls_D_TheoDoiDuyet.col_NGAY).CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDanhMucPhieu(int nhom, int loai)
		{
			try
			{
				return _busDuoc.GetDanhMucPhieu().Select(cls_D_LoaiPhieu.col_NHOM + " ='" + nhom + "' and " + cls_D_LoaiPhieu.col_LOAI + "='" + loai + "'", cls_D_LoaiPhieu.col_STT).CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDanhMucKhoDuoc(int nhom)
		{
			try
			{
				return _busDuoc.GetDanhMucKhoDuoc().Select(cls_D_DMKho.col_NHOM + " ='" + nhom + "'", cls_D_DMKho.col_STT).CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDanhMucKhoDuocTheoKho(string s_kho)
		{
			try
			{
				string sql = cls_D_DMKho.col_ID + " in (" + s_kho.Substring(0, s_kho.Length - 1) + ") ";

				DataTable ret = _busDuoc.GetDanhMucKhoDuoc();
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

		public DataTable GetDanhMucKhoDuocTheoKho(int nhom, string s_kho)
		{
			try
			{
				string sql = cls_D_DMKho.col_NHOM + " ='" + nhom + "' "
				+ (s_kho != "" ? (" AND " + cls_D_DMKho.col_ID + " in (" + s_kho.Substring(0, s_kho.Length - 1) + ") ") : "");

				DataTable ret = _busDuoc.GetDanhMucKhoDuoc();
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

		#region Phạm Thế Mỹ 10/07/2018 Load Danh mục khoa phòng 
		/// <summary>
		/// Phạm Thế Mỹ 10/07/2018
		/// Load Danh mục khoa phòng 
		/// </summary>
		/// <param name="Nhom">Nhóm</param>
		/// <param name="Makp">Mã Khoa Phòng =null => load hết </param>
		/// <param name="Khu">Khu =null => load hết</param>
		/// <returns></returns>
		public DataTable GetDanhMucKhoaPhongDuoc(int Nhom, string Makp, int Khu)
		{
			try
			{
				string sql = cls_D_DuocKP.col_NHOM + " like '%" + Nhom.ToString() + ",%' ";
				if (!string.IsNullOrEmpty(Makp))
				{
					sql += " and " + cls_D_DuocKP.col_ID + " in (" + Makp.Substring(0, Makp.Length - 1) + ")";
				}
				if (Khu != 0)
				{
					sql += " and" + cls_D_DuocKP.col_KHU + " in (0," + Khu + ")";
				}
				DataTable ret = _busDuoc.GetDanhMucKhoaPhongDuoc();
				if (ret.Rows.Count > 0)
				{
					ret = ret.Select(sql, cls_D_DuocKP.col_TEN).CopyToDataTable();
				}

				return ret;
			}
			catch (Exception)
			{
				return null;
			}
		}
		#endregion

		#region Phạm Thế Mỹ 10/07/2018 Load Danh mục khoa phòng có chọn lọc

		/// <summary>
		/// Phạm Thế Mỹ 10/07/2018
		/// Load Danh mục khoa phòng có chọn lọc
		/// </summary>
		/// <param name="Nhom">Nhóm</param>
		/// <param name="Loai"></param>
		/// <param name="Ngay"></param>
		/// <param name="Makp"></param>
		/// <param name="Khu"></param>
		/// <returns></returns>

		public DataTable GetDanhMucKhoaPhongDuoc(int Nhom, int Loai, string Ngay, string Makp, int Khu, string _mmyy)
		{
			try
			{

				string sql = cls_D_DuocKP.col_NHOM + " like '%" + Nhom.ToString() + ",%' ";
				if (!string.IsNullOrEmpty(Makp))
				{
					sql += " and " + cls_D_DuocKP.col_ID + " in (" + Makp.Substring(0, Makp.Length - 1) + ")";
				}
				if (Khu != 0)
				{
					sql += " and" + cls_D_DuocKP.col_KHU + " in (0," + Khu + ")";
				}
				DataTable ret = _busDuoc.GetDanhMucKhoaPhongDuocJoinDuyet(Loai, Ngay, _mmyy);
				if (ret.Rows.Count > 0)
				{
					ret = ret.Select(sql, cls_D_DuocKP.col_TEN).CopyToDataTable();
				}

				return ret;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		#region Phạm Thế Mỹ 10/07/2018 Load Danh mục loại phiếu 

		/// <summary>
		/// Phạm Thế Mỹ 10/07/2018
		/// Load Danh mục loại phiếu 
		/// </summary>
		/// <returns></returns>

		public DataTable GetDanhMucPhieu()
		{
			try
			{

				string sql = cls_D_LoaiPhieu.col_ID + " = 0 ";
				DataTable ret = _busDuoc.GetDanhMucPhieu();
				if (ret.Rows.Count > 0)
				{
					ret = ret.Select(sql, cls_D_LoaiPhieu.col_STT).CopyToDataTable();
				}

				return ret;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		//public bool GetBoolGiaban()
		//{
		//	return _busDuoc.GetBoolGiaban();
		//}

		public DataTable get_xuatsdcts(string mmyy, DataRow[] r, string str, decimal id, decimal idduyet, bool bPhattron, int thuoc, int loai, string file, int makp, int makhoa, string mabn, decimal mavaovien, decimal maql, decimal idkhoa, string ngay, decimal sltd, bool bBuhaophi, string ngayylenh, bool bDuyettreole, int nhom, string mabs, string maicd)
		{
			return _busDuoc.get_xuatsdcts(mmyy, r, str, id, idduyet, bPhattron, thuoc, loai, file, makp, makhoa, mabn, mavaovien, maql, idkhoa, ngay, sltd, bBuhaophi, ngayylenh, bDuyettreole, nhom, mabs, maicd);

		}
		public bool b1kho(string makho)
		{
			if (makho == "") return false;
			else
			{
				int i = 0;
				for (int j = 0; j < makho.Length; j++)
					if (makho.Substring(j, 1) == ",") i++;
				return i < 2;
			}
		}
		#region Phạm Thế Mỹ 10/07/2018 Load Danh mục loại phiếu 

		/// <summary>
		/// Phạm Thế Mỹ 10/07/2018
		/// Load Danh mục loại phiếu 
		/// </summary>
		/// <returns></returns>

		public DataTable GetDanhMucPhieu(int Nhom, string s_kho, int i_loai, string makp, string mmyy, string ngay)
		{
			try
			{
				string str = "";
				string str2 = "";
				string str3 = "";
				string sql = cls_D_DMKho.col_NHOM + " ='" + Nhom.ToString() + "' ";
				if (s_kho != "")
				{
					sql = sql + " and " + cls_D_DMKho.col_ID + " in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
				}
				DataTable dmkho = _busDuoc.GetDanhMucKhoDuoc();
				if (dmkho.Rows.Count > 0)
				{
					dmkho = dmkho.Select(sql).CopyToDataTable();
				}
				foreach (DataRow row in dmkho.Rows)
				{
					if (str.IndexOf(row["phieu"].ToString()) == -1)
					{
						str = str + row["phieu"].ToString();
					}
					if (str2.IndexOf(row["loaiphieu"].ToString()) == -1)
					{
						str2 = str2 + row["loaiphieu"].ToString();
					}
				}
				DataTable xuatsudungll = _busDuoc.GetXuatSuDungLL(Nhom, i_loai, makp, mmyy, ngay);
				foreach (DataRow row2 in xuatsudungll.Rows)
				{
					if (str3.IndexOf(row2["phieu"].ToString()) == -1)
					{
						str3 = str3 + row2["phieu"].ToString() + ",";
					}
				}
				sql = cls_D_LoaiPhieu.col_ID + " >= 0 AND " + cls_D_LoaiPhieu.col_NHOM + " = " + Nhom;
				sql = sql + " AND " + cls_D_LoaiPhieu.col_LOAI + " = " + i_loai;
				if ((!string.IsNullOrEmpty(str3)))
				{
					sql = sql + " and " + cls_D_LoaiPhieu.col_ID + " not in (" + str3.Substring(0, str3.Length - 1) + ")";
				}
				if ((str.IndexOf(i_loai.ToString()) != -1) && (!string.IsNullOrEmpty(str2)))
				{
					sql = sql + " and " + cls_D_LoaiPhieu.col_ID + " in (" + str2.Substring(0, str2.Length - 1) + ")";
				}
				sql = sql + " and " + cls_D_LoaiPhieu.col_ID + "<>0 ";

				DataTable ret = _busDuoc.GetDanhMucPhieu();
				if (ret.Rows.Count > 0)
				{
					ret = ret.Select(sql, cls_D_LoaiPhieu.col_STT).CopyToDataTable();
				}

				return ret;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		public DataTable getDuyetTuDen(string tu, string den, string s_makp, int i_loai, string s_phieuduyet, int songay)
		{
			string sql = cls_D_Duyet.col_DONE + " <>0 ";
			if (!string.IsNullOrEmpty(s_makp))
			{
				sql += " and " + cls_D_Duyet.col_MAKP + " = '" + s_makp + "' ";
			}

			sql += " and " + cls_D_Duyet.col_LOAI + " = " + i_loai + " ";

			if (!string.IsNullOrEmpty(s_phieuduyet))
			{
				sql += " and " + cls_D_Duyet.col_PHIEU + " in (" + s_phieuduyet.Substring(0, s_phieuduyet.Length - 1) + ")";
			}
			DataTable ret = _busDuoc.GetDuyetTuDen(tu, den, songay);
			if (ret.Rows.Count > 0)
			{
				try
				{
					ret = ret.Select(sql).CopyToDataTable();
				}
				catch (Exception)
				{
					ret.Rows.Clear();
					return ret;
				}
			}
			return ret;

		}

		public string GetMakpDuyetTuDen(string tu, string den, string s_makhoa, int i_loai, int nhom, string s_phieuduyet, int songay)
		{
			try
			{
				string sql = cls_D_Duyet.col_DONE + " <>0 ";
				if (!string.IsNullOrEmpty(s_makhoa))
				{
					sql += " and " + cls_D_Duyet.col_MAKHOA + " = '" + s_makhoa + "' ";
				}

				if (!string.IsNullOrEmpty(s_phieuduyet))
				{
					sql += " and" + cls_D_Duyet.col_PHIEU + " in (" + s_phieuduyet.Substring(0, s_phieuduyet.Length - 1) + ")";
				}
				sql += " and" + cls_D_Duyet.col_LOAI + " = " + i_loai + " ";


				sql += " and" + cls_D_Duyet.col_NHOM + " = " + nhom + " ";

				DataTable ret = _busDuoc.GetDuyetTuDen(tu, den, songay);
				DataView view = new DataView(ret);
				ret = view.ToTable(true, cls_D_Duyet.col_MAKP);
				if (ret.Rows.Count > 0)
				{
					ret = ret.Select(sql).CopyToDataTable();
				}
				string str3 = "";
				foreach (DataRow row2 in ret.Rows)
				{
					if (str3.IndexOf(row2["makp"].ToString().PadLeft(3, '0') + ",") != -1)
					{
						str3 = str3 + row2["makp"].ToString().PadLeft(3, '0') + ",";
					}
				}
				return str3;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDanhMucPhieuHoanTra()
		{
			try
			{
				return _busDuoc.GetDanhMucPhieu().Select(cls_D_LoaiPhieu.col_ID + " ='0'", cls_D_LoaiPhieu.col_STT).CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDanhMucKhoaPhongDuoc(int nhom)
		{
			try
			{
				return _busDuoc.GetDanhMucKhoaPhongDuoc().Select(cls_D_DuocKP.col_NHOM + " like '%" + nhom.ToString() + ",%'", cls_D_DuocKP.col_STT).CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetCoSoTuTruc(int nhom, string mmyy)
		{
			try
			{
				return _busDuoc.GetDanhMucKhoaPhongDuoc().Select(cls_D_CoSoTuTruc.col_NHOM + " like '%" + nhom.ToString() + ",%' and " + cls_D_CoSoTuTruc.col_MMYY + "='" + mmyy + "'").CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDanhSachPhieuXuatSuDung(int nhom, int loai, string maKP, int userID, string mmyy, string ngay, bool thuHoi)
		{
			try
			{
				return _busDuoc.GetDanhSachPhieuXuatSuDung(nhom, loai, maKP, userID, mmyy, ngay, thuHoi);
			}
			catch (Exception)
			{
				return null;
			}
		}
		public DataTable GetDanhSachPhieuVaThuocXuatSuDung(int nhom, int loai, string maKP, int userID, string mmyy, string ngay, bool thuHoi, string s_kho)
		{
			try
			{
				return _busDuoc.GetDanhSachPhieuVaThuocXuatSuDung(nhom, loai, maKP, userID, mmyy, ngay, thuHoi, s_kho);
			}
			catch (Exception)
			{
				return null;
			}
		}
		public DataTable GetChiTietPhieuXuatSuDung(decimal idPhieu, string mmyy)
		{
			try
			{
				return _busDuoc.GetChiTietPhieuXuatSuDung(idPhieu, mmyy);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDanhSachThuocChoDuyet(int nhom, int loai, string ngay, int soNgay, string mmyy)
		{
			try
			{

				return _busDuoc.GetDanhSachThuocChoDuyet(nhom, loai, ngay, soNgay, mmyy);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetPhieuXuatSuDung(string tenFile, int nhom, int loai, string ngay, int maKP, string mmyy, string maKho, bool inTheoCSTT)
		{
			try
			{

				return _busDuoc.GetPhieuXuatSuDung(tenFile, nhom, loai, ngay, maKP, mmyy, maKho, inTheoCSTT);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDanhMucLoaiPhieuTheoPhieuXuat(int nhom, int loai, string sPhieu, string sPhieuK, string sLoai, bool load =true)
		{
			try
			{
				string sPK = "";
				string sP = "";
				if (!string.IsNullOrEmpty(sPhieu))
				{
					sP = sPhieu != "" ? (" and id "+(load? "not":"") + " in (" + sPhieu.Substring(0, sPhieu.Length - 1) + ")") : "";
				}
				if (sPhieuK != "")
				{
					sPK = sPhieuK.IndexOf(loai.ToString()) != -1 && sLoai != "" ? (" and id in (" + sLoai.Substring(0, sLoai.Length - 1) + ")") : "";
				}

				return _busDuoc.GetDanhMucPhieu().Select(cls_D_LoaiPhieu.col_NHOM + " ='" + nhom + "' and " + cls_D_LoaiPhieu.col_LOAI + "='" + loai + "' and id<>0 " + sP + sPK, cls_D_LoaiPhieu.col_STT).CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDuLieuPhieuDuyet(string ngay, int loai, bool inTheoCSTT, int maKP, int phieu, string str, string str2)
		{
			try
			{

				return _busDuoc.GetDuLieuPhieuDuyet(ngay, loai, inTheoCSTT, maKP, phieu, str, str2);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetDDaDuyet(string mmyy, int nhom, int loai, string ngay, int maKP, int phieu)
		{
			return _busDuoc.GetDDaDuyet(mmyy, nhom, loai, ngay, maKP, phieu);
		}

		public DataTable GetDanhMucKhoDuoc(string maKho)
		{
			try
			{
				string sqlQ = "";
				if (maKho != "")
				{
					sqlQ = cls_D_DMKho.col_ID + " in (" + maKho.Substring(0, maKho.Length - 1) + ")";
				}
				return _busDuoc.GetDanhMucKhoDuoc().Select(maKho != "" ? sqlQ : "", cls_D_DMKho.col_STT).CopyToDataTable();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable GetThongTinThuHoiXuatSDLL(int loai, bool buHaoPhi, bool inTheoCSTT, string ngay, int nhom, int phieu, int maKP, bool bThua, int thuoc, string mmyy)
		{
			return _busDuoc.GetThongTinThuHoiXuatSDLL(loai, buHaoPhi, inTheoCSTT, ngay, nhom, phieu, maKP, bThua, thuoc, mmyy);
		}

		public DataTable GetIDXuatSuDungLL(int nhom, int loai, int maKP, string mmyy, string ngay, int phieu, int thuoc)
		{
			return _busDuoc.GetIDXuatSuDungLL(nhom, loai, maKP, mmyy, ngay, phieu, thuoc);
		}
		public decimal GetNewIDXuatSuDungLL()
		{
			return _busDuoc.GetNewIDXuatSuDungLL();
		}
		public DataTable GetThongTinDTienThuoc(string mmyy, string strID)
		{
			return _busDuoc.GetThongTinDTienThuoc(mmyy, strID);
		}

		public DataTable GetSoLuongXuatSDLL(int loai, bool buHaoPhi, bool inTheoCSTT, string ngay, int nhom, int phieu, int maKP, bool bThua, int thuoc, string mmyy)
		{
			return _busDuoc.GetSoLuongXuatSDLL(loai, buHaoPhi, inTheoCSTT, ngay, nhom, phieu, maKP, bThua, thuoc, mmyy);
		}

		public DataTable GetSoLuongDTuTrucCT(int maKP, string mmyy)
		{
			return _busDuoc.GetSoLuongDTuTrucCT(maKP, mmyy);
		}

		public DataTable GetBietDuocDDuyet(string ngay, int nhom, int maKP, string str)
		{
			return _busDuoc.GetBietDuocDDuyet(ngay, nhom, maKP, str);
		}

		public DataTable GetRaVien(string maBN, decimal maQL)
		{
			return _busDuoc.GetRaVien(maBN, maQL);
		}

		public DataTable GetIDNgayDuyet(string mmyy, int maKP, int nhom, int loai, int phieu, string ngay, string maKho, string strMaKP)
		{
			return _busDuoc.GetIDNgayDuyet(mmyy, maKP, nhom, loai, phieu, ngay, maKho, strMaKP);
		}

		public DataTable GetPhieuChuaDuyet(int maKP, int nhom, string ngay, string strIDDuyet)
		{
			return _busDuoc.GetPhieuChuaDuyet(maKP, nhom, ngay, strIDDuyet);
		}

		public DataTable GetPhieuTreoDuyet(decimal idDuyet, string ngay)
		{
			return _busDuoc.GetPhieuTreoDuyet(idDuyet, ngay);
		}

		public DataTable GetIDXuatSuDungLL(int nhom, int loai, int maKP, string mmyy, string ngay, int phieu, int thuoc, string file, bool inTheoCSTT, bool b1Kho, string maKho, bool bBuHaoPhi, bool bThua, bool bXuatTuTrucBuTruKho, string file2)
		{
			return _busDuoc.GetIDXuatSuDungLL(nhom, loai, maKP, mmyy, ngay, phieu, thuoc, file, inTheoCSTT, b1Kho, maKho, bBuHaoPhi, bThua, bXuatTuTrucBuTruKho, file2);
		}

		public DataTable GetThuocChoDuyet(string tuNgay, string denNgay, int nhom, int loai, string sKho)
		{
			return _busDuoc.GetThuocChoDuyet(tuNgay, denNgay, nhom, loai, sKho);
		}

        public DataTable GetDoiTuong()
        {
            return _busDuoc.GetDoiTuong();
        }

        #endregion

            #region CheckData
        public bool GetDuyet(string mmyy, string maKP, int nhom, int loai, string phieu, string ngay, string maKho)
		{
			try
			{
				return _busDuoc.GetDuyet(mmyy, int.Parse(maKP), nhom, loai, int.Parse(phieu), ngay, maKho);
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool GetTTNgay(string ngay, string maKP)
		{
			return _busDuoc.GetTTNgay(ngay, maKP);
		}

		public bool CheckTreoDuyet(string mmyy, decimal idDuyet, int sttDuyet)
		{
			return _busDuoc.CheckTreoDuyet(mmyy, idDuyet, sttDuyet);
		}

		public DataTable GetTutructhDuyet(string mmyy, string kho, int makp)
		{
			return _busDuoc.GetTutructhDuyet(mmyy, kho, makp);
		}

		public DataTable GetTonkhothDuyet(string mmyy, string kho)
		{
			return _busDuoc.GetTonkhothDuyet(mmyy, kho);
		}

		public bool GetThongso_Bool(int id, int Nhom = int.MinValue)
		{
			return _busDuoc.GetThongso_Bool(id, Nhom);
		}

		public int getThongso_Int(int id, int Nhom = int.MinValue)
		{
			return _busDuoc.getThongso_Int(id, Nhom);
		}

		public string getThongso_String(int id, int Nhom = int.MinValue)
		{
			return _busDuoc.getThongso_String(id, Nhom);
		}

		public bool GetBoolGiaban()
		{
			string sql = " loai = 1 ";

			DataTable ret = _busDuoc.GetDoiTuong();
			if (ret.Rows.Count > 0)
			{
				ret = ret.Select(sql).CopyToDataTable();
			}
			return ret.Rows.Count > 0;

		}

		public bool GetDuyet(string mmyy, int maKP, int nhom, int loai, int phieu, string ngay, string strMaKP = "")
		{

			DataTable ret = _busDuoc.GetIDNgayDuyet(mmyy, maKP, nhom, loai, phieu, ngay, strMaKP);

			return ret.Rows.Count > 0;

		}
		public DataTable GetDDT(string tu, string den, bool bCont, bool bThua, bool bTreole, bool bDonthuoc_bacsy_duyet, bool bIntheocstt, int i_thuoc, int i_loai, int i_nhom, int soluong_le, int iMakp, string s_kho, string s_phieu, string s_tenkp, string file1, string file2)
		{

			DataTable ret = _busDuoc.GetDT(tu, den, bCont, bThua, bTreole, bDonthuoc_bacsy_duyet, bIntheocstt, i_thuoc, i_loai, i_nhom, soluong_le, iMakp, s_kho, s_phieu, s_tenkp, file1, file2);

			return ret;

		}

		public string format_soluong(int d_nhom)
		{
			string ret = "###,###,###,##0";
			int n = getThongso_Int(57, d_nhom);
			if (n > 0) ret += ".";
			for (int i = 0; i < n; i++) ret += "0";
			return ret;
		}

		public bool GetBoolKhoaso(string d_mmyy, int d_nhom, int d_makho, string d_ngay)
		{
			try
			{
				if (GetThongso_Bool(185, d_nhom))
				{


					string sql = cls_D_KhoaSo.col_MAKHO + " = " + d_makho;

					DataTable ret = _busDuoc.GetKhoaSo(d_mmyy, d_ngay);
					if (ret.Rows.Count > 0)
					{
						ret = ret.Select(sql).CopyToDataTable();
					}
					return ret.Rows.Count > 0;
				}
				else
					return false;
			}
			catch (Exception)
			{
				return false;
			}


		}
		public bool GetBoolKhoaso(string d_mmyy, int d_nhom, int d_makho)
		{
			try
			{
				bool bFound = false;


				if (d_makho != -1) bFound = _busDuoc.GetKhoaSo(d_mmyy, "01/01/2000").Rows.Count > 0;
				if (!bFound)
				{
					string sql = cls_D_KhoaSo.col_NHOM + " = " + d_nhom;

					if (!string.IsNullOrEmpty(d_mmyy))
					{
						sql += " and " + cls_D_KhoaSo.col_MMYY + "  ='" + d_mmyy + "' ";
					}
					DataTable ret = _busDuoc.GetKhoaSo();
					if (ret.Rows.Count > 0)
					{
						ret = ret.Select(sql).CopyToDataTable();
					}
					bFound = ret.Rows.Count > 0;

				}


				return bFound;
			}
			catch (Exception ex)
			{
				return false;
			}


		}

		public DataTable GetDangDuyet(int i_nhom)
		{
			try
			{
				bool bFound = false;
				string sql = cls_D_DangDuyet.col_NHOM + " = " + i_nhom;
				return _busDuoc.GetDangDuyet();
			}
			catch (Exception)
			{
				return null;
			}


		}
		public decimal get_id_xuatsd()
		{
			return _busDuoc.get_id_xuatsd();
		}

		#endregion
		public void upd_thucxuat(string d_ngay, int d_nhom, int d_loai, int d_phieu, int d_makp, int d_makhoa, string d_mmyy, int d_thuoc, int d_makho)
		{
			_busDuoc.upd_thucxuat(d_ngay, d_nhom, d_loai, d_phieu, d_makp, d_makhoa, d_mmyy, d_thuoc, d_makho);
		}
		#region DeleteData
		public bool DeleteNgayDuyet(int i_nhom, int i_loai, string Phieu, string MaKP, string ngay, string s_mmyy)
		{

			return _busDuoc.DeleteNgayDuyet(i_nhom, i_loai, Phieu, MaKP, ngay, s_mmyy);

		}
		public void Delete_dangduyet(int d_nhom, string d_tu, string d_den, int d_loai, int d_makp)
		{
			_busDuoc.Delete_dangduyet(d_nhom, d_tu, d_den, d_loai, d_makp);
		}
		public void netsend(string domain, string computer, string message)
		{
			_busDuoc.netsend(domain, computer, message);
		}
		#endregion

		#endregion
	}
}
