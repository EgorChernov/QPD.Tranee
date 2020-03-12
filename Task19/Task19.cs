using System;

namespace Task19
{
    public static class Program
    {
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
            
            
            isParseSuccess = false;
            int m;
            Console.Write("Введите длину сдвига : ");
            do
            {
                var readConsole = Console.ReadLine();
                isParseSuccess = int.TryParse(readConsole, out m);
                if (isParseSuccess)
                    isParseSuccess = m > 0 && m < length;

                if (!isParseSuccess)
                    Console.Write("Введите длину массива : ");
            } while (!isParseSuccess);


            var array = GetRandomArray(length);
            var rightShift = SolveRight(array, m);
            foreach (var value in rightShift) Console.Write(value + " ");
            Console.WriteLine();

            array = GetRandomArray(length);
            var leftShift = SolveLeft(array, m);
            foreach (var value in leftShift) Console.Write(value + " ");
            Console.WriteLine();
        }

        private static int[] SolveRight(int[] array, int m)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (m <= 0 || m > array.Length) throw new ArgumentOutOfRangeException(nameof(m));

            for (var i = 0; i < m; i++)
            {
                var temp = array[^1];
                for (var j = array.Length - 1; j > 0; j--)
                    array[j] = array[j - 1];
                array[0] = temp;
            }

            return array;
        }

        private static int[] SolveLeft(int[] array, int m)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (m <= 0 || m > array.Length) throw new ArgumentOutOfRangeException(nameof(m));

            for (var i = 0; i < m; i++)
            {
                var temp = array[0];
                for (var j = 0; j < array.Length - 1; j++)
                    array[j] = array[j + 1];
                array[^1] = temp;
            }

            return array;
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