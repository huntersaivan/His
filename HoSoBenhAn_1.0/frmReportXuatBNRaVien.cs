using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E00_Model;
using E00_Common;

namespace HISQLHSBA
{
    public partial class frmReportXuatBNRaVien : E00_Base.frm_Base
    {
        private Api_Common _api = new Api_Common();
        DataSet _dts = new DataSet();
        DataTable _dt;
        private string _userError = "";
        private string _systemError = "";
        public frmReportXuatBNRaVien(DataTable dt)
        {
            InitializeComponent();
            _dt = dt;
            _api.KetNoi();
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            DateTime dttu = new DateTime(tu.Value.Year, tu.Value.Month, tu.Value.Day, 0,0,0);
            DateTime dtden = new DateTime(den.Value.Year, den.Value.Month, den.Value.Day, 23, 59, 59);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (!String.IsNullOrEmpty(slbKhoaPhong.txtMa.Text))
            {
                dt = FilterTable(_dt, dttu, dtden, "ngayrv", slbKhoaPhong.txtMa.Text);
            }
            else
            {
                dt = FilterTable(_dt, dttu, dtden, "ngayrv");
            }
            if (dt.Rows.Count < 1)
            {
                TA_MessageBox.MessageBox.Show("Không có dữ liệu",TA_MessageBox.MessageIcon.Warning);
                return;
            }
            string s_msg = "";
            _dts= new DataSet();
            _dts.Tables.Add(dt);
            if (!System.IO.Directory.Exists("..\\..\\xml")) System.IO.Directory.CreateDirectory("..\\..\\xml");
            _dts.WriteXml("..\\..\\xml\\ba_ravien.xml", XmlWriteMode.WriteSchema);
            HISToltal.frmReport f = new HISToltal.frmReport(new LibDal.AccessData(), _dts, s_msg, "ba_ravien.rpt");
            f.Show();
           
        }
        private DataTable FilterTable(DataTable table, DateTime startDate, DateTime endDate,string column,string makp)
        {
            try
            {
                var filteredRows =
                    from row in table.Rows.OfType<DataRow>()
                    where DateTime.Parse(row[column].ToString()) >= startDate
                    where DateTime.Parse(row[column].ToString()) <= endDate
                    where row["makp"].ToString() == makp
                    select row;

                var filteredTable = table.Clone();

                filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

                return filteredTable;
            }
            catch
            {
                return table.Clone();
            }
        }

        private DataTable FilterTable(DataTable table, DateTime startDate, DateTime endDate, string column)
        {
            try
            {
                var filteredRows =
                    from row in table.Rows.OfType<DataRow>()
                    where DateTime.Parse(row[column].ToString()) >= startDate
                    where DateTime.Parse(row[column].ToString()) <= endDate
                    select row;

                var filteredTable = table.Clone();

                filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

                return filteredTable;
            }
            catch
            {
                return table.Clone();
            }
        }

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

        private void frmReportXuatBNRaVien_Load(object sender, EventArgs e)
        {
            Load_KhoaPhong();
        }


    }
}
