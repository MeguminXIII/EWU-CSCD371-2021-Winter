using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {

        static public void Main()
        {
            LogFactory logFactory= new LogFactory();
            BaseLogger logger = logFactory.CreateLogger("FileLogger");
            logger.Log((LogLevel)2 , "This is a message" );


        }
    }
}
