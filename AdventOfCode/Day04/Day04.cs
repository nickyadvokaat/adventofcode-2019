using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Day04
    {
        public static void Run()
        {
            int resultPart1 = GetNumberOfPasswordsInRange(130254, 678275);
            Console.WriteLine("Result part 1: " + resultPart1);

            int resultPart2 = GetNumberOfPasswordsInRange(130254, 678275, true);
            Console.WriteLine("Result part 2: " + resultPart2);
        }

        public static int GetNumberOfPasswordsInRange(int start, int end, bool isPart2 = false)
        {
            int count = 0;
            for (int i = start + 1; i < end; i++)
            {
                if (IsValidPassword(i, isPart2))
                {
                    count++;
                }
            }
            return count;
        }

        private static bool IsValidPassword(int password, bool isPart2 = false)
        {
            return
                IsIncreasingDigits(password) &&
                (
                    isPart2 ?
                    HasExactlyTwoAdjacentDigits(password) :
                    HasTwoAdjacentDigits(password)
                );
        }

        private static bool IsIncreasingDigits(int password)
        {
            int[] digits = SplitToDigits(password);
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] > digits[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool HasTwoAdjacentDigits(int password)
        {
            int[] digits = SplitToDigits(password);
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasExactlyTwoAdjacentDigits(int password)
        {
            int[] digits = SplitToDigits(password);
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                {
                    int value = digits[i];
                    if (i > 0 && digits[i - 1] == value)
                    {
                        continue;
                    }
                    if (i < digits.Length - 2 && digits[i + 2] == value)
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }

        private static int[] SplitToDigits(int password)
        {
            List<int> listOfInts = new List<int>();
            while (password > 0)
            {
                listOfInts.Add(password % 10);
                password /= 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
    }
}