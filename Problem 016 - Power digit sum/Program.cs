using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml;

namespace Problem_16___Power_digit_sum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                var n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(BigInteger.Pow(2, n).ToString().Select(x => x - '0').Sum());
            }
        }
    }
}