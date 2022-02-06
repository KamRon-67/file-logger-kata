using System.IO;

namespace FileLogger
{
    public class FileLogger
    {
        public void Log(string message)
        {
            using var writer = File.AppendText("log.txt");
            
            writer.WriteLine(message);
        }
    }
}