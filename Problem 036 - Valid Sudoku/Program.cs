using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Project_36___Valid_Sudoku
{
    public class SudokuBoard
    {
        public readonly char[,] Board;
        public readonly int SquareSize;

        public SudokuBoard(char[,] board, int squareSize = 3)
        {
            Board = board;
            SquareSize = squareSize;
        }

        public IEnumerable<char> GetColumn(int c)
        {
            for (var i = 0; i < Board.GetLength(0); i++)
            {
                yield return Board[i, c];
            }
        }

        public IEnumerable<char> GetRow(int r)
        {
            for (var i = 0; i < Board.GetLength(1); i++)
            {
                yield return Board[r, i];
            }
        }

        public IEnumerable<char> GetSquare(int row, int col)
        {
            var initialRow = row * SquareSize;
            var initialCol = col * SquareSize;
            for (var i = 0; i < SquareSize; i++)
            {
                for (var j = 0; j < SquareSize; j++)
                {
                    yield return Board[initialRow + i, initialCol + j];
                }
            }
        }

        public IEnumerable<char> GetSquare(int squareNumber)
        {
            int remainder;
            var quotient = Math.DivRem(squareNumber, SquareSize, out remainder);
            return GetSquare(quotient, remainder);
        }

        public static bool IsValidList(IEnumerable<char> list)
        {
            var numbers = list.Where(n => n != '.').ToList();
            var numSet = new HashSet<char>(numbers);
            return numbers.Count == numSet.Count;
        }
    }

    public class Solution
    {
        public bool IsValidSudoku(char[,] board)
        {
            var myBoard = new SudokuBoard(board);
            for (int i = 0; i < 9; i++)
            {
                var col = myBoard.GetColumn(i);
                if (!SudokuBoard.IsValidList(col))
                    return false;
                var row = myBoard.GetRow(i);
                if (!SudokuBoard.IsValidList(row))
                    return false;
                var square = myBoard.GetSquare(i);
                if (!SudokuBoard.IsValidList(square))
                    return false;
            }

            return true;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var board1 = new char[,]
            {
                {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };

            var board2 = new char[,]
            {
                {'8', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };

            Console.WriteLine((new Solution()).IsValidSudoku(board1));
            Console.WriteLine((new Solution()).IsValidSudoku(board2));
        }
    }
}