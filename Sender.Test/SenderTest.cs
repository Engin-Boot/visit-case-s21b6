using System;
using System.Globalization;
using System.IO;
using Xunit;

namespace Sender.Test
{
    public class SenderTest
    {
        [Fact]
        public void WhenAskForCsvFilePathReturnTheExpectedCorrectPath()
        {
            var expectedPath = Directory.GetCurrentDirectory() + @"\FootFallEntries.csv";

            Assert.True(expectedPath == ReadCsvFileAndExtarctData.RetrieveCsvFilePath());
        }

        [Fact]
        public void WhenValidStringIsPassedToSplitCsvFileMethodThenSplitToDateTimeCorrectly()
        {
            const string eachrow = "01/01/2020,16:23:33";
            var dateAndTimeObj = SplitCsvFileAndReturnData.SplitCsvFileAndReturnDateAndTime(eachrow);

            Assert.True(dateAndTimeObj.Dt.ToString(CultureInfo.InvariantCulture) == "01/01/2020 16:23:33");
        }

        [Fact]
        public void WhenDateIsIncorrectlyPassedToSplitCsvFileMethodThenThrowException()
        {
            const string eachrow = "01/21/2020,16:23:33";

            Assert.Throws<FormatException>(() => SplitCsvFileAndReturnData.SplitCsvFileAndReturnDateAndTime(eachrow));
        }

        [Fact]
        public void WhenTimeIsIncorrectlyPassedToSplitCsvFileMethodThenThrowException()
        {
            var eachrow = "01/12/2020,16:60:33";

            Assert.Throws<FormatException>(() => SplitCsvFileAndReturnData.SplitCsvFileAndReturnDateAndTime(eachrow));
        }

        [Fact]
        public void WhenExtractDateAndTimeIsCalledThenDataIsRetrieved()
        {
            var allDatesandTime = ExtractDataFromCsv.ExtractDateAndTime();
            Assert.True(allDatesandTime.Count != 0);
            Assert.True(ExtractDataFromCsv.IsDataRetrieved);
        }


        [Fact]
        public void WhenValidListOfDateAndTimeIsPassedToPrintDataThenItGetPrintedSuccessfully()
        {
            var dateAndTimeList = ExtractDataFromCsv.ExtractDateAndTime();
            Sender.PrintData(dateAndTimeList);
            Assert.True(Sender.IsMessagePrinted);
        }
    }
}
