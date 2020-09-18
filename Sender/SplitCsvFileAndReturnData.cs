using System;
using System.Globalization;
using System.Threading;

namespace Sender
{
    public class SplitCsvFileAndReturnData
    {
        const int dateColumnNumber = 0;
        const int timeColumnNumber = 1;
        public static DateAndTime SplitCsvFileAndReturnDateAndTime(string eachRow)
        {
            string[] eachRowOfCsvFile = eachRow.Split(',');

            DateAndTime objOfDateAndTime = new DateAndTime();

            CultureInfo provider = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = provider;
            DateTime DateOnly = ExtractDate(eachRowOfCsvFile[dateColumnNumber], provider);
            DateTime TimeOnly = ExtractTime(eachRowOfCsvFile[timeColumnNumber], provider);
            
            objOfDateAndTime.dateAndTime = DateOnly.Date.Add(TimeOnly.TimeOfDay);

            return objOfDateAndTime;

        }

        public static DateTime ExtractDate(string Date ,CultureInfo provider)
        {
            DateTime DateOnly;
            
            try
            {
                DateOnly = DateTime.ParseExact(Date, "dd/MM/yyyy", provider);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", Date);
                throw new FormatException("You passed incorrect date format.");

            }
            return DateOnly;
        }

        public static DateTime ExtractTime(string Time,CultureInfo provider)
        {
            DateTime TimeOnly;
            try
            {
                TimeOnly = DateTime.ParseExact(Time, "HH:mm:ss", provider);

            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", Time);
                throw new FormatException("You passed incorrect time format.");

            }
            return TimeOnly;
        }
    }
}
