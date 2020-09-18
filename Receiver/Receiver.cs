using System;
using System.Threading;
using System.Collections.Generic;


namespace Receiver
{
    internal class Receiver
    {
        /// <summary>
        /// Main
        /// </summary>
        internal static void Main()
        {
            PipeReader.ConsolePipeReader();
        }

        /// <summary>
        /// Main thread
        /// </summary>
        internal static void OperationsThread()
        {
            Console.WriteLine("In operations..");
            var avg = DataProcessor.GetDailyAverage();
            //var avg1 = DataProcessor.GetDailyAverage(new DateTime(2020, 01, 01));
            DataProcessor.GetHourlyAverage(0);
            Console.WriteLine(DataProcessor.GetWeeklyAverage(DayOfWeek.Monday));
        }
        
    }
}