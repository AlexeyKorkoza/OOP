using System;
using System.Collections.Generic;
using System.IO;

namespace Cassetes
{
    public class TxtReader:IReader
    {
        public List<Cassetes> Read(string path)
        {
            List<Cassetes> list = new List<Cassetes>();
            StreamReader sr = new StreamReader(path);
            try
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var array = line.Split(' ', '\t');
                    Cassetes cassetes = new Cassetes
                    {
                        Count = int.Parse(array[0]),
                        Nominal = int.Parse(array[1])
                    };
                    if(cassetes.Count > 0)
                    list.Add(cassetes);
                }
            }
            catch (FileNotFoundException ex)
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
