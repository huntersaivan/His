using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using E00_Common;
using System.Threading;


namespace E00_STT
{
    public partial class frmXuat6LCD : DevComponents.DotNetBar.Office2007Form
    {
        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string lpszName, int hModule, int dwFlags);
        private int _userid = -1;
        private string _makp = "";
        private string _makp2 = "";
        private string _makp3 = "";
        private string _makp4 = "";
        private string _makp5= "";
        private string _makp6 = "";
        private bool changecolo = false;
        private bool changecolo1 = false;
        private bool changecolo2 = false;
        private bool changecolo3 = false;
        private bool changecolo4 = false;
        private bool changecolo5 = false;
        private bool changecolo6 = false;
        private Acc_Oracle _acc = new Acc_Oracle();
        public frmXuat6LCD()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        public frmXuat6LCD(int p_2, string p, string p2, string p3, string p4, string p5, string p6)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this._userid = p_2;
            this._makp = p;
            this._makp2 = p2;
            this._makp3= p3;
            this._makp4 = p4;
            this._makp5= p5;
            this._makp6 = p6;



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
            string user = _acc.Get_User();
            string sql = "";
            if (!string.IsNullOrEmpty(_makp) && _makp.Substring(0, 1).ToLower() == "p")
            {
                
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp.Substring(1) + "'";
            }
            LBTENPK1.Text = "";
            DataTable tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                LBTENPK1.Text = tmp.Rows[0][0].ToString();
            }



            if (!string.IsNullOrEmpty(_makp2) && _makp2.Substring(0, 1).ToLower() == "p")
            {
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp2.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp2.Substring(1) + "'";
            }
            LBTENPK2.Text = "";
             tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                LBTENPK2.Text = tmp.Rows[0][0].ToString();
            }


            if (!string.IsNullOrEmpty(_makp3) && _makp3.Substring(0, 1).ToLower() == "p")
            {
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp3.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp3.Substring(1) + "'";
            }
            LBTENPK3.Text = "";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                LBTENPK3.Text = tmp.Rows[0][0].ToString();
            }


            if (!string.IsNullOrEmpty(_makp4) && _makp4.Substring(0, 1).ToLower() == "p")
            {
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp4.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp4.Substring(1) + "'";
            }
            LBTENPK4.Text = "";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                LBTENPK4.Text = tmp.Rows[0][0].ToString();
            }


            if (!string.IsNullOrEmpty(_makp5) && _makp5.Substring(0, 1).ToLower() == "p")
            {
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp5.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp5.Substring(1) + "'";
            }
            LBTENPK5.Text = "";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                LBTENPK5.Text = tmp.Rows[0][0].ToString();
            }

            if (!string.IsNullOrEmpty(_makp6) && _makp6.Substring(0, 1).ToLower() == "p")
            {
                sql = "select ten from " + user + ".STT_KHOAPHONG where MA ='" + _makp6.Substring(1) + "'";
            }
            else
            {

                sql = "select ten from " + user + ".STT_KHUVUC where MA ='" + _makp6.Substring(1) + "'";
            }
            LBTENPK6.Text = "";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                LBTENPK6.Text = tmp.Rows[0][0].ToString();
            }

            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread(checknew);
            t.Start(); 
        }

        private void checknew()
        {
            bool ischange = false;
            string user = _acc.Get_User();
            #region lable 1
            string sql = "select stt, TRANGTHAI ,UUTIEN ";
            sql += " from " + user + ".stt_capso a where (TRANGTHAI=1 OR TRANGTHAI=5)";
            if (_makp != "")
            {
                sql += " and  MaNoiCap ='" + _makp + "'";
            }
            sql += " order by a.stt asc";
            DataTable tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                string stext = "";
                if (tmp.Rows.Count == 1)
                {
                    stext = tmp.Rows[0][0].ToString();
                }
                else
                {
                    if ("1" == tmp.Rows[0][2].ToString())
                    {
                        stext = tmp.Rows[0][0].ToString() + " UT " + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString() + " UT ";
                    }
                    else
                    {
                        stext = tmp.Rows[0][0].ToString() + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString();
                    }


                }

                if ((("1" == tmp.Rows[0][1].ToString()) && (LBLGOISO1.Text != stext)) || ("5" == tmp.Rows[0][1].ToString()))
                {
                    LBLGOISO1.Text = stext;
                    ischange = true;
                    changecolo1 = true;
                    pk1.Start();

                }
            }
            #endregion
            //else
            //{
            //    LBLGOISO1.Text = "";
            //}




            sql = "select stt, TRANGTHAI ,UUTIEN ";

            sql += " from " + user + ".stt_capso a where (TRANGTHAI=1 OR TRANGTHAI=5)";
            if (_makp2 != "")
            {

                sql += " and  MaNoiCap ='" + _makp2 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                string stext = "";
                if (tmp.Rows.Count == 1)
                {
                    stext = tmp.Rows[0][0].ToString();
                }
                else
                {
                    if ("1" == tmp.Rows[0][2].ToString())
                    {
                        stext = tmp.Rows[0][0].ToString() + " UT " + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString() + " UT ";
                    }
                    else
                    {
                        stext = tmp.Rows[0][0].ToString() + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString();
                    }


                }

                if ((("1" == tmp.Rows[0][1].ToString()) && (LBLGOISO2.Text != stext)) || ("5" == tmp.Rows[0][1].ToString()))
                {
                    LBLGOISO2.Text = stext;
                    ischange = true;
                    changecolo2 = true;
                    pk2.Start();

                }
            }






            //else
            //{
            //    LBLGOISO2.Text = "";
            //}


            sql = "select stt, TRANGTHAI ,UUTIEN ";

            sql += " from " + user + ".stt_capso a where (TRANGTHAI=1 OR TRANGTHAI=5)";
            if (_makp3 != "")
            {

                sql += " and  MaNoiCap ='" + _makp3 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                string stext = "";
                if (tmp.Rows.Count == 1)
                {
                    stext = tmp.Rows[0][0].ToString();
                }
                else
                {
                    if ("1" == tmp.Rows[0][2].ToString())
                    {
                        stext = tmp.Rows[0][0].ToString() + " UT " + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString() + " UT ";
                    }
                    else
                    {
                        stext = tmp.Rows[0][0].ToString() + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString();
                    }


                }

                if ((("1" == tmp.Rows[0][1].ToString()) && (LBLGOISO3.Text != stext)) || ("5" == tmp.Rows[0][1].ToString()))
                {
                    LBLGOISO3.Text = stext;
                    ischange = true;
                    changecolo3 = true;
                    pk3.Start();

                }
            }





            //else
            //{
            //    LBLGOISO3.Text = "";
            //}


            sql = "select stt, TRANGTHAI ,UUTIEN ";

            sql += " from " + user + ".stt_capso a where (TRANGTHAI=1 OR TRANGTHAI=5)";
            if (_makp4 != "")
            {

                sql += " and  MaNoiCap ='" + _makp4 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                string stext = "";
                if (tmp.Rows.Count == 1)
                {
                    stext = tmp.Rows[0][0].ToString();
                }
                else
                {
                    if ("1" == tmp.Rows[0][2].ToString())
                    {
                        stext = tmp.Rows[0][0].ToString() + " UT " + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString() + " UT ";
                    }
                    else
                    {
                        stext = tmp.Rows[0][0].ToString() + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString();
                    }


                }

                if ((("1" == tmp.Rows[0][1].ToString()) && (LBLGOISO4.Text != stext)) || ("5" == tmp.Rows[0][1].ToString()))
                {
                    LBLGOISO4.Text = stext;
                    ischange = true;
                    changecolo4 = true;
                    pk4.Start();

                }
            }


            //else
            //{
            //    LBLGOISO4.Text = "";
            //}


            sql = "select stt, TRANGTHAI ,UUTIEN ";

            sql += " from " + user + ".stt_capso a where (TRANGTHAI=1 OR TRANGTHAI=5)";
            if (_makp5 != "")
            {

                sql += " and  MaNoiCap ='" + _makp5 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                string stext = "";
                if (tmp.Rows.Count == 1)
                {
                    stext = tmp.Rows[0][0].ToString();
                }
                else
                {
                    if ("1" == tmp.Rows[0][2].ToString())
                    {
                        stext = tmp.Rows[0][0].ToString() + " UT " + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString() + " UT ";
                    }
                    else
                    {
                        stext = tmp.Rows[0][0].ToString() + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString();
                    }


                }

                if ((("1" == tmp.Rows[0][1].ToString()) && (LBLGOISO5.Text != stext)) || ("5" == tmp.Rows[0][1].ToString()))
                {
                    LBLGOISO5.Text = stext;
                    ischange = true;
                    changecolo5 = true;
                    pk5.Start();

                }
            }



            //else
            //{
            //    LBLGOISO5.Text = "";
            //}

            sql = "select stt, TRANGTHAI ,UUTIEN ";
            sql += " from " + user + ".stt_capso a where (TRANGTHAI=1 OR TRANGTHAI=5)";
            if (_makp6 != "")
            {
                sql += " and  MaNoiCap ='" + _makp6 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);
            if (tmp != null && tmp.Rows.Count > 0)
            {
                string stext = "";
                if (tmp.Rows.Count == 1)
                {
                    stext = tmp.Rows[0][0].ToString();
                }
                else
                {
                    if ("1" == tmp.Rows[0][2].ToString())
                    {
                        stext = tmp.Rows[0][0].ToString() + " UT " + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString() + " UT ";
                    }
                    else
                    {
                        stext = tmp.Rows[0][0].ToString() + " ~ " + tmp.Rows[tmp.Rows.Count - 1][0].ToString();
                    }


                }

                if ((("1" == tmp.Rows[0][1].ToString()) && (LBLGOISO6.Text != stext)) || ("5" == tmp.Rows[0][1].ToString()))
                {
                    LBLGOISO6.Text = stext;
                    ischange = true;
                    changecolo6 = true;
                    pk6.Start();

                }
            }



            //else
            //{
            //    LBLGOISO6.Text = "";
            //}

            if (ischange)
            {
                try
                {
                    PlaySound("wav\\wav1.wav", 0, 1);
                }
                catch (Exception)
                {
                }
            }



            #region ds cho

            sql = "select stt";
            sql += " from " + user + ".stt_capso a where TRANGTHAI=0 and UUTIEN =1";
            if (_makp != "")
            {
                sql += " and  MaNoiCap ='" + _makp + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);

            if (tmp != null && tmp.Rows.Count > 0)
            {

                LBLSOTT1.Text = tmp.Rows[0][0].ToString();

            }
            else
            {
                sql = "select stt";
                sql += " from " + user + ".stt_capso a where TRANGTHAI=0";
                if (_makp != "")
                {
                    sql += " and  MaNoiCap ='" + _makp + "'";
                }
                sql += " order by a.stt asc";
                tmp = XL_BANG.Doc(sql);

                if (tmp != null && tmp.Rows.Count > 0)
                {

                    LBLSOTT1.Text = tmp.Rows[0][0].ToString();

                }
                else
                {
                    LBLSOTT1.Text = "";
                }
            }


            sql = "select stt";
            sql += " from " + user + ".stt_capso a where TRANGTHAI=0 and UUTIEN =1";
            if (_makp2 != "")
            {
                sql += " and  MaNoiCap ='" + _makp2 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);

            if (tmp != null && tmp.Rows.Count > 0)
            {

                LBLSOTT2.Text = tmp.Rows[0][0].ToString();

            }
            else
            {
                sql = "select stt";
                sql += " from " + user + ".stt_capso a where TRANGTHAI=0";
                if (_makp2 != "")
                {
                    sql += " and  MaNoiCap ='" + _makp2 + "'";
                }
                sql += " order by a.stt asc";
                tmp = XL_BANG.Doc(sql);

                if (tmp != null && tmp.Rows.Count > 0)
                {

                    LBLSOTT2.Text = tmp.Rows[0][0].ToString();

                }
                else
                {
                    LBLSOTT2.Text = "";
                }

            }

            sql = "select stt";
            sql += " from " + user + ".stt_capso a where TRANGTHAI=0 and UUTIEN =1";
            if (_makp3 != "")
            {
                sql += " and  MaNoiCap ='" + _makp3 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);

            if (tmp != null && tmp.Rows.Count > 0)
            {

                LBLSOTT3.Text = tmp.Rows[0][0].ToString();

            }
            else
            {
                sql = "select stt";
                sql += " from " + user + ".stt_capso a where TRANGTHAI=0";
                if (_makp3 != "")
                {
                    sql += " and  MaNoiCap ='" + _makp3 + "'";
                }
                sql += " order by a.stt asc";
                tmp = XL_BANG.Doc(sql);

                if (tmp != null && tmp.Rows.Count > 0)
                {

                    LBLSOTT3.Text = tmp.Rows[0][0].ToString();

                }
                else
                {
                    LBLSOTT3.Text = "";
                }
            }

            sql = "select stt";
            sql += " from " + user + ".stt_capso a where TRANGTHAI=0 and UUTIEN =1";
            if (_makp4 != "")
            {
                sql += " and  MaNoiCap ='" + _makp4 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);

            if (tmp != null && tmp.Rows.Count > 0)
            {

                LBLSOTT4.Text = tmp.Rows[0][0].ToString();

            }
            else
            {
                sql = "select stt";
                sql += " from " + user + ".stt_capso a where TRANGTHAI=0";
                if (_makp4 != "")
                {
                    sql += " and  MaNoiCap ='" + _makp4 + "'";
                }
                sql += " order by a.stt asc";
                tmp = XL_BANG.Doc(sql);

                if (tmp != null && tmp.Rows.Count > 0)
                {

                    LBLSOTT4.Text = tmp.Rows[0][0].ToString();

                }
                else
                {
                    LBLSOTT4.Text = "";
                }
            }

            sql = "select stt";
            sql += " from " + user + ".stt_capso a where TRANGTHAI=0 and UUTIEN =1";
            if (_makp5 != "")
            {
                sql += " and  MaNoiCap ='" + _makp5 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);


            if (tmp != null && tmp.Rows.Count > 0)
            {

                LBLSOTT5.Text = tmp.Rows[0][0].ToString();

            }
            else
            {

                sql = "select stt";
                sql += " from " + user + ".stt_capso a where TRANGTHAI=0";
                if (_makp5 != "")
                {
                    sql += " and  MaNoiCap ='" + _makp5 + "'";
                }
                sql += " order by a.stt asc";
                tmp = XL_BANG.Doc(sql);


                if (tmp != null && tmp.Rows.Count > 0)
                {

                    LBLSOTT5.Text = tmp.Rows[0][0].ToString();

                }
                else
                {
                    LBLSOTT5.Text = "";
                }
            }
            sql = "select stt";
            sql += " from " + user + ".stt_capso a where TRANGTHAI=0 and UUTIEN =1";
            if (_makp6 != "")
            {
                sql += " and  MaNoiCap ='" + _makp6 + "'";
            }
            sql += " order by a.stt asc";
            tmp = XL_BANG.Doc(sql);

            if (tmp != null && tmp.Rows.Count > 0)
            {

                LBLSOTT6.Text = tmp.Rows[0][0].ToString();

            }
            else
            {
                sql = "select stt";
                sql += " from " + user + ".stt_capso a where TRANGTHAI=0";
                if (_makp6 != "")
                {
                    sql += " and  MaNoiCap ='" + _makp6 + "'";
                }
                sql += " order by a.stt asc";
                tmp = XL_BANG.Doc(sql);

                if (tmp != null && tmp.Rows.Count > 0)
                {

                    LBLSOTT6.Text = tmp.Rows[0][0].ToString();

                }
                else
                {
                    LBLSOTT6.Text = "";
                }
            }
            #endregion

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Color cl1 = Color.DarkViolet;
            Color cl2 = Color.Red;
            if (changecolo)
            {
                LBLGOISO1.ForeColor = cl1;
                LBLGOISO2.ForeColor = cl1;
                LBLGOISO3.ForeColor = cl1;
                LBLGOISO4.ForeColor = cl1;
                LBLGOISO5.ForeColor = cl1;
                LBLGOISO6.ForeColor = cl1;
            }
            else
            {
                if (changecolo1)
                {
                    LBLGOISO1.ForeColor = cl2;  
                }
                if (changecolo2)
                {
                    LBLGOISO2.ForeColor = cl2;
                }
                if (changecolo3)
                {
                    LBLGOISO3.ForeColor = cl2;
                }
                if (changecolo4)
                {
                    LBLGOISO4.ForeColor = cl2;
                }
                if (changecolo5)
                {
                    LBLGOISO5.ForeColor = cl2;
                }
                if (changecolo6)
                {
                    LBLGOISO6.ForeColor = cl2;
                } 
             
            }
            changecolo = !changecolo;

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            changecolo1 = false;
            pk1.Stop();
        }

        private void pk2_Tick(object sender, EventArgs e)
        {
            changecolo2 = false;
            pk2.Stop();
        }

        private void pk3_Tick(object sender, EventArgs e)
        {
            changecolo3 = false;
            pk3.Stop();
        }

        private void pk4_Tick(object sender, EventArgs e)
        {
            changecolo4 = false;
            pk4.Stop();
        }

        private void pk5_Tick(object sender, EventArgs e)
        {
            changecolo5 = false;
            pk5.Stop();
        }

        private void pk6_Tick(object sender, EventArgs e)
        {
            changecolo6 = false;
            pk6.Stop();
        }
    }
}
