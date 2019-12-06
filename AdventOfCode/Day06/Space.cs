using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Space
    {
        private List<Planet> planets;

        public Space()
        {
            this.planets = new List<Planet>();
        }

        public void AddOrbit(string orbit)
        {
            Regex rx = new Regex(@"^(\w+)\)(\w+)$");
            var match = rx.Match(orbit);
            Planet parent = GetOrCreatePlanet(match.Groups[1].Value);
            Planet child = GetOrCreatePlanet(match.Groups[2].Value);
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
            List<Planet> A = planetA.GetAncestors();
            List<Planet> B = planetB.GetAncestors();
            return A.Count + B.Count - 2 * A.Intersect(B).Count();
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
}