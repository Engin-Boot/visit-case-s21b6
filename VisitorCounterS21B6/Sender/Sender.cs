using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace VisitorCounter.Sender
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
                string JsonString = JsonSerializer.Serialize(entry);
                Console.WriteLine(JsonString);
            }
            Console.ReadKey();



        }
    }
}
