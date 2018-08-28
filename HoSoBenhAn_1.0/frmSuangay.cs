using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevComponents.DotNetBar;
using TA_MessageBox;

namespace HISToltal
{
	public class frmSuangay : Office2007Form
	{
        private LibUtility.Utility _Utility = new LibUtility.Utility(); 
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn1;
		private System.Windows.Forms.TextBox mabn2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox mann;
        private System.Windows.Forms.Label label6;
        private LibDal.AccessData m;
		private DataSet dsxml=new DataSet();
		private string mabn,sql,s_mmyy="";
		private System.Windows.Forms.TextBox tqx;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox benhan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ngayra;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown thang;
		private System.Windows.Forms.NumericUpDown nam;
        private PinkieControls.ButtonXP butKetthuc;
        private PinkieControls.ButtonXP butLuu;
		private System.ComponentModel.Container components = null;

		public frmSuangay(LibDal.AccessData _m, string _mabn)
		{
			InitializeComponent();
            this.m = _m;
            this.mabn = _mabn;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuangay));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn1 = new System.Windows.Forms.TextBox();
            this.mabn2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tqx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.benhan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ngayra = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.thang = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.butKetthuc = new PinkieControls.ButtonXP();
            this.butLuu = new PinkieControls.ButtonXP();
            ((System.ComponentModel.ISupportInitialize)(this.thang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn1
            // 
            this.mabn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn1.Enabled = false;
            this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn1.Location = new System.Drawing.Point(360, 144);
            this.mabn1.MaxLength = 2;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(24, 21);
            this.mabn1.TabIndex = 3;
            this.mabn1.Validated += new System.EventHandler(this.mabn1_Validated);
            this.mabn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            this.mabn1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn1_KeyPress);
            // 
            // mabn2
            // 
            this.mabn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn2.Enabled = false;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(96, 36);
            this.mabn2.MaxLength = 8;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(76, 21);
            this.mabn2.TabIndex = 4;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            this.mabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            this.mabn2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn2_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(216, 36);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(200, 21);
            this.hoten.TabIndex = 6;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(472, 36);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(48, 21);
            this.namsinh.TabIndex = 8;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(264, 60);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(256, 21);
            this.diachi.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(216, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tqx
            // 
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.Enabled = false;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(96, 84);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(424, 21);
            this.tqx.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tỉnh,Quận,P.Xã :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(96, 60);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(120, 21);
            this.mann.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Nghề nghiệp :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-15, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 19;
            this.label8.Text = "Sửa thành ngày giờ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy HH:mm";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(96, 132);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(112, 21);
            this.tu.TabIndex = 20;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ngày vào :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(96, 108);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(184, 21);
            this.ngayvao.TabIndex = 16;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhan_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(224, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thông tin :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(266, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "Ngày ra :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // benhan
            // 
            this.benhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.benhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhan.Items.AddRange(new object[] {
            "Nhận bệnh",
            "Nhập khoa",
            "Ngoại trú",
            "Phòng lưu",
            "Xuất khoa"});
            this.benhan.Location = new System.Drawing.Point(296, 13);
            this.benhan.Name = "benhan";
            this.benhan.Size = new System.Drawing.Size(224, 21);
            this.benhan.TabIndex = 1;
            this.benhan.SelectedIndexChanged += new System.EventHandler(this.benhan_SelectedIndexChanged);
            this.benhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhan_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(411, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ngayra.Enabled = false;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(328, 108);
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(192, 21);
            this.ngayra.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 23);
            this.label11.TabIndex = 23;
            this.label11.Text = "Số liệu tháng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thang
            // 
            this.thang.Location = new System.Drawing.Point(96, 13);
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(40, 20);
            this.thang.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(130, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 23);
            this.label12.TabIndex = 25;
            this.label12.Text = "năm :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nam
            // 
            this.nam.Location = new System.Drawing.Point(169, 13);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(47, 20);
            this.nam.TabIndex = 26;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.DefaultScheme = true;
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.butKetthuc.Hint = "";
            
            this.butKetthuc.Location = new System.Drawing.Point(264, 172);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butKetthuc.Size = new System.Drawing.Size(74, 25);
            this.butKetthuc.TabIndex = 258;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
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
            
            this.butLuu.Location = new System.Drawing.Point(190, 172);
            this.butLuu.Name = "butLuu";
            this.butLuu.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.butLuu.Size = new System.Drawing.Size(74, 25);
            this.butLuu.TabIndex = 257;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butSua_Click);
            // 
            // frmSuangay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 214);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.benhan);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.tqx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuangay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa ngày nhập sai từ hồ sơ bệnh án";
            this.Load += new System.EventHandler(this.frmSuangay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void mabn1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            //if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn1_Validated(object sender, System.EventArgs e)
		{
            //mabn1.Text=mabn1.Text.PadLeft(2,'0');
		}

		private void mabn2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void emp_text()
		{
			hoten.Text="";
			namsinh.Text="";
			diachi.Text="";
			mann.Text="";
			tqx.Text="";
			ngayra.Text="";
			dsxml.Clear();
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			emp_text();
			mabn2.Text=mabn2.Text.PadLeft(8,'0');
			mabn= mabn2.Text;
			s_mmyy=thang.Value.ToString().PadLeft(2,'0')+nam.Value.ToString().Substring(2);
			sql="select a.hoten,a.namsinh,nvl(a.sonha,'')||' '||a.thon as diachi,b.tennn,trim(c.tentt)||','||trim(d.tenquan)||','||e.tenpxa as tqx";
			sql+=" from medibv.btdbn a inner join btdnn_bv b on a.mann=b.mann inner joon btdtt c on a.matt=c.matt inner join btdquan d on a.maqu=d.maqu inner join btdpxa e on a.maphuongxa=e.maphuongxa";
            sql += " where and a.mabn='" + mabn + "'";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				diachi.Text=r["diachi"].ToString();
				mann.Text=r["tennn"].ToString();
				tqx.Text=r["tqx"].ToString();
				break;
			}
			if (hoten.Text=="")
			{
			TA_MessageBox.MessageBox.Show("Không tìm thấy mã người bệnh "+mabn);
				mabn1.Focus();
			}
			else
			{
                if (benhan.SelectedIndex == 0)
                {
                    sql = "select maql, to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayvao, ' ' as ngayra";
                    sql += " from medibv.benhandt where loaiba=1 and mabn='" + mabn2.Text + "' order by maql desc";
                }
				else if (benhan.SelectedIndex==1)
				{
					sql="select a.id as maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra";
                    sql += " from medibv.nhapkhoa a left join medibv.xuatkhoa b on a.id=b.id inner join medibv.benhandt c on a.maql=c.maql where c.loaiba=1 and a.mabn='" +  mabn2.Text + "' order by a.id desc";
				}
				else
					if(benhan.SelectedIndex==4)
				{
					sql="select a.id as maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra";
                    sql += " from medibv.nhapkhoa a inner join xuatkhoa b on a.id=b.id inner join benhandt c on a.maql=c.maql where c.loaiba=1 and a.mabn='" +  mabn2.Text + "' order by a.id desc";
				}
				else 
                    if(benhan.SelectedIndex==2)
				{
					sql="select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra";
                    sql += " from " + m.user +".benhanngtr a where a.mabn='" +  mabn2.Text + "'";
					sql+=" order by a.maql desc";
				}
                else if (benhan.SelectedIndex == 3)
                {
                    sql = "select a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra";
                    sql += " from " + m.user + s_mmyy + ".benhancc a where a.mabn='" +  mabn2.Text + "'";
                    sql += " order by a.maql desc";
                }
				int irec=1;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					if (irec==1)
					{
						int dd=int.Parse(r["ngayvao"].ToString().Substring(0,2));
						int mm=int.Parse(r["ngayvao"].ToString().Substring(3,2));
						int yyyy=int.Parse(r["ngayvao"].ToString().Substring(6,4));
						int hh=int.Parse(r["ngayvao"].ToString().Substring(11,2));
						int mi=int.Parse(r["ngayvao"].ToString().Substring(14,2));
						tu.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
						ngayra.Text=r["ngayra"].ToString();
					}
					updrec(long.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["ngayra"].ToString());
					irec++;
				}
			}
		}

		private void updrec(long maql,string ngayvao,string ngayra)
		{
			DataRow r1=dsxml.Tables[0].NewRow();
			r1["maql"]=maql;
			r1["ngayvao"]=ngayvao;
			r1["ngayra"]=ngayra;
			dsxml.Tables[0].Rows.Add(r1);
		}

		private bool kiemtra()
		{
			if (hoten.Text=="" || mabn2.Text=="")
			{
				mabn1.Focus();
				return false;
			}
			//
			if(ngayvao.SelectedIndex==-1)
			{
				ngayvao.Focus();
				return false;
			}
			//
			if(benhan.SelectedIndex==0)
			{
				string ngay="",s_tenkp="";
				sql="select to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp from medibv.benhandt a inner join medibv.nhapkhoa b on a.maql=b.maql inner join btdkp_bv c on b.makp=c.makp where b.maql="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
				DataTable tmp=m.get_data(sql).Tables[0];
				if (tmp.Rows.Count>0)
				{
					ngay=tmp.Rows[0]["ngay"].ToString();
					s_tenkp=tmp.Rows[0]["tenkp"].ToString();
                    if (!_Utility.bNgaygio(ngay, tu.Text))
					{
                        TA_MessageBox.MessageBox.Show("Ngày nhập viện không được lớn hơn ngày nhập khoa : "+s_tenkp.ToUpper() +" ["+ngay+"]");
						tu.Focus();
						return false;
					}
				}
			}
			//
			if (benhan.SelectedIndex==1)
			{
				string ngay="";
				sql="select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay from medibv.benhandt a inner join medibv.nhapkhoa b on a.maql=b.maql where b.id="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
				DataTable tmp=m.get_data(sql).Tables[0];
				if (tmp.Rows.Count>0)
				{
					ngay=tmp.Rows[0]["ngay"].ToString();
					if (!_Utility.bNgaygio(tu.Text,ngay))
					{
                        TA_MessageBox.MessageBox.Show("Ngày vào khoa không được nhỏ hơn ngày vào viện ("+ngay+")");
						tu.Focus();
						return false;
					}
				}
			}
			if (ngayra.Text!="")
			{
				if(benhan.SelectedIndex==4)
				{
					string ngay="",s_tenkp="",s_khoachuyen="";
					sql="select to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay from medibv.benhandt a inner join medibv.nhapkhoa b on a.maql=b.maql where b.id="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
					DataTable tmp=m.get_data(sql).Tables[0];
					if (tmp.Rows.Count>0)
					{
						ngay=tmp.Rows[0]["ngay"].ToString();
                        if (!_Utility.bNgaygio(tu.Text, ngay))
						{
                            TA_MessageBox.MessageBox.Show("Ngày xuất khoa không được nhỏ hơn ngày nhập khoa ("+ngay+")");
							tu.Focus();
							return false;
						}
					}
					//
					sql="select to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,d.tenkp khoachuyen from medibv.chuyenkhoa a inner join nhapkhoa b on a.maql=b.maql and a.khoaden=b.makp inner join btdkp_bv c on b.makp=c.makp inner join btdkp_bv d on a.makp=d.makp where a.id="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
					tmp=m.get_data(sql).Tables[0];
					if (tmp.Rows.Count>0)
					{
						ngay=tmp.Rows[0]["ngay"].ToString();
						s_tenkp=tmp.Rows[0]["tenkp"].ToString();
						s_khoachuyen=tmp.Rows[0]["khoachuyen"].ToString();
                        if (!_Utility.bNgaygio(ngay, tu.Text))
						{
                            TA_MessageBox.MessageBox.Show("Ngày xuất khoa "+s_khoachuyen.ToUpper()+" không được lớn hơn ngày nhập khoa : "+s_tenkp.ToUpper() +" ["+ngay+"]");
							tu.Focus();
							return false;
						}
					}
				}
                else if (benhan.SelectedIndex == 2)
                {
                    string ngay = "";
                    sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from medibv.benhanngtr where maql=" + long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
                    DataTable tmp = m.get_data(sql).Tables[0];
                    if (tmp.Rows.Count > 0)
                    {
                        ngay = tmp.Rows[0]["ngay"].ToString();
                        if (!_Utility.bNgaygio(tu.Text, ngay))
                        {
                            TA_MessageBox.MessageBox.Show("Ngày vào khoa không được nhỏ hơn ngày vào viện (" + ngay + ")");
                            tu.Focus();
                            return false;
                        }
                    }
                }
                else
                    if (!_Utility.bNgaygio(ngayra.Text, tu.Text))
                    {
                        TA_MessageBox.MessageBox.Show("Ngày vào không được lớn hơn ngày ra !");
                        tu.Focus();
                        return false;
                    }
			}
			return true;
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			s_mmyy=tu.Text.Substring(3,2)+tu.Text.Substring(8,2);
			if (TA_MessageBox.MessageBox.Show("Đồng ý sửa ngày giờ "+ngayvao.Text.Substring(0,16)+" thành "+tu.Text, MessageIcon.Question)==DialogResult.Yes)
			{
				if(benhan.SelectedIndex==0)
					m.execute_data("update benhandt set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where maql="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
				else
					if (benhan.SelectedIndex==1) 
				{
					m.execute_data("update nhapkhoa set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where id="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
					m.execute_data("update hiendien set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where id="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
				}
				else 
					if(benhan.SelectedIndex==2||benhan.SelectedIndex==4)
				{
					m.execute_data("update benhandt set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where maql="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
					m.execute_data("update nhapkhoa set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where maql="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
					m.execute_data("update hiendien set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where maql="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
				}
				else
					if (benhan.SelectedIndex==3) 
				{
					m.execute_data("update "+m.user+s_mmyy+".benhandt set ngay=to_date('"+tu.Text.Substring(0,16)+"','dd/mm/yyyy hh24:mi') where maql="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
					m.execute_data("update "+m.user+s_mmyy+".xuatvien set ngay=to_date('"+tu.Text.Substring(0,16)+"','dd/mm/yyyy hh24:mi') where maql="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
				}
				else
					if(benhan.SelectedIndex==5)
				{
					m.execute_data("update xuatkhoa set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where id="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
					m.execute_data("update chuyenkhoa set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where id="+long.Parse(dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString()));
					if(ngayra.Text!="")
						m.execute_data("update xuatvien set ngay=to_date('"+tu.Text+"','dd/mm/yyyy hh24:mi') where mabn='"+mabn+"' and to_char(ngay,'dd/mm/yyyy')='"+dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString().Substring(0,10)+"'");
				}
			TA_MessageBox.MessageBox.Show("Đã sửa thành công !");
				mabn1.Focus();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmSuangay_Load(object sender, System.EventArgs e)
		{
			dsxml.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
            //mabn1.Text = mabn.Substring(0, 2);//DateTime.Now.Year.ToString().Substring(2,2);
            mabn2.Text = mabn.Substring(2);
			thang.Value=decimal.Parse(DateTime.Now.Month.ToString());
			decimal t=decimal.Parse(DateTime.Now.Year.ToString());
			nam.Maximum=t+3;nam.Value=t;
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="MAQL";
			ngayvao.DataSource=dsxml.Tables[0];
			benhan.SelectedIndex=4;
            mabn2_Validated(null, null);
		}

		private void mabn1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
            _Utility.MaskDigit(e);
		}

		private void mabn2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
            _Utility.MaskDigit(e);
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao && ngayvao.Items.Count>0) 
			{
				string ngay=dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString();
				int dd=int.Parse(ngay.Substring(0,2));
				int mm=int.Parse(ngay.Substring(3,2));
				int yyyy=int.Parse(ngay.Substring(6,4));
				int hh=int.Parse(ngay.Substring(11,2));
				int mi=int.Parse(ngay.Substring(14,2));
				tu.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
				ngayra.Text=dsxml.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
			}
		}

		private void benhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void benhan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==benhan)
			{
				if(benhan.SelectedIndex==5) 
				{
					label7.Text="Ngày xuất :";
					label10.Text="Ra viện :";
				}
				else
				{
					label7.Text="Ngày vào :";
					label10.Text="Ngày ra :";
				}
                mabn2_Validated(null, null);
			}
		}
	}
}
