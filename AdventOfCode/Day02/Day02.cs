using System;
using System.Linq;

namespace AdventOfCode
{
    public static class Day02
    {
        public static void Run()
        {
            IntcodeProgram intcodeProgram;

            // part 1
            intcodeProgram = GetProgramFromFile();
            intcodeProgram.SetNounAndVerb(12, 2);
            int result1 = intcodeProgram.ExecuteIntcode();
            Console.WriteLine("result part 1: " + result1);

            // part 2
            intcodeProgram = GetProgramFromFile();
            int result2 = intcodeProgram.FindNounAndVerb(19690720);
            Console.WriteLine("result part 2: " + result2);
        }

        private static IntcodeProgram GetProgramFromFile()
        {
            string text = System.IO.File.ReadAllText(DataHelper.getPath("02"));
            return new IntcodeProgram(text);
        }
    }
}