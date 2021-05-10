using System;
using System.IO;

namespace FileLogger
{
    public class FileLogger
    {
        public void Log(string message)
        {
            using var writer = File.AppendText("log.txt");

            string dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            writer.WriteLine($"{dateString} {message}");
        }
    }
}
