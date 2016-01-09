using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatParser
{
    public interface IToolsLogger
    {
        void WriteError(string error);
        void WriteMessage(string message);
        void WriteWarning(string message);
        void LogRecord(ValidationRecord record);
    }
}
