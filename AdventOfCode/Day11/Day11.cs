using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Intcode;

namespace AdventOfCode.Day11
{
    internal static class Day11
    {
        public static void Run()
        {
            string text = System.IO.File.ReadAllText(DataHelper.getPath("11"));
            long[] program = text.Split(',').Select(long.Parse).ToArray();

            Drawing drawing = new Drawing();
            drawing.PaintWhite(0, 0);
            Robot robot = new Robot();
            Computer computer = new Computer();
            computer.LoadProgram(program);

            while (computer.GetState() != State.Finished)
            {
                long input = drawing.IsWhite(robot) ? 1 : 0;
                computer.ProvideInput(input);
                computer.ProcessInstructions();
                long output1 = computer.PopOutput();
                long output2 = computer.PopOutput();

                if (output1 == 0)
                {
                    drawing.PaintBlack(robot.x, robot.y);
                }
                if (output1 == 1)
                {
                    drawing.PaintWhite(robot.x, robot.y);
                }

                if (output2 == 0)
                {
                    robot.TurnLeft();
                }
                if (output2 == 1)
                {
                    robot.TurnRight();
                }
                robot.MoveForward();
            }
            drawing.Print();
        }
    }

    public enum Direction { Up = 0, Right, Down, Left };

    public class Robot : Point
    {
        public Direction direction;

        public Robot() : base(0, 0)
        {
            direction = Direction.Up;
        }

        public void TurnLeft()
        {
            direction = (Direction)(((int)direction + 3) % 4);
        }

        public void TurnRight()
        {
            direction = (Direction)(((int)direction + 1) % 4);
        }

        public void MoveForward()
        {
            switch (direction)
            {
                case Direction.Up:
                    y += 1;
                    break;

                case Direction.Down:
                    y -= 1;
                    break;

                case Direction.Left:
                    x -= 1;
                    break;

                case Direction.Right:
                    x += 1;
                    break;
            }
        }
    }

    public class Drawing : Map
    {
        private HashSet<Point> seen;

        public Drawing() : base()
        {
            seen = new HashSet<Point>();
        }

        public bool IsWhite(Point p)
        {
            return HasPoint(p);
        }

        public void PaintBlack(int x, int y)
        {
            Point p = new Point(x, y);
            if (HasPoint(p))
            {
                RemovePoint(p);
            }
        }

        public void PaintWhite(int x, int y)
        {
            Point p = new Point(x, y);

            AddPoint(p);
            seen.Add(p);
        }

        public int Seen()
        {
            return seen.Count();
        }
    }

    public class Map
    {
        private HashSet<Point> points;

        public Map()
        {
            this.points = new HashSet<Point>();
        }

        public void AddPoint(Point p)
        {
            points.Add(p);
        }

        public bool HasPoint(Point p)
        {
            return points.Contains(p);
        }

        public void RemovePoint(Point p)
        {
            points.Remove(p);
        }

        public int Count()
        {
            return points.Count();
        }

        public void Print()
        {
            int minY = points.Select(p => p.y).Min();
            int minX = points.Select(p => p.x).Min();
            int maxY = points.Select(p => p.y).Max();
            int maxX = points.Select(p => p.x).Max();

            StringBuilder sb = new StringBuilder();

            for (int y = maxY; y >= minY; y--)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    sb.Append(HasPoint(new Point(x, y)) ? '\u2588' : ' ');
                }
                sb.Append('\n');
            }
            Console.WriteLine(sb.ToString());
        }
    }

    public class Point : IEquatable<Point>
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Point p)
        {
            return x == p.x && y == p.y;
        }

        public override int GetHashCode()
        {
            return x * 0x00010000 + y;
        }

        public override string ToString()
        {
            return string.Format("<{0},{1}>", x, y);
        }
    }
}