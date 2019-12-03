using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day03
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ncim\source\repos\AdventOfCode\AdventOfCode\data\data03.txt");
            int distanceToClosestIntersection = getDistanceToClosestIntersection(new List<string> { lines[0], lines[1] });
            Console.WriteLine("Result part 1: " + distanceToClosestIntersection);
            int fewestCombinedStepsToIntersection = getFewestCombinedStepsToIntersection(new List<string> { lines[0], lines[1] });
            Console.WriteLine("Result part 2: " + fewestCombinedStepsToIntersection);
        }

        public static int getDistanceToClosestIntersection(List<string> wireStrings)
        {
            List<WirePath> wirePaths = wireStrings.Select(w => new WirePath(w)).ToList();
            return getDistanceToClosestIntersection(wirePaths);
        }

        private static int getDistanceToClosestIntersection(List<WirePath> wirePaths)
        {
            var intersections = getIntersectionCoordinates(wirePaths);
            return intersections.Select(c => c.coordinate.ManhattanDistance()).Min();
        }

        public static int getFewestCombinedStepsToIntersection(List<string> wireStrings)
        {
            List<WirePath> wirePaths = wireStrings.Select(w => new WirePath(w)).ToList();
            return getFewestCombinedStepsToIntersection(wirePaths);
        }

        private static int getFewestCombinedStepsToIntersection(List<WirePath> wirePaths)
        {
            var intersections = getIntersectionCoordinates(wirePaths);
            return intersections.Select(c => c.combinedNumberOfSteps).Min();
        }

        private static List<Intersection> getIntersectionCoordinates(List<WirePath> wirePaths)
        {
            Coordinate[] coordinatesA = wirePaths.ElementAt(0).getCoordinatesOnWirePath();
            Coordinate[] coordinatesB = wirePaths.ElementAt(1).getCoordinatesOnWirePath();

            List<Intersection> intersections = new List<Intersection>();

            foreach (Coordinate c1 in coordinatesA)
            {
                foreach (Coordinate c2 in coordinatesB)
                {
                    if (c1.Equals(c2))
                    {
                        intersections.Add(new Intersection(c1, c2));
                    }
                }
            }

            return intersections;
        }
    }

    internal struct Intersection
    {
        public readonly Coordinate coordinate;
        public readonly int combinedNumberOfSteps;

        public Intersection(Coordinate coordinateA, Coordinate coordinateB)
        {
            this.coordinate = coordinateA;
            this.combinedNumberOfSteps = coordinateA.stepNumber + coordinateB.stepNumber;
        }
    }
}