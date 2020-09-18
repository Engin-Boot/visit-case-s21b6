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
                throw new FormatException("You passed incorrect date format.");

            }
            try
            {
                timeOnly = objOfDateAndTime.dateAndTime = DateTime.ParseExact
                   (eachRowOfCsvFile[timeColumnNumber], "HH:mm:ss", provider);

            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", eachRowOfCsvFile[timeColumnNumber]);
                throw new FormatException("You passed incorrect time format.");

            }


            objOfDateAndTime.dateAndTime = dateOnly.Date.Add(timeOnly.TimeOfDay);

            return objOfDateAndTime;

        }
    }
}
