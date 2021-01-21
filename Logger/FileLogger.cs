using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string? FilePath { get; set; }
        public override string ClassName { get; set; } = "FileLogger";

        public FileLogger(string filePath)
        {
            this.FilePath = filePath;
        }

        public string GetFilePath()
        {
            return this.FilePath!;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (FilePath == null)
                throw new ArgumentNullException(FilePath);
            TextWriter messageAppend = new StreamWriter(FilePath, true);
            
            string dateAndTime = DateTime.Now.ToString("yyyy-mm-dd-h:m:s");

            messageAppend.WriteLine("Date and Time: " + dateAndTime);
            messageAppend.WriteLine(ClassName);
            messageAppend.WriteLine(logLevel);
            messageAppend.WriteLine(message);
            messageAppend.Close();
        }
    }
}
