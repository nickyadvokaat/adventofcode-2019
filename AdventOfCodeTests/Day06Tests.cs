using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public void TestNumberOfDirectAndIndirectOrbits1()
        {
            Space space = SpaceFactory.Bigbang("06-test");

            int result = space.NumberOfDirectAndIndirectOrbits();

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void TestNumberOfDirectAndIndirectOrbits2()
        {
            Space space = SpaceFactory.Bigbang("06");

            int result = space.NumberOfDirectAndIndirectOrbits();

            Assert.AreEqual(453028, result);
        }

        [TestMethod]
        public void TestNumberOfOrbitalTransfersRequired1()
        {
            Space space = SpaceFactory.Bigbang("06-test-2");

            int result = space.NumberOfOrbitalTransfersRequired();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestNumberOfOrbitalTransfersRequired2()
        {
            Space space = SpaceFactory.Bigbang("06");

            int result = space.NumberOfOrbitalTransfersRequired();

            Assert.AreEqual(562, result);
        }
    }
}