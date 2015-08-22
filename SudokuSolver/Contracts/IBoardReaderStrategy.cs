namespace SudokuSolver.Contracts
{
    public interface IBoardReaderStrategy
    {
        int Length { get; }

        void FillBoard(IBoard board);
    }
}