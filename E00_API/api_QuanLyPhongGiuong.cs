using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using E00_Model;
using E00_Common;
using System.Globalization;
using E00_BUS;

namespace E00_API
{
    public partial class api_QuanLyPhongGiuong
	{

        #region Biến toàn cục

        private Api_Common _api = new Api_Common();
		private bus_QuanLyPhongGiuong _bus = new bus_QuanLyPhongGiuong();
		#endregion

		#region Khởi tạo

		public api_QuanLyPhongGiuong()
        {
            _api.KetNoi();
        }

		#endregion

		#region Phương thức

		public string getmadoituong(string mabn)
		{
			DataRow dr = _bus.GetRowTiepDon(mabn);
			if (dr!=null)
			{
				return dr[cls_TiepDon.col_MaDoiTuong.ToUpper()]+"";
			}
			return "";

		}

        #endregion

    }
}
