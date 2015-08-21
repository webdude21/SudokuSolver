﻿namespace ConsoleApplication
{
    using System;

    using SudokuSolver;

    class ConsoleApplication
    {
        static void Main(string[] args)
        {
            const string StringInputPuzzle = "002008050000040070480072000008000031600080005570000600000960048090020000030800900";
            var sudokuBoard = new SudokuBoard();
            var sudokuReader = new StringBoardReaderStrategy(StringInputPuzzle);
            sudokuReader.FillBoard(sudokuBoard);
            Console.WriteLine($"Input:{Environment.NewLine}{sudokuBoard}");
            var sudokuSolver = new BruteForceSudokuSolver(sudokuBoard);
            Console.WriteLine($"Output:{Environment.NewLine}{sudokuSolver.Solve()}");
        }
    }
}
