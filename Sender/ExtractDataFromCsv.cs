using System.Collections.Generic;
using System.IO;

namespace Sender
{
    public static class ExtractDataFromCsv
    {
        public static bool IsDataRetrieved { get; private set; }

        public static List<DateAndTime> ExtractDateAndTime()
        {
            var allDatesandTime = new List<DateAndTime>();
            IsDataRetrieved = false;
            var csvFilePath = ReadCsvFileAndExtarctData.RetrieveCsvFilePath();
            using (var dataInCsvFile = new StreamReader(csvFilePath))
            {
                dataInCsvFile.ReadLine();

                while (!dataInCsvFile.EndOfStream)
                {
                    string eachRow = dataInCsvFile.ReadLine();
                    allDatesandTime.Add(SplitCsvFileAndReturnData.SplitCsvFileAndReturnDateAndTime(eachRow));
                }

                IsDataRetrieved = true;
                return allDatesandTime;
            }
        }
    }
}