using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public void TestSpaceSmall()
        {
            Space space = SpaceFactory.Bigbang("06-test");

            int result = space.NumberOfDirectAndIndirectOrbits();

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void TestSpaceLarge()
        {
            Space space = SpaceFactory.Bigbang("06");

            int result = space.NumberOfDirectAndIndirectOrbits();

            Assert.AreEqual(453028, result);
        }
    }
}