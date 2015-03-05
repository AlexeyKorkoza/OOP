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
        static List<bankomat> read_and_output()
        {
            List<bankomat> list = new List<bankomat>() { };
            StreamReader sr = new StreamReader("bankomat.txt");
            string line;
            string[] array;
            try
            {
                while ((line = sr.ReadLine()) != null)
                {
                    array = line.Split(new char[] { ' ', '\t' });
                    bankomat bankomat1 = new bankomat();
                    bankomat1.nominal_banknotes = int.Parse(array[0]);
                    bankomat1.count_of_nominal = int.Parse(array[1]);
                    list.Add(bankomat1);
                    line = string.Empty;
                }
                sr.Close();
            }
            catch
            {
                Console.WriteLine("Файл не найден");
            }
            return list;
        }

        static void calculation_write_in_file(List<bankomat> list, int money)
        {
            int count = 0;
            int money_output = 0;
            int m = 0;
            m = money;
            for (int p = 0; p < list.Count; p++)
            {
                if (list[p].count_of_nominal == 0)
                {

                }
                else
                {
                    count = m / list[p].nominal_banknotes;
                    m = m - count * list[p].nominal_banknotes;
                    if (count > 0)
                    {
                        Console.WriteLine("Будет снято:" + count + "    купюры номиналом:" + list[p].nominal_banknotes);
                        money_output = money_output + count * list[p].nominal_banknotes;
                        list[p].count_of_nominal = list[p].count_of_nominal - count;
                    }
                }
            }
            int rediuse_money = money - money_output;
            Console.WriteLine("Выведено всего:{0}", money_output);
            Console.WriteLine("Остаток от введенной суммы:{0}", Math.Abs(rediuse_money));
            Console.WriteLine("Теперь баланс банка:");
            StreamWriter sw = new StreamWriter("bankomat.txt");
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("{0}\t{1}", list[i].nominal_banknotes, list[i].count_of_nominal);
                    sw.WriteLine(list[i].nominal_banknotes + " " + list[i].count_of_nominal);
                }
                sw.Close();
            }
            catch
            {
                Console.WriteLine("Данные в файл не были записаны");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Текущий счет банка");
            List<bankomat> list = read_and_output();
            int all_money_of_bank = 0;
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}\t{1}", list[i].nominal_banknotes, list[i].count_of_nominal);
                all_money_of_bank = all_money_of_bank + list[i].nominal_banknotes * list[i].count_of_nominal;
            }
            Console.WriteLine("Введите суммму:");
            int money = int.Parse(Console.ReadLine());
            if (money < 20000)
            {
                Console.WriteLine("Минимальная сумма для ввода 20000руб");
                Environment.Exit(0);
            }
            if (all_money_of_bank < money)
            {
                Console.WriteLine("В банкомате недостаточно средств");
                Environment.Exit(0);
            }
            calculation_write_in_file(list, money);            
        }
    }
}