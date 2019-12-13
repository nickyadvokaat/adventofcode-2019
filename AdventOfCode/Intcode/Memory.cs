using System;

namespace AdventOfCode.Intcode
{
    internal class Memory
    {
        private long[] registers;

        private long relativeBase;

        public Memory()
        {
            this.relativeBase = 0;
        }

        public void LoadProgram(long[] program)
        {
            this.registers = program;
            this.relativeBase = 0;
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
            while (index >= this.registers.Length)
            {
                AddBlock();
            }
            return this.registers[index];
        }

        public long Get(long index, Mode mode)
        {
            switch (mode)
            {
                case Mode.Immediate:
                    return Get(index);

                case Mode.Position:
                    return Get(Get(index));

                case Mode.Relative:
                    return Get(Get(index) + relativeBase);

                default:
                    throw new NotImplementedException();
            }
        }

        private void AddBlock()
        {
            int blockSize = 1024;
            int l = this.registers.Length;
            Array.Resize(ref this.registers, this.registers.Length + blockSize);
            for (int i = l; i < l + blockSize; i++)
            {
                this.registers[i] = 0;
            }
        }

        public void AdjustRB(long value)
        {
            this.relativeBase += value;
        }

        public long getRB()
        {
            return this.relativeBase;
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