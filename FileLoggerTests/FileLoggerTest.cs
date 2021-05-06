using System;
using Xunit;
using FileLogger;
using System.IO;

namespace FileLoggerTests
{
    public class FileLoggerTests
    {
        [Fact]
        public void Log_Append_Test()
        {
            var path = @"";
            var log = new FileLogger.FileLogger();
            log.Log("Texttext");
            string text = File.ReadAllText(path);
            Assert.EndsWith("Texttext", text);
        }

        [Fact]
        public void GetFileIfExistsTest()
        {

        }
    }
}
