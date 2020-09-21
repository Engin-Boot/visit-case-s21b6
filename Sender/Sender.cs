using System;
using System.Collections.Generic;
using System.Globalization;

namespace Sender
{
    public static class Sender
    {
        public static bool IsMessagePrinted { get; private set; }

        public static void PrintData(List<DateAndTime> dateAndTimeList)
        {
            foreach (var entry in dateAndTimeList)
            {
                var date = entry.Dt;
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