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
using DevComponents.DotNetBar;
namespace LCDPK.uc
{
    public partial class UC_F1 : UserControl
    {

        #region Biến
        int i;
        LibDal.AccessData m = new LibDal.AccessData();
        DataTable dt = new DataTable();
        public string stt = string.Empty;
        Timer timer ;
      
        #region Tiêu đề
        
        public string TD_col_ID,TD_col_Ma,TD_col_Ten,TD_col_MaNhomLCD,TD_col_Font,TD_col_Size,TD_col_Style,TD_col_MauNen,TD_col_MauChu,
                      TD_col_CanLe,TD_col_ChieuCao,TD_col_ViTri,TD_col_SoLuong,TD_col_GhiChu,TD_col_STT,TD_col_TamNgung,TD_col_UserID, TD_col_NgayTao,
                      TD_col_UserUD, TD_col_NgayUD,TD_col_MaCHINEID =string.Empty;
        #endregion

        #region Vùng gọi
        public string VG_col_ID, VG_col_Ma, VG_col_Ten ,VG_col_MaNhomLCD,VG_col_Font,VG_col_Size,VG_col_Style,VG_col_MauNen ,VG_col_MauChu ,VG_col_CanLe ,
                      VG_col_ChieuCao ,VG_col_ViTri,VG_col_SoLuong ,VG_col_GhiChu,VG_col_STT,VG_col_TamNgung,VG_col_UserID,VG_col_NgayTao,VG_col_UserUD,
                      VG_col_NgayUD ,VG_col_MaCHINEID = string.Empty;
        #endregion

        #region Vùng chờ
        public string VC_col_ID ,VC_col_Ma ,VC_col_Ten,VC_col_MaNhomLCD,VC_col_Font,VC_col_Size,VC_col_Style,VC_col_MauNen,VC_col_MauChu,VC_col_CanLe,
                      VC_col_ChieuCao,VC_col_ViTri,VC_col_SoLuong,VC_col_GhiChu ,VC_col_STT,VC_col_TamNgung,VC_col_UserID,VC_col_NgayTao,VC_col_UserUD,VC_col_NgayUD ,
                      VC_col_MaCHINEID = string.Empty;
        #endregion

        #region Khu vực
        public string KV_col_ID,KV_col_Ma ,KV_col_Ten,KV_col_MaNhomLCD ,KV_col_Font,KV_col_Size ,KV_col_Style ,KV_col_MauNen ,KV_col_MauChu ,
                      KV_col_CanLe,KV_col_ChieuCao ,KV_col_ViTri,KV_col_SoLuong,KV_col_GhiChu,KV_col_STT,KV_col_TamNgung,KV_col_UserID,KV_col_NgayTao,
                      KV_col_UserUD,KV_col_NgayUD ,KV_col_MaCHINEID = string.Empty;
        #endregion

        #endregion

        #region Hàm tạo
        
        public UC_F1()
        {
            InitializeComponent();
            timer= new Timer();
            timer.Tick += new EventHandler(timer4_Tick); 
            timer.Interval = 1000;             
            timer.Enabled = true;              
            timer.Start();                      
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
            switch(str.ToLower())
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
            TD_col_Ma = "TDF1";
            TD_col_Ten = "TIÊU ĐỀ F1";
            TD_col_MaNhomLCD = "F1";
            TD_col_Font = "Arial";
            TD_col_Size = "12";
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
            pnl1.Height = Int32.Parse(TD_col_ChieuCao);

            #endregion

            #region Vùng gọi
            VG_col_ID = "2";
            VG_col_Ma = "VGF1";
            VG_col_Ten = "VÙNG GỌI F1";
            VG_col_MaNhomLCD = "F1";
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
            //lblVunggoi.ForeColor = System.Drawing.Color.Yellow;
            //lblVunggoi.ForeColor = Color.FromArgb(Convert.ToInt32(VG_col_MauChu.Split(',')[0]), Convert.ToInt32(VG_col_MauChu.Split(',')[1]), Convert.ToInt32(VG_col_MauChu.Split(',')[2]));
            //lblVunggoi.TextAlignment = System.Drawing.StringAlignment.Center;
            lblVunggoi.TextAlignment = Get_StringAlignment(VG_col_CanLe);
            pnl2.Height = Int32.Parse(VG_col_ChieuCao);
            #endregion

            #region Vùng chờ
            VC_col_ID = "3";
            VC_col_Ma = "VCF1";
            VC_col_Ten = "VÙNG CHỜ F1";
            VC_col_MaNhomLCD = "F1";
            VC_col_Font = "Arial";
            VC_col_Size = "12";
            VC_col_Style = "Bold"; // 2-đậm , 4-nghiêng , 8-Gạch dưới
            VC_col_MauNen = "Black";
            VC_col_MauChu = "Yellow";
            VC_col_CanLe = "Center";
            VC_col_ChieuCao = "50";
            VC_col_ViTri = "2";
            VC_col_SoLuong = "5";
            VC_col_GhiChu = "GHICHU";
            VC_col_STT = "STT";

            VC_col_TamNgung = "TAMNGUNG";
            VC_col_UserID = "USERID";
            VC_col_NgayTao = "NGAYTAO";
            VC_col_UserUD = "USERUD";
            VC_col_NgayUD = "NGAYUD";
            VC_col_MaCHINEID = "MACHINEID";

            lblVungcho.Text = VC_col_Ten;
            lblVungcho.Font = new Font(VC_col_Font, int.Parse(VC_col_Size), Get_FontStyle(VC_col_Font));//new Font(this.Font, FontStyle.Bold | FontStyle.Underline); //set khi kết hợp nhiều kiểu style chữ
            lblVungcho.BackColor = System.Drawing.Color.Black;
            //lblVungcho.BackColor = Color.FromArgb(Convert.ToInt32(VC_col_MauNen.Split(',')[0]), Convert.ToInt32(VC_col_MauNen.Split(',')[1]), Convert.ToInt32(VC_col_MauNen.Split(',')[2]));
            lblVungcho.ForeColor = System.Drawing.Color.Yellow;
            //lblVungcho.ForeColor = Color.FromArgb(Convert.ToInt32(VC_col_MauChu.Split(',')[0]), Convert.ToInt32(VC_col_MauChu.Split(',')[1]), Convert.ToInt32(VC_col_MauChu.Split(',')[2]));
            //lblVungcho.TextAlignment = System.Drawing.StringAlignment.Center;
            lblVungcho.TextAlignment = Get_StringAlignment(VC_col_CanLe);
            pnl3.Height = Int32.Parse(VC_col_ChieuCao);

           
            //List<Panel> ls = new List<Panel>();
            //pnl3.Controls.Clear();
            //for (i = 0; i < pnl3.Height; i += pnl3.Height / int.Parse(VC_col_SoLuong))
            //{
            //    PanelEx pan = new PanelEx();
            //    pan.Location = new Point(0, i);
            //    pan.Size = new Size(pnl3.Width, pnl3.Height / int.Parse(VC_col_SoLuong));
            //    pan.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            //    pan.Style.BackColor1.Color = System.Drawing.Color.Black;
            //    pan.Style.BackColor2.Color = System.Drawing.Color.Black;
            //    pan.Style.Border = DevComponents.DotNetBar.eBorderType.Bump;

            //    Label l = new Label();
            //    l.Text = stt;//"121213. NGUYỄN NAM SINH";
            //    l.Font = new Font(VC_col_Font, int.Parse(VC_col_Size), Get_FontStyle(VC_col_Font));
            //    l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    l.ForeColor = System.Drawing.Color.White;
            //    l.Dock = DockStyle.Fill;
            //    l.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //    pan.Dock = DockStyle.Top;
            //    pan.Controls.Add(l);
            //    pnl3.Controls.Add(pan);

            //}


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
            pnl4.Height = Int32.Parse(KV_col_ChieuCao);

            #endregion
        }

        private void load_dscho(string maphongkam1, Panel pn, int tt)
        {
            //ngay = m.ngayhienhanh_server.Substring(0, 10);
            //xxx = user + _Utility.mmyy(ngay);
            //sql = "select to_char(a.ngayud,'hh24miss') as ngayud, a.sovaovien,b.hoten as ten,a.bnmoi,case when length(trim(k.tuoivao))<4 then to_char(sysdate,'yyyy')-b.namsinh||'T' else to_char(to_number(substr(k.tuoivao,1,3)))||case when substr(k.tuoivao,4,1)='0' then 'T' else case when substr(k.tuoivao,4,1)='1' then 'TH' else  case when substr(k.tuoivao,4,1)='2' then 'NG' else 'GI' end end end end as tuoivao";
            ////sql = "select a.sovaovien,b.hoten as ten,a.bnmoi";
            //sql += " from " + xxx + ".tiepdon a," + user + ".btdbn b," + xxx + ".lienhe k ";
            //sql += " where a.mabn=b.mabn and a.done is null and a.maql=k.maql and to_char(a.ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "'";
            //sql += " and a.noitiepdon in (0,1,5,16,9,10,11,12,15)  and a.dagoi=0 ";
            //if (maphongkam1 != "") sql += " and a.makp='" + maphongkam1 + "'";
            //sql += " order by  a.bnmoi,to_number(a.sovaovien)";
            //DataTable tmp = m.get_data(sql).Tables[0];
            //string _ten = "";
            //foreach (System.Windows.Forms.Control c in pn.Controls)
            //{
            //    try
            //    {
            //        NewLabel lbl = (NewLabel)c;
            //        lbl.Text = "";
            //    }
            //    catch { }
            //}
            //for (int i = 0; i < tmp.Rows.Count; i++)
            //{
            //    int test = tmp.Rows.Count;
            //    foreach (System.Windows.Forms.Control c in pn.Controls)
            //    {
            //        try
            //        {
            //            NewLabel lbl = (NewLabel)c;
            //            if (lbl.Name == "lbl_" + tt.ToString() + "_" + i.ToString())
            //            {
            //                string tv = tmp.Rows[i]["tuoivao"].ToString();
            //                string mystr = Regex.Replace(tv, @"\d", "");
            //                int mynumber = int.Parse(Regex.Replace(tv, @"\D", ""));
            //                int inumber;
            //                string KQ = string.Empty;
            //                switch (mystr)
            //                {
            //                    case "NG":
            //                        if (mynumber <= 60)
            //                        {
            //                            inumber = mynumber;
            //                            KQ = "  ( " + inumber.ToString() + " Ngày )";
            //                        }
            //                        else
            //                        {
            //                            int ktnhuan = KTNhuan(DateTime.Now);
            //                            if (ktnhuan == 1)
            //                            {
            //                                if (mynumber > 60 && mynumber <= 366)
            //                                {
            //                                    int thang = TinhThang(DateTime.Now.Day, mynumber);
            //                                    KQ = "  ( " + thang.ToString() + " Tháng )";
            //                                }
            //                            }
            //                            else
            //                            {
            //                                if (mynumber > 60 && mynumber <= 365)
            //                                {
            //                                    int thang = TinhThang(DateTime.Now.Day, mynumber);
            //                                    KQ = "  ( " + thang.ToString() + " Tháng )";
            //                                }
            //                            }
            //                        }
            //                        break;
            //                    case "TH":
            //                        if (mynumber > 2 && mynumber <= 72)
            //                        {
            //                            KQ = "  ( " + mynumber.ToString() + " Tháng )";
            //                        }
            //                        else
            //                        {
            //                            if (mynumber > 72)
            //                            {
            //                                int tuoi = mynumber / 12;
            //                                KQ = "  ( " + tuoi.ToString() + " Tuổi )";
            //                            }
            //                        }
            //                        break;
            //                    case "T":
            //                        if (mynumber <= 6)
            //                        {
            //                            int tuoi = mynumber * 12;
            //                            KQ = "  ( " + tuoi.ToString() + " Tháng )";
            //                        }
            //                        else
            //                        {
            //                            if (mynumber > 6)
            //                            {
            //                                KQ = "  ( " + mynumber.ToString() + " Tuổi )";
            //                            }
            //                        }
            //                        break;
            //                }
            //                //_ten =tmp.Rows[i]["sovaovien"].ToString() + ". " + tmp.Rows[i]["ten"].ToString() + " ( " + tmp.Rows[i]["tuoivao"].ToString() + " )";
            //                //_ten = tmp.Rows[i]["sovaovien"].ToString() + ". " + tmp.Rows[i]["ten"].ToString() + KQ;
            //                _ten = tmp.Rows[i]["ngayud"].ToString() + ". " + tmp.Rows[i]["ten"].ToString() + KQ;
            //                if (tmp.Rows[i]["bnmoi"].ToString() == "1") _ten = _ten + " [UT]";
            //                lbl.Text = _ten;
            //                break;
            //            }
            //        }
            //        catch { }
            //    }
            //}

        }

        #endregion

        #region Events
        
        private void UC_F1_Load(object sender, EventArgs e)
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
        
        private void timer4_Tick(object sender, EventArgs e)
        {
            int j = 0;
            try
            {
                DataTable dscho = new DataTable();
                dscho = m.get_data("select * from " + m.user + ".stt_capso where trangthai = 0 and rownum <= '" + VC_col_SoLuong + "' order by stt asc").Tables[0];
                
                pnl3.Controls.Clear();
                for (i = 0; i < pnl3.Height; i += pnl3.Height / int.Parse(VC_col_SoLuong))
                {
                    PanelEx pan = new PanelEx();
                    
                    pan.Location = new Point(0, i);
                    pan.Size = new Size(pnl3.Width, pnl3.Height / int.Parse(VC_col_SoLuong));
                    pan.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
                    pan.Style.BackColor1.Color = System.Drawing.Color.Black;
                    pan.Style.BackColor2.Color = System.Drawing.Color.Black;
                    pan.Style.Border = DevComponents.DotNetBar.eBorderType.Bump;
                    Label l = new Label();
                    l.Tag = j;
                    if (j < dscho.Rows.Count)
                    {
                        l.Text = dscho.Rows[j]["mabn"].ToString();//"121213. NGUYỄN NAM SINH";
                    }
                    else
                    {
                        l.Text = "";
                    }
                    l.Font = new Font(VC_col_Font, int.Parse(VC_col_Size), Get_FontStyle(VC_col_Font));
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    l.ForeColor = System.Drawing.Color.White;
                    l.Dock = DockStyle.Fill;
                    l.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    pan.Controls.Add(l);
                    pan.Dock = DockStyle.Bottom;
                    pnl3.Controls.Add(pan);
                    j++;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
       
    }
}
