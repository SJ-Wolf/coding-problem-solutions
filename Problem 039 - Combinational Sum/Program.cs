// https://leetcode.com/problems/combination-sum/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_39___Combinational_Sum
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


            for (int i = candidateStartIndex; i < candidates.Length; i++)
            {
                var num = candidates[i];
                if (currentSum + num > target)
                    break;
                currentCandidates.Add(num);
                CombinationSumHelper(candidates, target, i, currentCandidates, currentSum + num,
                    results);
                currentCandidates.RemoveAt(currentCandidates.Count - 1);
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
            var results = (new Solution()).CombinationSum(new int[] {2, 3, 5}, 8);
            foreach (var result in results)
            {
                foreach (var x in result)
                {
                    Console.Write($"{x} ");
                }
                Console.WriteLine();
            }
        }
    }
}