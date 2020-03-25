using System;

namespace Utils
{
    public static class Util
    {
        public static int GetNumberFromConsole()
        {
            int number;
            do

            {
                Console.Write("Enter a number : ");
            } while (!int.TryParse(Console.ReadLine(), out number));

            return number;
        }

        public static int GetSumDigitInNumber(int number)
        {
            if (number < 0) number *= -1;

            var sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        public static int[] GetRandomArray(int length)
        {
            if (length <= 0)
                return null;

            var random = new Random();
            var array = new int[length];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }

            return array;
        }

        public static int[] GetSortRandomArray(int length, bool isAsc = true)
        {
            if (length < 1) return null;

            int sortIndex = isAsc ? 1 : -1;

            var array = new int[length];
            var random = new Random();
            array[0] = random.Next(101) - 100;
            for (var i = 1; i < array.Length; i++)
            {
                array[i] = array[i - 1] + (random.Next(20) * sortIndex);
            }

            return array;
            
        }

        public static void WriteLineArray(int[] array)
        {
            if (array == null || array.Length == 0)
                return;

            foreach (var value in array)
            {
                Console.Write($"{value} ");
            }
            
            Console.WriteLine();
        }
    }
}