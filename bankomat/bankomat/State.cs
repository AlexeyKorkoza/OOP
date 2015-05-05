using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassetes
{
    class State
    {
        public enum state
        {
            Ok = 1,
            NotEnoughMoney = 2,
            InvalidInput = 3,
            Error = 4,
        }
    }
}
