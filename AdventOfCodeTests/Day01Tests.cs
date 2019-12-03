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
            Assert.AreEqual(658, Day01.CalculateTotalRequiredFuel(new[] { 12, 14, 1969 }), "Incorrect required fuel amount");
            Assert.AreEqual(970, Day01.CalculateTotalRequiredFuel(new[] { 12, 14, 1969 }, true), "Incorrect required fuel amount");
        }
    }
}