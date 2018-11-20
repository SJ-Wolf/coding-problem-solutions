using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Problem_060___Permutation_Sequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().GetPermutation(4, 9));
        }
    }

    public class Solution
    {
        public readonly int[] numPermutations = new[]
            {1, 2, 6, 24, 120, 720, 5040, 40320, 40320};

        public string GetPermutation(int n, int k)
        {
            k--;
            var remainingNumbers = new List<char>(n);
            for (var c = '1'; c <= '0' + n; c++)
                remainingNumbers.Add(c);

            var permutation = new char[n];

            var i = 0;
            while (k > 0)
            {
                var idx = k / numPermutations[n - i ];
                k = k % numPermutations[n - i];
                permutation[i++] = remainingNumbers[idx];
                remainingNumbers.RemoveAt(idx);
            }

            foreach (var num in remainingNumbers)
            {
                permutation[i++] = num;
            }

            return new string(permutation);
        }
    }
}