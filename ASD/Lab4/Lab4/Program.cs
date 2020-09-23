using System;
using System.Text;

namespace Lab4
{
    class Program
    {
        static string[] time = { "", "" };//bin posl
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Створений масив:");
            int[] mas = create_mas(2000);
            shellSort(mas);
            show_mas(mas);
            Console.Write("\n\nВведіть число яке хочете знайти: ");
            string str = Console.ReadLine();
            int numb = 0;
            while (true)
            {
                try
                {
                    numb = Convert.ToInt32(str);
                    break;
                }catch(Exception e)
                {
                    Console.WriteLine("Ви ввели неправильне число!");
                    str = Console.ReadLine();
                    continue;
                }
            }
            
            int res = posl_search(mas, numb);
            if(res != -1)
            {
                Console.WriteLine("\nНомер шуканого елемента -> " + res.ToString());
            }
            else
            {
                Console.WriteLine("\nШуканого елемента немає у масиві!");
            }
            res = bin_search_timer(mas, numb, 0, mas.Length - 1);
            if (res != -1)
            {
                Console.WriteLine("\nНомер шуканого елемента -> " + res.ToString());
            }
            else
            {
                Console.WriteLine("\nШуканого елемента немає у масиві!");
            }
            show_statistics();
            //*/
            string random = create_string();
            Console.WriteLine(random);
            Console.Write("\nВведіть рядок який треба знайти: ");
            string s = Console.ReadLine();
            res = linear_search(random, s);
            if (res != -1)
            {
                Console.WriteLine("\nШуканий рядок знаходиться на позиції -> " + res.ToString());
            }
            else
            {
                Console.WriteLine("\nШуканого рядка не знайдено!");
            }
            res = boyera_mura(random, s);
            if (res != -1)
            {
                Console.WriteLine("\nШуканий рядок знаходиться на позиції -> " + res.ToString());
            }
            else
            {
                Console.WriteLine("\nШуканого рядка не знайдено!");
            }//*/
             mas = create_lottery_mas();
            shellSort(mas);
            show_mas(mas);
            Random rand = new Random();
            int ch = rand.Next(1, 91);
            if (contains(mas, ch)){
                Console.WriteLine($"\nЧисло {ch} є у квитку!");
            }
            else
            {
                Console.WriteLine($"\nЧисла {ch} немає у квитку!");
            }
        }



        static bool contains(int[] mas, int ch)
        {
            bool contains = false;
            for (int i = 0; i < 15; i++)
            {
                if(mas[i] == ch)
                {
                    return true;
                }
            }
            return false;
        }



        static int[] create_lottery_mas()
        {
            int[] mas = new int[15];
            Random random = new Random();
            for(int i = 0; i < 15; i++)
            {
                mas[i] = random.Next(1, 91);
            }

            int k = 0;
            while (true)
            {
                for (int j = 0; j < 15; j++)
                {
                    if(k != j)
                    {
                        if(mas[k]  == mas[j])
                        {
                            mas[k] = random.Next(1, 91);
                            continue;
                        }
                    }
                }
                k++;
                if(k == 15)
                {
                    return mas;
                }
            }
        }



        static int[] create_table(string str)
        {
            string s = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            int[] table = new int[str.Length];
            for(int i = 0; i < str.Length; i++)
            {

                table[i] = str.Length - str.LastIndexOf(str[i]) - 1;
                if (table[i] == -1)
                {
                    table[i] = str.Length;
                }
            }
            if(table[str.Length - 1] == 0)
            {
                table[str.Length - 1] = str.Length;
            }
            return table;
        }

        static int boyera_mura(string str, string search)
        {
            int pos = search.Length - 1;
            int[] table = create_table(search);
            while (pos < str.Length)
            {
                if (str[pos] == search[search.Length - 1])
                {
                    for(int j = search.Length - 2; j >= 0; j--)
                    {
                        if(str[pos - j] == search[j])
                        {
                            continue;
                        }
                        else
                        {
                            pos += table[j];
                        }
                        return (pos - search.Length - 1);
                    }
                }
                else
                {
                    if (search.Contains(str[pos]))
                    {
                        pos += table[search.LastIndexOf(str[pos])];
                    }
                    else
                    {
                        pos += search.Length;
                    }
                    continue;
                }
            }
            return -1;
        }

        static string create_string()
        {
            string str = "", vari = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            Random random = new Random();
            for(int i = 0; i < 20; i++)
            {
                str += vari[random.Next(0, vari.Length)];
            }
            return str;
        }
        static int linear_search(string str, string search)
        {
            for(int i = 0; i < str.Length - search.Length; i++)
            {
                bool res = true;
                if(str[i] == search[0])
                {
                    for(int j = 0; j < search.Length; j++)
                    {
                        if(str[i + j] != search[j])
                        {
                            res = false;
                            break;
                        }
                    }
                    if (res) 
                    { 
                        return i;
                    }
                }
            }
            return -1;
        }

        static int bin_search(int[] mas, int numb, int start, int end)
        {
            if (numb < mas[start])
            {
                return -1;
            }
            else if (numb > mas[end])
            {
                return -1;
            }
            int med = (end - start) / 2 + start;
            if(numb == mas[med])
            {
                return med;
            }
            else if (numb == mas[start])
            {
                return start;
            }
            else if (numb == mas[end])
            {
                return end;
            }
            else if(numb > mas[med])
            {
                return bin_search(mas, numb, med, end);
            }
            else
            {
                return bin_search(mas, numb, start, med);
            }
        }
        static int bin_search_timer(int[] mas, int numb, int start, int end)
        {
            DateTime beg_time = DateTime.Now, end_time;
            if(numb < mas[start])
            {
                end_time = DateTime.Now;
                time[0] = get_time(beg_time, end_time);//*/
                return -1;
            }
            else if (numb > mas[end])
            {
                end_time = DateTime.Now;
                time[0] = get_time(beg_time, end_time);//*/
                return -1;
            }
            int med = (end - start) / 2 + start;
            if(numb == mas[med])
            {
                end_time = DateTime.Now;
                time[0] = get_time(beg_time, end_time);//*/
                return med;
            }
            else if (numb == mas[start])
            {
                end_time = DateTime.Now;
                time[0] = get_time(beg_time, end_time);//*/
                return start;
            }
            else if (numb == mas[end])
            {
                end_time = DateTime.Now;
                time[0] = get_time(beg_time, end_time);//*/
                return end;
            }
            else if(numb > mas[med])
            {
                
                int res = bin_search(mas, numb, med, end); 
                end_time = DateTime.Now;
                time[0] = get_time(beg_time, end_time);//*/
                return res;
            }
            else
            {
                int res = bin_search(mas, numb, start, med);
                end_time = DateTime.Now;
                time[0] = get_time(beg_time, end_time);//*/
                return res;
            }
        }

        static int posl_search(int[] mas, int numb)
        {
            DateTime beg_time = DateTime.Now, end_time;
            for (int i = 0; i < mas.Length; i++)
            {
                if(mas[i] == numb){
                    end_time= DateTime.Now;
                    time[1] = get_time(beg_time, end_time);
                    return i;
                }
            }
            end_time = DateTime.Now;
            time[1] = get_time(beg_time, end_time);
            return -1;
        }

        static void show_statistics()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Послідовний пошук тривав: " + time[1]);
            Console.WriteLine("Бінарний пошук тривав: " + time[0]);

        }

        static string get_time(DateTime time1, DateTime time2)
        {
            string dif = "";
            if (time2.Year > time1.Year)
            {
                dif += Convert.ToString(time2.Year - time1.Year);
                dif += " year";
                if (time2.Year - time1.Year > 1)
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
            if (dif.EndsWith(", "))
            {
                dif = dif.Remove(dif.Length - 2, 2);
            }
            return dif;
        }

        static void shellSort(int[] mas)
        {
            DateTime beg_time = DateTime.Now;
            int step = mas.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < mas.Length; i++)
                {
                    int temp = mas[i];
                    for (j = i - step; (j >= 0) && (mas[j] > temp); j -= step)
                    {
                        mas[j + step] = mas[j];
                    }
                    mas[j + step] = temp;
                }
                step /= 2;
            }
            DateTime end_time = DateTime.Now;
            time_sort = get_time(beg_time, end_time);
        }
        public static string time_sort, time_creation, time_output;
        static int[] copy_mas(int[] orig)
        {
            int[] copy = new int[orig.Length];
            for (int i = 0; i < orig.Length; i++)
            {
                copy[i] = orig[i];
            }
            return copy;
        }

        static int[] create_mas(int N)
        {
            DateTime beg_time = DateTime.Now;
            Random random = new Random();
            int[] mas = new int[N];
            for (int i = 0; i < N; i++)
            {
                mas[i] = random.Next(0, 1000000000);
            }
            DateTime end_time = DateTime.Now;
            time_creation = get_time(beg_time, end_time);
            return mas;
        }

        static void show_mas(int[] mas)
        {
            DateTime beg_time = DateTime.Now;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                Console.Write(Convert.ToString(mas[i]) + ", ");
            }
            Console.Write(Convert.ToString(mas[mas.Length - 1]));
            DateTime end_time = DateTime.Now;
            time_output = get_time(beg_time, end_time);
        }
    }
}
