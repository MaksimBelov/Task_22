using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_22
{
    internal class Program
    {
        static int n;

        static void GetSum(int[] array)
        {
            int S = 0;
            for (int i = 0; i < n; i++)
                S += array[i];
            Console.WriteLine($"Сумма чисел массива: {S}");
        }

        static void GetMax(Task task, object array)
        {
            int[] arr = (int[])array;
            int max = 0;
            for (int i = 0; i < n; i++)
                if (arr[i] > max)
                    max = arr[i];
            Console.WriteLine($"Максимальное число в массиве: {max}");
        }

        static void Main(string[] args)
        {
            Console.Write("Ведите размер массива - целочисленное положительное значение: ");
            try { n = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Random r = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = r.Next(100);

            Console.Write($"Сформирован массив из {n} случайных чисел:");
            for (int i = 0; i < n; i++)
                Console.Write($" {array[i]}");
            Console.WriteLine();

            Task task1 = new Task(() => GetSum(array));
            task1.Start();

            Action<Task, object> action = new Action<Task, object>(GetMax);
            Task taks2 = task1.ContinueWith(action, array);

            Console.ReadKey();
        }
    }
}
