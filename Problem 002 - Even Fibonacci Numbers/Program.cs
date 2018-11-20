// https://www.hackerrank.com/contests/projecteuler/challenges/euler002
// https://projecteuler.net/problem=2

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem_2___Even_Fibonacci_Numbers
{
    internal class Program
    {
        public static IEnumerable<BigInteger> Fibonacci(BigInteger n)
        {
            BigInteger prev_prev_num = 1;
            yield return prev_prev_num;
            BigInteger prev_num = 1;
            yield return prev_num;
            BigInteger cur_num;

            while (true)
            {
                cur_num = prev_prev_num + prev_num;

                if (cur_num > n)
                    break;
                yield return cur_num;
                prev_prev_num = prev_num;
                prev_num = cur_num;
            }
        }

        public static IEnumerable<BigInteger> EvenFibonacci(BigInteger n)
        {
            return Fibonacci(n).Where(x => x % 2 == 0);
        }

        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                long n = Convert.ToInt64(Console.ReadLine());
                BigInteger sum = 0;
                foreach (var x in EvenFibonacci(n))
                    sum += x;
                Console.WriteLine(sum);
            }
        }
    }
}