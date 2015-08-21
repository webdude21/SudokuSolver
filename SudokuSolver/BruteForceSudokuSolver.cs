namespace SudokuSolver
{
    using System;

    using Contracts;

    public class BruteForceSudokuSolver : ISolverStrategy
    {
        private readonly IBoard inputBoard;

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

            this.inputBoard[cell] = 0;
            return false;
        }

        private Cell GetNextCell(Cell cell)
        {
            while (cell.Row < this.inputBoard.Length && this.inputBoard[cell.Row, cell.Col] > 0)
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

            var row = cell.Row;
            var col = cell.Col;

            var usedDigits = new bool[this.inputBoard.Length];

            for (var index = 0; index < this.inputBoard.Length; index++)
            {
                if (this.inputBoard[row, index] > 0)
                {
                    usedDigits[this.inputBoard[row, index] - 1] = true;
                }

                if (this.inputBoard[index, col] > 0)
                {
                    usedDigits[this.inputBoard[index, col] - 1] = true;
                }

                if (this.inputBoard[(row / tileSize) * tileSize + index / tileSize, (col / tileSize) * tileSize + index % tileSize] > 0)
                {
                    usedDigits[this.inputBoard[(row / tileSize) * tileSize + index / tileSize, (col / tileSize) * tileSize + index % tileSize] - 1] = true;
                }
            }

            return usedDigits;
        }
    }
}