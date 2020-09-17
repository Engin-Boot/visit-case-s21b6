using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace VisitorCounter.Receiver
{
    internal class ListHolder
    {
        public static List<CommPrimitive> MessageHolder = new List<CommPrimitive>();
        public static Mutex MuTexLock = new Mutex();
    }


    class Receiver
    {
        //Daily count (Date-count)
        private static Dictionary<DateTime, int> DailyCount = new Dictionary<DateTime, int>();

        //Hourly count (Hour - count)
        private static Dictionary<int, int> HourlyCount = new Dictionary<int, int>();


        /// <summary>
        /// This method reads from the console pipe
        /// </summary>
        private static void ConsolePipeReader()
        {
            Console.WriteLine("In pipe");
            //string inputFromPipe;
            //int AddToBuffer = 0;
            //List<string> TempMessageBuffer = new List<string>();

            //while ((inputFromPipe = Console.ReadLine()) != null)
            //{
            //    if (ListHolder.MuTexLock.WaitOne())
            //    {
            //        if (AddToBuffer == 1)
            //        {
            //            ListHolder.MessageHolder.AddRange(TempMessageBuffer);
            //            TempMessageBuffer.Clear();
            //            AddToBuffer = 0;
            //        }
            //        ListHolder.MessageHolder.Add(inputFromPipe);
            //        ListHolder.MuTexLock.ReleaseMutex();
            //    }
            //    else
            //    {
            //        AddToBuffer = 1;
            //        TempMessageBuffer.Add(inputFromPipe);
            //    }
            try
            {
                CommPrimitive comm1 = new CommPrimitive(2020, 09, 16, 2, 00, 00);
                CommPrimitive comm2 = new CommPrimitive(2020, 09, 16, 2, 00, 50);
                CommPrimitive comm3 = new CommPrimitive(2020, 09, 16, 2, 01, 00);
                CommPrimitive comm4 = new CommPrimitive(2020, 09, 16, 2, 20, 00);
                CommPrimitive comm5 = new CommPrimitive(2020, 09, 16, 2, 30, 00);
                CommPrimitive comm6 = new CommPrimitive(2020, 09, 16, 2, 50, 00);
                CommPrimitive comm7 = new CommPrimitive(2020, 09, 16, 3, 00, 00);
                CommPrimitive comm8 = new CommPrimitive(2020, 09, 16, 3, 00, 10);
                CommPrimitive comm9 = new CommPrimitive(2020, 09, 16, 4, 00, 00);
                CommPrimitive comm10 = new CommPrimitive(2020, 08, 16, 6, 00, 00);
                CommPrimitive comm11 = new CommPrimitive(2002, 08, 16, 4, 00, 00);
                try
                {
                    if (ListHolder.MuTexLock.WaitOne())
                    {
                        ListHolder.MessageHolder.Add(comm1);
                        SetHourCount(comm1);
                        SetDayCount(comm1);
                        ListHolder.MessageHolder.Add(comm2);
                        SetHourCount(comm2);
                        SetDayCount(comm2);
                        ListHolder.MessageHolder.Add(comm3);
                        SetHourCount(comm3);
                        SetDayCount(comm3);
                        ListHolder.MessageHolder.Add(comm4);
                        SetHourCount(comm4);
                        SetDayCount(comm4);
                        ListHolder.MessageHolder.Add(comm5);
                        SetHourCount(comm5);
                        SetDayCount(comm5);
                        ListHolder.MessageHolder.Add(comm6);
                        SetHourCount(comm6);
                        SetDayCount(comm6);
                        ListHolder.MessageHolder.Add(comm7);
                        SetHourCount(comm7);
                        SetDayCount(comm7);
                        ListHolder.MessageHolder.Add(comm8);
                        SetHourCount(comm8);
                        SetDayCount(comm8);
                        ListHolder.MessageHolder.Add(comm9);
                        SetHourCount(comm9);
                        SetDayCount(comm9);
                        ListHolder.MessageHolder.Add(comm10);
                        SetHourCount(comm10);
                        SetDayCount(comm10);
                        ListHolder.MessageHolder.Add(comm11);
                        SetHourCount(comm11);
                        SetDayCount(comm11);
                        ListHolder.MuTexLock.ReleaseMutex();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception in adding" + e);
                }
            }
            catch
            {
                Console.WriteLine("Exception in objects..");
            }

        }

        /// <summary>
        /// This method updates counter value in Daily count
        /// </summary>
        /// <param name="comm1"></param>
        private static void SetDayCount(CommPrimitive comm1)
        {
            if (DailyCount.ContainsKey(comm1.Date))
            {
                DailyCount[comm1.Date]++;
            }
            else
            {
                DailyCount.Add(comm1.Date, 1);
            }
        }

        /// <summary>
        /// This method updates HourCouter when an counter object arrives
        /// </summary>
        /// <param name="comm1"></param>
        private static void SetHourCount(CommPrimitive comm1)
        {
            int hour = comm1.time.Hours;
            if (HourlyCount.ContainsKey(hour))
            {
                HourlyCount[hour]++;
            }
            else
            {
                HourlyCount.Add(hour, 1);
            }
        }

        /// <summary>
        /// Main
        /// </summary>
        public static void Main()
        {

            Thread thread1 = new Thread(ConsolePipeReader);
            thread1.Start();
            Thread thread2 = new Thread(OperationsThread);
            thread2.Start();
            Console.ReadKey();

        }

        /// <summary>
        /// Main thread
        /// </summary>
        private static void OperationsThread()
        {
            Console.WriteLine("In operations..");
            double avg = GetDailyAverage();
            double avg1 = GetDailyAverage(new DateTime(2020, 01, 01));
            GetHourlyAverage(4);
        }
        /// <summary>
        /// This method gets the daily average. By default, it calculates daily average from 1st Jan 2000
        /// </summary>
        /// <returns></returns>

        private static double GetDailyAverage()
        {
            DateTime date = new DateTime(2000, 01, 01);
            return GetDailyAverage(date);

        }

        /// <summary>
        /// This method gets average footfall from given date.
        /// </summary>
        /// <param name="date"> Start date for average to be computed</param>
        /// <returns>average</returns>

        private static double GetDailyAverage(DateTime date)
        {
            IEnumerable<int> obj = from a in DailyCount where a.Key >= date select a.Value;
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
        private static double GetHourlyAverage(int hour)
        {
            try
            {
                int count = GetCountOfHour(hour);
                double avg = (double)count / DailyCount.Count;
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
        private static int GetCountOnDate(DateTime date)
        {
            if (DailyCount.ContainsKey(date))
            {
                return DailyCount[date];
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
        private static int GetCountOfHour(int hour)
        {
            if (HourlyCount.ContainsKey(hour))
            {
                return HourlyCount[hour];
            }
            else
            {
                return 0;
            }
        }

        //private double GetDayOfTheWeekAverage(string day)
        //{
        //    IEnumerable<>


        //}

    }
}