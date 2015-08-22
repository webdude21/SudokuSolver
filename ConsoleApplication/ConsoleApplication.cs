namespace ConsoleApplication
{
    using System;

    using SudokuSolver;
    using SudokuSolver.Contracts;

    internal class ConsoleApplication
    {
        private static void Main()
        {
            var sudokuBoard = new SudokuBoard();
            var sudokuSolver = SetUpSudokuSolver(sudokuBoard);
            TryToSolvePuzzle(sudokuSolver, sudokuBoard);
        }

        private static BruteForceSudokuSolver SetUpSudokuSolver(IBoard sudokuBoard)
        {
            const string StringInputPuzzle =
                "002008050000040070480070000008000031600080005570000600000960048090020000030800900";

            var sudokuReader = new StringBoardReaderStrategy(StringInputPuzzle);
            sudokuReader.FillBoard(sudokuBoard);
            Console.WriteLine($"Input:{Environment.NewLine}{sudokuBoard}");
            var sudokuSolver = new BruteForceSudokuSolver();
            return sudokuSolver;
        }

        private static void TryToSolvePuzzle(ISolverStrategy sudokuSolver, IBoard sudokuBoard)
        {
            try
            {
                Console.WriteLine($"Output:{Environment.NewLine}{sudokuSolver.Solve(sudokuBoard)}");
            }
            catch (OperationCanceledException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}