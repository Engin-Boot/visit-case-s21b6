using System.Collections.Generic;
using System.IO;

namespace Sender
{
    public class ExtractDataFromCsv
    {
        public static bool IsDataRetrieved { get; set; }

        public static List<DateAndTime> ExtractDateAndTime()
        {
            var allDatesandTime = new List<DateAndTime>();
            var csvFilePath = ReadCsvFileAndExtarctData.RetrieveCsvFilePath();
            using (var dataInCsvFile = new StreamReader(csvFilePath))
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