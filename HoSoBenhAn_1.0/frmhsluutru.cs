using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibList;
using DevComponents.DotNetBar;
using E00_Common;
using E00_Model;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using TA_MessageBox;

namespace HISQLHSBA
{
    public class frmhsluutru : Office2007Form
    {
        #region Biến toàn cục
        private LibDal.AccessData m;
        private LibUtility.Utility _Utility = new LibUtility.Utility();
        private string sql = "", s_mabn = "", s_soluutru = "", maluutru = "";
        private decimal l_maql = 0, l_id = 0, l_sttnam = 0;
        private DataTable dtbs = new DataTable();
        private DataSet dtm = new DataSet();
        private DataSet dtt = new DataSet();
        private DataSet dsng = new DataSet();
        private int i_tabpage = 0, i_row = 0, checkCol = 0, i_userid;
        private bool b_damuon = false, b_nhanba = false, bEdit = false, _design = true;
        string _userError = "", _systemError = "";
        private Api_Common _api = new Api_Common();

        public string _tungay, _denngay;
        //
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtvitri;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker ngaynhan;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker ngaytra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chktraba;
        private System.Windows.Forms.DateTimePicker ngaymuon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tenbs;
        private MaskedTextBox.MaskedTextBox mabs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsoluutru;
        private System.Windows.Forms.TextBox txtmabn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.TextBox txto;
        private System.Windows.Forms.TextBox txttang;
        private System.Windows.Forms.TextBox txtnguoigiao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPhai;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGrid dataGrid3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmang;
        private System.Windows.Forms.TextBox txtmann;
        private LibList.List listBS;
        private System.Windows.Forms.TabPage tabpage1;
        private System.Windows.Forms.TextBox txtnguoinhan;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtnamsinh;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txttinhtranghoso;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txthoso;
        private System.Windows.Forms.NumericUpDown txtxq;
        private System.Windows.Forms.NumericUpDown txtct;
        private System.Windows.Forms.NumericUpDown txtsa;
        private System.Windows.Forms.NumericUpDown txtxn;
        private System.Windows.Forms.NumericUpDown txtkhac;
        private LibList.List listBS1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox hoten_t;
        private System.Windows.Forms.TextBox soluutru_t;
        private System.Windows.Forms.TextBox mabn_t;
        private ButtonX butTim;
        private System.Windows.Forms.TextBox ten_t;
        private System.Windows.Forms.TextBox namsinh_t;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox gia_t;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox o_t;
        private System.Windows.Forms.TextBox tang_t;
        private Label label40;
        private Label label41;
        private MaskedTextBox.MaskedTextBox denngay;
        private MaskedTextBox.MaskedTextBox tungay;
        private ComboBox cboKhoa;
        private Label label42;
        private Label label43;
        private Label lbsobanhapkho;
        private CheckBox chktudongtang;
        private Label txttsbanam;
        private Label label28;
        private ComboBox cboGioitinh;
        private Label label44;
        private ComboBox cbobenhan;
        private ComboBox cbongayvao;
        private Label label45;
        private Label label46;
        private TextBox maicd_vao;
        private TextBox icd_vao;
        private TextBox icd_ravien;
        private TextBox maicd_ravien;
        private Label label47;
        private TextBox ngayravien;
        private Label label49;
        private NumericUpDown txtdt;
        private Label label48;
        private Label label36;
        private ComboBox cboDoituong;
        private Label label50;
        private ComboBox cboGioitinh_tim;
        private Label label51;
        private ComboBox cboTinhtrang;
        private Label label52;
        private Label label53;
        private Label label54;
        private ComboBox cboKetqua;
        private ComboBox cboTtLucrv;
        private CheckBox chkTainan;
        private ButtonX butMoi;
        private ButtonX butSua;
        private ButtonX butLuu;
        private ButtonX butBoqua;
        private ButtonX butHuy;
        private ButtonX butIn;
        private ButtonX butKetthuc;
        private TextBox icd_nn;
        private TextBox maicd_nn;
        private Label label55;
        private ComboBox makho;
        private Label label56;
        private MaskedTextBox.MaskedTextBox maicd;
        private Label label57;
        private CheckBox chkzum;
        private NumericUpDown ylenh;
        private Label label60;
        private Label label61;
        private NumericUpDown mri;
        private Label label58;
        private Label label59;
        private Label label62;
        private ComboBox makhotim;
        private Label lblmakp;
        private Label label23;
        private Label label13;
        private NumericUpDown chamsoc;
        private DataGrid dataGrid2;
        private IContainer components;
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged = true, bVitritudong;
        private CheckBox chkthieu;
        private TextBox diachi;
        private Label label63;
        private DataGrid dataGrid4;
        private ComboBox timngay;
        private Label label64;
        private ComboBox userid;
        private Label label65;
        private DataSet dst = new DataSet();
        private DataTable dtkp = new DataTable();
        private DataTable dt = new DataTable();
        private E00_Control.his_Panel his_Panel1;
        private E00_Control.his_TextboxX txtTimKiem;
        private E00_Control.his_DataGridView dgvMain;
        private CheckBox chkViTriTuDong;
        private E00_ControlNew.usc_SelectBox slbGia;
        private E00_ControlNew.usc_SelectBox slbO;
        private E00_Control.his_LabelX his_LabelX7;
        private E00_Control.his_LabelX his_LabelX8;
        private E00_Control.his_LabelX his_LabelX3;
        private E00_Control.his_LabelX his_LabelX4;
        private E00_Control.his_LabelX his_LabelX5;
        private E00_Control.his_LabelX his_LabelX6;
        private E00_ControlNew.usc_SelectBox slbTang;
        private E00_Control.his_LabelX his_LabelX1;
        private E00_Control.his_LabelX his_LabelX2;
        private E00_Control.his_LabelX lblTen;
        private E00_Control.his_LabelX labelX1;
        private E00_ControlNew.usc_SelectBox slbO1;
        private E00_Control.his_LabelX object_15083c67_ef79_4a40_a690_ce184f0b10c2;
        private E00_Control.his_LabelX object_26bae368_2a61_457d_995e_33689cd35eb9;
        private E00_Control.his_LabelX his_LabelX9;
        private E00_Control.his_LabelX his_LabelX10;
        private E00_Control.his_LabelX his_LabelX11;
        private E00_Control.his_LabelX his_LabelX12;
        private E00_Control.his_LabelX his_LabelX13;
        private E00_Control.his_LabelX his_LabelX14;
        private E00_ControlNew.usc_SelectBox slbTang1;
        private E00_Control.his_LabelX object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53;
        private E00_Control.his_LabelX object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f;
        private E00_Control.his_LabelX his_LabelX15;
        private E00_Control.his_LabelX his_LabelX16;
        private E00_Control.his_LabelX his_LabelX17;
        private E00_Control.his_LabelX his_LabelX18;
        private E00_ControlNew.usc_SelectBox slbGia1;
        private E00_Control.his_LabelX object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7;
        private E00_Control.his_LabelX object_7fd77ea2_2310_48f4_be5e_afe030f27697;
        private E00_Control.his_LabelX object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd;
        private E00_Control.his_LabelX object_ab5cce97_6a19_40e5_84d8_bc161b27d954;
        private E00_ControlNew.usc_SelectBox slbKhoaPhong;
        private Label label66;
        private Label lblKQ;
        private RadioButton radDaNhan;
        private RadioButton radChuaNhan;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private TextBox txtMaDoiTuong;
        private ButtonX btnNhanHS;
        private DataGridViewTextBoxColumn colMaBN;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colNgay;
        private DataGridViewTextBoxColumn colMaQL;
        private Label label67;
        private TextBox txtSoRaVien;
        BindingSource _bs = new BindingSource(); 
        #endregion

        #region Khởi tạo

        public frmhsluutru(LibDal.AccessData acc, string smabn, string ssoluutru, decimal lmaql, int _userid)
        {
            InitializeComponent();
            m = acc;
            s_mabn = smabn; s_soluutru = ssoluutru; l_maql = lmaql; i_userid = _userid;
            _api.KetNoi();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    if (disabledBackBrush != null)
                    {
                        disabledBackBrush.Dispose();
                        disabledTextBrush.Dispose();
                        alertBackBrush.Dispose();
                        alertFont.Dispose();
                        alertTextBrush.Dispose();
                        currentRowFont.Dispose();
                        currentRowBackBrush.Dispose();
                    }
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmhsluutru));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpage1 = new System.Windows.Forms.TabPage();
            this.slbO = new E00_ControlNew.usc_SelectBox();
            this.his_LabelX7 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX8 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX3 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX4 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX5 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX6 = new E00_Control.his_LabelX(this.components);
            this.slbTang = new E00_ControlNew.usc_SelectBox();
            this.his_LabelX1 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX2 = new E00_Control.his_LabelX(this.components);
            this.lblTen = new E00_Control.his_LabelX(this.components);
            this.labelX1 = new E00_Control.his_LabelX(this.components);
            this.slbGia = new E00_ControlNew.usc_SelectBox();
            this.chkViTriTuDong = new System.Windows.Forms.CheckBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chamsoc = new System.Windows.Forms.NumericUpDown();
            this.ylenh = new System.Windows.Forms.NumericUpDown();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.mri = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.chkzum = new System.Windows.Forms.CheckBox();
            this.makho = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.chkTainan = new System.Windows.Forms.CheckBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtdt = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.chktudongtang = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtkhac = new System.Windows.Forms.NumericUpDown();
            this.txtxn = new System.Windows.Forms.NumericUpDown();
            this.txtsa = new System.Windows.Forms.NumericUpDown();
            this.txtct = new System.Windows.Forms.NumericUpDown();
            this.txtxq = new System.Windows.Forms.NumericUpDown();
            this.listBS = new LibList.List();
            this.txtmann = new System.Windows.Forms.TextBox();
            this.txtmang = new System.Windows.Forms.TextBox();
            this.txtnguoinhan = new System.Windows.Forms.TextBox();
            this.txtnguoigiao = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txthoso = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtvitri = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txto = new System.Windows.Forms.TextBox();
            this.txttang = new System.Windows.Forms.TextBox();
            this.ngaynhan = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chktraba = new System.Windows.Forms.CheckBox();
            this.ngaymuon = new System.Windows.Forms.DateTimePicker();
            this.listBS1 = new LibList.List();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.ngaytra = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.slbO1 = new E00_ControlNew.usc_SelectBox();
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2 = new E00_Control.his_LabelX(this.components);
            this.object_26bae368_2a61_457d_995e_33689cd35eb9 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX9 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX10 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX11 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX12 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX13 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX14 = new E00_Control.his_LabelX(this.components);
            this.slbTang1 = new E00_ControlNew.usc_SelectBox();
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53 = new E00_Control.his_LabelX(this.components);
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f = new E00_Control.his_LabelX(this.components);
            this.his_LabelX15 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX16 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX17 = new E00_Control.his_LabelX(this.components);
            this.his_LabelX18 = new E00_Control.his_LabelX(this.components);
            this.slbGia1 = new E00_ControlNew.usc_SelectBox();
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7 = new E00_Control.his_LabelX(this.components);
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697 = new E00_Control.his_LabelX(this.components);
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd = new E00_Control.his_LabelX(this.components);
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954 = new E00_Control.his_LabelX(this.components);
            this.makhotim = new System.Windows.Forms.ComboBox();
            this.userid = new System.Windows.Forms.ComboBox();
            this.chkthieu = new System.Windows.Forms.CheckBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.timngay = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.cboTinhtrang = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.cboDoituong = new System.Windows.Forms.ComboBox();
            this.cboGioitinh_tim = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.denngay = new MaskedTextBox.MaskedTextBox();
            this.tungay = new MaskedTextBox.MaskedTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.ten_t = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.namsinh_t = new System.Windows.Forms.TextBox();
            this.hoten_t = new System.Windows.Forms.TextBox();
            this.soluutru_t = new System.Windows.Forms.TextBox();
            this.mabn_t = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lbsobanhapkho = new System.Windows.Forms.Label();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.o_t = new System.Windows.Forms.TextBox();
            this.tang_t = new System.Windows.Forms.TextBox();
            this.gia_t = new System.Windows.Forms.TextBox();
            this.butTim = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsoluutru = new System.Windows.Forms.TextBox();
            this.txtmabn2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnamsinh = new System.Windows.Forms.TextBox();
            this.lblPhai = new System.Windows.Forms.Label();
            this.txttinhtranghoso = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txttsbanam = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cboGioitinh = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cbobenhan = new System.Windows.Forms.ComboBox();
            this.cbongayvao = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.maicd_vao = new System.Windows.Forms.TextBox();
            this.icd_vao = new System.Windows.Forms.TextBox();
            this.icd_ravien = new System.Windows.Forms.TextBox();
            this.maicd_ravien = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.ngayravien = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.cboKetqua = new System.Windows.Forms.ComboBox();
            this.cboTtLucrv = new System.Windows.Forms.ComboBox();
            this.butMoi = new DevComponents.DotNetBar.ButtonX();
            this.butSua = new DevComponents.DotNetBar.ButtonX();
            this.butLuu = new DevComponents.DotNetBar.ButtonX();
            this.butBoqua = new DevComponents.DotNetBar.ButtonX();
            this.butHuy = new DevComponents.DotNetBar.ButtonX();
            this.butIn = new DevComponents.DotNetBar.ButtonX();
            this.butKetthuc = new DevComponents.DotNetBar.ButtonX();
            this.icd_nn = new System.Windows.Forms.TextBox();
            this.maicd_nn = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.lblmakp = new System.Windows.Forms.Label();
            this.his_Panel1 = new E00_Control.his_Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.slbKhoaPhong = new E00_ControlNew.usc_SelectBox();
            this.radDaNhan = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new E00_Control.his_TextboxX();
            this.radChuaNhan = new System.Windows.Forms.RadioButton();
            this.label66 = new System.Windows.Forms.Label();
            this.lblKQ = new System.Windows.Forms.Label();
            this.dgvMain = new E00_Control.his_DataGridView();
            this.colMaBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaQL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaDoiTuong = new System.Windows.Forms.TextBox();
            this.btnNhanHS = new DevComponents.DotNetBar.ButtonX();
            this.label67 = new System.Windows.Forms.Label();
            this.txtSoRaVien = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabpage1.SuspendLayout();
            this.slbO.SuspendLayout();
            this.slbTang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chamsoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ylenh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkhac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtxn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtxq)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.slbO1.SuspendLayout();
            this.slbTang1.SuspendLayout();
            this.slbGia1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.his_Panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabpage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(340, 143);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(711, 552);
            this.tabControl1.TabIndex = 31;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabpage1
            // 
            this.tabpage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.tabpage1.Controls.Add(this.slbO);
            this.tabpage1.Controls.Add(this.slbTang);
            this.tabpage1.Controls.Add(this.slbGia);
            this.tabpage1.Controls.Add(this.chkViTriTuDong);
            this.tabpage1.Controls.Add(this.dataGrid2);
            this.tabpage1.Controls.Add(this.dataGrid4);
            this.tabpage1.Controls.Add(this.label23);
            this.tabpage1.Controls.Add(this.label13);
            this.tabpage1.Controls.Add(this.chamsoc);
            this.tabpage1.Controls.Add(this.ylenh);
            this.tabpage1.Controls.Add(this.label60);
            this.tabpage1.Controls.Add(this.label61);
            this.tabpage1.Controls.Add(this.mri);
            this.tabpage1.Controls.Add(this.label58);
            this.tabpage1.Controls.Add(this.label59);
            this.tabpage1.Controls.Add(this.chkzum);
            this.tabpage1.Controls.Add(this.makho);
            this.tabpage1.Controls.Add(this.label56);
            this.tabpage1.Controls.Add(this.chkTainan);
            this.tabpage1.Controls.Add(this.label49);
            this.tabpage1.Controls.Add(this.txtdt);
            this.tabpage1.Controls.Add(this.label48);
            this.tabpage1.Controls.Add(this.chktudongtang);
            this.tabpage1.Controls.Add(this.label10);
            this.tabpage1.Controls.Add(this.label31);
            this.tabpage1.Controls.Add(this.txtkhac);
            this.tabpage1.Controls.Add(this.txtxn);
            this.tabpage1.Controls.Add(this.txtsa);
            this.tabpage1.Controls.Add(this.txtct);
            this.tabpage1.Controls.Add(this.txtxq);
            this.tabpage1.Controls.Add(this.listBS);
            this.tabpage1.Controls.Add(this.txtmann);
            this.tabpage1.Controls.Add(this.txtmang);
            this.tabpage1.Controls.Add(this.txtnguoinhan);
            this.tabpage1.Controls.Add(this.txtnguoigiao);
            this.tabpage1.Controls.Add(this.label27);
            this.tabpage1.Controls.Add(this.label26);
            this.tabpage1.Controls.Add(this.label24);
            this.tabpage1.Controls.Add(this.label25);
            this.tabpage1.Controls.Add(this.label22);
            this.tabpage1.Controls.Add(this.label21);
            this.tabpage1.Controls.Add(this.label20);
            this.tabpage1.Controls.Add(this.txthoso);
            this.tabpage1.Controls.Add(this.label19);
            this.tabpage1.Controls.Add(this.label18);
            this.tabpage1.Controls.Add(this.label17);
            this.tabpage1.Controls.Add(this.label16);
            this.tabpage1.Controls.Add(this.label15);
            this.tabpage1.Controls.Add(this.label14);
            this.tabpage1.Controls.Add(this.txtvitri);
            this.tabpage1.Controls.Add(this.label4);
            this.tabpage1.Controls.Add(this.txto);
            this.tabpage1.Controls.Add(this.txttang);
            this.tabpage1.Controls.Add(this.ngaynhan);
            this.tabpage1.Controls.Add(this.label11);
            this.tabpage1.Controls.Add(this.label12);
            this.tabpage1.Location = new System.Drawing.Point(4, 22);
            this.tabpage1.Name = "tabpage1";
            this.tabpage1.Size = new System.Drawing.Size(703, 526);
            this.tabpage1.TabIndex = 0;
            this.tabpage1.Text = "Quản lý Hồ sơ";
            // 
            // slbO
            // 
            this.slbO.Controls.Add(this.his_LabelX7);
            this.slbO.Controls.Add(this.his_LabelX8);
            this.slbO.Controls.Add(this.his_LabelX3);
            this.slbO.Controls.Add(this.his_LabelX4);
            this.slbO.Controls.Add(this.his_LabelX5);
            this.slbO.Controls.Add(this.his_LabelX6);
            this.slbO.DataSource = null;
            this.slbO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbO.his_AddNew = false;
            this.slbO.his_ColMa = null;
            this.slbO.his_ColTen = null;
            this.slbO.his_FontSize = 10F;
            this.slbO.his_lblText = "Mã:";
            this.slbO.his_lblTitle1_Bold = false;
            this.slbO.his_lblTitle1_text = "labelX1";
            this.slbO.his_lblTitle1_Visible = false;
            this.slbO.his_lblTitle1_Width = 0;
            this.slbO.his_lblVisible = false;
            this.slbO.his_lblWidth = 0;
            this.slbO.his_ShowCount = 10;
            this.slbO.his_TabLocation = 0;
            this.slbO.his_TenReadonly = false;
            this.slbO.his_TenReadOnly = false;
            this.slbO.his_TenVisible = true;
            this.slbO.his_txtWidth = 0;
            this.slbO.his_XoaMa = true;
            this.slbO.Location = new System.Drawing.Point(268, 344);
            this.slbO.Margin = new System.Windows.Forms.Padding(0);
            this.slbO.Name = "slbO";
            this.slbO.Size = new System.Drawing.Size(93, 23);
            this.slbO.TabIndex = 19;
            // 
            // his_LabelX7
            // 
            this.his_LabelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX7.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX7.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX7.IsNotNull = false;
            this.his_LabelX7.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX7.Margin = new System.Windows.Forms.Padding(4);
            this.his_LabelX7.Name = "his_LabelX7";
            this.his_LabelX7.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX7.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX7.TabIndex = 0;
            this.his_LabelX7.Text = "Mã:";
            this.his_LabelX7.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // his_LabelX8
            // 
            // 
            // 
            // 
            this.his_LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX8.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.his_LabelX8.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX8.IsNotNull = false;
            this.his_LabelX8.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX8.Name = "his_LabelX8";
            this.his_LabelX8.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX8.TabIndex = 3;
            this.his_LabelX8.Text = "labelX1";
            // 
            // his_LabelX3
            // 
            this.his_LabelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX3.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX3.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX3.IsNotNull = false;
            this.his_LabelX3.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX3.Margin = new System.Windows.Forms.Padding(4);
            this.his_LabelX3.Name = "his_LabelX3";
            this.his_LabelX3.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX3.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX3.TabIndex = 4;
            this.his_LabelX3.Text = "Mã:";
            this.his_LabelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            this.his_LabelX3.Visible = false;
            // 
            // his_LabelX4
            // 
            // 
            // 
            // 
            this.his_LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX4.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.his_LabelX4.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX4.IsNotNull = false;
            this.his_LabelX4.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX4.Name = "his_LabelX4";
            this.his_LabelX4.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX4.TabIndex = 3;
            this.his_LabelX4.Text = "labelX1";
            this.his_LabelX4.Visible = false;
            // 
            // his_LabelX5
            // 
            this.his_LabelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX5.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX5.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX5.IsNotNull = false;
            this.his_LabelX5.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX5.Margin = new System.Windows.Forms.Padding(4);
            this.his_LabelX5.Name = "his_LabelX5";
            this.his_LabelX5.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX5.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX5.TabIndex = 4;
            this.his_LabelX5.Text = "Mã:";
            this.his_LabelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            this.his_LabelX5.Visible = false;
            // 
            // his_LabelX6
            // 
            // 
            // 
            // 
            this.his_LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX6.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX6.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX6.IsNotNull = false;
            this.his_LabelX6.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX6.Name = "his_LabelX6";
            this.his_LabelX6.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX6.TabIndex = 3;
            this.his_LabelX6.Text = "labelX1";
            this.his_LabelX6.Visible = false;
            // 
            // slbTang
            // 
            this.slbTang.Controls.Add(this.his_LabelX1);
            this.slbTang.Controls.Add(this.his_LabelX2);
            this.slbTang.Controls.Add(this.lblTen);
            this.slbTang.Controls.Add(this.labelX1);
            this.slbTang.DataSource = null;
            this.slbTang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbTang.his_AddNew = false;
            this.slbTang.his_ColMa = null;
            this.slbTang.his_ColTen = null;
            this.slbTang.his_FontSize = 10F;
            this.slbTang.his_lblText = "Mã:";
            this.slbTang.his_lblTitle1_Bold = false;
            this.slbTang.his_lblTitle1_text = "labelX1";
            this.slbTang.his_lblTitle1_Visible = false;
            this.slbTang.his_lblTitle1_Width = 0;
            this.slbTang.his_lblVisible = false;
            this.slbTang.his_lblWidth = 0;
            this.slbTang.his_ShowCount = 10;
            this.slbTang.his_TabLocation = 0;
            this.slbTang.his_TenReadonly = false;
            this.slbTang.his_TenReadOnly = false;
            this.slbTang.his_TenVisible = true;
            this.slbTang.his_txtWidth = 0;
            this.slbTang.his_XoaMa = true;
            this.slbTang.Location = new System.Drawing.Point(136, 344);
            this.slbTang.Margin = new System.Windows.Forms.Padding(0);
            this.slbTang.Name = "slbTang";
            this.slbTang.Size = new System.Drawing.Size(87, 23);
            this.slbTang.TabIndex = 17;
            // 
            // his_LabelX1
            // 
            this.his_LabelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX1.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX1.IsNotNull = false;
            this.his_LabelX1.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX1.Margin = new System.Windows.Forms.Padding(4);
            this.his_LabelX1.Name = "his_LabelX1";
            this.his_LabelX1.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX1.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX1.TabIndex = 0;
            this.his_LabelX1.Text = "Mã:";
            this.his_LabelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            this.his_LabelX1.Visible = false;
            // 
            // his_LabelX2
            // 
            // 
            // 
            // 
            this.his_LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX2.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.his_LabelX2.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX2.IsNotNull = false;
            this.his_LabelX2.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX2.Name = "his_LabelX2";
            this.his_LabelX2.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX2.TabIndex = 3;
            this.his_LabelX2.Text = "labelX1";
            this.his_LabelX2.Visible = false;
            // 
            // lblTen
            // 
            this.lblTen.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTen.ForeColor = System.Drawing.Color.Black;
            this.lblTen.IsNotNull = false;
            this.lblTen.Location = new System.Drawing.Point(0, 0);
            this.lblTen.Margin = new System.Windows.Forms.Padding(4);
            this.lblTen.Name = "lblTen";
            this.lblTen.SingleLineColor = System.Drawing.Color.Black;
            this.lblTen.Size = new System.Drawing.Size(0, 23);
            this.lblTen.TabIndex = 4;
            this.lblTen.Text = "Mã:";
            this.lblTen.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblTen.Visible = false;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.IsNotNull = false;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(0, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "labelX1";
            this.labelX1.Visible = false;
            // 
            // slbGia
            // 
            this.slbGia.DataSource = null;
            this.slbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbGia.his_AddNew = false;
            this.slbGia.his_ColMa = null;
            this.slbGia.his_ColTen = null;
            this.slbGia.his_FontSize = 10F;
            this.slbGia.his_lblText = "Mã:";
            this.slbGia.his_lblTitle1_Bold = false;
            this.slbGia.his_lblTitle1_text = "labelX1";
            this.slbGia.his_lblTitle1_Visible = false;
            this.slbGia.his_lblTitle1_Width = 0;
            this.slbGia.his_lblVisible = false;
            this.slbGia.his_lblWidth = 0;
            this.slbGia.his_ShowCount = 10;
            this.slbGia.his_TabLocation = 0;
            this.slbGia.his_TenReadonly = false;
            this.slbGia.his_TenReadOnly = false;
            this.slbGia.his_TenVisible = true;
            this.slbGia.his_txtWidth = 0;
            this.slbGia.his_XoaMa = true;
            this.slbGia.Location = new System.Drawing.Point(136, 319);
            this.slbGia.Margin = new System.Windows.Forms.Padding(0);
            this.slbGia.Name = "slbGia";
            this.slbGia.Size = new System.Drawing.Size(225, 23);
            this.slbGia.TabIndex = 16;
            // 
            // chkViTriTuDong
            // 
            this.chkViTriTuDong.AutoSize = true;
            this.chkViTriTuDong.Checked = true;
            this.chkViTriTuDong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViTriTuDong.Location = new System.Drawing.Point(136, 299);
            this.chkViTriTuDong.Name = "chkViTriTuDong";
            this.chkViTriTuDong.Size = new System.Drawing.Size(87, 17);
            this.chkViTriTuDong.TabIndex = 15;
            this.chkViTriTuDong.Text = "Vị trí tự dộng";
            this.chkViTriTuDong.UseVisualStyleBackColor = true;
            this.chkViTriTuDong.CheckedChanged += new System.EventHandler(this.chkViTriTuDong_CheckedChanged);
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(367, -18);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(333, 539);
            this.dataGrid2.TabIndex = 311;
            // 
            // dataGrid4
            // 
            this.dataGrid4.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.dataGrid4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid4.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.dataGrid4.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.DataMember = "";
            this.dataGrid4.FlatMode = true;
            this.dataGrid4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid4.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid4.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid4.Location = new System.Drawing.Point(367, 295);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.RowHeaderWidth = 10;
            this.dataGrid4.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.Size = new System.Drawing.Size(333, 226);
            this.dataGrid4.TabIndex = 312;
            this.dataGrid4.CurrentCellChanged += new System.EventHandler(this.dataGrid4_CurrentCellChanged);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(26, 46);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(109, 23);
            this.label23.TabIndex = 256;
            this.label23.Text = "- Số tờ chăm sóc :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(226, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 19);
            this.label13.TabIndex = 255;
            this.label13.Text = "tờ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chamsoc
            // 
            this.chamsoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chamsoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chamsoc.Location = new System.Drawing.Point(136, 49);
            this.chamsoc.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.chamsoc.Name = "chamsoc";
            this.chamsoc.Size = new System.Drawing.Size(83, 21);
            this.chamsoc.TabIndex = 2;
            this.chamsoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chamsoc.Enter += new System.EventHandler(this.chamsoc_Enter);
            this.chamsoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.chamsoc.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // ylenh
            // 
            this.ylenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ylenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ylenh.Location = new System.Drawing.Point(136, 27);
            this.ylenh.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ylenh.Name = "ylenh";
            this.ylenh.Size = new System.Drawing.Size(83, 21);
            this.ylenh.TabIndex = 1;
            this.ylenh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ylenh.Enter += new System.EventHandler(this.ylenh_Enter);
            this.ylenh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.ylenh.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(226, 27);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(24, 20);
            this.label60.TabIndex = 253;
            this.label60.Text = "tờ";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(26, 24);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(112, 23);
            this.label61.TabIndex = 251;
            this.label61.Text = "- Số tờ điều trị :";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mri
            // 
            this.mri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mri.Location = new System.Drawing.Point(136, 115);
            this.mri.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.mri.Name = "mri";
            this.mri.Size = new System.Drawing.Size(83, 21);
            this.mri.TabIndex = 5;
            this.mri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mri.Enter += new System.EventHandler(this.mri_Enter);
            this.mri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.mri.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(226, 115);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(54, 22);
            this.label58.TabIndex = 250;
            this.label58.Text = "phim";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(26, 115);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(112, 23);
            this.label59.TabIndex = 248;
            this.label59.Text = "- MRI :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkzum
            // 
            this.chkzum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkzum.AutoSize = true;
            this.chkzum.Checked = true;
            this.chkzum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkzum.Location = new System.Drawing.Point(3, 506);
            this.chkzum.Name = "chkzum";
            this.chkzum.Size = new System.Drawing.Size(212, 17);
            this.chkzum.TabIndex = 247;
            this.chkzum.Text = "Toàn bộ hồ sơ bằng các hồ sơ cộng lại";
            this.chkzum.UseVisualStyleBackColor = true;
            this.chkzum.CheckedChanged += new System.EventHandler(this.chkzum_CheckedChanged);
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.Color.White;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.FormattingEnabled = true;
            this.makho.Location = new System.Drawing.Point(136, 369);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(225, 21);
            this.makho.TabIndex = 20;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(26, 366);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(112, 23);
            this.label56.TabIndex = 246;
            this.label56.Text = "- Lưu tại :";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkTainan
            // 
            this.chkTainan.Enabled = false;
            this.chkTainan.Location = new System.Drawing.Point(136, 392);
            this.chkTainan.Name = "chkTainan";
            this.chkTainan.Size = new System.Drawing.Size(135, 17);
            this.chkTainan.TabIndex = 21;
            this.chkTainan.Text = "Tai nạn";
            this.chkTainan.UseVisualStyleBackColor = true;
            this.chkTainan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(226, 159);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(24, 19);
            this.label49.TabIndex = 14;
            this.label49.Text = "tờ";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdt
            // 
            this.txtdt.BackColor = System.Drawing.Color.White;
            this.txtdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdt.Location = new System.Drawing.Point(136, 159);
            this.txtdt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtdt.Name = "txtdt";
            this.txtdt.Size = new System.Drawing.Size(83, 21);
            this.txtdt.TabIndex = 7;
            this.txtdt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdt.Enter += new System.EventHandler(this.txtdt_Enter);
            this.txtdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtdt.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(26, 159);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(112, 23);
            this.label48.TabIndex = 12;
            this.label48.Text = "- Điện tim :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chktudongtang
            // 
            this.chktudongtang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chktudongtang.AutoSize = true;
            this.chktudongtang.Checked = true;
            this.chktudongtang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chktudongtang.Location = new System.Drawing.Point(225, 506);
            this.chktudongtang.Name = "chktudongtang";
            this.chktudongtang.Size = new System.Drawing.Size(135, 17);
            this.chktudongtang.TabIndex = 245;
            this.chktudongtang.Text = "Số lưu trữ tăng tự động";
            this.chktudongtang.UseVisualStyleBackColor = true;
            this.chktudongtang.CheckedChanged += new System.EventHandler(this.chktudongtang_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngày nhập bệnh án :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label31.Location = new System.Drawing.Point(8, 299);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(44, 23);
            this.label31.TabIndex = 30;
            this.label31.Text = "Vị trí : ";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label31.Click += new System.EventHandler(this.label31_Click);
            // 
            // txtkhac
            // 
            this.txtkhac.BackColor = System.Drawing.Color.White;
            this.txtkhac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkhac.Location = new System.Drawing.Point(136, 203);
            this.txtkhac.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtkhac.Name = "txtkhac";
            this.txtkhac.Size = new System.Drawing.Size(83, 21);
            this.txtkhac.TabIndex = 9;
            this.txtkhac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtkhac.Enter += new System.EventHandler(this.txtkhac_Enter);
            this.txtkhac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtkhac.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // txtxn
            // 
            this.txtxn.BackColor = System.Drawing.Color.White;
            this.txtxn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxn.Location = new System.Drawing.Point(136, 181);
            this.txtxn.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtxn.Name = "txtxn";
            this.txtxn.Size = new System.Drawing.Size(83, 21);
            this.txtxn.TabIndex = 8;
            this.txtxn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtxn.Enter += new System.EventHandler(this.txtxn_Enter);
            this.txtxn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtxn.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // txtsa
            // 
            this.txtsa.BackColor = System.Drawing.Color.White;
            this.txtsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsa.Location = new System.Drawing.Point(136, 137);
            this.txtsa.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtsa.Name = "txtsa";
            this.txtsa.Size = new System.Drawing.Size(83, 21);
            this.txtsa.TabIndex = 6;
            this.txtsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsa.Enter += new System.EventHandler(this.txtsa_Enter);
            this.txtsa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtsa.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // txtct
            // 
            this.txtct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtct.Location = new System.Drawing.Point(136, 93);
            this.txtct.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtct.Name = "txtct";
            this.txtct.Size = new System.Drawing.Size(83, 21);
            this.txtct.TabIndex = 4;
            this.txtct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtct.Enter += new System.EventHandler(this.txtct_Enter);
            this.txtct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtct.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // txtxq
            // 
            this.txtxq.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtxq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxq.Location = new System.Drawing.Point(136, 71);
            this.txtxq.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtxq.Name = "txtxq";
            this.txtxq.Size = new System.Drawing.Size(83, 21);
            this.txtxq.TabIndex = 3;
            this.txtxq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtxq.Enter += new System.EventHandler(this.txtxq_Enter);
            this.txtxq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtxq.Validated += new System.EventHandler(this.txtxq_Validated);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(3, 392);
            this.listBS.MatchBufferTimeOut = 1000D;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 244;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // txtmann
            // 
            this.txtmann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmann.Enabled = false;
            this.txtmann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmann.Location = new System.Drawing.Point(136, 273);
            this.txtmann.Name = "txtmann";
            this.txtmann.Size = new System.Drawing.Size(48, 21);
            this.txtmann.TabIndex = 13;
            this.txtmann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtmann.Validated += new System.EventHandler(this.txtmann_Validated);
            // 
            // txtmang
            // 
            this.txtmang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmang.Enabled = false;
            this.txtmang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmang.Location = new System.Drawing.Point(136, 250);
            this.txtmang.Name = "txtmang";
            this.txtmang.Size = new System.Drawing.Size(48, 21);
            this.txtmang.TabIndex = 11;
            this.txtmang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtmang.Validated += new System.EventHandler(this.txtmang_Validated);
            // 
            // txtnguoinhan
            // 
            this.txtnguoinhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtnguoinhan.Enabled = false;
            this.txtnguoinhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnguoinhan.Location = new System.Drawing.Point(185, 273);
            this.txtnguoinhan.Name = "txtnguoinhan";
            this.txtnguoinhan.Size = new System.Drawing.Size(176, 21);
            this.txtnguoinhan.TabIndex = 14;
            this.txtnguoinhan.TextChanged += new System.EventHandler(this.txtnguoinhan_TextChanged);
            this.txtnguoinhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnguoigiao_KeyDown);
            // 
            // txtnguoigiao
            // 
            this.txtnguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtnguoigiao.Enabled = false;
            this.txtnguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnguoigiao.Location = new System.Drawing.Point(185, 250);
            this.txtnguoigiao.Name = "txtnguoigiao";
            this.txtnguoigiao.Size = new System.Drawing.Size(176, 21);
            this.txtnguoigiao.TabIndex = 12;
            this.txtnguoigiao.TextChanged += new System.EventHandler(this.txtnguoigiao_TextChanged);
            this.txtnguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnguoigiao_KeyDown);
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(26, 273);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(112, 23);
            this.label27.TabIndex = 27;
            this.label27.Text = "- Người nhận hồ sơ :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(26, 250);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(112, 23);
            this.label26.TabIndex = 24;
            this.label26.Text = "- Người giao hồ sơ :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(226, 203);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 20);
            this.label24.TabIndex = 20;
            this.label24.Text = "tờ";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(226, 181);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(24, 20);
            this.label25.TabIndex = 17;
            this.label25.Text = "tờ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(226, 137);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 19);
            this.label22.TabIndex = 11;
            this.label22.Text = "tờ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(226, 93);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 21);
            this.label21.TabIndex = 8;
            this.label21.Text = "phim";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(226, 71);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 20);
            this.label20.TabIndex = 5;
            this.label20.Text = "phim";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txthoso
            // 
            this.txthoso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txthoso.Enabled = false;
            this.txthoso.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoso.Location = new System.Drawing.Point(136, 225);
            this.txthoso.Name = "txthoso";
            this.txthoso.Size = new System.Drawing.Size(83, 23);
            this.txthoso.TabIndex = 10;
            this.txthoso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txthoso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(26, 225);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 23);
            this.label19.TabIndex = 21;
            this.label19.Text = "- Toàn bộ hồ sơ :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(26, 203);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 23);
            this.label18.TabIndex = 18;
            this.label18.Text = "- Khác :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(26, 181);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 23);
            this.label17.TabIndex = 15;
            this.label17.Text = "- Xét nghiệm :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(26, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 23);
            this.label16.TabIndex = 9;
            this.label16.Text = "- Siêu âm :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(26, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 23);
            this.label15.TabIndex = 6;
            this.label15.Text = "- CT Scanner";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(26, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 23);
            this.label14.TabIndex = 3;
            this.label14.Text = "- X Quang :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtvitri
            // 
            this.txtvitri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtvitri.Enabled = false;
            this.txtvitri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvitri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtvitri.Location = new System.Drawing.Point(136, 415);
            this.txtvitri.Name = "txtvitri";
            this.txtvitri.Size = new System.Drawing.Size(225, 23);
            this.txtvitri.TabIndex = 15;
            this.txtvitri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtvitri.Visible = false;
            this.txtvitri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(70, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Giá :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txto
            // 
            this.txto.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txto.Enabled = false;
            this.txto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txto.Location = new System.Drawing.Point(222, 440);
            this.txto.Name = "txto";
            this.txto.Size = new System.Drawing.Size(56, 23);
            this.txto.TabIndex = 17;
            this.txto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txto.Visible = false;
            this.txto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txto_KeyDown);
            // 
            // txttang
            // 
            this.txttang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttang.Enabled = false;
            this.txttang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttang.Location = new System.Drawing.Point(136, 440);
            this.txttang.Name = "txttang";
            this.txttang.Size = new System.Drawing.Size(50, 23);
            this.txttang.TabIndex = 16;
            this.txttang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttang.Visible = false;
            this.txttang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // ngaynhan
            // 
            this.ngaynhan.CalendarMonthBackground = System.Drawing.Color.White;
            this.ngaynhan.CustomFormat = "dd/MM/yyyy HH:mm";
            this.ngaynhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaynhan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaynhan.Location = new System.Drawing.Point(136, 5);
            this.ngaynhan.Name = "ngaynhan";
            this.ngaynhan.Size = new System.Drawing.Size(225, 21);
            this.ngaynhan.TabIndex = 0;
            this.ngaynhan.Value = new System.DateTime(2017, 12, 28, 14, 48, 37, 0);
            this.ngaynhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngaynhan_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(86, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 23);
            this.label11.TabIndex = 33;
            this.label11.Text = "Tầng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(228, 344);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 23);
            this.label12.TabIndex = 35;
            this.label12.Text = "Ô:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.tabPage2.Controls.Add(this.chktraba);
            this.tabPage2.Controls.Add(this.ngaymuon);
            this.tabPage2.Controls.Add(this.listBS1);
            this.tabPage2.Controls.Add(this.txtghichu);
            this.tabPage2.Controls.Add(this.ngaytra);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tenbs);
            this.tabPage2.Controls.Add(this.mabs);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.dataGrid1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(703, 526);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mượn & trả hồ sơ";
            // 
            // chktraba
            // 
            this.chktraba.Location = new System.Drawing.Point(70, 33);
            this.chktraba.Name = "chktraba";
            this.chktraba.Size = new System.Drawing.Size(104, 19);
            this.chktraba.TabIndex = 4;
            this.chktraba.Text = "Trả Bệnh án";
            this.chktraba.Click += new System.EventHandler(this.chktraba_Click);
            this.chktraba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // ngaymuon
            // 
            this.ngaymuon.CustomFormat = "dd/MM/yyyy HH:MM";
            this.ngaymuon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaymuon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaymuon.Location = new System.Drawing.Point(70, 8);
            this.ngaymuon.Name = "ngaymuon";
            this.ngaymuon.Size = new System.Drawing.Size(125, 21);
            this.ngaymuon.TabIndex = 0;
            this.ngaymuon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // listBS1
            // 
            this.listBS1.BackColor = System.Drawing.SystemColors.Info;
            this.listBS1.ColumnCount = 0;
            this.listBS1.Location = new System.Drawing.Point(16, 312);
            this.listBS1.MatchBufferTimeOut = 1000D;
            this.listBS1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS1.Name = "listBS1";
            this.listBS1.Size = new System.Drawing.Size(75, 17);
            this.listBS1.TabIndex = 245;
            this.listBS1.TextIndex = -1;
            this.listBS1.TextMember = null;
            this.listBS1.ValueIndex = -1;
            this.listBS1.Visible = false;
            // 
            // txtghichu
            // 
            this.txtghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtghichu.Enabled = false;
            this.txtghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtghichu.Location = new System.Drawing.Point(545, 8);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(156, 21);
            this.txtghichu.TabIndex = 3;
            this.txtghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtghichu_KeyDown);
            // 
            // ngaytra
            // 
            this.ngaytra.CustomFormat = "dd/MM/yyyy HH:MM";
            this.ngaytra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaytra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaytra.Location = new System.Drawing.Point(267, 31);
            this.ngaytra.Name = "ngaytra";
            this.ngaytra.Size = new System.Drawing.Size(225, 21);
            this.ngaytra.TabIndex = 5;
            this.ngaytra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngaytra_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(211, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 24);
            this.label9.TabIndex = 59;
            this.label9.Text = "Ngày trả :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(308, 8);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(184, 21);
            this.tenbs.TabIndex = 2;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown_1);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mabs.Location = new System.Drawing.Point(267, 8);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(40, 21);
            this.mabs.TabIndex = 1;
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(195, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 55;
            this.label3.Text = "Người mượn :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 24);
            this.label8.TabIndex = 58;
            this.label8.Text = "Ngày mượn";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(496, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 23);
            this.label6.TabIndex = 62;
            this.label6.Text = "Ghi chú :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 35);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(691, 488);
            this.dataGrid1.TabIndex = 6;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.tabPage4.Controls.Add(this.slbO1);
            this.tabPage4.Controls.Add(this.slbTang1);
            this.tabPage4.Controls.Add(this.slbGia1);
            this.tabPage4.Controls.Add(this.makhotim);
            this.tabPage4.Controls.Add(this.userid);
            this.tabPage4.Controls.Add(this.chkthieu);
            this.tabPage4.Controls.Add(this.label43);
            this.tabPage4.Controls.Add(this.label65);
            this.tabPage4.Controls.Add(this.timngay);
            this.tabPage4.Controls.Add(this.label64);
            this.tabPage4.Controls.Add(this.diachi);
            this.tabPage4.Controls.Add(this.label63);
            this.tabPage4.Controls.Add(this.label62);
            this.tabPage4.Controls.Add(this.maicd);
            this.tabPage4.Controls.Add(this.label57);
            this.tabPage4.Controls.Add(this.cboTinhtrang);
            this.tabPage4.Controls.Add(this.label52);
            this.tabPage4.Controls.Add(this.cboDoituong);
            this.tabPage4.Controls.Add(this.cboGioitinh_tim);
            this.tabPage4.Controls.Add(this.label51);
            this.tabPage4.Controls.Add(this.label50);
            this.tabPage4.Controls.Add(this.cboKhoa);
            this.tabPage4.Controls.Add(this.denngay);
            this.tabPage4.Controls.Add(this.tungay);
            this.tabPage4.Controls.Add(this.label40);
            this.tabPage4.Controls.Add(this.label37);
            this.tabPage4.Controls.Add(this.ten_t);
            this.tabPage4.Controls.Add(this.label36);
            this.tabPage4.Controls.Add(this.label35);
            this.tabPage4.Controls.Add(this.namsinh_t);
            this.tabPage4.Controls.Add(this.hoten_t);
            this.tabPage4.Controls.Add(this.soluutru_t);
            this.tabPage4.Controls.Add(this.mabn_t);
            this.tabPage4.Controls.Add(this.label33);
            this.tabPage4.Controls.Add(this.label34);
            this.tabPage4.Controls.Add(this.label32);
            this.tabPage4.Controls.Add(this.label41);
            this.tabPage4.Controls.Add(this.label38);
            this.tabPage4.Controls.Add(this.label39);
            this.tabPage4.Controls.Add(this.label42);
            this.tabPage4.Controls.Add(this.lbsobanhapkho);
            this.tabPage4.Controls.Add(this.dataGrid3);
            this.tabPage4.Controls.Add(this.o_t);
            this.tabPage4.Controls.Add(this.tang_t);
            this.tabPage4.Controls.Add(this.gia_t);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(703, 526);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tìm kiếm hồ sơ";
            // 
            // slbO1
            // 
            this.slbO1.Controls.Add(this.object_15083c67_ef79_4a40_a690_ce184f0b10c2);
            this.slbO1.Controls.Add(this.object_26bae368_2a61_457d_995e_33689cd35eb9);
            this.slbO1.Controls.Add(this.his_LabelX9);
            this.slbO1.Controls.Add(this.his_LabelX10);
            this.slbO1.Controls.Add(this.his_LabelX11);
            this.slbO1.Controls.Add(this.his_LabelX12);
            this.slbO1.Controls.Add(this.his_LabelX13);
            this.slbO1.Controls.Add(this.his_LabelX14);
            this.slbO1.DataSource = null;
            this.slbO1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbO1.his_AddNew = false;
            this.slbO1.his_ColMa = null;
            this.slbO1.his_ColTen = null;
            this.slbO1.his_FontSize = 10F;
            this.slbO1.his_lblText = "Mã:";
            this.slbO1.his_lblTitle1_Bold = false;
            this.slbO1.his_lblTitle1_text = "labelX1";
            this.slbO1.his_lblTitle1_Visible = false;
            this.slbO1.his_lblTitle1_Width = 0;
            this.slbO1.his_lblVisible = false;
            this.slbO1.his_lblWidth = 0;
            this.slbO1.his_ShowCount = 10;
            this.slbO1.his_TabLocation = 0;
            this.slbO1.his_TenReadonly = false;
            this.slbO1.his_TenReadOnly = false;
            this.slbO1.his_TenVisible = true;
            this.slbO1.his_txtWidth = 0;
            this.slbO1.his_XoaMa = true;
            this.slbO1.Location = new System.Drawing.Point(508, 34);
            this.slbO1.Margin = new System.Windows.Forms.Padding(0);
            this.slbO1.Name = "slbO1";
            this.slbO1.Size = new System.Drawing.Size(62, 23);
            this.slbO1.TabIndex = 279;
            // 
            // object_15083c67_ef79_4a40_a690_ce184f0b10c2
            // 
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.Dock = System.Windows.Forms.DockStyle.Left;
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.ForeColor = System.Drawing.Color.Black;
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.IsNotNull = false;
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.Location = new System.Drawing.Point(0, 0);
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.Name = "object_15083c67_ef79_4a40_a690_ce184f0b10c2";
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.SingleLineColor = System.Drawing.Color.Black;
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.Size = new System.Drawing.Size(0, 23);
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.TabIndex = 4;
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.Text = "Mã:";
            this.object_15083c67_ef79_4a40_a690_ce184f0b10c2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // object_26bae368_2a61_457d_995e_33689cd35eb9
            // 
            // 
            // 
            // 
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.Dock = System.Windows.Forms.DockStyle.Left;
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.ForeColor = System.Drawing.Color.Black;
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.IsNotNull = false;
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.Location = new System.Drawing.Point(0, 0);
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.Name = "object_26bae368_2a61_457d_995e_33689cd35eb9";
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.Size = new System.Drawing.Size(0, 23);
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.TabIndex = 3;
            this.object_26bae368_2a61_457d_995e_33689cd35eb9.Text = "labelX1";
            // 
            // his_LabelX9
            // 
            this.his_LabelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX9.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX9.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX9.IsNotNull = false;
            this.his_LabelX9.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX9.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.his_LabelX9.Name = "his_LabelX9";
            this.his_LabelX9.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX9.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX9.TabIndex = 0;
            this.his_LabelX9.Text = "Mã:";
            this.his_LabelX9.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // his_LabelX10
            // 
            // 
            // 
            // 
            this.his_LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX10.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.his_LabelX10.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX10.IsNotNull = false;
            this.his_LabelX10.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX10.Name = "his_LabelX10";
            this.his_LabelX10.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX10.TabIndex = 3;
            this.his_LabelX10.Text = "labelX1";
            // 
            // his_LabelX11
            // 
            this.his_LabelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX11.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX11.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX11.IsNotNull = false;
            this.his_LabelX11.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX11.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.his_LabelX11.Name = "his_LabelX11";
            this.his_LabelX11.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX11.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX11.TabIndex = 4;
            this.his_LabelX11.Text = "Mã:";
            this.his_LabelX11.TextAlignment = System.Drawing.StringAlignment.Far;
            this.his_LabelX11.Visible = false;
            // 
            // his_LabelX12
            // 
            // 
            // 
            // 
            this.his_LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX12.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.his_LabelX12.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX12.IsNotNull = false;
            this.his_LabelX12.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX12.Name = "his_LabelX12";
            this.his_LabelX12.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX12.TabIndex = 3;
            this.his_LabelX12.Text = "labelX1";
            this.his_LabelX12.Visible = false;
            // 
            // his_LabelX13
            // 
            this.his_LabelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX13.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX13.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX13.IsNotNull = false;
            this.his_LabelX13.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX13.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.his_LabelX13.Name = "his_LabelX13";
            this.his_LabelX13.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX13.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX13.TabIndex = 4;
            this.his_LabelX13.Text = "Mã:";
            this.his_LabelX13.TextAlignment = System.Drawing.StringAlignment.Far;
            this.his_LabelX13.Visible = false;
            // 
            // his_LabelX14
            // 
            // 
            // 
            // 
            this.his_LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX14.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX14.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX14.IsNotNull = false;
            this.his_LabelX14.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX14.Name = "his_LabelX14";
            this.his_LabelX14.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX14.TabIndex = 3;
            this.his_LabelX14.Text = "labelX1";
            this.his_LabelX14.Visible = false;
            // 
            // slbTang1
            // 
            this.slbTang1.Controls.Add(this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53);
            this.slbTang1.Controls.Add(this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f);
            this.slbTang1.Controls.Add(this.his_LabelX15);
            this.slbTang1.Controls.Add(this.his_LabelX16);
            this.slbTang1.Controls.Add(this.his_LabelX17);
            this.slbTang1.Controls.Add(this.his_LabelX18);
            this.slbTang1.DataSource = null;
            this.slbTang1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbTang1.his_AddNew = false;
            this.slbTang1.his_ColMa = null;
            this.slbTang1.his_ColTen = null;
            this.slbTang1.his_FontSize = 10F;
            this.slbTang1.his_lblText = "Mã:";
            this.slbTang1.his_lblTitle1_Bold = false;
            this.slbTang1.his_lblTitle1_text = "labelX1";
            this.slbTang1.his_lblTitle1_Visible = false;
            this.slbTang1.his_lblTitle1_Width = 0;
            this.slbTang1.his_lblVisible = false;
            this.slbTang1.his_lblWidth = 0;
            this.slbTang1.his_ShowCount = 10;
            this.slbTang1.his_TabLocation = 0;
            this.slbTang1.his_TenReadonly = false;
            this.slbTang1.his_TenReadOnly = false;
            this.slbTang1.his_TenVisible = true;
            this.slbTang1.his_txtWidth = 0;
            this.slbTang1.his_XoaMa = true;
            this.slbTang1.Location = new System.Drawing.Point(405, 33);
            this.slbTang1.Margin = new System.Windows.Forms.Padding(0);
            this.slbTang1.Name = "slbTang1";
            this.slbTang1.Size = new System.Drawing.Size(65, 23);
            this.slbTang1.TabIndex = 278;
            // 
            // object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53
            // 
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.Dock = System.Windows.Forms.DockStyle.Left;
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.ForeColor = System.Drawing.Color.Black;
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.IsNotNull = false;
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.Location = new System.Drawing.Point(0, 0);
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.Margin = new System.Windows.Forms.Padding(4);
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.Name = "object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53";
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.SingleLineColor = System.Drawing.Color.Black;
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.Size = new System.Drawing.Size(0, 23);
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.TabIndex = 4;
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.Text = "Mã:";
            this.object_a64b725e_5fcb_4f4d_8c6b_5a27fde16c53.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f
            // 
            // 
            // 
            // 
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.Dock = System.Windows.Forms.DockStyle.Left;
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.ForeColor = System.Drawing.Color.Black;
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.IsNotNull = false;
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.Location = new System.Drawing.Point(0, 0);
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.Name = "object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f";
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.Size = new System.Drawing.Size(0, 23);
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.TabIndex = 3;
            this.object_8ddd71e0_752a_48f2_b8da_ba3d23c07e9f.Text = "labelX1";
            // 
            // his_LabelX15
            // 
            this.his_LabelX15.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX15.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX15.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX15.IsNotNull = false;
            this.his_LabelX15.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX15.Margin = new System.Windows.Forms.Padding(4);
            this.his_LabelX15.Name = "his_LabelX15";
            this.his_LabelX15.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX15.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX15.TabIndex = 0;
            this.his_LabelX15.Text = "Mã:";
            this.his_LabelX15.TextAlignment = System.Drawing.StringAlignment.Far;
            this.his_LabelX15.Visible = false;
            // 
            // his_LabelX16
            // 
            // 
            // 
            // 
            this.his_LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX16.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.his_LabelX16.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX16.IsNotNull = false;
            this.his_LabelX16.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX16.Name = "his_LabelX16";
            this.his_LabelX16.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX16.TabIndex = 3;
            this.his_LabelX16.Text = "labelX1";
            this.his_LabelX16.Visible = false;
            // 
            // his_LabelX17
            // 
            this.his_LabelX17.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.his_LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX17.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX17.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX17.IsNotNull = false;
            this.his_LabelX17.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX17.Margin = new System.Windows.Forms.Padding(4);
            this.his_LabelX17.Name = "his_LabelX17";
            this.his_LabelX17.SingleLineColor = System.Drawing.Color.Black;
            this.his_LabelX17.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX17.TabIndex = 4;
            this.his_LabelX17.Text = "Mã:";
            this.his_LabelX17.TextAlignment = System.Drawing.StringAlignment.Far;
            this.his_LabelX17.Visible = false;
            // 
            // his_LabelX18
            // 
            // 
            // 
            // 
            this.his_LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.his_LabelX18.Dock = System.Windows.Forms.DockStyle.Left;
            this.his_LabelX18.ForeColor = System.Drawing.Color.Black;
            this.his_LabelX18.IsNotNull = false;
            this.his_LabelX18.Location = new System.Drawing.Point(0, 0);
            this.his_LabelX18.Name = "his_LabelX18";
            this.his_LabelX18.Size = new System.Drawing.Size(0, 23);
            this.his_LabelX18.TabIndex = 3;
            this.his_LabelX18.Text = "his_LabelX18";
            this.his_LabelX18.Visible = false;
            // 
            // slbGia1
            // 
            this.slbGia1.Controls.Add(this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7);
            this.slbGia1.Controls.Add(this.object_7fd77ea2_2310_48f4_be5e_afe030f27697);
            this.slbGia1.Controls.Add(this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd);
            this.slbGia1.Controls.Add(this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954);
            this.slbGia1.DataSource = null;
            this.slbGia1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbGia1.his_AddNew = false;
            this.slbGia1.his_ColMa = null;
            this.slbGia1.his_ColTen = null;
            this.slbGia1.his_FontSize = 10F;
            this.slbGia1.his_lblText = "Mã:";
            this.slbGia1.his_lblTitle1_Bold = false;
            this.slbGia1.his_lblTitle1_text = "labelX1";
            this.slbGia1.his_lblTitle1_Visible = false;
            this.slbGia1.his_lblTitle1_Width = 0;
            this.slbGia1.his_lblVisible = false;
            this.slbGia1.his_lblWidth = 0;
            this.slbGia1.his_ShowCount = 10;
            this.slbGia1.his_TabLocation = 0;
            this.slbGia1.his_TenReadonly = false;
            this.slbGia1.his_TenReadOnly = false;
            this.slbGia1.his_TenVisible = true;
            this.slbGia1.his_txtWidth = 0;
            this.slbGia1.his_XoaMa = true;
            this.slbGia1.Location = new System.Drawing.Point(305, 33);
            this.slbGia1.Margin = new System.Windows.Forms.Padding(0);
            this.slbGia1.Name = "slbGia1";
            this.slbGia1.Size = new System.Drawing.Size(65, 23);
            this.slbGia1.TabIndex = 277;
            // 
            // object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7
            // 
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.Dock = System.Windows.Forms.DockStyle.Left;
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.ForeColor = System.Drawing.Color.Black;
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.IsNotNull = false;
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.Location = new System.Drawing.Point(0, 0);
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.Margin = new System.Windows.Forms.Padding(4);
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.Name = "object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7";
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.SingleLineColor = System.Drawing.Color.Black;
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.Size = new System.Drawing.Size(0, 23);
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.TabIndex = 4;
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.Text = "Mã:";
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.TextAlignment = System.Drawing.StringAlignment.Far;
            this.object_2015ff56_ff69_41d2_aa3c_0b806d44e3b7.Visible = false;
            // 
            // object_7fd77ea2_2310_48f4_be5e_afe030f27697
            // 
            // 
            // 
            // 
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.Dock = System.Windows.Forms.DockStyle.Left;
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.ForeColor = System.Drawing.Color.Black;
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.IsNotNull = false;
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.Location = new System.Drawing.Point(0, 0);
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.Name = "object_7fd77ea2_2310_48f4_be5e_afe030f27697";
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.Size = new System.Drawing.Size(0, 23);
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.TabIndex = 3;
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.Text = "labelX1";
            this.object_7fd77ea2_2310_48f4_be5e_afe030f27697.Visible = false;
            // 
            // object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd
            // 
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.Dock = System.Windows.Forms.DockStyle.Left;
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.ForeColor = System.Drawing.Color.Black;
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.IsNotNull = false;
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.Location = new System.Drawing.Point(0, 0);
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.Margin = new System.Windows.Forms.Padding(4);
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.Name = "object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd";
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.SingleLineColor = System.Drawing.Color.Black;
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.Size = new System.Drawing.Size(0, 23);
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.TabIndex = 4;
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.Text = "Mã:";
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.TextAlignment = System.Drawing.StringAlignment.Far;
            this.object_b5a0e1e8_abeb_4dbb_81dd_f670636779cd.Visible = false;
            // 
            // object_ab5cce97_6a19_40e5_84d8_bc161b27d954
            // 
            // 
            // 
            // 
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.Dock = System.Windows.Forms.DockStyle.Left;
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.ForeColor = System.Drawing.Color.Black;
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.IsNotNull = false;
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.Location = new System.Drawing.Point(0, 0);
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.Name = "object_ab5cce97_6a19_40e5_84d8_bc161b27d954";
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.Size = new System.Drawing.Size(0, 23);
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.TabIndex = 3;
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.Text = "labelX1";
            this.object_ab5cce97_6a19_40e5_84d8_bc161b27d954.Visible = false;
            // 
            // makhotim
            // 
            this.makhotim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.makhotim.BackColor = System.Drawing.Color.White;
            this.makhotim.FormattingEnabled = true;
            this.makhotim.Location = new System.Drawing.Point(508, 82);
            this.makhotim.Name = "makhotim";
            this.makhotim.Size = new System.Drawing.Size(192, 21);
            this.makhotim.TabIndex = 260;
            // 
            // userid
            // 
            this.userid.FormattingEnabled = true;
            this.userid.Items.AddRange(new object[] {
            "Tất cả hồ sơ",
            "Đã nhập kho",
            "Chưa nhập kho"});
            this.userid.Location = new System.Drawing.Point(58, 106);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(192, 21);
            this.userid.TabIndex = 269;
            // 
            // chkthieu
            // 
            this.chkthieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkthieu.AutoSize = true;
            this.chkthieu.Location = new System.Drawing.Point(389, 109);
            this.chkthieu.Name = "chkthieu";
            this.chkthieu.Size = new System.Drawing.Size(124, 17);
            this.chkthieu.TabIndex = 262;
            this.chkthieu.Text = "Hồ sơ thiếu thông tin";
            this.chkthieu.UseVisualStyleBackColor = true;
            // 
            // label43
            // 
            this.label43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(507, 106);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(112, 23);
            this.label43.TabIndex = 250;
            this.label43.Text = "Số BA đã nhập kho :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(-27, 103);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(89, 23);
            this.label65.TabIndex = 268;
            this.label65.Text = "Ng. nhập: ";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timngay
            // 
            this.timngay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timngay.FormattingEnabled = true;
            this.timngay.Items.AddRange(new object[] {
            "Ngày ra viện",
            "Ngày vào viện",
            "Ngày nhận",
            "Ngày nhập liệu"});
            this.timngay.Location = new System.Drawing.Point(305, 106);
            this.timngay.Name = "timngay";
            this.timngay.Size = new System.Drawing.Size(80, 21);
            this.timngay.TabIndex = 267;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(255, 111);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(54, 13);
            this.label64.TabIndex = 266;
            this.label64.Text = "Tìm theo: ";
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(58, 82);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(326, 21);
            this.diachi.TabIndex = 265;
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(-5, 80);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(63, 23);
            this.label63.TabIndex = 264;
            this.label63.Text = "Địa chỉ :";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label62
            // 
            this.label62.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label62.Location = new System.Drawing.Point(464, 82);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(47, 19);
            this.label62.TabIndex = 261;
            this.label62.Text = "Lưu tại :";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(305, 57);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(140, 21);
            this.maicd.TabIndex = 258;
            // 
            // label57
            // 
            this.label57.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label57.Location = new System.Drawing.Point(258, 57);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(51, 23);
            this.label57.TabIndex = 259;
            this.label57.Text = "Mã ICD :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTinhtrang
            // 
            this.cboTinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhtrang.FormattingEnabled = true;
            this.cboTinhtrang.Items.AddRange(new object[] {
            "Tất cả hồ sơ",
            "Đã nhập kho",
            "Chưa nhập kho"});
            this.cboTinhtrang.Location = new System.Drawing.Point(618, 58);
            this.cboTinhtrang.Name = "cboTinhtrang";
            this.cboTinhtrang.Size = new System.Drawing.Size(82, 21);
            this.cboTinhtrang.TabIndex = 256;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(515, 58);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(99, 23);
            this.label52.TabIndex = 257;
            this.label52.Text = "Tình trạng hồ sơ :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDoituong
            // 
            this.cboDoituong.FormattingEnabled = true;
            this.cboDoituong.Location = new System.Drawing.Point(58, 58);
            this.cboDoituong.Name = "cboDoituong";
            this.cboDoituong.Size = new System.Drawing.Size(83, 21);
            this.cboDoituong.TabIndex = 65;
            // 
            // cboGioitinh_tim
            // 
            this.cboGioitinh_tim.FormattingEnabled = true;
            this.cboGioitinh_tim.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioitinh_tim.Location = new System.Drawing.Point(193, 57);
            this.cboGioitinh_tim.Name = "cboGioitinh_tim";
            this.cboGioitinh_tim.Size = new System.Drawing.Size(59, 21);
            this.cboGioitinh_tim.TabIndex = 66;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(131, 56);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(61, 23);
            this.label51.TabIndex = 255;
            this.label51.Text = "Giới tính :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(-5, 58);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(63, 23);
            this.label50.TabIndex = 253;
            this.label50.Text = "Đối tượng :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboKhoa
            // 
            this.cboKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(618, 34);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(82, 21);
            this.cboKhoa.TabIndex = 64;
            // 
            // denngay
            // 
            this.denngay.Location = new System.Drawing.Point(169, 11);
            this.denngay.Masked = MaskedTextBox.MaskedTextBox.Mask.DateOnly;
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(83, 20);
            this.denngay.TabIndex = 1;
            // 
            // tungay
            // 
            this.tungay.Location = new System.Drawing.Point(58, 11);
            this.tungay.Masked = MaskedTextBox.MaskedTextBox.Mask.DateOnly;
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(83, 20);
            this.tungay.TabIndex = 0;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(0, 11);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(58, 23);
            this.label40.TabIndex = 12;
            this.label40.Text = "Từ ngày :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(469, 34);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 23);
            this.label37.TabIndex = 21;
            this.label37.Text = "Ô:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten_t
            // 
            this.ten_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten_t.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten_t.Location = new System.Drawing.Point(58, 34);
            this.ten_t.Name = "ten_t";
            this.ten_t.Size = new System.Drawing.Size(83, 21);
            this.ten_t.TabIndex = 5;
            this.ten_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(2, 33);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(56, 23);
            this.label36.TabIndex = 17;
            this.label36.Text = "Tên :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(144, 34);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 23);
            this.label35.TabIndex = 18;
            this.label35.Text = "N.Sinh :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh_t
            // 
            this.namsinh_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh_t.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh_t.Location = new System.Drawing.Point(193, 34);
            this.namsinh_t.Name = "namsinh_t";
            this.namsinh_t.Size = new System.Drawing.Size(59, 21);
            this.namsinh_t.TabIndex = 6;
            this.namsinh_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // hoten_t
            // 
            this.hoten_t.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hoten_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten_t.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten_t.Location = new System.Drawing.Point(618, 11);
            this.hoten_t.Name = "hoten_t";
            this.hoten_t.Size = new System.Drawing.Size(82, 21);
            this.hoten_t.TabIndex = 4;
            this.hoten_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // soluutru_t
            // 
            this.soluutru_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru_t.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru_t.Location = new System.Drawing.Point(305, 11);
            this.soluutru_t.Name = "soluutru_t";
            this.soluutru_t.Size = new System.Drawing.Size(111, 21);
            this.soluutru_t.TabIndex = 2;
            this.soluutru_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // mabn_t
            // 
            this.mabn_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn_t.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn_t.Location = new System.Drawing.Point(469, 11);
            this.mabn_t.MaxLength = 8;
            this.mabn_t.Name = "mabn_t";
            this.mabn_t.Size = new System.Drawing.Size(101, 21);
            this.mabn_t.TabIndex = 3;
            this.mabn_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(573, 11);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 23);
            this.label33.TabIndex = 16;
            this.label33.Text = "Họ tên";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(242, 11);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(67, 23);
            this.label34.TabIndex = 14;
            this.label34.Text = "Số lưu trữ :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(413, 11);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(48, 23);
            this.label32.TabIndex = 15;
            this.label32.Text = "Mã BN";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(131, 11);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(40, 23);
            this.label41.TabIndex = 13;
            this.label41.Text = "đến :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(368, 34);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(40, 23);
            this.label38.TabIndex = 20;
            this.label38.Text = "Tầng :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(253, 35);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 23);
            this.label39.TabIndex = 19;
            this.label39.Text = "Giá :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(573, 34);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 23);
            this.label42.TabIndex = 63;
            this.label42.Text = "Khoa :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbsobanhapkho
            // 
            this.lbsobanhapkho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbsobanhapkho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsobanhapkho.ForeColor = System.Drawing.Color.Red;
            this.lbsobanhapkho.Location = new System.Drawing.Point(615, 105);
            this.lbsobanhapkho.Name = "lbsobanhapkho";
            this.lbsobanhapkho.Size = new System.Drawing.Size(85, 23);
            this.lbsobanhapkho.TabIndex = 251;
            this.lbsobanhapkho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGrid3
            // 
            this.dataGrid3.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid3.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.dataGrid3.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.DataMember = "";
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid3.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid3.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid3.Location = new System.Drawing.Point(8, 112);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.RowHeaderWidth = 5;
            this.dataGrid3.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.Size = new System.Drawing.Size(691, 410);
            this.dataGrid3.TabIndex = 62;
            this.dataGrid3.CurrentCellChanged += new System.EventHandler(this.dataGrid3_CurrentCellChanged);
            this.dataGrid3.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid3_Navigate);
            this.dataGrid3.Click += new System.EventHandler(this.dataGrid3_Click);
            // 
            // o_t
            // 
            this.o_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.o_t.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o_t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.o_t.Location = new System.Drawing.Point(161, 152);
            this.o_t.Name = "o_t";
            this.o_t.Size = new System.Drawing.Size(64, 23);
            this.o_t.TabIndex = 9;
            this.o_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.o_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // tang_t
            // 
            this.tang_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tang_t.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tang_t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tang_t.Location = new System.Drawing.Point(89, 152);
            this.tang_t.Name = "tang_t";
            this.tang_t.Size = new System.Drawing.Size(66, 23);
            this.tang_t.TabIndex = 8;
            this.tang_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tang_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // gia_t
            // 
            this.gia_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gia_t.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia_t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gia_t.Location = new System.Drawing.Point(24, 152);
            this.gia_t.Name = "gia_t";
            this.gia_t.Size = new System.Drawing.Size(55, 23);
            this.gia_t.TabIndex = 7;
            this.gia_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gia_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // butTim
            // 
            this.butTim.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butTim.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butTim.BackColor = System.Drawing.Color.Transparent;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.Location = new System.Drawing.Point(627, 701);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(63, 25);
            this.butTim.TabIndex = 10;
            this.butTim.Text = "&Tìm";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            this.butTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(292, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtsoluutru
            // 
            this.txtsoluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtsoluutru.Enabled = false;
            this.txtsoluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoluutru.Location = new System.Drawing.Point(564, 120);
            this.txtsoluutru.Name = "txtsoluutru";
            this.txtsoluutru.Size = new System.Drawing.Size(88, 21);
            this.txtsoluutru.TabIndex = 30;
            this.txtsoluutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluutru_KeyDown);
            this.txtsoluutru.Validated += new System.EventHandler(this.txtsoluutru_Validated);
            // 
            // txtmabn2
            // 
            this.txtmabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmabn2.Enabled = false;
            this.txtmabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabn2.Location = new System.Drawing.Point(340, 5);
            this.txtmabn2.MaxLength = 8;
            this.txtmabn2.Name = "txtmabn2";
            this.txtmabn2.Size = new System.Drawing.Size(70, 21);
            this.txtmabn2.TabIndex = 3;
            this.txtmabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn2_KeyDown);
            this.txtmabn2.Validated += new System.EventHandler(this.txtmabn2_Validated);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(416, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(499, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "Số lưu trữ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txthoten
            // 
            this.txthoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txthoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txthoten.Enabled = false;
            this.txthoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoten.Location = new System.Drawing.Point(463, 5);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(306, 21);
            this.txthoten.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Năm sinh :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnamsinh
            // 
            this.txtnamsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtnamsinh.Enabled = false;
            this.txtnamsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnamsinh.Location = new System.Drawing.Point(81, 28);
            this.txtnamsinh.Name = "txtnamsinh";
            this.txtnamsinh.Size = new System.Drawing.Size(58, 21);
            this.txtnamsinh.TabIndex = 7;
            // 
            // lblPhai
            // 
            this.lblPhai.Location = new System.Drawing.Point(137, 28);
            this.lblPhai.Name = "lblPhai";
            this.lblPhai.Size = new System.Drawing.Size(62, 23);
            this.lblPhai.TabIndex = 8;
            this.lblPhai.Text = "Giới tính :";
            this.lblPhai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txttinhtranghoso
            // 
            this.txttinhtranghoso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttinhtranghoso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttinhtranghoso.Enabled = false;
            this.txttinhtranghoso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttinhtranghoso.Location = new System.Drawing.Point(340, 28);
            this.txttinhtranghoso.Name = "txttinhtranghoso";
            this.txttinhtranghoso.Size = new System.Drawing.Size(714, 21);
            this.txttinhtranghoso.TabIndex = 11;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(244, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 23);
            this.label29.TabIndex = 10;
            this.label29.Text = "Tình trạng hồ sơ :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(2, 74);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 23);
            this.label30.TabIndex = 17;
            this.label30.Text = "Ngày ra viện :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label30.DoubleClick += new System.EventHandler(this.label30_DoubleClick);
            // 
            // txttsbanam
            // 
            this.txttsbanam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttsbanam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttsbanam.ForeColor = System.Drawing.Color.Red;
            this.txttsbanam.Location = new System.Drawing.Point(995, 116);
            this.txttsbanam.Name = "txttsbanam";
            this.txttsbanam.Size = new System.Drawing.Size(59, 24);
            this.txttsbanam.TabIndex = 249;
            this.txttsbanam.Text = "0/06";
            this.txttsbanam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(920, 116);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(81, 24);
            this.label28.TabIndex = 79;
            this.label28.Text = "Tổng số BA :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboGioitinh
            // 
            this.cboGioitinh.Enabled = false;
            this.cboGioitinh.FormattingEnabled = true;
            this.cboGioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioitinh.Location = new System.Drawing.Point(187, 28);
            this.cboGioitinh.Name = "cboGioitinh";
            this.cboGioitinh.Size = new System.Drawing.Size(44, 21);
            this.cboGioitinh.TabIndex = 9;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(25, 5);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(56, 23);
            this.label44.TabIndex = 0;
            this.label44.Text = "Bệnh án :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbobenhan
            // 
            this.cbobenhan.BackColor = System.Drawing.Color.White;
            this.cbobenhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobenhan.DropDownWidth = 150;
            this.cbobenhan.FormattingEnabled = true;
            this.cbobenhan.Items.AddRange(new object[] {
            "Nội trú",
            "Ngoại trú",
            "Phòng lưu",
            "Tử vong trước nhập viện",
            "Tử vong sau nhập viện",
            "Phòng khám"});
            this.cbobenhan.Location = new System.Drawing.Point(81, 5);
            this.cbobenhan.Name = "cbobenhan";
            this.cbobenhan.Size = new System.Drawing.Size(150, 21);
            this.cbobenhan.TabIndex = 1;
            this.cbobenhan.SelectedIndexChanged += new System.EventHandler(this.cbobenhan_SelectedIndexChanged);
            this.cbobenhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbobenhan_KeyDown);
            this.cbobenhan.Validated += new System.EventHandler(this.cbobenhan_Validated);
            // 
            // cbongayvao
            // 
            this.cbongayvao.BackColor = System.Drawing.Color.White;
            this.cbongayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbongayvao.FormattingEnabled = true;
            this.cbongayvao.Location = new System.Drawing.Point(81, 51);
            this.cbongayvao.Name = "cbongayvao";
            this.cbongayvao.Size = new System.Drawing.Size(150, 21);
            this.cbongayvao.TabIndex = 13;
            this.cbongayvao.SelectedIndexChanged += new System.EventHandler(this.cbongayvao_SelectedIndexChanged);
            this.cbongayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbongayvao_KeyDown);
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(-24, 52);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(105, 23);
            this.label45.TabIndex = 12;
            this.label45.Text = "Ngày vào viện :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(225, 51);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(116, 23);
            this.label46.TabIndex = 14;
            this.label46.Text = "Chẩn đoán vào viện :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maicd_vao
            // 
            this.maicd_vao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd_vao.Enabled = false;
            this.maicd_vao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd_vao.Location = new System.Drawing.Point(340, 51);
            this.maicd_vao.MaxLength = 6;
            this.maicd_vao.Name = "maicd_vao";
            this.maicd_vao.Size = new System.Drawing.Size(59, 21);
            this.maicd_vao.TabIndex = 15;
            // 
            // icd_vao
            // 
            this.icd_vao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icd_vao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_vao.Enabled = false;
            this.icd_vao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_vao.Location = new System.Drawing.Point(401, 51);
            this.icd_vao.Name = "icd_vao";
            this.icd_vao.Size = new System.Drawing.Size(654, 21);
            this.icd_vao.TabIndex = 16;
            // 
            // icd_ravien
            // 
            this.icd_ravien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icd_ravien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_ravien.Enabled = false;
            this.icd_ravien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_ravien.Location = new System.Drawing.Point(401, 74);
            this.icd_ravien.Name = "icd_ravien";
            this.icd_ravien.Size = new System.Drawing.Size(654, 21);
            this.icd_ravien.TabIndex = 21;
            // 
            // maicd_ravien
            // 
            this.maicd_ravien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd_ravien.Enabled = false;
            this.maicd_ravien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd_ravien.Location = new System.Drawing.Point(340, 74);
            this.maicd_ravien.MaxLength = 6;
            this.maicd_ravien.Name = "maicd_ravien";
            this.maicd_ravien.Size = new System.Drawing.Size(59, 21);
            this.maicd_ravien.TabIndex = 20;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(225, 73);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(116, 23);
            this.label47.TabIndex = 19;
            this.label47.Text = "Chẩn đoán ra viện :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayravien
            // 
            this.ngayravien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayravien.Enabled = false;
            this.ngayravien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayravien.Location = new System.Drawing.Point(81, 74);
            this.ngayravien.Name = "ngayravien";
            this.ngayravien.Size = new System.Drawing.Size(150, 21);
            this.ngayravien.TabIndex = 18;
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(2, 97);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(79, 23);
            this.label53.TabIndex = 22;
            this.label53.Text = "Kết quả :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(271, 117);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(68, 23);
            this.label54.TabIndex = 27;
            this.label54.Text = "Tình trạng :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboKetqua
            // 
            this.cboKetqua.BackColor = System.Drawing.Color.White;
            this.cboKetqua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKetqua.Enabled = false;
            this.cboKetqua.FormattingEnabled = true;
            this.cboKetqua.Location = new System.Drawing.Point(81, 97);
            this.cboKetqua.Name = "cboKetqua";
            this.cboKetqua.Size = new System.Drawing.Size(150, 21);
            this.cboKetqua.TabIndex = 23;
            // 
            // cboTtLucrv
            // 
            this.cboTtLucrv.BackColor = System.Drawing.Color.White;
            this.cboTtLucrv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTtLucrv.Enabled = false;
            this.cboTtLucrv.FormattingEnabled = true;
            this.cboTtLucrv.Location = new System.Drawing.Point(340, 120);
            this.cboTtLucrv.Name = "cboTtLucrv";
            this.cboTtLucrv.Size = new System.Drawing.Size(159, 21);
            this.cboTtLucrv.TabIndex = 28;
            // 
            // butMoi
            // 
            this.butMoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butMoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.Location = new System.Drawing.Point(295, 701);
            this.butMoi.Name = "butMoi";
            this.butMoi.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.butMoi.Size = new System.Drawing.Size(76, 25);
            this.butMoi.TabIndex = 263;
            this.butMoi.Text = "Mới (F3)";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butSua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.Location = new System.Drawing.Point(372, 701);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 264;
            this.butSua.Text = "Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butLuu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.Location = new System.Drawing.Point(433, 701);
            this.butLuu.Name = "butLuu";
            this.butLuu.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.butLuu.Size = new System.Drawing.Size(71, 25);
            this.butLuu.TabIndex = 265;
            this.butLuu.Text = "Lưu (F6)";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butBoqua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.Location = new System.Drawing.Point(505, 701);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 266;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butHuy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.Location = new System.Drawing.Point(566, 701);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 267;
            this.butHuy.Text = "Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.Location = new System.Drawing.Point(691, 701);
            this.butIn.Name = "butIn";
            this.butIn.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 265;
            this.butIn.Text = "In (F9)";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butKetthuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.Location = new System.Drawing.Point(752, 701);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 268;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // icd_nn
            // 
            this.icd_nn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icd_nn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_nn.Enabled = false;
            this.icd_nn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_nn.Location = new System.Drawing.Point(401, 97);
            this.icd_nn.Name = "icd_nn";
            this.icd_nn.Size = new System.Drawing.Size(654, 21);
            this.icd_nn.TabIndex = 26;
            // 
            // maicd_nn
            // 
            this.maicd_nn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd_nn.Enabled = false;
            this.maicd_nn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd_nn.Location = new System.Drawing.Point(340, 97);
            this.maicd_nn.MaxLength = 6;
            this.maicd_nn.Name = "maicd_nn";
            this.maicd_nn.Size = new System.Drawing.Size(59, 21);
            this.maicd_nn.TabIndex = 25;
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(240, 95);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(100, 23);
            this.label55.TabIndex = 24;
            this.label55.Text = "CĐ nguyên nhân :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblmakp
            // 
            this.lblmakp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblmakp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmakp.ForeColor = System.Drawing.Color.Red;
            this.lblmakp.Location = new System.Drawing.Point(775, 10);
            this.lblmakp.Name = "lblmakp";
            this.lblmakp.Size = new System.Drawing.Size(276, 13);
            this.lblmakp.TabIndex = 272;
            this.lblmakp.Text = "Khoa xuất";
            this.lblmakp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // his_Panel1
            // 
            this.his_Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.his_Panel1.Controls.Add(this.groupPanel1);
            this.his_Panel1.Controls.Add(this.dgvMain);
            this.his_Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.his_Panel1.Location = new System.Drawing.Point(0, 138);
            this.his_Panel1.Name = "his_Panel1";
            this.his_Panel1.Size = new System.Drawing.Size(341, 561);
            this.his_Panel1.TabIndex = 273;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.slbKhoaPhong);
            this.groupPanel1.Controls.Add(this.radDaNhan);
            this.groupPanel1.Controls.Add(this.txtTimKiem);
            this.groupPanel1.Controls.Add(this.radChuaNhan);
            this.groupPanel1.Controls.Add(this.label66);
            this.groupPanel1.Controls.Add(this.lblKQ);
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(338, 98);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 6;
            this.groupPanel1.Text = "Tìm kiếm nhanh";
            // 
            // slbKhoaPhong
            // 
            this.slbKhoaPhong.DataSource = null;
            this.slbKhoaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.slbKhoaPhong.his_AddNew = false;
            this.slbKhoaPhong.his_ColMa = null;
            this.slbKhoaPhong.his_ColTen = null;
            this.slbKhoaPhong.his_FontSize = 10F;
            this.slbKhoaPhong.his_lblText = "Mã:";
            this.slbKhoaPhong.his_lblTitle1_Bold = false;
            this.slbKhoaPhong.his_lblTitle1_text = "labelX1";
            this.slbKhoaPhong.his_lblTitle1_Visible = false;
            this.slbKhoaPhong.his_lblTitle1_Width = 0;
            this.slbKhoaPhong.his_lblVisible = false;
            this.slbKhoaPhong.his_lblWidth = 0;
            this.slbKhoaPhong.his_ShowCount = 10;
            this.slbKhoaPhong.his_TabLocation = 0;
            this.slbKhoaPhong.his_TenReadonly = false;
            this.slbKhoaPhong.his_TenReadOnly = false;
            this.slbKhoaPhong.his_TenVisible = true;
            this.slbKhoaPhong.his_txtWidth = 0;
            this.slbKhoaPhong.his_XoaMa = true;
            this.slbKhoaPhong.Location = new System.Drawing.Point(77, 4);
            this.slbKhoaPhong.Margin = new System.Windows.Forms.Padding(0);
            this.slbKhoaPhong.Name = "slbKhoaPhong";
            this.slbKhoaPhong.Size = new System.Drawing.Size(257, 23);
            this.slbKhoaPhong.TabIndex = 2;
            this.slbKhoaPhong.HisSelectChange += new E00_ControlNew.EventHandler(this.slbKhoaPhong_HisSelectChange);
            // 
            // radDaNhan
            // 
            this.radDaNhan.AutoSize = true;
            this.radDaNhan.BackColor = System.Drawing.Color.Transparent;
            this.radDaNhan.Location = new System.Drawing.Point(175, 29);
            this.radDaNhan.Name = "radDaNhan";
            this.radDaNhan.Size = new System.Drawing.Size(119, 17);
            this.radDaNhan.TabIndex = 5;
            this.radDaNhan.Text = "Đã nhận trong ngày";
            this.radDaNhan.UseVisualStyleBackColor = false;
            this.radDaNhan.CheckedChanged += new System.EventHandler(this.radDaNhan_CheckedChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtTimKiem.Border.BorderColor = System.Drawing.Color.LightBlue;
            this.txtTimKiem.Border.Class = "TextBoxBorder";
            this.txtTimKiem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.Location = new System.Drawing.Point(0, 50);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(335, 24);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimKiem.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.WatermarkImage = ((System.Drawing.Image)(resources.GetObject("txtTimKiem.WatermarkImage")));
            this.txtTimKiem.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.txtTimKiem.WatermarkText = "Tìm kiếm";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // radChuaNhan
            // 
            this.radChuaNhan.AutoSize = true;
            this.radChuaNhan.BackColor = System.Drawing.Color.Transparent;
            this.radChuaNhan.Checked = true;
            this.radChuaNhan.Location = new System.Drawing.Point(78, 29);
            this.radChuaNhan.Name = "radChuaNhan";
            this.radChuaNhan.Size = new System.Drawing.Size(77, 17);
            this.radChuaNhan.TabIndex = 5;
            this.radChuaNhan.TabStop = true;
            this.radChuaNhan.Text = "Chưa nhận";
            this.radChuaNhan.UseVisualStyleBackColor = false;
            this.radChuaNhan.CheckedChanged += new System.EventHandler(this.radChuaNhan_CheckedChanged);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.Location = new System.Drawing.Point(9, 8);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(68, 13);
            this.label66.TabIndex = 3;
            this.label66.Text = "Khoa phòng:";
            // 
            // lblKQ
            // 
            this.lblKQ.AutoSize = true;
            this.lblKQ.BackColor = System.Drawing.Color.Transparent;
            this.lblKQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblKQ.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblKQ.Location = new System.Drawing.Point(11, 27);
            this.lblKQ.Name = "lblKQ";
            this.lblKQ.Size = new System.Drawing.Size(18, 20);
            this.lblKQ.TabIndex = 4;
            this.lblKQ.Text = "0";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightCyan;
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvMain.ColumnHeadersHeight = 22;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaBN,
            this.colHoTen,
            this.colNgay,
            this.colMaQL});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvMain.GridColor = System.Drawing.Color.Thistle;
            this.dgvMain.Location = new System.Drawing.Point(3, 100);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(335, 457);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.DataSourceChanged += new System.EventHandler(this.dgvMain_DataSourceChanged);
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellDoubleClick);
            this.dgvMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMain_KeyDown);
            // 
            // colMaBN
            // 
            this.colMaBN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMaBN.DataPropertyName = "mabn";
            this.colMaBN.HeaderText = "Mã BN";
            this.colMaBN.Name = "colMaBN";
            this.colMaBN.ReadOnly = true;
            this.colMaBN.Width = 65;
            // 
            // colHoTen
            // 
            this.colHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHoTen.DataPropertyName = "hoten";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colHoTen.DefaultCellStyle = dataGridViewCellStyle13;
            this.colHoTen.HeaderText = "Họ Tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colNgay
            // 
            this.colNgay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colNgay.DataPropertyName = "ngayn";
            this.colNgay.HeaderText = "Ngày Nhận";
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            this.colNgay.Width = 80;
            // 
            // colMaQL
            // 
            this.colMaQL.DataPropertyName = "maql";
            this.colMaQL.HeaderText = "MAQL";
            this.colMaQL.Name = "colMaQL";
            this.colMaQL.Visible = false;
            // 
            // txtMaDoiTuong
            // 
            this.txtMaDoiTuong.Location = new System.Drawing.Point(838, 119);
            this.txtMaDoiTuong.Name = "txtMaDoiTuong";
            this.txtMaDoiTuong.Size = new System.Drawing.Size(86, 20);
            this.txtMaDoiTuong.TabIndex = 274;
            this.txtMaDoiTuong.Visible = false;
            // 
            // btnNhanHS
            // 
            this.btnNhanHS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNhanHS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNhanHS.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanHS.Image")));
            this.btnNhanHS.Location = new System.Drawing.Point(213, 701);
            this.btnNhanHS.Name = "btnNhanHS";
            this.btnNhanHS.Size = new System.Drawing.Size(81, 25);
            this.btnNhanHS.TabIndex = 275;
            this.btnNhanHS.Text = "Nhận HS";
            this.btnNhanHS.Click += new System.EventHandler(this.btnNhanHS_Click);
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(648, 119);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(67, 23);
            this.label67.TabIndex = 29;
            this.label67.Text = "Số ra viện :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoRaVien
            // 
            this.txtSoRaVien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSoRaVien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoRaVien.Location = new System.Drawing.Point(713, 120);
            this.txtSoRaVien.Name = "txtSoRaVien";
            this.txtSoRaVien.Size = new System.Drawing.Size(88, 21);
            this.txtSoRaVien.TabIndex = 30;
            // 
            // frmhsluutru
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1059, 729);
            this.Controls.Add(this.btnNhanHS);
            this.Controls.Add(this.txtMaDoiTuong);
            this.Controls.Add(this.his_Panel1);
            this.Controls.Add(this.lblmakp);
            this.Controls.Add(this.icd_nn);
            this.Controls.Add(this.maicd_nn);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.cboTtLucrv);
            this.Controls.Add(this.cboKetqua);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.txttsbanam);
            this.Controls.Add(this.ngayravien);
            this.Controls.Add(this.icd_ravien);
            this.Controls.Add(this.maicd_ravien);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.icd_vao);
            this.Controls.Add(this.maicd_vao);
            this.Controls.Add(this.cbongayvao);
            this.Controls.Add(this.cbobenhan);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.cboGioitinh);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txthoten);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.txtnamsinh);
            this.Controls.Add(this.txtSoRaVien);
            this.Controls.Add(this.txtsoluutru);
            this.Controls.Add(this.txtmabn2);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txttinhtranghoso);
            this.Controls.Add(this.lblPhai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label47);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmhsluutru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Hồ sơ lưu trữ";
            this.TitleText = "Quản lý Hồ sơ lưu trữ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmhsluutru_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabpage1.ResumeLayout(false);
            this.tabpage1.PerformLayout();
            this.slbO.ResumeLayout(false);
            this.slbTang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chamsoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ylenh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkhac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtxn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtxq)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.slbO1.ResumeLayout(false);
            this.slbTang1.ResumeLayout(false);
            this.slbGia1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.his_Panel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion 

        #endregion

        #region Phương thức
        #region 11/11/2017 vannq: tìm hồ sơ ngoại trú lấy từ Libdal
        public DataSet tim_hosoluutru_ngtru(string s_soluutru, string s_mabn, string s_ho, string s_ten, string s_namsinh, string s_gia, string s_tang, string s_o, string tungay, string denngay, string s_makp, string dk_ba, int danhap, string s_madoituong, string s_gioitinh, int loaingay)
        {
            DataSet ldt = new DataSet();
            string fie = (loaingay == 0) ? "a.ngayrv" : (loaingay == 1) ? "a.ngay" : (loaingay == 2) ? "d.ngaynhan" : "d.ngayud";
            sql = "select a.mabn,a.maql,c.hoten, c.ngaysinh, c.namsinh, c.phai,decode(c.phai,0,'Nam','Nữ') gioitinh,nvl(d.soluutru,a.soluutru) soluutru, e.tenkp, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql += " to_char(a.ngayrv,'dd/mm/yyyy hh24:mi')  as ngayrv,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi') as ngayn,";
            sql += " nvl(to_char(f.ngaymuon,'dd/mm/yyyy hh24:mi'),' ') ngaymuon,nvl(to_char(f.ngaytra,'dd/mm/yyyy hh24:mi'),' ') ngaytra,";
            sql += " nvl(g.hoten,' ') bacsimuon, nvl(d.stt,-1) as sttba, d.gia,d.tang,d.vitri_o,h.ten as ketqua,k.tenbv, j.doituong, l.tennn, m.ten as dentu,ltrim(trim(c.sonha||' - '||c.thon||' - '||o.tenpxa||' - '||n.tenquan||' - '||p.tentt),' - ') as diachi,x.ten as tenkho,a.maicdrv as maicd,a.chandoanrv as chandoan ";
            sql += ",d.soto,d.soxq,d.soct,d.sosa,d.soxn,d.sokhac,d.sodt,d.mri,d.ylenh,d.chamsoc,'' as ghichu,a.maicd as maicdvv,a.chandoan as chandoanvv,to_char(d.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,z.hoten as tenuser ";
            sql += " from " + m.user + ".benhanngtr a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d, " + m.user + ".btdkp_bv e," + m.user + ".ba_muon f," + m.user + ".dmbs g," + m.user + ".ketqua h, " + m.user + ".chuyenvien i, " + m.user + ".doituong j, " + m.user + ".dstt k, " + m.user + ".btdnn_bv l, " + m.user + ".dentu m, " + m.user + ".btdquan n, " + m.user + ".btdpxa o, " + m.user + ".btdtt p," + m.user + ".ba_kho x";
            sql += ",(select distinct maql from " + m.user + ".ba_luutruthieu) thieu ," + m.user + ".dlogin z";
            sql += " where a.mabn=c.mabn and a.makp=e.makp and a.ketqua=h.ma and a.maql=i.maql(+) and i.mabv=k.mabv(+) and a.madoituong=j.madoituong and c.mann=l.mann and a.dentu=m.ma and c.matt=p.matt and c.maqu=n.maqu and c.maphuongxa=o.maphuongxa and a.maql=d.maql(+) and a.maql=f.maql(+) and f.mabs=g.ma(+) and a.ngayrv is not null and d.makho=x.id(+) and d.userid=z.id(+) and d.soluutru is not null";
            if (tungay != "" && denngay != "") sql += " and to_date(" + fie + ",'dd/mm/yy') between to_date('" + tungay + "','dd/mm/yy') and to_date('" + denngay + "','dd/mm/yy')";
            if (s_soluutru != "") sql += " and d.soluutru='" + s_soluutru + "'";
            if (s_mabn != "") sql += " and a.mabn='" + s_mabn + "'";
            if (s_ho != "") sql += " and c.hotenkdau like '" + s_ho + "%'";
            if (s_ten != "") sql += " and c.hotenkdau like '%" + s_ten + "'";
            if (s_namsinh != "") sql += " and c.namsinh ='" + s_namsinh + "'";
            if (s_gia != "") sql += " and d.gia='" + s_gia + "'";
            if (s_tang != "") sql += " and d.tang='" + s_tang + "'";
            if (s_o != "") sql += " and d.vitri_o='" + s_o + "'";
            if (s_makp != "") sql += " and a.makp='" + s_makp + "'";
            if (dk_ba != "") sql += dk_ba;
            if (s_madoituong != "") sql += " and a.madoituong='" + s_madoituong + "'";
            if (s_gioitinh != "") sql += " and c.phai='" + s_gioitinh + "'";
            if (danhap == 1) sql += " and d.maql is not null";
            else if (danhap == 2) sql += " and d.maql is null";
            ldt = m.get_data(sql);
            return ldt;
        }
        #endregion

        #region 11/11/2017 vannq: tìm hồ sơ phòng lưu lấy từ Libdal
        public DataSet tim_hosoluutru_pluu(string s_soluutru, string s_mabn, string s_ho, string s_ten, string s_namsinh, string s_gia, string s_tang, string s_o, string tungay, string denngay, string s_makp, string dk_ba, int danhap, string s_madoituong, string s_gioitinh, int loaingay)
        {
            DataSet ldt = new DataSet();
            string fie = (loaingay == 0) ? "a.ngayrv" : (loaingay == 1) ? "a.ngay" : (loaingay == 2) ? "d.ngaynhan" : "d.ngayud";
            sql = "select a.mabn,a.maql,c.hoten, c.ngaysinh, c.namsinh, c.phai,decode(c.phai,0,'Nam','Nữ') gioitinh,nvl(d.soluutru,a.soluutru) soluutru, e.tenkp, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql += " to_char(a.ngayrv,'dd/mm/yyyy hh24:mi')  as ngayrv,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi') as ngayn,";
            sql += " nvl(to_char(f.ngaymuon,'dd/mm/yyyy hh24:mi'),' ') ngaymuon,nvl(to_char(f.ngaytra,'dd/mm/yyyy hh24:mi'),' ') ngaytra,";
            sql += " nvl(g.hoten,' ') bacsimuon, nvl(d.stt,-1) as sttba, d.gia,d.tang,d.vitri_o, h.ten as ketqua,k.tenbv, j.doituong, l.tennn, m.ten as dentu,ltrim(trim(c.sonha||' - '||c.thon||' - '||o.tenpxa||' - '||n.tenquan||' - '||p.tentt),' - ') as diachi,x.ten as tenkho,a.maicdrv as maicd,a.chandoanrv as chandoan ";
            sql += ",d.soto,d.soxq,d.soct,d.sosa,d.soxn,d.sokhac,d.sodt,d.mri,d.ylenh,d.chamsoc,'' as ghichu,a.maicd as maicdvv,a.chandoan as chandoanvv,to_char(d.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,z.hoten as tenuser ";
            sql += " from xxx.benhancc a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d, " + m.user + ".btdkp_bv e," + m.user + ".ba_muon f," + m.user + ".dmbs g," + m.user + ".ketqua h, " + m.user + ".chuyenvien i, " + m.user + ".doituong j, " + m.user + ".dstt k, " + m.user + ".btdnn_bv l, " + m.user + ".dentu m, " + m.user + ".btdquan n, " + m.user + ".btdpxa o, " + m.user + ".btdtt p," + m.user + ".ba_kho x";
            sql += ",(select distinct maql from " + m.user + ".ba_luutruthieu) thieu," + m.user + ".dlogin z ";
            sql += " where a.mabn=c.mabn and a.makp=e.makp and a.ketqua=h.ma and a.maql=i.maql(+) and i.mabv=k.mabv(+) and a.madoituong=j.madoituong and c.mann=l.mann and a.dentu=m.ma and c.matt=p.matt and c.maqu=n.maqu and c.maphuongxa=o.maphuongxa and a.maql=d.maql(+) and a.maql=f.maql(+) and f.mabs=g.ma(+) and a.ngayrv is not null and d.makho=x.id(+) and d.userid=z.id(+) and d.soluutru is not null";
            if (tungay != "" && denngay != "") sql += " and to_date(" + fie + ",'dd/mm/yy') between to_date('" + tungay + "','dd/mm/yy') and to_date('" + denngay + "','dd/mm/yy')";
            if (s_soluutru != "") sql += " and d.soluutru='" + s_soluutru + "'";
            if (s_mabn != "") sql += " and a.mabn='" + s_mabn + "'";
            if (s_ho != "") sql += " and c.hotenkdau like '" + s_ho + "%'";
            if (s_ten != "") sql += " and c.hotenkdau like '%" + s_ten + "'";
            if (s_namsinh != "") sql += " and c.namsinh ='" + s_namsinh + "'";
            if (s_gia != "") sql += " and d.gia='" + s_gia + "'";
            if (s_tang != "") sql += " and d.tang='" + s_tang + "'";
            if (s_o != "") sql += " and d.vitri_o='" + s_o + "'";
            if (s_makp != "") sql += " and a.makp='" + s_makp + "'";
            if (dk_ba != "") sql += dk_ba;
            if (s_madoituong != "") sql += " and a.madoituong='" + s_madoituong + "'";
            if (s_gioitinh != "") sql += " and c.phai='" + s_gioitinh + "'";
            if (danhap == 1) sql += " and d.maql is not null";
            else if (danhap == 2) sql += " and d.maql is null";
            try
            {
                ldt = m.get_data_mmyy(sql, tungay, denngay, false);
            }
            catch { };
            return ldt;
        }
        #endregion

        #region 11/11/2017 vannq: tìm hồ sơ phòng khám
        public DataSet tim_hosoluutru_pk(string s_soluutru, string s_mabn, string s_ho, string s_ten, string s_namsinh, string s_gia, string s_tang, string s_o, string tungay, string denngay, string s_makp, string dk_ba, int danhap, string s_madoituong, string s_gioitinh, int loaingay)
        {
            DataSet ldt = new DataSet();
            string fie = (loaingay == 0) ? "a.ngayrv" : (loaingay == 1) ? "a.ngay" : (loaingay == 2) ? "d.ngaynhan" : "d.ngayud";
            sql = "select a.mabn,a.maql,c.hoten, c.ngaysinh, c.namsinh, c.phai,decode(c.phai,0,'Nam','Nữ') gioitinh,nvl(d.soluutru,'') soluutru, e.tenkp, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql += " to_char(a.ngayrv,'dd/mm/yyyy hh24:mi')  as ngayrv,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi') as ngayn,";
            sql += " nvl(to_char(f.ngaymuon,'dd/mm/yyyy hh24:mi'),' ') ngaymuon,nvl(to_char(f.ngaytra,'dd/mm/yyyy hh24:mi'),' ') ngaytra,";
            sql += " nvl(g.hoten,' ') bacsimuon, nvl(d.stt,-1) as sttba, d.gia,d.tang,d.vitri_o, '' as ketqua,k.tenbv, j.doituong, l.tennn, m.ten as dentu,ltrim(trim(c.sonha||' - '||c.thon||' - '||o.tenpxa||' - '||n.tenquan||' - '||p.tentt),' - ') as diachi,x.ten as tenkho,'' as maicd,'' as chandoan ";
            sql += ",d.soto,d.soxq,d.soct,d.sosa,d.soxn,d.sokhac,d.sodt,d.mri,d.ylenh,d.chamsoc,'' as ghichu,a.maicd as maicdvv,a.chandoan as chandoanvv,to_char(d.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,z.hoten as tenuser ";
            sql += " from xxx.benhanpk a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d, " + m.user + ".btdkp_bv e," + m.user + ".ba_muon f," + m.user + ".dmbs g," + m.user + ".chuyenvien i, " + m.user + ".doituong j, " + m.user + ".dstt k, " + m.user + ".btdnn_bv l, " + m.user + ".dentu m, " + m.user + ".btdquan n, " + m.user + ".btdpxa o, " + m.user + ".btdtt p," + m.user + ".ba_kho x";
            sql += ",(select distinct maql from " + m.user + ".ba_luutruthieu) thieu," + m.user + ".dlogin z ";
            sql += " where a.mabn=c.mabn and a.makp=e.makp and a.maql=i.maql(+) and i.mabv=k.mabv(+) and a.madoituong=j.madoituong and c.mann=l.mann and a.dentu=m.ma and c.matt=p.matt and c.maqu=n.maqu and c.maphuongxa=o.maphuongxa and a.maql=d.maql(+) and a.maql=f.maql(+) and f.mabs=g.ma(+) and a.ngayrv is not null and d.makho=x.id(+) and d.userid=z.id(+) and d.nhanba is not null";
            if (tungay != "" && denngay != "") sql += " and to_date(" + fie + ",'dd/mm/yy') between to_date('" + tungay + "','dd/mm/yy') and to_date('" + denngay + "','dd/mm/yy')";
            if (s_soluutru != "") sql += " and d.soluutru='" + s_soluutru + "'";
            if (s_mabn != "") sql += " and a.mabn='" + s_mabn + "'";
            if (s_ho != "") sql += " and c.hotenkdau like '" + s_ho + "%'";
            if (s_ten != "") sql += " and c.hotenkdau like '%" + s_ten + "'";
            if (s_namsinh != "") sql += " and c.namsinh ='" + s_namsinh + "'";
            if (s_gia != "") sql += " and d.gia='" + s_gia + "'";
            if (s_tang != "") sql += " and d.tang='" + s_tang + "'";
            if (s_o != "") sql += " and d.vitri_o='" + s_o + "'";
            if (s_makp != "") sql += " and a.makp='" + s_makp + "'";
            if (dk_ba != "") sql += dk_ba;
            if (s_madoituong != "") sql += " and a.madoituong='" + s_madoituong + "'";
            if (s_gioitinh != "") sql += " and c.phai='" + s_gioitinh + "'";
            if (danhap == 1) sql += " and d.maql is not null";
            else if (danhap == 2) sql += " and d.maql is null";
            try
            {
                ldt = m.get_data_mmyy(sql, tungay, denngay, false);
            }
            catch { };

            if (cbobenhan.SelectedIndex == 5)
            {
                fie = (loaingay == 0) ? "a.ngayrv" : (loaingay == 1) ? "a.ngayvv" : (loaingay == 2) ? "a.ngaynhan" : "a.ngayud";
                string sql22 = "select a.mabn,a.maql,c.hoten,c.ngaysinh,c.namsinh, c.phai,decode(c.phai,0,'Nam','Nữ') gioitinh,a.soluutru, b.tenkp,a.ngayvv,a.ngayrv, a.ngaynhan,nvl(to_char(f.ngaymuon,'dd/mm/yyyy hh24:mi'),' ') ngaymuon ,nvl(to_char(f.ngaytra,'dd/mm/yyyy hh24:mi'),' ') ngaytra, nvl(g.hoten,' ') bacsimuon,decode(a.nhanba,null,-1,0) as  sttba,a.gia,a.tang,a.vitri_o,a.ketqua,null as tenbv,null as doituong,null as tennn,null as dentu,ltrim(trim(c.sonha||' - '||c.thon||' - '||o.tenpxa||' - '||n.tenquan||' - '||p.tentt),' - ') as diachi,x.ten as tenkho,a.icdrv as maicd,a.chandoanrv as chandoan,null as soto ,a.soxq,a.soct,a.sosa,a.soxn,a.sokhac,a.sodt,a.mri,a.ylenh,a.chamsoc,null as ghichu,a.icdvv as maicdvv,a.chandoanvv,a.ngayud,z.hoten as tenuser from his.ba_luutru a left join his.btdkp_bv b on a.makp = b.makp left join his.btdbn c on a.mabn = c.mabn ";
                sql22 += "left join his.btdpxa o on c.maphuongxa = o.maphuongxa left join his.btdquan n on c.maqu = n.maqu left join his.btdtt p on c.matt = p.matt left join his.ba_kho x on a.makho = x.id left join his.ba_muon f on a.maql = f.maql left join his.dmbs g on f.mabs = g.ma left join his.dlogin z on a.userid = z.id";
                sql22 += " where soto = 1 and a.khthnhanba = 1 and a.nhanba is not null ";
                if (tungay != "" && denngay != "") sql22 += " and " + fie + " between to_date('" + tungay + "','dd/mm/yy') and to_date('" + denngay + "','dd/mm/yy')";
                if (s_soluutru != "") sql22 += " and a.soluutru='" + s_soluutru + "'";
                if (s_mabn != "") sql22 += " and a.mabn='" + s_mabn + "'";
                if (s_ho != "") sql22 += " and c.hotenkdau like '" + s_ho + "%'";
                if (s_ten != "") sql22 += " and c.hotenkdau like '%" + s_ten + "'";
                if (s_namsinh != "") sql22 += " and c.namsinh ='" + s_namsinh + "'";
                if (s_gia != "") sql22 += " and a.gia='" + s_gia + "'";
                if (s_tang != "") sql22 += " and a.tang='" + s_tang + "'";
                if (s_o != "") sql22 += " and a.vitri_o='" + s_o + "'";
                if (s_makp != "") sql22 += " and a.makp='" + s_makp + "'";
                if (s_gioitinh != "") sql22 += " and c.phai='" + s_gioitinh + "'";
                try
                {
                    ldt = m.merge(ldt, m.get_data(sql22));
                }
                catch
                {
                    ldt = null;
                }
            }
            return ldt;
        }
        #endregion

        #region 11/11/2017 vannq: tìm hồ sơ nội trú lấy từ Libdal
        public DataSet tim_hosoluutru(string s_soluutru, string s_mabn, string s_ho, string s_ten, string s_namsinh, string s_gia, string s_tang, string s_o, string tungay, string denngay, string s_makp, string dk_ba, int danhap, string s_madoituong, string s_gioitinh, int loaingay)
        {
            DataSet ldt = new DataSet();
            string fie = (loaingay == 0) ? "b.ngay" : (loaingay == 1) ? "a.ngay" : (loaingay == 2) ? "d.ngaynhan" : "d.ngayud";
            sql = "select a.mabn,a.maql,c.hoten, c.ngaysinh, c.namsinh, c.phai,decode(c.phai,0,'Nam','Nữ') gioitinh,nvl(d.soluutru,a.soluutru) soluutru, e.tenkp, to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql += " to_char(a.ngay,'dd/mm/yyyy hh24:mi')  as ngayrv,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi') as ngayn,";
            sql += " nvl(to_char(f.ngaymuon,'dd/mm/yyyy hh24:mi'),' ') ngaymuon,nvl(to_char(f.ngaytra,'dd/mm/yyyy hh24:mi'),' ') ngaytra,";
            sql += " nvl(g.hoten,' ') bacsimuon, nvl(d.stt,-1) as sttba, d.gia,d.tang,d.vitri_o,h.ten as ketqua,k.tenbv, j.doituong, l.tennn, m.ten as dentu,";
            sql += " ltrim(trim(c.sonha||' - '||c.thon||' - '||o.tenpxa||' - '||n.tenquan||' - '||p.tentt),' - ') as diachi,x.ten as tenkho,a.maicd,a.chandoan ";
            sql += ",d.soto,d.soxq,d.soct,d.sosa,d.soxn,d.sokhac,d.sodt,d.mri,d.ylenh,d.chamsoc,'' as ghichu,b.maicd as maicdvv,b.chandoan as chandoanvv,to_char(d.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,z.hoten as tenuser ";
            sql += " from " + m.user + ".xuatvien a, " + m.user + ".benhandt b, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d, " + m.user + ".btdkp_bv e," + m.user + ".ba_muon f," + m.user + ".dmbs g, " + m.user + ".ketqua h, " + m.user + ".chuyenvien i, " + m.user + ".doituong j, " + m.user + ".dstt k, " + m.user + ".btdnn_bv l, " + m.user + ".dentu m, " + m.user + ".btdquan n, " + m.user + ".btdpxa o, " + m.user + ".btdtt p," + m.user + ".ba_kho x ";
            sql += ",(select distinct maql from " + m.user + ".ba_luutruthieu) thieu," + m.user + ".dlogin z ";
            sql += " where a.mabn=c.mabn and a.maql=b.maql and a.ketqua=h.ma and a.maql=i.maql(+) and i.mabv=k.mabv(+) and b.madoituong=j.madoituong and c.mann=l.mann and b.dentu=m.ma and c.matt=p.matt and c.maqu=n.maqu and c.maphuongxa=o.maphuongxa and a.makp=e.makp and a.maql=d.maql(+) and b.loaiba=1 and a.maql=f.maql(+) and f.mabs=g.ma(+) and d.makho=x.id(+) and d.userid=z.id(+) and d.soluutru is not null";
            if (tungay != "" && denngay != "") sql += " and to_date(" + fie + ",'dd/mm/yy') between to_date('" + tungay + "','dd/mm/yy') and to_date('" + denngay + "','dd/mm/yy')";
            if (s_soluutru != "") sql += " and d.soluutru='" + s_soluutru + "'";
            if (s_mabn != "") sql += " and a.mabn='" + s_mabn + "'";
            if (s_ho != "") sql += " and c.hotenkdau like '" + s_ho + "%'";
            if (s_ten != "") sql += " and c.hotenkdau like '%" + s_ten + "'";
            if (s_namsinh != "") sql += " and c.namsinh ='" + s_namsinh + "'";
            if (s_gia != "") sql += " and d.gia='" + s_gia + "'";
            if (s_tang != "") sql += " and d.tang='" + s_tang + "'";
            if (s_o != "") sql += " and d.vitri_o='" + s_o + "'";
            if (s_makp != "") sql += " and a.makp='" + s_makp + "'";
            if (dk_ba != "") sql += dk_ba;
            if (s_madoituong != "") sql += " and b.madoituong='" + s_madoituong + "'";
            if (s_gioitinh != "") sql += " and c.phai='" + s_gioitinh + "'";
            if (danhap == 1) sql += " and d.maql is not null";
            else if (danhap == 2) sql += " and d.maql is null";
            ldt = m.get_data(sql);
            return ldt;
        }
        #endregion

        #region 16/11/2017 Vannq Load danh sách ra viện
        private void Load_DanhSachRaVien()
        {
            //if (radDaNhan.Checked) return;
            //string sql = "";
            //sql += "select a.mabn,b.hoten,to_char(c.ngay,'dd/MM/yyyy') as \"Ngaynhan\",FN_CONVERT_TO_VN(b.hoten) as \"HOTENKHONGDAU\", a.maql from ba_luutru a ";
            //sql += " left join btdbn b on a.mabn = b.mabn ";
            //sql += " left join xuatvien c on c.maql = a.maql ";
            //sql += " where nhanba is null and c.ngay is not null";
            //if (cbobenhan.SelectedIndex == 0)
            //{
            //    sql += " and loaiba = '1'";
            //}
            //else if (cbobenhan.SelectedIndex == 1)
            //{
            //    sql += " and loaiba = '0'";
            //}
            //else sql += " and loaiba = '" + cbobenhan.SelectedIndex.ToString() + "'";
            //if (slbKhoaPhong.txtMa.Text != "") sql += " and makp = " + slbKhoaPhong.txtMa.Text;
            dt = m.get_data(sql).Tables[0];
            dgvMain.DataSource = dt;
        }

        private void Load_BenhNhan()
        {
            string sql1 = "", sql2 = "", sql3 = "", sql4 = "";
            if (String.IsNullOrEmpty(_tungay) || String.IsNullOrEmpty(_denngay))
            {
                _tungay = _denngay = DateTime.Now.ToString("dd/MM/yyyy");
            }
            string s_nam = _Utility.get_mmyy(_tungay,_denngay);
            string[] val = s_nam.Trim().Trim('+').Split('+');

            sql = "select maluutru,sort,maql,mabn,hoten, ngaysinh, namsinh, phai, tenkp,sltmedi,slthsba, ngayvv,maicd_vaovien,icd_vaovien,ngayrv,maicd_ravien,icd_ravien,ngayn, sttba,damuon,tenbs, gia,tang,vitri_o,soxq,soct,sosa,soxn,sodt,sokhac,tonghoso,nguoigiao,nguoinhan,loaiba,ttlucrv,ketqua,tainan,makho,mri,ylenh,chamsoc,madoituong,khthnhanba,makp,hotenkdau from (";
            // 
            sql1 = " select e.maluutru,to_char(b.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql1 += " b.maicd maicd_vaovien,b.chandoan icd_vaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,a.maicd maicd_ravien,a.chandoan icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn,";

            sql1 += " nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, b.madoituong,d.khthnhanba,a.makp,c.hotenkdau ";
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
                        sql2 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";

                        sql2 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc,a.madoituong,d.khthnhanba,a.makp,c.hotenkdau ";
                        sql2 += " from " + m.user + val[i].ToString() + ".benhancc a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql2 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                        // if (smabn != "") sql2 += " and a.mabn='" + smabn + "'";
                        // if (maql != 0) sql2 += " and a.maql=" + maql;
                    }
                }
            }
            //End Phong luu

            //Ngoai tru
            sql3 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
            sql3 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba,a.makp,c.hotenkdau ";
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
                        sql4 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,'' as sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
                        sql4 += " null as maicd_ravien,null as icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,0 as ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba, a.makp,c.hotenkdau ";
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
                    case 1: sql += sql3 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "' and a.khthnhanba = 1 order by sort desc"; break;
                    #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                    case 5:
                        {
                            //if (s_nam.Trim() == "") sql += sql3 + ")  a order by sort desc";
                            if (s_nam.Trim() != "") sql += sql4 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "' and a.khthnhanba = 1 order by sort desc"; break;
                        }
                    #endregion
                    case 2: sql += sql2 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "' and a.khthnhanba = 1  order by sort desc"; break;
                    case 0: sql += sql1 + ")  a where a.sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "' and a.khthnhanba = 1  order by sort desc"; break;
                    default: sql += sql1 + " union all " + sql2 + ")  a where a.ttlucrv=7 and sttba = '-1' and a.makp = '" + slbKhoaPhong.txtMa.Text + "' and a.khthnhanba = 1 order by sort desc"; break;
                }
            }
            else
            {
                switch (cbobenhan.SelectedIndex)
                {

                    #region code củ
                    case 1: sql += sql3 + ")  a where a.sttba = '-1' and a.khthnhanba = 1 order by sort desc"; break;
                    #endregion

                    #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                    case 5:
                        {
                            //if (s_nam.Trim() == "") sql += sql3 + ")  a order by sort desc";
                            if (s_nam.Trim() != "") sql += sql4 + ")  a where a.sttba = '-1' and a.khthnhanba = 1 order by sort desc"; break;
                        }
                    #endregion
                    case 2: sql += sql2 + ")  a where a.sttba = '-1' and a.khthnhanba = 1 order by sort desc"; break;
                    case 0: sql += sql1 + ")  a where a.sttba = '-1' and a.khthnhanba = 1 order by sort desc"; break;
                    default: sql += sql1 + " union all " + sql2 + ")  a where a.ttlucrv=7 and sttba = '-1' and a.khthnhanba = 1 order by sort desc"; break;
                }
            }

            try
            {
                dt = m.get_data(sql).Tables[0];
                
            }
            catch
            {
                dt = null;
            }
            DataTable dt1;
            string sql22 = "select null as maluutru,null as sort,a.maql,a.mabn,c.hoten,c.ngaysinh,c.namsinh, c.phai, b.tenkp,a.soluutru as sltmedi,null as slthsba, a.ngayvv,a.icdvv as maicd_vaovien,a.chandoanvv as icd_vaovien,a.ngayrv,a.icdrv as maicd_ravien,a.chandoanrv as icd_ravien,a.ngaynhan as ngayn,decode(a.nhanba,null,-1,0) as  sttba,0 as damuon,null as tenbs, a.gia,a.tang,a.vitri_o,a.soxq,a.soct,a.sosa,a.soxn,a.sodt,a.sokhac,a.tonghoso,a.nguoigiao,a.nguoinhan,a.loaiba,a.tinhtrang as ttlucrv,a.ketqua,a.tainan,a.makho,a.mri,a.ylenh,a.chamsoc,0 as madoituong,a.khthnhanba,a.makp,c.hotenkdau from his.ba_luutru a left join his.btdkp_bv b on a.makp = b.makp left join his.btdbn c on a.mabn = c.mabn where soto = 1 and a.khthnhanba = 1 and nhanba is null";
            try
            {
                dt1 = m.merge(dt.Copy(), m.get_data(sql22).Tables[0]);
            }
            catch 
            {
                dt1 = null;
            }
            if (cbobenhan.SelectedIndex == 5) dgvMain.DataSource = dt1;
            else dgvMain.DataSource = dt;
        }

        #endregion

        public void upd_ba_luutru(string s_mabn, decimal l_maql, string s_soluutru, int i_nhanba, string s_ngaynhan, string s_gia, string s_tang, string s_vitri_o, int i_soxq, int i_soct, int i_sosa, int i_soxn, int i_sodt, int i_sokhac, int i_tonghoso, string s_nguoigiao, string s_nguoinhan, decimal l_stt, int i_loaiba, int tainan, int makho, int mri, int ylenh, int chamsoc, int userid)
        {
            m.sql = "update " + m.user + ".ba_luutru set nhanba=:i_nhanba, ngaynhan=to_date(:s_ngaynhan,'dd/mm/yyyy hh24:mi'),gia=:s_gia,";
            m.sql += "tang=:s_tang, vitri_o=:s_vitri_o,soxq=:i_soxq, soct=:i_soct, sosa=:i_sosa, soxn=:i_soxn, sodt=:i_sodt,sokhac=:i_sokhac,";
            m.sql = string.Concat(new object[]
	{
		m.sql,
		"tonghoso=:i_tonghoso, nguoigiao=:s_nguoigiao, nguoinhan=:s_nguoinhan, stt=:l_stt, loaiba=:i_loaiba,tainan=",
		tainan,
		",makho=",
		makho
	});
            m.sql = string.Concat(new object[]
	{
		m.sql,
		",mri=",
		mri,
		",ylenh=",
		ylenh,
		",chamsoc=",
		chamsoc
	});
            m.sql = string.Concat(new object[]
	{
		m.sql,
		" where mabn='",
		s_mabn,
		"' and maql=",
		l_maql,
		" and soluutru=:s_soluutru"
	});
            CloseConnection();
            m.cmd = new OracleCommand(m.sql, m.con);
            m.cmd.CommandType = CommandType.Text;
            m.cmd.Parameters.Add("i_nhanba", OracleDbType.Decimal).Value = i_nhanba;
            m.cmd.Parameters.Add("s_ngaynhan", OracleDbType.Varchar2, 50).Value = s_ngaynhan;
            m.cmd.Parameters.Add("s_gia", OracleDbType.Varchar2, 50).Value = s_gia;
            m.cmd.Parameters.Add("s_tang", OracleDbType.Varchar2, 50).Value = s_tang;
            m.cmd.Parameters.Add("s_vitri_o", OracleDbType.Varchar2, 50).Value = s_vitri_o;
            m.cmd.Parameters.Add("i_soxq", OracleDbType.Decimal).Value = i_soxq;
            m.cmd.Parameters.Add("i_soct", OracleDbType.Decimal).Value = i_soct;
            m.cmd.Parameters.Add("i_sosa", OracleDbType.Decimal).Value = i_sosa;
            m.cmd.Parameters.Add("i_soxn", OracleDbType.Decimal).Value = i_soxn;
            m.cmd.Parameters.Add("i_sodt", OracleDbType.Decimal).Value = i_sodt;
            m.cmd.Parameters.Add("i_sokhac", OracleDbType.Decimal).Value = i_sokhac;
            m.cmd.Parameters.Add("i_tonghoso", OracleDbType.Decimal).Value = i_tonghoso;
            m.cmd.Parameters.Add("s_nguoigiao", OracleDbType.Varchar2, 50).Value = s_nguoigiao;
            m.cmd.Parameters.Add("s_nguoinhan", OracleDbType.Varchar2, 50).Value = s_nguoinhan;
            m.cmd.Parameters.Add("l_stt", OracleDbType.Decimal).Value = l_stt;
            m.cmd.Parameters.Add("i_loaiba", OracleDbType.Decimal).Value = i_loaiba;
            m.cmd.Parameters.Add("s_soluutru", OracleDbType.Varchar2, 50).Value = s_soluutru;
            try
            {
                int num = m.cmd.ExecuteNonQuery();
                m.cmd.Dispose();
                bool flag = num == 0;
                if (flag)
                {
                    m.sql = "insert into " + m.user + ".ba_luutru(mabn, maql, soluutru, nhanba, ngaynhan, gia, tang, vitri_o, soxq, soct,";
                    m.sql += "sosa, soxn, sokhac, tonghoso, nguoigiao, nguoinhan, stt, loaiba, sodt,tainan,makho,mri,ylenh,chamsoc,userid)";
                    m.sql += " values(:s_mabn,:l_maql, :s_soluutru, :i_nhanba, to_date(:s_ngaynhan,'dd/mm/yyyy hh24:mi'),:s_gia,";
                    m.sql += ":s_tang, :s_vitri_o, :i_soxq, :i_soct, :i_sosa, :i_soxn, :i_sokhac, :i_tonghoso, :s_nguoigiao, :s_nguoinhan,";
                    m.sql = string.Concat(new object[]
			{
				m.sql,
				":l_stt, :i_loaiba, :i_sodt,",
				tainan,
				",",
				makho,
				",",
				mri,
				",",
				ylenh,
				",",
				chamsoc,
				",",
				userid,
				")"
			});
                    m.cmd = new OracleCommand(m.sql, m.con);
                    m.cmd.CommandType = CommandType.Text;
                    m.cmd.Parameters.Add("s_mabn", OracleDbType.Varchar2).Value = s_mabn;
                    m.cmd.Parameters.Add("l_maql", OracleDbType.Decimal).Value = l_maql;
                    m.cmd.Parameters.Add("s_soluutru", OracleDbType.Varchar2, 50).Value = s_soluutru;
                    m.cmd.Parameters.Add("i_nhanba", OracleDbType.Decimal).Value = i_nhanba;
                    m.cmd.Parameters.Add("s_ngaynhan", OracleDbType.Varchar2, 50).Value = s_ngaynhan;
                    m.cmd.Parameters.Add("s_gia", OracleDbType.Varchar2, 50).Value = s_gia;
                    m.cmd.Parameters.Add("s_tang", OracleDbType.Varchar2, 50).Value = s_tang;
                    m.cmd.Parameters.Add("s_vitri_o", OracleDbType.Varchar2, 50).Value = s_vitri_o;
                    m.cmd.Parameters.Add("i_soxq", OracleDbType.Decimal).Value = i_soxq;
                    m.cmd.Parameters.Add("i_soct", OracleDbType.Decimal).Value = i_soct;
                    m.cmd.Parameters.Add("i_sosa", OracleDbType.Decimal).Value = i_sosa;
                    m.cmd.Parameters.Add("i_soxn", OracleDbType.Decimal).Value = i_soxn;
                    m.cmd.Parameters.Add("i_sokhac", OracleDbType.Decimal).Value = i_sokhac;
                    m.cmd.Parameters.Add("i_tonghoso", OracleDbType.Decimal).Value = i_tonghoso;
                    m.cmd.Parameters.Add("s_nguoigiao", OracleDbType.Varchar2, 50).Value = s_nguoigiao;
                    m.cmd.Parameters.Add("s_nguoinhan", OracleDbType.Varchar2, 50).Value = s_nguoinhan;
                    m.cmd.Parameters.Add("l_stt", OracleDbType.Decimal).Value = l_stt;
                    m.cmd.Parameters.Add("i_loaiba", OracleDbType.Decimal).Value = i_loaiba;
                    m.cmd.Parameters.Add("i_sodt", OracleDbType.Decimal).Value = i_sodt;
                    num = m.cmd.ExecuteNonQuery();
                    m.cmd.Dispose();
                }
            }
            catch (OracleException ex)
            {
                m.upd_error(ex.Message, this.sql);
            }
            finally
            {
                CloseConnectionFinally();
            }
        }

        private void CloseConnection()
        {
            bool flag = m.trans == null;
            if (flag)
            {
                bool flag2 = m.con != null;
                if (flag2)
                {
                    m.con.Close();
                    m.con.Dispose();
                }
                m.con = new OracleConnection(m.sConn);
                m.con.Open();
            }
        }

        private void CloseConnectionFinally()
        {
            m.cmd.Dispose();
            bool flag = m.trans == null;
            if (flag)
            {
                m.con.Close();
                m.con.Dispose();
            }
        }

        #region 20/11/2017 Vannq
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
            catch (System.Exception var_2_B1)
            {
            }
        }

        private void Load_Gia()
        {
            try
            {
                List<string> lstField = new List<string>();
                lstField.Add(cls_DanhMucViTri.col_Ma);
                lstField.Add(cls_DanhMucViTri.col_Ten);

                Dictionary<string, string> dicEqual = new Dictionary<string, string>();
                dicEqual.Add(cls_DanhMucViTri.col_Loai, "GIA");
                dicEqual.Add(cls_DanhMucViTri.col_TamNgung, "0");
                dicEqual.Add(cls_DanhMucViTri.col_TinhTrang, "0");


                slbGia.DataSource = slbGia1.DataSource = _api.Search(ref _userError, ref _systemError, cls_DanhMucViTri.tb_TenBang, lst: lstField, andLike: false, dicEqual: dicEqual,
                                                    orderByASC1: true, orderByName1: cls_DanhMucViTri.col_ID);
            }
            catch
            {
                slbGia.DataSource = slbGia1.DataSource = null;
            }
        }

        private void Load_Tang()
        {
            try
            {
                List<string> lstField = new List<string>();
                lstField.Add(cls_DanhMucViTri.col_Ma);
                lstField.Add(cls_DanhMucViTri.col_Ten);

                Dictionary<string, string> dicEqual = new Dictionary<string, string>();
                dicEqual.Add(cls_DanhMucViTri.col_Loai, "TANG");
                dicEqual.Add(cls_DanhMucViTri.col_TamNgung, "0");
                dicEqual.Add(cls_DanhMucViTri.col_TinhTrang, "0");

                slbTang.DataSource = slbTang1.DataSource = _api.Search(ref _userError, ref _systemError, cls_DanhMucViTri.tb_TenBang, lst: lstField, andLike: false, dicEqual: dicEqual,
                                                    orderByASC1: true, orderByName1: cls_DanhMucViTri.col_ID);
            }
            catch
            {
                slbTang.DataSource = slbTang1.DataSource = null;
            }
        }

        private void Load_O()
        {
            try
            {
                List<string> lstField = new List<string>();
                lstField.Add(cls_DanhMucViTri.col_Ma);
                lstField.Add(cls_DanhMucViTri.col_Ten);

                Dictionary<string, string> dicEqual = new Dictionary<string, string>();
                dicEqual.Add(cls_DanhMucViTri.col_Loai, "O");
                dicEqual.Add(cls_DanhMucViTri.col_TamNgung, "0");
                dicEqual.Add(cls_DanhMucViTri.col_TinhTrang, "0");

                slbO.DataSource = slbO1.DataSource = _api.Search(ref _userError, ref _systemError, cls_DanhMucViTri.tb_TenBang, lst: lstField, andLike: false, dicEqual: dicEqual,
                                                    orderByASC1: true, orderByName1: cls_DanhMucViTri.col_ID);
            }
            catch
            {
                slbO.DataSource = slbO1.DataSource = null;
            }
        }
        #endregion

        private void load_ngay()
        {
            string _ngay = m.Ngayhienhanh.Substring(0, 10);
            string _tu = _Utility.DateToString("dd/MM/yyyy", _Utility.StringToDate(_ngay).AddMonths(-3));
            sql = "select a.mabn,a.hoten,case when a.ngaysinh is not null then to_char(a.ngaysinh,'dd/mm/yyyy') else a.namsinh end as ngaysinh,";
            sql += " b.soluutru,to_char(b.ngaynhan,'dd/mm/yyyy') as ngayn,e.tenkp,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql += " to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,b.soluutru as slt ,b.maql,b.loaiba";
            sql += " from btdbn a,ba_luutru b,benhandt c,xuatvien d,btdkp_bv e ";
            sql += " where a.mabn=b.mabn and b.maql=c.maql and c.maql=d.maql and d.makp=e.makp ";
            #region 20/11/2017 Vannq lọc bệnh nhân đã lưu hs
            sql += " and b.nhanba is not null";
            #endregion
            #region code cũ 22/11/2017
            //sql += " and to_char(b.ngayud,'dd/mm/yyyy')='" + _ngay + "'";
            #endregion
            #region 22/11/2017 Vannq lấy bn đã lưu hs theo ngày nhận hs
            sql += " and to_char(b.ngaynhan,'dd/mm/yyyy')='" + _ngay + "'";
            #endregion
            sql += " union all ";
            sql += " select a.mabn,a.hoten,case when a.ngaysinh is not null then to_char(a.ngaysinh,'dd/mm/yyyy') else a.namsinh end as ngaysinh,";
            sql += " b.soluutru,to_char(b.ngaynhan,'dd/mm/yyyy') as ngayn,e.tenkp,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql += " to_char(c.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,b.soluutru as slt ,b.maql,b.loaiba";
            sql += " from btdbn a,ba_luutru b,benhanngtr c,btdkp_bv e ";
            sql += " where a.mabn=b.mabn and b.maql=c.maql and c.makp=e.makp ";
            #region 20/11/2017 Vannq lọc bệnh nhân đã lưu hs
            sql += " and b.nhanba is not null";
            #endregion
            #region code cũ 22/11/2017
            //sql += " and to_char(b.ngayud,'dd/mm/yyyy')='" + _ngay + "'";
            #endregion
            #region 22/11/2017 Vannq lấy bn đã lưu hs theo ngày nhận hs
            sql += " and to_char(b.ngaynhan,'dd/mm/yyyy')='" + _ngay + "'";
            #endregion
            sql += " order by slt";
            dsng = m.get_data(sql);

            sql = " select a.mabn,a.hoten,case when a.ngaysinh is not null then to_char(a.ngaysinh,'dd/mm/yyyy') else a.namsinh end as ngaysinh,";
            sql += " b.soluutru,to_char(b.ngaynhan,'dd/mm/yyyy') as ngayn,e.tenkp,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql += " to_char(c.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,b.soluutru as slt ,b.maql,b.loaiba";
            sql += " from btdbn a,ba_luutru b,xxx.benhancc c,btdkp_bv e ";
            sql += " where a.mabn=b.mabn and b.maql=c.maql and c.makp=e.makp ";
            #region Code cũ 22/11/2017
            //sql += " and to_char(b.ngayud,'dd/mm/yyyy')='" + _ngay + "'"; 
            #endregion
            #region 22/11/2017 Vannq lấy bn đã lưu hs theo ngày nhận hs
            sql += " and to_char(b.ngaynhan,'dd/mm/yyyy')='" + _ngay + "'";
            #endregion
            sql += " order by slt";

            dsng.Merge(m.get_data_mmyy(sql, _tu, _ngay, false));

            string sql22 = "select a.mabn,c.hoten,to_char(c.ngaysinh,'dd/mm/yyyy') as ngaysinh ,a.soluutru,to_char(a.ngaynhan,'dd/mm/yyyy') as ngayn, b.tenkp, to_char(a.ngayvv,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,a.soluutru as slt,a.maql,a.loaiba from his.ba_luutru a left join his.btdkp_bv b on a.makp = b.makp left join his.btdbn c on a.mabn = c.mabn where soto = 1 and a.khthnhanba = 1 and nhanba = 1 and loaiba = 5";
            dsng = m.merge(dsng, m.get_data(sql22));//19/06/2018
            //dsng.Merge(m.get_data(sql22),false);
            #region Gán Datasource
            //Nguyễn Văn Long - 17/11/09
            //dataGrid4.DataSource = dsng.Tables[0]; 
            //CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource, dataGrid4.DataMember];
            //DataView dv = (DataView)cm.List;
            _bs.AllowNew = false;
            _bs.DataSource = dsng.Tables[0];
            dataGrid4.DataSource = _bs;

            //DataView dv = (DataView)_bs.DataSource;

            #endregion



            //dv.AllowNew = false;
        }

        private void load_grid()
        {
            sql = "select " + l_maql + " as maql,id,ten,'' as ghichu from dmthieuhoso order by id";
            dst = m.get_data(sql);
            dst.Tables[0].Columns.Add("Chon", typeof(bool)).DefaultValue = false;
            foreach (DataRow r in dst.Tables[0].Rows)
            {
                r["chon"] = false;
                r["ghichu"] = string.Empty;
            }
            DataRow r1;
            foreach (DataRow r in m.get_data("select * from ba_luutruthieu where maql=" + l_maql).Tables[0].Rows)
            {
                r1 = m.getrowbyid(dst.Tables[0], "id=" + int.Parse(r["id"].ToString()));
                if (r1 != null)
                {
                    r1["ghichu"] = r["ghichu"].ToString();
                    r1["chon"] = true;
                }
            }
            dataGrid2.DataSource = dst.Tables[0];
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource, dataGrid2.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
        }

        private void AddGridTableStyle4()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dsng.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.FromArgb(255, 0, 128, 192);
            ts.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ts.HeaderForeColor = Color.White;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mabn";
            TextCol.HeaderText = "Mã BN";
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Họ tên";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "namsinh";
            TextCol.HeaderText = "Ngày sinh";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "soluutru";
            TextCol.HeaderText = "Số lưu trữ";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngaynhan";
            TextCol.HeaderText = "Ngày nhận";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngayvv";
            TextCol.HeaderText = "Ngày vào";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngayrv";
            TextCol.HeaderText = "Ngày ra";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Khoa";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);
        }

        private void AddGridTableStyle2()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dst.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.FromArgb(255, 0, 128, 192);
            ts.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ts.HeaderForeColor = Color.White;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "chon";
            discontinuedCol.HeaderText = "...";
            discontinuedCol.Width = 20;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid2.TableStyles.Add(ts);

            FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "id";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid2.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Nội dung";
            TextCol1.Width = 300;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid2.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ghichu";
            TextCol1.HeaderText = "Ghi chú";
            TextCol1.Width = 300;
            TextCol1.ReadOnly = false;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid2.TableStyles.Add(ts);
        }

        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid2[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = new SolidBrush(Color.Blue);
                else if (e.Column > 0 && e.Row == this.dataGrid2.CurrentRowIndex)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont;
                }
            }
            catch { }
        }

        private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            this.dataGrid2.EndEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
            RefreshRow(e.Row);
            this.dataGrid2.BeginEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
        }

        private void RefreshRow(int row)
        {
            Rectangle rect = this.dataGrid2.GetCellBounds(row, 0);
            rect = new Rectangle(rect.Right, rect.Top, this.dataGrid2.Width, rect.Height);
            this.dataGrid2.Invalidate(rect);
        }

        private void enable_obj(bool ena)
        {
            if (i_tabpage == 1)
            {
                ngaymuon.Enabled = ena;
                mabs.Enabled = ena;
                tenbs.Enabled = ena;
                txtghichu.Enabled = ena;

                chktraba.Enabled = true;
                ngaytra.Enabled = false;
                ngaymuon.Focus();
            }
            else
            {
                if (chktudongtang.Checked) txtsoluutru.Enabled = false;
                else txtsoluutru.Enabled = ena;
                //txtmabn1.Enabled = ena;
                txtmabn2.Enabled = ena;
                if (cbongayvao.Items.Count > 1) cbongayvao.Enabled = true;
                else cbongayvao.Enabled = ena;
                txthoten.Enabled = false;
                //cbobenhan.Enabled = ena;
                dataGrid3.Enabled = !ena;
            }
        }

        private void ena_detail(bool ena)
        {
            chkTainan.Enabled = txtxq.Enabled = ena;
            txtct.Enabled = txtsa.Enabled = txtxn.Enabled = txtdt.Enabled = txtkhac.Enabled = mri.Enabled = ylenh.Enabled = chamsoc.Enabled = ena;
            if (!chkzum.Checked) txthoso.Enabled = ena;
            txtnguoigiao.Enabled = txtmang.Enabled = txtnguoinhan.Enabled = txtmann.Enabled = ngaynhan.Enabled = makho.Enabled = ena;
            if (bVitritudong == false) txtvitri.Enabled = txttang.Enabled = txto.Enabled = slbGia.Enabled = slbTang.Enabled = slbO.Enabled = ena;
        }

        private void ena_button(bool ena)
        {
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butIn.Enabled = !ena;
            butHuy.Enabled = !ena;
            butKetthuc.Enabled = !ena;
        }

        private void empty_obj()
        {
           // if (!chktudongtang.Checked) txtsoluutru.Text = "";
            txtmabn2.Text = txthoten.Text = txtvitri.Text = txttang.Text = txto.Text = maicd_nn.Text = icd_nn.Text = txtMaDoiTuong.Text = txtSoRaVien.Text = "";
            #region Vannq 18/11/2017
            slbGia.txtTen.Text = slbTang.txtTen.Text = slbO.txtTen.Text = "";
            maicd_vao.Text = maicd_ravien.Text = icd_vao.Text = icd_ravien.Text = "";
            #endregion
            txtxq.Value = txtct.Value = txtsa.Value = txtxn.Value = txtdt.Value = txtkhac.Value = 0;
            txthoso.Text = txtmang.Text = txtnguoigiao.Text = txtnguoinhan.Text = txtmann.Text = "";
            mri.Value = ylenh.Value = chamsoc.Value = txtxq.Value = txtct.Value = txtsa.Value = txtxn.Value = txtkhac.Value = 0;
            txttinhtranghoso.Text = ngayravien.Text = mabs.Text = tenbs.Text = txtghichu.Text = lblmakp.Text = "";
            //muon ho so			
            if (makho.Items.Count > 0) makho.SelectedIndex = 0;
            chkTainan.Checked = chktraba.Checked = false;
        }

        private void empty_detail()
        {
            ngaynhan.Value = _Utility.StringToDateTime(m.Ngaygio);
            if (makho.Items.Count > 0) makho.SelectedIndex = 0;
            txtvitri.Text = txttang.Text = txto.Text = txthoso.Text = txtmang.Text = txtnguoigiao.Text = txtnguoinhan.Text =  txtmann.Text = "";
            #region Vannq 18/11/2017
            slbGia.txtTen.Text = slbTang.txtTen.Text = slbO.txtTen.Text = "";
            #endregion
            //txtxq.Value = txtct.Value = txtsa.Value = txtdt.Value = txtxn.Value = txtkhac.Value = mri.Value = chamsoc.Value = ylenh.Value = txtxq.Value = txtct.Value = txtsa.Value = txtxn.Value = txtkhac.Value = 0;
            //muon ho so			
            mabs.Text = tenbs.Text = txtghichu.Text = "";
            if (makho.Items.Count > 0) makho.SelectedIndex = 0;
            chkTainan.Checked = chktraba.Checked = false;
        }

        private void empty_muon()
        {
            mabs.Text = "";
            tenbs.Text = "";
            txtghichu.Text = "";
            chktraba.Checked = false;
            dataGrid1.DataSource = null;
        }

        private void get_tongsoba()
        {
            //lay tong so benh an tai phong luu tru/nam: theo ngay ra vien
            string s_yy = ngayravien.Text.Substring(8, 2);
            l_sttnam = get_sttba(s_yy);
            decimal tmp_stt = l_sttnam - 1;
            txttsbanam.Text = tmp_stt.ToString() + "/" + s_yy;
        }

        private bool load_mabn()
        {
            bool ret = false;
            foreach (DataRow r in m.get_data("select * from btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
            {
                txthoten.Text = r["hoten"].ToString();
                //namsinh.Text=r["namsinh"].ToString();
                ret = true;
                break;
            }
            return ret;
        }

        private bool load_vv_mabn()
        {
            l_maql = 0;
            foreach (DataRow r in m.get_data("select * from benhandt where loaiba=1 and mabn='" + s_mabn + "'" + " order by ngay desc").Tables[0].Rows)
            {
                l_maql = long.Parse(r["maql"].ToString());
            }
            return true;
        }

        private void load_dm()
        {
            sql = "select ma,hoten from dmbs where nhom not in (9)";
            sql += " union all ";
            sql += "select makp as ma,tenkp as hoten from btdkp_bv ";
            dtbs = m.get_data(sql).Tables[0];
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            listBS.DataSource = dtbs;
            //
            makho.DisplayMember = "ten";
            makho.ValueMember = "id";
            makho.DataSource = m.get_data("select * from ba_kho").Tables[0];

            makhotim.DisplayMember = "ten";
            makhotim.ValueMember = "id";
            makhotim.DataSource = m.get_data("select * from ba_kho").Tables[0];
            makhotim.SelectedIndex = -1;
            //
            listBS1.DisplayMember = "MA";
            listBS1.ValueMember = "HOTEN";
            listBS1.DataSource = dtbs.Copy();
            cbongayvao.DisplayMember = "NGAYVV";
            cbongayvao.ValueMember = "MAQL";
            //
            dtkp = m.get_data("select * from btdkp_bv where loai in(0,4) order by makp").Tables[0];
            cboKhoa.DisplayMember = "TENKP";
            cboKhoa.ValueMember = "MAKP";
            cboKhoa.DataSource = dtkp;
            cboKhoa.SelectedIndex = -1;
            //
            cboDoituong.DisplayMember = "DOITUONG";
            cboDoituong.ValueMember = "MADOITUONG";
            cboDoituong.DataSource = m.get_data("select * from doituong where hide=0 order by madoituong").Tables[0];
            cboDoituong.SelectedIndex = -1;
            //
            cboKetqua.DisplayMember = "TEN";
            cboKetqua.ValueMember = "MA";
            cboKetqua.DataSource = m.get_data("select * from ketqua order by ma").Tables[0];
            //
            cboTtLucrv.DisplayMember = "TEN";
            cboTtLucrv.ValueMember = "MA";
            cboTtLucrv.DataSource = m.get_data("select * from ttxk order by ma").Tables[0];
            //
            userid.DisplayMember = "hoten";
            userid.ValueMember = "id";
            userid.DataSource = m.get_data("select * from dlogin order by hoten").Tables[0];
            //
            userid.SelectedIndex = cboGioitinh_tim.SelectedIndex = -1;
            cboTinhtrang.SelectedIndex = 0;

        }

        private void Filt_tenbs(string ten, List list)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private string get_thoigian_bn(string mabn)
        {
            string _str = "";
            try
            {
                _str = m.get_data("select nam from " + m.user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                m.execute_data("update " + m.user + ".btdbn set nam=to_char(ngayud,'mmyy')||'+' where mabn='" + mabn + "'");
                foreach (DataRow r in m.get_data("select nam from " + m.user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows)
                    _str = r["nam"].ToString();
            }
            return _str;
        }

        private bool load_hosoba(string smabn, long maql, int tIndex)
        {
            DataTable ldt;
            bool bln = false;
            string sql1 = "", sql2 = "", sql3 = "", sql4 = "";
            string s_nam = get_thoigian_bn(smabn);
            string[] val = s_nam.Trim().Trim('+').Split('+');
            sql = "select maluutru,sort,maql,mabn,hoten, ngaysinh, namsinh, phai, tenkp,sltmedi,slthsba, ngayvv,maicd_vaovien,icd_vaovien,ngayrv,maicd_ravien,icd_ravien,ngayn, sttba,damuon,tenbs, gia,tang,vitri_o,soxq,soct,sosa,soxn,sodt,sokhac,tonghoso,nguoigiao,nguoinhan,loaiba,ttlucrv,ketqua,tainan,makho,mri,ylenh,chamsoc,madoituong,khthnhanba,makp,soravien from (";
            // 
            sql1 = " select e.maluutru,to_char(b.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,";
            sql1 += " b.maicd maicd_vaovien,b.chandoan icd_vaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayrv,a.maicd maicd_ravien,a.chandoan icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn,";
            sql1 += " nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, b.madoituong,d.khthnhanba,d.makp,d.soravien ";
            sql1 += " from " + m.user + ".xuatvien a, " + m.user + ".benhandt b, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
            sql1 += " where a.mabn=c.mabn and a.maql=b.maql and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp ";
            if (smabn != "") sql1 += " and a.mabn='" + smabn + "'";
            if (maql != 0) sql1 += " and a.maql=" + maql;
            //Phong luu
            if (s_nam.Trim() != "")
            {
                for (int i = 0; i < val.Length; i++)
                {
                    if (m.bMmyy(val[i].ToString()))
                    {
                        if (sql2 != "") sql2 += " union all ";
                        sql2 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
                        sql2 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc,a.madoituong,d.khthnhanba,d.makp,d.soravien  ";
                        sql2 += " from " + m.user + val[i].ToString() + ".benhancc a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql2 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                        if (smabn != "") sql2 += " and a.mabn='" + smabn + "'";
                        if (maql != 0) sql2 += " and a.maql=" + maql;
                    }
                }
            }
            //End Phong luu

            //Ngoai tru
            sql3 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,a.soluutru sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
            sql3 += " a.maicdrv maicd_ravien,a.chandoanrv icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,a.ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba,d.makp,d.soravien  ";
            sql3 += " from " + m.user + ".benhanngtr a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f ";
            sql3 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";

            ///
            if (smabn != "") sql3 += " and a.mabn='" + smabn + "'";
            if (maql != 0) sql3 += " and a.maql=" + maql;
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
                        sql4 += " select e.maluutru,to_char(a.ngay,'yyyymmdd') sort,a.maql,a.mabn,c.hoten, c.ngaysinh, c.namsinh, c.phai, e.tenkp,'' as sltmedi,d.soluutru slthsba, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.maicd maicd_vaovien,a.chandoan icd_vaovien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,";
                        sql4 += " null as maicd_ravien,null as icd_ravien,to_char(nvl(d.ngaynhan,sysdate),'dd/mm/yyyy hh24:mi')  as ngayn, nvl(d.stt,-1) as sttba,decode(f.id,null,0,1) as damuon,nvl(f.hoten,' ') tenbs, d.gia,d.tang,d.vitri_o,d.soxq,d.soct,d.sosa,d.soxn,d.sodt,d.sokhac,d.tonghoso,d.nguoigiao,d.nguoinhan,d.loaiba,a.ttlucrv,0 as ketqua,d.tainan,d.makho,d.mri,d.ylenh,d.chamsoc, a.madoituong,d.khthnhanba,d.makp,d.soravien  ";
                        sql4 += " from " + m.user + val[i].ToString() + ".benhanpk a, " + m.user + ".btdbn c, " + m.user + ".ba_luutru d , " + m.user + ".btdkp_bv e, (select b.hoten,a.* from " + m.user + ".ba_muon a," + m.user + ".dmbs b where a.mabs=b.ma and a.ngaytra is null) f";
                        sql4 += " where a.mabn=c.mabn and a.maql=d.maql(+) and a.maql=f.maql(+) and a.makp=e.makp and a.ngayrv is not null ";
                        if (smabn != "") sql4 += " and a.mabn='" + smabn + "'";
                        if (maql != 0) sql4 += " and a.maql=" + maql;
                    }
                }
            }
            #endregion
            //End Phong kham
            switch (cbobenhan.SelectedIndex)
            {
                #region code củ
                case 1: sql += sql3 + ")  a order by sort desc"; break;
                #endregion

                #region 10/11/2017 Vannq Lấy bệnh nhân trong bang benhnhanpkmmyy
                case 5:
                    {
                        //if (s_nam.Trim() == "") sql += sql3 + ")  a order by sort desc";
                        if (s_nam.Trim() != "") sql += sql4 + ")  a order by sort desc"; break;
                    }
                #endregion
                case 2: sql += sql2 + ")  a order by sort desc"; break;
                case 0: sql += sql1 + ")  a order by sort desc"; break;
                default: sql += sql1 + " union all " + sql2 + ")  a where a.ttlucrv=7 order by sort desc"; break;
            }
            try
            {
                ldt = m.get_data(sql).Tables[0];
            }
            catch
            {
                ldt = null;
            }
            if (cbobenhan.SelectedIndex == 5)
            {

                string sql22 = "select null as maluutru,null as sort,a.maql,a.mabn,c.hoten,c.ngaysinh,c.namsinh, c.phai, b.tenkp,a.soluutru as sltmedi,null as slthsba, to_char(a.ngayvv,'dd/mm/yyyy hh24:mi') as ngayvv,a.icdvv as maicd_vaovien,a.chandoanvv as icd_vaovien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv,a.icdrv as maicd_ravien,a.chandoanrv as icd_ravien,a.ngaynhan as ngayn,decode(a.nhanba,null,-1,0) as  sttba,0 as damuon,null as tenbs, a.gia,a.tang,a.vitri_o,a.soxq,a.soct,a.sosa,a.soxn,a.sodt,a.sokhac,a.tonghoso,a.nguoigiao,a.nguoinhan,a.loaiba,a.tinhtrang as ttlucrv,a.ketqua,a.tainan,a.makho,a.mri,a.ylenh,a.chamsoc,0 as madoituong,a.khthnhanba,a.makp,a.soravien from his.ba_luutru a left join his.btdkp_bv b on a.makp = b.makp left join his.btdbn c on a.mabn = c.mabn where soto = 1 and a.khthnhanba = 1";
                if (smabn != "") sql22 += " and a.mabn='" + smabn + "'";
                if (maql != 0) sql22 += " and a.maql=" + maql;
                try
                {
                    ldt = m.merge(ldt, m.get_data(sql22).Tables[0]);
                }
                catch
                {
                    ldt = null;
                }
            }

            if (ldt == null || ldt.Rows.Count <= 0)
            {
                TA_MessageBox.MessageBox.Show("Không tìm thấy bệnh nhân này !");
                butBoqua_Click(null, null);
                return false;
            }
            if (m.getrowbyid(ldt, "ttlucrv=7") != null && (cbobenhan.SelectedIndex == 0 || cbobenhan.SelectedIndex == 1 || cbobenhan.SelectedIndex == 2))
            {
                TA_MessageBox.MessageBox.Show("Bệnh nhân đã tử vong ! Hãy chọn bệnh án tử vong !");
                cbobenhan.Focus();
                cbobenhan.DroppedDown = true;
                //return false;
            }
            //if (maql == 0)
            //{
            //    cbongayvao.DataSource = ldt;
            //    if (cbongayvao.SelectedIndex != -1)
            //        cbongayvao.SelectedIndex = 0;
            //}
            cbongayvao.DataSource = ldt;
            if (cbongayvao.SelectedIndex != -1)
                cbongayvao.SelectedIndex = 0;
            foreach (DataRow r in ldt.Rows)
            {
                s_mabn = r["mabn"].ToString();
                txtmabn2.Text = s_mabn;
                maluutru = r["maluutru"].ToString();
                txthoten.Text = r["hoten"].ToString();
                txtnamsinh.Text = (r["ngaysinh"].ToString() == "") ? r["namsinh"].ToString() : r["ngaysinh"].ToString();
                cboGioitinh.SelectedIndex = int.Parse(r["phai"].ToString());
                ngayravien.Text = r["ngayrv"].ToString();
                lblmakp.Text = r["tenkp"].ToString();
                maicd_vao.Text = r["maicd_vaovien"].ToString();
                icd_vao.Text = r["icd_vaovien"].ToString();
                maicd_ravien.Text = r["maicd_ravien"].ToString();
                icd_ravien.Text = r["icd_ravien"].ToString();
                txttinhtranghoso.Text = (r["sttba"].ToString() == "0") ? "" : "";
                l_maql = long.Parse(r["maql"].ToString());
                foreach (DataRow r1 in m.get_data("select * from " + m.user + ".cdnguyennhan where maql=" + l_maql).Tables[0].Rows)
                {
                    maicd_nn.Text = r1["maicd"].ToString();
                    icd_nn.Text = r1["chandoan"].ToString();
                    break;
                }
                cboTtLucrv.SelectedValue = r["ttlucrv"].ToString();
                cboKetqua.SelectedValue = r["ketqua"].ToString();
                //
                //lấy bhyt
                txtMaDoiTuong.Text = r["madoituong"].ToString();

                #region 21/11/2017 Vannq Lấy thông tin số tờ lưu trữ khi xuất viện
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

                #endregion

                if (r["sttba"].ToString() != "-1")
                {
                    bln = true;
                    try
                    {
                        ngaynhan.Text = r["ngayn"].ToString();
                    }
                    catch
                    {
                        ngaynhan.Value = DateTime.ParseExact(r["ngayn"].ToString(),"dd/MM/yyyy HH:mm",null);
                    }
                    chkTainan.Checked = r["tainan"].ToString() == "1";
                    #region 21/11/2017 Vannq code cũ
                    //txtxq.Value=decimal.Parse(r["soxq"].ToString());
                    // mri.Value = decimal.Parse(r["mri"].ToString());
                    //ylenh.Value = decimal.Parse(r["ylenh"].ToString());
                    //chamsoc.Value = decimal.Parse(r["chamsoc"].ToString());

                    //txtct.Value=decimal.Parse(r["soct"].ToString());
                    //txtsa.Value=decimal.Parse(r["sosa"].ToString());
                    //txtxn.Value=decimal.Parse(r["soxn"].ToString());
                    //txtdt.Value = decimal.Parse(r["sodt"].ToString());
                    //txtkhac.Value=decimal.Parse(r["sokhac"].ToString());
                    //txthoso.Text=r["tonghoso"].ToString();
                    #endregion
                    txtmang.Text = r["nguoigiao"].ToString();
                    txtmang_Validated(null, null);
                    txtmann.Text = r["nguoinhan"].ToString();
                    txtmann_Validated(null, null);
                    #region code cũ
                    //txtvitri.Text = r["gia"].ToString();
                    //txttang.Text = r["tang"].ToString();
                    //txto.Text = r["vitri_o"].ToString(); 
                    #endregion

                    #region Vannq 18/11/2017
                    slbGia.txtTen.Text = Text = r["gia"].ToString();
                    slbTang.txtTen.Text = r["tang"].ToString();
                    slbO.txtTen.Text = r["vitri_o"].ToString();
                    #endregion

                    makho.SelectedValue = r["makho"].ToString();
                    b_nhanba = true;
                    b_damuon = r["damuon"].ToString() == "1";
                    if (r["tenbs"].ToString().Trim() != "")
                        txttinhtranghoso.Text = r["tenbs"].ToString() + " [MƯỢN]!";
                    else
                        txttinhtranghoso.Text = "Hồ sơ đã nhập kho!";
                    txtsoluutru.Text = r["slthsba"].ToString() != "" ? r["slthsba"].ToString() : r["sltmedi"].ToString();
                    txtSoRaVien.Text = r["soravien"].ToString() != "" ? r["soravien"].ToString() : r["slthsba"].ToString();
                    //cbobenhan.SelectedIndex = int.Parse(r["loaiba"].ToString());
                    if (i_tabpage == 0)
                    {
                        ena_button(false);
                        enable_obj(false);
                        ena_detail(false);
                    }
                }
                else
                {
                    b_nhanba = false;
                    txttinhtranghoso.Text = "Khoa '" + r["tenkp"].ToString() + "' chưa trả bệnh án.";
                    #region code cũ
                    //if (!chktudongtang.Checked)
                    //{
                    //    if (txtsoluutru.Text.Trim() == "")
                    //        txtsoluutru.Text = r["sltmedi"].ToString();
                    //} 
                    //else txtsoluutru.Text = get_soluutru(DateTime.Now.Year.ToString()).ToString().PadLeft(6, '0') + "/" + DateTime.Now.Year.ToString().Substring(2);
                    #endregion
                    #region Vannq 28/12/17 Lấy số lưu tru bên xuất viện
                    if (r["sltmedi"].ToString().Trim() != "")
                    {
                        txtsoluutru.Text = get_soluutru();
                        txtSoRaVien.Text = r["sltmedi"].ToString();
                    }
                    else
                    {
                        //  txtsoluutru.Text = get_soluutru(DateTime.Now.Year.ToString()).ToString().PadLeft(6, '0') + "/" + DateTime.Now.Year.ToString().Substring(2);
                        txtsoluutru.Text = get_soluutru();
                        txtSoRaVien.Text = get_soluutru();
                    }
                    #endregion
                    if (cbongayvao.Items.Count > 1 && i_tabpage == 0)
                    {
                        ena_button(true);
                        ena_detail(true);
                        if (!txtsoluutru.Enabled && !chktudongtang.Checked)
                        {
                            txtsoluutru.Enabled = true;
                           // txtsoluutru.Text = "";
                            txtSoRaVien.Text = "";
                            txtsoluutru.Focus();
                        }
                    }
                }
                //
                break;
            }
            if (!bln) empty_detail();
            return true;
        }

        private bool kiemtra_soluutru(string soluutru)
        {
            sql = "select soluutru from " + m.user + ".ba_luutru where soluutru='" + soluutru + "' and loaiba=" + cbobenhan.SelectedIndex;
            if (m.get_data(sql).Tables[0].Rows.Count > 0) return true;
            else return false;
        }

        private string get_soluutru()
        {
            int soluutru = 0;
            string str = "";
            if (cbobenhan.SelectedIndex == 0) str = "I";
            else if (cbobenhan.SelectedIndex == 3 || cbobenhan.SelectedIndex == 4) str = "T";
            else str = "O";
            try
            {
                //sql = "select nvl(max(to_number(substr(soluutru,1,instr(soluutru,'/')-1))),0) soluutru from medibv.ba_luutru where loaiba=" + cbobenhan.SelectedIndex + " and to_char(ngaynhan,'yyyy')='" + yyyy + "'";
                sql = "select nvl(max(to_number(substr(soluutru,8,4))),0) soluutru from " + m.user + ".ba_luutru ";
                sql += "where loaiba=" + cbobenhan.SelectedIndex + " and to_char(ngaynhan,'dd/mm/yyyy')='" + DateTime.Now.ToString("dd/MM/yyyy") + "'";
                soluutru = int.Parse(m.get_data(sql).Tables[0].Rows[0]["soluutru"].ToString());
            }
            catch { }
            return str + DateTime.Now.ToString("yyMMdd") + (soluutru + 1).ToString().PadLeft(4, '0');
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

        private void load_grid_muonba()
        {
            sql = "select b.hoten, to_char(b.ngaysinh,'dd/mm/yyyy') as ngaysinh, b.namsinh, b.phai,c.hoten as tenbs, to_char(a.ngaymuon,'dd/mm/yyyy hh24:mi') as ngaym,a.*";
            sql += " from " + m.user + ".ba_muon a, " + m.user + ".btdbn b, " + m.user + ".dmbs c";
            sql += " where a.mabn=b.mabn and a.mabs=c.ma and a.datra=0";
            dtm = m.get_data(sql);
            dataGrid1.DataSource = dtm.Tables[0];
            ref_text();
        }

        private bool load_ttba(decimal l_maql)
        {
            l_id = 0;
            bool bln = false;
            sql = "select b.hoten, to_char(b.ngaysinh,'dd/mm/yyyy') as ngaysinh, b.namsinh, b.phai,c.hoten as tenbs, to_char(a.ngaymuon,'dd/mm/yyyy hh24:mi') as ngaym, a.*";
            sql += " from " + m.user + ".ba_muon a, " + m.user + ".btdbn b, " + m.user + ".dmbs c";
            sql += " where a.mabn=b.mabn and a.mabs=c.ma and a.datra=0 and a.maql=" + l_maql;
            DataTable ldt = m.get_data(sql).Tables[0];
            dataGrid1.DataSource = ldt;
            ref_text();
            return bln = ldt.Rows.Count > 0;
        }

        private void AddGridTableStyle()
        {
            DataGridColoredTextBoxColumn TextCol;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtm.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.FromArgb(255, 0, 128, 192);
            ts.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ts.HeaderForeColor = Color.White;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            TextCol = new DataGridColoredTextBoxColumn(de, 0);
            TextCol.MappingName = "ID";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 1);
            TextCol.MappingName = "soluutru";
            TextCol.HeaderText = "Số lưu trữ";
            TextCol.Width = 70;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 2);
            TextCol.MappingName = "mabn";
            TextCol.HeaderText = "Mã BN";
            TextCol.Width = 65;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 3);
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Họ & Tên";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 4);
            TextCol.MappingName = "Namsinh";
            TextCol.HeaderText = "Năm sinh";
            TextCol.Width = 70;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 5);
            TextCol.MappingName = "tenbs";
            TextCol.HeaderText = "Bác sĩ mượn";
            TextCol.Width = 120;
            TextCol.NullText = String.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 6);
            TextCol.MappingName = "ngaym";
            TextCol.HeaderText = "Ngày mượn";
            TextCol.Width = 100;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "ghichu";
            TextCol.HeaderText = "Ghi chú";
            TextCol.Width = 180;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

        }

        private void AddGridTableStyle3()
        {
            dataGrid3.TableStyles.Clear();
            DataGridColoredTextBoxColumn TextCol;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtt.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.FromArgb(255, 0, 128, 192);
            ts.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ts.HeaderForeColor = Color.White;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            TextCol = new DataGridColoredTextBoxColumn(de, 0);
            TextCol.MappingName = "maql";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.NullText = String.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 1);
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Khoa/phòng";
            TextCol.Width = 120;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 2);
            TextCol.MappingName = "soluutru";
            TextCol.HeaderText = "Số lưu trữ";
            TextCol.Width = 70;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 3);
            TextCol.MappingName = "mabn";
            TextCol.HeaderText = "Mã BN";
            TextCol.Width = 65;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 4);
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Họ & Tên";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 5);
            TextCol.MappingName = "Namsinh";
            TextCol.HeaderText = "Năm sinh";
            TextCol.Width = 70;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 6);
            TextCol.MappingName = "Gioitinh";
            TextCol.HeaderText = "Giới tính";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "diachi";
            TextCol.HeaderText = "Địa chỉ";
            TextCol.Width = 300;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 8);
            TextCol.MappingName = "Doituong";
            TextCol.HeaderText = "Đối tượng";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 9);
            TextCol.MappingName = "sttba";
            TextCol.HeaderText = "STT";
            TextCol.Width = 0;
            TextCol.NullText = String.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 10);
            TextCol.MappingName = "gia";
            TextCol.HeaderText = "Giá";
            TextCol.Width = 40;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 11);
            TextCol.MappingName = "tang";
            TextCol.HeaderText = "Tầng";
            TextCol.Width = 40;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 12);
            TextCol.MappingName = "vitri_o";
            TextCol.HeaderText = (bVitritudong) ? "STT" : "Ô";
            TextCol.Width = 40;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 13);
            TextCol.MappingName = "ngayvv";
            TextCol.HeaderText = "Ngày vào";
            TextCol.Width = 100;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 14);
            TextCol.MappingName = "ngayrv";
            TextCol.HeaderText = "Ngày ra";
            TextCol.Width = 100;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            //khanh
            TextCol = new DataGridColoredTextBoxColumn(de, 15);
            TextCol.MappingName = "bacsimuon";
            TextCol.HeaderText = "Người mượn";
            TextCol.Width = 150;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 16);
            TextCol.MappingName = "ngaymuon";
            TextCol.HeaderText = "Ngày mượn";
            TextCol.Width = 100;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 17);
            TextCol.MappingName = "ngaytra";
            TextCol.HeaderText = "Ngày trả";
            TextCol.Width = 100;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 18);
            TextCol.MappingName = "tenkho";
            TextCol.HeaderText = "Kho";
            TextCol.Width = 85;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 19);
            TextCol.MappingName = "chandoan";
            TextCol.HeaderText = "Chẩn đoán";
            TextCol.Width = 300;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 20);
            TextCol.MappingName = "maicd";
            TextCol.HeaderText = "ICD10";
            TextCol.Width = 60;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 21);
            TextCol.MappingName = "ngayn";
            TextCol.HeaderText = "Ngày nhận HSBA";
            TextCol.Width = 120;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 22);
            TextCol.MappingName = "ngayud";
            TextCol.HeaderText = "Ngày nhập liệu";
            TextCol.Width = 120;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 23);
            TextCol.MappingName = "tenuser";
            TextCol.HeaderText = "Người nhập liệu";
            TextCol.Width = 150;
            TextCol.NullText = String.Empty;
            TextCol.Alignment = HorizontalAlignment.Left;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);
        }

        private void ref_text()
        {
            try
            {
                i_row = dataGrid1.CurrentCell.RowNumber;
                l_id = long.Parse(dataGrid1[i_row, 0].ToString());
                DataRow r = m.getrowbyid(dtm.Tables[0], "id=" + l_id);
                if (r != null)
                {
                    txtghichu.Text = r["ghichu"].ToString();
                    if (l_maql == 0)
                    {
                        s_mabn = r["mabn"].ToString();
                        txtmabn2.Text = s_mabn;
                        txtmabn2_Validated(null, null);
                    }
                    txttinhtranghoso.Text = r["tenbs"].ToString() + " [MƯỢN]!";
                    mabs.Text = r["mabs"].ToString();
                    mabs_Validated(null, null);
                    enable_obj(false);
                    ena_button(true);
                }
            }
            catch { }
        }

        private void ref_text3()
        {
            try
            {
                i_row = dataGrid3.CurrentCell.RowNumber;
                l_maql = long.Parse(dataGrid3[i_row, 0].ToString());
                decimal _maql = l_maql;
                enable_obj(false);
               // txtsoluutru.Text = dataGrid3[i_row, 2].ToString();//r["soluutru"].ToString();2
                txtSoRaVien.Text = dataGrid3[i_row, 2].ToString();//r["soluutru"].ToString();2
                s_mabn = dataGrid3[i_row, 3].ToString();//r["mabn"].ToString();3
                txtmabn2.Text = s_mabn;
                txtmabn2_Validated(null, null);
                string ng = dataGrid3[i_row, 13].ToString();//r["ngaymuon"].ToString();13
                if (ng.Trim().Length == 16)
                    ngaymuon.Value = new DateTime(int.Parse(ng.Substring(6, 4)), int.Parse(ng.Substring(3, 2)), int.Parse(ng.Substring(0, 2)), int.Parse(ng.Substring(11, 2)), int.Parse(ng.Substring(14, 2)), 0);

                if (cbongayvao.Items.Count > 0)
                {
                    cbongayvao.SelectedValue = _maql.ToString();
                    load_hosoba(txtmabn2.Text, long.Parse(cbongayvao.SelectedValue.ToString()), tabControl1.SelectedIndex);
                }

                load_grid();
            }
            catch { }
        }

        #region formatdatagrid

        public Color MyGetColorRowCol(int row, int col)
        {
            //if (this.dataGrid1[row,11].ToString().Trim()=="1") return Color.Red;
            //else if (this.dataGrid1[row,13].ToString().Trim()=="1") return Color.Blue;
            return Color.Black;
        }

        private void dataGrid1_Click(object sender, System.EventArgs e)
        {
            ref_text();
        }

        private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            ref_text();
        }

        private void butTim_Click(object sender, System.EventArgs e)
        {
            if (i_tabpage != 2) return;
            dtt.Clear();
            string ho = (hoten_t.Text == "") ? "" : _Utility.Hoten_khongdau(hoten_t.Text);
            string ten = (ten_t.Text == "") ? "" : _Utility.Hoten_khongdau(ten_t.Text);
            string s_tungay = "", s_denngay = "", dk = "";
            bool bBa_noitru = false, bBa_ngtru = false, bBa_pluu = false, bBa_pkham = false;
            switch (cbobenhan.SelectedIndex)
            {
                case 0: bBa_noitru = true; bBa_ngtru = false; bBa_pluu = false; bBa_pkham = false; break;
                case 1: bBa_noitru = false; bBa_ngtru = true; bBa_pluu = false; bBa_pkham = false; break;
                case 2: bBa_noitru = false; bBa_ngtru = false; bBa_pluu = true; bBa_pkham = false; break;
                case 5: bBa_noitru = false; bBa_ngtru = false; bBa_pluu = false; bBa_pkham = true; break;
                default: dk = " and a.ttlucrv=7 "; bBa_noitru = true; bBa_ngtru = true; bBa_pluu = true; break;
            }
            if (userid.SelectedIndex != -1) dk += " and d.userid=" + long.Parse(userid.SelectedValue.ToString());
            if (chkthieu.Checked) dk += " and d.maql=thieu.maql ";
            else dk += " and d.maql=thieu.maql(+) ";
            if (maicd.Text != "") dk += " and a.maicd like '%" + maicd.Text + "%'";
            if (makhotim.SelectedIndex != -1) dk += " and d.makho=" + int.Parse(makhotim.SelectedValue.ToString());
            if (diachi.Text != string.Empty) dk += " and (trim(c.sonha)='" + diachi.Text.Trim() + "' or trim(c.thon)='" + diachi.Text + "')";
            #region Code cũ
            //if (bBa_noitru) dtt = tim_hosoluutru(soluutru_t.Text, mabn_t.Text, ho, ten, namsinh_t.Text, gia_t.Text, tang_t.Text, o_t.Text, tungay.Text, denngay.Text, (cboKhoa.SelectedIndex != -1) ? cboKhoa.SelectedValue.ToString() : "", dk, cboTinhtrang.SelectedIndex, (cboDoituong.SelectedIndex != -1) ? cboDoituong.SelectedValue.ToString() : "", (cboGioitinh_tim.SelectedIndex != -1) ? cboGioitinh_tim.SelectedIndex.ToString() : "", timngay.SelectedIndex);
            //if (bBa_ngtru) dtt.Merge(tim_hosoluutru_ngtru(soluutru_t.Text, mabn_t.Text, ho, ten, namsinh_t.Text, gia_t.Text, tang_t.Text, o_t.Text, tungay.Text, denngay.Text, (cboKhoa.SelectedIndex != -1) ? cboKhoa.SelectedValue.ToString() : "", dk, cboTinhtrang.SelectedIndex, (cboDoituong.SelectedIndex != -1) ? cboDoituong.SelectedValue.ToString() : "", (cboGioitinh_tim.SelectedIndex != -1) ? cboGioitinh_tim.SelectedIndex.ToString() : "", timngay.SelectedIndex));            
            #endregion
            #region gắn DM Vị trí Vannq 20/11/2017
            if (bBa_noitru) dtt = tim_hosoluutru(soluutru_t.Text, mabn_t.Text, ho, ten, namsinh_t.Text, slbGia1.txtTen.Text, slbTang1.txtTen.Text, slbO1.txtTen.Text, tungay.Text, denngay.Text, (cboKhoa.SelectedIndex != -1) ? cboKhoa.SelectedValue.ToString() : "", dk, cboTinhtrang.SelectedIndex, (cboDoituong.SelectedIndex != -1) ? cboDoituong.SelectedValue.ToString() : "", (cboGioitinh_tim.SelectedIndex != -1) ? cboGioitinh_tim.SelectedIndex.ToString() : "", timngay.SelectedIndex);
            if (bBa_ngtru) dtt.Merge(tim_hosoluutru_ngtru(soluutru_t.Text, mabn_t.Text, ho, ten, namsinh_t.Text, slbGia1.txtTen.Text, slbTang1.txtTen.Text, slbO1.txtTen.Text, tungay.Text, denngay.Text, (cboKhoa.SelectedIndex != -1) ? cboKhoa.SelectedValue.ToString() : "", dk, cboTinhtrang.SelectedIndex, (cboDoituong.SelectedIndex != -1) ? cboDoituong.SelectedValue.ToString() : "", (cboGioitinh_tim.SelectedIndex != -1) ? cboGioitinh_tim.SelectedIndex.ToString() : "", timngay.SelectedIndex));

            #endregion
            if ((tungay.Text == "" || denngay.Text == "") && cbobenhan.SelectedIndex != 0)
            {
                s_tungay = "01/" + DateTime.Now.AddMonths(-1).Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
                s_denngay = DateTime.DaysInMonth(int.Parse(DateTime.Now.Year.ToString()), int.Parse(DateTime.Now.Month.ToString())).ToString() + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
            }
            else
            {
                s_tungay = tungay.Text;
                s_denngay = denngay.Text;
            }
            #region code cũ
            //if (bBa_pluu) dtt.Merge(tim_hosoluutru_pluu(soluutru_t.Text, mabn_t.Text, ho, ten, namsinh_t.Text, gia_t.Text, tang_t.Text, o_t.Text, s_tungay, s_denngay, (cboKhoa.SelectedIndex != -1) ? cboKhoa.SelectedValue.ToString() : "", dk, cboTinhtrang.SelectedIndex, (cboDoituong.SelectedIndex != -1) ? cboDoituong.SelectedValue.ToString() : "", (cboGioitinh_tim.SelectedIndex != -1) ? cboGioitinh_tim.SelectedIndex.ToString() : "", timngay.SelectedIndex)); 
            #endregion
            #region Gắn danh mục vị trí Vannq 20/11/2017
            if (bBa_pluu) dtt.Merge(tim_hosoluutru_pluu(soluutru_t.Text, mabn_t.Text, ho, ten, namsinh_t.Text, slbGia1.txtTen.Text, slbTang1.txtTen.Text, slbO1.txtTen.Text, s_tungay, s_denngay, (cboKhoa.SelectedIndex != -1) ? cboKhoa.SelectedValue.ToString() : "", dk, cboTinhtrang.SelectedIndex, (cboDoituong.SelectedIndex != -1) ? cboDoituong.SelectedValue.ToString() : "", (cboGioitinh_tim.SelectedIndex != -1) ? cboGioitinh_tim.SelectedIndex.ToString() : "", timngay.SelectedIndex));
            if (bBa_pkham) dtt.Merge(tim_hosoluutru_pk(soluutru_t.Text, mabn_t.Text, ho, ten, namsinh_t.Text, slbGia1.txtTen.Text, slbTang1.txtTen.Text, slbO1.txtTen.Text, s_tungay, s_denngay, (cboKhoa.SelectedIndex != -1) ? cboKhoa.SelectedValue.ToString() : "", dk, cboTinhtrang.SelectedIndex, (cboDoituong.SelectedIndex != -1) ? cboDoituong.SelectedValue.ToString() : "", (cboGioitinh_tim.SelectedIndex != -1) ? cboGioitinh_tim.SelectedIndex.ToString() : "", timngay.SelectedIndex));
            #endregion


            if (chkthieu.Checked)
            {
                string sten, sghichu;
                foreach (DataRow r in dtt.Tables[0].Rows)
                {
                    sten = sghichu = string.Empty;
                    sql = "select b.ten,a.ghichu from ba_luutruthieu a,dmthieuhoso b where a.id=b.id and a.maql=" + long.Parse(r["maql"].ToString());
                    foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                    {
                        if (sten.IndexOf(r1["ten"].ToString()) == -1) sten += r1["ten"].ToString().Trim() + ";";
                        if (sghichu.IndexOf(r1["ghichu"].ToString()) == -1) sghichu += r1["ghichu"].ToString().Trim() + ";";
                    }
                    r["ghichu"] = (sghichu == string.Empty) ? sten : sghichu;
                }
            }
            dataGrid3.DataSource = dtt.Tables[0];
            dataGrid3.Enabled = true;
            AddGridTableStyle3();
            if (cboTinhtrang.SelectedIndex == 2)
                lbsobanhapkho.Text = "0/" + dtt.Tables[0].Rows.Count.ToString();
            else
                lbsobanhapkho.Text = get_tongsohslt().ToString() + "/" + dtt.Tables[0].Rows.Count.ToString();

        }

        private int get_tongsohslt()
        {
            int i_ts = 0;
            string fie;
            try
            {
                fie = (timngay.SelectedIndex == 0) ? "a.ngay" : (timngay.SelectedIndex == 1) ? "n.ngay" : (timngay.SelectedIndex == 2) ? "c.ngaynhan" : "c.ngayud";
                sql = "select c.gia,c.tang,c.vitri_o,to_char(d.ngaymuon,'dd/mm/yy') ngaymuon,to_char(d.ngaytra,'dd/mm/yy') ngaytra,x.ten as tenkho,c.makho,c.mri,c.ylenh,c.chamsoc ";
                sql += " from " + m.user + ".xuatvien a, " + m.user + ".ba_luutru c,(select * from " + m.user + ".ba_muon where ngaymuon is not null and ngaytra is null) d," + m.user + ".btdbn e," + m.user + ".benhandt n, " + m.user + ".ba_kho x";
                sql += " where a.mabn=e.mabn and a.maql=c.maql and c.maql=d.maql(+) and d.maql is null and a.maql=n.maql and a.mabn=n.mabn and c.makho=x.id(+)";
                if (tungay.Text != "" && denngay.Text != "") sql += " and to_date(" + fie + ",'dd/mm/yy') between to_date('" + tungay.Text + "','dd/mm/yy') and to_date('" + denngay.Text + "','dd/mm/yy')";
                if (soluutru_t.Text != "") sql += " and c.soluutru='" + soluutru_t.Text + "'";
                if (mabn_t.Text != "") sql += " and a.mabn='" + mabn_t.Text + "'";
                if (hoten_t.Text != "") sql += " and e.hotenkdau like '" + hoten_t.Text + "%'";
                if (ten_t.Text != "") sql += " and e.hotenkdau like '%" + ten_t.Text + "'";
                if (namsinh_t.Text != "") sql += " and e.namsinh ='" + namsinh_t.Text + "'";
                #region Code cũ
                //if (gia_t.Text != "") sql += " and c.gia='" + gia_t.Text + "'";
                //if (tang_t.Text != "") sql += " and c.tang='" + tang_t.Text + "'";
                //if (o_t.Text != "") sql += " and c.vitri_o='" + o_t.Text + "'"; 
                #endregion

                if (slbGia1.txtTen.Text != "") sql += " and c.gia='" + slbGia1.txtTen.Text + "'";
                if (slbTang1.txtTen.Text != "") sql += " and c.tang='" + slbTang1.txtTen.Text + "'";
                if (slbO1.txtTen.Text != "") sql += " and c.vitri_o='" + slbO1.txtTen.Text + "'";
                if (cboKhoa.SelectedIndex != -1) sql += " and a.makp='" + cboKhoa.SelectedValue.ToString() + "'";
                if (cboDoituong.SelectedIndex != -1) sql += " and n.madoituong='" + cboDoituong.SelectedValue.ToString() + "'";
                if (cboGioitinh_tim.SelectedIndex != -1) sql += " and e.phai='" + cboGioitinh_tim.SelectedIndex.ToString() + "'";
                if (userid.SelectedIndex != -1) sql += " and c.userid=" + long.Parse(userid.SelectedValue.ToString());
                i_ts += m.get_data(sql).Tables[0].Rows.Count;
            }
            catch { };
            //
            try
            {
                fie = (timngay.SelectedIndex == 0) ? "a.ngayrv" : (timngay.SelectedIndex == 1) ? "a.ngay" : (timngay.SelectedIndex == 2) ? "c.ngaynhan" : "c.ngayud";
                sql = "select c.gia,c.tang,c.vitri_o,to_char(d.ngaymuon,'dd/mm/yy') ngaymuon,to_char(d.ngaytra,'dd/mm/yy') ngaytra,x.ten as tenkho,c.makho,c.mri,c.ylenh,c.chamsoc ";
                sql += " from " + m.user + ".benhanngtr a, " + m.user + ".ba_luutru c,(select * from " + m.user + ".ba_muon where ngaymuon is not null and ngaytra is null) d," + m.user + ".btdbn e, " + m.user + ".ba_kho x";
                sql += " where a.mabn=e.mabn and a.maql=c.maql and a.ngayrv is not null and c.maql=d.maql(+) and d.maql is null and c.makho=x.id(+)";
                if (tungay.Text != "" && denngay.Text != "") sql += " and to_date(" + fie + ",'dd/mm/yy') between to_date('" + tungay.Text + "','dd/mm/yy') and to_date('" + denngay.Text + "','dd/mm/yy')";
                if (soluutru_t.Text != "") sql += " and c.soluutru='" + soluutru_t.Text + "'";
                if (mabn_t.Text != "") sql += " and a.mabn='" + mabn_t.Text + "'";
                if (hoten_t.Text != "") sql += " and e.hotenkdau like '" + hoten_t.Text + "%'";
                if (ten_t.Text != "") sql += " and e.hotenkdau like '%" + ten_t.Text + "'";
                if (namsinh_t.Text != "") sql += " and e.namsinh ='" + namsinh_t.Text + "'";

                #region Code cũ
                //if (gia_t.Text != "") sql += " and c.gia='" + gia_t.Text + "'";
                //if (tang_t.Text != "") sql += " and c.tang='" + tang_t.Text + "'";
                //if (o_t.Text != "") sql += " and c.vitri_o='" + o_t.Text + "'"; 
                #endregion

                #region Gắn danh mục Vị trí Vannq 20/11/2017
                if (slbGia1.txtTen.Text != "") sql += " and c.gia='" + slbGia1.txtTen.Text + "'";
                if (slbTang1.txtTen.Text != "") sql += " and c.tang='" + slbTang1.txtTen.Text + "'";
                if (slbO1.txtTen.Text != "") sql += " and c.vitri_o='" + slbO1.txtTen.Text + "'";
                #endregion

                if (cboKhoa.SelectedIndex != -1) sql += " and a.makp='" + cboKhoa.SelectedValue.ToString() + "'";
                if (cboDoituong.SelectedIndex != -1) sql += " and a.madoituong='" + cboDoituong.SelectedValue.ToString() + "'";
                if (cboGioitinh_tim.SelectedIndex != -1) sql += " and e.phai='" + cboGioitinh_tim.SelectedIndex.ToString() + "'";
                if (userid.SelectedIndex != -1) sql += " and c.userid=" + long.Parse(userid.SelectedValue.ToString());
                i_ts += m.get_data(sql).Tables[0].Rows.Count;
            }
            catch { };
            //
            string s_tungay = "", s_denngay = "";
            if (tungay.Text == "" || denngay.Text == "")
            {
                s_tungay = "01/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
                s_denngay = DateTime.DaysInMonth(int.Parse(DateTime.Now.Year.ToString()), int.Parse(DateTime.Now.Month.ToString())).ToString() + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString();
            }
            else
            {
                s_tungay = tungay.Text;
                s_denngay = denngay.Text;
            }
            try
            {
                fie = (timngay.SelectedIndex == 0) ? "a.ngayrv" : (timngay.SelectedIndex == 1) ? "a.ngay" : (timngay.SelectedIndex == 2) ? "c.ngaynhan" : "c.ngayud";
                sql = "select c.gia,c.tang,c.vitri_o,to_char(d.ngaymuon,'dd/mm/yy') ngaymuon,to_char(d.ngaytra,'dd/mm/yy') ngaytra,x.ten as tenkho,c.makho,c.mri,c.ylenh,c.chamsoc ";
                sql += " from xxx.benhancc a, " + m.user + ".ba_luutru c,(select * from " + m.user + ".ba_muon where ngaymuon is not null and ngaytra is null) d," + m.user + ".btdbn e, " + m.user + ".ba_kho x";
                sql += " where a.mabn=e.mabn and a.maql=c.maql and a.ngayrv is not null and c.maql=d.maql(+) and d.maql is null and c.makho=x.id(+)";
                if (tungay.Text != "" && denngay.Text != "") sql += " and to_date(" + fie + ",'dd/mm/yy') between to_date('" + tungay.Text + "','dd/mm/yy') and to_date('" + denngay.Text + "','dd/mm/yy')";
                if (soluutru_t.Text != "") sql += " and c.soluutru='" + soluutru_t.Text + "'";
                if (mabn_t.Text != "") sql += " and a.mabn='" + mabn_t.Text + "'";
                if (hoten_t.Text != "") sql += " and e.hotenkdau like '" + hoten_t.Text + "%'";
                if (ten_t.Text != "") sql += " and e.hotenkdau like '%" + ten_t.Text + "'";
                if (namsinh_t.Text != "") sql += " and e.namsinh ='" + namsinh_t.Text + "'";
                #region Code cũ
                //if (gia_t.Text != "") sql += " and c.gia='" + gia_t.Text + "'";
                //if (tang_t.Text != "") sql += " and c.tang='" + tang_t.Text + "'";
                //if (o_t.Text != "") sql += " and c.vitri_o='" + o_t.Text + "'"; 
                #endregion

                #region Gắn danh mục Vị trí Vannq 20/11/2017
                if (slbGia1.txtTen.Text != "") sql += " and c.gia='" + slbGia1.txtTen.Text + "'";
                if (slbTang1.txtTen.Text != "") sql += " and c.tang='" + slbTang1.txtTen.Text + "'";
                if (slbO1.txtTen.Text != "") sql += " and c.vitri_o='" + slbO1.txtTen.Text + "'";
                #endregion

                if (cboKhoa.SelectedIndex != -1) sql += " and a.makp='" + cboKhoa.SelectedValue.ToString() + "'";
                if (cboDoituong.SelectedIndex != -1) sql += " and a.madoituong='" + cboDoituong.SelectedValue.ToString() + "'";
                if (cboGioitinh_tim.SelectedIndex != -1) sql += " and e.phai='" + cboGioitinh_tim.SelectedIndex.ToString() + "'";
                if (userid.SelectedIndex != -1) sql += " and c.userid=" + long.Parse(userid.SelectedValue.ToString());
                i_ts += m.get_data_mmyy(sql, s_tungay, s_denngay, false).Tables[0].Rows.Count;
            }
            catch { };
            return i_ts;
        }

        private void dataGrid3_Click(object sender, System.EventArgs e)
        {
            //ref_text3();
        }

        private void dataGrid3_CurrentCellChanged(object sender, System.EventArgs e)
        {
            ref_text3();

        }

        private long get_sttba(string s_yy)
        {
            sql = "select count(*)+1 stt from " + m.user + ".ba_luutru a, " + m.user + ".xuatvien b," + m.user + ".ba_muon c where a.maql=b.maql and a.maql=c.maql(+) and c.id is null and to_char(b.ngay,'yy')='" + s_yy + "'";
            DataTable ldt = m.get_data(sql).Tables[0];
            return long.Parse(ldt.Rows[0][0].ToString());
        }

        private bool huy_ba_luutru(decimal lngmaql)
        {
            bool bln = false;
            sql = "select a.*,b.hoten from " + m.user + ".ba_muon a,dmbs b where a.mabs=b.ma and a.maql=" + lngmaql + " and a.datra=0";
            DataTable ldt = m.get_data(sql).Tables[0];
            if (ldt.Rows.Count <= 0)
            {
                sql = "delete from " + m.user + ".ba_luutru where maql=" + lngmaql;
                m.execute_data(sql);
                sql = "delete from " + m.user + ".ba_muon where maql=" + lngmaql;
                m.execute_data(sql);
                bln = true;
            }
            else m.MsgBox(ldt.Rows[0]["hoten"].ToString() + " đang mượn " + ldt.Rows[0]["ghichu"].ToString() + "!");
            return bln;
        }

        private long get_sttba_ngay(string s_ngay)
        {
            sql = "select count(*) as tongso from " + m.user + ".ba_luutru a where to_char(ngaynhan,'dd/mm/yyyy')='" + s_ngay + "'";
            DataTable ldt = m.get_data(sql).Tables[0];
            return long.Parse(ldt.Rows[0][0].ToString());
        }

        private void butIn_Click(object sender, System.EventArgs e)
        {
            string s_msg = "";
            if (!System.IO.Directory.Exists("..\\..\\xml")) System.IO.Directory.CreateDirectory("..\\..\\xml");
            if (i_tabpage == 1)//danh sach muon
            {
                dtm.WriteXml("..\\..\\xml\\ba_muon.xml", XmlWriteMode.WriteSchema);
                HISToltal.frmReport f = new HISToltal.frmReport(m, dtm, s_msg, "ba_muon.rpt");
                f.Show();
            }
            else if (i_tabpage == 2)//tim kiem
            {
                dtt.WriteXml("..\\..\\xml\\ba_tim.xml", XmlWriteMode.WriteSchema);
                HISToltal.frmReport f = new HISToltal.frmReport(m, dtt, s_msg, (chkthieu.Checked) ? "ba_thieu.rpt" : (cboTinhtrang.SelectedIndex == 1) ? "ba_danhapkho.rpt" : "ba_timkiem.rpt");
                f.Show();
            }
            else
            {
                DataSet dsp = m.get_data("select 0 as id from dual");
                dsp.Clear();
                dsp.Tables[0].Columns.Add("mabn");
                dsp.Tables[0].Columns.Add("soluutru");
                dsp.Tables[0].Columns.Add("hoten");
                dsp.Tables[0].Columns.Add("namsinh");
                dsp.Tables[0].Columns.Add("phai");
                dsp.Tables[0].Columns.Add("ngayvao");
                dsp.Tables[0].Columns.Add("ngayra");
                dsp.Tables[0].Columns.Add("chandoanvao");
                dsp.Tables[0].Columns.Add("chandoanra");
                dsp.Tables[0].Columns.Add("chandoannn");
                dsp.Tables[0].Columns.Add("ketqua");
                dsp.Tables[0].Columns.Add("tenkp");
                dsp.Tables[0].Columns.Add("ttlucrv");
                dsp.Tables[0].Columns.Add("soto");
                dsp.Tables[0].Columns.Add("soxq");
                dsp.Tables[0].Columns.Add("soct");
                dsp.Tables[0].Columns.Add("sosa");
                dsp.Tables[0].Columns.Add("soxn");
                dsp.Tables[0].Columns.Add("sokhac");
                dsp.Tables[0].Columns.Add("sodt");
                dsp.Tables[0].Columns.Add("mri");
                dsp.Tables[0].Columns.Add("ylenh");
                dsp.Tables[0].Columns.Add("chamsoc");

                dsp.Tables[0].Columns.Add("maphuongxa");
                dsp.Tables[0].Columns.Add("tenpxa");
                dsp.Tables[0].Columns.Add("maqu");
                dsp.Tables[0].Columns.Add("tenquan");
                dsp.Tables[0].Columns.Add("matt");
                dsp.Tables[0].Columns.Add("tentt");
                dsp.Tables[0].Columns.Add("sonha");
                dsp.Tables[0].Columns.Add("cholam");
                dsp.Tables[0].Columns.Add("diachi");

                dsp.Tables[0].Columns.Add("madoituong");


                DataRow r = dsp.Tables[0].NewRow();
                r["mabn"] = txtmabn2.Text;
                r["soluutru"] = txtsoluutru.Text;
                r["hoten"] = txthoten.Text;
                r["namsinh"] = txtnamsinh.Text;
                r["phai"] = cboGioitinh.Text;
                r["ngayvao"] = cbongayvao.Text;
                r["ngayra"] = ngayravien.Text;
                r["chandoanvao"] = maicd_vao.Text + " " + icd_vao.Text;
                r["chandoanra"] = maicd_ravien.Text + " " + icd_ravien.Text;
                r["chandoannn"] = maicd_nn.Text + " " + icd_nn.Text;
                r["ketqua"] = cboKetqua.Text;
                r["tenkp"] = lblmakp.Text;
                r["ttlucrv"] = cboTtLucrv.Text;
                r["soto"] = txthoso.Text;
                r["soxq"] = txtxq.Value.ToString();
                r["soct"] = txtct.Value.ToString();
                r["sosa"] = txtsa.Value.ToString();
                r["soxn"] = txtxn.Value.ToString();
                r["sokhac"] = txtkhac.Value.ToString();
                r["sodt"] = txtdt.Value.ToString();
                r["mri"] = mri.Value.ToString();
                r["ylenh"] = ylenh.Value.ToString();
                r["chamsoc"] = chamsoc.Value.ToString();
                r["madoituong"] = txtMaDoiTuong.Text;
                foreach (DataRow row in m.get_data_query("select * from view_btdbn where mabn= '" + txtmabn2.Text + "'").Tables[0].Rows)
                {
                    r["maphuongxa"] = row["maphuongxa"];
                    r["tenpxa"] = row["tenpxa"];
                    r["maqu"] = row["maqu"];
                    r["tenquan"] = row["tenquan"];
                    r["matt"] = row["matt"];
                    r["tentt"] = row["tentt"];
                    r["sonha"] = row["sonha"];
                    r["cholam"] = row["cholam"];
                    r["diachi"] = row["diachi"];
                }
                dsp.Tables[0].Rows.Add(r);
                dsp.WriteXml("..\\..\\xml\\ba_luutru.xml", XmlWriteMode.WriteSchema);
                HISToltal.frmReport f = new HISToltal.frmReport(m, dsp, s_msg, "ba_luutru.rpt");
                f.Show();
            }
        }

        private void butin_t_Click(object sender, System.EventArgs e)
        {
            butIn_Click(null, null);
        }

        public delegate Color delegateGetColorRowCol(int row, int col);
        public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
        {
            private delegateGetColorRowCol _getColorRowCol;
            private int _column;
            public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
            {
                _getColorRowCol = getcolorRowCol;
                _column = column;
            }
            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
            {
                try
                {
                    foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
                    //backBrush = new SolidBrush(Color.GhostWhite);
                }
                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }
        #endregion 

        #endregion

        #region Sự Kiện

        private void butMoi_Click(object sender, System.EventArgs e)
        {
            l_id = 0;
            l_maql = 0;
            load_grid();
            //load_ngay();
            s_mabn = ""; bEdit = false;
            b_damuon = false;
            b_nhanba = false;
            //
            if (i_tabpage == 0) empty_obj();
            enable_obj(true);
            ena_detail(true);
            ena_button(true);
            #region code cũ
            //cbobenhan.Focus();
            //cbobenhan.DroppedDown = true; 
            #endregion

            #region 09/12/2017 vannq
            txtmabn2.Focus();
            #endregion
            //
        }

        private void butBoqua_Click(object sender, System.EventArgs e)
        {
            //if (i_tabpage == 0) empty_obj();
            enable_obj(false);
            ena_button(false);
            ena_detail(false);
            try
            {
                butMoi.Focus();
            }
            catch
            {
            }
        }

        private void butHuy_Click(object sender, System.EventArgs e)
        {
            if (i_tabpage != 0) return;
            if (l_maql <= 0)
            {
                TA_MessageBox.MessageBox.Show("Đề nghị chọn hồ sơ.",  MessageIcon.Error);
                return;
            }
            if (l_id > 0 || b_damuon)
            {
                TA_MessageBox.MessageBox.Show("Hồ sơ có người mượn, không hủy được.",  MessageIcon.Error);
                return;
            }
            DialogResult dlg = TA_MessageBox.MessageBox.Show("Bạn có muốn hủy hồ sơ này không?",  MessageIcon.Question);
            if (dlg == DialogResult.Yes)

                if (huy_ba_luutru(l_maql)) empty_obj();
            //
            enable_obj(false);
            ena_detail(false);
            ena_button(false);

            butMoi.Focus();
        }

        private void butLuu_Click(object sender, System.EventArgs e)
        {
            if (l_maql <= 0) return;
            //
            if (txtsoluutru.Enabled && txtsoluutru.Text != "")
            {
                m.execute_data("update " + m.user + ".xuatvien set soluutru='" + txtsoluutru.Text + "' where maql=" + l_maql);
                m.execute_data("update " + m.user + ".ba_luutru set soluutru='" + txtsoluutru.Text + "' where maql=" + l_maql);
            }
            if (i_tabpage == 0)//nhan benh an
            {
                if (txtmann.Text != "")
                {
                    txtsoluutru.Text = get_soluutru();
                    if (txtsoluutru.Text == "")
                    {
                        txtsoluutru.Focus();
                        return;
                    }
                    if (bVitritudong && m.get_data("select maql from ba_luutru where mabn='" + s_mabn + "' and maql=" + l_maql).Tables[0].Rows.Count == 0)
                    {
                        sql = "select gia,tang,vitri_o";
                        sql += " from ba_luutru where substr(gia,1," + maluutru.Trim().Length + ")='" + maluutru + "' and length(tang)=3 and length(vitri_o)=4";
                        sql += " order by gia desc,tang desc,vitri_o desc";
                        DataTable tmp = m.get_data(sql).Tables[0];
                        if (tmp.Rows.Count == 0)
                        {
                            #region Code củ
                            //txtvitri.Text = maluutru + "-1";
                            //txttang.Text = "-1-";
                            //txto.Text = "0001"; 
                            #endregion

                            #region Vannq 18/11/2017
                            slbGia.his_SetSelectedIndex = 0;
                            slbTang.his_SetSelectedIndex = 0;
                            slbO.his_SetSelectedIndex = 0;
                            #endregion
                        }
                        else
                        {
                            #region Code cũ
                            //int _o = 0, _tang = 0, _vitri = 1;
                            //foreach (DataRow r in tmp.Rows)
                            //{
                            //    _o = int.Parse(r["vitri_o"].ToString()) + 1;
                            //    if (_o % 150 != 0)
                            //    {
                            //        txto.Text = _o.ToString().PadLeft(4, '0');
                            //        txttang.Text = r["tang"].ToString();
                            //        txtvitri.Text = r["gia"].ToString();
                            //    }
                            //    else
                            //    {
                            //        _tang = int.Parse(r["tang"].ToString().Substring(1, 1)) + 1;
                            //        if (_tang < 8)
                            //        {
                            //            txttang.Text = "-" + _tang.ToString() + "-";
                            //            txto.Text = _o.ToString().PadLeft(4, '0');
                            //            txtvitri.Text = r["gia"].ToString();
                            //        }
                            //        else
                            //        {
                            //            if (r["gia"].ToString().Length > 1) _vitri = int.Parse(r["gia"].ToString().Substring(2)) + 1;
                            //            txtvitri.Text = maluutru + "-" + _vitri.ToString();
                            //            txttang.Text = "-1-";
                            //            txto.Text = "0001";
                            //        }
                            //    }
                            //    break;
                            //} 
                            #endregion
                        }
                    }
                    #region Code củ Vannq 18/11/2017
                    //m.upd_ba_luutru(s_mabn, l_maql, txtsoluutru.Text, 1, ngaynhan.Text, txtvitri.Text, txttang.Text, txto.Text,  
                    #endregion
                    #region Code mới lưu vị trí theo danh mục vị trí - Vannq 18/11/2017
                    m.upd_ba_luutru(s_mabn, l_maql, txtsoluutru.Text, 1, ngaynhan.Text, slbGia.txtTen.Text, slbTang.txtTen.Text, slbO.txtTen.Text,
                    #endregion
                        int.Parse(txtxq.Value.ToString()), int.Parse(txtct.Value.ToString()),
                        int.Parse(txtsa.Value.ToString()), int.Parse(txtxn.Value.ToString()),
                        int.Parse(txtdt.Value.ToString()), int.Parse(txtkhac.Value.ToString()),
                        int.Parse((txthoso.Text == "") ? "0" : txthoso.Text), txtmang.Text, txtmann.Text, l_sttnam,
                        cbobenhan.SelectedIndex, (chkTainan.Checked) ? 1 : 0, (makho.SelectedIndex != -1) ? int.Parse(makho.SelectedValue.ToString()) : 0,
                        int.Parse(mri.Value.ToString()), int.Parse(ylenh.Value.ToString()), int.Parse(chamsoc.Value.ToString()), i_userid);
                    m.execute_data("delete from ba_luutruthieu where maql=" + l_maql);

                    #region 22/11/2017 vannq set lại ngày nhận hs
                    if (bEdit)
                    {
                        string sss = "update " + m.user + ".ba_luutru set ngaynhan = to_date('" + ngaynhan.Text + "','dd/MM/yyyy hh24:mi'), soravien = '"+ txtSoRaVien.Text +"'  where maql=" + l_maql;
                        m.execute_data(sss);
                    }
                    #endregion
                    dst.AcceptChanges();
                    string sghichu = string.Empty;
                    foreach (DataRow r in dst.Tables[0].Select("chon=True"))
                    {
                        if (sghichu.IndexOf(r["ghichu"].ToString()) == -1) sghichu += r["ghichu"].ToString() + ";";
                        m.upd_ba_luutruthieu(l_maql, int.Parse(r["id"].ToString()), r["ghichu"].ToString());
                    }
                    if (sghichu == string.Empty)
                    {
                        foreach (DataRow r in dst.Tables[0].Select("chon=True"))
                            if (sghichu.IndexOf(r["ten"].ToString()) == -1) sghichu += r["ten"].ToString() + ";";
                        if (sghichu != string.Empty) m.upd_ba_luutruthieu(l_maql, sghichu);
                    }
                    get_tongsoba();
                    b_nhanba = true;
                    ena_detail(false);
                    #region 20/11/2017 Vannq
                    load_ngay();
                    //Load_DanhSachRaVien();
                    Load_BenhNhan();
                    txtTimKiem.Text = "";
                    #endregion
                }
                else
                {
                    TA_MessageBox.MessageBox.Show("Vui lòng nhập người nhận hồ sơ!", MessageIcon.Error);
                    txtmann.Focus();
                    return;
                }
            }
            else if (i_tabpage == 1)//muon benh an
            {
                if (b_nhanba == false)
                {
                    TA_MessageBox.MessageBox.Show("Bệnh án này chưa trả !");
                    return;
                }
                if (chktraba.Checked)
                {
                    sql = "select id from ba_muon where mabn='" + s_mabn + "' and maql=" + l_maql + " and ngaytra is null";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows) l_id = long.Parse(r["id"].ToString());
                }
                if (l_id <= 0) l_id = m.get_capid(-1);

                m.upd_ba_muon(l_id, s_mabn, l_maql, txtsoluutru.Text, mabs.Text, ngaymuon.Text, (chktraba.Checked) ? 1 : 0, ngaytra.Text, txtghichu.Text);
                load_grid_muonba();
                if (!chktraba.Checked) b_damuon = true;
                else b_damuon = false;
                chktraba.Checked = false;
            }
            //
            enable_obj(false);
            ena_button(false);

            try
            {
                butMoi.Focus();
            }
            catch
            {
            }
        }

        private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if ((bool)this.dataGrid2[this.dataGrid2.CurrentRowIndex, checkCol])
                this.dataGrid2.CurrentCell = new DataGridCell(this.dataGrid2.CurrentRowIndex, checkCol);
        }

        private void dataGrid2_Click(object sender, System.EventArgs e)
        {
            Point pt = this.dataGrid2.PointToClient(Control.MousePosition);
            DataGrid.HitTestInfo hti = this.dataGrid2.HitTest(pt);
            BindingManagerBase bmb = this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
            if (afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell && hti.Column == checkCol)
            {
                this.dataGrid2[hti.Row, checkCol] = !(bool)this.dataGrid2[hti.Row, checkCol];
                RefreshRow(hti.Row);
            }
        }

        private void butKetthuc_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmhsluutru_Load(object sender, System.EventArgs e)
        {
            _design = true;
            _Utility.f_SetEvent(this);
            timngay.SelectedIndex = 0;
            chktudongtang.Checked = _Utility.Thongso("thongso", "hsluutruauto") == "1";
            chkzum.Checked = _Utility.Thongso("thongso", "hsluutrusum") == "1";
            bVitritudong = m.bVitritudong;
            txtvitri.Enabled = txttang.Enabled = txto.Enabled = slbGia.Enabled = slbTang.Enabled = slbO.Enabled = !bVitritudong;
            if (bVitritudong) label12.Text = label37.Text = "STT: ";
            if (cbobenhan.SelectedIndex == -1) cbobenhan.SelectedIndex = 0;

            txtsoluutru.Enabled = !chktudongtang.Checked;
            enable_obj(false);
            ena_detail(false);
            load_dm();
            load_grid_muonba();
            //						
            string s_yy = DateTime.Now.Year.ToString().Substring(2, 2);
            l_sttnam = get_sttba(s_yy);
            decimal tmp_stt = l_sttnam - 1;
            txttsbanam.Text = tmp_stt.ToString() + "/" + s_yy;
            //
            AddGridTableStyle();
            //
            if (s_mabn != "")
            {
               // txtsoluutru.Text = s_soluutru;
                txtSoRaVien.Text = s_soluutru;
                txtmabn2.Text = s_mabn.Substring(2);
                txtmabn2_Validated(null, null);
            }

            load_grid();
            AddGridTableStyle2();

            load_ngay();
            AddGridTableStyle4();
            this.disabledBackBrush = new SolidBrush(Color.Black);
            this.disabledTextBrush = new SolidBrush(Color.Red);

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);
            this.currentRowFont = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));

            //Load_DanhSachRaVien();
            Load_BenhNhan();
            butMoi.Focus();
            Load_Gia();
            Load_Tang();
            Load_O();
            Load_KhoaPhong();
            _design = false;
        }

        private void butSua_Click(object sender, System.EventArgs e)
        {
            if (i_tabpage == 0 && b_damuon)
            {
                TA_MessageBox.MessageBox.Show("Bệnh án này '" + txttinhtranghoso.Text + "' nên không sửa được.",  MessageIcon.Error);
                return;
            }
            else if (i_tabpage == 1 && b_nhanba == false)
            {
                TA_MessageBox.MessageBox.Show("Bệnh án này khoa chưa trả nên không sửa được.",  MessageIcon.Error);
                return;
            }
            ena_detail(true);
            ena_button(true);
            txtsoluutru.Enabled = true;
            bEdit = true;
            try
            {
                ylenh.Focus();
            }
            catch
            {
            }
        }

        private void chktraba_Click(object sender, System.EventArgs e)
        {
            ngaytra.Enabled = chktraba.Checked;
        }

        private void txtsoluutru_Validated(object sender, System.EventArgs e)
        {
            if (bEdit) return;
            if (txtsoluutru.Text.Trim() != "" && txtsoluutru.Enabled)
            {
                if (kiemtra_soluutru(txtsoluutru.Text))
                {
                    TA_MessageBox.MessageBox.Show("Số lưu trữ này đã có !");
                    txtsoluutru.Focus();
                    return;
                }
               // if (chktudongtang.Checked) txtsoluutru.Text = txtsoluutru.Text.PadLeft(6, '0');
                if (!txtmabn2.Enabled) ngaynhan.Focus();
            }
        }

        private void txtmabn1_Validated(object sender, System.EventArgs e)
        {
            //if(txtmabn1.Text.Trim()=="")txtmabn1.Text=DateTime.Now.Year.ToString().Substring(2,2);
            //else txtmabn1.Text=txtmabn1.Text.PadLeft(2,'0');
        }

        private void txtmabn2_Validated(object sender, System.EventArgs e)
        {
            if (txtmabn2.Text == "" || txtmabn2.Text.Trim().Length < 3) return;
            if (txtmabn2.Text.Trim().Length != 8) txtmabn2.Text = txtmabn2.Text.Substring(0, 2) + txtmabn2.Text.Substring(2).PadLeft(6, '0');
            s_mabn = txtmabn2.Text;

            #region code cũ 22/11/2017
            //if (!load_hosoba(s_mabn, 0, tabControl1.SelectedIndex)) 
            #endregion

            #region 22/11/2017 Vannq load ben nhan dua theo mabn va maql
            if (!load_hosoba(s_mabn, (long)l_maql, tabControl1.SelectedIndex))
            #endregion
            {
                empty_obj();
                txtmabn2.Focus();
            }
            else
            {
                if (slbGia.txtTen.Text == "")
                {
                    slbGia.his_SetSelectedIndex = 0;
                    slbTang.his_SetSelectedIndex = 0;
                    slbO.his_SetSelectedIndex = 0;
                }
                cbongayvao.Focus();
            }
            // txtsoluutru.Enabled = true;
           
        }

        private void txtmabn2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

        private void txtnguoigiao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void txtnguoigiao_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == txtnguoigiao)
            {
                Filt_tenbs(txtnguoigiao.Text, listBS);
                listBS.BrowseToICD10(txtnguoigiao, txtmang, txtmann, txtmang.Location.X, txtmang.Location.Y + txtmang.Height, txtmang.Width + txtnguoigiao.Width + 2, txtmang.Height);
            }
        }

        private void txtmang_Validated(object sender, System.EventArgs e)
        {
            if (txtmang.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + txtmang.Text + "'");
                if (r != null) txtnguoigiao.Text = r["hoten"].ToString();
                else txtnguoigiao.Text = "";
            }
            #region Vannq 22/11/2017
            else txtnguoigiao.Text = "";
            #endregion
        }

        private void txtmann_Validated(object sender, System.EventArgs e)
        {
            if (txtmann.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + txtmann.Text + "'");
                if (r != null) txtnguoinhan.Text = r["hoten"].ToString();
                else txtnguoinhan.Text = "";
            }
            #region Vannq 22/11/2017
            else txtnguoinhan.Text = "";
            #endregion
        }

        private void txtnguoinhan_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == txtnguoinhan)
            {
                Filt_tenbs(txtnguoinhan.Text, listBS);
                listBS.BrowseToICD10(txtnguoinhan, txtmann, txtvitri, txtmann.Location.X, txtmann.Location.Y + txtmann.Height, txtmann.Width + txtnguoinhan.Width + 2, txtmann.Height);
            }
        }

        private void txtxq_Validated(object sender, System.EventArgs e)
        {
            if (chkzum.Checked) get_tonghoso();
        }

        private void tenbs_TextChanged(object sender, System.EventArgs e)
        {

            if (this.ActiveControl == tenbs)
            {
                Filt_tenbs(tenbs.Text, listBS1);
                listBS1.BrowseToICD10(tenbs, mabs, txtghichu, mabs.Location.X, mabs.Location.Y + mabs.Height, mabs.Width + tenbs.Width + 2, mabs.Height);
            }
        }

        private void tabControl1_Click(object sender, System.EventArgs e)
        {
            i_tabpage = tabControl1.SelectedIndex;
            if (i_tabpage == 1)//load ds muon benh an
            {
                if (l_maql > 0)
                {
                    if (!load_ttba(l_maql))
                    {
                        ena_button(true);
                        enable_obj(true);
                    }
                }
                else load_grid_muonba();
                chktraba.Enabled = dtm.Tables[0].Rows.Count > 0;
            }
            else if (i_tabpage == 0)
            {
                if (b_damuon)//muon benh an: khong cho sua
                {
                    enable_obj(false);
                    ena_detail(false);
                    ena_button(false);
                }
                else
                {
                    ena_button(true);
                    ena_detail(true);
                }
            }
            if (i_tabpage == 2) cbobenhan.Enabled = true;
        }

        private void mabs_Validated(object sender, System.EventArgs e)
        {
            if (mabs.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                if (r != null) tenbs.Text = r["hoten"].ToString();
                else tenbs.Text = "";
            }
        }

        private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS1.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS1.Visible) listBS1.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void dataGrid3_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void txtsoluutru_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ngayravien_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{Tab}");
        }

        private void txto_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter) butLuu.Focus();// SendKeys.Send("{Tab}{Tab}");
        }

        private void tenbs_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS1.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS1.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void cbongayvao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (this.ActiveControl == cbongayvao)
            {
                load_hosoba(txtmabn2.Text, long.Parse(cbongayvao.SelectedValue.ToString()), tabControl1.SelectedIndex);
            }
        }

        private void cbobenhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (butMoi.Enabled) butMoi.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void cbongayvao_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
            //ngaynhan.Focus();
        }

        private void cbobenhan_Validated(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            #region code cũ
            //if (chktudongtang.Checked) txtsoluutru.Text = get_soluutru(DateTime.Now.Year.ToString()).ToString().PadLeft(6, '0') + "/" + DateTime.Now.Year.ToString().Substring(2); 
            #endregion
            if (chktudongtang.Checked && butLuu.Enabled) txtsoluutru.Text =  get_soluutru();
            //else txtsoluutru.Focus();


        }

        private void ngaytra_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
                butLuu.Focus();
        }

        private void txtghichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
                if (!chktraba.Enabled) butLuu.Focus();
                else SendKeys.Send("{Tab}");
        }

        private void label30_DoubleClick(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (txthoten.Text.Trim() == "") return;
            frmSuangayXK f = new frmSuangayXK(m, ngayravien.Text, l_maql);
            f.ShowDialog();
            cbongayvao_SelectedIndexChanged(null, null);
        }

        private void chktudongtang_CheckedChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            _Utility.writeXml("thongso", "hsluutruauto", (chktudongtang.Checked) ? "1" : "0");
        }

        private void chkzum_CheckedChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            _Utility.writeXml("thongso", "hsluutrusum", (chkzum.Checked) ? "1" : "0");
            txthoso.Enabled = !chkzum.Checked;
        }

        private void dataGrid4_CurrentCellChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            txtmabn2.Text = ((DataRowView)_bs.Current)[0].ToString();
            l_maql = (long)((DataRowView)_bs.Current)[9];
            txtmabn2_Validated(null, null);
        }

        #region 16/11/2017 Vannq them sk tim benh nhan cho xuat vien

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_design)
            {
                return;
            }
            try
            {
                txtmabn2.Text = dgvMain["colMaBN", e.RowIndex].Value.ToString();
                l_maql = Convert.ToDecimal(dgvMain["colMaQL", e.RowIndex].Value.ToString());
                txtmabn2_Validated(null, null);
                if (radChuaNhan.Checked && txtmabn2.Text != "") butSua_Click(null, null);
            }
            catch { }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_design)
                {
                    return;
                }


                string searchString = cls_Common.BoDau(txtTimKiem.Text).Replace(" ","");
                DataTable tb = new DataTable();
                if (radChuaNhan.Checked)
                {

                    tb = dt.Select("HOTENKDAU Like '%" + searchString + "%' or MABN Like '%" + searchString + "%'").CopyToDataTable();
                }
                else
                {

                    tb = dsng.Tables[0].Select("HOTEN Like '%" + searchString + "%' or MABN Like '%" + searchString + "%'").CopyToDataTable();
                }


                this.dgvMain.DataSource = tb;
            }
            catch { dgvMain.DataSource = null; }
        }

        private void dgvMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtmabn2.Text = dgvMain["colMaBN", dgvMain.SelectedRows[0].Index].Value.ToString();
                    l_maql = Convert.ToDecimal(dgvMain["colMaQL", dgvMain.SelectedRows[0].Index].Value.ToString());
                    txtmabn2_Validated(null, null);
                    if (radChuaNhan.Checked) butSua_Click(null, null);
                    e.SuppressKeyPress = true;
                }
            }
            catch { }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                dgvMain.Focus();
            }
        }

        #endregion

        #region 20/11/2017 Vannq them sk Danh mục vị trí
        private void chkViTriTuDong_CheckedChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            bVitritudong = chkViTriTuDong.Checked;
            txtvitri.Enabled = txttang.Enabled = txto.Enabled = !chkViTriTuDong.Checked;
            slbGia.Enabled = slbTang.Enabled = slbO.Enabled = !chkViTriTuDong.Checked;
            if (bVitritudong) label12.Text = label37.Text = "STT: ";
            else label12.Text = label37.Text = "Ô: ";

            if (chkViTriTuDong.Checked)
            {
                slbGia.his_SetSelectedIndex = 0;
                slbTang.his_SetSelectedIndex = 0;
                slbO.his_SetSelectedIndex = 0;
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            frm_DanhMucViTri f = new frm_DanhMucViTri();
            f.ShowDialog();
            Load_Gia();
            Load_Tang();
            Load_O();
        }
        #endregion

        private void slbKhoaPhong_HisSelectChange(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (radChuaNhan.Checked)
            {
                //Load_DanhSachRaVien();
                Load_BenhNhan();
            }
            else
            {
                radDaNhan_CheckedChanged(null, null);
            }
        }

        private void dgvMain_DataSourceChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            try
            {
                lblKQ.Text = dgvMain.RowCount.ToString();
            }
            catch { }
        }

        private void radDaNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (radDaNhan.Checked)
            {
                dgvMain.DataSource = null;
                if (cbobenhan.SelectedIndex == 0 && dsng.Tables[0].Select("loaiba = '0'").Length > 0)
                {
                    if (String.IsNullOrWhiteSpace(slbKhoaPhong.txtTen.Text))
                    {
                        dgvMain.DataSource = dsng.Tables[0].Select("loaiba = '0'").CopyToDataTable();
                        return;
                    }
                    else if (dsng.Tables[0].Select("loaiba = '0' and tenkp like '" + slbKhoaPhong.txtTen.Text + "'").Length > 0)
                    {
                        dgvMain.DataSource = dsng.Tables[0].Select("loaiba = '0' and tenkp like '" + slbKhoaPhong.txtTen.Text + "'").CopyToDataTable();
                        return;
                    }
                    else
                    {
                        dgvMain.DataSource = null;
                        return;
                    }
                }
                else if (cbobenhan.SelectedIndex == 1 && dsng.Tables[0].Select("loaiba = '1'").Length > 0)
                {
                    if (String.IsNullOrWhiteSpace(slbKhoaPhong.txtTen.Text))
                    {
                        dgvMain.DataSource = dsng.Tables[0].Select("loaiba = '1'").CopyToDataTable();
                        return;
                    }
                    else if (dsng.Tables[0].Select("loaiba = '1' and tenkp like '" + slbKhoaPhong.txtTen.Text + "'").Length > 0)
                    {
                        dgvMain.DataSource = dsng.Tables[0].Select("loaiba = '1' and tenkp = '" + slbKhoaPhong.txtTen.Text + "'").CopyToDataTable();
                        return;
                    }
                    else
                    {
                        dgvMain.DataSource = null;
                        return;
                    }
                }
                else if (cbobenhan.SelectedIndex == 2 && dsng.Tables[0].Select("loaiba = '4'").Length > 0)
                {
                    if (String.IsNullOrWhiteSpace(slbKhoaPhong.txtTen.Text))
                    {
                        dgvMain.DataSource = dsng.Tables[0].Select("loaiba = '4'").CopyToDataTable();
                        return;
                    }
                    else if (dsng.Tables[0].Select("loaiba = '4' and tenkp like '" + slbKhoaPhong.txtTen.Text + "'").Length > 0)
                    {
                        dgvMain.DataSource = dsng.Tables[0].Select("loaiba = '4' and tenkp like '" + slbKhoaPhong.txtTen.Text + "'").CopyToDataTable();
                        return;
                    }
                    else
                    {
                        dgvMain.DataSource = null;
                        return;
                    }
                }
                else if (cbobenhan.SelectedIndex == 5 && dsng.Tables[0].Select("loaiba = '5'").Length > 0)
                {
                    if (String.IsNullOrWhiteSpace(slbKhoaPhong.txtTen.Text))
                    {
                        dgvMain.DataSource = dsng.Tables[0].Select("loaiba = '5'").CopyToDataTable();
                        return;
                    }
                    else if (dsng.Tables[0].Select("loaiba = '5' and tenkp like '" + slbKhoaPhong.txtTen.Text + "'").Length > 0)
                    {
                        dgvMain.DataSource = dsng.Tables[0].Select("loaiba = '5' and tenkp like '" + slbKhoaPhong.txtTen.Text + "'").CopyToDataTable();
                        return;
                    }
                    else
                    {
                        dgvMain.DataSource = null;
                        return;
                    }
                }
            }
        }

        private void radChuaNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (radChuaNhan.Checked)
            {
                //Load_DanhSachRaVien();
                Load_BenhNhan();
            }
        }

        private void cbobenhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            slbKhoaPhong.txtTen.Text = txtTimKiem.Text = "";
            butMoi_Click(null, null);
            if (radChuaNhan.Checked)
            {
                //Load_DanhSachRaVien();
                Load_BenhNhan();
            }
            else
            {
                radDaNhan_CheckedChanged(null, null);
            }
        }

        private void ngaynhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (_design)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        #region Event Enter numberic up down vannq 09/12/2017
        private void ylenh_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            ylenh.Select(0, ylenh.Value.ToString().Length);
        }

        private void chamsoc_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            chamsoc.Select(0, chamsoc.Value.ToString().Length);
        }

        private void txtxq_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            txtxq.Select(0, txtxq.Value.ToString().Length);
        }

        private void txtct_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            txtct.Select(0, txtct.Value.ToString().Length);
        }

        private void mri_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            mri.Select(0, mri.Value.ToString().Length);
        }

        private void txtsa_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            txtsa.Select(0, txtsa.Value.ToString().Length);
        }

        private void txtdt_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            txtdt.Select(0, txtdt.Value.ToString().Length);
        }

        private void txtxn_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            txtxn.Select(0, txtxn.Value.ToString().Length);
        }

        private void txtkhac_Enter(object sender, EventArgs e)
        {
            if (_design)
            {
                return;
            }
            txtkhac.Select(0, txtkhac.Value.ToString().Length);
        }
        #endregion 

        private void btnNhanHS_Click(object sender, EventArgs e)
        {
            frmNhanHS f = new frmNhanHS(i_userid);
            f.ShowDialog();
            
            _tungay = f._tungay;
            _denngay = f._denngay;
            Load_BenhNhan();
        }
        #endregion


    }
}

