// https://www.hackerrank.com/contests/projecteuler/challenges/euler003
// https://projecteuler.net/problem=3

using System;
using System.Linq;

namespace Problem_3___Largets_Prime_Factor
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

        public static long largestPrimeFactor(long n)
        {
            var primes = Primes((int) Math.Sqrt(n));

            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] && n % i == 0)
                {
                    if (i == n)
                        return n;
                    n /= i;
                    i--; // may be multiple!
                }
            }

            return n;
        }

        public static long largestPrimeFactorBruteForce(long n)
        {
            for (long i = n; i >= 2; i--)
            {
                // check i is prime
                var isPrime = true;
                for (long j = 2; j < i; j++)
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }

                if (!isPrime)
                    continue;
                if (n % i == 0)
                    return i;
            }

            return -1;
        }

        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                long n = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine(largestPrimeFactor(n));
            }
//            for (int n = 10; n <= 50; n++)
//            {
//                Console.WriteLine($"For {n}, the largest prime is {largestPrimeFactor(n)} and should be {largestPrimeFactorBruteForce(n)}");
//            }
        }
    }
}