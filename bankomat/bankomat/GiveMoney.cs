using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bankomat
{
    class GiveMoney
    {
        public static void calculation_and_write_in_file(List<bankomat> list, int money, int min)
        {
            try
            {
                int count = 0;
                int m = 0;
                int change = 0;
                m = money;
                for (int p = 0; p < list.Count; p++)
                {                   
                        count = m / list[p].nominal;
                        if (count < list[p].count)
                        {
                            change = m - count * list[p].nominal;
                            if (change == 0)
                            {
                                m = m - count * list[p].nominal;
                                Console.WriteLine("{0} {1}", count, list[p].nominal);
                            }
                            else if (change < min)
                            {
                                count--;
                                m = m - count * list[p].nominal;
                                Console.WriteLine("{0} {1}", count, list[p].nominal);
                            }
                            else
                            {
                                m -= count * list[p].nominal;
                                Console.WriteLine("{0} {1}", count, list[p].nominal);
                            }
                            list[p].count -= count;
                        }
                        else
                        {
                            change = m - count * list[p].nominal;
                            if (change == 0)
                            {
                                m = m - list[p].count * list[p].nominal;
                                Console.WriteLine("{0} {1}", list[p].count, list[p].nominal);
                            }
                            else if (change < min)
                            {
                                list[p].count--;
                                m = m - list[p].count * list[p].nominal;
                                Console.WriteLine("{0} {1}", list[p].count, list[p].nominal);
                            }
                            else
                            {
                                m -= list[p].count * list[p].nominal;
                                Console.WriteLine("{0} {1}", list[p].count, list[p].nominal);
                            }
                            list[p].count -= list[p].count;
                        }
                        count = 0;
                        change = 0;
                    }                
                if (m > 0)
                {
                    Console.WriteLine("The Bank can not fully give the amount entered");
                    Console.WriteLine("The remainder of the amount entered:{0}", Math.Abs(m));
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
