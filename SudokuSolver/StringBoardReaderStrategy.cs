namespace SudokuSolver
{
    using System;

    using Contracts;

    public class StringBoardReaderStrategy : IBoardReaderStrategy
    {
        private readonly string input;

        public StringBoardReaderStrategy(string input)
        {
            this.input = input;
        }

        private void CheckIfBoardReaderHasEnoughDigits(IBoard board)
        {
            if (board.Length * board.Length < this.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(board.Length),
                    "The're are not enough digits in the reader to fill the entire board!");
            }
        }

        public int Length => this.input.Length;

        public void FillBoard(IBoard board)
        {
            this.CheckIfBoardReaderHasEnoughDigits(board);
            var row = 0;
            var col = 0;

            foreach (var digit in this.input)
            {
                if (col >= board.Length)
                {
                    col = 0;
                    row += 1;
                }

                if (row >= board.Length)
                {
                    break;
                }

                board[row, col] = (byte)(digit - '0');

                col++;
            }
        }
    }
}
