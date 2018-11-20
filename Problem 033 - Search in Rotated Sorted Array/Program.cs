using System;

namespace Problem_33___Search_in_Rotated_Sorted_Array
{
    public class Solution
    {
        public static int FindPivotIndex(int[] nums)
        {
            int leftIndex = 0;
            int rightIndex = nums.Length - 1;
            int pivot;

            while (true)
            {
                int diff = rightIndex - leftIndex;
                int midpoint = leftIndex + (diff + 1) / 2;
                if (diff <= 1)
                {
                    pivot = leftIndex + 1;
                    break;
                }
                else if (nums[leftIndex] > nums[midpoint])
                {
                    // left side unsorted
                    rightIndex = midpoint;
                }
                else if (nums[rightIndex] < nums[midpoint])
                {
                    // right side unsorted
                    leftIndex = midpoint;
                }
                else
                {
                    return nums.Length;
                }
            }


            return pivot;
        }

        public int RestrictedBinarySearch(int[] nums, int target, int startIndex, int endIndex)
        {
            while (startIndex <= endIndex)
            {
                var midpoint = (endIndex + startIndex) / 2;

                if (nums[midpoint] > target)
                {
                    endIndex = midpoint - 1;
                }
                else if (nums[midpoint] < target)
                {
                    startIndex = midpoint + 1;
                }
                else
                {
                    return midpoint;
                }
            }

            return -1;
        }

        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;
            else if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;
            int pivot = FindPivotIndex(nums);
            int indexInLeftSide = RestrictedBinarySearch(nums, target, 0, pivot - 1);
            if (indexInLeftSide != -1)
                return indexInLeftSide;
            int indexInRightSide = RestrictedBinarySearch(nums, target, pivot, nums.Length - 1);
            return indexInRightSide;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new Solution();
            Console.WriteLine(s.Search(new int[]
            {
                1, 2, 3
            }, 3));
        }
    }
}