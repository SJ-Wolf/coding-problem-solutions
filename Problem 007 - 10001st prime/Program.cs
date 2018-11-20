//https://www.hackerrank.com/contests/projecteuler/challenges/euler007

using System;
using System.Linq;

namespace Problem_7___10001st_prime
{
    internal class Program
    {
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
            var isPrimeList = Primes(105000);
            var primes = isPrimeList.Select(((b, i) => new {b, i})).Where(p => p.b).Select(p => p.i).ToArray();

            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(primes[n-1]);
            }
        }
    }
}