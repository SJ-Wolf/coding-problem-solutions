using System;
using System.Collections.Generic;

namespace Problem_073___Set_Matrix_Zeroes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            var m = new[,] {{0, 1, 2, 0}, {3, 4, 5, 2}, {1, 3, 1, 5}};
//            var m = new[,] {{1, 1, 1}, {1, 0, 1}, {1, 1, 1}};
//            var m = new[,] {{0}, {1}};
//            var m = new[,] {{0, 1, 2, 0}, {3, 4, 5, 2}, {1, 3, 1, 5}};
            var m = new[,]
            {
                {-3, 0, -6, -4},
                {7, 0, -10, -1},
                {-2147483648, -3, 4, -2},
                {5, 2, 4, 2147483647},
                {8, 10, -7, -5}
            };
            new Solution().SetZeroes(m);
            for (int row = 0; row < m.GetLength(0); row++)
            {
                for (int col = 0; col < m.GetLength(1); col++)
                {
                    Console.Write($"{m[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }

    public class Solution
    {
        public void SetZeroes(int[,] matrix)
        {
            var foundZero = false;
            int firstZeroRow = -1, firstZeroCol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        foundZero = true;
                        firstZeroRow = row;
                        firstZeroCol = col;
                        break;
                    }
                }

                if (foundZero)
                    break;
            }

            if (!foundZero)
                return;


            // reserve 1 for marking zeroes
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, firstZeroCol] == 1)
                {
                    matrix[row, firstZeroCol] = 2;
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[firstZeroRow, col] == 1)
                {
                    matrix[firstZeroRow, col] = 2;
                }
            }

            for (int row = firstZeroRow; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == firstZeroRow && col == firstZeroCol)
                        continue;
                    if (matrix[row, col] == 0)
                    {
                        matrix[firstZeroRow, col] = 1;
                        matrix[row, firstZeroCol] = 1;
                    }
                }
            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row == firstZeroRow)
                    continue;
                if (matrix[row, firstZeroCol] == 1)
                {
                    SetRowZeroes(matrix, row, firstZeroCol);
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col == firstZeroCol)
                    continue;
                if (matrix[firstZeroRow, col] == 1)
                {
                    SetColumnZeroes(matrix, col, firstZeroRow);
                }
            }

            SetColumnZeroes(matrix, firstZeroCol);
            SetRowZeroes(matrix, firstZeroRow);
        }

        public static void SetColumnZeroes(int[,] matrix, int col, int skipRow = -1)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                if (row == skipRow)
                    continue;
                matrix[row, col] = 0;
            }
        }

        public static void SetRowZeroes(int[,] matrix, int row, int skipCol = -1)
        {
            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                if (col == skipCol)
                    continue;
                matrix[row, col] = 0;
            }
        }
    }
}