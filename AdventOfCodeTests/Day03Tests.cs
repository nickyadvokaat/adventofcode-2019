﻿using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public void TestGetDistanceToClosestIntersection_1()
        {
            List<string> wireStrings = new List<string> {
                "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                "U62,R66,U55,R34,D71,R55,D58,R83"
            };

            int distanceToClosestIntersection = Day03.getDistanceToClosestIntersection(wireStrings);

            Assert.AreEqual(159, distanceToClosestIntersection);
        }

        [TestMethod]
        public void TestGetDistanceToClosestIntersection_2()
        {
            List<string> wireStrings = new List<string> {
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"
            };

            int distanceToClosestIntersection = Day03.getDistanceToClosestIntersection(wireStrings);

            Assert.AreEqual(135, distanceToClosestIntersection);
        }

        [TestMethod]
        public void TestGetFewestCombinedStepsToIntersection_1()
        {
            List<string> wireStrings = new List<string> {
                "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                "U62,R66,U55,R34,D71,R55,D58,R83"
            };

            int fewestStepToIntersection = Day03.getFewestCombinedStepsToIntersection(wireStrings);

            Assert.AreEqual(610, fewestStepToIntersection);
        }

        [TestMethod]
        public void TestGetFewestCombinedStepsToIntersection_2()
        {
            List<string> wireStrings = new List<string> {
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"
            };

            int fewestStepToIntersection = Day03.getFewestCombinedStepsToIntersection(wireStrings);

            Assert.AreEqual(410, fewestStepToIntersection);
        }
    }
}