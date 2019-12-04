using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public void TestGetNumberOfPasswordsInRange()
        {
            int start = 130254;
            int end = 678275;

            int result = Day04.GetNumberOfPasswordsInRange(start, end);

            Assert.AreEqual(2090, result);
        }

        [TestMethod]
        public void TestGetNumberOfPasswordsInRangePart2()
        {
            int start = 130254;
            int end = 678275;

            int result = Day04.GetNumberOfPasswordsInRange(start, end, true);

            Assert.AreEqual(1419, result);
        }
    }
}