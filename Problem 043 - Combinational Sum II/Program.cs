using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_43___Combinational_Sum_II
{
    public class Solution
    {
        public void CombinationSumHelper(int[] candidates, int target, int candidateStartIndex,
            List<int> currentCandidates, int currentSum, IList<IList<int>> results)
        {
            // base case
            if (currentSum == target)
            {
                results.Add(currentCandidates.Select(x => x).ToArray());
                return;
            }

            var prev_num = -1;
            for (int i = candidateStartIndex; i < candidates.Length; i++)
            {
                var num = candidates[i];
                if (currentSum + num > target)
                    break;
                if (num == prev_num)
                    continue;
                currentCandidates.Add(num);
                CombinationSumHelper(candidates, target, i + 1, currentCandidates, currentSum + num,
                    results);
                currentCandidates.RemoveAt(currentCandidates.Count - 1);

                prev_num = num;
            }
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var results = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSumHelper(candidates, target, 0, new List<int>(), 0, results);
            return results;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintSolution(new int[] {10, 1, 2, 7, 6, 1, 5}, 8);
            PrintSolution(new int[] {2, 5, 2, 1, 2}, 5);
            PrintSolution(new int[] { }, 1);
            PrintSolution(new int[] {1}, 6);
            PrintSolution(new int[] {1, 1, 1, 1}, 2);
        }

        public static void PrintSolution(int[] nums, int target)
        {
            var results = (new Solution()).CombinationSum(nums, target);
            foreach (var result in results)
            {
                foreach (var x in result)
                {
                    Console.Write($"{x} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}