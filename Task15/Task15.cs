using System;
using Utils;

namespace Task15
{
    public static class Solution
    {
        /// <summary>
        ///     3. Ввести массив целых чисел в диапазоне [-100,100]. Длина массива задается пользователем.
        ///     а) Найти минимальный элемент
        ///     б) Найти максимальный элемент
        ///     в) найти минимальное нечетное
        ///     г) найти минимальное четное
        ///     д) найти минимальный и максимальный элементы и поменять их местами
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int length;
            do
            {
                length = Util.GetNumberFromConsole();
            } while (length < 0);

            var array = Util.GetRandomArray(length);
            Util.WriteLineArray(array);
            
            Solve(array);
        }

        private static void Solve(int[] array)
        {
            var maxIndex = 0;
            var minIndex = 0;
            
            //FIXME: Заменить на linq
            var minEvenIndex = array[0] % 2 == 0 ? 0 : int.MinValue;
            var minOddIndex = array[0] % 2 == 0 ? int.MinValue : 0;

            for (var i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex]) maxIndex = i;
                if (array[i] < array[minIndex]) minIndex = i;

                if (array[i] % 2 == 0 && (minEvenIndex == int.MinValue || array[i] < array[minEvenIndex]))
                    minEvenIndex = i;
                if (array[i] % 2 != 0 && (minOddIndex == int.MinValue || array[i] < array[minOddIndex]))
                    minOddIndex = i;
            }

            Console.WriteLine("минимальный элемент = {0}", array[minIndex]);
            Console.WriteLine("максимальный элемент = {0}", array[maxIndex]);

            if (minEvenIndex == int.MinValue)
                Console.WriteLine("В массиве нет четных элементов");
            else
                Console.WriteLine("минимальное четное = {0}", array[minEvenIndex]);
            if (minEvenIndex == int.MinValue)
                Console.WriteLine("В массиве нет нечетных элементов");
            else
                Console.WriteLine("минимальное нечетное = {0}", array[minOddIndex]);

            var temp = array[maxIndex];
            array[maxIndex] = array[minIndex];
            array[minIndex] = temp;

            Util.WriteLineArray(array);
        }
    }
}