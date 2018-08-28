using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E00_STT
{
    public partial class frmXuatLCD : DevComponents.DotNetBar.Office2007Form
    {
        private string p;
        private int p_2;
        private int _userid = -1;
        private string _makp = "";
        private bool changecolo = false;
      //  private LibDal.AccessData _acc = new LibDal.AccessData();
        public frmXuatLCD()
        {
            InitializeComponent();

        }

        public frmXuatLCD(string p, int p_2)
        {
            InitializeComponent();
            this._makp = p;
            
            this._userid = p_2;

        }

        private void kếtThúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblso_Click(object sender, EventArgs e)
        {
        }

        private void frmXuatLCD_Load(object sender, EventArgs e)
        {
            string user = _acc.user;
            string sql = "";
            if (_makp.Substring(0, 1).ToLower() == "p")
            {
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp.Substring(1) + "'";
            }
            DataTable tmp = _acc.get_data(sql).Tables[0];
            if (tmp != null && tmp.Rows.Count > 0)
            {
                lblphong.Text = tmp.Rows[0][0].ToString();
            }
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string user = _acc.user;
            string sql = "select stt";

            sql += " from " + user + ".stt_capso a where TRANGTHAI=1 AND rownum = 1 ";

            if (_makp != "")
            {

                sql += " and  MaNoiCap ='" + _makp + "'";
            }
            sql += " order by a.stt asc";
            DataTable tmp = _acc.get_data(sql).Tables[0];
            if (tmp != null && tmp.Rows.Count > 0)
            {
                LBLSOGOI.Text = tmp.Rows[0][0].ToString();
            }
            else
            {
                LBLSOGOI.Text = "";
            }
             sql = "select stt";

            sql += " from " + user + ".stt_capso a where TRANGTHAI=0";

            if (_makp != "")
            {

                sql += " and  MaNoiCap ='" + _makp + "'";
            }
            sql += " order by a.stt asc";
             tmp = _acc.get_data(sql).Tables[0];
            if (tmp != null && tmp.Rows.Count > 0)
            {
                
                
                    if (tmp.Rows.Count>=4)
                    {
                        LBDSCHO1.Text = tmp.Rows[0][0].ToString();
                        LBDSCHO2.Text = tmp.Rows[1][0].ToString();
                        LBDSCHO3.Text = tmp.Rows[2][0].ToString();
                        LBDSCHO4.Text = tmp.Rows[3][0].ToString();
                    }
                    else if (tmp.Rows.Count == 3)
                    {
                        LBDSCHO1.Text = tmp.Rows[0][0].ToString();
                        LBDSCHO2.Text = tmp.Rows[1][0].ToString();
                        LBDSCHO3.Text = tmp.Rows[2][0].ToString();
                        LBDSCHO4.Text = "";
                        
                    }
                    else if (tmp.Rows.Count == 2)
                    {
                        LBDSCHO1.Text = tmp.Rows[0][0].ToString();
                        LBDSCHO2.Text = tmp.Rows[1][0].ToString();
                        LBDSCHO3.Text ="";
                        LBDSCHO4.Text = "";
                    }
                    else if (tmp.Rows.Count == 1)
                    {
                        LBDSCHO1.Text = tmp.Rows[0][0].ToString();
                        LBDSCHO2.Text = "";
                        LBDSCHO3.Text = "";
                        LBDSCHO4.Text = "";
                    }
                
               
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (changecolo)
            {
                LBLSOGOI.ForeColor = Color.Red;
            }
            else
            {
                LBLSOGOI.ForeColor = Color.Gold;
            }
            changecolo = !changecolo;

        }
    }
}
