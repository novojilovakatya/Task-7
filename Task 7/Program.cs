using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    class Program
    {
        /// <summary>
        /// Проверка ввода натуральных чисел
        /// </summary>
        /// <returns>Натуральное число</returns>
        public static int ReadPositive()
        {
            int k = 0; bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out k);
                if (!ok || k <= 0) Console.WriteLine("Неправильный ввод. Ожидалось натуральное число. Пожалуйста, повторите ввод");
            }
            while (!ok || k <= 0);
            return k;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину кодовых слов");
            int n = ReadPositive();
            // Находим количество кодовых слов
            int k = int.Parse(Math.Pow(2, n - 1).ToString()) + 1;
            // Создаем массив для хранения кодовых слов 
            string[] code = new string[k];
            // Первое кодовое слово состоит из нулей
            for (int i = 0; i < n; i++)
                code[0] += '0';
            // У второго - первая единица, остальные нули
            code[1] = "1";
            for (int i = 1; i < n; i++)
                code[1] += '0';

            // Генерируем остальные кодовые слова, добавляя 1 к каждому следующему
            int[] t = new int[n + 1];
            t[1] = 1;
            for (int i = 2; i < k; i++)
            {
                t[n] = t[n] + 1;
                for (int j = n; j > 0; j--)
                {
                    if (t[j] == 2)
                    {
                        t[j - 1] = t[j - 1] + 1;
                        t[j] = 0;
                    }
                    code[i] = t[j].ToString() + code[i];
                }
            }

            // Выводим результат
            Console.WriteLine("Результат:");
            for (int i = 0; i < k; i++)
                Console.WriteLine(code[i]);
            Console.ReadLine();
        }
    }
}
