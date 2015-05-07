using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Cassetes
{
    class XMLWriter:IWriter
    {
        public void write(List<Cassetes> list)
        {  
            string Path = @"XMLFile.xml";
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Cassetes>));
            Stream fStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
         }        
    }
}
