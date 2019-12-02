using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Day01
    {
        public static void run()
        {
            int[] masses = getMassesFromFile();

            // part 1
            int resultPart1 = calculateTotalRequiredFuel(masses);
            Console.WriteLine("Result part 1: " + resultPart1);

            // part 2
            int resultPart2 = calculateTotalRequiredFuel(masses, true);
            Console.WriteLine("Result part 2: " + resultPart2);
        }

        public static int calculateTotalRequiredFuel(int[] masses, bool includingAddedFuel = false)
        {
            int totalRequiredFuel = 0;
            foreach (int mass in masses)
            {
                totalRequiredFuel += includingAddedFuel ? calculateRequiredFuelIncludingAddedFuel(mass) : calculateRequiredFuel(mass);
            }
            return totalRequiredFuel;
        }

        private static int[] getMassesFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ncim\source\repos\AdventOfCode\AdventOfCode\data\data01.txt");
            int[] masses = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                masses[i] = int.Parse(lines[i]);
            }
            return masses;
        }

        private static int calculateRequiredFuelIncludingAddedFuel(int mass)
        {
            int requiredFuel = calculateRequiredFuel(mass);
            return requiredFuel <= 0 ? 0 : requiredFuel + calculateRequiredFuelIncludingAddedFuel(requiredFuel);
        }

        private static int calculateRequiredFuel(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}
