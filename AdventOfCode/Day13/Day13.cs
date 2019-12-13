using AdventOfCode.Intcode;
using System;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day13
{
    public static class Day13
    {
        public static void Run()
        {
            string text = System.IO.File.ReadAllText(DataHelper.getPath("13"));
            long[] program = text.Split(',').Select(long.Parse).ToArray();

            Computer computer = new Computer();
            computer.LoadProgram(program);
            while (!computer.IsFinished())
            {
                computer.ProcessInstructions();
                computer.ProvideInput(JoystickPosition(computer));
            }
        }

        private static int JoystickPosition(Computer computer)
        {
            long ballX = 0;
            long paddleX = 0;
            while (computer.HasOutput())
            {
                long x = computer.PopOutput();
                computer.PopOutput();
                Tile tile = (Tile)computer.PopOutput();
                if (x == -1)
                {
                    Console.WriteLine("Score: {0}", tile);
                }
                if (tile == Tile.Paddle)
                {
                    paddleX = x;
                }
                if (tile == Tile.Ball)
                {
                    ballX = x;
                }
            }
            return ballX.CompareTo(paddleX);
        }

        private enum Tile { Empty = 0, Wall, Block, Paddle, Ball }

        private static void PrintOutput(Computer computer)
        {
            int i = 0;
            long[,] view = new long[45, 25];
            while (computer.HasOutput())
            {
                long x = computer.PopOutput();
                long y = computer.PopOutput();
                long t = computer.PopOutput();

                if (x == -1 && y == 0)
                {
                    Console.WriteLine("Score: {0}", t);
                }
                else
                {
                    view[x, y] = t;
                    i++;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < 21; y++)
            {
                for (int x = 0; x < 45; x++)
                {
                    Tile g = (Tile)view[x, y];
                    switch (g)
                    {
                        case Tile.Empty:
                            sb.Append(' ');
                            break;

                        case Tile.Ball:
                            sb.Append('o');
                            break;

                        default:
                            sb.Append('\u2588');
                            break;
                    }
                }
                sb.Append('\n');
            }
            Console.Write(sb.ToString());
        }
    }
}