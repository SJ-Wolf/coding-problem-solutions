using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_018___Maximum_path_sum_I
{
    internal class Program
    {
        public static int MaximumPathSum(int[][] triangle, int row, int col, int curSum, int maxSum, int maxNum)
        {
            if (row < triangle.Length)
            {
                curSum += triangle[row][col];
                if (curSum + maxNum * (triangle.Length - row) <= maxSum)
                {
                    return maxSum;
                }

                for (int i = 0; i <= 1; i++)
                {
                    maxSum = MaximumPathSum(triangle, row + 1, col + i, curSum, maxSum, maxNum);
                }
            }

            return Math.Max(curSum, maxSum);
        }

        public static int MaximumPathSumWithPath(int[][] triangle, int row, int col, int curSum, int maxSum,
            List<int> curList = null)
        {
            if (curList == null)
                curList = new List<int>();

            Console.WriteLine(string.Join(", ", curList));

            if (row < triangle.Length)
            {
                curSum += triangle[row][col];
                curList.Add(triangle[row][col]);

                for (int i = 0; i <= 1; i++)
                {
                    maxSum = MaximumPathSumWithPath(triangle, row + 1, col + i, curSum, maxSum, curList);
                }

                curList.RemoveAt(curList.Count - 1);
            }

            return Math.Max(curSum, maxSum);
        }


        public static void Main(string[] args)
        {
//            var triangle = new int[4][]
//            {
//                new int[] {3},
//                new int[] {9, 4},
//                new int[] {2, 9, 6},
//                new int[] {8, 5, 9, 3},
//            };
            int testCases = Convert.ToInt32(Console.ReadLine());
            for (int testCaseIdx = 0; testCaseIdx < testCases; testCaseIdx++)
            {
                int triangleRows = Convert.ToInt32(Console.ReadLine());
                var triangle = new int[triangleRows][];
                for (var row = 0; row < triangleRows; row++)
                {
                    triangle[row] = Console.ReadLine().Split().Select(x => Convert.ToInt32(x)).ToArray();
                }
                Console.WriteLine(MaximumPathSum(triangle, 0, 0, 0, 0, 99));
            }

        }
    }
}