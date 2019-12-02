using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void TestDay01TotalRequiredFuel()
        {
            Assert.AreEqual(Day01.CalculateTotalRequiredFuel(new[] { 12, 14, 1969 }), 658, "Incorrect required fuel amount");
            Assert.AreEqual(Day01.CalculateTotalRequiredFuel(new[] { 12, 14, 1969 }, true), 970, "Incorrect required fuel amount");
        }
    }
}