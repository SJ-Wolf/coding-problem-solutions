using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_14___Longeset_Collatz_sequence
{
    internal class Program
    {
        private static readonly List<long> TmpChain = new List<long>();

        public static int AddChainToCollatz(long n, int[] collatz)
        {
            if (n < collatz.Length && collatz[n] != 0)
                return collatz[n];

//            var tmpChain = new List<long>();
            TmpChain.Clear();

            while (n >= collatz.Length || (n > 1 && collatz[n] == 0))
            {
                TmpChain.Add(n);
                if (n % 2 == 0)
                    n = n / 2;
                else
                    n = 3 * n + 1;
            }

            var existingChainLength = collatz[n];

            for (int i = 0; i < TmpChain.Count; i++)
            {
                var num = TmpChain[i];
                if (num >= collatz.Length)
                    continue;
                var chainLength = TmpChain.Count - i + existingChainLength;
                collatz[num] = chainLength;
            }

            return TmpChain.Count + existingChainLength;
        }

        public static IEnumerable<long> LongestCollatzSequence(List<long> maxStartingNumbers)
        {
            var maxInputNumber = maxStartingNumbers.Max();
            var collatz = new int[maxInputNumber + 1 + 10000];
//            var collatz = new int[4000000L];
            collatz[1] = 0;

            for (long i = 2; i <= maxInputNumber; i++)
                AddChainToCollatz(i, collatz);

            var outputDictionary = maxStartingNumbers.Distinct().ToDictionary(l => l);
            var sortedInputNumbers = maxStartingNumbers.OrderBy(x => x).ToArray();
            var inputNumberIndex = 0;
            var curInputNumber = sortedInputNumbers[0];
            var maxStartingValue = 0L;
            var maxChainLength = 0;
            var doneIterating = false;

            for (int num = 1; num <= maxInputNumber; num++)
            {
                var chainLength = AddChainToCollatz(num, collatz);


                if (chainLength >= maxChainLength)
                {
                    maxStartingValue = num;
                    maxChainLength = chainLength;
                }

                while (num == curInputNumber)
                {
                    outputDictionary[curInputNumber] = maxStartingValue;
                    inputNumberIndex++;
                    if (inputNumberIndex == maxStartingNumbers.Count)
                    {
                        doneIterating = true;
                        break;
                    }

                    curInputNumber = sortedInputNumbers[inputNumberIndex];
                }

                if (doneIterating)
                    break;
            }

            foreach (var inputNum in maxStartingNumbers)
            {
                yield return outputDictionary[inputNum];
            }
        }

        public static void Main(string[] args)
        {
            var inputNumbers = new List<long>();
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                var n = Convert.ToInt64(Console.ReadLine());
                inputNumbers.Add(n);
            }

            foreach (var x in LongestCollatzSequence(inputNumbers))
            {
                Console.WriteLine(x);
            }
        }

        public static IEnumerable<long> LongestCollatzSequenceBruteForce(List<long> maxStartingNumbers)
        {
            var collatz = new int[maxStartingNumbers.Max() + 1];
            for (int i = 1; i < collatz.Length; i++)
            {
                var steps = 0;
                var n = i;
                while (n != 1)
                {
                    if (n % 2 == 0)
                        n = n / 2;
                    else
                        n = 3 * n + 1;
                    steps++;
                }

                collatz[i] = steps;
            }

            var q = collatz.Select((steps, n) => new {steps, n}).OrderByDescending(p => p.steps)
                .ThenByDescending(p => p.n).ToArray();

            foreach (var n in maxStartingNumbers)
            {
                yield return q.First(p => p.n <= n).n;
            }
        }

        public static void TestMain()
        {
            var inputNumbers = new List<long>(new[] {2L, 3, 4, 5, 6, 7, 8, 9, 10});
            for (int i = 11; i < 3000; i++)
            {
                inputNumbers.Add(i);
            }

            var idx = 0;
            foreach (var x in Enumerable.Zip(LongestCollatzSequence(inputNumbers),
                LongestCollatzSequenceBruteForce(inputNumbers), (l1, l2) => new {l1, l2}))
            {
                var inputNumber = inputNumbers[idx];
                if (x.l1 != x.l2)
                    Console.WriteLine(inputNumber);
                idx++;
            }

//            foreach (var x in LongestCollatzSequence(inputNumbers))
//                Console.WriteLine(x);
//            foreach (var x in LongestCollatzSequenceBruteForce(inputNumbers))
//                Console.WriteLine(x);
        }
    }
}