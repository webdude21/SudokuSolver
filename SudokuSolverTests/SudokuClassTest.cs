namespace SudokuSolverTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SudokuSolver;

    [TestClass]
    public class SudokuClassTest
    {
        private readonly SudokuBoard validBoardWith9Places = new SudokuBoard();

        [TestMethod]
        public void Init()
        {
            Assert.IsInstanceOfType(new SudokuBoard(), typeof(SudokuBoard));
            Assert.IsInstanceOfType(new SudokuBoard(240), typeof(SudokuBoard));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
             "Expecting exception when the value is larger than the board size")]
        public void SettingValuesToBoard()
        {
            this.validBoardWith9Places[1, 1] = 10;
        }

        [TestMethod]
        public void SettingValidValueCanBeRetrievedLater()
        {
            byte valueToSet = 2;
            this.validBoardWith9Places[1, 1] = valueToSet;
            Assert.AreEqual(this.validBoardWith9Places[1, 1], valueToSet);
        }
    }
}
