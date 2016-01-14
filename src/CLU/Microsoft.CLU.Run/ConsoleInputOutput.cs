using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CLU.Common.Properties;

namespace Microsoft.CLU.Run
{
    /// <summary>
    /// Implementation of IConsoleInputOutput for use in the CLU framework.
    /// </summary>
    internal class ConsoleInputOutput : IConsoleInputOutput
    {
        /// <summary>
        /// Creates an instance of ConsoleInputOutput
        /// </summary>
        /// <param name="args">The commandline arguments</param>
        internal ConsoleInputOutput(string [] args)
        {
            Input = Console.In;
            PipelineOutput = Console.Out;
            TextOutput = Console.Error;
            
            _doDebug = args.Select(arg => arg.ToLowerInvariant()).Where(arg => arg.Equals("--debug") || arg.Equals("/debug")).Any();
            _doVerbose = args.Select(arg => arg.ToLowerInvariant()).Where(arg => arg.Equals("--verbose") || arg.Equals("/verbose")).Any();
        }

        /// <summary>
        /// Tells whether the STDIN stream has been redirected from a file or pipe.
        /// </summary>
        /// <remarks>If this is true, your code is not doing console I/O</remarks>
        public bool IsInputRedirected { get { return System.Console.IsInputRedirected || _inputRedirectOverride; } }

        /// <summary>
        /// Tells whether the STDOUT stream has been redirected to a file or pipe.
        /// </summary>
        /// <remarks>If this is true, your code is not doing console I/O</remarks>
        public bool IsOutputRedirected { get { return System.Console.IsOutputRedirected; } }

        /// <summary>
        /// Gives the width of the console window, if there is one.
        /// </summary>
        public int WindowWidth
        {
            get
            {
                try
                {
                    return System.Console.WindowWidth;
                }
                catch (System.IO.IOException)
                {
                    return 200;
                }
            }
        }

#if DEBUG
        /// <summary>
        /// This is mainly useful for debugging purposes, when the input pipeline is redirected programmatically,
        /// in which case the property will not be picked up at process startup.
        /// </summary>
        /// <param name="redirect"></param>
        public void InputRedirectOverride(bool redirect)
        {
            _inputRedirectOverride = redirect;
        }
#endif
        private bool _inputRedirectOverride = false;

        /// <summary>
        /// The TextReader that represents the input stream of a command process.
        /// </summary>
        /// <remarks>
        /// Typically, this is STDIN, but it could be reassigned for unit testing, for example.
        /// </remarks>
        public TextReader Input { get; private set; }

        /// <summary>
        /// The TextWriter that represents the output stream of a command process.
        /// </summary>
        /// <remarks>
        /// Typically, this is STDOUT, but it could be reassigned for unit testing, for example.
        /// </remarks>
        public TextWriter PipelineOutput { get; private set; }

        /// <summary>
        /// The TextWriter that represents the error stream of a command process.
        /// </summary>
        /// <remarks>
        /// Typically, this is STDERR, but it could be reassigned for unit testing, for example.
        /// </remarks>
        public TextWriter TextOutput { get; private set; }

        #region The Read methods

        /// <summary>
        /// Read a keystroke from the console, without displaying it.
        /// </summary>
        /// <returns>A record representing the key that was struck</returns>
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        /// <summary>
        /// Read a line of text from the input console stream
        /// </summary>
        /// <returns>A line of text.</returns>
        public string ReadLine()
        {
            return Input.ReadLine();
        }

        /// <summary>
        /// Prompt user for choice.
        /// </summary>
        /// <param name="caption">The choice caption</param>
        /// <param name="message">The choice message</param>
        /// <param name="choices">The collection of choices</param>
        /// <param name="defaultChoice">The default choice</param>
        /// <returns></returns>
        public int PromptForChoice(string caption, string message, IEnumerable<Choice> choices, int defaultChoice)
        {
            int result = defaultChoice;

            var choicesArray = choices.Select(ch => new ChoiceRecord(ch)).ToArray();

            if (defaultChoice < -1 || defaultChoice >= choicesArray.Length)
                throw new ArgumentOutOfRangeException("The default must be within the bounds of the collection size, or -1 for no default.");

            WriteLine();
            WriteLine(caption);
            WriteLine(ConsoleColor.Yellow, GetConsoleBgColor(), message);

            while (true)
            {
                PrintChoices(defaultChoice, choicesArray);

                var line = ReadLine();

                if (string.IsNullOrEmpty(line) && defaultChoice != -1)
                    return defaultChoice;

                switch (line.Trim())
                {
                    case "?":
                        foreach (var ch in choicesArray)
                        {
                            if (ch.Key != char.MinValue)
                                WriteLine(ConsoleColor.Yellow, GetConsoleBgColor(), $"{ch.Key} - {ch.HelpMessage}");
                            else
                                WriteLine(ConsoleColor.Yellow, GetConsoleBgColor(), $"{ch.Label} - {ch.HelpMessage}");
                        }
                        break;
                    default:
                        for (int i = 0; i < choicesArray.Length; ++i)
                        {
                            if (line.Length == 1 && Char.ToLower(line[0]) == Char.ToLower(choicesArray[i].Key))
                                return i;
                            if (line.Equals(choicesArray[i].Label, StringComparison.Ordinal))
                                return i;
                        }
                        break;
                }
            }
        }

#endregion

#region The Write methods

        /// <summary>
        /// Write a string value to the error stream.
        /// </summary>
        /// <param name="value">The value to write</param>
        public void Write(string value)
        {
            TextOutput.Write(value);
        }

        /// <summary>
        /// Write a formatted string to the error stream.
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="values">An array of objects to write using format</param>
        public void Write(string format, params object[] values)
        {
            TextOutput.Write(format, values);
        }

        /// <summary>
        /// Write a string value to the  to the error stream, changing the color of the text.
        /// </summary>
        /// <param name="foregroundColor">The foreground color</param>
        /// <param name="backgroundColor">The background color</param>
        /// <param name="value">The value to write</param>
        public void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            if (CLUEnvironment.Platform.IsUnixOrMacOSX)
            {
                //TODO: figure out why this is necessary on Linux/MacOS
                TextOutput.Write(value);
                return;
            }

            var fg = GetConsoleFgColor();
            var bg = GetConsoleBgColor();
            try
            {
                SetConsoleFgColor(foregroundColor);
                SetConsoleBgColor(backgroundColor);
                TextOutput.Write(value);
            }
            finally
            {
                SetConsoleFgColor(fg);
                SetConsoleBgColor(bg);
            }
        }

#endregion

#region The WriteLine methods

        /// <summary>
        /// Write a new line character to the error stream.
        /// </summary>
        public void WriteLine()
        {
            TextOutput.WriteLine();
        }

        /// <summary>
        /// Write a string value to the error stream. Append a new line character.
        /// </summary>
        /// <param name="value">The value to write</param>
        public void WriteLine(string value)
        {
            TextOutput.WriteLine(value);
        }

        /// <summary>
        /// Write a formatted string to the error stream. Append a new line character.
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="values">An array of objects to write using format</param>
        public void WriteLine(string format, params object[] values)
        {
            TextOutput.WriteLine(format, values);
        }

        /// <summary>
        /// Write a string value to the error stream, changing the color of the text. Append a new line character.
        /// </summary>
        /// <param name="foregroundColor">The foreground color</param>
        /// <param name="backgroundColor">The background color</param>
        /// <param name="value">The value to write</param>
        public void WriteLine(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            if (CLUEnvironment.Platform.IsUnixOrMacOSX)
            {
                //TODO: figure out why this is necessary on Linux/MacOS
                TextOutput.WriteLine(value);
                return;
            }

            var fg = GetConsoleFgColor();
            var bg = GetConsoleBgColor();
            try
            {
                SetConsoleFgColor(foregroundColor);
                SetConsoleBgColor(backgroundColor);
                TextOutput.WriteLine(value);
            }
            finally
            {
                SetConsoleFgColor(fg);
                SetConsoleBgColor(bg);
            }
        }

        /// <summary>
        /// Write a 'DEBUG' message to the error stream. Append a new line character.
        /// </summary>
        /// <param name="message">The message to write</param>
        public void WriteDebugLine(string message)
        {
            if (_doDebug)
                CLUEnvironment.Console.WriteLine(string.Format(Strings.DebugLineFormat, message));
        }

        /// <summary>
        /// Write a 'ERROR' message to the error stream. Append a new line character.
        /// </summary>
        /// <param name="message">The message to write</param>
        public void WriteErrorLine(string message)
        {
            WriteLine(ConsoleColor.Red, GetConsoleBgColor(), string.Format(Strings.ErrorLineFormat, message));
        }

        /// <summary>
        /// Write a 'VERBOSE' message to the error stream. Append a new line character.
        /// </summary>
        /// <param name="message">A string to write</param>
        public void WriteVerboseLine(string message)
        {
            if (_doVerbose)
                CLUEnvironment.Console.WriteLine(string.Format(Strings.VerboseLineFormat, message));
        }

        /// <summary>
        /// Write a 'WARNING' message to the error stream. Append a new line character.
        /// </summary>
        /// <param name="message">The message to write</param>
        public void WriteWarningLine(string message)
        {
            CLUEnvironment.Console.WriteLine(ConsoleColor.Yellow, GetConsoleBgColor(), string.Format(Strings.WarningLineFormat, message));
        }

#endregion

        /// <summary>
        /// Type represents choice record.
        /// </summary>
        private class ChoiceRecord
        {
            /// <summary>
            /// The shortcut key for the choice.
            /// </summary>
            public char Key { get; set; } = Char.MinValue;

            /// <summary>
            /// The label for the choce.
            /// </summary>
            public string Label { get; set; }

            /// <summary>
            /// The help message for the choce.
            /// </summary>
            public string HelpMessage { get; set; }

            /// <summary>
            /// Creates an instance of ChoiceRecord
            /// </summary>
            /// <param name="from">The Choice instance from which this instance needs to be initialized</param>
            internal ChoiceRecord(Choice from)
            {
                Label = from.Label.Replace("&","");
                HelpMessage = from.HelpMessage;
                for (var i = 0; i < from.Label.Length; ++i)
                {
                    if (from.Label[i] == '&' && i + 1 < from.Label.Length)
                    {
                        Key = Char.ToUpper(from.Label[i + 1]);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Display the choices.
        /// </summary>
        /// <param name="defaultChoice">The default choice</param>
        /// <param name="choicesArray">The collection of choices</param>
        private void PrintChoices(int defaultChoice, ChoiceRecord[] choicesArray)
        {
            for (int i = 0; i < choicesArray.Length; ++i)
            {
                var choice = choicesArray[i];

                if (i == defaultChoice)
                {
                    if (choice.Key != Char.MinValue)
                        Write(ConsoleColor.Yellow, GetConsoleBgColor(), $"[{choice.Key}] {choice.Label} ");
                    else
                        Write(ConsoleColor.Yellow, GetConsoleBgColor(), $"[] {choice.Label} ");
                }
                else
                {
                    if (choice.Key != Char.MinValue)
                        Write($"[{choice.Key}] {choice.Label} ");
                    else
                        Write($"[] {choice.Label} ");
                }
            }

            if (defaultChoice != -1)
            {
                if (choicesArray[defaultChoice].Key != Char.MinValue)
                    Write(ConsoleColor.Yellow, GetConsoleBgColor(), $"[?] Help (default is \"{choicesArray[defaultChoice].Key}\"): ");
                else
                    Write(ConsoleColor.Yellow, GetConsoleBgColor(), $"[?] Help (default is \"{choicesArray[defaultChoice].Label}\"): ");
            }
            else
            {
                Write(ConsoleColor.Yellow, GetConsoleBgColor(), $"[?] Help ");
            }
        }


        private ConsoleColor GetConsoleBgColor()
        {
            try
            {
                return Console.BackgroundColor;
            }
            catch (PlatformNotSupportedException) { }
            return ConsoleColor.Black;
        }

        private void SetConsoleBgColor(ConsoleColor color)
        {
            try
            {
                Console.BackgroundColor = color;
            }
            catch (PlatformNotSupportedException) { }
        }


        private ConsoleColor GetConsoleFgColor()
        {
            try
            {
                return Console.ForegroundColor;
            }
            catch (PlatformNotSupportedException) { }
            return ConsoleColor.White;
        }

        private void SetConsoleFgColor(ConsoleColor color)
        {
            try
            {
                Console.ForegroundColor = color;
            }
            catch (PlatformNotSupportedException) { }
        }


        #region Private fields

        /// <summary>
        /// Indicates whether the command needs to be run in debug mode.
        /// </summary>
        private static bool _doDebug = false;

        /// <summary>
        /// Indicates whether the command needs to be run in verbose mode.
        /// </summary>
        private static bool _doVerbose = false;

#endregion
    }
}
