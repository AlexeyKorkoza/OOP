using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cassetes
{
    public class XmlWriter:IWriter
    {
        public void Write(List<Cassetes> list)
        {  
            string Path = @"XMLFile.xml";
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Cassetes>));
            Stream fStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
         }        
    }
}
