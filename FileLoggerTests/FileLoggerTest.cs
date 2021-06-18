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

        [Fact]
        public void Check_If_File_Exist_If_Not_Create_And_Append()
        {
            var IfFileExistMessage = File.Exists("log.txt");

            var log = new FileLogger.FileLogger();
            var msg = Guid.NewGuid().ToString();
            string dateString = DateTime.Today.ToString("yyyy-MM-dd");

            log.Log(msg);

            var fileContents = File.ReadAllText("log.txt");
        }
    }
}
