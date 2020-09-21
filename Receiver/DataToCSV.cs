using System;
using System.IO;

namespace Receiver
{
    public class DataToCsv
    {
        public static string GetFilePath()
        {
            const string fileName = @"Output.csv";
            var filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            return filePath;
        }
        public static int WriteToCsv(string data)
        {
            var filePath = GetFilePath();

            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(data);
                    sw.Close();
                    return 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}