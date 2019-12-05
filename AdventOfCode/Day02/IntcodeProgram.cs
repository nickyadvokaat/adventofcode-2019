using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public struct IntcodeProgramResult
    {
        public int position0;
        public List<int> outputs;

        public static IntcodeProgramResult Init()
        {
            IntcodeProgramResult i = new IntcodeProgramResult();
            i.position0 = 0;
            i.outputs = new List<int>();
            return i;
        }
    }

    public struct IntcodeProgram
    {
        private readonly int[] instructions;

        public IntcodeProgram(string inputString)
        {
            this.instructions = inputString.Split(',').Select(Int32.Parse).ToArray();
        }

        public IntcodeProgramResult ExecuteIntcode(int input = 0)
        {
            IntcodeProgramResult result = IntcodeProgramResult.Init();

            int instructionPointer = 0;
            int[] instructions = new int[this.instructions.Length];
            this.instructions.CopyTo(instructions, 0);
            while (true)
            {
                string s = instructions[instructionPointer].ToString();
                int DE = 0;
                int C = 0;
                int B = 0;
                int A = 0;

                switch (s.Length)
                {
                    case 1:
                        DE = int.Parse(s);
                        break;

                    case 2:
                        DE = int.Parse(s);
                        break;

                    case 3:
                        DE = int.Parse(s.Substring(1, 2));
                        C = int.Parse(s.Substring(0, 1));
                        break;

                    case 4:
                        DE = int.Parse(s.Substring(2, 2));
                        C = int.Parse(s.Substring(1, 1));
                        B = int.Parse(s.Substring(0, 1));
                        break;

                    case 5:
                        DE = int.Parse(s.Substring(3, 2));
                        C = int.Parse(s.Substring(2, 1));
                        B = int.Parse(s.Substring(1, 1));
                        A = int.Parse(s.Substring(0, 1));
                        break;
                }
                int instructionPointerSteps = 0;
                switch (DE)
                {
                    case 1:
                        int valueA = C == 0 ? instructions[instructions[instructionPointer + 1]] : instructions[instructionPointer + 1];
                        int valueB = B == 0 ? instructions[instructions[instructionPointer + 2]] : instructions[instructionPointer + 2];
                        instructions[instructions[instructionPointer + 3]] = valueA + valueB;
                        instructionPointerSteps = 4;
                        break;

                    case 2:
                        valueA = C == 0 ? instructions[instructions[instructionPointer + 1]] : instructions[instructionPointer + 1];
                        valueB = B == 0 ? instructions[instructions[instructionPointer + 2]] : instructions[instructionPointer + 2];
                        instructions[instructions[instructionPointer + 3]] = valueA * valueB;
                        instructionPointerSteps = 4;
                        break;

                    case 3:
                        int index = C == 0 ? instructions[instructionPointer + 1] : instructionPointer + 1;
                        instructions[index] = input;
                        instructionPointerSteps = 2;
                        break;

                    case 4:
                        index = C == 0 ? instructions[instructionPointer + 1] : instructionPointer + 1;
                        result.outputs.Add(instructions[index]);
                        instructionPointerSteps = 2;
                        break;

                    case 5:
                        valueA = C == 0 ? instructions[instructions[instructionPointer + 1]] : instructions[instructionPointer + 1];
                        valueB = B == 0 ? instructions[instructions[instructionPointer + 2]] : instructions[instructionPointer + 2];

                        if (valueA != 0)
                        {
                            instructionPointer = valueB;
                        }
                        else
                        {
                            instructionPointerSteps = 3;
                        }

                        break;

                    case 6:
                        valueA = C == 0 ? instructions[instructions[instructionPointer + 1]] : instructions[instructionPointer + 1];
                        valueB = B == 0 ? instructions[instructions[instructionPointer + 2]] : instructions[instructionPointer + 2];

                        if (valueA == 0)
                        {
                            instructionPointer = valueB;
                        }
                        else
                        {
                            instructionPointerSteps = 3;
                        }

                        break;

                    case 7:
                        valueA = C == 0 ? instructions[instructions[instructionPointer + 1]] : instructions[instructionPointer + 1];
                        valueB = B == 0 ? instructions[instructions[instructionPointer + 2]] : instructions[instructionPointer + 2];
                        instructions[instructions[instructionPointer + 3]] = (valueA < valueB) ? 1 : 0;
                        instructionPointerSteps = 4;
                        break;

                    case 8:
                        valueA = C == 0 ? instructions[instructions[instructionPointer + 1]] : instructions[instructionPointer + 1];
                        valueB = B == 0 ? instructions[instructions[instructionPointer + 2]] : instructions[instructionPointer + 2];
                        instructions[instructions[instructionPointer + 3]] = (valueA == valueB) ? 1 : 0;
                        instructionPointerSteps = 4;
                        break;

                    case 99:
                        result.position0 = instructions[0];
                        return result;
                }
                instructionPointer += instructionPointerSteps;
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
                    int result = ExecuteIntcode().position0;
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