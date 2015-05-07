using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Cassetes
{
    class JSONReader:IReader
    {
        public List<Cassetes> read()
        {
            string Path = @"JSONFIle.json";
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Cassetes>));
            Stream fstream = new FileStream(Path,FileMode.Open);
            var temp = (List<Cassetes>)json.ReadObject(fstream);
            fstream.Close();
            return temp;
        }
    }
}
