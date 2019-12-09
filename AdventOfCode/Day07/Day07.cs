using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class Day07
    {
        public static void Run()
        {
            IntcodeProgram intcodeProgram;

            intcodeProgram = GetProgramFromFile();

            var result = GetPermutations(Enumerable.Range(0, 5), 5);

            int max = 0;

            foreach (var phaseSettingSequence in result)
            {
                int output = 0;
                foreach (int i in phaseSettingSequence)
                {
                    List<int> inputs = new List<int> { i, output };
                    output = intcodeProgram.ExecuteIntcode(inputs).outputs.Last();
                }
                if (output > max)
                {
                    max = output;
                }
            }
            Console.WriteLine(max);
        }

        private static IntcodeProgram GetProgramFromFile()
        {
            string text = System.IO.File.ReadAllText(DataHelper.getPath("07"));
            return new IntcodeProgram(text);
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}