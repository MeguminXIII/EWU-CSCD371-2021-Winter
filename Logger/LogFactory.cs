using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private string? FilePath;


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
            {
                string nullException = "className is null in CreateLogger method";
                throw new ArgumentNullException(nullException);
            }
           

            BaseLogger? logger = null;
            if (className == nameof(FileLogger))
            {
                ClassName = className;
                ConfigureFileLogger(InputFileName()!);

                if (FilePath == null)
                {
                    return null!;
                }

                while (!File.Exists(FilePath))
                {
                    Console.WriteLine("No file found please try again");
                    ConfigureFileLogger(InputFileName()!);
                }

                logger = new FileLogger(FilePath) { ClassName = className };
            }

            if (logger == null)
                throw new NullReferenceException("BaseLogger is null, try again");
            return logger;
        }

        static private string? InputFileName()
        {
            Console.WriteLine("Please input a filepath");
            return @Console.ReadLine()!;
        }

        private void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }

    }
}
