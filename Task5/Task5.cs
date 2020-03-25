﻿using System;
using Utils;

namespace Task5
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int m;
            do
            {
                m = Util.GetNumberFromConsole();
            } while (m <= 0);
           
            int n;
            do
            {
                n = Util.GetNumberFromConsole();
            } while (n <= 0);

            RenderA(m, m);
            RenderB(m);
            RenderC(m);
            RenderD(m);
            RenderE(m);
            RenderF(m);
        }

        /// <summary>
        ///     ****
        ///     ****
        ///     ****
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void RenderA(int m, int n)
        {
            if (m <= 0 || n <= 0)
                throw new ArgumentException("Должны быть неотрицательные числа");

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                    Console.Write("*");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     *
        ///     **
        ///     ***
        ///     ****
        ///     *****
        /// </summary>
        /// <param name="m"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void RenderB(int m)
        {
            if (m <= 0) throw new ArgumentException(nameof(m));

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j <= i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void RenderC(int m)
        {
            if (m <= 0) throw new ArgumentException(nameof(m));

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j <= m - i; j++)
                    Console.Write(" ");
                for (var j = m - i; j <= m; j++)
                    Console.Write("*");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void RenderD(int m)
        {
            if (m <= 0) throw new ArgumentException(nameof(m));

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < m - i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     ******
        ///     *****
        ///     ****
        ///     ***
        ///     **
        ///     *
        /// </summary>
        /// <param name="m"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void RenderE(int m)
        {
            if (m <= 0) throw new ArgumentException(nameof(m));

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < m - i; j++)
                    Console.Write("*");
                for (var j = m - i; j <= m; j++)
                    Console.Write(" ");
                Console.WriteLine();
            }

            Console.WriteLine();
        }


        private static void RenderF(int m)
        {
            for (var i = 1; i < m * 2; i++)
            {
                if (i < m)
                {
                    var offset = m - i;
                    for (var j = 0; j < m; j++) Console.Write(j < offset || (i - j) * offset < offset ? " " : "*");
                }
                else
                {
                    var offset = i - m;
                    for (var j = 0; j < m; j++) Console.Write(j < offset || m - j - 1 < offset ? " " : "*");
                }

                Console.WriteLine();
            }
        }
    }
}