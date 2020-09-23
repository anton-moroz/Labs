using System;
using System.Security.Cryptography;
using System.Text;

namespace Lab2
{
    class Program
    {
        // {бульбашковий, вставками, вибором}
        static int[,] compares = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static int[,] passes = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static int[,] exchanges = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static string[,] times = new string[5, 3];
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int[] N = { 10, 100, 1000, 10000, 30000 };
            for (int i = 0; i < 5; i++)
            {
                int[] mas = create_mas(N[i]);
                
                
                Console.WriteLine("Створений масив:");
                show_mas(mas);

                Console.WriteLine("\n\nСортування бульбашкою:");
                show_mas(sort_bubble(copy_mas(mas)));
                Console.WriteLine("\n\nСортування бульбашкою на таймер:");
                show_mas(sort_bubble_timer(copy_mas(mas)));
                Console.WriteLine("\n\nСортування вибором:");
                show_mas(sort_choice(copy_mas(mas)));
                Console.WriteLine("\n\nСортування вибором на таймер:");
                show_mas(sort_choice_timer(copy_mas(mas)));
                Console.WriteLine("\n\nСортування вставкою:");
                show_mas(sort_insert(copy_mas(mas)));
                Console.WriteLine("\n\nСортування вставкою на таймер:");
                show_mas(sort_insert_timer(copy_mas(mas)));

                /*if(i + 1 >= 4)
                {
                    break;
                }//*/
                Console.WriteLine("\n\n\n");
            }
            show_statistics();
        }
        
        static int[] copy_mas(int[] orig)
        {
            int[] copy = new int[orig.Length];
            for(int i = 0; i < orig.Length; i++)
            {
                copy[i] = orig[i];
            }
            return copy;
        }

        static int[] create_mas(int N)
        {
            Random random = new Random();
            int[] mas = new int[N];
            for(int i = 0; i < N; i++)
            {
                mas[i] = random.Next(0, 1000000);
            }
            return mas;
        }

        static void show_mas(int[] mas)
        {
            for(int i = 0; i < mas.Length - 1; i++)
            {
                Console.Write(Convert.ToString(mas[i]) + ", ");
            }
            Console.Write(Convert.ToString(mas[mas.Length - 1]));
        }

        static int[] sort_choice(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                int i_min = find_min(mas, i);
                if (mas[i] > mas[i_min])
                {
                    int temp = mas[i];
                    mas[i] = mas[i_min];
                    mas[i_min] = temp;
                    exchanges[define_mas_number(mas), 2]++;
                }
                compares[define_mas_number(mas), 2]++;
            }
            passes[define_mas_number(mas), 2]++;
            return mas;
        }
        static int[] sort_choice_timer(int[] mas)
        {
            DateTime beg_time = DateTime.Now;
            for(int i = 0; i < mas.Length; i++)
            {
                int temp = mas[i];
                int i_min = find_min(mas, i);
                mas[i] = mas[i_min];
                mas[i_min] = temp;
            }
            DateTime end_time = DateTime.Now;
            times[define_mas_number(mas), 2] = get_time(beg_time, end_time);
            return mas;
        }


        static string get_time(DateTime time1, DateTime time2)
        {
            string dif = "";
            if(time2.Year > time1.Year)
            {
                dif += Convert.ToString(time2.Year - time1.Year);
                dif += " year";
                if(time2.Year - time1.Year > 1)
                {
                    dif += "s";
                }
                dif += ", ";
            }
            if (time2.Month > time1.Month)
            {
                dif += Convert.ToString(time2.Month - time1.Month);
                dif += " month";
                if (time2.Month - time1.Month > 1)
                {
                    dif += "s";
                }
                dif += ", ";
            }
            if (time2.Day > time1.Day)
            {
                dif += Convert.ToString(time2.Day - time1.Day);
                dif += " day";
                if (time2.Day - time1.Day > 1)
                {
                    dif += "s";
                }
                dif += ", ";
            }
            if (time2.Hour > time1.Hour)
            {
                dif += Convert.ToString(time2.Hour - time1.Hour);
                dif += " hour";
                if (time2.Hour - time1.Hour > 1)
                {
                    dif += "s";
                }
                dif += ", ";
            }
            if (time2.Minute > time1.Minute)
            {
                dif += Convert.ToString(time2.Minute - time1.Minute);
                dif += " min";
                if (time2.Minute - time1.Minute > 1)
                {
                    dif += "s";
                }
                dif += ", ";
            }
            if (time2.Second > time1.Second)
            {
                dif += Convert.ToString(time2.Second - time1.Second);
                dif += " sec, ";
            }
            if (time2.Millisecond >= time1.Millisecond)
            {
                dif += Convert.ToString(time2.Millisecond - time1.Millisecond);
                dif += " msec";
            }
            if(dif.EndsWith(", "))
            {
                dif = dif.Remove(dif.Length - 2, 2);
            }
            return dif;
        }

        static int find_min(int[] mas, int n)
        {
            int min = 1000000, i_min = 0;
            for (int i = n; i < mas.Length; i++)
            {
                if (min > mas[i])
                {
                    i_min = i;
                    min = mas[i];
                    exchanges[define_mas_number(mas), 2]++;
                }
                compares[define_mas_number(mas), 2]++;
            }
            passes[define_mas_number(mas), 2]++;
            return i_min;
        }
        static int find_min_timer(int[] mas, int n)
        {
            int min = 1000000, i_min = 0;
            for (int i = n; i < mas.Length; i++)
            {
                if (min > mas[i])
                {
                    i_min = i;
                    min = mas[i];
                }
            }
            return i_min;
        }

        static int[] sort_bubble(int[] mas)
        {
            for(int i = 0; i < mas.Length; i++)
            {
                for(int j = mas.Length - 1; j >= i; j--)
                {
                    if (mas[i] > mas[j])
                    {
                        int temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                        exchanges[define_mas_number(mas), 0]++;
                    }
                }
                compares[define_mas_number(mas), 0]++;
                passes[define_mas_number(mas), 0]++;
            }
            return mas;
        }

        static int[] sort_bubble_timer(int[] mas)
        {
            DateTime beg_time = DateTime.Now;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = mas.Length - 1; j >= i; j--)
                {
                    if(mas[i] > mas[j])
                    {
                        int temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            DateTime end_time = DateTime.Now;
            times[define_mas_number(mas), 0] = get_time(beg_time, end_time);
            return mas;
        }


         static int[] sort_insert(int[] mas)
         {
            int newElement, location;
            for (int i = 1; i < mas.Length; i++)
            {
                newElement = mas[i];
                location = i - 1;
                while (location >= 0 && mas[location] > newElement)
                {
                    mas[location + 1] = mas[location];
                    location = location - 1;
                    compares[define_mas_number(mas), 1]++;
                    exchanges[define_mas_number(mas), 1]++;
                }
                compares[define_mas_number(mas), 1]++;
                mas[location + 1] = newElement;
            }
            passes[define_mas_number(mas), 1]++;
            return mas;
        }
        static int[] sort_insert_timer(int[] mas)
        {
            DateTime beg_time = DateTime.Now;
            int newElement, location;
            for (int i = 1; i < mas.Length; i++)
            {
                newElement = mas[i];
                location = i - 1;
                while (location >= 0 && mas[location] > newElement)
                {
                    mas[location + 1] = mas[location];
                    location = location - 1;
                }
                mas[location + 1] = newElement;
            }
            DateTime end_time = DateTime.Now;
            times[define_mas_number(mas), 1] = get_time(beg_time, end_time);
            return mas;
        }

        static int define_mas_number(int[] mas)
        {
            switch (mas.Length)
            {
                case 10:
                    return 0;
                case 100:
                    return 1;
                case 1000:
                    return 2;
                case 10000:
                    return 3;
                case 30000:
                    return 4;
            }
            return -1;
        }
        static void show_statistics()
        {
            Console.WriteLine("\n\n\nСтатистика:");
            int[] N = { 10, 100, 1000, 10000, 30000 };
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine((i + 1).ToString() + " при N = " + N[i].ToString());
                Console.WriteLine("   Бульбашковий метод:");
                Console.WriteLine("      Проходи -> " + passes[i, 0].ToString());
                Console.WriteLine("      Порівняння -> " + compares[i, 0].ToString());
                Console.WriteLine("      Заміни -> " + exchanges[i, 0].ToString());
                Console.WriteLine("      Час сортування -> " + times[i, 0]);
                Console.WriteLine("   Метод вибору:");
                Console.WriteLine("      Проходи -> " + passes[i, 2].ToString());
                Console.WriteLine("      Порівняння -> " + compares[i, 2].ToString());
                Console.WriteLine("      Заміни -> " + exchanges[i, 2].ToString());
                Console.WriteLine("      Час сортування -> " + times[i, 2]);
                Console.WriteLine("   Метод вставками:");
                Console.WriteLine("      Проходи -> " + passes[i, 1].ToString());
                Console.WriteLine("      Порівняння -> " + compares[i, 1].ToString());
                Console.WriteLine("      Заміни -> " + exchanges[i, 1].ToString());
                Console.WriteLine("      Час сортування -> " + times[i, 1]);
                Console.WriteLine("\n");
            }
        }
    }
}
