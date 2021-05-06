using System;
using System.IO;

namespace FileLogger
{
    public class FileLogger
    {
        public void Log(string message)
        {
            var path = @"";
            var prefix = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(prefix + " " + message);
            }
        }

        public File GetFileIfExists()
        {
        }
    }
}
