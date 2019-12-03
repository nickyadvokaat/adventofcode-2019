namespace AdventOfCode
{
    internal enum Direction { Up, Down, Left, Right };

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
}