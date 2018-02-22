using System.Collections.Concurrent;
using NLog;
using NLog.Targets;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// NLog is used by the ADLS dataplane sdk to log debug messages. We can create a custom target
    /// which basically queues the debug data to the ConcurrentQueue for debug messages.
    /// https://github.com/NLog/NLog/wiki/How-to-write-a-custom-target
    /// </summary>
    [Target("AdlsLogger")]
    internal sealed class AdlsLoggerTarget : TargetWithLayout
    {
        internal ConcurrentQueue<string> DebugMessageQueue;
        protected override void Write(LogEventInfo logEvent)
        {
            string logMessage = Layout.Render(logEvent);
            DebugMessageQueue?.Enqueue(logMessage);
        }
    }
}
