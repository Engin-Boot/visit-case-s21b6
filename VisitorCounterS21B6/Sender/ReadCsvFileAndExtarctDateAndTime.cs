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
        const int dateColumnNumber = 0;
        const int timeColumnNumber = 1;
        public class DateAndTime
        {
            public DateTime dateAndTime { get; set; }     

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
            string csvFilePath = RetrieveCsvFilePath();
            using (StreamReader dataInCsvFile = new StreamReader(csvFilePath))
            {

                dataInCsvFile.ReadLine();
                string eachRow;

                while (!dataInCsvFile.EndOfStream)
                {
                    eachRow = dataInCsvFile.ReadLine();

                    allDatesandTime.Add(SplitCsvFileAndReturnDateAndTime(eachRow));
                }
            }


            return allDatesandTime;
        }

        public DateAndTime SplitCsvFileAndReturnDateAndTime(string eachRow)
        {

            string[] eachRowOfCsvFile = eachRow.Split(',');

            DateAndTime objOfDateAndTime = new DateAndTime();

            CultureInfo provider = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = provider;
            DateTime dateOnly = new DateTime();
            DateTime timeOnly = new DateTime();
            try
            {
                dateOnly = DateTime.ParseExact
                   (eachRowOfCsvFile[dateColumnNumber], "dd/MM/yyyy", provider);

            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", eachRowOfCsvFile[dateColumnNumber]);
            }
            try
            {
                timeOnly = objOfDateAndTime.dateAndTime = DateTime.ParseExact
                   (eachRowOfCsvFile[timeColumnNumber], "HH:mm:ss", provider);

            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", eachRowOfCsvFile[timeColumnNumber]);
            }


            objOfDateAndTime.dateAndTime = dateOnly.Date.Add(timeOnly.TimeOfDay);

            return objOfDateAndTime;

        }

    }
}
