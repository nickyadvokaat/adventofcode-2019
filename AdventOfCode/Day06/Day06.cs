using System;

namespace AdventOfCode
{
    internal static class Day06
    {
        public static void Run()
        {
            Space space = SpaceFactory.Bigbang("06");

            int numberOfDirectAndIndirectOrbits = space.NumberOfDirectAndIndirectOrbits();
            int numberOfOrbitalTransfersRequired = space.NumberOfOrbitalTransfersRequired();

            Console.WriteLine("#orbits: {0}, #transfers: {1}", numberOfDirectAndIndirectOrbits, numberOfOrbitalTransfersRequired);
        }
    }
}