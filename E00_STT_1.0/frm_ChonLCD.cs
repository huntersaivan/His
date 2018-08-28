using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E00_Model;
using E00_Common;

namespace E00_STT
{
    public partial class frm_ChonLCD : DevComponents.DotNetBar.Office2007Form
    {

        #region Biến toàn cục

        private string _userError = "";
        private string _systemError = "";
        private Api_Common _api = new Api_Common();
        private clsBUS _bus = new clsBUS();

        #endregion

        #region Khởi tạo

        public frm_ChonLCD()
        {
            InitializeComponent();
            _api.KetNoi();
        }
        #endregion

        #region Events
        private void frm_ChonLCD_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> lstField = new List<string>();
                lstField.Add(cls_STT_NhomLCD.col_ID);
                lstField.Add(cls_STT_NhomLCD.col_Ten);
                Dictionary<string, string> dicWhere = new Dictionary<string, string>();
                dicWhere.Add(cls_STT_NhomLCD.col_TamNgung, "0");
                slbLCD.DataSource = _api.GetDataAll(ref _userError, ref _systemError, cls_STT_NhomLCD.tb_TenBang, lstField, dicWhere);
            }
            catch
            {
                slbLCD.DataSource = null;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(slbLCD.txtMa.Text))
            {
                TA_MessageBox.MessageBox.Show("Vui lòng chọn LCD!", TA_MessageBox.MessageIcon.Warning);
                slbLCD.txtTen.Focus();
            }
            else
            {
                frm_LCD1 frm = new frm_LCD1(slbLCD.txtMa.Text);
                if (!_bus.CheckOpened(frm.Text))
                {
                    Screen[] screens = Screen.AllScreens;
                    if (Screen.AllScreens.Length > 1)
                    {
                        if (chkVuaManHinh.Checked)
                        {
                            frm.Location = new Point(Screen.AllScreens[1].WorkingArea.Location.X + 25, Screen.AllScreens[1].WorkingArea.Location.Y + 10);
                            frm.Width = Screen.AllScreens[1].WorkingArea.Width - 50;
                            frm.Height = Screen.AllScreens[1].WorkingArea.Height - 10;
                        }
                        else
                        {
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Location = Screen.AllScreens[1].WorkingArea.Location;
                        }
                    }
                    else
                    {
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Location = Screen.AllScreens[0].WorkingArea.Location;
                    }
                    frm.Show();
                    this.Close();
                }
                else
                {
                    Application.OpenForms[frm.Name].Focus();
                    this.Close();
                }

            }
        } 
        #endregion

    }
}
