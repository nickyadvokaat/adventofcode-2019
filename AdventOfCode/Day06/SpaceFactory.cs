using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AdventOfCode
{
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
}