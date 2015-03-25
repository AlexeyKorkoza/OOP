using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Available for the issuance of banknotes");
                List<bankomat> list = Read.read();
                int all_money_of_bank = 0;
                int min = list[0].nominal;
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("{0}",list[i].nominal);
                    all_money_of_bank += list[i].nominal * list[i].count;
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
                    GiveMoney.calculation_and_write_in_file(list, money, min);
                }
                while (all_money_of_bank < money);
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
