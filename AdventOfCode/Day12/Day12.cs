using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal static class Day12
    {
        public static void Run()
        {
            List<Moon> moons = new List<Moon>();
            string[] lines = System.IO.File.ReadAllLines(DataHelper.getPath("12"));
            foreach (string orbit in lines)
            {
                Regex rx = new Regex(@"^<x=(-?\d+), y=(-?\d+), z=(-?\d+)>$");
                var match = rx.Match(orbit);
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                int z = int.Parse(match.Groups[3].Value);
                moons.Add(new Moon(x, y, z));
            }

            Universe universe = new Universe();
            foreach (Moon m in moons)
            {
                universe.AddMoon(m);
            }
            universe.Run();
        }

        public class Universe
        {
            private List<Moon> moons;

            public Universe()
            {
                moons = new List<Moon>();
            }

            public void AddMoon(Moon moon)
            {
                moons.Add(moon);
            }

            public void Run()
            {
                SortedSet<string> states = new SortedSet<string>();
                int steps = 1 * 1000 * 1000;
                for (int step = 0; step < steps; step++)
                {
                    UpdateVelocities();
                    ApplyVelocities();

                    string s = S();//string.Join(",", moons.Select(m => m.ToString()));
                    if (states.Contains(s))
                    {
                        Console.WriteLine("Result: {0}", step);
                        break;
                    }
                    states.Add(s);
                }
                Console.WriteLine("Energy: {0}", moons.Select(m => m.KineticEnergy()).Sum());
            }

            private void UpdateVelocities()
            {
                foreach (Moon m in moons)
                {
                    foreach (Moon n in moons)
                    {
                        m.velocity.X += m.position.X.CompareTo(n.position.X);
                        if (m.position.X < n.position.X)
                        {
                            m.velocity.X += 1;
                        }
                        else if (m.position.X > n.position.X)
                        {
                            m.velocity.X -= 1;
                        }
                        if (m.position.Y < n.position.Y)
                        {
                            m.velocity.Y += 1;
                        }
                        else if (m.position.Y > n.position.Y)
                        {
                            m.velocity.Y -= 1;
                        }
                        if (m.position.Z < n.position.Z)
                        {
                            m.velocity.Z += 1;
                        }
                        else if (m.position.Z > n.position.Z)
                        {
                            m.velocity.Z -= 1;
                        }
                    }
                }
            }

            private void ApplyVelocities()
            {
                foreach (Moon m in moons)
                {
                    m.ApplyVelocity();
                }
            }

            private string S()
            {
                StringBuilder sb = new StringBuilder();
                foreach (Moon moon in moons)
                {
                    sb.AppendFormat("{0} {1} {2},", moon.position.X, moon.position.Y, moon.position.Z);
                    sb.AppendFormat("{0} {1} {2},", moon.velocity.X, moon.velocity.Y, moon.velocity.Z);
                }
                return sb.ToString();
            }
        }

        public class Moon
        {
            public Vector3 position;
            public Vector3 velocity;

            public Moon(int positionX, int positionY, int positionZ)
            {
                this.position = new Vector3(positionX, positionY, positionZ);
                this.velocity = new Vector3(0, 0, 0);
            }

            public void ApplyVelocity()
            {
                this.position += this.velocity;
            }

            public int KineticEnergy()
            {
                return (int)position.SumOfAbsoluteValues() * (int)velocity.SumOfAbsoluteValues();
            }

            public override string ToString()
            {
                //long a = (long)position.X * 1000 * 1000 * 1000 * 1000 + (long)position.Y * 1000 * 1000 + (long)position.Z;
                //long b = (long)velocity.X * 1000 * 1000 * 1000 * 1000 + (long)velocity.Y * 1000 * 1000 + (long)velocity.Z;
                //return a + "-" + b;
                return position.ToString() + "," + velocity.ToString();
                //return String.Format("pos=<x={0}, y={1}, z={2}>, vel=<x={3}, y={4}, z={5}>",
                //  position.X, position.Y, position.Z, velocity.X, velocity.Y, velocity.Z);
            }
        }
    }

    public static class VectorExtensions
    {
        public static float SumOfAbsoluteValues(this Vector3 v)
        {
            return Math.Abs(v.X) + Math.Abs(v.Y) + Math.Abs(v.Z);
        }
    }
}