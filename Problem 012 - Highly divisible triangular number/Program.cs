using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace Problem_012___Highly_divisible_triangular_number
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

        public static int NumFactors(int num, int[] primes)
        {
            var factors = 1;
            foreach (var p in primes)
            {
                if (p * p > num)
                    break;
                var numOfThisFactor = 0;
                while (num % p == 0)
                {
                    numOfThisFactor++;
                    num /= p;
                }

                if (numOfThisFactor > 0)
                    factors *= numOfThisFactor + 1;
            }

            if (num != 1)
                factors *= 2;

            return factors;
        }

        public static void Main(string[] args)
        {
            var isPrimeList = Primes(30000);
            var primes = isPrimeList.Select(((b, i) => new {b, i})).Where(p => p.b).Select(p => p.i).ToArray();

            var triangleNumberFactors = new SortedDictionary<int, int>();
            var triangleNumber = 0;
            for (int i = 1;; i++)
            {
                triangleNumber += i;
                var numFactors = NumFactors(triangleNumber, primes);
                triangleNumberFactors.Add(triangleNumber, numFactors);

                if (numFactors >= 1000)
                    break;
            }
            
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                var tNumWithNFactors = triangleNumberFactors.First(f => f.Value > n).Key;
                Console.WriteLine(tNumWithNFactors);
            }
        }
    }
}