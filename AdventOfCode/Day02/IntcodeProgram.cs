using System;
using System.Linq;

namespace AdventOfCode
{
    public struct IntcodeProgram
    {
        private readonly int[] instructions;

        public IntcodeProgram(string inputString)
        {
            this.instructions = inputString.Split(',').Select(Int32.Parse).ToArray();
        }

        public int ExecuteIntcode()
        {
            int instructionPointer = 0;
            int[] instructions = new int[this.instructions.Length];
            this.instructions.CopyTo(instructions, 0);
            while (true)
            {
                int opCode = instructions[instructionPointer];
                switch (opCode)
                {
                    case 1:
                        instructions[instructions[instructionPointer + 3]] = instructions[instructions[instructionPointer + 1]] + instructions[instructions[instructionPointer + 2]];
                        break;

                    case 2:
                        instructions[instructions[instructionPointer + 3]] = instructions[instructions[instructionPointer + 1]] * instructions[instructions[instructionPointer + 2]];
                        break;

                    case 99:
                        return instructions[0];
                }
                instructionPointer += 4;
            }
        }

        public void SetNounAndVerb(int noun, int verb)
        {
            this.instructions[1] = noun;
            this.instructions[2] = verb;
        }

        public int FindNounAndVerb(int target)
        {
            for (int noun = 1; noun <= 99; noun++)
            {
                for (int verb = 1; verb <= 99; verb++)
                {
                    SetNounAndVerb(noun, verb);
                    int result = ExecuteIntcode();
                    if (result == target)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            return -1;
        }
    }
}