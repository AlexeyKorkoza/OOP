using System;
using System.Collections.Generic;
using System.IO;

namespace Cassetes
{
    public class CsvWriter:IWriter
    {
        public void Write(List<Cassetes> list)
        {
            StreamWriter sw = new StreamWriter("CSVFile.csv", false);
            try
            {
                foreach (Cassetes itemCassetes in list)
                {
                    if(itemCassetes.Count!=0)
                        sw.WriteLine(itemCassetes.Count + "," + itemCassetes.Nominal);
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