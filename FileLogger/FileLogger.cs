using System;
using System.IO;

namespace FileLogger
{
    public class SystemDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }

    public class FileLogger
    {
        public FileLogger(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public FileLogger() : this(new SystemDateTime())
        {
        }

        private readonly IDateTime _dateTime;

        public void Log(string message)
        {

            var todayString = DateTime.Today.ToString("yyyy-MM-dd");

            var fileName = $"log{todayString}.txt";

            using var writer = File.AppendText(fileName);

            string dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            writer.WriteLine($"{dateString} {message}");
        }
    }
}