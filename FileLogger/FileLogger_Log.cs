using System;
using System.IO;
using Xunit;

namespace FileLogger
{
    public class FileLogger_Log
    {
        private FileLogger _logger = new FileLogger();
        private string _testMessage = Guid.NewGuid().ToString();
        private string GetFileName()
        {
            string dateString = DateTime.Today.ToString("yyyy-MM-dd");

            return $"log{dateString}.txt";
        }

        [Fact]
        public void AppendsMessageToLogFile()
        {
            _logger.Log(_testMessage);

            var fileContents = File.ReadAllText(GetFileName());

            Assert.Contains(_testMessage, fileContents);
        }

        [Fact]
        public void AppendsMessageToLogFileWithCurrentTimePrefix()
        {
            string dateString = DateTime.Today.ToString("yyyy-MM-dd");

            _logger.Log(_testMessage);

            var fileContents = File.ReadAllText(GetFileName());

            Assert.Contains(dateString, fileContents);
        }

        [Fact]
        public void AppendsMessageToLogFileNameForToday()
        {
            string expectedfileName = GetFileName();

            _logger.Log(_testMessage);

            Assert.True(File.Exists(GetFileName()));
        }

        [Fact]
        public void CreatesNewFileOnNewDay()
        {
            DateTime firstDate = new DateTime(2021, 03, 19, 23, 59, 59);
            DateTime secondDate = firstDate.AddMinutes(1);
            string expectedfileName = "log2022-02-06.txt";

            var fakeDateTime = new FakeDateTime();

            var logger = new FileLogger(fakeDateTime);
            fakeDateTime.Now = firstDate;
            logger.Log("foo");

            fakeDateTime.Now = secondDate;
            logger.Log(_testMessage);
            
            Assert.True(File.Exists(expectedfileName));
        }

        public class FakeDateTime : IDateTime
        {
            public DateTime Now { get; set; } = DateTime.Now;
        }
    }
}