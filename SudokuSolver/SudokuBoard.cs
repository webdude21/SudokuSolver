namespace SudokuSolver
{
    using System;

    using Contracts;

    public class SudokuBoard : IBoard, IEquatable<SudokuBoard>
    {
        private byte[][] board;

        public SudokuBoard(byte boardSize = 9)
        {
            this.BoardSize = boardSize;
            this.InitializeBoard();
        }

        public byte BoardSize { get; }

        private void InitializeBoard()
        {
            this.board = new byte[this.BoardSize][];

            for (var i = 0; i < this.BoardSize; i++)
            {
                this.board[i] = new byte[this.BoardSize];
            }
        }

        public byte this[int row, int col]
        {
            get
            {
                return this.board[row][col];
            }

            set
            {
                if (value > this.BoardSize)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Any value used in the board should be less than the boardSize!");
                }

                this.board[row][col] = value;
            }
        }

        public bool Equals(SudokuBoard other)
        {
            if (this.BoardSize != other.BoardSize)
            {
                return false;
            }

            for (var row = 0; row < this.BoardSize; row++)
            {
                for (var col = 0; col < this.BoardSize; col++)
                {
                    if (this[row, col] != other[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
