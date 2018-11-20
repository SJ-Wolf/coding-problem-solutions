using System;
using System.Collections.Generic;

namespace Problem_052___N_Queens_II
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = 4;
//            var q = new QueenBoard(n);
//            var p1 = q.TryPlaceQueen(3, 0);
//            var p2 = q.TryPlaceQueen(4, 1);
//            var i = 0;


            Console.WriteLine(TotalNQueens(n));
        }

        public static int SolveNQueenHelper(QueenBoard board, int row, int numSolutions)
        {
            if (row == board.Size)
            {
                return numSolutions + 1;
            }

            for (var col = 0; col < board.Size; col++)
            {
                var successfulPlacement = board.TryPlaceQueen(row, col);
                if (successfulPlacement)
                {
                    numSolutions = SolveNQueenHelper(board, row + 1, numSolutions);
                    board.RemoveQueen(row, col);
                }
            }

            return numSolutions;
        }

        public static int TotalNQueens(int n)
        {
            var q = new QueenBoard(n);
            return SolveNQueenHelper(q, 0, 0);
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
            return GetTopRightDiagonalIndex(row, Size - 1 - col);
        }
    }
}