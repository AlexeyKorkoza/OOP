using System;
using Cassetes;

namespace Console
{
    class Program
    {
        static void Main()
        {
            try
            {
                Bankomat bankomat = new Bankomat();
                IReader reader = new CsvReader();
                var list = reader.Read();
                bankomat.InputCassettes(list);
                while (true)
                {
                    System.Console.WriteLine("Balance");
                    foreach (Cassetes.Cassetes item in list)
                    {
                        if (item.Count != 0)
                        {
                            System.Console.WriteLine(item.Nominal);
                        }
                    }
                    System.Console.WriteLine("Menu:\ninput - input sum;\nexit - exit from bankomat");
                    string input = System.Console.ReadLine();
                    if (input == "input")
                    {
                        System.Console.WriteLine("Input sum:");
                        string str = System.Console.ReadLine();
                        int sum;
                        if (int.TryParse(str, out sum))
                        {
                            var money = bankomat.Withdraw(sum);
                            if (money.Count != 0)
                            {
                                System.Console.WriteLine("Total shot:");
                                for (int i = 0; i < money.Count; i++)
                                {
                                    if (money[i] != 0)
                                        System.Console.WriteLine("{0}:{1}", money[i], list[i].Nominal);
                                }
                            }
                            else System.Console.WriteLine(State.MoneyIsNotIssued);
                        }
                        else System.Console.WriteLine(State.InputError);
                    }
                    if(input=="exit")
                        Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}