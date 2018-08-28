using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HISNoiTru.HISNoiTru.Common.Contract
{
    public class ValueInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ValueInfo() {
            Code = "";
            Name = "";
        }
        public ValueInfo(string code ,string name)
        {
            Code = code;
            Name = name;
        }
    }
}
