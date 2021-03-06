﻿namespace SudokuSolver
{
    using System;
    using System.Text;

    using Contracts;

    public class SudokuBoard : IBoard, IEquatable<SudokuBoard>
    {
        private const byte BoardSize = 9;

        private const byte BoardTileSize = 3;

        private byte[][] board;

        public SudokuBoard()
        {
            this.InitializeBoard();
        }

        public byte Length => BoardSize;

        public byte TileSize => BoardTileSize;

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
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Any value used in the board should be less than the boardSize!");
                }

                this.board[row][col] = value;
            }
        }

        public byte this[Cell cell]
        {
            get
            {
                return this[cell.Row, cell.Col];
            }
            set
            {
                this[cell.Row, cell.Col] = value;
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

        public static bool operator ==(SudokuBoard left, SudokuBoard right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SudokuBoard left, SudokuBoard right)
        {
            return !Equals(left, right);
        }

        private void InitializeBoard()
        {
            this.board = new byte[BoardSize][];

            for (var i = 0; i < BoardSize; i++)
            {
                this.board[i] = new byte[BoardSize];
            }
        }

        public override bool Equals(object obj)
        {
            var sudokuBoard = obj as SudokuBoard;
            return sudokuBoard != null && this.Equals(sudokuBoard);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < BoardSize; i++)
            {
                stringBuilder.AppendLine(string.Join(", ", this.board[i]));
            }

            return stringBuilder.ToString();
        }
    }
}