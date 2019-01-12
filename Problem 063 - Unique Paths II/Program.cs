using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Problem_063___Unique_Paths_II
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            Console.WriteLine(new Solution().UniquePathsWithObstacles(new int[,] {{0, 0, 0}, {1, 1, 0}, {0, 0, 0}}));
            Console.WriteLine(new Solution().UniquePathsWithObstacles(new int[,] {{0, 0, 0}, {0, 0, 0}, {0, 0, 1}}));
//            Console.WriteLine(new Solution().UniquePathsWithObstacles(new int[,] {{0}, {1}}));
        }
    }

    public class Solution
    {
        private const int Empty = -1;
        private const int Full = -2;

        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            for (var row = 0; row < obstacleGrid.GetLength(0); row++)
            {
                for (var col = 0; col < obstacleGrid.GetLength(1); col++)
                {
                    if (obstacleGrid[row, col] == 0)
                        obstacleGrid[row, col] = Empty;
                    else
                        obstacleGrid[row, col] = Full;
                }
            }

            var output = GetLatticePaths(obstacleGrid, 0, 0);

            for (var row = 0; row < obstacleGrid.GetLength(0); row++)
            {
                for (var col = 0; col < obstacleGrid.GetLength(1); col++)
                {
                    var elem = obstacleGrid[row, col];
                    var c = elem.ToString();
                    if (elem == Empty)
                        c = "e";
                    else if (elem == Full)
                        c = "F";
                    Console.Write(c + " ");
                }

                Console.WriteLine();
            }

            return output;
        }

        public static int GetLatticePaths(int[,] lattice, int n, int m)
        {
            if (n == lattice.GetLength(0) || m == lattice.GetLength(1))
                return 0;
            
            var existingLatticeNumber = lattice[n, m];
            if (existingLatticeNumber == Full)
                return 0;

            if (existingLatticeNumber >= 0)
                return lattice[n, m];

            if (n == lattice.GetLength(0) - 1 && m == lattice.GetLength(1) - 1)
            {
                lattice[n, m] = 1;
            }
            else
            {
                lattice[n, m] = GetLatticePaths(lattice, n + 1, m) + GetLatticePaths(lattice, n, m + 1);
            }

            return lattice[n, m];
        }
    }
}