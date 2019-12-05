using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public void Test01()
        {
            int input = 0;
            string program = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9";
            IntcodeProgram intcodeProgram = new IntcodeProgram(program);

            int result = intcodeProgram.ExecuteIntcode(input).outputs.Last();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test02()
        {
            int input = 1;
            string program = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9";
            IntcodeProgram intcodeProgram = new IntcodeProgram(program);

            int result = intcodeProgram.ExecuteIntcode(input).outputs.Last();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test03()
        {
            int input = 0;
            string program = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1";
            IntcodeProgram intcodeProgram = new IntcodeProgram(program);

            int result = intcodeProgram.ExecuteIntcode(input).outputs.Last();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test04()
        {
            int input = 1;
            string program = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1";
            IntcodeProgram intcodeProgram = new IntcodeProgram(program);

            int result = intcodeProgram.ExecuteIntcode(input).outputs.Last();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestLargerExample()
        {
            int input = 7;
            string program = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";
            IntcodeProgram intcodeProgram = new IntcodeProgram(program);

            int result = intcodeProgram.ExecuteIntcode(input).outputs.Last();

            Assert.AreEqual(999, result);
        }

        [TestMethod]
        public void TestPart1Solution()
        {
            int input = 1;
            string program = System.IO.File.ReadAllText(DataHelper.getPath("05"));

            IntcodeProgram intcodeProgram = new IntcodeProgram(program);

            int result = intcodeProgram.ExecuteIntcode(input).outputs.Last();

            Assert.AreEqual(5182797, result);
        }

        [TestMethod]
        public void TestPart2Solution()
        {
            int input = 5;
            string program = System.IO.File.ReadAllText(DataHelper.getPath("05"));

            IntcodeProgram intcodeProgram = new IntcodeProgram(program);

            int result = intcodeProgram.ExecuteIntcode(input).outputs.Last();

            Assert.AreEqual(12077198, result);
        }
    }
}