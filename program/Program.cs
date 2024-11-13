using System;
using System.IO;
using System.Linq;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputFilePath = args.Length > 0 ? args[0] : "INPUT.TXT";
            string outputFilePath = args.Length > 1 ? args[1] : "OUTPUT.TXT";
            string[] input = File.ReadAllLines(inputFilePath);
            int N = int.Parse(input[0]);
            int[] prices = input[1].Split(' ').Select(int.Parse).ToArray();

            int[] maxPricesFromToday = new int[N];
            maxPricesFromToday[N - 1] = prices[N - 1];

            for (int i = N - 2; i >= 0; i--)
            {
                maxPricesFromToday[i] = Math.Max(prices[i], maxPricesFromToday[i + 1]);
            }

            int totalProfit = 0;
            int hairLength = 0;

            for (int i = 0; i < N; i++)
            {
                hairLength++;
                if (prices[i] == maxPricesFromToday[i])
                {
                    totalProfit += hairLength * prices[i];
                    hairLength = 0;
                }
            }
            File.WriteAllText(outputFilePath, totalProfit.ToString());
        }
    }
}