using System;
using System.IO;

namespace Receiver
{
    public static class DataToCsv
    {
        private static string GetFilePath()
        {
            const string fileName = @"Output.csv";
            var filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            return filePath;
        }
        public static void WriteToCsv(string data)
        {
            var filePath = GetFilePath();

            try
            {
                using var sw = new StreamWriter(filePath);
                sw.WriteLine(data);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}