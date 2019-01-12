using System;
using System.Configuration;

namespace Problem_064___Minimum_Path_Sum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var grid = new[,] {{1, 3, 1}, {1, 5, 1}, {4, 2, 1}};

            Console.WriteLine(new Solution().MinPathSum(grid));
            for (var row = 0; row < grid.GetLength(0); row++)
            {
                for (var col = 0; col < grid.GetLength(1); col++)
                {
                    var elem = grid[row, col];
                    var c = elem.ToString();
                    Console.Write(c + " ");
                }

                Console.WriteLine();
            }
        }
    }

    public class Solution
    {
        public int MinPathSum(int[,] grid)
        {
            for (var row = 0; row < grid.GetLength(0); row++)
            {
                for (var col = 0; col < grid.GetLength(1); col++)
                {
                    grid[row, col] = ~grid[row, col];
                }
            }
            if (grid.GetLength(0) == 0 || grid.GetLength(1) == 0)
                return 0;
            return MinPathSumHelper(grid, 0, 0);
        }

        public int MinPathSumHelper(int[,] grid, int row, int col)
        {
            if (row == grid.GetLength(0) || col == grid.GetLength(1))
                return int.MaxValue;
            if (row == grid.GetLength(0) - 1 && col == grid.GetLength(1) - 1)
                return ~grid[row, col];
            if (grid[row, col] >= 0) // nonnegative num => predetermined sum
                return grid[row, col];
            var additionalSum = -grid[row, col] - 1;

            var bottomPath = MinPathSumHelper(grid, row + 1, col);
            var rightPath = MinPathSumHelper(grid, row, col + 1);
            var output = additionalSum + Math.Min(bottomPath, rightPath);

            grid[row, col] = output;

            return output;
        }
    }
}