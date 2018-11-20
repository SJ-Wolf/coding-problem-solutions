// https://leetcode.com/problems/permutations/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Problem_46___Permutations
{
    public class Solution
    {
        private void PermuteHelper(HashSet<int> remainingNums, List<IList<int>> result,
            int[] currentNums, int currentNumsIdx)
        {
            if (remainingNums.Count == 0)
            {
                result.Add(currentNums.ToArray());
                return;
            }

            foreach (var num in remainingNums.ToArray())
            {
                remainingNums.Remove(num);
                currentNums[currentNumsIdx] = num;
                PermuteHelper(remainingNums, result, currentNums, currentNumsIdx + 1);
                remainingNums.Add(num);
            }
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            var currentNums = new int[nums.Length];
            PermuteHelper(new HashSet<int>(nums), result, currentNums, 0);
            return result;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            foreach (var x in new Solution().Permute(new[] {1, 2, 3}))
            {
                Console.WriteLine($"{string.Join(", ", x.Select(z => z.ToString()))}");
            }
        }
    }
}