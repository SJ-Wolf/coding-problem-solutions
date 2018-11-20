// https://leetcode.com/problems/first-missing-positive/

using System;
using System.Linq;

namespace Problem_41___First_Missing_Positive
{
    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] -= 1;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                while (nums[i] >= 0 && nums[i] != i && nums[i] < nums.Length)
                {
                    // swap nums[i] and nums[nums[i]]
                    var tmp = nums[i];
                    if (tmp == nums[tmp])
                        break;
                    nums[i] = nums[tmp];
                    nums[tmp] = tmp;
                }
            }

            var missingIndex = 0;

            for (; missingIndex < nums.Length; missingIndex++)
            {
                if (nums[missingIndex] != missingIndex)
                    break;
            }

            return missingIndex + 1;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().FirstMissingPositive(new[] {1, 2, 0}));
            Console.WriteLine(new Solution().FirstMissingPositive(new [] {3,4,1,-1}));
            Console.WriteLine(new Solution().FirstMissingPositive(new [] {2,8,9,11,12}));
            Console.WriteLine(new Solution().FirstMissingPositive(new[] {4, 2, 2, 3, 1}));
            Console.WriteLine(new Solution().FirstMissingPositive(new[] {1, 2, 3}));
        }
    }
}