using System;
using System.IO;

namespace FileLogger
{
    public class FileLogger
    {
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