// https://www.hackerrank.com/contests/projecteuler/challenges/euler001
// https://projecteuler.net/problem=1


using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem_1___Multiples_of_3_and_5
{
    internal class Program
    {
        public static void TestMultiples()
        {
            for (int n = 0; n < 500; n++)
            {
                var sumOfMultiples = Multiples(3, n - 1) + Multiples(5, n - 1) - Multiples(15, n - 1);
                if (BruteForceMultiples(n) != sumOfMultiples)
                {
                    throw new Exception("Not equal!");
                }
            }
        }
        
        public static BigInteger BruteForceMultiples(BigInteger n)
        {
            BigInteger multiples = 0;
            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    multiples += i;
                }
            }

            return multiples;
        }

        public static BigInteger Multiples(BigInteger num, BigInteger maxNum)
        {
            return num * (maxNum / num) * (maxNum / num + 1) / 2;
        }

        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                var sumOfMultiples = Multiples(3, n - 1) + Multiples(5, n - 1) - Multiples(15, n - 1);
                Console.WriteLine(sumOfMultiples);
            }
        }
    }
}