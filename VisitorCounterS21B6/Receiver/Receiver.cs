using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace VisitorCounter.Receiver
{
    internal class ListHolder
    {
        public static List<DateTime> MessageHolder = new List<DateTime>();
        public static Mutex MuTexLock = new Mutex();
    }


    class Receiver
    {
        /// <summary>
        /// Main
        /// </summary>
        public static void Main()
        {
            Thread thread1 = new Thread(PipeReader.ConsolePipeReader);
            thread1.Start();
            Thread thread2 = new Thread(OperationsThread);
            thread2.Start();
        }

        /// <summary>
        /// Main thread
        /// </summary>
        internal static void OperationsThread()
        {
            Console.WriteLine("In operations..");
            double avg = DataProcessor.GetDailyAverage();
            double avg1 = DataProcessor.GetDailyAverage(new DateTime(2020, 01, 01));
            DataProcessor.GetHourlyAverage(4);
            Console.WriteLine(DataProcessor.GetWeeklyAverage(DayOfWeek.Monday));
        }
        
    }
}