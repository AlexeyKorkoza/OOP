using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Cassetes
{
    class JSONWriter : IWriter
    {
        public void write(List<Cassetes> list)
        {
            string Path = @"JSONFile.json";
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Cassetes>));
            using (Stream fStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                json.WriteObject(fStream, list);
                fStream.Close();
            }
        }
    }
}
