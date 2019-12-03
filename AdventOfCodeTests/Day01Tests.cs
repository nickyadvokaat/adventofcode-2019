using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void TestCalculateRequiredFuel()
        {
            var masses = new List<int> { 12, 14, 1969 };

            int result = Day01.CalculateRequiredFuel(masses);

            Assert.AreEqual(658, result);
        }

        [TestMethod]
        public void TestCalculateRequiredFuelIncludingAddedFuel()
        {
            var masses = new List<int> { 12, 14, 1969 };

            int result = Day01.CalculateRequiredFuelIncludingAddedFuel(masses);

            Assert.AreEqual(970, result);
        }
    }
}