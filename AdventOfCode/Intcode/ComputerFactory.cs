using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Intcode
{
    internal static class ComputerFactory
    {
        public static Computer GetComputer()
        {
            Computer computer = new Computer();
            string text = System.IO.File.ReadAllText(DataHelper.getPath("05"));
            text = "3,9,8,9,10,9,4,9,99,-1,8";
            long[] program = text.Split(',').Select(long.Parse).ToArray();
            computer.LoadProgram(program);
            return computer;
        }
    }
}