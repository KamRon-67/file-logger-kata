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
            string fileName = GetFileName();
            using var writer = File.AppendText(fileName);

            string dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            writer.WriteLine($"{dateString} {message}");
            writer.Close();
        }

        private string GetFileName()
        {
            if(_dateTime.Now.DayOfWeek == DayOfWeek.Sunday
                ||
                    _dateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                    {
                return "weekend.txt";
            }

            var todayString = DateTime.Today.ToString("yyyy-MM-dd");

            return $"log{todayString}.txt";
        }
    }
}