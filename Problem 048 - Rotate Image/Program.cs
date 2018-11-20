//https://leetcode.com/problems/rotate-image/

using System;

namespace Problem_48___Rotate_Image
{
    public class Solution
    {
        public static void Swap(int[,] matrix, int row1, int col1, int row2, int col2)
        {
            var tmp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = tmp;
        }

        public void Rotate(int[,] matrix)
        {
            var size = matrix.GetLength(0);

            // upside-down
            for (var col = 0; col < size; col++)
            {
                for (var row = 0; row < size / 2; row++)
                {
                    var swapRow = size - row - 1;
                    Swap(matrix, row, col, swapRow, col);
                }
            }

            // swap along diagonals
            for (var row = 1; row < size; row++)
            {
                for (var col = 0; col < row; col++)
                {
                    Swap(matrix, row, col, col, row);
                }
            }
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
//            var mat = new[,]
//            {
//                {1, 2, 3},
//                {4, 5, 6},
//                {7, 8, 9},
//            };
            var mat = new[,]
            {
                {5, 1, 9, 11},
                {2, 4, 8, 10},
                {13, 3, 6, 7},
                {15, 14, 12, 16},
            };
            new Solution().Rotate(mat);
            for (var i = 0; i < mat.GetLength(0); i++)
            {
                for (var k = 0; k < mat.GetLength(1); k++)
                {
                    Console.Write($"{mat[i, k]} ");
                }

                Console.WriteLine();
            }
        }
    }
}