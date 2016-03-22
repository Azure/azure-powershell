using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Logger
{
    public class Logger
    {
        private static Action<string> WriteWarningAction { get; set; }

        private static Action<string> WriteDebugAction { get; set; }

        private static Action<string> WriteVerboseAction { get; set; }

        public Logger(Action<string> writeWarning,
                      Action<string> writeDebug,
                      Action<string> writeVerbose)
        {
            WriteWarningAction = writeWarning;
            WriteDebugAction = writeDebug;
            WriteVerboseAction = writeVerbose;
        }

        public static void WriteVerbose(string text)
        {
            WriteVerboseAction(text);
        }

        public static void WriteDebug(string text)
        {
            WriteDebugAction(text);
        }

        public static void WriteWarning(string text)
        {
            WriteWarningAction(text);
        }
    }
}
