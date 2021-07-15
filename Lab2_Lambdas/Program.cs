using System;
using System.Collections.Generic;

namespace Lab2_Lambdas
{
    class Program
    {
        public static List<int> Results = new();

        public delegate int MathOp(int x, int y);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Func<int, int, int> add = (x, y) => x + y; 
            Func<int, int, int> subtract = (x, y) => x - y; 
            Func<int, int, int> multiply = (x, y) => x * y;

            Process(5, 5, add);
            Process(5, 5, subtract);
            Process(5, 5, multiply);
            Process(2, 5, multiply);

            //Alternative with user defined delegate
            Console.WriteLine();

            MathOp add2 = (x, y) => x + y;
            MathOp subtract2 = (x, y) => x - y;
            MathOp multiply2 = (x, y) => x * y;

            Process2(5, 5, add2);
            Process2(5, 5, subtract2);
            Process2(5, 5, multiply2);
            Process2(2, 5, multiply2);
        }

        public static int Process(int x, int y, Func<int, int, int> op)
        {
            int result = op(x, y);
            Results.Add(result);
            Console.WriteLine(result);
            return result;
        }

        //Alternative with user defined delegate
        public static int Process2(int x, int y, MathOp op)
        {
            int result = op(x, y);
            Results.Add(result);
            Console.WriteLine(result);
            return result;
        }
    }
}
