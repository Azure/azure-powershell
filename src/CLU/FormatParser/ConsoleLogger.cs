using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatParser
{
    public class ConsoleLogger : IToolsLogger
    {
        private List<ValidationRecord> _records = new List<ValidationRecord>();

        public List<ValidationRecord> Records { get { return _records; } }

        public string Assembly { get; set; }
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

        public void LogRecord(ValidationRecord record)
        {
            if (!string.IsNullOrWhiteSpace(Assembly))
            {
                record.Assembly = Assembly;
            }

            _records.Add(record);
        }
    }
}
