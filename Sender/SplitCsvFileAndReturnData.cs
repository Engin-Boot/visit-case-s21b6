using System;
using System.Globalization;
using System.Threading;

namespace Sender
{
    public class SplitCsvFileAndReturnData
    {
        private const int DateColumnNumber = 0;
        private const int TimeColumnNumber = 1;

        public static DateAndTime SplitCsvFileAndReturnDateAndTime(string eachRow)
        {
            var eachRowOfCsvFile = eachRow.Split(',');

            var objOfDateAndTime = new DateAndTime();

            var provider = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = provider;
            var dateOnly = ExtractDate(eachRowOfCsvFile[DateColumnNumber], provider);
            var timeOnly = ExtractTime(eachRowOfCsvFile[TimeColumnNumber], provider);

            objOfDateAndTime.Dt = dateOnly.Date.Add(timeOnly.TimeOfDay);

            return objOfDateAndTime;
        }

        public static DateTime ExtractDate(string date, CultureInfo provider)
        {
            DateTime dateOnly;

            try
            {
                dateOnly = DateTime.ParseExact(date, "dd/MM/yyyy", provider);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", date);
                throw new FormatException("You passed incorrect date format.");
            }

            return dateOnly;
        }

        public static DateTime ExtractTime(string time, CultureInfo provider)
        {
            DateTime timeOnly;
            try
            {
                timeOnly = DateTime.ParseExact(time, "HH:mm:ss", provider);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", time);
                throw new FormatException("You passed incorrect time format.");
            }

            return timeOnly;
        }
    }
}