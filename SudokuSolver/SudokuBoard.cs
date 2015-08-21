namespace SudokuSolver
{
    using System;

    using Contracts;

    public class SudokuBoard : IBoard, IEquatable<SudokuBoard>
    {
        private readonly IBoardReaderStrategy boardReader;

        private byte[][] board;

        private const byte BoardSize = 9;

        public SudokuBoard(IBoardReaderStrategy boardReader)
        {
            this.boardReader = boardReader;
            this.InitializeBoard();
            this.FillBoard();
        }

        public byte Length => BoardSize;

        private void InitializeBoard()
        {
            this.board = new byte[BoardSize][];

            for (var i = 0; i < BoardSize; i++)
            {
                this.board[i] = new byte[BoardSize];
            }
        }

        private void FillBoard()
        {
            this.CheckIfBoardReaderHasEnoughDigits();
            var row = 0;
            var col = 0;

            foreach (var digit in this.boardReader)
            {
                this[row, col] = digit;

                if (col >= this.Length)
                {
                    col = 0;
                    row += 1;
                }

                if (row >= this.Length)
                {
                    break;
                }

            }
        }

        private void CheckIfBoardReaderHasEnoughDigits()
        {
            if (this.Length * this.Length < this.boardReader.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Length),
                    "The're are not enough digits in the reader to fill the entire board!");
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
                if (value > BoardSize)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Any value used in the board should be less than the boardSize!");
                }

                this.board[row][col] = value;
            }
        }

        public bool Equals(SudokuBoard other)
        {
            for (var row = 0; row < BoardSize; row++)
            {
                for (var col = 0; col < BoardSize; col++)
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
