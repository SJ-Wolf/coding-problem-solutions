using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Problem_54___Spiral_Matrix
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var m1 = new int[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
            };

            var m2 = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
            };

            var m3 = new int[,]
            {
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, {11, 12, 13, 14, 15, 16, 17, 18, 19, 20}
            };

            Console.WriteLine(string.Join(", ", SpiralOrder(m3)));
        }

        public static IList<int> SpiralOrder(int[,] matrix)
        {
            var output = new List<int>(matrix.Length);
            for (var idx = 0; idx <= Math.Min(matrix.GetLength(0), matrix.GetLength(1)); idx++)
            {
                var lastRow = matrix.GetLength(0) - 1 - idx;
                var lastCol = matrix.GetLength(1) - 1 - idx;

                if (lastRow < idx || lastCol < idx)
                    break;
                for (var col = idx; col <= lastCol; col++)
                    output.Add(matrix[idx, col]);
                for (var row = idx + 1; row <= lastRow; row++)
                    output.Add(matrix[row, lastCol]);
                if (lastRow == idx || lastCol == idx)
                    break;
                for (var col = lastCol - 1; col >= idx; col--)
                    output.Add(matrix[lastRow, col]);
                for (var row = lastRow - 1; row > idx; row--)
                    output.Add(matrix[row, idx]);
            }

            return output;
        }
    }
}