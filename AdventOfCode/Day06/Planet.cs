using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode
{
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