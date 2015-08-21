namespace SudokuSolverTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SudokuSolver;

    [TestClass]
    public class SudokuClassTest
    {
        private const string TestString = "002008050000040070480072000008000031600080005570000600000960048090020000030800900";

        private readonly StringBoardReaderStrategy boardReaderStrategy;

        private readonly SudokuBoard boardInstance;

        public SudokuClassTest()
        {
            this.boardReaderStrategy = new StringBoardReaderStrategy(TestString);
            this.boardInstance = new SudokuBoard(this.boardReaderStrategy);
        }

        [TestMethod]
        public void Init()
        {
            Assert.IsInstanceOfType(new SudokuBoard(this.boardReaderStrategy), typeof(SudokuBoard));
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
    }
}
