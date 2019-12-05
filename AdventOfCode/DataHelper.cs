using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
    public static class DataHelper
    {
        public static string getPath(string challenge)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\data" + challenge + ".txt");
        }
    }
}