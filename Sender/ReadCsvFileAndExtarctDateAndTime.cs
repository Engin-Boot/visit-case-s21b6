using System;
using System.IO;

namespace Sender
{
    public class ReadCsvFileAndExtarctData
    {
        public static string RetrieveCsvFilePath()
        {
            String csvInputFilePath = Directory.GetCurrentDirectory();
            String csvFileName = "FootFallEntries.csv";
            csvInputFilePath += @"\" + csvFileName;

            return csvInputFilePath;
        }
    }
}
