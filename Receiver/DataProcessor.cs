using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace VisitorCounter.Receiver
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
                double avg = obj.Average(a => a);
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
        /// This method gets Hourly average
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        internal static double GetHourlyAverage(int hour)
        {
            try
            {
                int count = GetCountOfHour(hour);
                double avg = (double)count / CountSetters.DailyCount.Count;
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
            if (CountSetters.DailyCount.ContainsKey(date))
            {
                return CountSetters.DailyCount[date];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// This method gets the count of given hour
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        internal static int GetCountOfHour(int hour)
        {
            if (CountSetters.HourlyCount.ContainsKey(hour))
            {
                return CountSetters.HourlyCount[hour];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Weekly average for current year
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>

        internal static double GetWeeklyAverage(DayOfWeek day)
        {
            IEnumerable<int> en = from a in CountSetters.DailyCount where a.Key.DayOfWeek == day select a.Value;
            int totalCount = en.Sum();
            if (CountSetters.DailyCount.Count == 0)
            {
                return 0;
            }
            else
            {
                DateTime latestEntry = CountSetters.DailyCount.ElementAt(CountSetters.DailyCount.Count - 1).Key;
                CultureInfo cul = CultureInfo.CurrentCulture;
                int weekNum = cul.Calendar.GetWeekOfYear(latestEntry, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                return (Double)totalCount / weekNum;
            }
        }

    }
}
