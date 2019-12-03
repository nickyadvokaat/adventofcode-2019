using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void TestExecuteIntcode_1()
        {
            int[] intCode = { 2, 4, 4, 5, 99, 0 };

            int result = Day02.ExecuteIntcode(intCode);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestExecuteIntcode_2()
        {
            int[] intCode = { 1, 1, 1, 4, 99, 5, 6, 0, 99 };

            int result = Day02.ExecuteIntcode(intCode);

            Assert.AreEqual(30, result);
        }
    }
}