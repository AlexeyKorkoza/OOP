using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cassetes
{
    class TXTReader:IReader
    {
        public List<Cassetes> read()
        {
            List<Cassetes> list = new List<Cassetes>() { };
            StreamReader sr = new StreamReader("bankomat.txt");
            string line;
            string[] array;
            try
            {
                while ((line = sr.ReadLine()) != null)
                {
                    array = line.Split(new char[] { ' ', '\t' });
                    Cassetes cassetes = new Cassetes();
                    cassetes.count = int.Parse(array[0]);
                    cassetes.value = int.Parse(array[1]);
                    list.Add(cassetes);
                    line = string.Empty;
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
