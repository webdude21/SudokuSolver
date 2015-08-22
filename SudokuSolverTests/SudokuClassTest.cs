namespace SudokuSolverTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SudokuSolver;

    [TestClass]
    public class SudokuClassTest
    {
        private const string TestString = "002008050000040070480072000008000031600080005570000600000960048090020000030800900";

        private readonly SudokuBoard boardInstance;

        private readonly BruteForceSudokuSolver boardBruteForceSolver;

        public SudokuClassTest()
        {
            new StringBoardReaderStrategy(TestString);
            this.boardInstance = new SudokuBoard();
            this.boardBruteForceSolver = new BruteForceSudokuSolver(this.boardInstance);
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
            byte valueToSet = 2;
            this.boardInstance[1, 1] = valueToSet;
            Assert.AreEqual(this.boardInstance[1, 1], valueToSet);
        }

        [TestMethod]
        public void TryToSolve()
        {
            var solved = this.boardBruteForceSolver.Solve();
        }
    }
}
