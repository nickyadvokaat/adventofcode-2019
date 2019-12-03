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
            int result = getDistanceToClosestIntersection(new List<string> { lines[0], lines[1] });
            Console.WriteLine("Result part 1: " + result);
        }

        public static int getDistanceToClosestIntersection(List<string> wireStrings)
        {
            List<WirePath> wirePaths = wireStrings.Select(w => new WirePath(w)).ToList();
            return getDistanceToClosestIntersection(wirePaths);
        }

        private static int getDistanceToClosestIntersection(List<WirePath> wirePaths)
        {
            var intersectionCoordinates = getIntersectionCoordinates(wirePaths);
            return intersectionCoordinates.Select(c => c.ManhattanDistance()).Min();
        }

        private static List<Coordinate> getIntersectionCoordinates(List<WirePath> wirePaths)
        {
            Coordinate[] coordinatesA = wirePaths.ElementAt(0).getCoordinatesOnWirePath();
            Coordinate[] coordinatesB = wirePaths.ElementAt(1).getCoordinatesOnWirePath();

            List<Coordinate> intersections = new List<Coordinate>();

            foreach (Coordinate c1 in coordinatesA)
            {
                foreach (Coordinate c2 in coordinatesB)
                {
                    if (c1.Equals(c2))
                    {
                        intersections.Add(c1);
                    }
                }
            }

            return intersections;
        }
    }
}