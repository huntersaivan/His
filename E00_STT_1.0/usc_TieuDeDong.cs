using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace E00_STT
{
    public partial class usc_TieuDeDong : UserControl
    {
        
        public string NoiDung
        {
            get { 
                
                return lblTenPK.Text+";"+lblMoiSo.Text+";"+lblSoTT.Text ;
            
            }
            set {
                    if (value!=null&&(!string.IsNullOrEmpty(value)))
                    {
                        string[] lstTxt = value.Split(';');
                        if (lstTxt.Length>=3)
                        {
                            lblTenPK.Text = lstTxt[0];
                            lblMoiSo.Text = lstTxt[1];
                            lblSoTT.Text = lstTxt[2];
                        }

                    }
                }
        }

        public usc_TieuDeDong()
        {
            InitializeComponent();
        }
    }
}
