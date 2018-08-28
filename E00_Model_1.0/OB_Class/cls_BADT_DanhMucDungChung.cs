using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace E00_Model
{
    public partial class cls_BADT_DanhMucDungChung
    {

        public cls_BADT_DanhMucDungChung()
        {

        }

        public DataTable Get_Data(string ma, string ten,string danhSachMa,string danhSachTen)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(ma);
                dt.Columns.Add(ten);

                string[] sMa = danhSachMa.Split(',');
                string[] sTen = danhSachMa.Split(',');

                DataRow row = dt.NewRow();
                for (int i = 0; i < sMa.Length; i++)
                {
                    row = dt.NewRow();
                    row[ma] = sMa[i];
                    row[ten] = sTen[i];

                    dt.Rows.Add(row);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_DataControl()
        {
            try
            {
                string danhSachMa = "usc_SelectBox";
                string danhSachTen = "ComboBox";
                return Get_Data("Ma", "Ten",danhSachMa,danhSachTen);
            }
            catch
            {
                return null;
            }
        }
    }
}
