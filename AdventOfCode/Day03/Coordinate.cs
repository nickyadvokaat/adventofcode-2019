using System;

namespace AdventOfCode
{
    internal struct Coordinate
    {
        public int x;
        public int y;
        public int stepNumber;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.stepNumber = 0;
        }

        public int ManhattanDistance()
        {
            return Math.Abs(this.x) + Math.Abs(this.y);
        }

        override public string ToString()
        {
            return x + "," + y;
        }

        override public int GetHashCode()
        {
            return (x << 2) ^ y;
        }

        override public bool Equals(object obj)
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
    }
}