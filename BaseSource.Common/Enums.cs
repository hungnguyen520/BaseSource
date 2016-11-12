using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Common
{
    public class Enums
    {
        public enum ORDER_STATUS : byte
        {
            New = 1,
            Pending = 2,
            Close = 3
        }
        public enum ORDER_PAYMENT : byte
        {
            Cash = 1,
            Credit = 2
        }

        public enum GENDER : byte
        {
            Female = 0,
            Male = 1
        }
    }
}
