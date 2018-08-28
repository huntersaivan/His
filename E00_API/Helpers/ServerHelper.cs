using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using E00_API.Base;
using E00_Common;
using E00_System;

namespace E00_API.Helpers
{
    public class ServerHelper
    {
        public const string FormatDate = @"dd/MM/yyyy";
        public const string FormatSDateTime = @"yyyy-MM-dd HH24:mm:ss";
        public const string FormatSHDateTime = @"yyyy-MM-dd HH:mm:ss";
        public const string FormatDateTime = @"MM/dd/yyyy hh:mm";
        public const string FormatDataDateTime = @"yyyy-MM-dd HH24:mi:ss";
        public const string FormatCodeDateTime = @"dd/MM/yyyy hh:mm";
        public ServerHelper() { }
        public static DateTime ConvertSToDtime(string value)
        {
            if (value == null) return DateTime.MinValue;
            try
            {
                return DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
        public static int ConvertSToIn(object value)
        {
            try
            {
                return int.Parse("" + value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Int64 ConvertSToLong(object value)
        {
            try
            {
                return Int64.Parse("" + value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static string AutoGenerateNumberSoNhapVien(Acc_Oracle _acc)
        {
            try
            {
                string sql = "select TO_CHAR(SYSDATE, MaSO.NAM) NamValue,MaSO.*  from " + _acc.Get_User() + ".MASO_DANHMUC MaSO where Ma ='SVV' and (MaSO.HIDE = 0)";
                DataTable table = _acc.Get_Data(sql);
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        int so = int.Parse("" + table.Rows[0]["DANGGHI"]) + int.Parse("" + table.Rows[0]["NHAY"]);
                        string chuoi = so.ToString(("" + table.Rows[0]["SO"]).Replace('x', '0'));
                        string result = ("" + table.Rows[0]["FORMAT"]).Replace("" + table.Rows[0]["NAM"], "" + table.Rows[0]["NamValue"]).Replace("" + table.Rows[0]["SO"], chuoi);
                        int row = _acc.Execute_Data_Return("update " + _acc.Get_User() + ".MASO_DANHMUC set DANGGHI = " + so + " where Ma ='SVV'");
                        return result;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                TA_MessageBox.MessageBox.Show("Lỗi :" + ex.Message);
                return "";
            }
        }
        public static string AutoGenerateMaBN()
        {
            clsBUS _phuongThuc = new clsBUS();
            LibDal.AccessData libDal_AccessData = new LibDal.AccessData();
            string yy = libDal_AccessData.ngayhienhanh_server.Substring(8, 2);
            int stt = _phuongThuc.CapMaBN(int.Parse(libDal_AccessData.ngayhienhanh_server.Substring(8, 2)), 1, int.Parse(cls_System.sys_UserID != "" ? cls_System.sys_UserID : "0"), true);
            return yy + stt.ToString().PadLeft(6, '0');
        }
    }
}
