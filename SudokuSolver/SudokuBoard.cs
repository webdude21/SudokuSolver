﻿namespace SudokuSolver
{
    using System;

    using Contracts;

    public class SudokuBoard : IBoard, IEquatable<SudokuBoard>
    {
        private byte[][] board;

        private const byte BoardSize = 9;

        public SudokuBoard(IBoardReaderStrategy boardReader)
        {
            this.InitializeBoard();
            boardReader.FillBoard(this);
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
