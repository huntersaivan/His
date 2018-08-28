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
    public partial class UC_F2 : UserControl
    {

        #region Biến
        int i;
        LibDal.AccessData m = new LibDal.AccessData();
        DataTable dt = new DataTable();

        #region Vùng gọi
        public string VG_col_ID, VG_col_Ma, VG_col_Ten, VG_col_MaNhomLCD, VG_col_Font, VG_col_Size, VG_col_Style, VG_col_MauNen, VG_col_MauChu, VG_col_CanLe,
                      VG_col_ChieuCao, VG_col_ViTri, VG_col_SoLuong, VG_col_GhiChu, VG_col_STT, VG_col_TamNgung, VG_col_UserID, VG_col_NgayTao, VG_col_UserUD,
                      VG_col_NgayUD, VG_col_MaCHINEID = string.Empty;
        #endregion

        #region Khu vực
        public string KV_col_ID, KV_col_Ma, KV_col_Ten, KV_col_MaNhomLCD, KV_col_Font, KV_col_Size, KV_col_Style, KV_col_MauNen, KV_col_MauChu,
                      KV_col_CanLe, KV_col_ChieuCao, KV_col_ViTri, KV_col_SoLuong, KV_col_GhiChu, KV_col_STT, KV_col_TamNgung, KV_col_UserID, KV_col_NgayTao,
                      KV_col_UserUD, KV_col_NgayUD, KV_col_MaCHINEID = string.Empty;
        #endregion

        #endregion

        #region Hàm tạo
        public UC_F2()
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
            #region Vùng gọi
            VG_col_ID = "5";
            VG_col_Ma = "VGF2";
            VG_col_Ten = "VÙNG GỌI F2";
            VG_col_MaNhomLCD = "F2";
            VG_col_Font = "Arial";
            VG_col_Size = "12";
            VG_col_Style = "Bold"; // 2-đậm , 4-nghiêng , 8-Gạch dưới
            VG_col_MauNen = "Orange";
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
            lblVunggoi.Font = new Font(VG_col_Font, int.Parse(VG_col_Size), Get_FontStyle(VG_col_Font));//new Font(this.Font, FontStyle.Bold | FontStyle.Underline); //set khi kết hợp nhiều kiểu style chữ
            lblVunggoi.BackColor = System.Drawing.Color.Black;
            //lblVunggoi.BackColor=Color.FromArgb(Convert.ToInt32(VG_col_MauNen.Split(',')[0]), Convert.ToInt32(VG_col_MauNen.Split(',')[1]), Convert.ToInt32(VG_col_MauNen.Split(',')[2]));
            lblVunggoi.ForeColor = System.Drawing.Color.Yellow;
            //lblVunggoi.ForeColor = Color.FromArgb(Convert.ToInt32(VG_col_MauChu.Split(',')[0]), Convert.ToInt32(VG_col_MauChu.Split(',')[1]), Convert.ToInt32(VG_col_MauChu.Split(',')[2]));
            //lblVunggoi.TextAlignment = System.Drawing.StringAlignment.Center;
            lblVunggoi.TextAlignment = Get_StringAlignment(VG_col_CanLe);
            //pnl2.Height = Int32.Parse(VG_col_ChieuCao);
            #endregion

            #region Khu vực

            KV_col_ID = "4";
            KV_col_Ma = "KVF1";
            KV_col_Ten = "KHU VỰC F1";
            KV_col_MaNhomLCD = "F1";
            KV_col_Font = "Arial";
            KV_col_Size = "12";
            KV_col_Style = "Bold"; // 2-đậm , 4-nghiêng , 8-Gạch dưới
            KV_col_MauNen = "Teal";
            KV_col_MauChu = "Yellow";
            KV_col_CanLe = "Center";
            KV_col_ChieuCao = "50";
            KV_col_ViTri = "2";
            KV_col_SoLuong = "0";
            KV_col_GhiChu = "GHICHU";
            KV_col_STT = "STT";

            KV_col_TamNgung = "TAMNGUNG";
            KV_col_UserID = "USERID";
            KV_col_NgayTao = "NGAYTAO";
            KV_col_UserUD = "USERUD";
            KV_col_NgayUD = "NGAYUD";
            KV_col_MaCHINEID = "MACHINEID";

            lblKhuvuc.Text = KV_col_Ten;
            lblKhuvuc.Font = new Font(KV_col_Font, int.Parse(KV_col_Size), Get_FontStyle(KV_col_Style));//new Font(this.Font, FontStyle.Bold | FontStyle.Underline); //set khi kết hợp nhiều kiểu style chữ
            lblKhuvuc.BackColor = System.Drawing.Color.Teal;
            //lblKhuvuc.BackColor = Color.FromArgb(Convert.ToInt32(KV_col_MauNen.Split(',')[0]), Convert.ToInt32(KV_col_MauNen.Split(',')[1]), Convert.ToInt32(KV_col_MauNen.Split(',')[2]));
            lblKhuvuc.ForeColor = System.Drawing.Color.Yellow;
            //lblKhuvuc.ForeColor = Color.FromArgb(Convert.ToInt32(KV_col_MauChu.Split(',')[0]), Convert.ToInt32(KV_col_MauChu.Split(',')[1]), Convert.ToInt32(KV_col_MauChu.Split(',')[2]));
            //lblKhuvuc.TextAlignment = System.Drawing.StringAlignment.Center;
            lblKhuvuc.TextAlignment = Get_StringAlignment(KV_col_CanLe);
            //pnl4.Height = Int32.Parse(KV_col_ChieuCao);

            #endregion
        }
        #endregion

        #region Event
        private void UC_F2_Load(object sender, EventArgs e)
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
        #endregion
    }
}
