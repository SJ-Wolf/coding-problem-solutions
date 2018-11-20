using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Problem_5___Smallest_Multiple
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

        public static List<Dictionary<int, int>> GetPrimeFactors(int n)
        {
            var isPrimeList = Primes(n);
            var primes = isPrimeList.Select(((b, i) => new {b, i})).Where(p => p.b).Select(p => p.i).ToArray();
            var factorList = new List<Dictionary<int, int>> {null, null}; // 0 and 1 have no meaningful factors

            for (int i = 2; i <= n; i++)
            {
                var factors = new Dictionary<int, int>();

                if (isPrimeList[i])
                {
                    factors.Add(i, 1);
                }
                else
                {
                    foreach (var prime in primes)
                    {
                        if (i % prime == 0)
                        {
                            factors = new Dictionary<int, int>(factorList[i / prime]);
                            if (factors.ContainsKey(prime))
                                factors[prime]++;
                            else
                                factors.Add(prime, 1);
                            break;
                        }
                    }
                }

                factorList.Add(factors);
            }

            return factorList;
        }

        public static List<int> GetSmallestNumbersDivisibleByUpToN(int n)
        {
            var factorList = GetPrimeFactors(n);
            var results = new List<int>(new[] {0, 1});
            var maxFactors = new Dictionary<int, int>();
            var curMaxNum = 1;
            foreach (var row in factorList.Select(((factors, num) => new {factors, num})))
            {
                var factors = row.factors;
                var num = row.num;
                if (factors == null)
                    continue;
                foreach (var factor in factors)
                {
                    var newFactorValue = factor.Value;
                    int existingFactorValue = 0;
                    maxFactors.TryGetValue(factor.Key, out existingFactorValue);
                    if (existingFactorValue == 0)
                        maxFactors.Add(factor.Key, 1);
                    if (newFactorValue > existingFactorValue)
                    {
                        curMaxNum *= factor.Key;
                        maxFactors[factor.Key] = newFactorValue;
                    }
                }

                results.Add(curMaxNum);
            }

            return results;
        }

        public static void Main(string[] args)
        {
            var inputs = new List<int>();
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                inputs.Add(n);
            }

            var smallestNumbers = GetSmallestNumbersDivisibleByUpToN(inputs.Max());
            foreach (var n in inputs)
            {
                Console.WriteLine(smallestNumbers[n]);
            }
        }
    }
}