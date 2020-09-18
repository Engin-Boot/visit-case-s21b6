using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization.Configuration;

namespace VisitorCounter.Sender
{
    public class ReadCsvFileAndExtarctDateAndTime
    {
        public class DateAndTime
        {
            public DateTime Date { get; set; }
            public TimeSpan Time { get; set; }

        }

        public string RetrieveCsvFilePath()
        {
            String csvInputFilePath = Directory.GetCurrentDirectory();
            String csvFileName = "FootFallEntries.csv";
            csvInputFilePath += @"\" + csvFileName;
            return csvInputFilePath;
        }

        public List<DateAndTime> ExtractDateAndTime()
        {
            List<DateAndTime> allDatesandTime = new List<DateAndTime>();
            CommPrimitive commPrimitive;

            int dateColumnNumber = 0;
            int timeColumnNumber = 1;


            CultureInfo provider = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = provider;
            string formatForDate = "dd/MM/yyyy";

            string csvFilePath = RetrieveCsvFilePath();
            try
            {
                using (StreamReader dataInCsvFile = new StreamReader(csvFilePath))
                {
                    //StreamReader dataInCsvFile = new StreamReader(csvInputFilePath);
                    dataInCsvFile.ReadLine();
                    string eachRow;

                    while (!dataInCsvFile.EndOfStream)
                    {
                        eachRow = dataInCsvFile.ReadLine();
                        string[] eachRowOfCsvFile = eachRow.Split(',');
                        DateAndTime objOfDateAndTime = new DateAndTime();

                        try
                        {
                            objOfDateAndTime.Date = DateTime.ParseExact(eachRowOfCsvFile[dateColumnNumber], formatForDate, provider);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not in the correct format.", eachRowOfCsvFile[dateColumnNumber]);
                        }
                        try
                        {
                            objOfDateAndTime.Time = TimeSpan.Parse(eachRowOfCsvFile[timeColumnNumber]);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not in the correct format.", eachRowOfCsvFile[timeColumnNumber]);
                        }
                        allDatesandTime.Add(objOfDateAndTime);
                        commPrimitive = new CommPrimitive();
                        commPrimitive.Date = objOfDateAndTime.Date;
                        commPrimitive.Time = objOfDateAndTime.Time;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception + "FILE NOT FOUND");
                throw;
            }

            return allDatesandTime;
        }
    }
}
