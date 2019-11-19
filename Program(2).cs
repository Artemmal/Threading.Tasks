using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace HW19._4
{
    class Program
    {
        public static int[] SortingArray(int[] array)
        {
            Array.Sort(array);
            return array;
        }
        public static int LineyniyPoisk(int[] array, int number, int index)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    index = i;
                }
            }
            return index;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число от 1 до 9: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int index = -1;
            int[] array = { 5, 4, 9, 7, 3, 6, 1, 2, 8};
            Task<int[]> task1 = new Task<int[]>(() => SortingArray(array));
            Task<int> task2 = task1.ContinueWith((m) => LineyniyPoisk(task1.Result, number, index));
            task1.Start();
            index = task2.Result;
            Console.WriteLine(index);
        }
    }
}
