using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Cassetes
{
    public class JsonWriter : IWriter
    {
        public void Write(List<Cassetes> list,string path)
        {
            var json = new DataContractJsonSerializer(typeof(List<Cassetes>));
            using (Stream fStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                json.WriteObject(fStream, list);
                fStream.Close();
            }
        }
    }
}
