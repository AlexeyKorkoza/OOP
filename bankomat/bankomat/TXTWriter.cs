using System;
using System.Collections.Generic;
using System.IO;

namespace Cassetes
{
    class TxtWriter:IWriter
    {
        public void Write(List<Cassetes> list)
        {
            StreamWriter sw = new StreamWriter("bankomat.txt", false);
            try
            {
                foreach (Cassetes item in list)
                {
                    sw.WriteLine(item.Count + " " + item.Nominal);
                }
            }
            catch (FileNotFoundException ex)
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