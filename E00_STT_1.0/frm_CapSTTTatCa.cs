using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E00_Base;
using DevComponents.DotNetBar;
using E00_Model;
using E00_Common;
using E00_Control;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace E00_STT
{
    public partial class frm_CapSTTTatCa : frm_Base
    {
        private string _idNhomKhu = "";
        private string _idKhu = "";
        private string _tenKhu = "";
        private DataTable _dtCapSTT = new DataTable();
        private Api_Common _api = new Api_Common();
        Acc_Oracle _acc = new Acc_Oracle();
        private string _userError = "";
        private string _systemError = "";
        private clsBUS _bus = new clsBUS();
        private bool checkLCDHIS = false;

        public frm_CapSTTTatCa(string idNhomKhu, string idKhu, string tenKhu)
        {
            InitializeComponent();

            _idNhomKhu = idNhomKhu;
            _idKhu = idKhu;
            _tenKhu = tenKhu;
            _api.KetNoi();
        }

        #region Tạo uscCapSTT

        private void TaoUscCapSTT(string maNoiCap, string tenKhu, string ghiChu)
        {
            usc_CapSTT usc_CapSTT1 = new E00_STT.usc_CapSTT();

            usc_CapSTT1.BackColor = System.Drawing.Color.Azure;
            usc_CapSTT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            usc_CapSTT1.Cursor = System.Windows.Forms.Cursors.Hand;
            usc_CapSTT1.Dock = System.Windows.Forms.DockStyle.Top;
            usc_CapSTT1.Location = new System.Drawing.Point(0, 0);
            usc_CapSTT1.Margin = new System.Windows.Forms.Padding(4);
            usc_CapSTT1.Name = "usc_CapSTT1";
            usc_CapSTT1.Size = new System.Drawing.Size(874, 70);
            usc_CapSTT1.TabIndex = 0;
            usc_CapSTT1.lblKhu.Tag = maNoiCap;
            usc_CapSTT1.lblKhu.Text = tenKhu.ToUpper();
            usc_CapSTT1.lblGhiChu.Tag = maNoiCap;
            usc_CapSTT1.lblGhiChu.Text = ghiChu;
            usc_CapSTT1.lblGhiChu.Click += new System.EventHandler(usc_CapSTT1_Click);
            usc_CapSTT1.lblKhu.Click += new System.EventHandler(usc_CapSTT1_Click);
            pnlFill.Controls.Add(usc_CapSTT1);

            his_ButtonX2 but = new his_ButtonX2();
            but.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            but.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            but.Location = new System.Drawing.Point(103, 3);
            but.Name = maNoiCap;
            but.Size = new System.Drawing.Size(200, 200);
            but.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            but.Cursor = Cursors.Hand;
            but.TabIndex = 1;
            but.Text = tenKhu;
            but.Click += But_Click;
            flowLayoutPanel1.Controls.Add(but);
        }

        private void But_Click(object sender, EventArgs e)
        {

            his_ButtonX2 but = (his_ButtonX2)sender;
            string maNoiCap = "K" + but.Name;
            string stt = "";
            try
            {
                checkLCDHIS = _acc.Get_Data(string.Format("select Value from {0}.{1} where {2}='{3}'", _acc.Get_User(), cls_Option.tb_TenBang, cls_Option.col_SYSPARAID, "CAUHINHLCD")).Rows[0][0].ToString() == "1" ? true : false;
            }
            catch (Exception)
            {
                checkLCDHIS = false;
            }
            if (checkLCDHIS)
            {
                string sttDK = "";
                string Ngay = "";
                try
                {
                    Ngay = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    sttDK = (int.Parse(_acc.Get_Data(string.Format("Select max(STT) as STT  from {0}.{1} where {2}='{3}' and to_char(NGAY,'dd/MM/yyyy')='{4}' ", _acc.Get_User(),cls_STT_DangKyCT.tb_TenBang,cls_STT_DangKyCT.col_IDKhu,_idKhu, DateTime.Now.ToString("dd/MM/yyyy"))).Rows[0][0].ToString())+1).ToString();
                }
                catch (Exception)
                {
                    sttDK = _idKhu + "001";
                }
                try
                {
                    string sql = "Insert into {0}.{1}({2},{3},{4},{8})values(to_date('{5}','dd/MM/yyyy HH24:mi:ss'),'{6}','{7}','{9}')";
                    sql = string.Format(sql, _acc.Get_User(), cls_STT_DangKyCT.tb_TenBang, cls_STT_DangKyCT.col_Ngay, cls_STT_DangKyCT.col_IDKhu, cls_STT_DangKyCT.col_STT, Ngay, _idKhu, sttDK,cls_STT_DangKyCT.col_UuTien, chkUuTien.Checked == true ? 1 : 0);
                    _acc.Execute_Data(ref _userError, ref _systemError, sql);
                    DataTable ds = new DataTable();
                    ds.Columns.Add("TEN");
                    ds.Columns.Add("NGAY");
                    ds.Columns.Add("SO");
                    ds.Columns.Add("UT", typeof(int));
                    DataRow dr = ds.NewRow();
                    dr[0] = _tenKhu;
                    dr[1] = Ngay;
                    dr[2] = sttDK;
                    dr[3] = chkUuTien.Checked==true ? 1 : 0;
                    ds.Rows.Add(dr);
                    ds.TableName = "Table";
                    ReportDocument oRpt = new ReportDocument();
                    oRpt.Load("..\\..\\..\\Report\\rptSttdangky.rpt", OpenReportMethod.OpenReportByDefault);
                    oRpt.SetDataSource(ds);
                    frm_ReportSTT frm = new frm_ReportSTT(oRpt);
                    frm.Text = "rptSttdangky.rpt";
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
                catch (Exception)
                {
                }

            }
            else
            {
                _bus.CapSTT(maNoiCap, but.Text, "", "", "", "", chkUuTien.Checked, true, chkXemIn.Checked, ref stt);
            }
        }

        #endregion

        private void Load_Data()
        {
            try
            {
                Dictionary<string, string> dicD = new Dictionary<string, string>();
                dicD.Add(cls_STT_KhuVuc.col_TamNgung, "0");
                if (_idKhu == "ALL")
                {
                    dicD.Add(cls_STT_KhuVuc.col_MaNhom, _idNhomKhu);
                    _dtCapSTT = _api.Search(ref _userError, ref _systemError, cls_STT_KhuVuc.tb_TenBang, andEqual: true, dicEqual: dicD,
                                                   orderByASC1: false, orderByName1: cls_STT_KhuVuc.col_Ten);
                    foreach (DataRow row in _dtCapSTT.Rows)
                    {
                        TaoUscCapSTT(row[cls_STT_KhuVuc.col_Ma] + "", row[cls_STT_KhuVuc.col_Ten] + "", row[cls_STT_KhuVuc.col_GhiChu] + "");
                    }
                }
                else
                {
                    //dicD.Add(cls_STT_KhoaPhong.col_MaNhom, _idKhu);
                    //_dtCapSTT = _api.Search(ref _userError, ref _systemError, cls_STT_KhoaPhong.tb_TenBang, andLike: false, dicDifferent: dicD,
                    //                               orderByASC1: false, orderByName1: cls_STT_KhoaPhong.col_Ten);
                    //foreach (DataRow row in _dtCapSTT.Rows)
                    //{
                    //    TaoUscCapSTT(row[cls_STT_KhuVuc.col_Ma] + "" , row[cls_STT_KhuVuc.col_Ten] + "" , row[cls_STT_KhuVuc.col_GhiChu] + "" );
                    //}

                    his_ButtonX2 but = new his_ButtonX2();
                    but.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
                    but.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
                    but.Font = new Font(but.Font.FontFamily, 30);
                    but.Name = _idKhu;
                    but.Dock = DockStyle.Fill;
                    but.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                    but.Cursor = Cursors.Hand;
                    but.TabIndex = 1;
                    but.Text = _tenKhu;
                    but.Click += But_Click;
                    this.Controls.Add(but);
                    but.BringToFront();
                }

            }
            catch
            {
                _dtCapSTT = null;
            }
        }


        private void usc_CapSTT1_Click(object sender, EventArgs e)
        {
            LabelX capSTT = (LabelX)sender;
            TA_MessageBox.MessageBox.Show(capSTT.Tag.ToString());
        }

        private void frm_CapSTTTatCa_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
    }
}
