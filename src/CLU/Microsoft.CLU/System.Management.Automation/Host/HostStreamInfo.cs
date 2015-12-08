using System.Management.Automation.Runspaces;

namespace System.Management.Automation
{
    /// <summary>
    /// Type represents the details of streams to be used by host.
    /// </summary>
    internal class HostStreamInfo
    {
        /// <summary>
        /// The data streams.
        /// </summary>
        public IDataStream DataStream { get; set; }

        /// <summary>
        /// Indicates whether the input is redirected.
        /// </summary>
        public bool IsInputRedirected { get; set; }

        /// <summary>
        /// Indicates whether the output is redirected.
        /// </summary>
        public bool IsOutputRedirected { get; set; }

        /// <summary>
        /// The pipe to read from.
        /// </summary>
        public IPipe<string> ReadFromPipe { get; set; }

        /// <summary>
        /// The pipe to write to.
        /// </summary>
        public IPipe<string> WriteToPipe { get; set; }
    }
}
