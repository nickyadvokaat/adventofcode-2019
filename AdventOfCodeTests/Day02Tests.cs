using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void TestDay02()
        {
            Assert.AreEqual(Day02.executeIntcode(new[] { 2, 4, 4, 5, 99, 0 }), 2, "Incorrect value at position 0");
            Assert.AreEqual(Day02.executeIntcode(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }), 30, "Incorrect value at position 0");
        }
    }
}
