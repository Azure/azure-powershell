namespace System.Management.Automation
{
    /// <summary>
    /// Entry point to perform all read-write.
    /// </summary>
    internal interface IDataStream
    {
        /// <summary>
        /// Write a debug line to debug stream.
        /// </summary>
        /// <param name="message">The message</param>
        void WriteDebugLine(string message);

        /// <summary>
        /// Write an exception line to error stream.
        /// </summary>
        /// <param name="exception">The exception to write</param>
        void WriteExceptionLine(Exception exception);

        /// <summary>
        /// Write an error line to error stream.
        /// </summary>
        /// <param name="message">The message</param>
        void WriteErrorLine(string message);

        /// <summary>
        /// Write a progress record to progress stream.
        /// </summary>
        /// <param name="sourceId">The source id</param>
        /// <param name="record">The record</param>
        void WriteProgress(long sourceId, ProgressRecord record);

        /// <summary>
        /// Writes a verbose line to verbose stream.
        /// </summary>
        /// <param name="message">The message</param>
        void WriteVerboseLine(string message);

        /// <summary>
        /// Writes a warning line to warning stream.
        /// </summary>
        /// <param name="message">The message</param>
        void WriteWarningLine(string message);

        /// <summary>
        /// Write a string line.
        /// </summary>
        /// <param name="value">The value to write</param>
        void WriteLine(string value);

        /// <summary>
        /// Write a string line.
        /// </summary>
        /// <param name="foregroundColor">The text foreground color</param>
        /// <param name="backgroundColor">The text background color</param>
        /// <param name="value">The value to write</param>
        void WriteLine(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value);

        /// <summary>
        /// Write a string value.
        /// </summary>
        /// <param name="value">The value to write</param>
        void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value);

        /// <summary>
        /// Write a string value.
        /// </summary>
        /// <param name="foregroundColor">The text foreground color</param>
        /// <param name="backgroundColor">The text background color</param>
        /// <param name="value">The value to write</param>
        void Write(string value);
    }
}
