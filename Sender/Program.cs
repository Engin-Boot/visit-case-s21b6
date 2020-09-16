using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadCsvFileAndExtarctDateAndTime object1 = new ReadCsvFileAndExtarctDateAndTime();
            List<ReadCsvFileAndExtarctDateAndTime.DateAndTime> dateAndTimeList;
            dateAndTimeList = object1.extractDateAndTime();

            foreach (var entry in dateAndTimeList)
            {

                Console.Write(entry.Date.Year + " ");
                Console.Write(entry.Date.Month + " ");
                Console.Write(entry.Date.Day + " ");
                Console.Write(entry.Time.Hours + " ");
                Console.Write(entry.Time.Minutes + " ");
                Console.WriteLine(entry.Time.Seconds);
            }

        

        }
    }
}
