using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Sender
{
    public class ExtractDataFromCsv
    {
        public static bool IsDataRetrieved { get; set; }
        public static List<DateAndTime> ExtractDateAndTime()
        {
            List<DateAndTime> allDatesandTime = new List<DateAndTime>();
            string csvFilePath = ReadCsvFileAndExtarctData.RetrieveCsvFilePath();
            using (StreamReader dataInCsvFile = new StreamReader(csvFilePath))
            {

                dataInCsvFile.ReadLine();
                string eachRow;

                while (!dataInCsvFile.EndOfStream)
                {
                    eachRow = dataInCsvFile.ReadLine();

                    allDatesandTime.Add(SplitCsvFileAndReturnData.SplitCsvFileAndReturnDateAndTime(eachRow));
                }

                IsDataRetrieved = true;
            }


            return allDatesandTime;
        }
    }
}
