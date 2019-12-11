using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    internal class AsteroidMapFactory
    {
        public static AsteroidMap CreateAsteroidMap(string file)
        {
            AsteroidMap asteroidMap = new AsteroidMap();
            string[] lines = System.IO.File.ReadAllLines(DataHelper.getPath(file));
            int width = lines[0].Length;
            int height = lines.Length;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (lines[y][x] == '#')
                    {
                        asteroidMap.Add(new Asteroid(x, y));
                    }
                }
            }
            return asteroidMap;
        }
    }
}