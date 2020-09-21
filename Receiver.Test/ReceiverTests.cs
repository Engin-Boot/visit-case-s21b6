using System;
using Receiver;
using Xunit;

namespace Receiver.Tests
{
    public class ReceiverTests
    {
        [Fact]
        public void WhenTwoDatesArePassedCheckIfNumberOfWeeksIsCorrect()
        {
            var date1 = new DateTime(2020, 09, 14);
            var date2 = new DateTime(2020, 09, 21);
            var numberOfWeeks = WhenTwoDatesArePassedCheckIfNumberOfWeeksIsCorrectGen(date1, date1);
            Assert.False(2 == numberOfWeeks);
        }

        public int WhenTwoDatesArePassedCheckIfNumberOfWeeksIsCorrectGen(DateTime date1, DateTime date2)
        {
            var numberOfWeeks = DataProcessor.GetNumberOfWeeks(date1, date2);
            return numberOfWeeks;
        }

        public void SetTestData()
        {

            CountSetters.DailyCount.Add(new DateTime(2002, 12, 15), 1);
            CountSetters.DailyCount[new DateTime(2002, 12, 15)]++;
            CountSetters.DailyCount[new DateTime(2002, 12, 15)]++;
            CountSetters.DailyCount[new DateTime(2002, 12, 15)]++;
        }


    }
}
