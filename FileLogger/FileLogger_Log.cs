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
    }
}