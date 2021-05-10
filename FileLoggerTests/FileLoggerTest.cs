using System;
using Xunit;
using System.IO;

namespace FileLoggerTests
{
    public class FileLoggerTests
    {
        [Fact]
        public void Append_Message_To_Log_File()
        {
            var log = new FileLogger.FileLogger();
            var msg = Guid.NewGuid().ToString();

            log.Log(msg);

            var fileContents = File.ReadAllText("log.txt");

            Assert.Contains(msg, fileContents);
        }

        [Fact]
        public void Append_Message_To_Log_File_With_Current_Time_Prefix()
        {
            var log = new FileLogger.FileLogger();
            var msg = Guid.NewGuid().ToString();
            string dateString = DateTime.Today.ToString("yyyy-MM-dd");

            log.Log(msg);

            var fileContents = File.ReadAllText("log.txt");

            Assert.Contains(dateString, fileContents);
        }
    }
}
