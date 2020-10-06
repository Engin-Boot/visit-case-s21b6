using System;
using System.Globalization;
using System.Linq;

namespace Receiver
{
    public static class DataProcessor
    {
        public static int GetNumberOfDaysBetweenDates(DateTime date1 , DateTime date2)
        {
            var numberOfDays = (int)Math.Abs((date1.Date - date2.Date).TotalDays);
            return numberOfDays + 1;
        }
        /// <summary>
        /// Gets the number of Weeks between the 2 dates
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        public static int GetNumberOfWeeks(DateTime date1, DateTime date2)
        {
                var numberOfWeeks = (int)(Math.Abs((date1 - date2).TotalDays) / 7);
                return numberOfWeeks;

        }

        public static double GetAverageForCurrentMonth()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var currentDate = new DateTime(currentYear, currentMonth, 01);
            return GetDailyAverage(currentDate);
        }
        /// <summary>
        /// This method gets the daily average. By default, it calculates daily average from 1st Jan 2000
        /// </summary>
        /// <returns></returns>
        public static double GetDailyAverage()
        {
            var date = new DateTime(2000, 01, 01);
            return GetDailyAverage(date);
        }

        /// <summary>
        ///     This method gets average footfall from given date.
        /// </summary>
        /// <param name="date"> Start date for average to be computed</param>
        /// <returns>average</returns>
        public static double GetDailyAverage(DateTime date)
        {
            var todayDate = DateTime.Today;
            var obj = from a in CountSetters.DailyCount where a.Key >= date select a.Value;
            var numberOfDays = GetNumberOfDaysBetweenDates(todayDate, date);
            var totalCount = obj.Sum(a => a);
            return ((double)totalCount / numberOfDays);
        }

        public static double GetHourlyAverage(int hour)
        {
            try
            {
                var count = GetCountOfHour(hour);
                var endDate = DateTime.Today;
                var startDate = CountSetters.DailyCount.ElementAt(0).Key;
                var numberOfDays = GetNumberOfDaysBetweenDates(startDate, endDate);
                var avg = (double) count / numberOfDays;
                return avg;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in calculating Hourly Average" + e);
                return 0;
            }
        }

        /// <summary>
        /// This method gets the count of given hour
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        private static int GetCountOfHour(int hour)
        {
            return CountSetters.HourlyCount.ContainsKey(hour) ? CountSetters.HourlyCount[hour] : 0;
        }

        /// <summary>
        /// Weekly average
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static double GetWeeklyAverage(DayOfWeek day)
        {
            var en = from a in CountSetters.DailyCount where a.Key.DayOfWeek == day select a.Value;
            var totalCount = en.Sum();
            var cul = CultureInfo.CurrentCulture;
            if (CountSetters.DailyCount.Count == 0)
            {
                return 0;
            }

            var latestEntry = CountSetters.DailyCount.ElementAt(CountSetters.DailyCount.Count - 1).Key;
            var weekNum = cul.Calendar.GetWeekOfYear(latestEntry, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return (double)totalCount / weekNum;
        }
    }
}