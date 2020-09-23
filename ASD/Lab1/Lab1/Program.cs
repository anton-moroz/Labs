using System;
using System.Threading.Channels;
using System.Text.Encodings;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                menu();
            }
        }

        static void menu()
        {
            Console.Write("Оберіть дію:\n1 - Обчислити послідовність Фібоначчі до і\n2 - Перевірити чи фрагмент рядка з і-го по j-тий символ є паліндромом\n3 - Вихід\nВаш вибір: ");
            string choice = Console.ReadLine();
            Console.WriteLine("\n");
            switch (choice)
            {
                case "1":
                    fibonachchi();
                    break;
                case "2":
                    palindrom();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n\n\nНеправильний вибір! Спробуйте ще раз!\n\n\n");
                    return;

            }
            
        }

        static int get_i()
        {
            int i = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    Console.Write("Введіть значення числа і: ");
                    i = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\n\nНеправильне значення для числа і! Спробуйте ще раз!\n\n\n");
                    continue;
                }
            }
            return i;

        }static int get_j(int i)
        {
            int j = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    Console.Write("Введіть значення числа j: ");
                    j = Convert.ToInt32(Console.ReadLine());
                    if(j >= i)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("\n\n\nНеправильне значення для числа j! Спробуйте ще раз!\n\n\n");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\n\nНеправильне значення для числа j! Спробуйте ще раз!\n\n\n");
                    continue;
                }
            }
            return j;
        }

        static void fibonachchi()
        {
            int i = get_i();
            Console.WriteLine();
            fibonachchi_cycle(i);
            Console.Write("\nПослідовність Фібоначчі через рекурсію:\n0");
            fibonachchi_rec(i, 0, 1);
            Console.WriteLine("\n\n\n");
        }

        static void fibonachchi_rec(int i, int a1, int a2)
        {
            Console.Write(", " + a2.ToString());
            if(a1 + a2 < i)
            {
                fibonachchi_rec(i, a2, a1 + a2);
            }
            else
            {
                return;
            }
        }
        static void fibonachchi_cycle(int i)
        {
            Console.WriteLine("Послідовність Фібоначчі через цикл:");
            List<int> array = new List<int>();
            array.Add(0);
            array.Add(1);
            while (array[array.Count - 1] < i)
            {
                int temp = array[array.Count - 1] + array[array.Count - 2];
                if (temp < i)
                {
                    array.Add(temp);
                }
                else
                {
                    break;
                }
            }
            while (array.Count != 0)
            {
                Console.Write(array[0]);
                if(array.Count != 1)
                {
                    Console.Write(", ");
                }
                array.RemoveAt(0);
            }
            
        }

        static void palindrom()
        {
            Console.Write("Введіть рядок: ");
            string str = Console.ReadLine();
            if(str.Length == 1)
            {
                Console.WriteLine("Рядок є паліндромом.");
                Console.WriteLine("\n\n\n");
                return;
            }
            int i = get_i(), j = 0;
            while(i < 0 || i >= str.Length - 1)
            {
                Console.WriteLine("\n\n\nНеправильне значення для числа i! Спробуйте ще раз!\n\n\n");
                i = get_i();
            }
            j = get_j(i);
            if(i == j)
            {
                Console.WriteLine("Фрагмент рядка з і-го по j-тий символ є паліндромом.");
                Console.WriteLine("\n\n\n");
                return;
            }
            while(j < i || j > str.Length - 1)
            {
                Console.WriteLine("\n\n\n\nНеправильне значення для числа j! Спробуйте ще раз!\n\n\n");
                j = get_j(i);
                if (i == j)
                {
                    Console.WriteLine("Фрагмент рядка з і-го по j-тий символ є паліндромом.\n\n\n");
                    return;
                }
            }
            str = str.Remove(j, str.Length - j);
            str = str.Remove(0, i + 1);
            if (check_palindrom(str)){
                Console.WriteLine("Фрагмент рядка з і-го по j-тий символ є паліндромом.");
            }
            else
            {
                Console.WriteLine("Фрагмент рядка з і-го по j-тий символ не є паліндромом.");
            }
            Console.Write("\n\n\n");
        }
        
        static bool check_palindrom(string s)
        {
            int i = 0;
            if(s.Length % 2 == 0)
            {
                i = s.Length / 2;
            }
            else
            {
                i = s.Length / 2 + 1;
            }
            if(s.Length != 1)
            {
                for(int j = 0; j < i; j++)
                {
                    if(s[j] != s[s.Length - j - 1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
