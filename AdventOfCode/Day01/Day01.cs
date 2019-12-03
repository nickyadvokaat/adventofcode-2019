using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day01
    {
        public static void Run()
        {
            var masses = GetMassesFromFile();

            // part 1
            int resultPart1 = CalculateRequiredFuel(masses);
            Console.WriteLine("Result part 1: " + resultPart1);

            // part 2
            int resultPart2 = CalculateRequiredFuelIncludingAddedFuel(masses);
            Console.WriteLine("Result part 2: " + resultPart2);
        }

        public static int CalculateRequiredFuel(List<int> masses)
        {
            return masses.Select(m => CalculateRequiredFuel(m)).Sum();
        }

        public static int CalculateRequiredFuelIncludingAddedFuel(List<int> masses)
        {
            return masses.Select(m => CalculateRequiredFuelIncludingAddedFuel(m)).Sum();
        }

        private static int CalculateRequiredFuelIncludingAddedFuel(int mass)
        {
            int requiredFuel = CalculateRequiredFuel(mass);
            return requiredFuel > 0 ? requiredFuel + CalculateRequiredFuelIncludingAddedFuel(requiredFuel) : 0;
        }

        private static int CalculateRequiredFuel(int mass)
        {
            return (mass / 3) - 2;
        }

        private static List<int> GetMassesFromFile()
        {
            var lines = System.IO.File.ReadAllLines(DataHelper.getPath("01")).ToList();
            return lines.Select(l => int.Parse(l)).ToList();
        }
    }
}