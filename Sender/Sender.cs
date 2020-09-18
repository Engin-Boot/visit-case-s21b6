using System;
using System.Collections.Generic;


namespace Sender
{
    class Sender
    {
        public static void Main()
        {

            ReadCsvFileAndExtarctDateAndTime object1 = new ReadCsvFileAndExtarctDateAndTime();
            List<ReadCsvFileAndExtarctDateAndTime.DateAndTime> dateAndTimeList;
            dateAndTimeList = object1.ExtractDateAndTime();
            foreach (var entry in dateAndTimeList)
            {
                //string JsonString = JsonConvert.SerializeObject(entry);
                //Console.WriteLine(JsonString);
                Console.WriteLine(entry.dateAndTime.ToString());
            }
        }
    }
}
