using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter22.Listing22_01
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class BookCodeWithLock
    {
        static int _Total = int.MaxValue;
        static int _Count = 0;
        static object _lockObj = new();

        public static int BookCodeLocked(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => Decrement());

            // Increment
            
                for (int i = 0; (i < _Total); i++)
                {
                     lock (_lockObj)
                    {
                    _Count++;
                    }
                }
            

            task.Wait();
            Console.WriteLine($"Count = {_Count}");

            return _Count;
        }

        static void Decrement()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                lock (_lockObj)
                {
                    _Count--;
                }
            }
        }
    }
}
