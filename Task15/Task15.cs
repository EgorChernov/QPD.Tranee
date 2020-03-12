using System;

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
            var isParseSuccess = false;
            int length;
            Console.Write("Введите длину массива : ");
            do
            {
                var readConsole = Console.ReadLine();
                isParseSuccess = int.TryParse(readConsole, out length);
                if (isParseSuccess)
                    isParseSuccess = length > 0;
            
                if (!isParseSuccess)
                    Console.Write("Введите длину массива : ");
            } while (!isParseSuccess);

            var array = GetRandomArray(length);
            Solve(array);
        }

        private static void Solve(int[] array)
        {
            if (array.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(array));
            
            var maxIndex = 0;
            var minIndex = 0;
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
            foreach (var value in array) Console.Write(value + " ");
            Console.WriteLine();
        }
        
        private static int[] GetRandomArray(int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));
            var array = new int[length];
            var random = new Random();
            for (var i = 0; i < array.Length; i++) array[i] = random.Next(100);
            // array[0] = random.Next(10);
            // for (var i = 1; i < array.Length; i++)
            //     array[i] = array[i - 1] + random.Next(6);
            foreach (var value in array) Console.Write(value + " ");
            Console.WriteLine();
            return array;
        }
    }
}