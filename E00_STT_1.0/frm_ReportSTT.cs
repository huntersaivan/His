using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace E00_STT
{
    public partial class frm_ReportSTT : Form
    {
        public ReportDocument _rptDoc = new ReportDocument();

        public frm_ReportSTT()
        {
            InitializeComponent();
        }

        public frm_ReportSTT(ReportDocument rptDoc)
        {
            InitializeComponent();
            _rptDoc = rptDoc;
        }
        public void ShowReport(ReportDocument rptDoc)
        {
            CrystalReportViewer crystalReportViewer1 = new CrystalReportViewer();
            crystalReportViewer1.ReportSource = rptDoc;
            this.Controls.Add(crystalReportViewer1);
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Dock = DockStyle.Fill;
        }

        private void frm_Report_Load(object sender, EventArgs e)
        {
            ShowReport(_rptDoc);
        }

        private void frm_ReportSTT_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData ==Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
