namespace SudokuSolverTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SudokuSolver;

    [TestClass]
    public class SudokuSolverTest
    {
        private const string TestCaseInitial =
            "002008050000040070480072000008000031600080005570000600000960048090020000030800900";

        private const string TestCaseSolution =
            "712698354369541872485372196928756431643189725571234689157963248896427513234815967";

        private const string EmptyPuzzleSolution =
            "123456789456789123789123456214365897365897214897214365531642978642978531978531642";

        private readonly BruteForceSudokuSolver boardBruteForceSolver;

        private readonly SudokuBoard boardInstance;

        private readonly StringBoardReaderStrategy boardReaderInstance;

        public SudokuSolverTest()
        {
            this.boardInstance = new SudokuBoard();
            this.boardReaderInstance = new StringBoardReaderStrategy(TestCaseInitial);
            this.boardBruteForceSolver = new BruteForceSudokuSolver();
        }

        [TestMethod]
        public void Init()
        {
            Assert.IsInstanceOfType(new SudokuBoard(), typeof(SudokuBoard));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Expecting exception when the value is larger than the board size")]
        public void SettingValuesToBoard()
        {
            this.boardInstance[1, 1] = 10;
        }

        [TestMethod]
        public void SettingValidValueCanBeRetrievedLater()
        {
            const byte ValueToSet = 2;
            this.boardInstance[1, 1] = ValueToSet;
            Assert.AreEqual(this.boardInstance[1, 1], ValueToSet);
        }

        [TestMethod]
        public void VerifyThatEmptyPuzzleIsSolved()
        {
            var solved = this.boardBruteForceSolver.Solve(new SudokuBoard());
            this.boardReaderInstance.Input = EmptyPuzzleSolution;
            var boardWithSolution = new SudokuBoard();
            this.boardReaderInstance.FillBoard(boardWithSolution);
            Assert.AreEqual(solved, boardWithSolution);
        }

        [TestMethod]
        public void VerifyThatNonEmptyPuzzleIsSolved()
        {
            this.boardReaderInstance.FillBoard(this.boardInstance);
            var solved = this.boardBruteForceSolver.Solve(this.boardInstance);
            this.boardReaderInstance.Input = TestCaseSolution;
            var boardWithSolution = new SudokuBoard();
            this.boardReaderInstance.FillBoard(boardWithSolution);
            Assert.AreEqual(solved, boardWithSolution);
        }
    }
}