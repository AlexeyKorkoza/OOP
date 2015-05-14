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
                    string str = System.Console.ReadLine();
                    int sum ;
                    if (int.TryParse(str, out sum))
                    {
                        var money = bankomat.Money(sum);
                        System.Console.WriteLine("Total shot");

                        for (int i = 0; i < money.Count; i++)
                        {
                            if (money[i] != 0)
                                System.Console.WriteLine("{0}:{1}", money[i], list[i].Nominal);
                        }
                    }
                    /*var allMoney = 0;
                    var removed = 0;
                    System.Console.WriteLine("Balance:");
                    int min = list[0].value;
                    foreach (Cassetes.Cassetes item in list)
                    {
                        if (item.count != 0)
                            System.Console.WriteLine("{0}", item.value);

                        allMoney += item.value * item.count;

                        if (item.value < min)
                            min = item.value;
                    }
                    System.Console.WriteLine("Max sum:{0}", allMoney - removed);
                    int money = 0;

                    do
                    {
                        System.Console.WriteLine("Input money:");
                        var str = System.Console.ReadLine();
                        if (str != null) money = int.Parse(str);
                    }
                    while (allMoney < money || money < min || money < 0);

                    List<int> count = GiveMoney.calculation(list, money, min);
                    System.Console.WriteLine("Total shot");

                    for (int i = 0; i < count.Count; i++)
                    {
                        if (count[i] != 0)
                            System.Console.WriteLine("{0}:{1}", count[i], list[i].value);
                    }

                    IWriter writer = new CSVWriter();
                    writer.write(list);
                    System.Console.WriteLine("======================================");
                     */
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}