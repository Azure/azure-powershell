using Microsoft.CLU;
using Microsoft.CLU.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace System.Management.Automation.Host
{
    /// <summary>
    /// Internal implementation of the runtime host interfaces, used by Cmdlet code to access system
    /// features such as Console I/O and session state.
    /// </summary>
    internal class CLUHost : PSHost, ICommandRuntime
    {
        /// <summary>
        /// Creates an instance of CLUHost.
        /// </summary>
        /// <param name="args">The commandline arguments</param>
        internal CLUHost(string[] args, HostStreamInfo hostStreamInfo)
        {
            Debug.Assert(args != null);
            Debug.Assert(hostStreamInfo != null);

            _hostStreamInfo = hostStreamInfo;
            _ui = new HostUserInterface(this, hostStreamInfo.DataStream);
            var dpref = CLUEnvironment.GetEnvironmentVariable(Constants.DebugPreference, false);
            if (!string.IsNullOrEmpty(dpref))
                _doDebug = InterpretStreamPreference(Constants.DebugPreference, dpref, _doDebug);

            var vpref = CLUEnvironment.GetEnvironmentVariable(Constants.VerbosePreference, false);
            if (!string.IsNullOrEmpty(vpref))
                _doVerbose = InterpretStreamPreference(Constants.VerbosePreference, vpref, _doVerbose);

            // Command-line switch overrides environment variable
            if (args.Select(arg => arg.ToLowerInvariant()).Where(arg => arg.Equals("--debug") || arg.Equals("/debug")).Any())
                _doDebug = Constants.CmdletPreferencesInquire;
                    
            if (args.Select(arg => arg.ToLowerInvariant()).Where(arg => arg.Equals("--verbose") || arg.Equals("/verbose")).Any())
                _doVerbose = Constants.CmdletPreferencesContinue;
        }

        internal CLUHost(string[] args, HostStreamInfo hostStreamInfo, string debugPreference, string verbosePreference)
        {
            Debug.Assert(hostStreamInfo != null);

            _hostStreamInfo = hostStreamInfo;
            _ui = new HostUserInterface(this, hostStreamInfo.DataStream);
            _doDebug = debugPreference;
            _doVerbose = verbosePreference;
        }

        /// <summary>
        /// ToString() override.
        /// </summary>
        /// <returns>A string representation of the host.</returns>
        public override string ToString()
        {
            // TODO: replace with something more useful.
            return "CLUHost";
        }

        /// <summary>
        /// Access to the streams used by the host.
        /// </summary>
        internal HostStreamInfo StreamInfo
        {
            get
            {
                return _hostStreamInfo;
            }
        }

        /// <summary>
        /// Tells whether the STDIN byte stream has been redirected from a file or pipe
        /// </summary>
        /// <remarks>If this is true, your code is not doing console I/O</remarks>
        public override bool IsInputRedirected { get { return _hostStreamInfo.IsInputRedirected; } }

        /// <summary>
        /// Tells whether the STDOUT byte stream has been redirected to a file or pipe
        /// </summary>
        /// <remarks>If this is true, your code is not doing console I/O</remarks>
        public override bool IsOutputRedirected { get { return _hostStreamInfo.IsOutputRedirected; } }

        public override CultureInfo CurrentCulture
        {
            get
            {
                return CultureInfo.CurrentCulture;
            }
        }

        public override CultureInfo CurrentUICulture
        {
            get
            {
                return CultureInfo.CurrentUICulture;
            }
        }

        public PSHost Host
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Private field backing InstanceId property.
        /// </summary>
        private Guid _id = Guid.NewGuid();

        /// <summary>
        /// The host instance ID.
        /// </summary>
        public override Guid InstanceId
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// The host name.
        /// </summary>
        public override string Name
        {
            get
            {
                return System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            }
        }

        /// <summary>
        /// Private field backing UI property.
        /// </summary>
        private PSHostUserInterface _ui;

        /// <summary>
        /// The host UI.
        /// </summary>
        public override PSHostUserInterface UI
        {
            get
            {
                return _ui;
            }
        }


        /// <summary>
        /// Gets host version.
        /// </summary>
        public override Version Version
        {
            get
            {
                return new Version(0, 0, 1);
            }
        }

        /// <summary>
        /// Requests confirmation of an operation from the user by sending a second query to the user.
        /// </summary>
        /// <param name="query">The query that confirms whether the cmdlet should continue</param>
        /// <param name="caption">The caption that is displayed above the query</param>
        /// <returns></returns>
        public bool ShouldContinue(string query, string caption)
        {
            if (IsInputRedirected)
            {
                return true;
            }

            ChoiceDescription[] choices = new ChoiceDescription[]
            {
                new ChoiceDescription("&Yes", "Continue with only the next step of the operation."),
                new ChoiceDescription("&No", "Skip this operation and proceed with the next operation.")
            };

            return _ui.PromptForChoice(caption, query, new Collection<ChoiceDescription>(choices), 0) == 0;
        }

        /// <summary>
        /// Requests confirmation of an operation from the user by sending a second query to
        /// the user with yesToall and noToall options.
        /// </summary>
        /// <param name="query">Query that inquires whether the cmdlet should continue</param>
        /// <param name="caption">Caption of the window that might be displayed when the user is
        /// prompted whether or not to perform the action</param>
        /// <param name="yesToAll">True if and only if the user selects the yesToall option.
        /// If this is already True, ShouldContinue will bypass the prompt and return True.</param>
        /// <param name="noToAll">True if and only if the user selects the noToall option.
        /// If this is already True, ShouldContinue will bypass the prompt and return False.</param>
        /// <returns>A Boolean value that indicates true if the cmdlet should perform the operation.
        /// If false is returned, the operation should not be performed and the cmdlet should move
        /// to the next resource.</returns>
        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            yesToAll = false;
            noToAll = false;

            if (IsInputRedirected)
            {
                yesToAll = true;
                return true;
            }

            ChoiceDescription[] choices = new ChoiceDescription[]
            {
                new ChoiceDescription("&Yes", "Continue with the next operation."),
                new ChoiceDescription("Yes to &All", "Continue with the operation and don't ask again."),
                new ChoiceDescription("&No", "Stop the next operation."),
                new ChoiceDescription("No to Al&l", "Stop all operations.")
            };

            var choice = _ui.PromptForChoice(caption, query, new Collection<ChoiceDescription>(choices), 0);

            if (choice == 1)
                yesToAll = true;
            if (choice == 3)
                noToAll = true;

            return choice < 2;
        }

        /// <summary>
        /// Requests confirmation from the user before an operation is performed.
        /// This method sends the name of the resource to be changed so that the
        /// user can decide if the operation should continue.
        /// </summary>
        /// <param name="target">The name of the resource to be changed</param>
        /// <returns></returns>
        public bool ShouldProcess(string target)
        {
            return true;
        }

        /// <summary>
        /// Requests confirmation from the user before an operation is performed.
        /// This method sends the operation that is to be performed and the
        /// name of the resource to be changed so that the user can decide if the
        /// operation should continue.
        /// </summary>
        /// <param name="target">The name of the resource to be changed</param>
        /// <param name="action">The operation to be performed</param>
        /// <returns></returns>
        public bool ShouldProcess(string target, string action)
        {
            return true;
        }

        /// <summary>
        /// Requests confirmation from the user before an operation is performed.
        /// This method sends a description of the operation to be performed, a warning
        /// message that can include query, and a caption for the warning message
        /// </summary>
        /// <param name="verboseDescription">A description of the operation to be performed</param>
        /// <param name="verboseWarning">A warning message that contains a query asking whether
        /// the operation should be performed</param>
        /// <param name="caption">A caption for the warning message</param>
        /// <returns>A Boolean value that indicates true whether the cmdlet should perform the action.
        /// A return value of false indicates that the action should not be performed. </returns>
        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            WriteVerbose(verboseDescription);

            if (IsInputRedirected)
            {
                return true;
            }

            ChoiceDescription[] choices = new ChoiceDescription[]
            {
                new ChoiceDescription("&Yes", "Continue with the next operation."),
                new ChoiceDescription("Yes to &All", "Continue with the operation and don't ask again."),
                new ChoiceDescription("&No", "Stop the next operation."),
                new ChoiceDescription("No to Al&l", "Stop all operations.")
            };

            var choice = _ui.PromptForChoice(caption, verboseWarning, new Collection<ChoiceDescription>(choices), 0);

            return choice < 2;
        }

        /// <summary>
        /// Requests confirmation from the user before an operation is performed. This method sends
        /// a detailed description of the resource to be changed and the operation to be performed
        /// to the user for confirmation before the operation is performed
        /// </summary>
        /// <param name="verboseDescription">The operation to be performed</param>
        /// <param name="verboseWarning">Query that confirms whether the operation should be performed</param>
        /// <param name="caption">Caption of the window that displays the query</param>
        /// <param name="shouldProcessReason">A ShouldProcessReason constant that specifies any special
        /// circumstances that existed when the call was made</param>
        /// <returns></returns>
        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason)
        {
            shouldProcessReason = ShouldProcessReason.None;
            return ShouldProcess(verboseDescription, verboseWarning, caption);
        }

        /// <summary>
        /// Reports a terminating error when the cmdlet cannot continue, or when you do not want the
        /// cmdlet to continue to process records.
        /// </summary>
        /// <param name="errorRecord">An ErrorRecord object that describes the error condition</param>
        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            TerminatingErrorReported = true;
            throw new CmdletTerminateException(errorRecord);
        }

        /// <summary>
        /// Writes information to the execution log of the pipeline.
        /// </summary>
        /// <param name="text">Text to be written to the execution log</param>
        public void WriteCommandDetail(string text)
        {
            _ui.WriteLine(text);
        }

        /// <summary>
        /// Writes a debug message to the host.
        /// </summary>
        /// <param name="text">The debug message to be written to the host</param>
        public void WriteDebug(string text)
        {
            if (_doDebug.Equals(Constants.CmdletPreferencesContinue, StringComparison.OrdinalIgnoreCase))
            {
                _ui.WriteDebugLine(text);
            }
            else if (_doDebug.Equals(Constants.CmdletPreferencesInquire, StringComparison.OrdinalIgnoreCase))
            {
                _ui.WriteDebugLine(text);
                var choice = _ui.PromptForChoice("Confirm", "Continue with this operation?", new Collection<ChoiceDescription>(choices), 0);
                if (choice == 1)
                    throw new Exception("The running command stopped because the user selected the Stop option.");
            }
            else if (_doDebug.Equals(Constants.CmdletPreferencesStop, StringComparison.OrdinalIgnoreCase))
            {
                _ui.WriteDebugLine(text);
                throw new Exception("The running command stopped because the preference variable \"DebugPreference\" or common parameter is set to Stop.");
            }
            else if (!_doDebug.Equals(Constants.CmdletPreferencesSilentlyContinue, StringComparison.OrdinalIgnoreCase))
            {
                File.AppendAllText(_doDebug, text+"\n");
            }
        }

        /// <summary>
        /// Writes a general user-level message to the pipeline. These messages
        /// can help describe what the cmdlet is doing.
        /// </summary>
        /// <param name="text">The message to be sent to the host</param>
        public void WriteVerbose(string text)
        {
            if (_doVerbose.Equals(Constants.CmdletPreferencesContinue, StringComparison.OrdinalIgnoreCase))
            {
                _ui.WriteVerboseLine(text);
            }
            else if (_doVerbose.Equals(Constants.CmdletPreferencesInquire, StringComparison.OrdinalIgnoreCase))
            {
                _ui.WriteVerboseLine(text);
                var choice = _ui.PromptForChoice("Confirm", "Continue with this operation?", new Collection<ChoiceDescription>(choices), 0);
                if (choice == 1)
                    throw new Exception("The running command stopped because the user selected the Stop option.");
            }
            else if (_doVerbose.Equals(Constants.CmdletPreferencesStop, StringComparison.OrdinalIgnoreCase))
            {
                _ui.WriteVerboseLine(text);
                throw new Exception("The running command stopped because the preference variable \"VerbosePreference\" or common parameter is set to Stop.");
            }
            else if(!_doVerbose.Equals(Constants.CmdletPreferencesSilentlyContinue, StringComparison.OrdinalIgnoreCase))
            {
                File.AppendAllText(_doVerbose, text+"\n");
            }
        }

        /// <summary>
        /// Reports a nonterminating error to the error pipeline when the cmdlet
        /// cannot process a record but can continue to process other records.
        /// </summary>
        /// <param name="errorRecord">An ErrorRecord object that describes the
        /// error condition</param>
        public void WriteError(ErrorRecord errorRecord)
        {
            this.NonTerminatingErrorReported = true;
            WriteExceptionLine(errorRecord.Exception);
        }

        /// <summary>
        /// Writes a single object to the output pipeline.
        /// </summary>
        /// <param name="sendToPipeline">The object to be written to the output pipeline</param>
        public void WriteObject(object sendToPipeline)
        {
            _hostStreamInfo.WriteToPipe.Write(sendToPipeline);
        }

        /// <summary>
        /// Writes an object to the output pipeline that can be enumerated by CLU.
        /// </summary>
        /// <param name="sendToPipeline">The object to be sent to the pipeline</param>
        /// <param name="enumerateCollection">True indicates that CLU runtime will
        /// enumerate the object one level. The default is False.</param>
        public void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            _hostStreamInfo.WriteToPipe.Write(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// Writes a progress record to the host.
        /// </summary>
        /// <param name="progressRecord">A ProgressRecord object that describes
        /// the progress of the operation being performed by the cmdlet</param>
        public void WriteProgress(ProgressRecord progressRecord)
        {
            _ui.WriteProgress(0, progressRecord);
        }

        /// <summary>
        /// Writes a progress record to the host.
        /// </summary>
        /// <param name="sourceId">The source identifier</param>
        /// <param name="progressRecord">A ProgressRecord object that describes
        /// the progress of the operation being performed by the cmdlet</param>
        public void WriteProgress(long sourceId, ProgressRecord progressRecord)
        {
            _ui.WriteProgress(sourceId, progressRecord);
        }

        /// <summary>
        /// Writes a warning message that can be displayed.
        /// </summary>
        /// <param name="text">The warning message to be displayed</param>
        public void WriteWarning(string text)
        {
            _ui.WriteWarningLine(text);
        }

        /// <summary>
        /// Write an exception.
        /// </summary>
        /// <param name="exc">The exception to write.</param>
        private void WriteExceptionLine(Exception exc)
        {
            if (exc.InnerException != null)
            {
                _ui.WriteErrorLine("Inner exception: ");
                WriteExceptionLine(exc.InnerException);
            }

            _ui.WriteErrorLine(exc.Message);
            if (_doDebug.Equals(Constants.CmdletPreferencesContinue, StringComparison.OrdinalIgnoreCase))
                _ui.WriteDebugLine(exc.StackTrace);
        }

        /// <summary>
        /// Has at least one non-terminating error been reported?
        /// </summary>
        internal bool NonTerminatingErrorReported { get; private set; }

        /// <summary>
        /// At least one terminating error has been reported...
        /// </summary>
        internal bool TerminatingErrorReported { get; private set;  }

        private string InterpretStreamPreference(string variable, string input, string current)
        {
            switch (input)
            {
                case Constants.CmdletPreferencesContinue:
                case Constants.CmdletPreferencesInquire:
                case Constants.CmdletPreferencesSilentlyContinue:
                case Constants.CmdletPreferencesStop:
                    return input;
                default:
                    if (input.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
                        return input.Split(":".ToCharArray(), 2)[1];
                    else
                        WriteWarning($"Ignoring unsupported value for {variable}: '{input}'.");
                    break;
            }
            return current;
        }

        #region private fields

        /// <summary>
        /// Debug preference for the current command.
        /// </summary>
        private string _doDebug = Constants.CmdletPreferencesSilentlyContinue;

        /// <summary>
        /// Verbose preference for the current command.
        /// </summary>
        private string _doVerbose = Constants.CmdletPreferencesSilentlyContinue;

        /// <summary>
        /// The choices.
        /// </summary>
        private static ChoiceDescription[] choices = new ChoiceDescription[]
        {
                new ChoiceDescription("&Yes", "Continue with the operation."),
                new ChoiceDescription("&Halt Command", "Stop this command.")
        };
        private HostStreamInfo _hostStreamInfo;

        #endregion

        /// <summary>
        /// Type represents the host UI.
        /// </summary>
        private class HostUserInterface : PSHostUserInterface
        {
            /// <summary>
            /// Creates an instance of HostUserInterface.
            /// </summary>
            /// <param name="host">The host</param>
            internal HostUserInterface(CLUHost host, IDataStream dataStream)
            {
                _host = host;
                _dataStream = dataStream;
            }

            /// <summary>
            /// Prompt.
            /// </summary>
            /// <param name="caption">The caption</param>
            /// <param name="message">The message</param>
            /// <param name="descriptions">The field discriptions</param>
            /// <returns></returns>
            public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
            {
                throw new NotImplementedException("Prompt");
            }

            /// <summary>
            /// Prompt for choice.
            /// </summary>
            /// <param name="caption">The caption</param>
            /// <param name="message">The message</param>
            /// <param name="choices">The list of choices</param>
            /// <param name="defaultChoice">The default choice</param>
            /// <returns></returns>
            public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
            {
                if (_host.IsInputRedirected)
                    throw new PSInvalidOperationException("Prompting a user for input cannot be done when the command input has been redirected.");

                return CLUEnvironment.Console.PromptForChoice(caption, message, choices.Select(c => new Choice(c.Label.Trim(), c.HelpMessage)), defaultChoice);
            }

            /// <summary>
            /// Prompt for credentails.
            /// </summary>
            /// <param name="caption">The caption</param>
            /// <param name="message">The message</param>
            /// <param name="userName">The user name</param>
            /// <param name="targetName">The target name</param>
            /// <returns>The credentails</returns>
            public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
            {
                if (_host.IsInputRedirected)
                    throw new PSInvalidOperationException("Credentials cannot be gathered when the command input has been redirected.");

                if (!string.IsNullOrEmpty(caption))
                {
                    Console.Error.WriteLine();
                    Console.Error.WriteLine(caption);
                }
                if (!string.IsNullOrEmpty(message))
                {
                    Console.Error.WriteLine();
                    Console.Error.WriteLine(message);
                }
                Console.Error.WriteLine();

                string id = null;

                if (string.IsNullOrEmpty(userName))
                {
                    Console.Error.Write("User Name: ");
                    id = Console.ReadLine();
                } 
                else
                {
                    Console.Error.Write($"User Name [{userName}]:");
                    id = Console.ReadLine();
                    if (string.IsNullOrEmpty(id))
                        id = userName;
                }

                Console.Error.Write("Password: ");

                return new PSCredential(id, ReadLine('*'));
            }

            /// <summary>
            /// Prompt for credentails.
            /// </summary>
            /// <param name="caption">The caption</param>
            /// <param name="message">The message</param>
            /// <param name="userName">The user name</param>
            /// <param name="targetName">The target name</param>
            /// <param name="allowedCredentialTypes">The supported credentials types</param>
            /// <param name="options">The UI options</param>
            /// <returns>The credentails</returns>
            public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName, PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
            {
                return PromptForCredential(caption, message, userName, targetName);
            }

            /// <summary>
            /// Read a line from STDIN.
            /// </summary>
            /// <returns>The read line</returns>
            public override string ReadLine()
            {
                if (_host.IsInputRedirected)
                    throw new OperationNotAvailableException("ReadLine");
                return Console.ReadLine();
            }


            /// <summary>
            /// Read a line from STDIN by masking the characters.
            /// </summary>
            /// <param name="maskChar">The character to use for masking</param>
            /// <returns>The string</returns>
            /// <summary>
            private string ReadLine(char maskChar)
            {
                if (_host.IsInputRedirected)
                    throw new PSInvalidOperationException("ReadLineAsSecureString() cannot be used when the command input has been redirected.");

                var line = new StringBuilder();
                var key = Console.ReadKey(true);
                while (key.Key != ConsoleKey.Enter)
                {
                    line.Append(key.KeyChar);
                    Console.Error.Write('*');
                    key = Console.ReadKey(true);
                }
                Console.Error.WriteLine();
                return line.ToString();
            }

            /// <summary>
            /// Write a string value using CLUEnvironment.Console (IConsoleInputOutput)
            /// </summary>
            /// <param name="value">The value to write</param>
            public override void Write(string value)
            {
                _dataStream.Write(value);
            }

            /// <summary>
            /// Write a string value using CLUEnvironment.Console (IConsoleInputOutput), changing the color of the text.
            /// </summary>
            /// <param name="foregroundColor">The foreground color</param>
            /// <param name="backgroundColor">The background color</param>
            /// <param name="value">The value to write</param>
            public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
            {
                _dataStream.Write(foregroundColor, backgroundColor, value);
            }

            /// <summary>
            /// Write a string value in a line using CLUEnvironment.Console (IConsoleInputOutput), changing the color of the text.
            /// </summary>
            /// <param name="foregroundColor">The foreground color</param>
            /// <param name="backgroundColor">The background color</param>
            /// <param name="value">The value to write</param>
            public override void WriteLine(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
            {
                _dataStream.WriteLine(foregroundColor, backgroundColor, value);
            }

            /// <summary>
            ///  Write a string value in a line using CLUEnvironment.Console (IConsoleInputOutput).
            /// </summary>
            /// <param name="value">The value to write</param>
            public override void WriteLine(string value)
            {
                _dataStream.WriteLine(value);
            }

            /// <summary>
            /// Writes a progress record.
            /// </summary>
            /// <param name="sourceId">The source identifier</param>
            /// <param name="progressRecord">A ProgressRecord object that describes
            /// the progress of the operation being performed by the cmdlet</param>
            public override void WriteProgress(long sourceId, ProgressRecord record)
            {
                _dataStream.WriteProgress(sourceId, record);
            }

            /// <summary>
            /// Write an debug message using CLUEnvironment.Console.
            /// </summary>
            /// <param name="message">The message to write</param>
            public override void WriteDebugLine(string message)
            {
                _dataStream.WriteDebugLine(message);
            }

            /// <summary>
            /// Write an error message using CLUEnvironment.Console.
            /// </summary>
            /// <param name="message">The message to write</param>
            public override void WriteErrorLine(string message)
            {
                _dataStream.WriteErrorLine(message);
            }

            /// <summary>
            /// Write a verbose message using CLUEnvironment.Console.
            /// </summary>
            /// <param name="message">The message to write</param>
            public override void WriteVerboseLine(string message)
            {
                _dataStream.WriteVerboseLine(message);
            }

            /// <summary>
            /// Write a warning message using CLUEnvironment.Console.
            /// </summary>
            /// <param name="message">The message to write</param>
            public override void WriteWarningLine(string message)
            {
                _dataStream.WriteWarningLine(message);
            }

#region private fields

            CLUHost _host;
            private IDataStream _dataStream;

#endregion
        }
    }
}
