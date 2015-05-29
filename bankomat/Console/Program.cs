using System;
using Cassetes;
using System.Configuration;
using System.Linq;

namespace Console
{
    class Program
    {
        static void Main()
        {
            try
            {
                var path = ConfigurationSettings.AppSettings["Cassetes"];
                var bankomat = new Bankomat();
                IReader reader = new TxtReader();
                var list = reader.Read(path);
                bankomat.InputCassettes(list);
                while (true)
                {
                    System.Console.WriteLine(@"Balance");
                    foreach (var item in list.Where(item => item.Count != 0))
                    {
                        System.Console.WriteLine(item.Nominal);
                    }
                    System.Console.WriteLine(@"Menu:\ninput - input sum;\nexit - exit from bankomat");
                    var input = System.Console.ReadLine();
                    if (input == "input")
                    {
                        System.Console.WriteLine(@"Input sum:");
                        var str = System.Console.ReadLine();
                        int sum;
                        if (int.TryParse(str, out sum))
                        {
                            var money = bankomat.Withdraw(sum,path);
                            if (money.Count != 0)
                            {
                                System.Console.WriteLine(@"Total shot:");
                                for (var i = 0; i < money.Count; i++)
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