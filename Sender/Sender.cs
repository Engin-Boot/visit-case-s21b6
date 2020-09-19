using System;
using System.Collections.Generic;


namespace Sender
{
    public class Sender
    {
        public static bool IsMessagePrinted = false;
        public static void PrintData(List<DateAndTime> DateAndTimeList)
        {
            foreach (var entry in DateAndTimeList)
            {
                Console.WriteLine(entry.dateAndTime.ToString());
            }
            IsMessagePrinted = true;
        }
        public static void Main()
        {
            List<DateAndTime> dateAndTimeList = ExtractDataFromCsv.ExtractDateAndTime();
            PrintData(dateAndTimeList);
        }
    }
}
