using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    internal static class Day10
    {
        public static void Run()
        {
            AsteroidMap map = AsteroidMapFactory.CreateAsteroidMap("10");

            Console.WriteLine("Result part1: {0}", map.MaxNumberOfVisibleAsteroids());
            Console.WriteLine("Result part2: {0}", map.AsteroidVaporizedAt200());
        }
    }
}