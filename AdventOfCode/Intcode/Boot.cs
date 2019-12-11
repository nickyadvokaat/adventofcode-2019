using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Intcode
{
    internal static class Boot
    {
        public static void Run()
        {
            string text = System.IO.File.ReadAllText(DataHelper.getPath("05"));
            //text = "3,3,1107,-1,8,3,4,3,99";
            long[] program = text.Split(',').Select(long.Parse).ToArray();

            Computer computer = new Computer();
            computer.LoadProgram(program);
            computer.ProvideInput(5);
            computer.ProcessInstructions();
            computer.PrintOutput();
        }
    }
}