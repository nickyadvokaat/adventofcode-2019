using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Intcode
{
    internal class Memory
    {
        private long[] registers;

        public Memory()
        {
        }

        public void LoadProgram(long[] program)
        {
            this.registers = program;
        }

        public void Set(long index, long value)
        {
            while (index >= this.registers.Length)
            {
                AddBlock();
            }
            this.registers[index] = value;
        }

        public long Get(long index)
        {
            return this.registers[index];
        }

        public long Get(long index, Mode mode)
        {
            return mode == Mode.Immediate ? Get(index) : Get(Get(index));
        }

        private void AddBlock()
        {
            Array.Resize(ref this.registers, this.registers.Length + 100);
        }

        public void Print()
        {
            foreach (long l in registers)
            {
                Console.Write(",{0}", l);
            }
            Console.WriteLine();
        }
    }
}