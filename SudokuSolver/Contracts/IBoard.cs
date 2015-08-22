namespace SudokuSolver.Contracts
{
    public interface IBoard 
    {
        byte Length { get; }

        byte TileSize { get; }

        byte this[int row, int col] { get; set; }

        byte this[Cell cell] { get; set; }
    }
}