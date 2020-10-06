using System;
using System.Globalization;
using System.Linq;
using Xunit;
using static System.Double;

namespace Receiver.Test
{
    public class ReceiverTests
    {



        [Fact]
        public void WhenTwoDatesArePassedCheckIfNumberOfWeeksIsCorrect()
        {
            var date1 = new DateTime(2020, 09, 14);
            var date2 = new DateTime(2020, 09, 21);
            var numberOfWeeks = WhenTwoDatesArePassedCheckIfNumberOfWeeksIsCorrectGen(date1, date2);
            Assert.False(2 == numberOfWeeks);
        }

        
        [Fact]
        public void CheckFileSystem()
        {
            var ret = DataToCsv.WriteToCsv("Hello world");
            Assert.True(ret == 1);
        }

        [Fact]
        public void CheckIfFilePathIsCorrect()
        {
            const string fileName = @"Output.csv";
            var filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            Assert.Equal(filePath, DataToCsv.GetFilePath());
        }


        private static int WhenTwoDatesArePassedCheckIfNumberOfWeeksIsCorrectGen(DateTime date1, DateTime date2)
        {
            var numberOfWeeks = DataProcessor.GetNumberOfWeeks(date1, date2);
            return numberOfWeeks;
        }

        [Fact]
        public void WhenSetDayCounterAddsCountCheckValidity()
        {
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
            var date1 = new DateTime(2020, 12, 3);
            var date2 = new DateTime(2020, 10, 20);
            CountSetters.SetDayCount(date1);
            CountSetters.SetDayCount(date1);
            CountSetters.SetDayCount(date1);
            CountSetters.SetDayCount(date2);
            CountSetters.SetDayCount(date2);
            var count = CountSetters.DailyCount.Count;
            Assert.True(count == 2);
            var counter1 = CountSetters.DailyCount[date1];
            var counter2 = CountSetters.DailyCount[date2];
            Assert.True(counter1 == 3);
            Assert.True(counter2 == 2);
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
        }

        [Fact]
        //Use helper functions in tests. Property Based testing: Look it up.
        public void WhenSetHourCounterAddsCountCheckValidity()
        {
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
            var date1 = new DateTime(2020, 12, 3, 10, 12, 15);
            var date2 = new DateTime(2020, 10, 20, 11, 12, 13);
            var date3 = new DateTime(2020, 10, 20, 12, 13, 13);
            var date4 = new DateTime(2020, 10, 20, 12, 12, 13);
            CountSetters.SetHourCount(date1);
            CountSetters.SetHourCount(date2);
            CountSetters.SetHourCount(date3);
            CountSetters.SetHourCount(date4);
            var count = CountSetters.HourlyCount.Count;
            Assert.True(count == 3);
            var counter1 = CountSetters.HourlyCount[10];
            var counter2 = CountSetters.HourlyCount[11];
            var counter3 = CountSetters.HourlyCount[12];
            Assert.True(counter1 == 1);
            Assert.True(counter2 == 1);
            Assert.True(counter3 == 2);
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
        }

        [Fact]
        public void WhenPipeInputGivenSetDailyAndHourlyCounter()
        {
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
            var date1 = new DateTime(2020, 10, 12, 10, 11, 14);
            var pipeIp = date1.ToString(CultureInfo.InvariantCulture);
            PipeReader.AddEventToDs(pipeIp);
            var dayCount = CountSetters.DailyCount.Count;
            var hourCount = CountSetters.HourlyCount.Count;
            Assert.True((dayCount == 1) && hourCount == 1);
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
        }

        [Fact]
        public void CheckNumberOfDaysBetweenDates()
        {
            var date1 = DateTime.Now;
            var date2 = DateTime.Now.AddDays(-1);
            var numberOfDays = DataProcessor.GetNumberOfDaysBetweenDates(date1, date2);
            Assert.True(numberOfDays == 2);
        }

        [Fact]
        public void CheckMonthlyAverage()
        {
            SetTestData();
            var dailyAverageForMonth = DataProcessor.GetAverageForCurrentMonth();
            DateTime date = GetTodaysDate();
            Assert.True(Math.Abs(dailyAverageForMonth - ((double)0 / 22)) < Epsilon);
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
        }

        [Fact]
        public void CheckDailyAverage()
        {
            SetTestData();
            var dailyAverage = DataProcessor.GetDailyAverage();
            DateTime date1 = new DateTime(2000, 01, 01);
            DateTime date2 = DateTime.Now.Date;
            var numberOfDays = DataProcessor.GetNumberOfDaysBetweenDates(date1, date2) ;
            Assert.True(Math.Abs((double) 7/ numberOfDays - dailyAverage) < Epsilon);
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
        }

        [Fact]
        public void CheckAverageFromDate()
        {
            SetTestData();
            var averageFrom2020 = DataProcessor.GetDailyAverage(new DateTime(2020, 01, 01));
            var date1 = DateTime.Now.Date;
            var date2 = new DateTime(2020, 01, 01);
            var numberOfDays = DataProcessor.GetNumberOfDaysBetweenDates(date1, date2);
            Assert.True(Math.Abs((double)4 / numberOfDays - averageFrom2020) < Epsilon);
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
        }

        [Fact]
        public void CheckHourlyAverage()
        {
            SetTestData();
            var hourlyAverage = DataProcessor.GetHourlyAverage(0);
            var date1 = CountSetters.DailyCount.ElementAt(0).Key;
            var date2 = GetTodaysDate();
            var numberOfDays = DataProcessor.GetNumberOfDaysBetweenDates(date1, date2);
            Assert.True(Math.Abs(hourlyAverage - (double)1 / numberOfDays) < Epsilon);
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
        }

        [Fact]
        public void WhenNoInputIsGivenHourlyAverageMustThrowError()
        {
            var hourlyAverage = DataProcessor.GetHourlyAverage(0);
            Assert.True((hourlyAverage == 0));
        }

        [Fact]
        public void WhenNoInputIsGivenWeeklyAverageMustBe0()
        {
            var weeklyAverage = DataProcessor.GetWeeklyAverage(DayOfWeek.Friday);
            Assert.True(weeklyAverage == 0);
        }

        [Fact]
        public void CheckWeeklyAverage()
        {
            SetTestData();
            var averageForSunday = DataProcessor.GetWeeklyAverage(DayOfWeek.Saturday);
            Assert.True(Math.Abs(averageForSunday - (double)1 / 39) < Epsilon);
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
        }

        private void SetTestData()
        {
            CountSetters.DailyCount.Clear();
            CountSetters.HourlyCount.Clear();
            var date1 = new DateTime(2020, 09, 12, 10, 10, 13);
            var date2 = new DateTime(2020, 09, 21, 00, 12, 59);
            var date3 = new DateTime(2020, 09, 20, 11, 12, 59);
            var date4 = new DateTime(2020, 09, 04, 15, 14, 31);
            var date5 = new DateTime(2002, 09, 04, 15, 14, 31);
            var date7 = new DateTime(2001, 09, 06, 15, 14, 31);
            var date6 = new DateTime(2003, 09, 23, 15, 14, 31);
            CountSetters.SetDayCount(date1);
            CountSetters.SetDayCount(date2);
            CountSetters.SetDayCount(date3);
            CountSetters.SetDayCount(date4);
            CountSetters.SetDayCount(date5);
            CountSetters.SetDayCount(date7);
            CountSetters.SetDayCount(date6);

            CountSetters.SetHourCount(date1);
            CountSetters.SetHourCount(date2);
            CountSetters.SetHourCount(date3);
            CountSetters.SetHourCount(date4);
            CountSetters.SetHourCount(date5);
            CountSetters.SetHourCount(date6);
            CountSetters.SetHourCount(date7);
        }

        private DateTime GetTodaysDate()
        {
            return DateTime.Now;
        }




    }
}
