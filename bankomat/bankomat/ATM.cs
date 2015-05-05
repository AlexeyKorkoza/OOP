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
                //Console.WriteLine("Available for the issuance of banknotes");
                while (true)
                {
                    IReader reader = new CSVReader();
                    List<Cassetes> list = reader.read();
                    Console.WriteLine("balance:");
                    int allMoney = 0;
                    int min = list[0].value;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].count != 0)
                        {
                            Console.WriteLine("{0}", list[i].value);
                        }
                        allMoney += list[i].value * list[i].count;
                        if (list[i].value < min)
                        {
                            min = list[i].value;
                        }
                    }
                    int money;
                    do
                    {
                        Console.WriteLine("Input money:");
                        money = int.Parse(Console.ReadLine());
                    }
                    while (allMoney > money && money < min);
                    List<int> count = GiveMoney.calculation(list, money, min);
                    Console.WriteLine("Total shot");
                    for(int i =0; i < count.Count;i++)
                    {
                        if (count[i] != 0)
                        {
                            Console.WriteLine("{0}:{1}", count[i], list[i].value);
                            list[i].value -= count[i];
                        }
                    }
                    IWriter writer = new CSVWriter();
                    writer.write(list);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}