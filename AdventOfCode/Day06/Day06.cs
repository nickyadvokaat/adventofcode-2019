using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    internal static class Day06
    {
        public static void Run()
        {
            Space space = SpaceFactory.Bigbang("06-test");
            int result = space.NumberOfDirectAndIndirectOrbits();
            Console.WriteLine("Result 6: {0}", result); ;
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
            return this.planets.Select(p => NumberOfAncestors(p)).Sum();
        }

        private int NumberOfAncestors(Planet planet)
        {
            return planet.parent == null ? 0 : 1 + NumberOfAncestors(planet.parent);
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

    public class Planet
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
    }
}