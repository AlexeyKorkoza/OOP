using System;
using System.Collections.Generic;
using System.Xml;

namespace Cassetes
{
   public class XmlReader: IReader
    {        
       public List<Cassetes> Read(string path)
        {
           List<Cassetes> list = new List<Cassetes>();
           try
           {
               XmlDocument xDoc = new XmlDocument();
               xDoc.Load(path);
               XmlElement xRoot = xDoc.DocumentElement;
               if (xRoot != null)
                   foreach (XmlElement xnode in xRoot)
                   {
                       Cassetes cassetes = new Cassetes();
                       foreach (XmlNode childnode in xnode.ChildNodes)
                       {
                           if (childnode.Name == "count")
                               cassetes.Count = Convert.ToInt32(childnode.InnerText);
                           if (childnode.Name == "value")
                               cassetes.Nominal = Convert.ToInt32(childnode.InnerText);
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