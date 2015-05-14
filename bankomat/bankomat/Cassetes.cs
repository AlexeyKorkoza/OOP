using System;
using System.Runtime.Serialization;

namespace Cassetes
{
    [Serializable]
    [DataContract]
    public class Cassetes
    {
        [DataMember]
        public int Nominal
        {
            get;
            set;
        }
        [DataMember]
        public int Count
        {
            get;
            set;
        }
    }
}