using System;
using System.Data.Common;
using System.Linq;

namespace Problem_10___Summation_of_Primes
{
    internal class Program
    {
        public static int BinarySearchLessThanOrEqual(int[] arr, int val)
        {
            var idx = Array.BinarySearch(arr, val);
            if (idx >= 0)
                return idx;
            if (idx == -1)
                return -1;
            return ~idx - 1;
        }

        public static bool[] Primes(int maxPrime)
        {
            var primes = new bool[maxPrime + 1];
            for (var i = 2; i < primes.Length; i++)
                primes[i] = true;
            for (int i = 2; i <= Math.Sqrt(maxPrime); i++)
            {
                if (primes[i])
                {
                    for (int j = i * i; j <= maxPrime; j += i)
                        primes[j] = false;
                }
            }

            return primes;
        }

        public static void Main(string[] args)
        {
            var isPrime = Primes(1000000);
            var primes = isPrime.Select(((b, i) => new {b, i})).Where(p => p.b).Select(p => p.i).ToArray();
            var primeCumulativeSum = new long[primes.Length];
            long sum = 0;
            foreach (var row in primes.Select((p, i) => new {p, i}))
            {
                sum += row.p;
                primeCumulativeSum[row.i] = sum;
            }

            int t = Convert.ToInt32(Console.ReadLine());
            for(int a0 = 0; a0 < t; a0++){
                int n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    Console.WriteLine(0);
                    continue;
                }
                var idx = BinarySearchLessThanOrEqual(primes, n);
                Console.WriteLine(primeCumulativeSum[idx]);
            }
        }
    }
}