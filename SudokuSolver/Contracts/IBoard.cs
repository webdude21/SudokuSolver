namespace SudokuSolver.Contracts
{
    public interface IBoard
    {
        byte Length { get; }

        byte this[int row, int col] { get; set; }
    }
}
