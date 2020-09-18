using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace VisitorCounter.Sender
{
    class Sender
    {
        public static void Main()
        {

            ReadCsvFileAndExtarctDateAndTime object1 = new ReadCsvFileAndExtarctDateAndTime();
            List<ReadCsvFileAndExtarctDateAndTime.DateAndTime> dateAndTimeList;
            dateAndTimeList = object1.ExtractDateAndTime();


            //foreach (var objOfDateAndTime in dateAndTimeList)
            //{
            //    Console.WriteLine(objOfDateAndTime.dateAndTime.ToString());

            //}

            foreach (var entry in dateAndTimeList)
            {
                //string JsonString = JsonConvert.SerializeObject(entry);
                //Console.WriteLine(JsonString);
                Console.WriteLine(entry.dateAndTime.ToString());
            }
        }
    }
}
