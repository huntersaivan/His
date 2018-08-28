using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace E00_STT
{
    public partial class usc_Dong : UserControl
    {
        private string _makp = "";
        private clsBUS _bus = new clsBUS();
        public Color curren;
        public event EventHandler AlamRing;
        public bool changecolo = false;
        public string Makp
        {
            get
            {
                return _makp;
            }
            set
            {
                if (!string.IsNullOrEmpty(_makp))
                {
                    _makp = value;
                }
                timer1.Start();
            }
        }

        public double thoigian
        {

            set
            {
                timer2.Interval = Convert.ToInt32(value * 1000);
            }
        }
        public usc_Dong()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void lblKhuVuc_TextChanged(object sender, EventArgs e)
        {
            lblGoi.Text = "";
            lblCho.Text="";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread(checknew);
            t.Start();
          

        }
        private void checknew()
        {
            if (!(string.IsNullOrEmpty(_makp)))
            {
                DataTable tmp = _bus.GetSoGoi(_makp);
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

                    if ((("1" == tmp.Rows[0][1].ToString()) && (lblGoi.Text != stext)) || ("5" == tmp.Rows[0][1].ToString()))
                    {
                        lblGoi.Text = stext;
                        if (this.AlamRing != null)
                        {
                            this.AlamRing(null, null);
                        }
                        curren = lblGoi.ForeColor;
                        changecolo = true;
                        timer2.Start();

                    }
                }
                lblCho.Text = _bus.GetSoGoiTiepTheo(_makp, 1);
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            changecolo = false;
            timer2.Stop();
            lblGoi.ForeColor = curren;
        }
    }
}
