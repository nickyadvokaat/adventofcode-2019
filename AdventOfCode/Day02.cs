using System;
using System.Linq;

namespace AdventOfCode
{
    public static class Day02
    {
        public static void Run()
        {
            int[] program;

            // part 1
            program = GetProgramFromFile();
            program[1] = 12;
            program[2] = 2;
            int result1 = ExecuteIntcode(program);
            Console.WriteLine("result: " + result1);

            // part 2
            program = GetProgramFromFile();
            int result2 = FindNounAndVerb(program);
            Console.WriteLine("result: " + result2);
        }

        public static int ExecuteIntcode(int[] program)
        {
            int instructionPointer = 0;
            while (true)
            {
                int opCode = program[instructionPointer];
                switch (opCode)
                {
                    case 1:
                        program[program[instructionPointer + 3]] = program[program[instructionPointer + 1]] + program[program[instructionPointer + 2]];
                        break;

                    case 2:
                        program[program[instructionPointer + 3]] = program[program[instructionPointer + 1]] * program[program[instructionPointer + 2]];
                        break;

                    case 99:
                        return program[0];
                }
                instructionPointer += 4;
            }
        }

        private static int FindNounAndVerb(int[] p)
        {
            for (int noun = 1; noun <= 99; noun++)
            {
                for (int verb = 1; verb <= 99; verb++)
                {
                    int[] program = new int[p.Length];
                    p.CopyTo(program, 0);
                    program[1] = noun;
                    program[2] = verb;
                    int result = ExecuteIntcode(program);
                    if (result == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            return -1;
        }

        private static int[] GetProgramFromFile()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\ncim\source\repos\AdventOfCode\AdventOfCode\data\data02.txt");
            return text.Split(',').Select(Int32.Parse).ToArray();
        }
    }
}