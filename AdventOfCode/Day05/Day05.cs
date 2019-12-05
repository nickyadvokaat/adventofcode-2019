using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day05
    {
        public static void Run()
        {
            IntcodeProgram intcodeProgram;

            // part 1
            intcodeProgram = GetProgramFromFile();
            int result1 = intcodeProgram.ExecuteIntcode(1).outputs.Last();
            Console.WriteLine("result part 1: " + result1);

            // part 2
            intcodeProgram = GetProgramFromFile();
            int result2 = intcodeProgram.ExecuteIntcode(5).outputs.Last();
            Console.WriteLine("result part 2: " + result2);
        }

        private static IntcodeProgram GetProgramFromFile()
        {
            string text = System.IO.File.ReadAllText(DataHelper.getPath("05"));
            return new IntcodeProgram(text);
        }
    }
}