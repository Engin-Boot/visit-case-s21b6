using System;
using System.IO;
using Xunit;
using System.Collections.Generic;

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

        
        [Fact]
        public void WhenValidValuePassedToCommPrimitiveDataMemberDateThenDateIsSuccessfullyInitialized()
        {
            CommPrimitive obj = new CommPrimitive();
            obj.Date = new DateTime(2020, 12, 01, 16, 02, 33);
            Assert.True(obj.Date.ToString("dd/MM/yyyy HH:mm:ss") == "01/12/2020 16:02:33");
        }

        [Fact]
        public void WhenExtractDateAndTimeIsCalledThenDataIsRetrieved()
        {
            List<DateAndTime> AllDatesandTime = new List<DateAndTime>();
            AllDatesandTime = ExtractDataFromCsv.ExtractDateAndTime();
            Assert.True(AllDatesandTime.Count != 0);
            Assert.True(ExtractDataFromCsv.IsDataRetrieved);
        }

        
        [Fact]
        public void WhenValidListOfDateAndTimeIsPassedToPrintDataThenItGetPrintedSuccessfully()
        {
            List<DateAndTime> dateAndTimeList = ExtractDataFromCsv.ExtractDateAndTime();
            Sender.PrintData(dateAndTimeList);
            Assert.True(Sender.IsMessagePrinted);
        }
    }
}
