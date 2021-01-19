using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private string? _ClassName;
        public string ClassName
        {
            get
            {
                return _ClassName!;
            }
            set => _ClassName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public BaseLogger CreateLogger(string className)
        {
            if (className == null)
                throw new ArgumentNullException();

            BaseLogger? logger = null;
            if (className == nameof(FileLogger))
            {
                ClassName = className;
                string? filePath = ConfigureFileLogger();

                while (filePath == null)
                {
                    Console.WriteLine("FilePath was null Please try again");
                    filePath = Console.ReadLine();
                }

                while (!File.Exists(filePath))
                {
                    Console.WriteLine("No file found please try again");
                    filePath = ConfigureFileLogger();
                }

                logger = new FileLogger(filePath!);
            }

            if (logger == null)
                    throw new NullReferenceException("BaseLogger is null, try again");
                return logger;
        }

        static private string? ConfigureFileLogger()
        {
            Console.WriteLine("Please input a filepath");
            return @Console.ReadLine();
        }
    }
}
