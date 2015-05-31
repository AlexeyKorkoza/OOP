using System;
using Cassetes;
using System.Configuration;
using System.Linq;
using log4net;
using log4net.Config;

namespace Console
{
    class Program
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(Program)); 
        static void Main()
        {
            
            XmlConfigurator.Configure();
            //a piece of magic
            Log.Info("Start Program");
            try
            {
                var path = ConfigurationManager.AppSettings["Cassetes"];//навёл мышью он предложил юзать другую штуку, юзаем её
                var bankomat = new Bankomat();//больше не предлогает я то видел,но нажимал алт+ентер на апп(( это руками писать надо
                //вроде все?
                //я откуда знаю что тебе ещё надо смотри
                //пока все, буду смотреть сериал xmlson.
                IReader reader = new TxtReader();
                var list = reader.Read(path);
                bankomat.InputCassettes(list);
                Log.Info("Input Cassetes");
                while (true)
                {
                    System.Console.WriteLine(@"Balance");
                    foreach (var item in list.Where(item => item.Count != 0))
                    {
                        System.Console.WriteLine(item.Nominal);
                    }
                    System.Console.WriteLine("Menu:\ninput - input sum;\nexit - exit from bankomat");
                    var input = System.Console.ReadLine();
                    if (input == "input")
                    {
                        Log.Info(input);
                        System.Console.WriteLine(@"Input sum:");
                        var str = System.Console.ReadLine();
                        int sum;
                        if (int.TryParse(str, out sum))
                        {
                            var money = bankomat.Withdraw(sum, path);
                            Log.Info("Withdraw:"+sum);
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
                    if (input == "exit")
                    {
                        Log.Info("Exit");
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                Log.Fatal(ex);
            }
        }
    }
}