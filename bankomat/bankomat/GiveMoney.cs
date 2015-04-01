using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cassetes
{
    class GiveMoney
    {
       
        public static  Dictionary<int,int> calculation(List<Cassetes> list, int money, int min)
        {
            Dictionary<int,int> moneyoutput = new Dictionary<int,int>();
            try
            {
                int count = 0;
                int m = 0;
                int change = 0;
                m = money;
                Cassetes cassetes = new Cassetes();
                for (int p = 0; p < list.Count; p++)
                {
                    if (list[p].count != 0)
                    {
                        count = m / list[p].nominal;
                        if (count < list[p].count)
                        {
                            change = m - count * list[p].nominal;
                            if (change == 0)
                            {
                                m = m - count * list[p].nominal;
                                moneyoutput.Add(count, list[p].nominal);
                            }
                            else if (change < min)
                            {
                                count--;
                                m = m - count * list[p].nominal;
                                moneyoutput.Add(count, list[p].nominal);
                            }
                            else
                            {
                                m -= count * list[p].nominal;
                                moneyoutput.Add(count, list[p].nominal);
                            }
                            list[p].count -= count;
                        }
                        else
                        {
                            change = m - count * list[p].nominal;
                            if (change == 0)
                            {
                                m = m - list[p].count * list[p].nominal;
                                moneyoutput.Add(list[p].count, list[p].nominal);
                            }
                            else if (change < min)
                            {
                                list[p].count--;
                                m = m - list[p].count * list[p].nominal;
                                moneyoutput.Add(list[p].count, list[p].nominal);
                            }
                            else
                            {
                                m -= list[p].count * list[p].nominal;
                                moneyoutput.Add(list[p].count, list[p].nominal);
                            }
                            list[p].count -= list[p].count;
                        }
                        count = 0;
                        change = 0;
                    }
                }               
                if (m > 0)
                {
                    Console.WriteLine("The bank can not repay in full");
                    Console.WriteLine("The remainder of the amount entered:{0}", Math.Abs(m));
                }
                
            }
            catch
            {              
            }
            return moneyoutput;
        }

    }
}
