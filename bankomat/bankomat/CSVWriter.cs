using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cassetes
{
    class CSVWriter:IWriter
    {
        public void write(List<Cassetes> list)
        {
            StreamWriter sw = new StreamWriter("CSVFile.csv", false);
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sw.WriteLine(list[i].count + "," + list[i].value);
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}