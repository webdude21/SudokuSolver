namespace SudokuSolver.Contracts
{
    public interface ISolverStrategy
    {
        IBoard Solve(IBoard input);
    }
}