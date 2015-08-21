namespace SudokuSolver.Contracts
{
    using System;

    public interface IBoard : ICloneable
    {
        byte Length { get; }

        byte TileSize { get; }

        byte this[int row, int col] { get; set; }

        byte this[Cell cell] { get; set; }
    }
}
