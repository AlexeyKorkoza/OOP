using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cassetes
{
    public class XmlWriter:IWriter
    {
        public void Write(List<Cassetes> list,string path)
        {  
            var xmlFormat = new XmlSerializer(typeof(List<Cassetes>));
            Stream fStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
         }        
    }
}
