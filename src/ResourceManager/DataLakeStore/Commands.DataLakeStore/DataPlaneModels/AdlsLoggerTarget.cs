using System.Collections.Concurrent;
using System.IO;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public delegate void WriteMessageDelegate(string message);
    [Target("AdlsLogger")]
    public sealed class AdlsLoggerTarget : TargetWithLayout
    {
        internal ConcurrentQueue<string> DebugMessageQueue;  
        public AdlsLoggerTarget()
        {
        }
        protected override void Write(LogEventInfo logEvent)
        {
            string logMessage = Layout.Render(logEvent);
            DebugMessageQueue?.Enqueue(logMessage);
        }
    }
}
