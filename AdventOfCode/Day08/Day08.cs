using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    internal static class Day08
    {
        public static void Run()
        {
            const int width = 25;
            const int height = 6;

            string text = System.IO.File.ReadAllText(DataHelper.getPath("08"));

            int result = CheckImageCorruption(text, width, height);
            Console.WriteLine("Result part 1: {0}", result);

            string image = DecodeImage(text, width, height);
            PrintImage(image, 25);
        }

        private static int CheckImageCorruption(string text, int width, int height)
        {
            var parts = text.SplitInParts(width * height);
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

        private static string DecodeImage(string text, int width, int height)
        {
            int numberOfPixels = width * height;
            var parts = text.SplitInParts(numberOfPixels).Reverse();
            char[] image = parts.First().ToCharArray();
            foreach (string part in parts)
            {
                for (int i = 0; i < part.Length; i++)
                {
                    if (part[i] != '2')
                    {
                        image[i] = part[i];
                    }
                }
            }
            return new string(image);
        }

        private static void PrintImage(string image, int width)
        {
            foreach (string line in image.Replace('0', ' ').Replace('1', '\u2588').SplitInParts(width))
            {
                Console.WriteLine(line);
            }
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