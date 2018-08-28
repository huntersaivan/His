using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E00_Model;
namespace LCDPK.uc
{
    public partial class UC_F3 : UserControl
    {
        #region Biến
        int i;
        LibDal.AccessData m = new LibDal.AccessData();
        DataTable dt = new DataTable();

        #region Tiêu đề

        public string TD_col_ID, TD_col_Ma, TD_col_Ten, TD_col_MaNhomLCD, TD_col_Font, TD_col_Size, TD_col_Style, TD_col_MauNen, TD_col_MauChu,
                      TD_col_CanLe, TD_col_ChieuCao, TD_col_ViTri, TD_col_SoLuong, TD_col_GhiChu, TD_col_STT, TD_col_TamNgung, TD_col_UserID, TD_col_NgayTao,
                      TD_col_UserUD, TD_col_NgayUD, TD_col_MaCHINEID = string.Empty;
        #endregion

        #region Vùng gọi
        public string VG_col_ID, VG_col_Ma, VG_col_Ten, VG_col_MaNhomLCD, VG_col_Font, VG_col_Size, VG_col_Style, VG_col_MauNen, VG_col_MauChu, VG_col_CanLe,
                      VG_col_ChieuCao, VG_col_ViTri, VG_col_SoLuong, VG_col_GhiChu, VG_col_STT, VG_col_TamNgung, VG_col_UserID, VG_col_NgayTao, VG_col_UserUD,
                      VG_col_NgayUD, VG_col_MaCHINEID = string.Empty;
        #endregion

        #endregion

        #region Hàm tạo
        public UC_F3()
        {
            InitializeComponent();
        }
        #endregion

        #region Function

        public StringAlignment Get_StringAlignment(string str)
        {
            switch (str.ToLower())
            {
                case "center":
                    return StringAlignment.Center;
                    break;
                case "far":
                    return StringAlignment.Far;
                    break;
                case "near":
                    return StringAlignment.Near;
                    break;

                default:
                    return StringAlignment.Center;
                    break;
            }
        }

        public string RGBConverter(Color c)
        {
            return c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString();
        }

        public FontStyle Get_FontStyle(string str)
        {
            switch (str.ToLower())
            {
                case "bold":
                    return FontStyle.Bold;
                    break;
                case "italic":
                    return FontStyle.Italic;
                    break;
                case "regular":
                    return FontStyle.Regular;
                    break;
                case "underline":
                    return FontStyle.Underline;
                    break;
                default:
                    return FontStyle.Regular;
                    break;
            }
        }

        public void GetData()
        {
            #region Tiêu đề
            TD_col_ID = "1";
            TD_col_Ma = "TDF3";
            TD_col_Ten = "TIÊU ĐỀ F3";
            TD_col_MaNhomLCD = "F3";
            TD_col_Font = "Arial";
            TD_col_Size = "14";
            TD_col_Style = "Bold"; // 2-đậm , 4-nghiêng , 8-Gạch dưới
            TD_col_MauNen = "Teal";
            TD_col_MauChu = "White";
            TD_col_CanLe = "Center";
            TD_col_ChieuCao = "50";
            TD_col_ViTri = "1";
            TD_col_SoLuong = "0";
            TD_col_GhiChu = "GHICHU";
            TD_col_STT = "STT";
            TD_col_TamNgung = "TAMNGUNG";
            TD_col_UserID = "USERID";
            TD_col_NgayTao = "NGAYTAO";
            TD_col_UserUD = "USERUD";
            TD_col_NgayUD = "NGAYUD";
            TD_col_MaCHINEID = "MACHINEID";



            lblTieude.Text = TD_col_Ten;
            lblTieude.Font = new Font(TD_col_Font, int.Parse(TD_col_Size), Get_FontStyle(TD_col_Style));//new Font(this.Font, FontStyle.Bold | FontStyle.Underline); //set khi kết hợp nhiều kiểu style chữ
            lblTieude.BackColor = Color.Teal;
            //lblTieude.BackColor = Color.FromArgb(Convert.ToInt32(TD_col_MauNen.Split(',')[0]), Convert.ToInt32(TD_col_MauNen.Split(',')[1]), Convert.ToInt32(TD_col_MauNen.Split(',')[2]));
            lblTieude.ForeColor = Color.White;
            //lblTieude.ForeColor = Color.FromArgb(Convert.ToInt32(TD_col_MauChu.Split(',')[0]), Convert.ToInt32(TD_col_MauChu.Split(',')[1]), Convert.ToInt32(TD_col_MauChu.Split(',')[2]));
            //lblTieude.TextAlignment = System.Drawing.StringAlignment.Center;
            lblTieude.TextAlignment = Get_StringAlignment(TD_col_CanLe);
            //pnl1.Height = Int32.Parse(TD_col_ChieuCao);

            #endregion

            #region Vùng gọi
            VG_col_ID = "2";
            VG_col_Ma = "VGF1";
            VG_col_Ten = "VÙNG GỌI F3";
            VG_col_MaNhomLCD = "F3";
            VG_col_Font = "Arial";
            VG_col_Size = "12";
            VG_col_Style = "Bold"; // 2-đậm , 4-nghiêng , 8-Gạch dưới
            VG_col_MauNen = "Teal";
            VG_col_MauChu = "Yellow";
            VG_col_CanLe = "Center";
            VG_col_ChieuCao = "50";
            VG_col_ViTri = "2";
            VG_col_SoLuong = "0";
            VG_col_GhiChu = "GHICHU";
            VG_col_STT = "STT";

            VG_col_TamNgung = "TAMNGUNG";
            VG_col_UserID = "USERID";
            VG_col_NgayTao = "NGAYTAO";
            VG_col_UserUD = "USERUD";
            VG_col_NgayUD = "NGAYUD";
            VG_col_MaCHINEID = "MACHINEID";

            lblVunggoi.Text = VG_col_Ten;
            lblVunggoi.Font = new Font(VG_col_Font, int.Parse(VG_col_Size), Get_FontStyle(VG_col_Style));//new Font(this.Font, FontStyle.Bold | FontStyle.Underline); //set khi kết hợp nhiều kiểu style chữ
            lblVunggoi.BackColor = System.Drawing.Color.Black ;
            //lblVunggoi.BackColor=Color.FromArgb(Convert.ToInt32(VG_col_MauNen.Split(',')[0]), Convert.ToInt32(VG_col_MauNen.Split(',')[1]), Convert.ToInt32(VG_col_MauNen.Split(',')[2]));
            lblVunggoi.ForeColor = System.Drawing.Color.Yellow;
            //lblVunggoi.ForeColor = Color.FromArgb(Convert.ToInt32(VG_col_MauChu.Split(',')[0]), Convert.ToInt32(VG_col_MauChu.Split(',')[1]), Convert.ToInt32(VG_col_MauChu.Split(',')[2]));
            //lblVunggoi.TextAlignment = System.Drawing.StringAlignment.Center;
            lblVunggoi.TextAlignment = Get_StringAlignment(VG_col_CanLe);
            //pnl2.Height = Int32.Parse(VG_col_ChieuCao);
            #endregion
         
        }
        #endregion
        private void UC_F3_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblVunggoi.ForeColor = Color.Yellow;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.lblVunggoi.ForeColor = Color.Green;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.lblVunggoi.ForeColor = Color.Blue;
        }
    }
}
