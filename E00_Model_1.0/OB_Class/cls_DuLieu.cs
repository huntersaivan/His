using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace E00_Model
{
    public partial class cls_DuLieu
    {

        public cls_DuLieu()
        {

        }

        public static DataTable Get_Data(string ma, string ten, string danhSachMa, string danhSachTen)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(ma);
                dt.Columns.Add(ten);

                string[] sMa = danhSachMa.Split(',');
                string[] sTen = danhSachTen.Split(',');

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

        public static DataTable Get_DataControl()
        {
            try
            {
                string danhSachMa = "usc_SelectBox,usc_SelectListBox,usc_Label,usc_DauSinhTon,usc_TextBox,usc_Numberic,usc_ListControl,usc_CheckBox,usc_DateToDate,usc_SelectBoxRadioButton,usc_RadioButton,usc_LabelSum,usc_TextBoxRadioButton,usc_ShowListBox,usc_Para,usc_Mach,usc_CanNang,usc_Image,usc_RichTextBox,usc_DoubleInput";
                string danhSachTen = "ComboBox,List ComboBox,Label,Dấu sinh tồn,TextBox,Numberic,List Control,Check Box,Date, Radio Button and SelectBox,usc_RadioButton,Label Sum,Radio Button and TextBox, Show Listbox,Para,Mạch,Cân nặng,Hình Ảnh,RichTextBox,Số thập phân";
                return Get_Data("Ma", "Ten", danhSachMa, danhSachTen);
            }
            catch
            {
                return null;
            }
        }
    }
}
