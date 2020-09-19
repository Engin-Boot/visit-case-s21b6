using System;
using System.Collections.Generic;


namespace Sender
{
    public class Sender
    {
        public static void PrintData(List<DateAndTime> DateAndTimeList)
        {
            foreach (var entry in DateAndTimeList)
            {
                //string JsonString = JsonConvert.SerializeObject(entry);
                //Console.WriteLine(JsonString);
                Console.WriteLine(entry.dateAndTime.ToString());
            }
        }
        public static void Main()
        {
            List<DateAndTime> dateAndTimeList = ExtractDataFromCsv.ExtractDateAndTime();
            PrintData(dateAndTimeList);
        }
    }
}
