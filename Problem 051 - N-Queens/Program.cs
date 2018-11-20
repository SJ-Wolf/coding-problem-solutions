using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_51___N_Queens
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = 5;
//            var q = new QueenBoard(n);
//            var p1 = q.TryPlaceQueen(3, 0);
//            var p2 = q.TryPlaceQueen(4, 1);
//            var i = 0;


            foreach (var x in SolveNQueens(n))
            {
                foreach (var y in x)
                    Console.WriteLine(y);
                Console.WriteLine();
            }
        }

        public static void SolveNQueenHelper(QueenBoard board, int row, IList<IList<string>> solutions)
        {
            if (row == board.Size)
            {
                solutions.Add(board.ToStringList());
                return;
            }

            for (var col = 0; col < board.Size; col++)
            {
                var successfulPlacement = board.TryPlaceQueen(row, col);
                if (successfulPlacement)
                {
                    SolveNQueenHelper(board, row + 1, solutions);
                    board.RemoveQueen(row, col);
                }
            }
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            var output = new List<IList<string>>();
            var q = new QueenBoard(n);
            SolveNQueenHelper(q, 0, output);
            return output;
        }
    }

    public class QueenBoard
    {
        private readonly bool[,] _board;
        private readonly bool[] _columns;
        private readonly bool[] _rows;
        private readonly bool[] _topRightDiagonals;
        private readonly bool[] _bottomRightDiagonal;
        public readonly int Size;

        public QueenBoard(int n)
        {
            Size = n;
            _board = new bool[n, n];
            _columns = new bool[n];
            _rows = new bool[n];
            _topRightDiagonals = new bool[Math.Max(1, 2 * n - 3)];
            _bottomRightDiagonal = new bool[Math.Max(1, 2 * n - 3)];
        }

        public bool TryPlaceQueen(int row, int col)
        {
            if (_board[row, col])
                throw new Exception("Tried to place Queen where one already exists!");
            if (_columns[col] || _rows[row])
                return false;
            var topRightDiag = GetTopRightDiagonalIndex(row, col);
            if (topRightDiag >= 0 && _topRightDiagonals[topRightDiag])
                return false;
            var botRightDiag = GetBottomRightDiagonalIndex(row, col);
            if (botRightDiag != -1 && _bottomRightDiagonal[botRightDiag])
                return false;
            _board[row, col] = _columns[col] = _rows[row] = true;
            if (topRightDiag != -1)
                _topRightDiagonals[topRightDiag] = true;
            if (botRightDiag != -1)
                _bottomRightDiagonal[botRightDiag] = true;
            return true;
        }

        public void RemoveQueen(int row, int col)
        {
            if (!_board[row, col])
                throw new Exception("Tried to remove non-existent queen!");

            var topRightDiag = GetTopRightDiagonalIndex(row, col);
            var botRightDiag = GetBottomRightDiagonalIndex(row, col);

            _board[row, col] = _columns[col] = _rows[row] = false;
            if (topRightDiag != -1)
                _topRightDiagonals[topRightDiag] = false;
            if (botRightDiag != -1)
                _bottomRightDiagonal[botRightDiag] = false;
        }

        private int GetTopRightDiagonalIndex(int row, int col)
        {
            var topRightDiag = row + col - 1;
            if (topRightDiag == _topRightDiagonals.Length)
                return -1;
            return topRightDiag;
        }

        private int GetBottomRightDiagonalIndex(int row, int col)
        {
//            var botRightDiag = col - row + 1;
//            if (botRightDiag == _bottomRightDiagonal.Length)
//                return -1;
//            return botRightDiag;
            return GetTopRightDiagonalIndex(row, Size - 1 - col);
        }

        public IList<string> ToStringList()
        {
            var output = new List<string>();
            var s = new char[Size];
            var col = 0;
            foreach (var b in _board)
            {
                if (b)
                    s[col] = 'Q';
                else
                {
                    s[col] = '-';
                }

                col++;
                if (col == Size)
                {
                    col = 0;
                    output.Add(new string(s));
                }
            }

            return output;
        }
    }
}