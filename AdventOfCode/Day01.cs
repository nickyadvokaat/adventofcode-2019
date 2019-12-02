using System;

namespace AdventOfCode
{
    public static class Day01
    {
        public static void Run()
        {
            int[] masses = GetMassesFromFile();

            // part 1
            int resultPart1 = CalculateTotalRequiredFuel(masses);
            Console.WriteLine("Result part 1: " + resultPart1);

            // part 2
            int resultPart2 = CalculateTotalRequiredFuel(masses, true);
            Console.WriteLine("Result part 2: " + resultPart2);
        }

        public static int CalculateTotalRequiredFuel(int[] masses, bool includingAddedFuel = false)
        {
            int totalRequiredFuel = 0;
            foreach (int mass in masses)
            {
                totalRequiredFuel += includingAddedFuel ? CalculateRequiredFuelIncludingAddedFuel(mass) : CalculateRequiredFuel(mass);
            }
            return totalRequiredFuel;
        }

        private static int[] GetMassesFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ncim\source\repos\AdventOfCode\AdventOfCode\data\data01.txt");
            int[] masses = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                masses[i] = int.Parse(lines[i]);
            }
            return masses;
        }

        private static int CalculateRequiredFuelIncludingAddedFuel(int mass)
        {
            int requiredFuel = CalculateRequiredFuel(mass);
            return requiredFuel <= 0 ? 0 : requiredFuel + CalculateRequiredFuelIncludingAddedFuel(requiredFuel);
        }

        private static int CalculateRequiredFuel(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}