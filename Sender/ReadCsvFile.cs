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

namespace Sender
{
     class ReadCsvFileAndExtarctDateAndTime
    {
         public class DateAndTime
        {
            public DateTime Date { get; set; }
            public TimeSpan Time { get; set; }
            
        }
        
        public List<DateAndTime> extractDateAndTime()
        {
            
            string formatForDate = "dd/MM/yyyy";
            string formatForTime = "HH:mm:ss";

        

            CultureInfo provider = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = provider;


            
            List<DateAndTime> allDatesandTime = new List<DateAndTime>();
            String csvInputFilePath = Directory.GetCurrentDirectory();
            String csvFileName = "FootFallEntries.csv";
            csvInputFilePath += @"\" + csvFileName;
            string line;
            try
            {
                StreamReader dataInCsvFile = new StreamReader(csvInputFilePath);
                dataInCsvFile.ReadLine();
                while(!dataInCsvFile.EndOfStream)
                {
                    line= dataInCsvFile.ReadLine();
                    string[] eachRowOfCsvFile = line.Split(',');
                    DateAndTime objOfDateAndTime = new DateAndTime();

                    try
                    {
                        objOfDateAndTime.Date = DateTime.ParseExact(eachRowOfCsvFile[0], formatForDate, provider);
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("{0} is not in the correct format.", eachRowOfCsvFile[0]);
                    }
                    try
                    {
                        objOfDateAndTime.Time = TimeSpan.Parse(eachRowOfCsvFile[1]);
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("{0} is not in the correct format.", eachRowOfCsvFile[1]);
                    }
                    

                    allDatesandTime.Add(objOfDateAndTime);
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
