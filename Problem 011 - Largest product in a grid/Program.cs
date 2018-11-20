using System;

namespace Problem_011___Largest_product_in_a_grid
{
    internal class Program
    {
        public const int Numbers = 4;

        public enum Direction
        {
            DownLeft,
            Down,
            DownRight,
            Right
        };

        public static int GridSubProduct(int[][] grid, int row, int col, Direction d)
        {
            int rowIncrement = 0;
            int colIncrement = 0;

            if (d != Direction.Right)
                rowIncrement = 1;
            if (d == Direction.Right || d == Direction.DownRight)
                colIncrement = 1;
            if (d == Direction.DownLeft)
                colIncrement = -1;

            var lastRow = row + rowIncrement * Numbers;
            var lastCol = col + colIncrement * Numbers;

            if (lastRow > grid.Length || lastRow < 0)
                return 0;
            if (lastCol > grid.Length || lastCol < 0)
                return 0;

            var product = 1;
            var curRow = row;
            var curCol = col;
            for (int i = 0; i < Numbers; i++)
            {
                product *= grid[curRow][curCol];
                curRow += rowIncrement;
                curCol += colIncrement;
            }

            if (curRow != lastRow)
                throw new Exception("!!!!");
            if (curCol != lastCol)
                throw new Exception("!!");

            return product;
        }

        public static int FindMaxSubproduct(int[][] grid)
        {
            var maxProduct = 0;
            for (int row = 0; row < grid.Length; row++)
            {
                for (var col = 0; col < grid[row].Length; col++)
                {
                    maxProduct = Math.Max(maxProduct, GridSubProduct(grid, row, col, Direction.Down));
                    maxProduct = Math.Max(maxProduct, GridSubProduct(grid, row, col, Direction.Right));
                    maxProduct = Math.Max(maxProduct, GridSubProduct(grid, row, col, Direction.DownLeft));
                    maxProduct = Math.Max(maxProduct, GridSubProduct(grid, row, col, Direction.DownRight));
                }
            }

            return maxProduct;
        }

        public static void Main(string[] args)
        {
            int[][] grid = new int[20][];
            for (int grid_i = 0; grid_i < 20; grid_i++)
            {
                string[] grid_temp = Console.ReadLine().Split(' ');
                grid[grid_i] = Array.ConvertAll(grid_temp, Int32.Parse);
            }

            Console.WriteLine(FindMaxSubproduct(grid));
        }
    }
}