using System;
using System.Collections.Generic;
using System.Globalization;

namespace Sender
{
    public class Sender
    {
        public static bool IsMessagePrinted { get; set; }

        public static void PrintData(List<DateAndTime> dateAndTimeList)
        {
            foreach (var entry in dateAndTimeList)
            {
                var date = entry.dateAndTime;
                Console.WriteLine(date.ToString(CultureInfo.InvariantCulture));
            }

            IsMessagePrinted = true;
        }

        public static void Main()
        {
            var dateAndTimeList = ExtractDataFromCsv.ExtractDateAndTime();
            PrintData(dateAndTimeList);
        }
    }
}