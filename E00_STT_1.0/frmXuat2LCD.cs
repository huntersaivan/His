using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E00_Common;

namespace E00_STT
{
    public partial class frmXuat2LCD : DevComponents.DotNetBar.Office2007Form
    {
        private string p;
        private int p_2;
        private int _userid = -1;
        private string _makp = "";
        private string _makp2 = "";
        private bool changecolo = false;
         
        private Acc_Oracle _acc = new Acc_Oracle();
        public frmXuat2LCD()
        {
            InitializeComponent();
                 
        }

        public frmXuat2LCD(string p, int p_2, string p2)
        {
            InitializeComponent();
            this._makp = p;
            this._makp2 = p2;
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
            string user = _acc.Get_Data();
            string sql = "";
            if (_makp.Substring(0, 1).ToLower() == "p")
            {
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp.Substring(1) + "'";
            }
            lblphong.Text = "";
            DataTable tmp = _acc.get_data(sql).Tables[0];
            if (tmp != null && tmp.Rows.Count > 0)
            {
                lblphong.Text = tmp.Rows[0][0].ToString();
            }

            if (_makp2.Substring(0, 1).ToLower() == "p")
            {
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp2.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp2.Substring(1) + "'";
            }
            lblphong2.Text = "";
             tmp = _acc.get_data(sql).Tables[0];
            if (tmp != null && tmp.Rows.Count > 0)
            {
                lblphong2.Text = tmp.Rows[0][0].ToString();
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

            sql += " from " + user + ".stt_capso a where TRANGTHAI=1 AND rownum = 1 ";

            if (_makp2 != "")
            {

                sql += " and  MaNoiCap ='" + _makp2 + "'";
            }
            sql += " order by a.stt asc";
             tmp = _acc.get_data(sql).Tables[0];
            if (tmp != null && tmp.Rows.Count > 0)
            {
                LBLSOGOI2.Text = tmp.Rows[0][0].ToString();
            }
            else
            {
                LBLSOGOI2.Text = "";
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


            sql = "select stt";

            sql += " from " + user + ".stt_capso a where TRANGTHAI=0";

            if (_makp2 != "")
            {

                sql += " and  MaNoiCap ='" + _makp2 + "'";
            }
            sql += " order by a.stt asc";
            tmp = _acc.get_data(sql).Tables[0];
            if (tmp != null && tmp.Rows.Count > 0)
            {


                if (tmp.Rows.Count >= 4)
                {
                    LBDSCHO12.Text = tmp.Rows[0][0].ToString();
                    LBDSCHO22.Text = tmp.Rows[1][0].ToString();
                    LBDSCHO32.Text = tmp.Rows[2][0].ToString();
                    LBDSCHO42.Text = tmp.Rows[3][0].ToString();
                }
                else if (tmp.Rows.Count == 3)
                {
                    LBDSCHO12.Text = tmp.Rows[0][0].ToString();
                    LBDSCHO22.Text = tmp.Rows[1][0].ToString();
                    LBDSCHO32.Text = tmp.Rows[2][0].ToString();
                    LBDSCHO42.Text = "";

                }
                else if (tmp.Rows.Count == 2)
                {
                    LBDSCHO12.Text = tmp.Rows[0][0].ToString();
                    LBDSCHO22.Text = tmp.Rows[1][0].ToString();
                    LBDSCHO32.Text = "";
                    LBDSCHO42.Text = "";
                }
                else if (tmp.Rows.Count == 1)
                {
                    LBDSCHO12.Text = tmp.Rows[0][0].ToString();
                    LBDSCHO22.Text = "";
                    LBDSCHO32.Text = "";
                    LBDSCHO42.Text = "";
                }


            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (changecolo)
            {
                LBLSOGOI.ForeColor = Color.Red;
                LBLSOGOI2.ForeColor = Color.Red;
            }
            else
            {
                LBLSOGOI.ForeColor = Color.Gold;
                LBLSOGOI2.ForeColor = Color.Gold;
            }
            changecolo = !changecolo;

        }
    }
}
