using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E00_Common;
using E00_Model;
using System.Globalization;

namespace HISQLHSBA
{
    public partial class frmNhanHS : E00_Base.frm_DanhMuc
    {

        #region Biến toàn cục

        private Api_Common _api = new Api_Common();
        private bool _isDesign = true,_isNew = false;
        private string _userError = "";
        private string _systemError = "";
        public static string Loai = "";
        DataTable _ldt,_ldtReport,_ldtmoi;
        private LibDal.AccessData m = new LibDal.AccessData();
        private LibUtility.Utility _Utility = new LibUtility.Utility();
        private string sql = "", s_mabn = "", maluutru = "";
        private decimal l_maql = 0, l_sttnam = 0;
        private DataTable dtbs = new DataTable();
        private DataSet dtm = new DataSet();
        private DataSet dtt = new DataSet();
        private DataSet dsng = new DataSet();
        public string _tungay, _denngay, _makp;
        private int _userid;
        #endregion

        #region Khởi tạo

        public frmNhanHS(int userid)
        {

            _isDesign = true;
            InitializeComponent();
            _api.KetNoi();
            _isDesign = false;
            _userid = userid;
        }

        #endregion

        #region Phương thức

        #region Protected Override

        protected override void LoadData()
        {
            try
            {
                enable_obj(false);
                cbobenhan.SelectedIndex = 0;
                Load_KhoaPhong();
                Load_ICD10();
                dtpTuThang.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpDenThang.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                get_thoigian_bn();
                Load_BenhNhan();
                LoadGridView();
                //btnBoQua.Visible = false;
                btnSua.Visible = false;
                txtmabn2.Focus();
               // dgvMain.Columns["colNgay"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanHS));
                btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
                btnBoQua.Text = "In";

                //
                cboKetqua.DisplayMember = "TEN";
                cboKetqua.ValueMember = "MA";
                cboKetqua.DataSource = m.get_data("select * from ketqua order by ma").Tables[0];
                //
                cboTtLucrv.DisplayMember = "TEN";
                cboTtLucrv.ValueMember = "MA";
                cboTtLucrv.DataSource = m.get_data("select * from ttxk order by ma").Tables[0];
               
            }
            catch { }
        }

        protected override void Them()
        {
            empty_detail();
            empty_obj();
            txtmabn2.Focus();
        }

        protected override void Sua()
        {

        }

        protected override void Xoa()
        {
            try
            {
                if (m.execute_data("update his.ba_luutru set khthnhanba = '', nhanba = '' where maql = '" + l_maql.ToString() + "'"))
                {
                    DataRow row = m.getrowbyid(_ldt, "maql = " + l_maql.ToString());
                    row["khthnhanba"] = DBNull.Value;
                    row["ngayn"] = _Utility.cur_dd_mm_yyyy_hh24mi;
                    _ldt.AcceptChanges();
                    LoadGridView();
                    empty_detail();
                    empty_obj();
                    txtmabn2.Focus();
                }
            }
            catch
            {
            }
        }

        protected override void Luu()
        {
            try
            {
                if (l_maql == 0)
                {
                    TA_MessageBox.MessageBox.Show("Không tìm thấy thông tin bệnh nhân này!",   TA_MessageBox.MessageIcon.Warning);
                    return;
                }

                if (!KiemTra() && cbobenhan.SelectedIndex == 5) return;
                
                if (!(m.get_data("select mabn from his.ba_luutru where maql = '" + l_maql.ToString() + "'").Tables[0].Rows.Count >= 1))
                {
                    m.upd_ba_luutru(s_mabn, l_maql, txtsoluutru.Text,0, _Utility.cur_dd_mm_yyyy_hh24mi, "", "", "",
                       int.Parse(txtxq.Value.ToString()), int.Parse(txtct.Value.ToString()),
                       int.Parse(txtsa.Value.ToString()), int.Parse(txtxn.Value.ToString()),
                       int.Parse(txtdt.Value.ToString()), int.Parse(txtkhac.Value.ToString()),
                       int.Parse((txthoso.Text == "") ? "0" : txthoso.Text), "", "", l_sttnam,
                       cbobenhan.SelectedIndex, 0,0,
                       int.Parse(mri.Value.ToString()), int.Parse(ylenh.Value.ToString()), int.Parse(chamsoc.Value.ToString()),_userid);
                }

                DataRow row = m.getrowbyid(_ldt, "maql = " + l_maql.ToString());
                if (row == null)
                {
                    //thêm dòng dữ liệu mới them vào datatable
                    row = _ldt.NewRow();
                    row["mabn"] = txtmabn2.Text;
                    row["maql"] = l_maql.ToString();
                    row["sltmedi"] = txtsoluutru.Text;
                    row["ngayn"] = _Utility.cur_dd_mm_yyyy_hh24mi;
                    row["soxq"] = txtxq.Value;
                    row["soct"] = txtct.Value;
                    row["sosa"] = txtsa.Value;
                    row["soxn"] = txtxn.Value;
                    row["sokhac"] = txtkhac.Value;
                    row["sodt"] = txtdt.Value;
                    row["chamsoc"] = chamsoc.Value;
                    row["ylenh"] = ylenh.Value;
                    row["mri"] = mri.Value;
                    row["tonghoso"] = txthoso.Text == "" ? "0" : txthoso.Text;
                    row["hoten"] = txthoten.Text;
                    row["ngaysinh"] = txtnamsinh.Text;
                    if(txtnamsinh.Text.Length > 5) row["namsinh"] = txtnamsinh.Text.Substring(6,4);
                    row["phai"] = cboGioitinh.SelectedIndex;
                    row["tenkp"] = lblmakp.Text;
                    row["ngayvv"] = dtpNgayVao.Text;
                    try
                    {
                        row["ngayrv"] = dtpNgayRaVien.Text;
                    }
                    catch
                    {
                        row["ngayrv"] = dtpNgayRaVien.Value;
                    }
                    row["maicd_vaovien"] = slbCDVV.txtMa.Text;
                    row["maicd_ravien"] = slbCDRV.txtMa.Text;
                    row["icd_vaovien"] = slbCDVV.txtTen.Text;
                    row["icd_ravien"] = slbCDRV.txtTen.Text;
                    row["khthnhanba"] = "1";
                    row["sttba"] = "-1";
                    row["ttlucrv"] = cboTtLucrv.SelectedValue;
                    row["ketqua"] = cboKetqua.SelectedValue;
                    _ldt.Rows.Add(row);

                    row = m.getrowbyid(_ldt, "maql = " + l_maql.ToString());
                }

  
                sql = String.Format("update his.ba_luutru set khthnhanba = 1, nhanba = '',stt = ''," +
                    " ngayvv = to_date('{0}','dd/mm/yyyy hh24:mi'),ngayrv = to_date('{1}','dd/mm/yyyy hh24:mi'), icdvv = '{2}', icdrv = '{3}',chandoanvv = '{4}',chandoanrv = '{5}', tinhtrang = '{6}', ketqua = '{7}', makp = '{8}',soto = 1 ",
                        dtpNgayVao.Text,
                        dtpNgayRaVien.Text,
                        slbCDVV.txtMa.Text,
                        slbCDRV.txtMa.Text,
                        slbCDVV.txtTen.Text,
                        slbCDRV.txtTen.Text,
                        cboTtLucrv.SelectedValue.ToString(),
                        cboKetqua.SelectedValue.ToString(),
                        _makp);
                sql += " where maql = '" + l_maql.ToString() + "'";

                if (m.execute_data(sql))
                {                    
                    row["khthnhanba"] = 1;
                    row["ngayn"] = _Utility.cur_dd_mm_yyyy_hh24mi;
                    _ldt.AcceptChanges();
                    LoadGridView();
                    empty_detail();
                    empty_obj();
                    txtmabn2.Focus();
                    _isNew = false;
                }
            }
            catch
            {
            }
        }

        protected override void TimKiem()
        {
            try
            {

                
                    base.TimKiem();


            }
            catch
            {
                dgvMain.DataSource = null;
            }
        }

        #endregion

        #region Private

        private void Load_KhoaPhong()
        {
            try
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add(cls_BTDKP_BV.col_MaKP);
                list.Add(cls_BTDKP_BV.col_TenKP);
                this.slbKhoaPhong.DataSource = _api.Search(ref this._userError, ref this._systemError, cls_BTDKP_BV.tb_TenBang, null, -1, list, orderByASC1: true, orderByName1: cls_BTDKP_BV.col_TenKP);
                this.slbKhoaPhong.Show_Count = 10;
            }
            catch
            {
                slbKhoaPhong.DataSource = null;
            }
        }

        private void Load_ICD10()
        {
            try
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add(cls_ICD10.col_Ma);
                list.Add(cls_ICD10.col_Ten);
                slbCDVV.DataSource = slbCDRV.DataSource = _api.Search(ref this._userError, ref this._systemError, cls_ICD10.tb_TenBang, null, -1, list, orderByASC1: true, orderByName1: cls_ICD10.col_Ten);
                slbCDVV.Show_Count = slbCDVV.Show_Count = 10;
            }
            catch
            {
                slbKhoaPhong.DataSource = null;
            }
        }

        private void Load_BenhNhanMoi()
        {
            string sql1 = "", sql2 = "", sql3 = "", sql4 = "";
            string s_nam = get_thoigian_bn();
            string[] val = s_nam.Trim().Trim('+').Split('+');
            sql = "select maluutru,sort,maql,mabn,hoten, ngaysinh, namsinh, phai, tenkp,sltmedi,slthsba, ngayvv,maicd_vaovien,icd_vaovien,ngayrv,maicd_ravien,icd_ravien,ngayn, sttba,damuon,tenbs, gia,tang,vitri_o,soxq,soct,sosa,soxn,sodt,sokhac,tonghoso,nguoigiao,nguoinhan,loaiba,ttlucrv,ketqua,tainan,makho,mri,ylenh,chamsoc,madoituong,khthnhanba,makp from (";
            // 
            sql1 = " select a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi, ";
            sql1 += " b.maicd maicd_vaovien,b.chandoan icd_vaovien,to_date(to_char(a.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') as ngayrv,a.maicd maicd_ravien,a.chandoan icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn,";
            sql1 += " nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, b.madoituong,d.khthnhanba,a.makp";
            sql1 += " from " + m.user + ".xuatvien a, " + m.user + ".benhandt b, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
            sql1 += " where a.mabn=c.mabn and a.maql=b.maql and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp ";
            // if (smabn != "") sql1 += " and a.mabn='" + smabn + "'";
            // if (maql != 0) sql1 += " and a.maql=" + maql;
            //Phong luu
            if (s_nam.Trim() != "")
            {
                for (int i = 0; i < val.Length; i++)
                {
                    if (m.bMmyy(val[i].ToString()))
                    {
                        if (sql2 != "") sql2 += " union all ";
                        sql2 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_date(to_char(a.ngayrv,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') as ngayrv,";
                        sql2 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc,a.madoituong,d.khthnhanba,a.makp ";
                        sql2 += " from " + m.user + val[i].ToString() + ".benhancc a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql2 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                        // if (smabn != "") sql2 += " and a.mabn='" + smabn + "'";
                        // if (maql != 0) sql2 += " and a.maql=" + maql;
                    }
                }
            }
            //End Phong luu

            //Ngoai tru
            sql3 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_date(to_char(a.ngayrv,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') as ngayrv,";
            sql3 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba,a.makp ";
            sql3 += " from " + m.user + ".benhanngtr a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f ";
            sql3 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";

            ///
            //if (smabn != "") sql3 += " and a.mabn='" + smabn + "'";
            // if (maql != 0) sql3 += " and a.maql=" + maql;
            //End Ngoai tru
            //Phong kham
            #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
            if (s_nam.Trim() != "")
            {
                for (int i = 0; i < val.Length; i++)
                {
                    if (m.bMmyy(val[i].ToString()))
                    {
                        if (sql4 != "") sql4 += " union all ";
                        sql4 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,'' as sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_date(to_char(a.ngayrv,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') as ngayrv,";
                        sql4 += " null as maicd_ravien,null as icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,0 as ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba, a.makp ";
                        sql4 += " from " + m.user + val[i].ToString() + ".benhanpk a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql4 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                        // if (smabn != "") sql4 += " and a.mabn='" + smabn + "'";
                        // if (maql != 0) sql4 += " and a.maql=" + maql;
                    }
                }
            }
            #endregion
            //End Phong kham
            if (!String.IsNullOrEmpty(slbKhoaPhong.txtMa.Text))
            {
                switch (cbobenhan.SelectedIndex)
                {
                    case 1: sql += sql3 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by sort desc"; break;
                    #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                    case 5:
                        {
                            //if (s_nam.Trim() == "") sql += sql3 + ")  a order by sort desc";
                            if (s_nam.Trim() != "") sql += sql4 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "' order by sort desc"; break;
                        }
                    #endregion
                    case 2: sql += sql2 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by sort desc"; break;
                    case 0: sql += sql1 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by sort desc"; break;
                    default: sql += sql1 + " union all " + sql2 + ")  a where a.ttlucrv=7 and sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by sort desc"; break;
                }
            }
            else
            {
                switch (cbobenhan.SelectedIndex)
                {

                    #region code củ
                    case 1: sql += sql3 + ")  a where a.sttba = '-1'  order by sort desc"; break;
                    #endregion

                    #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                    case 5:
                        {
                            //if (s_nam.Trim() == "") sql += sql3 + ")  a order by sort desc";
                            if (s_nam.Trim() != "") sql += sql4 + ")  a where a.sttba = '-1'  order by sort desc"; break;
                        }
                    #endregion
                    case 2: sql += sql2 + ")  a where a.sttba = '-1'  order by sort desc"; break;
                    case 0: sql += sql1 + ")  a where a.sttba = '-1'  order by sort desc"; break;
                    default: sql += sql1 + " union all " + sql2 + ")  a where a.ttlucrv=7 and sttba = '-1'  order by sort desc"; break;
                }
            }

            try
            {
                _ldtmoi = m.get_data(sql).Tables[0];
            }
            catch
            {
                _ldtmoi = null;
            }         
        }

        private void Load_BenhNhan()
        {
            string sql1 = "", sql2 = "", sql3 = "", sql4 = "";
            string s_nam = get_thoigian_bn();
            string[] val = s_nam.Trim().Trim('+').Split('+');
            sql = "select maluutru,sort,maql,mabn,hoten, ngaysinh, namsinh, phai, tenkp,sltmedi,slthsba, ngayvv,maicd_vaovien,icd_vaovien,ngayrv,maicd_ravien,icd_ravien,ngayn, sttba,damuon,tenbs, gia,tang,vitri_o,soxq,soct,sosa,soxn,sodt,sokhac,tonghoso,nguoigiao,nguoinhan,loaiba,ttlucrv,ketqua,tainan,makho,mri,ylenh,chamsoc,madoituong,khthnhanba,makp from (";
            // 
            sql1 = " select e.maluutru,to_char(b.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql1 += " b.maicd maicd_vaovien,b.chandoan icd_vaovien,to_date(to_char(a.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') as ngayrv,a.maicd maicd_ravien,a.chandoan icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn,";
            sql1 += " nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, b.madoituong,d.khthnhanba,a.makp";
            sql1 += " from " + m.user + ".xuatvien a, " + m.user + ".benhandt b, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
            sql1 += " where a.mabn=c.mabn and a.maql=b.maql and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp ";
            // if (smabn != "") sql1 += " and a.mabn='" + smabn + "'";
            // if (maql != 0) sql1 += " and a.maql=" + maql;
            //Phong luu
            if (s_nam.Trim() != "")
            {
                for (int i = 0; i < val.Length; i++)
                {
                    if (m.bMmyy(val[i].ToString()))
                    {
                        if (sql2 != "") sql2 += " union all ";
                        sql2 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_date(to_char(a.ngayrv,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') as ngayrv,";
                        sql2 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc,a.madoituong,d.khthnhanba,a.makp ";
                        sql2 += " from " + m.user + val[i].ToString() + ".benhancc a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql2 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                        // if (smabn != "") sql2 += " and a.mabn='" + smabn + "'";
                        // if (maql != 0) sql2 += " and a.maql=" + maql;
                    }
                }
            }
            //End Phong luu

            //Ngoai tru
            sql3 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_date(to_char(a.ngayrv,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') as ngayrv,";
            sql3 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba,a.makp ";
            sql3 += " from " + m.user + ".benhanngtr a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f ";
            sql3 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";

            ///
            //if (smabn != "") sql3 += " and a.mabn='" + smabn + "'";
            // if (maql != 0) sql3 += " and a.maql=" + maql;
            //End Ngoai tru
            //Phong kham
            #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
            if (s_nam.Trim() != "")
            {
                for (int i = 0; i < val.Length; i++)
                {
                    if (m.bMmyy(val[i].ToString()))
                    {
                        if (sql4 != "") sql4 += " union all ";
                        sql4 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,'' as sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_date(to_char(a.ngayrv,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') as ngayrv,";
                        sql4 += " null as maicd_ravien,null as icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,0 as ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba, a.makp ";
                        sql4 += " from " + m.user + val[i].ToString() + ".benhanpk a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql4 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                        // if (smabn != "") sql4 += " and a.mabn='" + smabn + "'";
                        // if (maql != 0) sql4 += " and a.maql=" + maql;
                    }
                }
            }
            #endregion
            //End Phong kham
            if (!String.IsNullOrEmpty(slbKhoaPhong.txtMa.Text))
            {
                switch (cbobenhan.SelectedIndex)
                {
                    case 1: sql += sql3 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by sort desc"; break;
                    #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                    case 5:
                        {
                            //if (s_nam.Trim() == "") sql += sql3 + ")  a order by sort desc";
                            if (s_nam.Trim() != "") sql += sql4 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "' order by sort desc"; break;
                        }
                    #endregion
                    case 2: sql += sql2 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by sort desc"; break;
                    case 0: sql += sql1 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by sort desc"; break;
                    default: sql += sql1 + " union all " + sql2 + ")  a where a.ttlucrv=7 and sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by sort desc"; break;
                }
            }
            else
            {
                switch (cbobenhan.SelectedIndex)
                {

                    #region code củ
                    case 1: sql += sql3 + ")  a where a.sttba = '-1'  order by sort desc"; break;
                    #endregion

                    #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                    case 5:
                        {
                            //if (s_nam.Trim() == "") sql += sql3 + ")  a order by sort desc";
                            if (s_nam.Trim() != "") sql += sql4 + ")  a where a.sttba = '-1'  order by sort desc"; break;
                        }
                    #endregion
                    case 2: sql += sql2 + ")  a where a.sttba = '-1'  order by sort desc"; break;
                    case 0: sql += sql1 + ")  a where a.sttba = '-1'  order by sort desc"; break;
                    default: sql += sql1 + " union all " + sql2 + ")  a where a.ttlucrv=7 and sttba = '-1'  order by sort desc"; break;
                }
            }

            try
            {
                _ldt = m.get_data(sql).Tables[0];
            }
            catch
            {
                _ldt = null;
            }
        }

        private void Load_BenhNhan_Report()
        {
            string them = "left join his.btdpxa b on a.maphuongxa = b.maphuongxa left join his.btdquan c on a.maqu = c.maqu left join his.btdtt d on a.matt = d.matt";
            string sql1 = "", sql2 = "", sql3 = "", sql4 = "";
            string s_nam = get_thoigian_bn();
            string[] val = s_nam.Trim().Trim('+').Split('+');
            sql = "select a.maluutru,a.sort,a.maql,a.mabn,a.hoten, a.ngaysinh, a.namsinh, a.phai, a.tenkp,a.sltmedi,a.slthsba, a.ngayvv,a.maicd_vaovien,a.icd_vaovien,a.ngayrv,a.maicd_ravien,a.icd_ravien,a.ngayn, a.sttba,a.damuon,a.tenbs, a.gia,a.tang,a.vitri_o,a.soxq,a.soct,a.sosa,a.soxn,a.sodt,a.sokhac,a.tonghoso,a.nguoigiao,a.nguoinhan,a.loaiba,a.ttlucrv,a.ketqua,a.tainan,a.makho,a.mri,a.ylenh,a.chamsoc," +
                    "a.madoituong,a.khthnhanba,a.makp,a.sonha,a.thon,a.maphuongxa,a.maqu,a.matt,b.tenpxa,c.tenquan,d.tentt from (";
            // 
            sql1 = " select e.maluutru,to_char(b.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql1 += " b.maicd maicd_vaovien,b.chandoan icd_vaovien,a.ngay as ngayrv,a.maicd maicd_ravien,a.chandoan icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn,";
            sql1 += " nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, b.madoituong,d.khthnhanba,a.makp,c.sonha,c.thon,c.maphuongxa,c.maqu,c.matt";
            sql1 += " from " + m.user + ".xuatvien a, " + m.user + ".benhandt b, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
            sql1 += " where a.mabn=c.mabn and a.maql=b.maql and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp ";
            // if (smabn != "") sql1 += " and a.mabn='" + smabn + "'";
            // if (maql != 0) sql1 += " and a.maql=" + maql;
            //Phong luu
            if (s_nam.Trim() != "")
            {
                for (int i = 0; i < val.Length; i++)
                {
                    if (m.bMmyy(val[i].ToString()))
                    {
                        if (sql2 != "") sql2 += " union all ";
                        sql2 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,a.ngayrv,";
                        sql2 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc,a.madoituong,d.khthnhanba,a.makp,c.sonha,c.thon,c.maphuongxa,c.maqu,c.matt ";
                        sql2 += " from " + m.user + val[i].ToString() + ".benhancc a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql2 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                    }
                }
            }
            //End Phong luu

            //Ngoai tru
            sql3 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,a.ngayrv,";
            sql3 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba,a.makp,c.sonha,c.thon,c.maphuongxa,c.maqu,c.matt ";
            sql3 += " from " + m.user + ".benhanngtr a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f ";
            sql3 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";

           
            #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
            if (s_nam.Trim() != "")
            {
                for (int i = 0; i < val.Length; i++)
                {
                    if (m.bMmyy(val[i].ToString()))
                    {
                        if (sql4 != "") sql4 += " union all ";
                        sql4 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,'' as sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,a.ngayrv,";
                        sql4 += " null as maicd_ravien,null as icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,0 as ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba, a.makp,c.sonha,c.thon,c.maphuongxa,c.maqu,c.matt ";
                        sql4 += " from " + m.user + val[i].ToString() + ".benhanpk a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql4 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                    }
                }
            }
            #endregion
            //End Phong kham
            if (!String.IsNullOrEmpty(slbKhoaPhong.txtMa.Text))
            {
                switch (cbobenhan.SelectedIndex)
                {
                    case 1: sql += sql3 + ")  a " + them + " where a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by a.sttba desc,a.khthnhanba desc"; break;
                    #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                    case 5: if (s_nam.Trim() != "") sql += sql4 + ")  a " + them + " where a.makp = '" + slbKhoaPhong.txtMa.Text + "' order by a.sttba desc,a.khthnhanba desc"; break;
                    #endregion
                    case 2: sql += sql2 + ")  a " + them + " where a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by a.sttba desc,a.khthnhanba desc"; break;
                    case 0: sql += sql1 + ")  a " + them + " where a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by a.sttba desc,a.khthnhanba desc"; break;
                    default: sql += sql1 + " union all " + sql2 + ")  a " + them + " where a.ttlucrv=7 and a.makp = '" + slbKhoaPhong.txtMa.Text + "'  order by a.sttba desc,a.khthnhanba desc"; break;
                }
            }
            else
            {
                switch (cbobenhan.SelectedIndex)
                {
                    case 1: sql += sql3 + ")  a " + them + "  order by a.sttba desc,a.khthnhanba desc"; break;
                    #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                    case 5: if (s_nam.Trim() != "") sql += sql4 + ")  a " + them + "  order by a.sttba desc,a.khthnhanba desc"; break;

                    #endregion
                    case 2: sql += sql2 + ")  a " + them + "  order by a.sttba desc,a.khthnhanba desc"; break;
                    case 0: sql += sql1 + ")  a " + them + "  order by a.sttba desc,a.khthnhanba desc"; break;
                    default: sql += sql1 + " union all " + sql2 + ")  a " + them + " where a.ttlucrv=7  order by a.sttba desc,a.khthnhanba desc"; break;
                }
            }

            try
            {
                _ldtReport = m.get_data(sql).Tables[0];
            }
            catch
            {
                _ldtReport = null;
            }
        }

        private string get_thoigian_bn()
        {
            string _str = "";
            try
            {
                //_str = m.get_data("select nam from " + m.user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows[0][0].ToString();
                _str = _Utility.get_mmyy(dtpTuThang.Value.ToString("dd/MM/yyyy"), dtpDenThang.Value.ToString("dd/MM/yyyy"));
            }
            catch
            {
                //m.execute_data("update " + m.user + ".btdbn set nam=to_char(ngayud,'mmyy')||'+' where mabn='" + mabn + "'");
                //foreach (DataRow r in m.get_data("select nam from " + m.user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows)
                _str = "";
            }
            return _str;
        }

        public void LoadGridView()
        {
            try
            {
                dgvMain.DataSource = _ldt.Select("khthnhanba is null").CopyToDataTable();
            }
            catch
            {
                dgvMain.DataSource = null;
            }
            try
            {
                dgvDaNhan.DataSource = _ldt.Select("khthnhanba = '1'").CopyToDataTable();
            }
            catch
            {
                dgvDaNhan.DataSource = null;
            }
        }

        private void get_tonghoso()
        {
            decimal l_sohoso = 0;
            l_sohoso += txtxq.Value;
            l_sohoso += txtct.Value;
            l_sohoso += txtsa.Value;
            l_sohoso += txtdt.Value;
            l_sohoso += txtxn.Value;
            l_sohoso += txtkhac.Value;
            l_sohoso += mri.Value;
            l_sohoso += ylenh.Value;
            l_sohoso += chamsoc.Value;
            txthoso.Text = l_sohoso.ToString();
        }

        private void enable_obj(bool ena)
        {

            txtsoluutru.Enabled = cboKetqua.Enabled = cboTtLucrv.Enabled = dtpNgayVao.Enabled = dtpNgayRaVien.Enabled =  ena;
           // txtmabn2.Enabled = ena;
            
                txttinhtranghoso.Enabled =  ena;
            txthoten.Enabled = txtnamsinh.Enabled = cboGioitinh.Enabled = txttinhtranghoso.Enabled = false;
            //cbobenhan.Enabled = ena;
            txtxq.Enabled = ena;
            txtct.Enabled = txtsa.Enabled = txtxn.Enabled = txtdt.Enabled = txtkhac.Enabled = mri.Enabled = ylenh.Enabled = chamsoc.Enabled = ena;
            txthoso.Enabled = slbCDRV.Enabled = slbCDVV.Enabled = ena;
        }

        public decimal get_maql(string m_mabn, string m_ngay)
        {

            if (!m.bMmyy(this._Utility.mmyy(m_ngay)))
            {
                return 0M;
            }
            this.sql = "select maql from " + m.user + this._Utility.mmyy(m_ngay) + ".tiepdon where mabn='" + m_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + m_ngay + "'";
            DataSet ds = m.get_data(this.sql);
            decimal num = (ds.Tables[0].Rows.Count == 0) ? 0M : decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            return num;
        }

        private bool KiemTra()
        {
            if (cboKetqua.SelectedIndex == -1)
            {
                TA_MessageBox.MessageBox.Show("Vui lòng chọn kết quả!");
                cboKetqua.Enabled = true;
                cboKetqua.Focus();
                return false;
            }
            if (cboTtLucrv.SelectedIndex == -1)
            {
                TA_MessageBox.MessageBox.Show("Vui lòng chọn tình trạng lúc ra viện!");
                cboTtLucrv.Enabled = true;
                cboTtLucrv.Focus();
                return false;
            }
            if (slbCDRV.txtMa.Text == "")
            {
                TA_MessageBox.MessageBox.Show("Vui lòng chọn chẩn đoán ra viện!");
                slbCDRV.Enabled = true;
                slbCDRV.txtMa.Focus();
                return false;
            }
            if (slbCDVV.txtMa.Text == "")
            {
                TA_MessageBox.MessageBox.Show("Vui lòng chọn chẩn đoán vào viện!");
                slbCDVV.Enabled = true;
                slbCDVV.txtMa.Focus();
                return false;
            }
            return true;
        }

        #endregion

        

        #endregion

        private void dtpDenThang_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbobenhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isDesign) return;
            if (_isNew) return;
            if (cbobenhan.SelectedIndex == 2 || cbobenhan.SelectedIndex == 5)
            {
                dtpDenThang.Enabled = dtpTuThang.Enabled = butTim.Enabled = true;
            }
            else
            {
                dtpDenThang.Enabled = dtpTuThang.Enabled = butTim.Enabled = false;
            }
            Load_BenhNhan();
            LoadGridView();
            empty_detail();
            empty_obj();
        }

        private void txtmabn2_Validated(object sender, EventArgs e)
        {
            if (_isDesign) return;
            if (txtmabn2.Text == "" || txtmabn2.Text.Trim().Length < 3) return;
            if (txtmabn2.Text.Trim().Length != 8) txtmabn2.Text = txtmabn2.Text.Substring(0, 2) + txtmabn2.Text.Substring(2).PadLeft(6, '0');
            s_mabn = txtmabn2.Text;
            DataRow r;
            try
            {
                r = m.getrowbyid(_ldt, "mabn = " + txtmabn2.Text);
            }
            catch
            {
                r = null;
            }
            if (r != null)
            {

                l_maql = decimal.Parse(r["maql"].ToString());
                _makp = r["makp"].ToString();
                s_mabn = r["mabn"].ToString();
                txtmabn2.Text = s_mabn;
                txtsoluutru.Text = r["sltmedi"].ToString() != "" ? r["sltmedi"].ToString() : r["slthsba"].ToString();
                maluutru = r["maluutru"].ToString();
                txthoten.Text = r["hoten"].ToString();
                txtnamsinh.Text = (r["ngaysinh"].ToString() == "") ? r["namsinh"].ToString() : r["ngaysinh"].ToString();
                cboGioitinh.SelectedIndex = int.Parse(r["phai"].ToString());
                dtpNgayRaVien.Text = r["ngayrv"].ToString();
                lblmakp.Text = r["tenkp"].ToString();
                txttinhtranghoso.Text = r["tenkp"].ToString() + " chưa chuyển hồ sơ";
                   
                cboTtLucrv.SelectedValue = r["ttlucrv"].ToString();
                cboKetqua.SelectedValue = r["ketqua"].ToString();
                slbCDVV.txtMa.Text = r["maicd_vaovien"].ToString();
                slbCDVV.txtTen.Text = r["icd_vaovien"].ToString();
                slbCDRV.txtMa.Text = r["maicd_ravien"].ToString();
                slbCDRV.txtTen.Text = r["icd_ravien"].ToString();
                try
                {
                    dtpNgayVao.Text = DateTime.ParseExact(r["ngayvv"].ToString(), "dd/MM/yyyy HH:mm", null).ToString();
                    dtpNgayRaVien.Text = r["ngayrv"].ToString();
                }
                catch { }
                try
                {
                    txtxq.Value = decimal.Parse(r["soxq"].ToString());
                    mri.Value = decimal.Parse(r["mri"].ToString());
                    ylenh.Value = decimal.Parse(r["ylenh"].ToString());
                    chamsoc.Value = decimal.Parse(r["chamsoc"].ToString());
                    txtct.Value = decimal.Parse(r["soct"].ToString());
                    txtsa.Value = decimal.Parse(r["sosa"].ToString());
                    txtxn.Value = decimal.Parse(r["soxn"].ToString());
                    txtdt.Value = decimal.Parse(r["sodt"].ToString());
                    txtkhac.Value = decimal.Parse(r["sokhac"].ToString());
                    txthoso.Text = r["tonghoso"].ToString();
                }
                catch
                {
                    txtxq.Value = 0;
                    mri.Value = 0;
                    ylenh.Value = 0;
                    chamsoc.Value = 0;
                    txtct.Value = 0;
                    txtsa.Value = 0;
                    txtxn.Value = 0;
                    txtdt.Value = 0;
                    txtkhac.Value = 0;
                    txthoso.Text = "0";
                }
            }
            else
            {
                if (cbobenhan.SelectedIndex == 5)
                {
                    if (TA_MessageBox.MessageBox.Show("Không tìm thấy hồ sơ bệnh nhân này!\nHoặc\nHồ sơ chưa hoàn tất thủ tục!\nBạn có muốn nhập mới hồ sơ không?",  TA_MessageBox.MessageIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        enable_obj(true);
                        
                        dtpNgayVao.CustomFormat = dtpNgayRaVien.CustomFormat = "  /  /       :  ";
                        _isNew = true;
                        string sql = " select c.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai";
                        sql += " from his.btdbn c  where  c.mabn='" + txtmabn2.Text + "'";

                        try
                        {
                            _ldtmoi = m.get_data(sql).Tables[0];
                            r = m.getrowbyid(_ldtmoi, "mabn = " + txtmabn2.Text);


                        }
                        catch
                        {
                            r = null;
                        }
                        if (r != null)
                        {
                            empty_obj();
                            s_mabn = r["mabn"].ToString();
                            txtmabn2.Text = s_mabn;
                            txthoten.Text = r["hoten"].ToString();
                            txtnamsinh.Text = (r["ngaysinh"].ToString() == "") ? r["namsinh"].ToString() : r["ngaysinh"].ToString();
                            cboGioitinh.SelectedIndex = int.Parse(r["phai"].ToString());
                            //lblmakp.Text = r["tenkp"].ToString();
                            //txttinhtranghoso.Text = r["tenkp"].ToString() + " chưa chuyển hồ sơ";
                            dtpNgayVao.Focus();

                        }
                        else
                        {
                            TA_MessageBox.MessageBox.Show("Mã số bệnh nhân này không tồn tại?",   TA_MessageBox.MessageIcon.Warning);
                            txtmabn2.Focus();
                            return;
                        }
                    }
                    else
                    {
                        txtmabn2.Focus();
                        return;
                    }
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Không tìm thấy hồ sơ bệnh nhân này!\nHoặc\nHồ sơ chưa hoàn tất thủ tục!",   TA_MessageBox.MessageIcon.Warning);
                    return;
                }
            }
            if (chkNhanLienTuc.Checked && txtmabn2.Text.Trim().Length == 8)
            {
                Luu();
            }
            else
            {
               if(!_isNew) btnLuu.Focus();
            }
        }

        private void empty_detail()
        {
            if (_isDesign) return;
            txthoso.Text = "";
            txtxq.Value = txtct.Value = txtsa.Value = txtdt.Value = txtxn.Value = txtkhac.Value = mri.Value = chamsoc.Value = ylenh.Value = txtxq.Value = txtct.Value = txtsa.Value = txtxn.Value = txtkhac.Value = 0;
        }

        private void empty_obj()
        {
            if (_isDesign) return;
            txtsoluutru.Text = slbCDRV.txtMa.Text = slbCDRV.txtTen.Text = slbCDVV.txtMa.Text = slbCDVV.txtTen.Text = txtnamsinh.Text = "";
            txtmabn2.Text = txthoten.Text =  "";
            txtxq.Value = txtct.Value = txtsa.Value = txtxn.Value = txtdt.Value = txtkhac.Value = 0;
            txthoso.Text = "";
            mri.Value = ylenh.Value = chamsoc.Value = txtxq.Value = txtct.Value = txtsa.Value = txtxn.Value = txtkhac.Value = 0;
            txttinhtranghoso.Text = dtpNgayRaVien.Text = lblmakp.Text = "";
            dtpNgayRaVien.Text = dtpNgayVao.Text = "";
            cboKetqua.SelectedIndex = cboTtLucrv.SelectedIndex = -1;
        }

        private void slbKhoaPhong_HisSelectChange(object sender, EventArgs e)
        {
            if (_isDesign) return;
            Load_BenhNhan();
            LoadGridView();
        }

        private void dtpTuThang_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvDaNhan_SelectionChanged(object sender, EventArgs e)
        {
            //if (_isDesign) return;
            //txtmabn2.Text = dgvDaNhan["colMaBN1", dgvDaNhan.SelectedRows[0].Index].Value.ToString();
            //txtmabn2_Validated(null, null);
        }

        private void dgvDaNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isDesign) return;
            txtmabn2.Text = dgvDaNhan["colMaBN1", dgvDaNhan.SelectedRows[0].Index].Value.ToString();
            txtmabn2_Validated(null, null);
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void txtmabn2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtmabn2.Text.Trim() == "")
                {
                    TA_MessageBox.MessageBox.Show("Đề nghị nhập MSBN vào.");
                    txtmabn2.Enabled = true;
                    txtmabn2.Focus();
                }
                else
                    SendKeys.Send("{Tab}");
            }
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isDesign) return;
            txtmabn2.Text = dgvMain["colMaBN", dgvMain.SelectedRows[0].Index].Value.ToString();
            txtmabn2_Validated(null, null);
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void frmNhanHS_FormClosed(object sender, FormClosedEventArgs e)
        {
            _tungay = dtpTuThang.Value.ToString("dd/MM/yyyy");
            _denngay = dtpDenThang.Value.ToString("dd/MM/yyyy");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            Load_BenhNhan_Report();
            btnLuu.Enabled = btnXoa.Enabled = btnBoQua.Enabled = true;
            frmReportXuatBNRaVien f = new frmReportXuatBNRaVien(_ldtReport);
            f.ShowDialog();
        }

        private void dtpNgayVao_Validated(object sender, EventArgs e)
        {
            l_maql = get_maql(txtmabn2.Text, dtpNgayVao.Text.Substring(0,10));
            if (l_maql != 0)
            {
                string sql = "select a.maql,a.makp,b.tenkp from " + m.user + _Utility.mmyy(dtpNgayVao.Text) + ".tiepdon a left join his.btdkp_bv b on a.makp = b.makp where mabn='" + txtmabn2.Text + "' and to_char(ngay,'dd/mm/yyyy')='" + dtpNgayVao.Text.Substring(0, 10) + "'";
                DataSet ds = m.get_data(sql);
                DataRow r = m.getrowbyid(ds.Tables[0], "maql = " + l_maql);
                lblmakp.Text = r["tenkp"].ToString();
                txttinhtranghoso.Text = r["tenkp"].ToString() + " chưa chuyển hồ sơ";
                _makp = r["makp"].ToString();
            }
            else
            {
                TA_MessageBox.MessageBox.Show("Không tìm thấy thông tin vào viện vui lòng kiểm tra lại", TA_MessageBox.MessageIcon.Error);
                dtpNgayVao.Focus();
            }
        }

        private void ylenh_Validated(object sender, EventArgs e)
        {
            get_tonghoso();
        }

        private void dtpNgayVao_Enter(object sender, EventArgs e)
        {
            dtpNgayVao.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void dtpNgayRaVien_Enter(object sender, EventArgs e)
        {
            dtpNgayRaVien.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            Load_BenhNhan();
            LoadGridView();
        }

        private void ylenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        #region Event Enter numberic up down vannq 09/12/2017
        private void ylenh_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            ylenh.Select(0, ylenh.Value.ToString().Length);
        }

        private void chamsoc_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            chamsoc.Select(0, chamsoc.Value.ToString().Length);
        }

        private void txtxq_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            txtxq.Select(0, txtxq.Value.ToString().Length);
        }

        private void txtct_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            txtct.Select(0, txtct.Value.ToString().Length);
        }

        private void mri_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            mri.Select(0, mri.Value.ToString().Length);
        }

        private void txtsa_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            txtsa.Select(0, txtsa.Value.ToString().Length);
        }

        private void txtdt_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            txtdt.Select(0, txtdt.Value.ToString().Length);
        }

        private void txtxn_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            txtxn.Select(0, txtxn.Value.ToString().Length);
        }

        private void txtkhac_Enter(object sender, EventArgs e)
        {
            if (_isDesign)
            {
                return;
            }
            txtkhac.Select(0, txtkhac.Value.ToString().Length);
        }
        #endregion 

        private void txtkhac_KeyDown(object sender, KeyEventArgs e)
        {
            btnLuu.Focus();
        }

        private void cboKetqua_Enter(object sender, EventArgs e)
        {
            cboKetqua.DroppedDown = true;
        }

        private void cboTtLucrv_Enter(object sender, EventArgs e)
        {
            cboTtLucrv.DroppedDown = true;
        }

    }
}
