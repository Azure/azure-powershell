using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.CLU
{
    /// <summary>
    /// All user-code STDIN/STDOUT interaction must avoid using System.Console directly, as
    /// does most framework code (except pipeline processing). This interfaces is used for
    /// the framework's processing, as well as the implementation of the Cmdlet base class'
    /// I/O APIs.
    /// </summary>
    public interface IConsoleInputOutput
    {
        /// <summary>
        /// Tells whether the STDIN stream has been redirected from a file or pipe.
        /// </summary>
        /// <remarks>If this is true, your code is not doing console I/O</remarks>
        bool IsInputRedirected { get; }

        /// <summary>
        /// Tells whether the STDOUT stream has been redirected to a file or pipe.
        /// </summary>
        /// <remarks>If this is true, your code is not doing console I/O</remarks>
        bool IsOutputRedirected { get; }

        /// <summary>
        /// Gives the width of the console window, if there is one.
        /// </summary>
        int WindowWidth { get; }

        /// <summary>
        /// The TextReader that represents the input stream of a command process.
        /// </summary>
        /// <remarks>
        /// Typically, this is STDIN, but it could be reassigned for unit testing, for example.
        /// </remarks>
        TextReader Input { get; }

        /// <summary>
        /// The TextWriter that represents the output stream of a command process.
        /// </summary>
        /// <remarks>
        /// Typically, this is STDOUT, but it could be reassigned for unit testing, for example.
        /// </remarks>
        TextWriter PipelineOutput { get; }

        /// <summary>
        /// The TextWriter that represents the error stream of a command process.
        /// </summary>
        /// <remarks>
        /// Typically, this is STDERR, but it could be reassigned for unit testing, for example.
        /// </remarks>
        TextWriter TextOutput { get; }

        #region The Read methods

        /// <summary>
        /// Read a line of text from the input stream.
        /// </summary>
        /// <returns>A line of text.</returns>
        string ReadLine();

        /// <summary>
        /// Read a keystroke from the console, without displaying it.
        /// </summary>
        /// <returns>A record representing the key that was struck</returns>
        ConsoleKeyInfo ReadKey();

        /// <summary>
        /// Prompt user for choice.
        /// </summary>
        /// <param name="caption">The choice caption</param>
        /// <param name="message">The choice message</param>
        /// <param name="choices">The collection of choices</param>
        /// <param name="defaultChoice">The default choice</param>
        /// <returns></returns>
        int PromptForChoice(string caption, string message, IEnumerable<Choice> choices, int defaultChoice);

#endregion

#region The Write methods

        /// <summary>
        /// Write a string value to the error stream.
        /// </summary>
        /// <param name="value">The value to write</param>
        void Write(string value);

        /// <summary>
        /// Write a formatted string to the error stream.
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="values">An array of objects to write using format</param>
        void Write(string format, params object[] values);

        /// <summary>
        /// Write a string value to the  to the error stream, changing the color of the text.
        /// </summary>
        /// <param name="foregroundColor">The foreground color</param>
        /// <param name="backgroundColor">The background color</param>
        /// <param name="value">The value to write</param>
        void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value);

#endregion

#region The WriteLine methods

        /// <summary>
        /// Write a new line character to the error stream.
        /// </summary>
        void WriteLine();

        /// <summary>
        /// Write a string value to the error stream. Append a new line character.
        /// </summary>
        /// <param name="value">The value to write</param>
        void WriteLine(string value);

        /// <summary>
        /// Write a formatted string to the error stream. Append a new line character.
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="values">An array of objects to write using format</param>
        void WriteLine(string format, params object [] values);

        /// <summary>
        /// Write a string value to the error stream, changing the color of the text. Append a new line character.
        /// </summary>
        /// <param name="foregroundColor">The foreground color</param>
        /// <param name="backgroundColor">The background color</param>
        /// <param name="value">The value to write</param>
        void WriteLine(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value);

        /// <summary>
        /// Write a 'DEBUG' message to the error stream. Append a new line character.
        /// </summary>
        /// <param name="message">The message to write</param>
        void WriteDebugLine(string message);

        /// <summary>
        /// Write a 'ERROR' message to the error stream. Append a new line character.
        /// </summary>
        /// <param name="message">The message to write</param>
        void WriteErrorLine(string message);

        /// <summary>
        /// Write a 'VERBOSE' message to the error stream. Append a new line character.
        /// </summary>
        /// <param name="message">The message to write</param>
        void WriteVerboseLine(string message);

        /// <summary>
        /// Write a 'WARNING' message to the error stream. Append a new line character.
        /// </summary>
        /// <param name="message">The message to write</param>
        void WriteWarningLine(string message);

#endregion
    }

    /// <summary>
    /// Type represents a choice to be presented to user.
    /// </summary>
    public class Choice
    {
        /// <summary>
        /// The label
        /// </summary>
        public string Label { get; private set; }

        /// <summary>
        /// The help message
        /// </summary>
        public string HelpMessage { get; set; }

        /// <summary>
        /// Creates an instance of Choice.
        /// </summary>
        /// <param name="label"></param>
        public Choice(string label) { Label = label; }

        /// <summary>
        /// Creates an instance of Choice.
        /// </summary>
        /// <param name="label">The choice label</param>
        /// <param name="helpMessage">The choice help message</param>
        public Choice(string label, string helpMessage) { Label = label; HelpMessage = helpMessage; }
    }
}
