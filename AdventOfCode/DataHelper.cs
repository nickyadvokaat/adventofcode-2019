using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
    internal static class DataHelper
    {
        public static string getPath(string challenge)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\data" + challenge + ".txt");
        }
    }
}