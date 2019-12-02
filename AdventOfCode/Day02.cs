using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public static class Day02
    {
        public static void run()
        {
            int[] program;

            // part 1
            program = getProgramFromFile();
            program[1] = 12;
            program[2] = 2;
            int result1 = executeIntcode(program);
            Console.WriteLine("result: " + result1);

            // part 2
            program = getProgramFromFile();
            int result2 = findNounAndVerb(program);
            Console.WriteLine("result: " + result2);
        }

        public static int executeIntcode(int[] program)
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

        private static int findNounAndVerb(int[] p)
        {
            for (int noun = 1; noun <= 99; noun++)
            {
                for (int verb = 1; verb <= 99; verb++)
                {

                    int[] program = new int[p.Length];
                    p.CopyTo(program, 0);
                    program[1] = noun;
                    program[2] = verb;
                    int result = executeIntcode(program);
                    if (result == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            return -1;
        }

        private static int[] getProgramFromFile()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\ncim\source\repos\AdventOfCode\AdventOfCode\data\data02.txt");
            return text.Split(','). Select(Int32.Parse).ToArray();
        }
    }
}
