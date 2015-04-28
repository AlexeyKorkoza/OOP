using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cassetes
{
    class ATM
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Available for the issuance of banknotes");
                List<Cassetes> list = Read.read();
                int allMoney = 0;
                int min = list[0].nominal;
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("{0}", list[i].nominal);
                    allMoney += list[i].nominal * list[i].count;
                    if (list[i].nominal < min)
                    {
                        min = list[i].nominal;
                    }
                }
                int money;
                do
                {
                    Console.WriteLine("Input money:");
                    money = int.Parse(Console.ReadLine());
                    SortedList<int,int> moneyoutput = GiveMoney.calculation(list, money, min);
                    ICollection<int> keys = moneyoutput.Keys;
                    ICollection<int> values = moneyoutput.Values;
                    foreach (int j in keys)
                        Console.WriteLine("{0}:{1}",j,(moneyoutput[j]));

                }
                while (allMoney > money && money<= 0);
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}