using System;
using System.Collections.Generic;

namespace Cassetes
{
    public class GiveMoney
    {
        public static List<int> Calculation(List<Cassetes> list, int money, int min)
        {
            List<int> moneyoutput = new List<int>();
            try
            {
                int perem = 0;
                var m = money;
                foreach (Cassetes item in list)
                {
                    if (item.Count != 0)
                    {
                        if (m == 0)
                            break;
                        var count = m / item.Nominal;
                        int change;
                        if (count < item.Count)
                        {
                            change = m - count * item.Nominal;
                            if (change == 0)
                            {
                                m = m - count * item.Nominal;
                                moneyoutput.Add(count);
                            }
                            else if (change < min)
                            {
                                count--;
                                m = m - count * item.Nominal;
                                moneyoutput.Add(count);
                            }
                            else
                            {
                                m -= count * item.Nominal;
                                moneyoutput.Add(count);
                            }
                            item.Count -= count;
                        }
                        else
                        {
                            change = m - count * item.Nominal;
                            if (change == 0)
                            {
                                m = m - item.Count * item.Nominal;
                                moneyoutput.Add(item.Count);
                            }
                            else if (change < min)
                            {
                                item.Count--;
                                m = m - item.Count * item.Nominal;
                                moneyoutput.Add(item.Count);
                            }
                            else
                            {
                                m -= item.Count * item.Nominal;
                                moneyoutput.Add(item.Count);
                            }
                            item.Count -= item.Count;
                        }
                    }
                    else moneyoutput.Add(perem);
                }
                //if (m > 0)
                //   Console.WriteLine(State.state.NotEnoughMoney);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return moneyoutput;
        }

    }
}