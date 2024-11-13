using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using Program1;

namespace Program1.Tests
{
    public class HairSellingTests
    {
        private readonly ITestOutputHelper output;

        public HairSellingTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public static IEnumerable<object[]> ProfitTestData()
        {
            yield return new object[] { "5\n73 31 96 24 46\n", 380 };
            yield return new object[] { "3\n10 20 30\n", 90 };
            yield return new object[] { "4\n1 2 3 4\n", 16 };
            yield return new object[] { "5\n5 5 5 5 5\n", 25 };
            yield return new object[] { "10\n1 2 3 4 5 6 7 8 9 10\n", 100 };
            yield return new object[] { "10\n10 9 8 7 6 5 4 3 2 1\n", 55 };
        }

        [Theory]
        [MemberData(nameof(ProfitTestData))]
        public void TestCalculateMaxProfit(string inputData, int expectedProfit)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");

            try
            {
                File.WriteAllText(inputPath, inputData);
                Program.Main(new string[] { inputPath, outputPath });

                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                Assert.Equal(expectedProfit.ToString(), result);
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void TestFileOperations()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");

            try
            {
                File.WriteAllText(inputPath, "5\n73 31 96 24 46\n");
                Program.Main(new string[] { inputPath, outputPath });

                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                Assert.Equal("380", result);
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }
    }
}