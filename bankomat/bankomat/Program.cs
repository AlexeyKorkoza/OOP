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

        static void calculation_and_write_in_file(List<bankomat> list, int money)
        {
            int count = 0;
            int the_amount = 3;
            int money_output = 0;
            int rediuse_money = 0;
            for (int i = 0; i < list.Count - 3; i++)
            {
                if (money % 50000 != 0 && money>100000 && list[i].count_of_nominal >= the_amount)
                {
                    money = money - the_amount * list[i].nominal_banknotes;
                    Console.WriteLine("Будет снято:" + the_amount + "    купюры номиналом:" + list[i].nominal_banknotes);
                    list[i].count_of_nominal = list[i].count_of_nominal - the_amount;
                    money_output = money_output + the_amount * list[i].nominal_banknotes;
                }
            }
            Console.WriteLine("перед циклом{0}:", money);
            int m = 0;
            m = money;
            for (int p = 3; p >=0;p--)
            {
                if (list[p].count_of_nominal != 0)
                {
                    count = m / list[p].nominal_banknotes;
                    m = m - count * list[p].nominal_banknotes;
                    if (count > 0)
                    {
                        money_output = money_output + count * list[p].nominal_banknotes;
                        list[p].count_of_nominal = list[p].count_of_nominal - count;
                        rediuse_money = money - money_output;
                        Console.WriteLine("Будет снято:" + count + "    купюры номиналом:" + list[p].nominal_banknotes);
                    }
                }
            }
            Console.WriteLine("Снято от введенной суммы:{0}", money_output);
            if (rediuse_money > 0)
            {
                Console.WriteLine("Банк не может в полном объеме выдать запрашеваемую сумму");
                Console.WriteLine("Остаток от введенной суммы:{0}", Math.Abs(rediuse_money));
            }
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
            try
            {
                Console.WriteLine("Текущий счет банка");
                List<bankomat> list = read();
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
                calculation_and_write_in_file(list, money);
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}