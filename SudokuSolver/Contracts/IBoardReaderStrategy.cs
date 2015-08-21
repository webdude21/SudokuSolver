namespace SudokuSolver.Contracts
{
    using System.Collections.Generic;

    public interface IBoardReaderStrategy : IEnumerable<byte>
    {
        int Length { get; }
    }
}
