using System;
using System.Collections.Generic;

namespace VisitorCounter.Receiver
{
    internal class CountSetters
    {
        //Daily count (Date-count)
        internal static Dictionary<DateTime, int> DailyCount = new Dictionary<DateTime, int>();

        //Hourly count (Hour - count)
        internal static Dictionary<int, int> HourlyCount = new Dictionary<int, int>();

        /// <summary>
        /// This method updates counter value in Daily count
        /// </summary>
        /// <param name="comm1"></param>
        internal static void SetDayCount(DateTime date)
        {
            //DailyCount.Add(new DateTime(2002, 2, 21), 1);
            //DailyCount.Add(new DateTime(2003, 4, 21), 1);
            //HourlyCount.Add(1, 1);
            //HourlyCount.Add(4, 1);
            //HourlyCount.Add(3, 1);
            var TempDate = date.Date;
            if (DailyCount.ContainsKey(TempDate))
            {
                DailyCount[TempDate]++;
            }
            else
            {
                DailyCount.Add(TempDate, 1);
            }
        }

        /// <summary>
        /// This method updates HourCouter when an counter object arrives
        /// </summary>
        /// <param name="comm1"></param>
        internal static void SetHourCount(DateTime time)
        {
            int hour = time.TimeOfDay.Hours;
            if (HourlyCount.ContainsKey(hour))
            {
                HourlyCount[hour]++;
            }
            else
            {
                HourlyCount.Add(hour, 1);
            }
        }
    }
}
