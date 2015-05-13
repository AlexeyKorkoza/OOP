using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cassetes.Operation
{
    class GiveMoney
    {
        public static List<int> calculation(List<Cassetes> list, int money, int min)
        {
            List<int> moneyoutput = new List<int>();
            try
            {                
                int count = 0;
                int m = 0;
                int change = 0;
                int perem = 0;
                m = money;
                for (int p = 0; p < list.Count; p++)
                {
                    if (list[p].count != 0)
                    {
                        if (m == 0)
                            break;
                        count = m / list[p].value;
                        if (count < list[p].count)
                        {
                            change = m - count * list[p].value;
                            if (change == 0)
                            {
                                m = m - count * list[p].value;
                                moneyoutput.Add(count);
                            }
                            else if (change < min)
                            {
                                count--;
                                m = m - count * list[p].value;
                                moneyoutput.Add(count);
                            }
                            else
                            {
                                m -= count * list[p].value;
                                moneyoutput.Add(count);
                            }
                            list[p].count -= count;
                        }
                        else
                        {
                            change = m - count * list[p].value;
                            if (change == 0)
                            {
                                m = m - list[p].count * list[p].value;
                                moneyoutput.Add(list[p].count);
                            }
                            else if (change < min)
                            {
                                list[p].count--;
                                m = m - list[p].count * list[p].value;
                                moneyoutput.Add(list[p].count);
                            }
                            else
                            {
                                m -= list[p].count * list[p].value;
                                moneyoutput.Add(list[p].count);
                            }
                            list[p].count -= list[p].count;
                        }
                        count = 0;
                        change = 0;
                    }
                    else moneyoutput.Add(perem);
                }
                if (m > 0)
                   Console.WriteLine(State.State.state.NotEnoughMoney);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return moneyoutput;
        }

    }
}