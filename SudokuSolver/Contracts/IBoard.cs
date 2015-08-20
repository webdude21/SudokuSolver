namespace SudokuSolver.Contracts
{
    public interface IBoard
    {
        byte BoardSize { get; }

        byte this[int row, int col] { get; set; }
    }
}
