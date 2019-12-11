using System.Linq;

namespace AdventOfCode.Intcode
{
    internal static class Boot
    {
        public static void Run()
        {
            string text = System.IO.File.ReadAllText(DataHelper.getPath("09"));
            long[] program = text.Split(',').Select(long.Parse).ToArray();

            Computer computer = new Computer();
            computer.LoadProgram(program);
            computer.ProvideInput(2);
            computer.ProcessInstructions();
            computer.PrintOutput();
        }
    }
}