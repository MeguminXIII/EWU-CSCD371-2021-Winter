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
        public override string ClassName { get; set; }
        public string? FilePath { get; set; }

        public FileLogger(string filePath)
        {
            this.FilePath = filePath;
            this.ClassName = "FileLogger";
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (FilePath == null)
                throw new ArgumentNullException(FilePath);
            StreamWriter messageAppend = File.AppendText(FilePath);
            
            string dateAndTime = DateTime.Now.ToString("yyyy-mm-dd-h:m:s");

            messageAppend.WriteLine("Date and Time: " + dateAndTime);
            messageAppend.WriteLine(ClassName);
            messageAppend.WriteLine(logLevel);
            messageAppend.WriteLine(message);
        }
    }
}
