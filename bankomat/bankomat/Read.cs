using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bankomat
{
    class Read
    {
        public static List<bankomat> read()
        {
            List<bankomat> list = new List<bankomat>() { };
            StreamReader sr = new StreamReader("bankomat.txt");
            string line;
            string[] array;
            try
            {
                while ((line = sr.ReadLine()) != null)
                {
                    array = line.Split(new char[] { ' ', '\t' });
                    bankomat bankomat1 = new bankomat();
                    bankomat1.count = int.Parse(array[0]);
                    bankomat1.nominal = int.Parse(array[1]);
                    if (bankomat1.count != 0)
                    {
                        list.Add(bankomat1);
                    }                    
                    line = string.Empty;
                }
                sr.Close();
            }
            catch
            {
                Console.WriteLine("File found not");
            }
            return list;
        }        
    }
}
