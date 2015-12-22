using Microsoft.CLU;
using System.Diagnostics;

namespace System.Management.Automation
{
    using Strings = Microsoft.CLU.Common.Properties.Strings;

    /// <summary>
    /// The type that exposes methods to perform read and write on various console streams.
    /// </summary>
    internal class ConsoleDataStream : IDataStream
    {
        /// <summary>
        /// Creates an instance of ConsoleDataStream.
        /// </summary>
        /// <param name="consoleInputOutput">The information of console to use</param>
        public ConsoleDataStream(IConsoleInputOutput consoleInputOutput)
        {
            Debug.Assert(consoleInputOutput != null);
            _console = consoleInputOutput;
        }

        /// <summary>
        /// Write a debug line to debug stream.
        /// </summary>
        /// <param name="message">The message</param>
        public void WriteDebugLine(string message)
        {
            _console.WriteLine(string.Format(Strings.DebugLineFormat, message));
        }

        /// <summary>
        /// Write an exception line to error stream.
        /// </summary>
        /// <param name="exception">The exception to write</param>
        public void WriteExceptionLine(Exception exception)
        {
            Debug.Assert(exception != null);
            if (exception.InnerException != null)
            {
                WriteErrorLine(Strings.CmdletHelp_GenerateSingleCommandHelp_TxtInnerException);
                WriteExceptionLine(exception.InnerException);
            }

            WriteErrorLine(exception.Message);
        }

        /// <summary>
        /// Write an error line to error stream.
        /// </summary>
        /// <param name="message">The message</param>
        public void WriteErrorLine(string message)
        {
            _console.WriteErrorLine(message);
        }

        /// <summary>
        /// Write a progress record to progress stream.
        /// </summary>
        /// <param name="sourceId">The source id</param>
        /// <param name="record">The record</param>
        public void WriteProgress(long sourceId, ProgressRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            _console.Write("\r");

            var width = _console.WindowWidth - 1;

            if (record.RecordType == ProgressRecordType.Completed)
            {
                var statusLine = string.Format(Strings.ConsoleDataStream_WriteProgress_StatusLineCompleted, record.Activity, record.StatusDescription);
                _console.Write(statusLine);
                for (int pos = statusLine.Length; pos < width; ++pos)
                {
                    _console.Write(" ");
                }
                _console.WriteLine();
            }
            else
            {
                var statusLine = string.Format(Strings.ConsoleDataStream_WriteProgress_StatusLineInProgress, record.Activity, record.StatusDescription, record.CurrentOperation, record.SecondsRemaining);
                // Subtract what's already known to be needed:
                width = Math.Max(1, width - (statusLine.Length + 3));

                var chunkSize = (100 / width) + 1;

                _console.Write(statusLine);
                _console.Write(" [");
                int pos = 0;
                for (; pos < record.PercentComplete / chunkSize; ++pos)
                {
                    _console.Write("*");
                }
                for (; pos < 100 / chunkSize; ++pos)
                {
                    _console.Write(" ");
                }
                _console.Write("]");
                for (; pos < width; ++pos)
                {
                    _console.Write(" ");
                }
            }
        }

        /// <summary>
        /// Writes a verbose line to verbose stream.
        /// </summary>
        /// <param name="message">The message</param>
        public void WriteVerboseLine(string message)
        {
            _console.WriteLine(string.Format(Strings.VerboseLineFormat,message));
        }

        /// <summary>
        /// Writes a warning line to warning stream.
        /// </summary>
        /// <param name="message">The message</param>
        public void WriteWarningLine(string message)
        {
            _console.WriteWarningLine(message);
        }

        /// <summary>
        /// Write a string line.
        /// </summary>
        /// <param name="value">The value to write</param>
        public void WriteLine(string value)
        {
            _console.WriteLine(value);
        }

        /// <summary>
        /// Write a string line.
        /// </summary>
        /// <param name="foregroundColor">The text foreground color</param>
        /// <param name="backgroundColor">The text background color</param>
        /// <param name="value">The value to write</param>
        public void WriteLine(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            _console.WriteLine(foregroundColor, backgroundColor, value);
        }

        /// <summary>
        /// Write a string value.
        /// </summary>
        /// <param name="value">The value to write</param>
        public void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            _console.Write(foregroundColor, backgroundColor, value);
        }

        /// <summary>
        /// Write a string value.
        /// </summary>
        /// <param name="foregroundColor">The text foreground color</param>
        /// <param name="backgroundColor">The text background color</param>
        /// <param name="value">The value to write</param>
        public void Write(string value)
        {
            _console.Write(value);
        }

        #region Private fields

        /// <summary>
        /// The information of console to use for read-write.
        /// </summary>
        IConsoleInputOutput _console;

        #endregion
    }
}
