using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_67___Maximum_path_sum_II
{
    internal class Program
    {

        public static int MaximumPathSum(int[][] triangle, int row, int col, int curSum, int maxNum,
            int[,] memo)
        {
            if (row == triangle.Length)
            {
                return curSum;
            }

            if (memo[row, col] != 0)
                return memo[row, col];

            curSum = Math.Max(
                MaximumPathSum(triangle, row + 1, col, curSum, maxNum, memo),
                MaximumPathSum(triangle, row + 1, col + 1, curSum, maxNum, memo));
            memo[row, col] = curSum + triangle[row][col];

            return memo[row, col];
        }


        public static void Main(string[] args)
        {
//            var triangle = new int[4][]
//            {
//                new int[] {3},
//                new int[] {7, 4},
//                new int[] {2, 4, 6},
//                new int[] {8, 5, 9, 3},
//            };
//            var triangle = new int[][]
//            {
//                new[] {75},
//                new[] {95, 64},
//                new[] {17, 47, 82},
//                new[] {18, 35, 87, 10},
//                new[] {20, 04, 82, 47, 65},
//                new[] {19, 01, 23, 75, 03, 34},
//                new[] {88, 02, 77, 73, 07, 63, 67},
//                new[] {99, 65, 04, 28, 06, 16, 70, 92},
//                new[] {41, 41, 26, 56, 83, 40, 80, 70, 33},
//                new[] {41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
//                new[] {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
//                new[] {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
//                new[] {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
//                new[] {63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
//                new[] {04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23},
//            };
//            Console.WriteLine(MaximumPathSum(triangle, 0, 0, 0, 99,
//                new int[triangle.Length, triangle.Length]));
//            Console.WriteLine(iterations);
            int testCases = Convert.ToInt32(Console.ReadLine());
            for (int testCaseIdx = 0; testCaseIdx < testCases; testCaseIdx++)
            {
                int triangleRows = Convert.ToInt32(Console.ReadLine());
                var triangle = new int[triangleRows][];
                for (var row = 0; row < triangleRows; row++)
                {
                    triangle[row] = Console.ReadLine().Split().Select(x => Convert.ToInt32(x)).ToArray();
                }

                Console.WriteLine(MaximumPathSum(triangle, 0, 0, 0, 0, new int[triangle.Length, triangle.Length]));
            }
        }
    }
}