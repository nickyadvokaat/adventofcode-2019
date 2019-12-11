using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Intcode
{
    internal enum Mode
    { Position = 0, Immediate = 1 };

    internal class Computer
    {
        private enum State
        { Ready, Running, AwaitingInput, Finished };

        private enum Opcode { Add = 1, Mult = 2, Input = 3, Output = 4, True = 5, False = 6, Less = 7, Equals = 8, End = 99 };

        private Queue<long> inputQueue;
        private Queue<long> outputQueue;
        private Memory memory;
        private State state;
        private long IP;

        public Computer()
        {
            this.memory = new Memory();
            this.inputQueue = new Queue<long>();
            this.outputQueue = new Queue<long>();
        }

        public void LoadProgram(long[] program)
        {
            this.memory.LoadProgram(program);
            this.IP = 0;
            this.state = State.Ready;
        }

        public void ProvideInput(long input)
        {
            inputQueue.Enqueue(input);
        }

        public void ProcessInstructions()
        {
            state = State.Running;
            while (state == State.Running)
            {
                ProcessNextInstruction();
            }
        }

        public long Test()
        {
            return memory.Get(0);
        }

        private void ProcessNextInstruction()
        {
            //memory.Print();

            long instruction = memory.Get(IP);
            Opcode opcode = (Opcode)(instruction % 100);
            Mode C = (Mode)((instruction % 1000) / 100);
            Mode B = (Mode)((instruction % 10000) / 1000);
            Mode A = (Mode)(instruction / 10000);

            switch (opcode)
            {
                case Opcode.Add:
                    long value1 = memory.Get(IP + 1, C);
                    long value2 = memory.Get(IP + 2, B);
                    //long index = memory.Get(IP + 3, A);
                    long index = memory.Get(IP + 3);
                    memory.Set(index, value1 + value2);
                    IP += 4;
                    break;

                case Opcode.Mult:
                    value1 = memory.Get(IP + 1, C);
                    value2 = memory.Get(IP + 2, B);
                    //index = memory.Get(IP + 3, A);
                    index = memory.Get(IP + 3);
                    memory.Set(index, value1 * value2);
                    IP += 4;
                    break;

                case Opcode.Input:
                    if (inputQueue.Count > 0)
                    {
                        //
                        index = memory.Get(IP + 1);
                        memory.Set(index, inputQueue.Dequeue());
                        IP += 2;
                    }
                    else
                    {
                        state = State.AwaitingInput;
                    }
                    break;

                case Opcode.Output:
                    long value = memory.Get(IP + 1, C);
                    outputQueue.Enqueue(value);
                    IP += 2;
                    break;

                case Opcode.True:
                    value1 = memory.Get(IP + 1, C);
                    value2 = memory.Get(IP + 2, B);

                    if (value1 != 0)
                    {
                        IP = value2;
                    }
                    else
                    {
                        IP += 3;
                    }
                    break;

                case Opcode.False:
                    value1 = memory.Get(IP + 1, C);
                    value2 = memory.Get(IP + 2, B);

                    if (value1 == 0)
                    {
                        IP = value2;
                    }
                    else
                    {
                        IP += 3;
                    }
                    break;

                case Opcode.Less:
                    value1 = memory.Get(IP + 1, C);
                    value2 = memory.Get(IP + 2, B);
                    index = memory.Get(IP + 3);
                    long result = value1 < value2 ? 1 : 0;
                    memory.Set(index, result);
                    IP += 4;
                    break;

                case Opcode.Equals:
                    value1 = memory.Get(IP + 1, C);
                    value2 = memory.Get(IP + 2, B);
                    index = memory.Get(IP + 3);
                    result = value1 == value2 ? 1 : 0;
                    memory.Set(index, result);
                    IP += 4;
                    break;

                case Opcode.End:
                    state = State.Finished;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public void PrintOutput()
        {
            while (outputQueue.Count > 0)
            {
                Console.WriteLine(outputQueue.Dequeue());
            }
        }
    }
}