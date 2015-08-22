namespace SudokuSolver
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class BruteForceSudokuSolver : ISolverStrategy
    {
        private readonly IBoard inputBoard;

        private const int EmptyCell = 0;

        public BruteForceSudokuSolver(IBoard inputBoard)
        {
            this.inputBoard = inputBoard;
        }

        public IBoard Solve()
        {
            if (!this.Solved(new Cell { Row = 0, Col = 0 }))
            {
                throw new OperationCanceledException("The puzzle cannot be solved");
            }

            return this.inputBoard;
        }

        private bool Solved(Cell cell)
        {
            var usedDigits = this.GetUsedDigits(cell);

            for (byte digit = 1; digit < this.inputBoard.Length + 1; digit++)
            {
                if (!usedDigits[digit - 1])
                {
                    this.inputBoard[cell] = digit;

                    var nextCell = this.GetNextCell(cell);

                    if (nextCell.Row == this.inputBoard.Length)
                    {
                        return true;
                    }

                    if (this.Solved(nextCell))
                    {
                        return true;
                    }
                }
            }

            this.inputBoard[cell] = EmptyCell;
            return false;
        }

        private Cell GetNextCell(Cell cell)
        {
            while (cell.Row < this.inputBoard.Length && this.inputBoard[cell.Row, cell.Col] != EmptyCell)
            {
                if (++cell.Col > 8)
                {
                    cell.Col = 0;
                    cell.Row++;
                }
            }

            return cell;
        }

        private bool[] GetUsedDigits(Cell cell)
        {
            var tileSize = this.inputBoard.TileSize;
            var usedDigits = new bool[this.inputBoard.Length];

            for (byte index = 0; index < this.inputBoard.Length; index++)
            {
                this.GetIfDigitIsUsed(new Cell { Row = cell.Row, Col = index }, usedDigits);
                this.GetIfDigitIsUsed(new Cell { Row = index, Col = cell.Col }, usedDigits);
                this.GetIfDigitIsUsed(new Cell { Row = (byte)((cell.Row / tileSize) * tileSize + index / tileSize),
                    Col = (byte)((cell.Col / tileSize) * tileSize + index % tileSize)
                }, usedDigits);
            }

            return usedDigits;
        }

        private void GetIfDigitIsUsed(Cell cellToCheck, IList<bool> usedDigits)
        {
            if (this.inputBoard[cellToCheck] != EmptyCell)
            {
                usedDigits[this.inputBoard[cellToCheck] - 1] = true;
            }
        }
    }
}