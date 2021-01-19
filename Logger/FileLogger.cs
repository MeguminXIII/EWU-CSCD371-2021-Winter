using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    class FileLogger : BaseLogger
    {
        public override string ClassName { get; set; }
        private string? FilePath { get; set; }

        public FileLogger(string filePath)
        {
            this.FilePath = filePath;
            this.ClassName = "FileLogger";
        }

        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter messageAppend;
            if (FilePath == null)
                throw new ArgumentNullException(FilePath);
            messageAppend = new StreamWriter(FilePath);

            string dateAndTime = DateTime.Now.ToString("yyyy-mm-dd-h:m:s");

            messageAppend.WriteLine("Date and Time: "
                + dateAndTime + "\r\n"
                + ClassName + "\r\n"
                + logLevel + "\r\n" 
                + message);
        }
    }
}
