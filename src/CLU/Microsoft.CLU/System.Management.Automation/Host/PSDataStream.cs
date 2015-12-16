using System.Diagnostics;

namespace System.Management.Automation
{
    /// <summary>
    /// The type that exposes methods to perform read and write on various PSDataStream.
    /// </summary>
    internal class PSDataStream : IDataStream
    {
        /// <summary>
        /// Gets the streams.
        /// </summary>
        public PSDataStreams Streams
        {
            get
            {
                return _dataStreams;
            }
        }

        /// <summary>
        /// Creates an instance of PSDataStream.
        /// </summary>
        /// <param name="dataStreams">The streams to use</param>
        public PSDataStream(PSDataStreams dataStreams)
        {
            Debug.Assert(dataStreams != null);
            _dataStreams = dataStreams;
        }

        /// <summary>
        /// Write a debug line to debug stream.
        /// </summary>
        /// <param name="message">The message</param>
        public void WriteDebugLine(string message)
        {
            _dataStreams.Debug.Add(new DebugRecord(message));
        }

        /// <summary>
        /// Write an exception line to error stream.
        /// </summary>
        /// <param name="exception">The exception to write</param>
        public void WriteExceptionLine(Exception exception)
        {
            _dataStreams.Error.Add(new ErrorRecord(exception, "", ErrorCategory.NotSpecified, null));
        }

        /// <summary>
        /// Write an error line to error stream.
        /// </summary>
        /// <param name="message">The message</param>
        public void WriteErrorLine(string message)
        {
            _dataStreams.Error.Add(new ErrorRecord(new Exception(message), "", ErrorCategory.NotSpecified, null));
        }

        /// <summary>
        /// Write a progress record to progress stream.
        /// </summary>
        /// <param name="sourceId">The source id</param>
        /// <param name="record">The record</param>
        public void WriteProgress(long sourceId, ProgressRecord record)
        {
            _dataStreams.Progress.Add(record);
        }

        /// <summary>
        /// Writes a verbose line to verbose stream.
        /// </summary>
        /// <param name="message">The message</param>
        public void WriteVerboseLine(string message)
        {
            _dataStreams.Verbose.Add(new VerboseRecord(message));
        }

        /// <summary>
        /// Writes a warning line to warning stream.
        /// </summary>
        /// <param name="message">The message</param>
        public void WriteWarningLine(string message)
        {
            _dataStreams.Warning.Add(new WarningRecord(message));
        }

        /// <summary>
        /// Write a string line.
        /// </summary>
        /// <param name="value">The value to write</param>
        public void WriteLine(string value)
        {
            // NOP: Ignore when running under runspace
        }

        /// <summary>
        /// Write a string line.
        /// </summary>
        /// <param name="foregroundColor">The text foreground color</param>
        /// <param name="backgroundColor">The text background color</param>
        /// <param name="value">The value to write</param>
        public void WriteLine(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            // NOP: Ignore when running under runspace
        }

        /// <summary>
        /// Write a string value.
        /// </summary>
        /// <param name="value">The value to write</param>
        public void Write(string value)
        {
            // NOP: Ignore when running under runspace
        }

        /// <summary>
        /// Write a string value.
        /// </summary>
        /// <param name="foregroundColor">The text foreground color</param>
        /// <param name="backgroundColor">The text background color</param>
        /// <param name="value">The value to write</param>
        public void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            // NOP: Ignore when running under runspace
        }

        /// <summary>
        /// The streams to use.
        /// </summary>
        PSDataStreams _dataStreams;
    }
}
