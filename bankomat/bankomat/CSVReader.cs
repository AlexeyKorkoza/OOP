using System;
using System.Collections.Generic;
using System.IO;

namespace Cassetes
{
    public class CsvReader : IReader
    {
        public List<Cassetes> Read()
        {
            List<Cassetes> list = new List<Cassetes>();
            StreamReader sr = new StreamReader("CSVFile.csv");
            try
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var array = line.Split(',', '\t');
                    var cassetes = new Cassetes
                    {
                        Count = int.Parse(array[0]),
                        Nominal = int.Parse(array[1])
                    };
                    if (cassetes.Count > 0)
                    list.Add(cassetes);
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
            return list;
        }
    }
}
