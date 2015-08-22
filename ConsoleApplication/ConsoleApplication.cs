namespace ConsoleApplication
{
    using System;

    using SudokuSolver;
    using SudokuSolver.Contracts;

    class ConsoleApplication
    {
        static void Main()
        {
            var sudokuSolver = SetUpSudokuSolver();
            TryToSolvePuzzle(sudokuSolver);
        }

        private static BruteForceSudokuSolver SetUpSudokuSolver()
        {
            const string StringInputPuzzle = "002008050000040070480070000008000031600080005570000600000960048090020000030800900";
            var sudokuBoard = new SudokuBoard();
            var sudokuReader = new StringBoardReaderStrategy(StringInputPuzzle);
            sudokuReader.FillBoard(sudokuBoard);
            Console.WriteLine($"Input:{Environment.NewLine}{sudokuBoard}");
            var sudokuSolver = new BruteForceSudokuSolver(sudokuBoard);
            return sudokuSolver;
        }

        private static void TryToSolvePuzzle(ISolverStrategy sudokuSolver)
        {
            try
            {
                Console.WriteLine($"Output:{Environment.NewLine}{sudokuSolver.Solve()}");
            }
            catch (OperationCanceledException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
