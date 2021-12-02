using System;
using System.Collections.Generic;
using System.IO;

namespace SonarSweep
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = GetSonarReport();
            int countIncreaseDepth = CountIncreasingDepth(list);
            int countIncreaseThree = CountIncreasingThreeMeasurementWindow(list);

            Console.WriteLine($"The number of times depth increased is: {countIncreaseDepth}");
            Console.WriteLine($"The number of time debth increased using the three measurement window is: {countIncreaseThree}");
        }

        public static List<int> GetSonarReport()
        {
            List<int> report = new List<int>();

            StreamReader reader = File.OpenText("C:\\Dev\\Csharp\\AoC2021\\day1_sonar_sweep\\SonarSweep\\sonar_report.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                report.Add(int.Parse(line));
            }

            return report;
        }

        public static int CountIncreasingDepth(List<int> sonarReport)
        {
            int count = 0;

            for (var i = 0; i < sonarReport.Count - 1; i++)
            {
                if (sonarReport[i] < sonarReport[i + 1])
                {
                    count++;
                }
            }

            return count;
        }

        public static int CountIncreasingThreeMeasurementWindow(List<int> sonarReport)
        {
            int count = 0;
            int sum = sonarReport[0] + sonarReport[1] + sonarReport[2];

            for (var i = 1; i <= sonarReport.Count - 3; ++i)
            {
                int currSum = sonarReport[i] + sonarReport[i + 1] + sonarReport[i + 2];

                if (currSum > sum)
                {
                    count++;
                }

                sum = currSum;
            }

            return count;
        }
    }
}
