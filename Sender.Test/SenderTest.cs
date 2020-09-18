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

            string expectedPath = Directory.GetCurrentDirectory() + @"\FootFallEntries.csv";

            Assert.True(expectedPath == ReadCsvFileAndExtarctData.RetrieveCsvFilePath());
        }

        [Fact]

        public void WhenValidStringIsPassedToSplitCsvFileMethodThenSplitToDateTimeCorrectly()
        {
            ReadCsvFileAndExtarctData obj = new ReadCsvFileAndExtarctData();

            string eachrow = "01/01/2020,16:23:33";
            DateAndTime dateAndTimeObj = new DateAndTime();
            dateAndTimeObj = SplitCsvFileAndReturnData.SplitCsvFileAndReturnDateAndTime (eachrow);

            Assert.True(dateAndTimeObj.dateAndTime.ToString() == "01/01/2020 16:23:33");
        }
        [Fact]
        public void WhenDateIsIncorrectlyPassedToSplitCsvFileMethodThenThrowException()
        {
            string eachrow = "01/21/2020,16:23:33";
            DateAndTime dateAndTimeObj = new DateAndTime();

            Assert.Throws<FormatException>(() => dateAndTimeObj = SplitCsvFileAndReturnData.SplitCsvFileAndReturnDateAndTime (eachrow));
        }

        [Fact]
        public void WhenTimeIsIncorrectlyPassedToSplitCsvFileMethodThenThrowException()
        {
            
            string eachrow = "01/12/2020,16:60:33";
            DateAndTime dateAndTimeObj = new DateAndTime();

            Assert.Throws<FormatException>(() => dateAndTimeObj = SplitCsvFileAndReturnData.SplitCsvFileAndReturnDateAndTime(eachrow));
        }
    }
}
