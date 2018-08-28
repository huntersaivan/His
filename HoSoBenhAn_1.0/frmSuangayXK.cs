using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevComponents.DotNetBar;
namespace HISQLHSBA
{
	public class frmSuangayXK : Office2007Form
	{
        private LibUtility.Utility _Utility = new LibUtility.Utility();
        private LibDal.AccessData m;
		private string s_ngay,sql;
		private decimal l_id;
		public int kt;
		private string s_msg;
        private System.Windows.Forms.Label label2;
		private MaskedBox.MaskedBox txtngay;
        private PinkieControls.ButtonXP butKetthuc;
        private PinkieControls.ButtonXP butLuu;
		private System.ComponentModel.Container components = null;
		public frmSuangayXK(LibDal.AccessData  _m, string ngay, decimal id)
		{
			InitializeComponent();
			this.s_ngay=ngay;
			this.l_id=id;
            this.m = _m;
			this.s_msg="Kiểm tra chương trình";
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuangayXK));
            this.label2 = new System.Windows.Forms.Label();
            this.txtngay = new MaskedBox.MaskedBox();
            this.butKetthuc = new PinkieControls.ButtonXP();
            this.butLuu = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày xuất viện mới :";
            // 
            // txtngay
            // 
            this.txtngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtngay.Location = new System.Drawing.Point(104, 24);
            this.txtngay.Mask = "##/##/#### ##:##";
            this.txtngay.Name = "txtngay";
            this.txtngay.Size = new System.Drawing.Size(134, 21);
            this.txtngay.TabIndex = 16;
            this.txtngay.Text = "  /  /       :  ";
            this.txtngay.Validated += new System.EventHandler(this.txtngay_Validated);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.DefaultScheme = true;
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butKetthuc.Hint = "";

            this.butKetthuc.Location = new System.Drawing.Point(120, 73);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butKetthuc.Size = new System.Drawing.Size(74, 25);
            this.butKetthuc.TabIndex = 259;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLuu.DefaultScheme = true;
            this.butLuu.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butLuu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Hint = "";
            
            this.butLuu.Location = new System.Drawing.Point(46, 73);
            this.butLuu.Name = "butLuu";
            this.butLuu.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butLuu.Size = new System.Drawing.Size(74, 25);
            this.butLuu.TabIndex = 258;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butOk_Click);
            // 
            // frmSuangayXK
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(241, 117);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.txtngay);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuangayXK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật ngày xuất khoa";
            this.Load += new System.EventHandler(this.frmSuangayXK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private void butOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtngay.Text.Trim()!="")
				{
					s_ngay=txtngay.Text.Trim();
                    sql = "update medibv.xuatkhoa set ngay=to_date('" + s_ngay + "','dd/mm/yyyy hh24:mi') where id in (select id from medibv.nhapkhoa where maql=" + l_id + ") and ttlucrk<>5";
                    m.execute_data(sql);

                    sql = "update medibv.xuatvien set ngay=to_date('" + s_ngay + "','dd/mm/yyyy hh24:mi') where maql=" + l_id;
					m.execute_data(sql);
                    TA_MessageBox.MessageBox.Show("Đã cập nhật thành công!" + "\n" + s_msg);
                    this.Close();
				}
			}
			catch
			{
				MessageBox.Show("Không cập nhật được ngày xuất khoa!");
			}
		}
		private void frmSuangayXK_Load(object sender, System.EventArgs e)
		{
			txtngay.Text=s_ngay.Trim();
		}
		
		private void butCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void chkicd_CheckedChanged(object sender, System.EventArgs e)
		{
		}

		private void txtngay_Validated(object sender, System.EventArgs e)
		{
			if(txtngay.Text.Trim()!="")
			{
				if (txtngay.Text.Length<16)
				{
					MessageBox.Show("Ngày và giờ không hợp lệ !",s_msg);
					txtngay.Focus();
					return;
				}
				if (!_Utility.bNgay(txtngay.Text))
				{
					MessageBox.Show("Ngày và giờ không hợp lệ !",s_msg);
					txtngay.Focus();
					return;
				}
			}
		}
	}
}
