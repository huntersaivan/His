using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E00_Common;

namespace E00_STT
{
    public partial class frm_CapSTT_2 : DevComponents.DotNetBar.Office2007Form
    {
        //public LibDal.AccessData m = new LibDal.AccessData();
        public int ikhu, isottgoi, iQuay;
        public DataTable dt = new DataTable();
        public DataTable dttmp = new DataTable();
        private Api_Common _api = new Api_Common();
        //public LibUtility.Utility _Utility = new LibUtility.Utility();

        public frm_CapSTT_2()
        {
            InitializeComponent();

            ColMa.DisplayMember = "ten";
            ColMa.ValueMember = "id";
            //string str = "select * from " + m.user + ".an_dmloaikhu order by id ";
            //ColMa.DataSource = m.get_data(str).Tables[0];

            //khu.DisplayMember = "ten";
            //khu.ValueMember = "id";
            //string sql = "select * from " + m.user + ".an_dmloaikhu order by id ";
            //khu.DataSource = m.get_data(sql).Tables[0];
            //khu.SelectedIndex = -1;
        }

        private void ReLoad()
        {
            //dataGridViewX1.Controls.Clear();
            //string query = "select id,ma,diengiai,chuoinam,chuoithang,chuoingay,chuoiso,chuoigio,chuoiphut,chuoigiay,chuoiformat,sonhay,batdau,ketthuc from " + m.user + ".an_dmsotudong order by ngayud desc";
            //dataGridViewX1.DataSource = m.get_data(query).Tables[0];

        }

        private void frmCapso_Load(object sender, EventArgs e)
        {
            txtNgaycapnhat.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            ReLoad();
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {


        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["ColId"].Value.ToString()))
            {
                string _id = dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["ColId"].Value.ToString();
                DataTable dt = new DataTable();
               // dt = m.get_data("select * from " + m.user + ".an_dmsotudong where id='" + _id + "'").Tables[0];

                khu.SelectedValue = dt.Rows[0]["ma"].ToString();
                txtDienGiai.Text = dt.Rows[0]["diengiai"].ToString();
                txtNam.Text = dt.Rows[0]["chuoinam"].ToString();
                txtThang.Text = dt.Rows[0]["chuoithang"].ToString();
                txtNgay.Text = dt.Rows[0]["chuoingay"].ToString();
                txtSo.Text = dt.Rows[0]["chuoiso"].ToString();
                txtGio.Text = dt.Rows[0]["chuoigio"].ToString();
                txtPhut.Text = dt.Rows[0]["chuoiphut"].ToString();
                txtGiay.Text = dt.Rows[0]["chuoigiay"].ToString();
                txtFormat.Text = dt.Rows[0]["chuoiformat"].ToString();
                txtSonhay.Text = dt.Rows[0]["sonhay"].ToString();
                txtBatdau.Text = dt.Rows[0]["batdau"].ToString();
                txtKetthuc.Text = dt.Rows[0]["ketthuc"].ToString();
            }
            else
            {
                khu.Text = string.Empty;
                txtDienGiai.Text = string.Empty;
                txtNam.Text = string.Empty;
                txtThang.Text = string.Empty;
                txtNgay.Text = string.Empty;
                txtSo.Text = string.Empty;
                txtGio.Text = string.Empty;
                txtPhut.Text = string.Empty;
                txtGiay.Text = string.Empty;
                txtFormat.Text = string.Empty;
                txtSonhay.Text = string.Empty;
                txtBatdau.Text = string.Empty;
                txtKetthuc.Text = string.Empty;
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            //string _id = dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["ColId"].Value.ToString();
            //string _ma = khu.SelectedValue.ToString();
            //DataTable dt = new DataTable();
            //    if (!m.upd_dmsotudong(_id, _ma, txtDienGiai.Text, txtNam.Text, txtThang.Text, txtNgay.Text, txtSo.Text, txtGio.Text, txtPhut.Text, txtGiay.Text, txtFormat.Text, int.Parse(txtSonhay.Text), int.Parse(txtBatdau.Text), int.Parse(txtKetthuc.Text)))
            //    {
            //        MessageBox.Show("Không cập nhật được thông tin khai báo Số Tự Động", "Thông báo");
            //    }
           
            //ReLoad();

            try
            {
                for (int i = 0; i < dataGridViewX1.RowCount - 1; i++)
                {
                    string _id = dataGridViewX1.Rows[i].Cells["ColId"].Value.ToString();
                    string _ma = dataGridViewX1.Rows[i].Cells["ColMa"].Value.ToString();
                    string diengiai = dataGridViewX1.Rows[i].Cells["ColDiengiai"].Value.ToString();
                    string nam = dataGridViewX1.Rows[i].Cells["ColChuoinam"].Value.ToString();
                    string thang = dataGridViewX1.Rows[i].Cells["ColChuoithang"].Value.ToString();
                    string ngay = dataGridViewX1.Rows[i].Cells["ColChuoingay"].Value.ToString();
                    string so = dataGridViewX1.Rows[i].Cells["ColChuoiso"].Value.ToString();
                    string gio = dataGridViewX1.Rows[i].Cells["ColGio"].Value.ToString();
                    string phut = dataGridViewX1.Rows[i].Cells["ColPhut"].Value.ToString();
                    string giay = dataGridViewX1.Rows[i].Cells["ColGiay"].Value.ToString();
                    string format = dataGridViewX1.Rows[i].Cells["ColFormat"].Value.ToString();
                    string sonhay = dataGridViewX1.Rows[i].Cells["ColSonhay"].Value.ToString();
                    if (string.IsNullOrEmpty(sonhay))
                        sonhay = "0";
                    string batdau = dataGridViewX1.Rows[i].Cells["ColBatdau"].Value.ToString();
                    if (string.IsNullOrEmpty(batdau))
                        batdau = "0";
                    string ketthuc = dataGridViewX1.Rows[i].Cells["ColKetthuc"].Value.ToString();
                    if (string.IsNullOrEmpty(ketthuc))
                        ketthuc = "0";
                    //if (!m.upd_dmsotudong(_id, _ma, diengiai, nam, thang, ngay, so, gio, phut, giay, format, int.Parse(sonhay), int.Parse(batdau), int.Parse(ketthuc)))
                    //{
                    //    MessageBox.Show("Không cập nhật được thông tin khai báo Số Tự Động", "Thông báo");
                    //}
                }
                ReLoad();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

  
    }
}
