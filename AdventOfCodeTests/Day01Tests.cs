using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void TestDay01TotalRequiredFuel()
        {
            Assert.AreEqual(Day01.calculateTotalRequiredFuel(new[] { 12, 14, 1969 }), 658, "Incorrect required fuel amount");
            Assert.AreEqual(Day01.calculateTotalRequiredFuel(new[] { 12, 14, 1969 }, true), 970, "Incorrect required fuel amount");
        }
    }
}
