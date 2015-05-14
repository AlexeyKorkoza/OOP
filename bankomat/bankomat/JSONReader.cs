using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Cassetes
{
    class JsonReader:IReader
    {
        public List<Cassetes> Read()
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
