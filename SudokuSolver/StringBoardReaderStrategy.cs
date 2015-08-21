namespace SudokuSolver
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class StringBoardReaderStrategy : IBoardReaderStrategy
    {
        private readonly string input;

        public StringBoardReaderStrategy(string input)
        {
            this.input = input;
        }

        public int Length => this.input.Length;

        IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
        {
            return this.input.Select(chr => (byte)(chr - '0')).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this.input.Select(chr => (byte)(chr - '0')).GetEnumerator();
        }
    }
}
