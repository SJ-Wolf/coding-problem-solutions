using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_13___Large_sum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var inputNumbers = new List<string>();
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string n = Console.ReadLine();
                inputNumbers.Add(n);
            }

            var top10DigitsOfInputNumbers = inputNumbers.Select(s => long.Parse(s.Substring(0, 11)));
            var sum = top10DigitsOfInputNumbers.Sum();
            var output = sum.ToString().Substring(0, 10);

            Console.WriteLine(output);
        }
    }
}