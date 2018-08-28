using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using E00_Common;
using E00_Model;
using System.Data.OracleClient;
using System.Globalization;

namespace E00_API
{
	public partial class api_BADT
	{
		#region Biến toàn cục
		public static Acc_Oracle _acc = new Acc_Oracle();
		private static Api_Common _api = new Api_Common();

		#endregion

		#region Khởi tạo
		public api_BADT()
		{
			_api.KetNoi();
		}

        #endregion

        #region Phương thức

		private DataTable GetDataBenhAn(string MA)
		{
			string sql = "";
			if (MA != "")
			{
				sql = "Select Ma,MABN from " + _acc.Get_User() + "." + cls_BADT_BenhAnDienTu.tb_TenBang + " where MA='" + MA + "'";
			}
			else
			{
				sql = "Select Ma,MABN from " + _acc.Get_User() + "." + cls_BADT_BenhAnDienTu.tb_TenBang + "";

			}
			return _acc.Get_Data(sql);

		}
		/// <summary>
		/// Phạm Thế Mỹ 28/06/2018
		/// lấy thông tin một bệnh nhân từ bệnh án 
		/// </summary>
		/// <param name="MaBN">mã bệnh nhân</param>
		/// <param name="schema">schema (Lấy từ ngày vào viện dùng cho bảng tiếp đón)</param>
		/// <param name="Mavv">Mã vào viện</param>
		/// <returns></returns>
		public DataTable GetMotBenhNhan(string MaBN, string schema, string mabadtcha)
		{
			string sql = string.Format("SELECT D.MAVAOVIEN, '' as CHANDOAN,A.MA,D.MAQL,D.MAKP,C.TENKP,cast(''  AS VARCHAR2(30)) as MADT,A.NGAYVAOVIEN ,A.NGAYRAVIEN , B.MABN, B.HOTEN, B.NGAYSINH, B.PHAI ,'' as PHONG,'' as MABS,D.SOVAOVIEN as SOVAOVIEN , '' as MAICD ,A.MALOAI "
					 + " ,cast(''  AS VARCHAR2(50)) as GIOITINH,cast(''  AS VARCHAR2(50)) as TUOI,cast(''  AS VARCHAR2(2000)) as DIACHI    "
					 + " , cast(''  AS VARCHAR2(2000)) as TENBS, cast(''  AS VARCHAR2(2000)) as TENICD , cast(''  AS VARCHAR2(2000)) as TENICDKEM, cast(''  AS VARCHAR2(2000)) as NOIGIOITHIEU, cast(''  AS VARCHAR2(2000)) as MANOIGIOITHIEU  FROM"
					 + " " + _acc.Get_User() + ".BTDBN B"
					 + " LEFT JOIN"
					 + " " + _acc.Get_User() + ".BADT_BENHAN A"
					 + " ON A.MABN = B.MABN"
					  +" AND A.MA = '" + mabadtcha + "'  "
					 + " Left JOIN"
					 + " " + schema + ".TIEPDON D"
					 + " ON B.MABN = D.MABN"
					 + " Left JOIN"
					 + " " + _acc.Get_User() + ".BTDKP_BV C"
					 + " ON  cast(NVL(D.MAKP,'0') as NUMBER) = C.MAKP"
					 + " WHERE "
					 + " B.MABN in ('" + MaBN + "')  "
					 + " AND NVL(B.HOTEN,'9999999999') <> '9999999999'"
					);

			sql += " order by  B.MABN";
			return _acc.Get_Data(sql);
		}
		/// <summary>
		/// Phạm Thế Mỹ 28/06.2018
		/// Lấy Schema từ ngày vào viện
		/// </summary>
		/// <param name="ngayvv">Ngày vào viện phải theo định dang DD/MM/YYYY...... </param>
		/// <returns></returns>
		public string GetSchema(string ngayvv)
		{
			string ret = "";

			string[] term = ngayvv.Split('/');
			if (term.Length >= 3)
			{
				if (term[0].Length==2 && term[1].Length == 2 && term[2].Length >= 2)
				{

					ret += _acc.Get_User() + term[1];
					if (term[2].Length > 2)
					{
						ret += term[2].Substring(2,2);
					}
					else
					{
						ret += term[2];
					} 
				}

			}


			return ret;
			
		}
		/// <summary>
		///  Phạm Thế Mỹ 28/06.2018
		///  Lấy mã quản lý từ mã vào viện trong bảng benh an dt
		/// </summary>
		/// <param name="maVaoVien">Mã Vào Viện</param>
		/// <returns>Mã Quản Lý</returns>
		public string GetMaQuanLyNoiTru(string maVaoVien)
		{
			string ret = "";
			DataTable dt = _acc.Get_Data("select MAQL from " + _acc.Get_User() + ".BENHANDT where MAVAOVIEN='" + maVaoVien + "'");
			if (dt!=null && dt.Rows.Count > 0)
			{
				ret = dt.Rows[0][0].ToString();
			}
			return ret;
		}
		/// <summary>
		/// Phạm Thế Mỹ 28/06.2018
		///  lấy số thẻ bảo hiểm y tế
		/// </summary>
		/// <param name="_maBenhNhan">mã bệnh nhân</param>
		/// <returns>số bhyt</returns>
		public string GetSoTheBHYT(string _maBenhNhan)
		{
			string sothebhyt="";
			foreach (DataRow r in _acc.Get_Data("select * from " + _acc.Get_User() + ".bhyt where mabn=" + _maBenhNhan).Rows)
			{
				sothebhyt = r["sothe"].ToString();


			}
			return sothebhyt;
		}
		/// <summary>
		///  Phạm Thế Mỹ 28/06.2018
		///  lấy cân nặng
		/// </summary>
		/// <param name="maQL">mã quản lý</param>
		/// <returns>cân nặng</returns>
		public string GetCanNang(string maQL)
		{
			string cannang ="0";
			DataTable nk1 = _acc.Get_Data("select CANNANG from " + _acc.Get_User() + ".dausinhton where maql='" + maQL + "'");
			if (nk1 != null && nk1.Rows.Count > 0)
			{
				cannang = nk1.Rows[0][0].ToString();
			}
			return cannang;
		}
		/// <summary>
		/// PHẠM thế Mỹ 28/06/2018
		/// Xuất XML của BADT Nội Trú
		/// </summary>
		/// <param name="MaBN"></param>
		/// <param name="MaQL"></param>
		/// <returns></returns>
		public DataTable ExportPage1ToXML_NT(string MaBN,string MaQL)
		{
			#region Xuất Report
			#region Trang 1
			DataSet ds = new DataSet();
			DataTable table = new DataTable();
			table.Columns.Add("SoYTe");
			table.Columns.Add("TenBenhVien");
			table.Columns.Add("Khoa");
			table.Columns.Add("SoVaoVien");
			table.Columns.Add("SoHoSo");
			table.Columns.Add("SoLuuTru");
			table.Columns.Add("PhongGiuong");
			table.Columns.Add("HoTen");
			table.Columns.Add("MaBenhNhan");
			table.Columns.Add("GioiTinh");
			table.Columns.Add("NgaySinh1");
			table.Columns.Add("NgaySinh2");
			table.Columns.Add("ThangSinh1");
			table.Columns.Add("ThangSinh2");
			table.Columns.Add("HoTenCha");
			table.Columns.Add("HoTenMe");
			table.Columns.Add("TrinhDoVHCha");
			table.Columns.Add("TrinhDoVHMe");
			table.Columns.Add("NgheNghiepCha");
			table.Columns.Add("NgheNghiepMe");
			table.Columns.Add("SoDienThoaiCha");
			table.Columns.Add("SoDienThoaiMe");
			table.Columns.Add("CMNDCha");
			table.Columns.Add("CMNDMe");
			table.Columns.Add("NamSinh1");
			table.Columns.Add("NamSinh2");
			table.Columns.Add("NamSinh3");
			table.Columns.Add("NamSinh4");
			table.Columns.Add("Tuoi1");
			table.Columns.Add("Tuoi2");

			table.Columns.Add("DiaChi");

			table.Columns.Add("MaDanToc1");
			table.Columns.Add("MaDanToc2");
			table.Columns.Add("DanToc");

			table.Columns.Add("MaNgoaiKieu1");
			table.Columns.Add("MaNgoaiKieu2");
			table.Columns.Add("NgoaiKieu");

			table.Columns.Add("MaPhuongXa1");
			table.Columns.Add("MaPhuongXa2");
			table.Columns.Add("PhuongXa");

			table.Columns.Add("MaQuanHuyen1");
			table.Columns.Add("MaQuanHuyen2");
			table.Columns.Add("QuanHuyen");

			table.Columns.Add("MaTinhThanh1");
			table.Columns.Add("MaTinhThanh2");
			table.Columns.Add("MaTinhThanh3");
			table.Columns.Add("TinhThanh");

			table.Columns.Add("DienThoai");

			table.Columns.Add("NguoiGiamHo");

			table.Columns.Add("DoiTuong");
			table.Columns.Add("SoTheBHYT");
			table.Columns.Add("GiaTriTheBHYT");

			table.Columns.Add("QuanHeNguoiThan");
			table.Columns.Add("HotenNguoiThan");
			table.Columns.Add("DiaChiNguoiThan");
			table.Columns.Add("DienThoaiNguoiThan");

			table.Columns.Add("GioVaoVien");
			table.Columns.Add("PhutVaoVien");
			table.Columns.Add("NgayVaoVien");
			table.Columns.Add("ThangVaoVien");
			table.Columns.Add("NamVaoVien");
			table.Columns.Add("KhoaVaoTrucTiep");
			table.Columns.Add("BenhVienGioiThieu");
			table.Columns.Add("TuyenChuyen");

			table.Columns.Add("ChuyenKhoa1");
			table.Columns.Add("NgayChuyenKhoa1");
			table.Columns.Add("ChuyenKhoa2");
			table.Columns.Add("NgayChuyenKhoa2");
			table.Columns.Add("ChuyenKhoa3");
			table.Columns.Add("NgayChuyenKhoa3");

			table.Columns.Add("NhapKhoa1");
			table.Columns.Add("NgayNhapKhoa1");

			table.Columns.Add("ChuyenVien");

			table.Columns.Add("VaoKhoa");
			table.Columns.Add("NoiGioiThieu");
			table.Columns.Add("VaoVienLanThu");

			table.Columns.Add("NgayGioRaVien");
			table.Columns.Add("TTLucRV");

			table.Columns.Add("MaCDNoiChuyen1");
			table.Columns.Add("MaCDNoiChuyen2");
			table.Columns.Add("MaCDNoiChuyen3");
			table.Columns.Add("MaCDNoiChuyen4");
			table.Columns.Add("CDNoiChuyen");

			table.Columns.Add("MaChanDoanKKB1");
			table.Columns.Add("MaChanDoanKKB2");
			table.Columns.Add("MaChanDoanKKB3");
			table.Columns.Add("MaChanDoanKKB4");
			table.Columns.Add("ChanDoanKKB");

			table.Columns.Add("MaChanDoanBenhChinh1");
			table.Columns.Add("MaChanDoanBenhChinh2");
			table.Columns.Add("MaChanDoanBenhChinh3");
			table.Columns.Add("MaChanDoanBenhChinh4");
			table.Columns.Add("BenhChinh");

			table.Columns.Add("MaChanDoanKemTheo1");
			table.Columns.Add("MaChanDoanKemTheo2");
			table.Columns.Add("MaChanDoanKemTheo3");
			table.Columns.Add("MaChanDoanKemTheo4");
			table.Columns.Add("BenhKemTheo");

			table.Columns.Add("KetQuaRaVien");
			table.Columns.Add("TruongKhoa");
			table.Columns.Add("KhoaChuyen");
			table.Columns.Add("RaVien");
			table.Columns.Add("SoNgayDieuTri");
			table.Columns.Add("NgayGioTuVong");

			table.Columns.Add("ChetDo");
			table.Columns.Add("MaICDTV1");
			table.Columns.Add("MaICDTV2");
			table.Columns.Add("MaICDTV3");
			table.Columns.Add("MaICDTV4");
			table.Columns.Add("ChanDoanTV");

			table.Columns.Add("GiaiPhauBenh");
			table.Columns.Add("PhauThuat");
			table.Columns.Add("ThuThuat");
			table.Columns.Add("TaiBien");
			table.Columns.Add("BienChung");
			table.Columns.Add("KhamNghiemTuThi");

			table.Columns.Add("MaCDKhoaDieuTri1");
			table.Columns.Add("MaCDKhoaDieuTri2");
			table.Columns.Add("MaCDKhoaDieuTri3");
			table.Columns.Add("MaCDKhoaDieuTri4");
			table.Columns.Add("CDKhoaDieuTri");
			DataRow row = table.NewRow();
			_api = new Api_Common();
			string userError = "";
			string systemError = "";
			Dictionary<string, string> _lst2 = new Dictionary<string, string>();
			List<string> _lst = new List<string>();
			

			DataTable btdbn = new DataTable();
			_lst2.Clear();
			_lst2.Add(cls_BTDBN.col_MaBN.ToUpper(), MaBN);
			btdbn = _api.Search(ref userError, ref systemError, cls_BTDBN.tb_TenBang, dicLike: _lst2);

			DataRow TTBenhNhan = null;
			DataTable benhan = new DataTable();
			_lst2.Clear();
			_lst2.Add(cls_BenhAnDT.col_MaBN.ToUpper(), MaBN);
			benhan = _api.Search(ref userError, ref systemError, cls_BenhAnDT.tb_TenBang, dicLike: _lst2);
			if (benhan != null && benhan.Rows.Count > 0)
			{
				TTBenhNhan = benhan.Rows[0];
			}
			#region Bệnh viện giới thiệu
			try
			{

				if (TTBenhNhan != null) // Kiểm tra tồn tại
				{
					_lst2.Clear();
					_lst2.Add(cls_DenTu.col_Ma.ToUpper(), TTBenhNhan[cls_BenhAnDT.col_DenTu].ToString());
					DataTable dentu = _api.Search(ref userError, ref systemError, cls_DenTu.tb_TenBang, dicEqual: _lst2);

					if (dentu != null)
					{
						row["NoiGioiThieu"] = dentu.Rows[0][cls_DenTu.col_Ten].ToString();
						if (TTBenhNhan[cls_BenhAnDT.col_DenTu].ToString() == "1")
						{
							_lst2.Clear();
							_lst2.Add(cls_NoiGioiThieu.col_MaQL.ToUpper(), MaQL);
							DataTable noiGioiThieu = _api.Search(ref userError, ref systemError, cls_NoiGioiThieu.tb_TenBang, dicEqual: _lst2);
							if (noiGioiThieu != null && noiGioiThieu.Rows.Count > 0)
							{

								_lst2.Clear();
								_lst2.Add(cls_TrungTamYTe.col_MaBV.ToUpper(), noiGioiThieu.Rows[0][cls_NoiGioiThieu.col_MaBV].ToString());
								DataTable dtaDiaChiBHTY = _api.Search(ref userError, ref systemError, cls_TrungTamYTe.tb_TenBang, dicEqual: _lst2);
								if (dtaDiaChiBHTY != null && dtaDiaChiBHTY.Rows.Count > 0)
								{
									row["BenhVienGioiThieu"] = dtaDiaChiBHTY.Rows[0][cls_TrungTamYTe.col_TenBV].ToString();
								}
								else
								{
									row["BenhVienGioiThieu"] = "";
								}
								string ChiDinhNoiChuyen = noiGioiThieu.Rows[0][cls_NoiGioiThieu.col_MaICD].ToString();

								if (ChiDinhNoiChuyen.Length == 3)
								{
									row["MaCDNoiChuyen1"] = ChiDinhNoiChuyen.Substring(0, 1);
									row["MaCDNoiChuyen2"] = ChiDinhNoiChuyen.Substring(1, 1);
									row["MaCDNoiChuyen3"] = ChiDinhNoiChuyen.Substring(2, 1);
								}
								else
								{
									row["MaCDNoiChuyen1"] = ChiDinhNoiChuyen.Substring(0, 1);
									row["MaCDNoiChuyen2"] = ChiDinhNoiChuyen.Substring(1, 1);
									row["MaCDNoiChuyen3"] = ChiDinhNoiChuyen.Substring(2, 1);
									row["MaCDNoiChuyen4"] = ChiDinhNoiChuyen.Substring(4, 1);
								}

								_lst2.Clear();
								_lst2.Add(cls_ICD10.col_Ma.ToUpper().ToUpper(), ChiDinhNoiChuyen);
								DataTable dtaChiDinhNoiChuyen = _api.Search(ref userError, ref systemError, cls_ICD10.tb_TenBang, dicEqual: _lst2);
								if (dtaChiDinhNoiChuyen != null && dtaChiDinhNoiChuyen.Rows.Count > 0)
								{

									row["CDNoiChuyen"] = dtaChiDinhNoiChuyen.Rows[0][cls_ICD10.col_Ten].ToString();
								}
							}
							else
							{
								row["BenhVienGioiThieu"] = "";
								row["MaCDNoiChuyen1"] = "";
								row["MaCDNoiChuyen2"] = "";
								row["MaCDNoiChuyen3"] = "";
								row["MaCDNoiChuyen4"] = "";
								row["CDNoiChuyen"] = "";
							}
						}
						else
						{
							row["BenhVienGioiThieu"] = "";
							row["MaCDNoiChuyen1"] = "";
							row["MaCDNoiChuyen2"] = "";
							row["MaCDNoiChuyen3"] = "";
							row["MaCDNoiChuyen4"] = "";
							row["CDNoiChuyen"] = "";
						}
					}
				}
			}
			catch
			{
				row["BenhVienGioiThieu"] = "";
				row["MaCDNoiChuyen1"] = "";
				row["MaCDNoiChuyen2"] = "";
				row["MaCDNoiChuyen3"] = "";
				row["MaCDNoiChuyen4"] = "";
				row["CDNoiChuyen"] = "";
			}
			#endregion

			_lst2.Clear();
			_lst2.Add(cls_TiepDon.col_MaQL.ToUpper(), MaQL);
			DataTable _tableTiepDon = _api.Search(ref userError, ref systemError, cls_TiepDon.tb_TenBang, dicLike: _lst2);
			if (_tableTiepDon != null && _tableTiepDon.Rows.Count > 0 && TTBenhNhan == null)
			{
				TTBenhNhan = _tableTiepDon.Rows[0];
			}
			if (TTBenhNhan != null) // Kiểm tra tồn tại
			{

				row["SoYTe"] = "SỞ Y TẾ TP.HỒ CHÍ MINH";
				row["TenBenhVien"] = "BỆNH VIỆN NHI ĐỒNG THÀNH PHỐ";

				string _ngaythangnam = TTBenhNhan[cls_TiepDon.col_Ngay].ToString().Substring(0, 16);
				string _thang = _ngaythangnam.Substring(0, 2);
				string _ngay = _ngaythangnam.Substring(3, 2);
				string _nam = _ngaythangnam.Substring(6, 4);
				string _gio = _ngaythangnam.Substring(10);
				string ngay = _ngay + "/" + _thang + "/" + _nam + _gio;
				string schema = _acc.Get_UserMMYY();
				#region Khoa

				_lst2.Clear();
				_lst2.Add(cls_BTDBN.col_MaBN, MaBN);
				_lst2.Add(cls_BTDKP_BV.col_MaKP, TTBenhNhan[cls_TiepDon.col_MaKP].ToString());
				_lst2.Add("to_char(ngay,'dd/MM/yyyy hh24:mi')", ngay);
				DataTable _tableKhoa = _api.Search(ref userError, ref systemError, cls_BTDKP_BV.tb_TenBang, dicLike: _lst2);
				if (_tableKhoa != null && _tableKhoa.Rows.Count > 0)
				{
					try
					{
						row["Khoa"] = _tableKhoa.Rows[0][cls_BTDKP_BV.col_TenKP].ToString();

						_lst2.Clear();
						_lst2.Add(cls_BTDBN.col_MaBN, MaBN);
						DataTable nhapkhoa = _api.Search(ref userError, ref systemError, cls_NhapKhoa.tb_TenBang, schema: schema, dicLike: _lst2);
						if (nhapkhoa != null && nhapkhoa.Rows.Count > 0)
						{
							try
							{
								row["PhongGiuong"] = nhapkhoa.Rows[0][cls_NhapKhoa.col_Giuong].ToString();
							}
							catch
							{
								row["PhongGiuong"] = "";
							}
						}
						else
						{
							row["PhongGiuong"] = "";
						}

					}
					catch
					{
						row["Khoa"] = "";
					}
				}
				else
				{
					row["Khoa"] = "";
				}
				#endregion

				row["SoVaoVien"] = TTBenhNhan[cls_TiepDon.col_SoVaoVien].ToString();
				row["SoHoSo"] = MaBN;
				row["SoLuuTru"] = TTBenhNhan[cls_TiepDon.col_MaVaoVien].ToString();
				try
				{

					row["HoTen"] = btdbn.Rows[0][cls_BTDBN.col_HoTen];



				}
				catch
				{
					row["HoTen"] = "";
				}
				row["HoTenCha"] = "";
				row["HoTenMe"] = "";
				row["TrinhDoVHCha"] = "";
				row["TrinhDoVHMe"] = "";
				row["NgheNghiepCha"] = "";
				row["NgheNghiepMe"] = "";
				try
				{
					row["HoTenCha"] = btdbn.Rows[0][cls_BTDBN.col_HoTenCha];
					row["HoTenMe"] = btdbn.Rows[0][cls_BTDBN.col_HoTenMe];
					row["TrinhDoVHCha"] = btdbn.Rows[0][cls_BTDBN.col_VanHoaBo];
					row["TrinhDoVHMe"] = btdbn.Rows[0][cls_BTDBN.col_VanHoaMe];
					row["SoDienThoaiCha"] = btdbn.Rows[0][cls_BTDBN.col_DienThoaiCha];
					row["SoDienThoaiMe"] = btdbn.Rows[0][cls_BTDBN.col_DienThoaiMe];
					row["CMNDCha"] = btdbn.Rows[0][cls_BTDBN.col_CMNDCha];
					row["CMNDMe"] = btdbn.Rows[0][cls_BTDBN.col_CMNDMe];

					row["NgheNghiepCha"] = _acc.Get_Data("select TENNN from " + _acc.Get_User() + ".btdnn where MANN='" + btdbn.Rows[0][cls_BTDBN.col_MaNNBo].ToString() + "'").Rows[0]["TENNN"].ToString();
					row["NgheNghiepMe"] = _acc.Get_Data("select TENNN from " + _acc.Get_User() + ".btdnn where MANN='" + btdbn.Rows[0][cls_BTDBN.col_MaNNMe].ToString() + "'").Rows[0]["TENNN"].ToString();
				}
				catch
				{


				}
				try
				{
					row["MaBenhNhan"] = btdbn.Rows[0][cls_BTDBN.col_MaBN];

				}
				catch
				{
					row["MaBenhNhan"] = "";
				}
				#region Giới tính
				try
				{
					if (btdbn.Rows[0][cls_BTDBN.col_Phai].ToString() == "0")
					{
						row["GioiTinh"] = cls_Common.DinhDangHoaDauTu("Nam");
					}
					else
					{
						row["GioiTinh"] = cls_Common.DinhDangHoaDauTu("Nu");
					}
				}
				catch
				{
					row["GioiTinh"] = "";
				}
				#endregion

				#region Ngày sinh
				try
				{
					string NgaySinh = btdbn.Rows[0][cls_BTDBN.col_NgaySinh].ToString();
					row["NgaySinh1"] = NgaySinh.Substring(0, 1);
					row["NgaySinh2"] = NgaySinh.Substring(1, 1);
					row["ThangSinh1"] = NgaySinh.Substring(3, 1);
					row["ThangSinh2"] = NgaySinh.Substring(4, 1);

					row["NamSinh1"] = NgaySinh.Substring(6, 1);
					row["NamSinh2"] = NgaySinh.Substring(7, 1);
					row["NamSinh3"] = NgaySinh.Substring(8, 1);
					row["NamSinh4"] = NgaySinh.Substring(9, 1);
					string _tuoi = "";
					string tuoivao = Tuoivao("", NgaySinh);
					_tuoi = tuoivao.Substring(2);
					if (_tuoi.Length == 1)
					{
						row["Tuoi1"] = "0";
						row["Tuoi2"] = _tuoi;
					}
					else
					{
						row["Tuoi1"] = _tuoi.Substring(0, 1);
						row["Tuoi2"] = _tuoi.Substring(1, 1);
					}

				}
				catch
				{
					row["NgaySinh1"] = "";
					row["NgaySinh2"] = "";
					row["ThangSinh1"] = ""; ;
					row["ThangSinh2"] = "";

					row["NamSinh1"] = "";
					row["NamSinh2"] = "";
					row["NamSinh3"] = "";
					row["NamSinh4"] = "";

					row["Tuoi1"] = "";
					row["Tuoi2"] = "";
				}
				#endregion

				#region Địa chỉ
				try
				{
					row["DiaChi"] = btdbn.Rows[0][cls_BTDBN.col_Thon];
				}
				catch
				{
					row["DiaChi"] = "";
				}
				#endregion

				#region Dân tộc
				try
				{
					string maDanToc = btdbn.Rows[0][cls_BTDBN.col_MaDanToc].ToString();
					_lst2.Clear();
					_lst2.Add(cls_DanToc.col_MaDanToc, maDanToc);
					DataTable dantoc = _api.Search(ref userError, ref systemError, cls_DanToc.tb_TenBang, dicLike: _lst2);

					if (!string.IsNullOrEmpty(maDanToc))
					{
						row["MaDanToc1"] = maDanToc.Substring(0, 1);
						row["MaDanToc2"] = maDanToc.Substring(1, 1);
						if (dantoc != null && dantoc.Rows.Count > 0)
						{
							row["DanToc"] = cls_Common.DinhDangHoaDauTu(dantoc.Rows[0][cls_DanToc.col_DanToc].ToString());
						}
					}
					else
					{
						row["MaDanToc1"] = "";
						row["MaDanToc2"] = "";
						row["DanToc"] = "";
					}
				}
				catch
				{
					row["MaDanToc1"] = "";
					row["MaDanToc2"] = "";
					row["DanToc"] = "";
				}
				#endregion

				#region Ngoại kiều
				try
				{
					string ma = _acc.Get_Data("select ID_NUOC from " + _acc.Get_User() + ".nuocngoai where MABN='" + MaBN + "'").Rows[0]["ID_NUOC"].ToString();

					row["MaNgoaiKieu1"] = ma;
					row["MaNgoaiKieu2"] = _acc.Get_Data("select VALUEA from " + _acc.Get_User() + ".dmquocgia where MA='" + ma + "'").Rows[0]["VALUEA"].ToString();
					row["NgoaiKieu"] = _acc.Get_Data("select VIETNAMESE from " + _acc.Get_User() + ".dmquocgia where MA='" + ma + "'").Rows[0]["VIETNAMESE"].ToString();
					//_maNgoaiKieu1 = "";
					//_maNgoaiKieu2 = "";
					//_ngoaiKieu = "";
				}
				catch
				{
					row["MaNgoaiKieu1"] = "VN"; ;
					row["MaNgoaiKieu2"] = "VN"; ;
					row["NgoaiKieu"] = "Việt Nam";

				}
				#endregion

				#region Phường xã
				try
				{
					string maPhuongXa = btdbn.Rows[0][cls_BTDBN.col_MaPhuongXa].ToString();
					if (!string.IsNullOrEmpty(maPhuongXa))
					{
						row["MaPhuongXa1"] = maPhuongXa.Substring(maPhuongXa.Length - 2, 1);
						row["MaPhuongXa2"] = maPhuongXa.Substring(maPhuongXa.Length - 1, 1);

						_lst2.Clear();
						_lst2.Add(cls_BoTuDienPhuongXa.col_MaPhuongXa, maPhuongXa);
						DataTable dtaPhuongXa = _api.Search(ref userError, ref systemError, cls_BoTuDienPhuongXa.tb_TenBang, dicLike: _lst2);
						if (dtaPhuongXa != null && dtaPhuongXa.Rows.Count > 0)
						{
							row["PhuongXa"] = dtaPhuongXa.Rows[0][cls_BoTuDienPhuongXa.col_TenPXa].ToString();
						}
					}
					else
					{
						row["MaPhuongXa1"] = "";
						row["MaPhuongXa2"] = "";
						row["PhuongXa"] = "";
					}


				}
				catch
				{
					row["MaPhuongXa1"] = "";
					row["MaPhuongXa2"] = "";
					row["PhuongXa"] = "";
				}
				#endregion

				#region Quận huyện

				try
				{
					string maQuanHuyen = btdbn.Rows[0][cls_BTDBN.col_MaQU].ToString();
					if (!string.IsNullOrEmpty(maQuanHuyen))
					{
						row["MaQuanHuyen1"] = maQuanHuyen.Substring(maQuanHuyen.Length - 2, 1);
						row["MaQuanHuyen2"] = maQuanHuyen.Substring(maQuanHuyen.Length - 1, 1);

						_lst2.Clear();
						_lst2.Add(cls_BoTuDienQuanHuyen.col_MaQu, maQuanHuyen);
						DataTable dtaQuanHuyen = _api.Search(ref userError, ref systemError, cls_BoTuDienQuanHuyen.tb_TenBang, dicLike: _lst2);
						if (dtaQuanHuyen != null && dtaQuanHuyen.Rows.Count > 0)
						{
							row["QuanHuyen"] = dtaQuanHuyen.Rows[0][cls_BoTuDienQuanHuyen.col_TenQuan].ToString();
						}
					}
					else
					{
						row["MaQuanHuyen1"] = "";
						row["MaQuanHuyen2"] = "";
						row["QuanHuyen"] = "";
					}
				}
				catch
				{
					row["MaQuanHuyen1"] = "";
					row["MaQuanHuyen2"] = "";
					row["QuanHuyen"] = "";
				}
				#endregion

				#region Tỉnh thành
				try
				{
					string maTinhThanh = btdbn.Rows[0][cls_BTDBN.col_MaTT].ToString();
					if (!string.IsNullOrEmpty(maTinhThanh))
					{
						row["MaTinhThanh1"] = maTinhThanh.Substring(0, 1);
						row["MaTinhThanh2"] = maTinhThanh.Substring(1, 1);
						row["MaTinhThanh3"] = maTinhThanh.Substring(2, 1);

						_lst2.Clear();
						_lst2.Add(cls_BoTuDienTinhThanh.col_MaTT.ToUpper(), maTinhThanh);
						DataTable dtaTinhThanh = _api.Search(ref userError, ref systemError, cls_BoTuDienTinhThanh.tb_TenBang, dicEqual: _lst2);
						if (dtaTinhThanh != null && dtaTinhThanh.Rows.Count > 0)
						{
							row["TinhThanh"] = dtaTinhThanh.Rows[0][cls_BoTuDienTinhThanh.col_TenTT].ToString();
						}
					}
					else
					{
						row["MaTinhThanh1"] = "";
						row["MaTinhThanh2"] = "";
						row["MaTinhThanh3"] = "";
						row["TinhThanh"] = "";
					}
				}
				catch
				{
					row["MaTinhThanh1"] = "";
					row["MaTinhThanh2"] = "";
					row["MaTinhThanh3"] = "";
					row["TinhThanh"] = "";
				}

				#endregion

				#region Quan Hệ
				try
				{
					_lst2.Clear();
					_lst2.Add(cls_QuanHe.col_MaQL.ToUpper(), MaQL);
					DataTable dtaQuanHe = _api.Search(ref userError, ref systemError, cls_QuanHe.tb_TenBang, dicEqual: _lst2, schema: schema);
					row["DienThoai"] = "";

					row["NguoiGiamHo"] = "";
					row["QuanHeNguoiThan"] = "";
					row["HoTenNguoiThan"] = "";
					row["DiaChiNguoiThan"] = "";
					row["DienThoaiNguoiThan"] = "";
					if (dtaQuanHe != null && dtaQuanHe.Rows.Count > 0)
					{


						row["NguoiGiamHo"] = dtaQuanHe.Rows[0][cls_QuanHe.col_HoTen].ToString().ToUpper();
						row["QuanHeNguoiThan"] = "NGƯỜI GIÁM HỘ";


						row["DienThoai"] = dtaQuanHe.Rows[0][cls_QuanHe.col_DienThoai].ToString();
						row["HoTenNguoiThan"] = dtaQuanHe.Rows[0][cls_QuanHe.col_HoTen].ToString().ToUpper();
						row["DiaChiNguoiThan"] = dtaQuanHe.Rows[0][cls_QuanHe.col_DiaChi].ToString();
						row["DienThoaiNguoiThan"] = dtaQuanHe.Rows[0][cls_QuanHe.col_DienThoai].ToString();
					}
					else
					{

					}
				}
				catch
				{
					row["DienThoai"] = "";

					row["NguoiGiamHo"] = "";
					row["QuanHeNguoiThan"] = "";
					row["HoTenNguoiThan"] = "";
					row["DiaChiNguoiThan"] = "";
					row["DienThoaiNguoiThan"] = "";
				}
				#endregion

				#region Bảo hiểm y tế
				try
				{
					_lst2.Clear();

					////  _lst2.Add(cls_BTDBN.col_MaBN, MaBN);
					//  _lst2.Add(cls_DoiTuong.col_MaDoiTuong.ToUpper(), TTBenhNhan[cls_TiepDon.col_MaDoiTuong].ToString());
					//  //_lst2.Add("to_char(ngay,'dd/MM/yyyy hh24:mi')", ngay);


					//  DataTable dtaDoiTuong = _api.Search(ref userError, ref systemError, cls_DoiTuong.tb_TenBang, dicEqual: _lst2);
					//  if (dtaDoiTuong != null && dtaDoiTuong.Rows.Count > 0)
					//  {
					row["DoiTuong"] = TTBenhNhan[cls_TiepDon.col_MaDoiTuong].ToString();


					if (TTBenhNhan[cls_TiepDon.col_MaDoiTuong].ToString() == "1")
					{
						_lst2.Clear();
						_lst2.Add(cls_BTDBN.col_MaBN, MaBN);
						DataTable dtaBaoHiem = _api.Search(ref userError, ref systemError, cls_BaoHiemYTe.tb_TenBang, dicEqual: _lst2);
						if (dtaBaoHiem != null && dtaBaoHiem.Rows.Count > 0)
						{
							row["SoTheBHYT"] = dtaBaoHiem.Rows[0][cls_BaoHiemYTe.col_SoThe].ToString();
							row["GiaTriTheBHYT"] = dtaBaoHiem.Rows[0][cls_BaoHiemYTe.col_DenNgay].ToString();
						}
					}
					else
					{
						row["SoTheBHYT"] = "";
						row["GiaTriTheBHYT"] = "";
					}




				}
				catch
				{
					row["DoiTuong"] = "";
					row["SoTheBHYT"] = "";
					row["GiaTriTheBHYT"] = "";
				}
				#endregion

				#region Vào viện
				try
				{
					string NgayVV = DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(ngay));
					string NgayVaoVien = DateTime.ParseExact(NgayVV, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture).ToString();
					string GioVaoVien = NgayVV.Substring(11);
					row["GioVaoVien"] = GioVaoVien.Substring(0, 2);
					row["PhutVaoVien"] = GioVaoVien.Substring(3);
					row["NgayVaoVien"] = NgayVaoVien.Substring(0, 2);
					row["ThangVaoVien"] = NgayVaoVien.Substring(3, 2);
					row["NamVaoVien"] = NgayVaoVien.Substring(6, 4);
				}
				catch
				{
					row["GioVaoVien"] = "";
					row["PhutVaoVien"] = "";
					row["NgayVaoVien"] = "";
					row["ThangVaoVien"] = "";
					row["NamVaoVien"] = "";
					row["KhoaVaoTrucTiep"] = "";
					row["BenhVienGioiThieu"] = "";
					row["TuyenChuyen"] = "";
				}
				#endregion

				#region Khoa vào trực tiếp
				try
				{
					if (TTBenhNhan != null)
					{
						_lst2.Clear();
						_lst2.Add(cls_NhanTu.col_Ma.ToUpper(), TTBenhNhan[cls_BenhAnDT.col_NhanTu].ToString());
						DataTable dtaNhanTu = _api.Search(ref userError, ref systemError, cls_NhanTu.tb_TenBang, dicEqual: _lst2, schema: schema);
						if (dtaNhanTu != null && dtaNhanTu.Rows.Count > 0)
						{
							row["KhoaVaoTrucTiep"] = dtaNhanTu.Rows[0][cls_NhanTu.col_Ten].ToString();
						}
						else
						{
							row["KhoaVaoTrucTiep"] = "";
						}
					}
					else
					{
						row["KhoaVaoTrucTiep"] = "";
					}
				}
				catch
				{
					row["KhoaVaoTrucTiep"] = "";
				}
				#endregion


				row["TuyenChuyen"] = "";

				#region Chuyển khoa
				try
				{
					_lst2.Clear();
					_lst2.Add(cls_ChuyenKhoa.col_MaBN.ToUpper(), MaBN);
					DataTable ChuyenKhoa = _api.Search(ref userError, ref systemError, cls_ChuyenKhoa.tb_TenBang, schema: schema, dicEqual: _lst2);
					if (ChuyenKhoa != null && ChuyenKhoa.Rows.Count > 0)
					{
						string chuyenkhoa1 = ChuyenKhoa.Rows[0][cls_ChuyenKhoa.col_MaKP].ToString();
						_lst2.Clear();
						_lst2.Add(cls_BTDBN.col_MaBN, MaBN);
						_lst2.Add(cls_BTDKP_BV.col_MaKP, chuyenkhoa1);
						DataTable KhoaChuyen = _api.Search(ref userError, ref systemError, cls_BTDKP_BV.tb_TenBang, dicEqual: _lst2);
						if (KhoaChuyen != null && KhoaChuyen.Rows.Count > 0)
						{
							row["ChuyenKhoa1"] = KhoaChuyen.Rows[0][cls_BTDKP_BV.col_TenKP].ToString();
							string ngaychuyenkhoa1 = DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(ChuyenKhoa.Rows[0][cls_ChuyenKhoa.col_NgayChuyen].ToString()));
							string ngaychuyen1 = ngaychuyenkhoa1.Substring(0, 2);
							string thangchuyen1 = ngaychuyenkhoa1.Substring(3, 2);
							string namchuyen1 = ngaychuyenkhoa1.Substring(6, 4);
							string giochuyen1 = ngaychuyenkhoa1.Substring(11, 2);
							string phutchuyen1 = ngaychuyenkhoa1.Substring(14, 2);
							row["NgayChuyenKhoa1"] = giochuyen1 + " Giờ " + phutchuyen1 + " phút " + ngaychuyen1 + "/" + thangchuyen1 + "/" + namchuyen1;
						}

						if (ChuyenKhoa.Rows.Count > 1)
						{
							string chuyenkhoa2 = ChuyenKhoa.Rows[1][cls_ChuyenKhoa.col_MaKP].ToString();
							_lst2.Clear();
							_lst2.Add(cls_BTDBN.col_MaBN, MaBN);
							_lst2.Add(cls_BTDKP_BV.col_MaKP, chuyenkhoa2);
							DataTable KhoaChuyen1 = _api.Search(ref userError, ref systemError, cls_BTDKP_BV.tb_TenBang, dicEqual: _lst2);
							if (KhoaChuyen1 != null && KhoaChuyen1.Rows.Count > 0)
							{
								row["ChuyenKhoa2"] = KhoaChuyen1.Rows[0][cls_BTDKP_BV.col_TenKP].ToString();
								string ngaychuyenkhoa2 = DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(ChuyenKhoa.Rows[1][cls_ChuyenKhoa.col_NgayChuyen].ToString()));
								string ngaychuyen2 = ngaychuyenkhoa2.Substring(0, 2);
								string thangchuyen2 = ngaychuyenkhoa2.Substring(3, 2);
								string namchuyen2 = ngaychuyenkhoa2.Substring(6, 4);
								string giochuyen2 = ngaychuyenkhoa2.Substring(11, 2);
								string phutchuyen2 = ngaychuyenkhoa2.Substring(14, 2);
								row["NgayChuyenKhoa2"] = giochuyen2 + " Giờ " + phutchuyen2 + " phút " + ngaychuyen2 + "/" + thangchuyen2 + "/" + namchuyen2;
							}
						}
						if (ChuyenKhoa.Rows.Count > 2)
						{
							string chuyenkhoa3 = ChuyenKhoa.Rows[2][cls_ChuyenKhoa.col_MaKP].ToString();
							_lst2.Clear();
							_lst2.Add(cls_BTDBN.col_MaBN, MaBN);
							_lst2.Add(cls_BTDKP_BV.col_MaKP, chuyenkhoa3);
							DataTable KhoaChuyen2 = _api.Search(ref userError, ref systemError, cls_BTDKP_BV.tb_TenBang, dicEqual: _lst2);
							if (KhoaChuyen2 != null && KhoaChuyen2.Rows.Count > 0)
							{
								row["ChuyenKhoa3"] = KhoaChuyen2.Rows[0][cls_BTDKP_BV.col_TenKP].ToString();
								string ngaychuyenkhoa3 = DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(ChuyenKhoa.Rows[2][cls_ChuyenKhoa.col_NgayChuyen].ToString()));
								string ngaychuyen3 = ngaychuyenkhoa3.Substring(0, 2);
								string thangchuyen3 = ngaychuyenkhoa3.Substring(3, 2);
								string namchuyen3 = ngaychuyenkhoa3.Substring(6, 4);
								string giochuyen3 = ngaychuyenkhoa3.Substring(11, 2);
								string phutchuyen3 = ngaychuyenkhoa3.Substring(14, 2);
								row["NgayChuyenKhoa3"] = giochuyen3 + " Giờ " + phutchuyen3 + " phút " + ngaychuyen3 + "/" + thangchuyen3 + "/" + namchuyen3;
							}
						}
					}
					else
					{
						row["ChuyenKhoa1"] = "";
						row["NgayChuyenKhoa1"] = "";
						row["ChuyenKhoa2"] = "";
						row["NgayChuyenKhoa2"] = "";
						row["ChuyenKhoa3"] = "";
						row["NgayChuyenKhoa3"] = "";
					}
				}
				catch
				{
					row["ChuyenKhoa1"] = "";
					row["NgayChuyenKhoa1"] = "";
					row["ChuyenKhoa2"] = "";
					row["NgayChuyenKhoa2"] = "";
					row["ChuyenKhoa3"] = "";
					row["NgayChuyenKhoa3"] = "";
				}
				#endregion

				#region Nhập khoa

				try
				{
					DataTable nhapkhoa = new DataTable();
					_lst2.Clear();
					_lst2.Add(cls_NhapKhoa.col_MaBN.ToUpper(), MaBN);
					nhapkhoa = _api.Search(ref userError, ref systemError, cls_NhapKhoa.tb_TenBang, schema: schema, dicEqual: _lst2);
					if (nhapkhoa != null && nhapkhoa.Rows.Count > 0)
					{
						string nhapkhoa1 = nhapkhoa.Rows[0][cls_NhapKhoa.col_MaKP].ToString();
						_lst2.Clear();
						_lst2.Add(cls_BTDKP_BV.col_MaKP.ToUpper(), nhapkhoa1);
						DataTable nKhoa = _api.Search(ref userError, ref systemError, cls_BTDKP_BV.tb_TenBang, schema: schema, dicEqual: _lst2);
						if (nKhoa != null && nKhoa.Rows.Count > 0)
						{
							row["NhapKhoa1"] = nKhoa.Rows[0][cls_BTDKP_BV.col_TenKP].ToString();
							string ngaynhapkhoa1 = DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(nhapkhoa.Rows[0][cls_NhapKhoa.col_Ngay].ToString()));
							string ngaynhap1 = ngaynhapkhoa1.Substring(0, 2);
							string thangnhap1 = ngaynhapkhoa1.Substring(3, 2);
							string namnhap1 = ngaynhapkhoa1.Substring(6, 4);
							string gionhap1 = ngaynhapkhoa1.Substring(11, 2);
							string phutnhap1 = ngaynhapkhoa1.Substring(14, 2);
							row["NgayNhapKhoa1"] = gionhap1 + " Giờ " + phutnhap1 + " phút " + ngaynhap1 + "/" + thangnhap1 + "/" + namnhap1;
						}
						string maicd = nhapkhoa.Rows[0][cls_NhapKhoa.col_MaiCD].ToString();
						if (maicd.Length == 3)
						{
							row["MaCDKhoaDieuTri1"] = maicd.Substring(0, 1);
							row["MaCDKhoaDieuTri2"] = maicd.Substring(1, 1);
							row["MaCDKhoaDieuTri3"] = maicd.Substring(2, 1);
							row["CDKhoaDieuTri"] = nhapkhoa.Rows[0][cls_NhapKhoa.col_ChanDoan].ToString();
						}
						else
						{
							row["MaCDKhoaDieuTri1"] = maicd.Substring(0, 1);
							row["MaCDKhoaDieuTri2"] = maicd.Substring(1, 1);
							row["MaCDKhoaDieuTri3"] = maicd.Substring(2, 1);
							row["MaCDKhoaDieuTri4"] = maicd.Substring(4, 1);
							row["CDKhoaDieuTri"] = nhapkhoa.Rows[0][cls_NhapKhoa.col_ChanDoan].ToString();
						}
					}
				}
				catch
				{
					row["NhapKhoa1"] = "";
					row["NgayNhapKhoa1"] = "";
					row["MaCDKhoaDieuTri1"] = "";
					row["MaCDKhoaDieuTri2"] = "";
					row["MaCDKhoaDieuTri3"] = "";
					row["MaCDKhoaDieuTri4"] = "";
					row["CDKhoaDieuTri"] = "";
				}

				#endregion

				#region Chuyển viện
				try
				{
					DataTable cv = new DataTable();
					_lst2.Clear();
					_lst2.Add(cls_ChuyenVien.col_MaQL.ToUpper(), MaQL);
					cv = _api.Search(ref userError, ref systemError, cls_ChuyenVien.tb_TenBang, dicEqual: _lst2);
					if (cv != null && cv.Rows.Count > 0)
					{
						string loaibv = cv.Rows[0][cls_ChuyenVien.col_LoaiBV].ToString();
						row["ChuyenVien"] = _acc.Get_Data("select * from " + _acc.Get_User() + ".loaibv where ma='" + loaibv + "'").Rows[0]["ten"].ToString();
					}
				}
				catch
				{
					row["ChuyenVien"] = "";
				}
				#endregion
				try
				{
					row["VaoKhoa"] = _tableKhoa.Rows[0][cls_BTDKP_BV.col_TenKP].ToString();
				}
				catch
				{
					row["VaoKhoa"] = "";
				}

				#region Nơi giới thiệu
				try
				{
					_lst2.Clear();
					_lst2.Add(cls_DenTu.col_Ma.ToUpper(), TTBenhNhan[cls_BenhAnDT.col_DenTu].ToString());
					DataTable dtaNoiGioiThieu = _api.Search(ref userError, ref systemError, cls_DenTu.tb_TenBang, dicEqual: _lst2);
					if (dtaNoiGioiThieu != null && dtaNoiGioiThieu.Rows.Count > 0)
					{
						row["NoiGioiThieu"] = dtaNoiGioiThieu.Rows[0][cls_DenTu.col_Ten].ToString();
					}
					else
					{
						row["NoiGioiThieu"] = "";
					}
				}
				catch
				{
					row["NoiGioiThieu"] = "";
				}
				#endregion

				#region Vào viện lần
				try
				{
					row["VaoVienLanThu"] = TTBenhNhan[cls_BenhAnDT.col_LanThu].ToString();
				}
				catch
				{
				}
				#endregion

				#region Ra viện
				try
				{
					DataTable rv = new DataTable();
					_lst2.Clear();
					_lst2.Add(cls_XuatVien.col_MaBN.ToUpper(), MaBN);
					rv = _api.Search(ref userError, ref systemError, cls_XuatVien.tb_TenBang, schema: schema, dicEqual: _lst2);
					if (rv != null && rv.Rows.Count > 0)
					{
						string query = rv.Rows[0][cls_XuatVien.col_Ngay].ToString();
						string ngayrv = DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(query));
						try
						{
							row["NgayGioRaVien"] = ngayrv.Substring(11, 2) + " giờ " + ngayrv.Substring(14, 2) + " ngày " + ngayrv.Substring(0, 2) + "/" + ngayrv.Substring(3, 2) + "/" + ngayrv.Substring(6, 4);
						}
						catch
						{
							row["NgayGioRaVien"] = "";
						}
						try
						{
							row["TTLucRV"] = _acc.Get_Data("select * from " + _acc.Get_User() + ".ttxk where ma='" + rv.Rows[0]["ttlucrv"].ToString() + "'").Rows[0]["ten"].ToString();
						}
						catch
						{
							row["TTLucRV"] = "";
						}

						string maKetQuaRaVien = rv.Rows[0]["ketqua"].ToString();
						try
						{
							row["KetQuaRaVien"] = _acc.Get_Data("select * from " + _acc.Get_User() + ".ketqua where ma=" + maKetQuaRaVien + "").Rows[0]["ten"].ToString(); ;
						}
						catch
						{
							row["KetQuaRaVien"] = "";
						}

						string maicd = rv.Rows[0][cls_XuatVien.col_MaiCD].ToString();
						if (maicd.Length == 3)
						{
							row["MaChanDoanBenhChinh1"] = maicd.Substring(0, 1);
							row["MaChanDoanBenhChinh2"] = maicd.Substring(1, 1);
							row["MaChanDoanBenhChinh3"] = maicd.Substring(2, 1);
							row["BenhChinh"] = rv.Rows[0]["chandoan"].ToString();
						}
						else
						{
							row["MaChanDoanBenhChinh1"] = maicd.Substring(0, 1);
							row["MaChanDoanBenhChinh2"] = maicd.Substring(1, 1);
							row["MaChanDoanBenhChinh3"] = maicd.Substring(2, 1);
							row["MaChanDoanBenhChinh4"] = maicd.Substring(4, 1);
							row["BenhChinh"] = rv.Rows[0]["chandoan"].ToString();
						}
						#region Giải phẫu bệnh
						string giaiPhauBenh = rv.Rows[0][cls_XuatVien.col_GiaiPhau].ToString();
						if (giaiPhauBenh.Trim() == "0")
						{
							row["GiaiPhauBenh"] = "1.";
						}
						else
						{
							try
							{
								row["GiaiPhauBenh"] = "1. " + _acc.Get_Data("select * from " + _acc.Get_User() + ".gphaubenh where ma=" + giaiPhauBenh + "").Rows[0]["ten"].ToString();
							}
							catch
							{
								row["GiaiPhauBenh"] = "";
							}
						}
						#endregion

						#region Tai biến , biến chứng
						if (rv.Rows[0][cls_XuatVien.col_TaiBien].ToString() != "0")
						{
							row["TaiBien"] = "X";
						}
						else
						{
							row["TaiBien"] = "";
						}
						if (rv.Rows[0][cls_XuatVien.col_BienChung].ToString() != "0")
						{
							row["BienChung"] = "X";
						}
						else
						{
							row["BienChung"] = "";
						}
						#endregion
					}
				}
				catch
				{
					row["NgayGioRaVien"] = "";
					row["TTLucRV"] = "";
					row["MaChanDoanBenhChinh1"] = "";
					row["MaChanDoanBenhChinh2"] = "";
					row["MaChanDoanBenhChinh3"] = "";
					row["MaChanDoanBenhChinh4"] = "";
					row["BenhChinh"] = "";
					row["GiaiPhauBenh"] = "";
					row["KetQuaRaVien"] = "";
				}
				#endregion

				#region Chẩn đoán KKB-CC
				try
				{
					string chanDoanKB = TTBenhNhan[cls_BenhAnDT.col_MaICD].ToString();
					string tenChanDoanKH = TTBenhNhan[cls_BenhAnDT.col_ChanDoan].ToString();
					if (chanDoanKB.Length == 3)
					{
						row["MaChanDoanKKB1"] = chanDoanKB.Substring(0, 1);
						row["MaChanDoanKKB2"] = chanDoanKB.Substring(1, 1);
						row["MaChanDoanKKB3"] = chanDoanKB.Substring(2, 1);
						row["ChanDoanKKB"] = tenChanDoanKH;
					}
					else
					{
						row["MaChanDoanKKB1"] = chanDoanKB.Substring(0, 1);
						row["MaChanDoanKKB2"] = chanDoanKB.Substring(1, 1);
						row["MaChanDoanKKB3"] = chanDoanKB.Substring(2, 1);
						row["MaChanDoanKKB4"] = chanDoanKB.Substring(4, 1);
						row["ChanDoanKKB"] = tenChanDoanKH;
					}
				}
				catch
				{
					row["MaChanDoanKKB1"] = "";
					row["MaChanDoanKKB2"] = "";
					row["MaChanDoanKKB3"] = "";
					row["MaChanDoanKKB4"] = "";
					row["ChanDoanKKB"] = "";
				}
				#endregion

				#region Chẩn đoán kèm theo
				try
				{
					_lst2.Clear();
					_lst2.Add(cls_ChanDoanKemTheo.col_MaQL.ToUpper(), MaQL);
					DataTable cdkt_ql = _api.Search(ref userError, ref systemError, cls_ChanDoanKemTheo.tb_TenBang, schema: schema, dicEqual: _lst2);
					if (cdkt_ql != null && cdkt_ql.Rows.Count > 0)
					{
						string chanDoanKB = cdkt_ql.Rows[0][cls_ChanDoanKemTheo.col_MaICD].ToString();
						string tenChanDoanKH = cdkt_ql.Rows[0][cls_ChanDoanKemTheo.col_ChanDoan].ToString();
						if (chanDoanKB.Length == 3)
						{
							row["MaChanDoanKemTheo1"] = chanDoanKB.Substring(0, 1);
							row["MaChanDoanKemTheo2"] = chanDoanKB.Substring(1, 1);
							row["MaChanDoanKemTheo3"] = chanDoanKB.Substring(2, 1);
							row["BenhKemTheo"] = tenChanDoanKH;
						}
						else
						{
							row["MaChanDoanKemTheo1"] = chanDoanKB.Substring(0, 1);
							row["MaChanDoanKemTheo2"] = chanDoanKB.Substring(1, 1);
							row["MaChanDoanKemTheo3"] = chanDoanKB.Substring(2, 1);
							row["MaChanDoanKemTheo4"] = chanDoanKB.Substring(4, 1);
							row["BenhKemTheo"] = tenChanDoanKH;
						}
					}
					else
					{
						row["MaChanDoanKemTheo1"] = "";
						row["MaChanDoanKemTheo2"] = "";
						row["MaChanDoanKemTheo3"] = "";
						row["MaChanDoanKemTheo4"] = "";
						row["BenhKemTheo"] = "";
					}
				}
				catch
				{
					row["MaChanDoanKemTheo1"] = "";
					row["MaChanDoanKemTheo2"] = "";
					row["MaChanDoanKemTheo3"] = "";
					row["MaChanDoanKemTheo4"] = "";
					row["BenhKemTheo"] = "";
				}
				#endregion

				row["TruongKhoa"] = "";
				row["KhoaChuyen"] = "";
				row["RaVien"] = "";

				try
				{
					if (TTBenhNhan != null)
					{
						string ngayvv = TTBenhNhan[cls_BenhAnDT.col_Ngay].ToString();
						string ngayrv = TTBenhNhan[cls_BenhAnDT.col_NgayRV].ToString();
						if (!string.IsNullOrEmpty(ngayrv))
						{
							row["SoNgayDieuTri"] = Math.Abs(SoNgay(Convert.ToDateTime(ngayvv), Convert.ToDateTime(ngayrv), 0)).ToString() + " ngày .";
						}
						else
						{
							row["SoNgayDieuTri"] = "";
						}
					}
					else
					{
						row["SoNgayDieuTri"] = "";
					}
				}
				catch
				{
					row["SoNgayDieuTri"] = "";
				}
				#region Từ vong
				try
				{
					string maqltv = MaQL;
					_lst2.Clear();
					_lst2.Add(cls_TuVong.col_MaQL.ToUpper(), maqltv);
					DataTable tv = _api.Search(ref userError, ref systemError, cls_TuVong.tb_TenBang, schema: schema, dicEqual: _lst2);
					if (tv != null && tv.Rows.Count > 0)
					{
						string querytv = tv.Rows[0][cls_TuVong.col_NGAYUD].ToString();
						string ngayGioTV = DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(querytv));
						try
						{
							row["NgayGioTuVong"] = ngayGioTV.Substring(11, 2) + " giờ " + ngayGioTV.Substring(14, 2) + " ph        ngày " + ngayGioTV.Substring(0, 2) + "/" + ngayGioTV.Substring(3, 2) + "/" + ngayGioTV.Substring(6, 4);
						}
						catch
						{
							row["NgayGioTuVong"] = "";
						}

						string maNguyenNhan = tv.Rows[0][cls_TuVong.col_NguyenNhan].ToString();
						try
						{
							row["ChetDo"] = _acc.Get_Data("select * from " + _acc.Get_User() + ".chetdo where ma=" + maNguyenNhan + "").Rows[0]["ten"].ToString();
						}
						catch
						{
							row["ChetDo"] = "";
						}

						string maICDTV = tv.Rows[0][cls_TuVong.col_MaiCD].ToString();
						if (maICDTV.Length == 3)
						{
							row["MaICDTV1"] = maICDTV.Substring(0, 1);
							row["MaICDTV2"] = maICDTV.Substring(1, 1);
							row["MaICDTV3"] = maICDTV.Substring(2, 1);
							row["ChanDoanTV"] = tv.Rows[0][cls_TuVong.col_ChanDoan].ToString();
						}
						else
						{
							row["MaICDTV1"] = maICDTV.Substring(0, 1);
							row["MaICDTV2"] = maICDTV.Substring(1, 1);
							row["MaICDTV3"] = maICDTV.Substring(2, 1);
							row["MaICDTV4"] = maICDTV.Substring(4, 1);
							row["ChanDoanTV"] = tv.Rows[0][cls_TuVong.col_ChanDoan].ToString();
						}
						string khamNghiemTuThi = tv.Rows[0][cls_TuVong.col_KhamTuThi].ToString();
						if (khamNghiemTuThi != "0")
						{
							row["KhamNghiemTuThi"] = "X";
						}
						else
						{
							row["KhamNghiemTuThi"] = "";
						}
					}
				}
				catch
				{
					row["NgayGioTuVong"] = "";
					row["ChetDo"] = "";
					row["KhamNghiemTuThi"] = "";
					row["MaICDTV1"] = "";
					row["MaICDTV2"] = "";
					row["MaICDTV3"] = "";
					row["MaICDTV4"] = "";
					row["ChanDoanTV"] = "";
				}
				#endregion

				#region PTTT
				try
				{
					DataTable pttt = new DataTable();

					_lst2.Clear();
					_lst2.Add(cls_PTTT.col_MaPT.ToUpper(), MaBN);
					pttt = _api.Search(ref userError, ref systemError, cls_BTDBN.tb_TenBang, schema: schema, dicEqual: _lst2);
					if (pttt != null && pttt.Rows.Count > 0)
					{
						string pt = pttt.Rows[0][cls_PTTT.col_MaPT].ToString();
						if (pt.Contains("T"))
						{
							row["ThuThuat"] = "X";
						}
						else
						{
							if (pt.Contains("P"))
							{
								row["PhauThuat"] = "X";
							}
							else
							{
								row["PhauThuat"] = "";
							}
						}
					}
				}
				catch
				{
					row["ThuThuat"] = "";
					row["PhauThuat"] = "";
				}

				#endregion

				table.Rows.Add(row);
				ds.Tables.Add(table);
				if (ds.Tables[0].Rows.Count == 0)
				{
					
					return null;
				}
				if (!System.IO.Directory.Exists("..//..//DataXml//"))
				{
					System.IO.Directory.CreateDirectory("..//..//DataXml//");
				}

				return table;
			}
			//table.Merge(_tableTiepDon);

			return table;

			#endregion
			#endregion
		}
		/// <summary>
		/// Phạm Thế Mỹ
		/// Format ngày tháng 
		/// </summary>
		/// <param name="format"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		public string DateToString(string format, DateTime date)
		{
			string result;
			if (date.Equals(null))
			{
				result = "";
			}
			else
			{
				result = date.ToString(format, DateTimeFormatInfo.CurrentInfo);
			}
			return result;
		}
		/// <summary>
		/// Phạm Thế Mỹ 
		/// Lấy tuổi vào theo băn và ngày
		/// </summary>
		/// <param name="ngayvao">Ngày Vao</param>
		/// <param name="ngaysinh">Năm vào</param>
		/// <returns></returns>
		public string Tuoivao(string ngayvao, string ngaysinh)
		{
			if (ngaysinh == null || ngaysinh == "")
			{
				return "0";
			}
			int namht = DateTime.Now.Year;
			int thanght = DateTime.Now.Month;
			int ngayht = DateTime.Now.Day;
			int gioht = DateTime.Now.Hour;
			int nam = int.Parse(ngaysinh.Substring(6, 4));
			int thang = int.Parse(ngaysinh.Substring(3, 2));
			int ngay = int.Parse(ngaysinh.Substring(0, 2));
			int gio = (ngaysinh.Length > 10) ? int.Parse(ngaysinh.Substring(11, 2)) : 0;
			if (ngayvao != "")
			{
				namht = int.Parse(ngayvao.Substring(6, 4));
				thanght = int.Parse(ngayvao.Substring(3, 2));
				ngayht = int.Parse(ngayvao.Substring(0, 2));
				gioht = int.Parse(ngayvao.Substring(11, 2));
			}
			string tuoi;
			if (nam == namht)
			{
				if (thang == thanght)
				{
					if (ngay == ngayht)
					{
						tuoi = "3/" + (gioht - gio);
					}
					else
					{
						tuoi = "2/" + (ngayht - ngay);
					}
				}
				else
				{
					tuoi = "1/" + (thanght - thang);
				}
			}
			else
			{
				tuoi = "0/" + (namht - nam);
			}
			string iTuoi = "";
			if (int.Parse(tuoi.Substring(0, 1)) < 0)
			{
				iTuoi = "0";
			}
			else
			{
				iTuoi = int.Parse(tuoi.Substring(0, 1)).ToString(); ;
			}

			
			return tuoi;
		}
		public long SoNgay(DateTime d1, DateTime d2, int congthem)
		{
			long result;
			try
			{
				result = Convert.ToInt64(d1.ToOADate() - d2.ToOADate() + (double)congthem);
			}
			catch
			{
				result = 0L;
			}
			return result;
		}

		public DataTable InTTHC(string _maBNNgoaiTru, string MaBN, string MABS, string tenBS, string mabenhchinh, string tenbenhchinh, string mabenhkemtheo, string tenbenhkemtheo)
		{
			DataSet ds = new DataSet();
			DataTable table = new DataTable();
			cls_reportBenhAnNgoaiTru rpt = new cls_reportBenhAnNgoaiTru();
			foreach (var prop in rpt.GetType().GetProperties())
			{
				table.Columns.Add(prop.Name);
			}
			// bổ sung 1 số column mới
			if (table.Columns["MA_ICD_NOIGIOITHIEU"] == null) { table.Columns.Add("MA_ICD_NOIGIOITHIEU"); }
			if (table.Columns["NGOAIKIEU"] == null) { table.Columns.Add("NGOAIKIEU"); }
			if (table.Columns["MANGOAIKIEU"] == null) { table.Columns.Add("MANGOAIKIEU"); }
			if (table.Columns["MAXAPHUONG"] == null) { table.Columns.Add("MAXAPHUONG"); }
			if (table.Columns["MATINHTHANHPHO"] == null) { table.Columns.Add("MATINHTHANHPHO"); }



			if (table.Columns["HOTEN_QUANHE"] == null) { table.Columns.Add("HOTEN_QUANHE"); }
			if (table.Columns["DIENTHOAI_QUANHE"] == null) { table.Columns.Add("DIENTHOAI_QUANHE"); }
			if (table.Columns["DIACHI_QUANHE"] == null) { table.Columns.Add("DIACHI_QUANHE"); }
			if (table.Columns["ChanDoanNoiGioiThieu"] == null) { table.Columns.Add("ChanDoanNoiGioiThieu"); }
			if (table.Columns[cls_BTDBN.col_ChoLam] == null) { table.Columns.Add(cls_BTDBN.col_ChoLam); }
			if (table.Columns[cls_BTDBN.col_Thon] == null) { table.Columns.Add(cls_BTDBN.col_Thon); }
			if (table.Columns["HOTENCHA"] == null) { table.Columns.Add("HOTENCHA"); }
			if (table.Columns["NSCHA"] == null) { table.Columns.Add("NSCHA"); }
			if (table.Columns["HOTENME"] == null) { table.Columns.Add("HOTENME"); }
			if (table.Columns["NSME"] == null) { table.Columns.Add("NSME"); }
			if (table.Columns["TINHCACH"] == null) { table.Columns.Add("TINHCACH"); }
			if (table.Columns["GHICHU"] == null) { table.Columns.Add("GHICHU"); }
			if (table.Columns["VANHOA_BO"] == null) { table.Columns.Add("VANHOA_BO"); }
			if (table.Columns["VANHOA_ME"] == null) { table.Columns.Add("VANHOA_ME"); }
			if (table.Columns["MANN_BO"] == null) { table.Columns.Add("MANN_BO"); }
			if (table.Columns["MANN_ME"] == null) { table.Columns.Add("MANN_ME"); }
			if (table.Columns["DIENTHOAICHA"] == null) { table.Columns.Add("DIENTHOAICHA"); }
			if (table.Columns["DIENTHOAIME"] == null) { table.Columns.Add("DIENTHOAIME"); }
			if (table.Columns["CMNDCHA"] == null) { table.Columns.Add("CMNDCHA"); }
			if (table.Columns["CMNDME"] == null) { table.Columns.Add("CMNDME"); }
			if (table.Columns["BacSiDieuTri"] == null) { table.Columns.Add("BacSiDieuTri"); }
			if (table.Columns["BacSiDieuTri_Ma"] == null) { table.Columns.Add("BacSiDieuTri_Ma"); }
			if (table.Columns["ICD_BENHCHINH"] == null) { table.Columns.Add("ICD_BENHCHINH"); }
			if (table.Columns["ICD_BENHCHINH_MA"] == null) { table.Columns.Add("ICD_BENHCHINH_MA"); }
			if (table.Columns["ICD_BENHKEMTHEO"] == null) { table.Columns.Add("ICD_BENHKEMTHEO"); }
			if (table.Columns["ICD_ICD_BENHKEMTHEO_MA"] == null) { table.Columns.Add("ICD_ICD_BENHKEMTHEO_MA"); }

			if (table.Columns["TUNGAY_BHYT"] == null) { table.Columns.Add("TUNGAY_BHYT"); }
			if (table.Columns["Ngayvv"] == null) { table.Columns.Add("Ngayvv"); }

			DataRow row = table.NewRow();
			string Schema = _acc.Get_MMYY();
			string user = _acc.Get_User();
			DataTable dt1 = new DataTable();
			var sql = "";

			sql = string.Format("SELECT "
						+ "nt.{10}, to_char(nt.{11} ,'dd/mm/yyyy hh24:mi') as Ngay,bn.MaDanToc,nt.MaVaoVien,pxa.MaPhuongXa,quan.MaQu,tt.MaTT,nt.MaKP"
						+ ",bn.{12}, bn.{13}, bn.{14},kp.tenkp"
						+ ",dt.{15}"
						+ ",bn.{16}, bn.{17},pxa.{18}, quan.{19}, tt.{20}"
						+ ",dt.{21}"
						+ ",bhyt.{22}, bhyt.{23}"
						+ ",qh.{24} as HOTEN_QUANHE, qh.{25} as DIACHI_QUANHE, qh.{26} as DIENTHOAI_QUANHE "
						+ ",ngt.{27} as MA_ICD_NOIGIOITHIEU,ngt.{28} as CHANDOAN_NOIGIOITHIEU "
						+ ",bn.{44} ,bn.{45} ,bn.HOTENCHA,bn.NSCHA,bn.HOTENME,bn.NSME,bn.TINHCACH,bn.GHICHU,bn.VANHOA_BO,bn.VANHOA_ME "
						+ ",bn.MANN_BO,bn.MANN_ME,bn.DIENTHOAICHA,bn.DIENTHOAIME,bn.CMNDCHA,bn.CMNDME,bhyt.{46} as TUNGAY_BHYT  "
						+ ",to_char(nt.ngay ,'dd/mm/yyyy hh24:mi') as Ngayvv  "
					+ "FROM "
						+ user + ".{1} bn "
						+ "LEFT JOIN " + user + ".{0} nt ON nt.{10} = bn.{29} "
						+ "LEFT JOIN " + user + ".btdkp_bv kp ON nt.makp = kp.makp "
						+ "LEFT JOIN " + user + ".{2} dt ON bn.{30} = dt.{31} "
						+ "LEFT JOIN " + user + ".{3} pxa ON  bn.{32} = pxa.{33} "
						+ "LEFT JOIN " + user + ".{4} quan ON bn.{34} = quan.{35} "
						+ "LEFT JOIN " + user + ".{5} tt ON bn.{36} = tt.{37} "

						+ "LEFT JOIN " + user + ".{7} ngt ON nt.{40} = ngt.{41} "
						+ "LEFT JOIN " + user + Schema + ".{8} bhyt ON nt.{40} = bhyt.{42} "
						+ "LEFT JOIN " + user + Schema + ".{9} qh ON nt.mavaovien = qh.{43} "
						+ "LEFT JOIN " + user + ".{6} dt ON nt.{38} = dt.{39} "
						+ "LEFT JOIN " + user + Schema + ".{47} td ON nt.mavaovien = td.maql "
					+ "WHERE "
						+ "nt.{10} = '" + _maBNNgoaiTru + "'"
						+ " Order by nt.MaQL DESC"
						, "BenhAnNGTR"          //0
						, cls_BenhNhan.tb_TenBang        // 1
						, cls_DanToc.tb_TenBang          // 2
						, cls_PhuongXa.tb_TenBang         // 3
						, cls_Quan.tb_TenBang            // 4
						, cls_TinhThanh.tb_TenBang       // 5
						, cls_DoiTuong.tb_TenBang        // 6
						, cls_NoiGioiThieu.tb_TenBang    // 7
						, cls_BaoHiemYTe.tb_TenBang      // 8
						, cls_QuanHe.tb_TenBang          // 9
						, cls_TiepDon.col_MaBN           // 10
						, cls_TiepDon.col_Ngay           // 11
						, cls_BenhNhan.col_HoTen         // 12
						, cls_BenhNhan.col_NgaySinh      // 13
						, cls_BenhNhan.col_Phai           // 14
						, cls_DanToc.col_DanToc          // 15
						, cls_BenhNhan.col_SoNha         // 16
						, cls_BenhNhan.col_Thon          // 17
						, cls_PhuongXa.col_TenPXa        // 18
						, cls_Quan.col_TenQuan           // 19
						, cls_TinhThanh.col_TenTT        // 20
						, cls_DoiTuong.col_DoiTuong      // 21
						, cls_BaoHiemYTe.col_SoThe       // 22
						, cls_BaoHiemYTe.col_DenNgay     // 23
						, cls_QuanHe.col_HoTen           // 24
						, cls_QuanHe.col_DiaChi          // 25
						, cls_QuanHe.col_DienThoai       // 26
						, cls_NoiGioiThieu.col_MaICD     // 27
						, cls_NoiGioiThieu.col_ChanDoan  // 28

						, cls_BenhNhan.col_MaBN          // 29
						, cls_BenhNhan.col_MaDanToc      // 30
						, cls_DanToc.col_MaDanToc        // 31
						, cls_BenhNhan.col_MaPhuongXa    // 32
						, cls_PhuongXa.col_MaPhuongXa    // 33
						, cls_BenhNhan.col_MaQu          // 34
						, cls_Quan.col_MaQu              // 35
						, cls_BenhNhan.col_MaTT          // 36
						, cls_TinhThanh.col_MaTT         // 37
						, cls_DanToc.col_MaDoiTuong      // 38
						, cls_DoiTuong.col_MaDoiTuong    // 39
						, cls_TiepDon.col_MaQL           // 40
						, cls_NoiGioiThieu.col_MaQL      // 41
						, cls_BaoHiemYTe.col_MaQL        // 42
						, cls_QuanHe.col_MaQL            // 43
						, cls_BTDBN.col_ChoLam           // 44
						, cls_BTDBN.col_Thon             // 45
						, cls_BaoHiemYTe.col_TuNgay           // 46
						, cls_TiepDon.tb_TenBang           // 47
						);

			dt1 = _acc.Get_Data(sql);

			if (dt1.Rows.Count > 0)
			{

				DataRow Row2 = dt1.Rows[0];


				row["SoYTe"] = "SỞ Y TẾ TP.HỒ CHÍ MINH";
				row["BenhVien"] = "BỆNH VIỆN NHI ĐỒNG THÀNH PHỐ";
				row["SoVaoVien"] = Row2["MaVaoVien"].ToString();
				row["SoHoSo"] = _maBNNgoaiTru;
				row["MaBenhNhan"] = _maBNNgoaiTru;
				row["TenKhoaPhong"] = Row2["TenKp"].ToString();
				row["HoVaTenInHoa"] = Row2[cls_BenhNhan.col_HoTen].ToString();
				row["SinhNgay"] = Row2[cls_BenhNhan.col_NgaySinh].ToString();
				row["GioiTinh"] = Row2[cls_BenhNhan.col_Phai].ToString() == "1" ? "Nữ" : "Nam";
				row["DanToc"] = Row2[cls_DanToc.col_DanToc].ToString();
				row["MaDanToc"] = Row2[cls_BenhNhan.col_MaDanToc].ToString();
				//row["DenKhamLuc"] = String.Format("{0:dd/MM/yy HH:mm:ss}", NgayVaoVien);
				row["MaXaPhuong"] = Row2[cls_PhuongXa.col_MaPhuongXa].ToString();
				row["XaPhuong"] = Row2[cls_PhuongXa.col_TenPXa].ToString();
				row["MaHuyen"] = Row2[cls_Quan.col_MaQu].ToString();
				row["Huyen"] = Row2[cls_Quan.col_TenQuan].ToString();
				row["MaTinh"] = Row2[cls_TinhThanh.col_MaTT].ToString();
				row["TinhThanhPho"] = Row2[cls_TinhThanh.col_TenTT].ToString();
				row["DoiTuong"] = Row2[cls_DoiTuong.col_DoiTuong].ToString();
				row["NgayBaoHiemYTeHet"] = Row2[cls_BaoHiemYTe.col_DenNgay].ToString();
				row["SoTheBaoHiemYTe"] = Row2[cls_BaoHiemYTe.col_SoThe].ToString();
				row["DienThoaiNguoiNha"] = Row2["DIENTHOAI_QUANHE"].ToString();

				try
				{
					string ma = _acc.Get_Data("select ID_NUOC from " + _acc.Get_User() + ".nuocngoai where MABN='" + MaBN + "'").Rows[0]["ID_NUOC"].ToString();

					row["MANGOAIKIEU"] = ma;
					row["NGOAIKIEU"] = _acc.Get_Data("select VIETNAMESE from " + _acc.Get_User() + ".dmquocgia where MA='" + ma + "'").Rows[0]["VIETNAMESE"].ToString();
					//_maNgoaiKieu1 = "";
					//_maNgoaiKieu2 = "";
					//_ngoaiKieu = "";
				}
				catch
				{
					row["MANGOAIKIEU"] = "VN";
					row["NGOAIKIEU"] = "Việt Nam";

				}


				row["MA_ICD_NOIGIOITHIEU"] = Row2["MA_ICD_NOIGIOITHIEU"].ToString();
				row["HOTEN_QUANHE"] = Row2["HOTEN_QUANHE"].ToString();
				row["DIENTHOAI_QUANHE"] = Row2["DIENTHOAI_QUANHE"].ToString();
				row["DIACHI_QUANHE"] = Row2["DIACHI_QUANHE"].ToString();

				row["ChanDoanNoiGioiThieu"] = Row2["CHANDOAN_NOIGIOITHIEU"].ToString();
				row[cls_BTDBN.col_ChoLam] = Row2[cls_BTDBN.col_ChoLam].ToString();
				row[cls_BTDBN.col_Thon] = Row2[cls_BTDBN.col_Thon].ToString();
				row["HOTENCHA"] = Row2["HOTENCHA"].ToString();
				row["NSCHA"] = Row2["NSCHA"].ToString();
				row["HOTENME"] = Row2["HOTENME"].ToString();
				row["NSME"] = Row2["NSME"].ToString();
				row["TINHCACH"] = Row2["TINHCACH"].ToString();
				row["GHICHU"] = Row2["GHICHU"].ToString();
				row["VANHOA_BO"] = Row2["VANHOA_BO"].ToString();
				row["VANHOA_ME"] = Row2["VANHOA_ME"].ToString();
				row["MANN_BO"] = Row2["MANN_BO"].ToString();
				row["MANN_ME"] = Row2["MANN_ME"].ToString();
				row["DIENTHOAICHA"] = Row2["DIENTHOAICHA"].ToString();
				row["DIENTHOAIME"] = Row2["DIENTHOAIME"].ToString();
				row["CMNDCHA"] = Row2["CMNDCHA"].ToString();
				row["CMNDME"] = Row2["CMNDME"].ToString();

				row["TUNGAY_BHYT"] = Row2["TUNGAY_BHYT"].ToString();
				row["Ngayvv"] = Row2["Ngayvv"].ToString();

				row["BacSiDieuTri"] = tenBS;
				row["BacSiDieuTri_Ma"] = MABS;
				row["ICD_BENHCHINH"] = tenbenhchinh;
				row["ICD_BENHCHINH_MA"] = mabenhchinh;
				row["ICD_BENHKEMTHEO"] = mabenhkemtheo;
				row["ICD_ICD_BENHKEMTHEO_MA"] = tenbenhkemtheo;
				table.Rows.Add(row);
			}

			ds.Tables.Add(table);
			if (ds.Tables[0].Rows.Count == 0)
			{

				return null;
				//return;
			}
			return table;
		}
		#endregion
	}
}
