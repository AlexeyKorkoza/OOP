using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Cassetes
{
    public class JsonReader:IReader
    {
        public List<Cassetes> Read(string path)
        {
            var json = new DataContractJsonSerializer(typeof(List<Cassetes>));
            Stream fstream = new FileStream(path,FileMode.Open);
            var temp = (List<Cassetes>)json.ReadObject(fstream);
            fstream.Close();
            return temp;
        }
    }
}
