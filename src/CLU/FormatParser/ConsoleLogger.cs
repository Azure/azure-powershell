using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatParser
{
    public class ConsoleLogger : IToolsLogger
    {
        public void WriteError(string error)
        {
            Console.WriteLine($"### ERROR {error}");
        }

        public void WriteMessage(string message)
        {
            //Console.WriteLine(message);
        }

        public void WriteWarning(string message)
        {
            Console.WriteLine($"Warning: {message}");
        }
    }
}
