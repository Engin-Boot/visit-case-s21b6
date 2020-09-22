using System;
using System.Collections.Generic;

namespace Receiver
{
    public static class CountSetters
    {
        //Daily count (Date-count)
        public static readonly Dictionary<DateTime, int> DailyCount = new Dictionary<DateTime, int>();

        //Hourly count (Hour - count)
        public static readonly Dictionary<int, int> HourlyCount = new Dictionary<int, int>();

        /// <summary>
        ///     This method updates counter value in Daily count
        /// </summary>
        public static void SetDayCount(DateTime date)
        {
            var tempDate = date.Date;
            if (DailyCount.ContainsKey(tempDate))
                DailyCount[tempDate]++;
            else
                DailyCount.Add(tempDate, 1);
        }

        /// <summary>
        ///     This method updates HourCounter when an counter object arrives
        /// </summary>
        public static void SetHourCount(DateTime time)
        {
            var hour = time.TimeOfDay.Hours;
            if (HourlyCount.ContainsKey(hour))
                HourlyCount[hour]++;
            else
                HourlyCount.Add(hour, 1);
        }
    }
}