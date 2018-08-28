using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;



namespace DatabaseV2
{
    public partial class frm_TaoSoLieu : E00_Base.frm_Base
    {
        CancellationTokenSource ts = new CancellationTokenSource();
        public static event EventHandler Complete = delegate { };

        

        public frm_TaoSoLieu()
        {
            InitializeComponent();
        }

        private void btnTaoSoLieu_Click(object sender, EventArgs e)
        {
            ts = new CancellationTokenSource();
            var ui = TaskScheduler.FromCurrentSynchronizationContext();
            List<Task> tasks = new List<Task>();

            var frm = new frm_Status();
            frm.stop += new EventHandler(Stop_Task);

            Task task = Task.Factory.StartNew(() =>
            {
                try
                {                    
                    Database.CheckOther();//FIRST BCAUSE INITIAL API
                    Database.Create_Table(ts);                   
                    TA_MessageBox.MessageBox.Show("Tạo cấu trúc thành công!"
                                                        , TA_MessageBox.MessageIcon.Information);
                    Completed();
                    this.Invoke((MethodInvoker)delegate
                    {
                        frm.Close();
                    });
                }
                catch {  }
            }, ts.Token);

            frm.ShowDialog();

            //Tạo số liệu viện phí
            try
            {
                VienPhiExtension.Database.CheckDatabase();
            }
            catch
            {
            }
        }

        private void btnTaoDuLieuMau_Click(object sender, EventArgs e)
        {
            Database.Insert_data();
            TA_MessageBox.MessageBox.Show("Tạo dữ liệu mẫu thành công!"
                                                    , TA_MessageBox.MessageIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_TaoSoLieu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //DatabaseSQLSever.CheckOther();//FIRST BCAUSE INITIAL API
            //DatabaseSQLSever.Create_Table();
            //TA_MessageBox.MessageBox.Show("Tạo cấu trúc thành công!"
            //                                       , "Thông báo"
            //                                       , "Đồng ý"
            //                                        , TA_MessageBox.MessageButton.OK
            //                                        , TA_MessageBox.MessageIcon.Information);
        }



        void Stop_Task(object sender, EventArgs e)
        {
            ts.Cancel();
        }
        static void Completed()
        {
            Complete(null, new EventArgs());
        }
    }
}
