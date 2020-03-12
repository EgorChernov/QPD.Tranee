using System;

namespace Task16
{
    public static class Solution
    {
        /// <summary>
        ///     Ввести два упорядоченных массива (контроль за корректностью ввода). Слить их в один упорядоченный массив без
        ///     использования сортировки.
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
            
            var a =GetRandomArray(length);
            var b = GetRandomArray(length);
            var c = Solve(a, b);
            foreach (var value in c) Console.Write(value + " ");
            Console.WriteLine();
        }

        private static int[] Solve(int[] a, int[] b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            var c = new int[a.Length + b.Length];

            var aIndex = 0;
            var bIndex = 0;
            var cIndex = 0;

            while (!(c.Length == cIndex && b.Length == bIndex && a.Length == aIndex))
            {
                if (a.Length == aIndex)
                {
                    c[cIndex++] = b[bIndex++];
                    continue;
                }

                if (b.Length == bIndex)
                {
                    c[cIndex++] = a[aIndex++];
                    continue;
                }

                c[cIndex++] = a[aIndex] < b[bIndex] ? a[aIndex++] : b[bIndex++];
            }

            return c;
        }
        
        private static int[] GetRandomArray(int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));
            var array = new int[length];
            var random = new Random();
            array[0] = random.Next(101) - 100;
            for (var i = 1; i < array.Length; i++)
                array[i] = array[i - 1] + random.Next(20);
            foreach (var value in array) Console.Write(value + " ");
            Console.WriteLine();
            return array;
        }
    }
}