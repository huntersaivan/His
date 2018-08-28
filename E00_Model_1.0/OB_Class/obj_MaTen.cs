using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E00_Model
{
    public partial class  obj_MaTen
    {
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

        public obj_MaTen()
        {
            
        }

        public obj_MaTen(string ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }
    }
}
