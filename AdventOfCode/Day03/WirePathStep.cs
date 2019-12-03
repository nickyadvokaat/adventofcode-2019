namespace AdventOfCode
{
    internal class WirePathStep
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
}