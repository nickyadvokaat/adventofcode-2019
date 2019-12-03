using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Day03
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ncim\source\repos\AdventOfCode\AdventOfCode\data\data03.txt");
            string lineA = lines[0];
            string lineB = lines[1];

            // lineA = "R8,U5,L5,D3";
            // lineB = "U7,R6,D4,L4";

            WirePath a = new WirePath(lineA);
            WirePath b = new WirePath(lineB);

            Coordinate c = getDistanceToClosestIntersection(a, b);

            //Console.WriteLine("Solution: " + c.ToString());
        }

        public static Coordinate getDistanceToClosestIntersection(WirePath a, WirePath b)
        {
            //Console.WriteLine(a.ToString());
            //Console.WriteLine(b.ToString());

            Coordinate[] coordinatesA = a.getCoordinatesOnWirePath();
            Coordinate[] coordinatesB = b.getCoordinatesOnWirePath();

            List<Coordinate> intersections = new List<Coordinate>();

            foreach (Coordinate c1 in coordinatesA)
            {
                foreach (Coordinate c2 in coordinatesB)
                {
                    if (c1.Equals(c2))
                    {
                        intersections.Add(c1);
                    }
                }
            }

            int shortestDistance = int.MaxValue;
            foreach (Coordinate solution in intersections)
            {
                shortestDistance = Math.Min(shortestDistance, solution.ManhattanDistance());
            }
            Console.WriteLine(shortestDistance);

            return new Coordinate(0, 0);
        }
    }

    public enum Direction { Up, Down, Left, Right };

    internal static class DirectionExtensions
    {
        public static Direction FromChar(char input)
        {
            switch (input)
            {
                case 'U':
                    return Direction.Up;

                case 'D':
                    return Direction.Down;

                case 'L':
                    return Direction.Left;

                case 'R':
                    return Direction.Right;

                default:
                    return Direction.Up;
            }
        }

        public static string EnumValue(this Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return "U";

                case Direction.Down:
                    return "D";

                case Direction.Left:
                    return "L";

                case Direction.Right:
                    return "R";

                default:
                    return "";
            }
        }
    }

    public class WirePath
    {
        private WirePathStep[] wirePathSteps;

        public WirePath(string input)
        {
            string[] wirePathStepStrings = input.Split(",");
            this.wirePathSteps = new WirePathStep[wirePathStepStrings.Length];
            for (int i = 0; i < wirePathStepStrings.Length; i++)
            {
                this.wirePathSteps[i] = new WirePathStep(wirePathStepStrings[i]);
            }
        }

        public Coordinate[] getCoordinatesOnWirePath()
        {
            List<Coordinate> c = new List<Coordinate>();

            Coordinate currentPosition = new Coordinate(0, 0);
            foreach (WirePathStep wirePathStep in this.wirePathSteps)
            {
                int x = wirePathStep.stepLength;
                while (x > 0)
                {
                    switch (wirePathStep.direction)
                    {
                        case Direction.Up:
                            currentPosition.y += 1;
                            break;

                        case Direction.Down:
                            currentPosition.y -= 1;
                            break;

                        case Direction.Left:
                            currentPosition.x -= 1;
                            break;

                        case Direction.Right:
                            currentPosition.x += 1;
                            break;
                    }
                    x -= 1;
                    c.Add(currentPosition);
                }
            }
            return c.ToArray();
        }

        public override string ToString()
        {
            string[] s = new string[this.wirePathSteps.Length];
            for (int i = 0; i < this.wirePathSteps.Length; i++)
            {
                s[i] = this.wirePathSteps[i].ToString();
            }
            return String.Join(" ", s);
        }
    }

    public class WirePathStep
    {
        public readonly Direction direction;
        public readonly int stepLength;

        public WirePathStep(string inputString)
        {
            this.direction = DirectionExtensions.FromChar(inputString[0]);
            this.stepLength = int.Parse(inputString.Substring(1, inputString.Length - 1));
        }

        public override string ToString()
        {
            return this.direction.EnumValue() + "" + this.stepLength;
        }
    }

    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        override public string ToString()
        {
            return x + "," + y;
        }

        public override int GetHashCode()
        {
            return (x << 2) ^ y;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Coordinate c = (Coordinate)obj;
                return (x == c.x) && (y == c.y);
            }
        }

        public int ManhattanDistance()
        {
            return Math.Abs(this.x) + Math.Abs(this.y);
        }
    }
}