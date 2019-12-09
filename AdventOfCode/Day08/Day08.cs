using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class Day08
    {
        public static void Run()
        {
            int result = part1();
            Console.WriteLine("{0}", result);
        }

        private static int part1()
        {
            string text = System.IO.File.ReadAllText(DataHelper.getPath("08"));
            int numberOfPixels = 25 * 6;
            var parts = text.SplitInParts(numberOfPixels);
            int min = int.MaxValue;
            string minPart = "";
            foreach (string part in parts)
            {
                int count = part.NumberOfOccurencesOfCharacter('0');
                if (count < min)
                {
                    min = count;
                    minPart = part;
                }
            }
            return minPart.NumberOfOccurencesOfCharacter('1') * minPart.NumberOfOccurencesOfCharacter('2');
        }
    }

    internal static class StringExtensions
    {
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        public static int NumberOfOccurencesOfCharacter(this String s, Char c)
        {
            return s.Count(x => x == c);
        }
    }
}