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
        static List<bankomat> read()
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
                    bankomat1.count = int.Parse(array[0]);
                    bankomat1.nominal = int.Parse(array[1]);
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

        static void calculation_and_write_in_file(List<bankomat> list, int money, int min)
        {
            int count = 0;
            int m = 0;
            int change = 0;
            m = money;
            for (int p = 0; p < list.Count; p++)
            {
                if (list[p].count != 0)
                {
                    count = m / list[p].nominal;
                    if (count < list[p].count)
                    {
                        change = m - count * list[p].nominal;
                        if (change == 0)
                        {
                            m = m - count * list[p].nominal;
                            Console.WriteLine("{0} {1}", count, list[p].nominal);
                        }
                        else if (change < min)
                        {
                            count--;
                            m = m - count * list[p].nominal;
                            Console.WriteLine("{0} {1}", count, list[p].nominal);
                        }
                        else
                        {
                            m -= count * list[p].nominal;
                            Console.WriteLine("{0} {1}", count, list[p].nominal);
                        }
                        list[p].count -= count;
                    }
                    else
                    {
                        change = m - count * list[p].nominal;
                        if (change == 0)
                        {
                            m = m - list[p].count * list[p].nominal;
                            Console.WriteLine("{0} {1}", list[p].count, list[p].nominal);
                        }
                        else if (change < min)
                        {
                            list[p].count--;
                            m = m - list[p].count * list[p].nominal;
                            Console.WriteLine("{0} {1}", list[p].count, list[p].nominal);
                        }
                        else
                        {
                            m -= list[p].count * list[p].nominal;
                            Console.WriteLine("{0} {1}", list[p].count, list[p].nominal);
                        }
                        list[p].count -= list[p].count;
                    }
                    count = 0;
                    change = 0;
                }
            }
            if (m > 0)
            {
                Console.WriteLine("Банк не может в полном объеме выдать запрашеваемую сумму");
                Console.WriteLine("Остаток от введенной суммы:{0}", Math.Abs(m));
            }
            Console.WriteLine("Теперь баланс банка:");
            StreamWriter sw = new StreamWriter("bankomat.txt");
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("{0}\t{1}", list[i].count, list[i].nominal);
                    sw.WriteLine(list[i].count + " " + list[i].nominal);
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
            try
            {
                Console.WriteLine("Текущий счет банка");
                List<bankomat> list = read();
                int all_money_of_bank = 0;
                int min = list[0].nominal;
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("{0}\t{1}", list[i].count, list[i].nominal);
                    all_money_of_bank += list[i].nominal * list[i].count;
                    if (list[i].nominal < min)
                    {
                        min = list[i].nominal;
                    }
                }
                Console.WriteLine("Введите суммму:");
                int money = int.Parse(Console.ReadLine());
                if (all_money_of_bank < money)
                {
                    Console.WriteLine("В банкомате недостаточно средств");
                    Environment.Exit(0);
                }
                calculation_and_write_in_file(list, money, min);
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}
