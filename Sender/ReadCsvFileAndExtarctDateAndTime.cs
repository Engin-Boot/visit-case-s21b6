using System.IO;

namespace Sender
{
    public class ReadCsvFileAndExtarctData
    {
        public static string RetrieveCsvFilePath()
        {
            var csvInputFilePath = Directory.GetCurrentDirectory();
            var csvFileName = "FootFallEntries.csv";
            csvInputFilePath += @"\" + csvFileName;

            return csvInputFilePath;
        }
    }
}