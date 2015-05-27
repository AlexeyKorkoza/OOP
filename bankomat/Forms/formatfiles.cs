using System.Collections.Generic;
using Cassetes;
using Cassetes = Cassetes.Cassetes;

namespace Forms
{
    public class Formatfiles
    {
        public List<global::Cassetes.Cassetes> Loading(string path)
        {
            IReader reader = null;
            List<global::Cassetes.Cassetes> list = new List<global::Cassetes.Cassetes>();
            var maStrings = path.Split('.');
            if (maStrings[1] == "json")
            {
                reader = new JsonReader();
                list = reader.Read(path);
            }
            if (maStrings[1] == "txt")
            {
                reader = new TxtReader();
                list = reader.Read(path);
            }
            if (maStrings[1] == "xml")
            {
                reader = new XmlReader();
                list = reader.Read(path);
            }
            if (maStrings[1] == "csv")
            {
                reader = new CsvReader();
                list = reader.Read(path);
            }
            return list;
        }

    }
}
