using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseV2
{
    public partial class frm_Status : Form
    {
        delegate void SetTextCallback(string text);
        public event EventHandler stop = delegate { };

        public frm_Status()
        {
            InitializeComponent();

        }

        private void frm_Status_Load(object sender, EventArgs e)
        {
            Database.trig += new EventHandler(ChangedText);
            frm_TaoSoLieu.Complete += new EventHandler(CreateComplete);           
        }
        void ChangedText(object sender, EventArgs e)
        {
            SetText(Database._currentTable);
        }
        private void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.stop(this, new EventArgs());
            this.Dispose();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private void CreateComplete(object sender, EventArgs e)
        {
           
        }
        
    }
}
