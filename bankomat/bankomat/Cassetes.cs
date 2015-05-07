using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Cassetes
{
    [Serializable]
    [DataContract]
    public class Cassetes
    {
        [DataMember]
        public int value
        {
            get;
            set;
        }
        [DataMember]
        public int count
        {
            get;
            set;
        }
    }
}
