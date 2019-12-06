using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AdventOfCode
{
    internal static class Day06
    {
        public static void Run()
        {
            Space space = SpaceFactory.Bigbang("06");

            int result = space.NumberOfDirectAndIndirectOrbits();
            Console.WriteLine("Result6 part1: {0}", result);

            int result2 = space.NumberOfOrbitalTransfersRequired();
            Console.WriteLine("Result6 part2: {0}", result2);
        }
    }

    public static class SpaceFactory
    {
        public static Space Bigbang(string file)
        {
            Space space = new Space();
            string[] lines = System.IO.File.ReadAllLines(DataHelper.getPath(file));
            foreach (string orbit in lines)
            {
                space.AddOrbit(orbit);
            }
            return space;
        }
    }

    public class Space
    {
        private List<Planet> planets;

        public Space()
        {
            this.planets = new List<Planet>();
        }

        public void AddOrbit(string orbit)
        {
            string[] split = orbit.Split(")");
            Planet parent = GetOrCreatePlanet(split[0]);
            Planet child = GetOrCreatePlanet(split[1]);
            child.SetParent(parent);
        }

        public int NumberOfDirectAndIndirectOrbits()
        {
            return this.planets.Select(p => p.NumberOfAncestors()).Sum();
        }

        public int NumberOfOrbitalTransfersRequired()
        {
            return NumberOfOrbitalTransfersRequired(GetPlanet("YOU"), GetPlanet("SAN"));
        }

        private int NumberOfOrbitalTransfersRequired(Planet planetA, Planet planetB)
        {
            List<Planet> ancestorsA = planetA.GetAncestors();
            List<Planet> ancestorsB = planetB.GetAncestors();

            for (int i = 0; i < ancestorsA.Count; i++)
            {
                if (!ancestorsA[i].Equals(ancestorsB[i]))
                {
                    return ancestorsA.Count - i + ancestorsB.Count - i;
                }
            }

            return -1;
        }

        private Planet GetPlanet(string planetName)
        {
            return this.planets.Where(p => p.name == planetName).First();
        }

        private Planet GetOrCreatePlanet(string planetName)
        {
            var x = this.planets.Where(p => p.name == planetName);
            if (x.Count() > 0)
            {
                return x.First();
            }
            else
            {
                Planet planet = new Planet(planetName);
                this.planets.Add(planet);
                return planet;
            }
        }
    }

    public class Planet : IEquatable<Planet>
    {
        public readonly string name;
        public Planet parent;

        public Planet(string name)
        {
            this.name = name;
            this.parent = null;
        }

        public void SetParent(Planet parent)
        {
            this.parent = parent;
        }

        public List<Planet> GetAncestors()
        {
            if (this.parent == null)
            {
                return new List<Planet>();
            }
            else
            {
                List<Planet> p = this.parent.GetAncestors();
                p.Add(this.parent);
                return p;
            }
        }

        public int NumberOfAncestors()
        {
            return parent == null ? 0 : 1 + parent.NumberOfAncestors();
        }

        public bool Equals([AllowNull] Planet other)
        {
            return other == null ? false : other.name == name;
        }
    }
}