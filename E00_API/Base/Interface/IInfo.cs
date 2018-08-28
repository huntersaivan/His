using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E00_API.Base.Interface
{
    public interface IInfo<in T>
    {
        void Copy(T info);
        object ID { get; set; }
    }
}
