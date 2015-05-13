using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace Cassetes.Reader
{
   class XMLReader: IReader
    {        
       public List<Cassetes> read()
        {
           XmlTextReader  reader = new XmlTextReader("XMLFile.xml");
           List<Cassetes> list = new List<Cassetes>() { };
           try
           {
               XmlDocument xDoc = new XmlDocument();
               xDoc.Load("XMLFile.xml");
               XmlElement xRoot = xDoc.DocumentElement;
               foreach (XmlElement xnode in xRoot)
               {
                   Cassetes cassetes = new Cassetes();
                   foreach (XmlNode childnode in xnode.ChildNodes)
                   {
                       if (childnode.Name == "count")
                           cassetes.count = Convert.ToInt32(childnode.InnerText);
                       if (childnode.Name == "value")
                           cassetes.value = Convert.ToInt32(childnode.InnerText);
                   }
                   list.Add(cassetes);
               }
           }
           catch(XmlException ex)
           {
               Console.WriteLine(ex.Message);
           }
            return list;
        }
    }
}