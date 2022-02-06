using System;
using Xunit;

namespace FileLogger
{
    public class FileLogger_Log
    {
        [Fact]
        public void AppendsMessageToLogFile()
        {
            var logger = new FileLogger();
            var msg = Guid.NewGuid().ToString();
            
            logger.Log(msg);

            var fileContents = System.IO.File.ReadAllText("log.txt");

            Assert.Contains(msg, fileContents);
        }

        [Fact]
        public void AppendsMessageToLogFileWithCurrentTimePrefix()
        {
            var logger = new FileLogger();
            var msg = Guid.NewGuid().ToString();
            string dateString = DateTime.Today.ToString("yyyy-MM-dd");

            logger.Log(msg);

            var fileContents = System.IO.File.ReadAllText("log.txt");

            Assert.Contains(dateString, fileContents);
        }
    }
}