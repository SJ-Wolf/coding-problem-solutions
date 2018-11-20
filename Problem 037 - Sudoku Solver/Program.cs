using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project_37___Sudoku_Solver
{
    public class SudokuList
    {
        private readonly char[] _list;
        private readonly HashSet<char> _existingNumbers;

        public SudokuList(IEnumerable<char> list)
        {
            _list = list.ToArray();
            var numbers = _list.Where(n => n != '.').ToList();
            _existingNumbers = new HashSet<char>(numbers);
            if (numbers.Count != _existingNumbers.Count)
                throw new InvalidDataException("Invalid SudokuList!");
        }

        public bool AddElement(int i, char value)
        {
            if (_existingNumbers.Contains(value))
                return false;
            _existingNumbers.Add(value);
            _list[i] = value;
            return true;
        }

        public void RemoveElement(int i)
        {
            _existingNumbers.Remove(_list[i]);
            _list[i] = '.';
        }
    }

    public class SudokuBoard
    {
        public readonly char[,] Board;
        public readonly int SquareSize;
        public readonly int BoardSize;
        public int EmptySquares { private set; get; }
        private readonly SudokuList[] _columns;
        private readonly SudokuList[] _rows;
        private readonly SudokuList[] _squares;


        public SudokuBoard(char[,] board, int squareSize = 3)
        {
            Board = board;
            SquareSize = squareSize;
            BoardSize = board.GetLength(0);
            if (board.GetLength(1) != BoardSize)
                throw new Exception("Board must be square!");

            _columns = new SudokuList[BoardSize];
            _rows = new SudokuList[BoardSize];
            _squares = new SudokuList[BoardSize];

            for (var i = 0; i < BoardSize; i++)
            {
                _columns[i] = new SudokuList(GetColumn(i));
                _rows[i] = new SudokuList(GetRow(i));
                _squares[i] = new SudokuList(GetSquare(i));
            }

            EmptySquares = board.Length;

            foreach (var c in board)
            {
                if (c != '.')
                    EmptySquares--;
            }
        }

        public bool AddElement(int row, int col, char value)
        {
            if (Board[row, col] != '.')
                return false;

            var success = _columns[col].AddElement(row, value);
            if (!success)
                return false;
            success = _rows[row].AddElement(col, value);
            if (!success)
            {
                _columns[col].RemoveElement(row);
                return false;
            }

            var squareRow = row / SquareSize;
            var squareCol = col / SquareSize;
            var squareIndex = SquareSize * squareRow + squareCol;
            var inSquareRow = row - SquareSize * squareRow;
            var inSquareCol = col - SquareSize * squareCol;
            var inSquareIndex = inSquareRow * SquareSize + inSquareCol;

            success = _squares[squareIndex].AddElement(inSquareIndex, value);
            if (!success)
            {
                _columns[col].RemoveElement(row);
                _rows[row].RemoveElement(col);
                return false;
            }

            Board[row, col] = value;
            EmptySquares--;
            return true;
        }

        public void RemoveElement(int row, int col)
        {
            _columns[col].RemoveElement(row);
            _rows[row].RemoveElement(col);
            var squareRow = row / SquareSize;
            var squareCol = col / SquareSize;
            var squareIndex = SquareSize * squareRow + squareCol;
            var inSquareRow = row - SquareSize * squareRow;
            var inSquareCol = col - SquareSize * squareCol;
            var inSquareIndex = inSquareRow * SquareSize + inSquareCol;

            _squares[squareIndex].RemoveElement(inSquareIndex);

            Board[row, col] = '.';
            EmptySquares++;
        }

        private IEnumerable<char> GetColumn(int c)
        {
            for (var i = 0; i < Board.GetLength(0); i++)
            {
                yield return Board[i, c];
            }
        }

        private IEnumerable<char> GetRow(int r)
        {
            for (var i = 0; i < Board.GetLength(1); i++)
            {
                yield return Board[r, i];
            }
        }

        private IEnumerable<char> GetSquare(int row, int col)
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

        private IEnumerable<char> GetSquare(int squareNumber)
        {
            int remainder;
            var quotient = Math.DivRem(squareNumber, SquareSize, out remainder);
            return GetSquare(quotient, remainder);
        }
    }

    public class Solution
    {
        private static bool SolveSudokuHelper(SudokuBoard board, int startRow = 0, int startCol = 0)
        {
            // base case
            if (board.EmptySquares == 0)
            {
                return true;
            }

            // make sure startRow and startCol are good (on the board and pointing to an empty spot)
            while (true)
            {
                if (startCol >= board.BoardSize)
                {
                    startCol = 0;
                    startRow++;
                }

                if (board.Board[startRow, startCol] != '.')
                {
                    startCol++;
                    continue;
                }

                break;
            }

            for (var i = '1'; i <= '9'; i++)
            {
                if (!board.AddElement(startRow, startCol, i)) continue;

                if (SolveSudokuHelper(board, startRow, startCol + 1)) return true;

                board.RemoveElement(startRow, startCol);
            }

            return false;
        }

        public void SolveSudoku(char[,] board)
        {
            var myBoard = new SudokuBoard(board, 3);
            Console.WriteLine(SolveSudokuHelper(myBoard));

            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var k = 0; k < board.GetLength(1); k++)
                {
                    Console.Write($"{board[i, k]} ");
                }

                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var board1 = new[,]
            {
                {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'},
            };

            var board2 = new[,]
            {
                {'8', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'},
            };

            var board3 = new[,]
            {
                {'1', '2', '.', '4'},
                {'.', '.', '.', '.'},
                {'.', '.', '.', '2'},
                {'.', '.', '4', '1'},
            };

            var board4 = new[,]
            {
                {'.', '1'},
                {'.', '.'},
            };


            (new Solution()).SolveSudoku(board1);
//            (new Solution()).SolveSudoku(board2);
        }
    }
}