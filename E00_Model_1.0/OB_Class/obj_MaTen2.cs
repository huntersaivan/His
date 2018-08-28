using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E00_Base
{
    public partial class obj_MaTen2
    {
        #region Thuộc tính

        private string ma;

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private string trangThai;

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        #endregion

        #region Khởi tạo

        public obj_MaTen2()
        {
        }

        public obj_MaTen2(string ma, string ten, string trangThai)
        {
            Ma = ma;
            Ten = ten;
            TrangThai = trangThai;
        }

        #endregion
    }
}
