using System;

namespace Receiver
{
    internal class Receiver
    {
        private static string OutputToFile { get; set; }
        /// <summary>
        ///     Main
        /// </summary>
        internal static void Main()
        {
            PipeReader.ConsolePipeReader();
        }

        /// <summary>
        ///     Main thread
        /// </summary>
        internal static void OperationsThread()
        {
            Console.WriteLine("Finished reading from pipe...");
            Console.WriteLine("Calculating Daily average for the month...");
            var dailyAverage = DataProcessor.GetAverageForCurrentMonth();
            OutputToFile = "Daily average for current month=" + dailyAverage + "\n";

            for (int i = 0; i <= 24; i++)
            {
                var hourlyAverage = DataProcessor.GetHourlyAverage(i);
                OutputToFile += "Average footfall at:" + i + "hours is:" + hourlyAverage + "\n";
            }
            Console.WriteLine("Calculating average for a Sunday...");
            var averageForSunday = DataProcessor.GetWeeklyAverage(DayOfWeek.Sunday);
            Console.WriteLine("Average footfall on a sunday is:"+ averageForSunday);
            OutputToFile += "Average footfall on a Sunday = " + averageForSunday;
            DataToCsv.WriteToCsv(OutputToFile);
        }
    }
}