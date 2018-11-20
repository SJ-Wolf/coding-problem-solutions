using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace Problem_217___Balanced_Numbers
{
    internal class Program
    {
        public static IEnumerable<int> NDigitNumbers(int n, bool includeZeroes = false)
        {
            var min = includeZeroes ? 0 : Math.Pow(10, n - 1);
            for (var i = min; i < Math.Pow(10, n); i++)
            {
                yield return (int) i;
            }
        }

        public static int Sum(string s)
        {
            return s.Sum(l => int.Parse(l.ToString()));
        }

        public static void Main(string[] args)
        {
//            for (int i = 1; i <= 5; i++)
//            {
//                var num = NDigitNumbers(i, true).Where(x => x.ToString().Sum(l => int.Parse(l.ToString())) == 5).Count();
//                Console.WriteLine(num);
//            }
            for (int i = 0; i <= 100; i++)
            {
                var num = NDigitNumbers(3, true).Where(x => Sum(x.ToString()) == i).Count();
                Console.WriteLine(num);
            }

//            var num = NDigitNumbers(5, true).Where(x => x.ToString().Sum(l => int.Parse(l.ToString())) == 5).Count();
//            Console.WriteLine(num);
//            int total = 0;
//            for (var N = 1; N <= 4; N++)
//            {
//                var num = NDigitNumbers(N, false).Where(x =>
//                    Sum(x.ToString().Substring(0, N / 2)) == Sum(x.ToString().Substring((N + 1) / 2, N / 2)));
//                total += num.Sum();
//            }
//
//            Console.WriteLine(total);
        }
    }
}