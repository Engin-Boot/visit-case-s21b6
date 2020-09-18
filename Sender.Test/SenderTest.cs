using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Sender;

namespace Sender.Test
{
    public class SenderTest
    {
        [Fact]
        public void WhenAskForCsvFilePathReturnTheExpectedCorrectPath()
        {
            ReadCsvFileAndExtarctDateAndTime obj = new ReadCsvFileAndExtarctDateAndTime();

            string expectedPath = Directory.GetCurrentDirectory() + @"\FootFallEntries.csv";

            Assert.True(expectedPath == obj.RetrieveCsvFilePath());
        }

        [Fact]

        public void WhenValidStringIsPassedToSplitCsvFileMethodThenSplitToDateTimeCorrectly()
        {
            ReadCsvFileAndExtarctDateAndTime obj = new ReadCsvFileAndExtarctDateAndTime();

            string eachrow = "01/01/2020,16:23:33";
            ReadCsvFileAndExtarctDateAndTime.DateAndTime dateAndTimeObj = new ReadCsvFileAndExtarctDateAndTime.DateAndTime();
            dateAndTimeObj = obj.SplitCsvFileAndReturnDateAndTime(eachrow);

            Assert.True(dateAndTimeObj.dateAndTime.ToString() == "01/01/2020 16:23:33");
        }
        [Fact]
        public void WhenDateIsIncorrectlyPassedToSplitCsvFileMethodThenThrowException()
        {
            ReadCsvFileAndExtarctDateAndTime obj = new ReadCsvFileAndExtarctDateAndTime();

            string eachrow = "01/21/2020,16:23:33";
            ReadCsvFileAndExtarctDateAndTime.DateAndTime dateAndTimeObj = new ReadCsvFileAndExtarctDateAndTime.DateAndTime();

            Assert.Throws<FormatException>(() => dateAndTimeObj = obj.SplitCsvFileAndReturnDateAndTime(eachrow));
        }

        [Fact]
        public void WhenTimeIsIncorrectlyPassedToSplitCsvFileMethodThenThrowException()
        {
            ReadCsvFileAndExtarctDateAndTime obj = new ReadCsvFileAndExtarctDateAndTime();

            string eachrow = "01/12/2020,16:60:33";
            ReadCsvFileAndExtarctDateAndTime.DateAndTime dateAndTimeObj = new ReadCsvFileAndExtarctDateAndTime.DateAndTime();

            Assert.Throws<FormatException>(() => dateAndTimeObj = obj.SplitCsvFileAndReturnDateAndTime(eachrow));
        }
    }
}
