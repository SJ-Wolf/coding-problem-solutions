// https://leetcode.com/problems/permutations-ii/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem_47___Permutations_II
{
    public class Solution
    {
        private void PermuteHelper(int[] nums, SortedDictionary<int, int> remainingNums, List<IList<int>> result,
            int[] currentNums, int currentNumsIdx)
        {
            if (remainingNums.Count == 0)
            {
                result.Add(currentNums.ToArray());
                return;
            }

            int? prevNum = null;
            foreach (var num in remainingNums.Keys.ToArray())
            {
                if (num == prevNum)
                {
                    continue;
                }

                var remaining = remainingNums[num];
                if (remaining == 1)
                    remainingNums.Remove(num);
                else
                    remainingNums[num] = remaining - 1;
                currentNums[currentNumsIdx] = num;
                PermuteHelper(nums, remainingNums, result, currentNums, currentNumsIdx + 1);

                if (remaining == 1)
                    remainingNums.Add(num, 1);
                else
                    remainingNums[num]++;

                prevNum = num;
            }
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length == 0)
                return result;
            var currentNums = new int[nums.Length];
            var remainingNums =
                new SortedDictionary<int, int>(nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()));
            Array.Sort(nums);
            PermuteHelper(nums, remainingNums, result, currentNums, 0);
            return result;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            foreach (var x in new Solution().PermuteUnique(new int[] {1, 1, 2, 4}))
            {
                Console.WriteLine($"{string.Join(", ", x.Select(z => z.ToString()))}");
            }
        }
    }
}