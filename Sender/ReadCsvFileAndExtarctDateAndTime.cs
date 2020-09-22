using System;

namespace Sender
{
    public static class ReadCsvFileAndExtarctData
    {
        public static string RetrieveCsvFilePath()
        {
            var fileName = @"FootFallEntries.csv";
            var filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            return filePath;

        }
    }
}