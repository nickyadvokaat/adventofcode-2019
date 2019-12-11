using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    internal static class Day07
    {
        public static void Run()
        {
            //int HighestSignal = FindHighestSignal();
            //Console.WriteLine("Result part 1: {0}", HighestSignal);

            int HighestSignalLooped = FindHighestSignalLooped();
            Console.WriteLine("Result part 2: {0}", HighestSignalLooped);
        }

        private static int FindHighestSignal()
        {
            IntcodeProgram intcodeProgram = GetProgramFromFile();
            var phaseSettings = GetPermutations(Enumerable.Range(0, 5), 5);
            int max = 0;
            foreach (var phaseSettingSequence in phaseSettings)
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
            return max;
        }

        private static int FindHighestSignalLooped()
        {
            IntcodeProgram intcodeProgram = GetProgramFromFile();
            var phaseSettings = GetPermutations(Enumerable.Range(5, 5), 5);
            int max = 0;
            foreach (var phaseSettingSequence in phaseSettings)
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
            return max;
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