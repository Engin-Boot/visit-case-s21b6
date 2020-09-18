using System;
using System.Collections.Generic;


namespace Sender
{
    class Sender
    {
        public static void Main()
        {

            
            List<DateAndTime> dateAndTimeList = ExtractDataFromCsv.ExtractDateAndTime();

            foreach (var entry in dateAndTimeList)
            {
                //string JsonString = JsonConvert.SerializeObject(entry);
                //Console.WriteLine(JsonString);
                Console.WriteLine(entry.dateAndTime.ToString());
            }
        }
    }
}
