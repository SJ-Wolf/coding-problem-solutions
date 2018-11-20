using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Problem_6___Sum_square_difference
{
    internal class Program
    {
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                BigInteger n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(n * (n - 1) * (n + 1) * (3 * n + 2) / 12);
            }
        }
    }
}