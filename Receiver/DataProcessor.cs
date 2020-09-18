using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Receiver
{
    internal class DataProcessor
    {
        /// <summary>
        /// This method gets the daily average. By default, it calculates daily average from 1st Jan 2000
        /// </summary>
        /// <returns></returns>

        internal static double GetDailyAverage()
        {
            DateTime date = new DateTime(2000, 01, 01);
            return GetDailyAverage(date);

        }

        /// <summary>
        /// This method gets average footfall from given date.
        /// </summary>
        /// <param name="date"> Start date for average to be computed</param>
        /// <returns>average</returns>

        internal static double GetDailyAverage(DateTime date)
        {
            IEnumerable<int> obj = from a in CountSetters.DailyCount where a.Key >= date select a.Value;
            try
            {
                var avg = obj.Average(a => a);
                Console.WriteLine("Daily Average = " + avg);
                return avg;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in calculating Daily Average" + e);
                return 0;
            }
        }

        /// <summary>
        /// This method gets Hourly average for month
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        internal static double GetHourlyAverage(int hour)
        {
            try
            {
                var count = GetCountOfHour(hour);
                var avg = (double)count / CountSetters.DailyCount.Count;
                Console.WriteLine("Average footfall at {0} is:{1}", hour, avg);
                return avg;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in calculating Hourly Average" + e);
                return 0;
            }
        }

        /// <summary>
        /// This method gets count on given day
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>  
        internal static int GetCountOnDate(DateTime date)
        {
            return CountSetters.DailyCount.ContainsKey(date) ? CountSetters.DailyCount[date] : 0;
        }

        /// <summary>
        /// This method gets the count of given hour
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        internal static int GetCountOfHour(int hour)
        {
            return CountSetters.HourlyCount.ContainsKey(hour) ? CountSetters.HourlyCount[hour] : 0;
        }

        /// <summary>
        /// Weekly average for current year
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>

        internal static double GetWeeklyAverage(DayOfWeek day)
        {
            var en = from a in CountSetters.DailyCount where a.Key.DayOfWeek == day select a.Value;
            var totalCount = en.Sum();
            var cul = CultureInfo.CurrentCulture;
            if (CountSetters.DailyCount.Count == 0)
            {
                return 0;
            }
            else
            {
                var latestEntry = CountSetters.DailyCount.ElementAt(CountSetters.DailyCount.Count - 1).Key;
                var weekNum = cul.Calendar.GetWeekOfYear(latestEntry, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                return (double)totalCount / weekNum;
            }
        }

    }
}
