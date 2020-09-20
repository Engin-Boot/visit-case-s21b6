using System;

namespace Sender
{
    public class ReadCsvFileAndExtarctData
    {
        public static string RetrieveCsvFilePath()
        {
            var fileName = @"FootFallEntries.csv";
            var filePath = AppDomain.CurrentDomain.BaseDirectory +  fileName;
            return filePath;
        }


    }
}