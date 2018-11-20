using System;

namespace Problem_055___Jump_Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var j1 = new int[] {2, 3, 1, 1, 4};
            var j2 = new int[] {3, 2, 1, 0, 4};
            var j3 = new int[] {2, 3, 1, 1, 0};
            var j4 = new int[] {2, 0, 0, 0, 2, 0, 0, 0};

            var s = new Solution();
            Console.WriteLine(s.CanJump(j4));
        }
    }

    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            var idx = 0;
            var maxJumpIdx = 0;
            foreach (var num in nums)
            {
                if (idx == nums.Length - 1)
                    return true;
                if (num == 0 && maxJumpIdx <= idx)
                    return false;
                maxJumpIdx = Math.Max(maxJumpIdx, idx + num);

                idx++;
            }

            return true;
        }
    }
}