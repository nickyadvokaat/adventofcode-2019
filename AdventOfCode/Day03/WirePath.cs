using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    internal class WirePath
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
}