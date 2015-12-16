using Microsoft.CLU.CommandBinder;
using Microsoft.CLU.Common;
using Microsoft.CLU.Common.Properties;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Microsoft.CLU.CommandModel
{
    /// <summary>
    /// Implementation of ICommandModel interface to support "Cmdlet Progamming Model".
    /// </summary>
    internal class CmdletCommandModel : CommandModel, ICommandModel
    {
        /// <summary>
        /// Runs the Cmdlet programming model given it's configuration.
        /// </summary>
        /// <param name="commandConfiguration">Date from the command configuration file.</param>
        /// <param name="arguments">The command-line arguments array</param>
        public CommandModelErrorCode Run(ConfigurationDictionary commandConfiguration, string[] arguments)
        {
            Debug.Assert(commandConfiguration != null);
            Debug.Assert(arguments != null);

            if (arguments.Length < 1)
            {
                throw new ArgumentException(Strings.CmdletCommandModel_Run_MissingMinimalArguments);
            }

            Init(commandConfiguration);
            IPipe<string> pipe = new ConsolePipe(CLUEnvironment.Console);
            HostStreamInfo hostStreamInfo = new HostStreamInfo
            {
                DataStream = new ConsoleDataStream(CLUEnvironment.Console),
                IsInputRedirected = CLUEnvironment.Console.IsInputRedirected,
                IsOutputRedirected = CLUEnvironment.Console.IsOutputRedirected,
                ReadFromPipe = pipe,
                WriteToPipe = pipe
            };

            // The runtime host is a Cmdlet's path to accessing system features, such as Console I/O
            // and session state. The runtime instance is created here and passed into the binder,
            // which will be creating the Cmdlet instance.
            var runtimeHost = new System.Management.Automation.Host.CLUHost(arguments, hostStreamInfo);

            // Create instance of ICommandBinder and ICommand implementation for cmdlet model
            var binderAndCommand = new CmdletBinderAndCommand(commandConfiguration, runtimeHost);

            ICommandLineParser commandParser = GetCommandLineParser();
            binderAndCommand.ParserSeekBackAndRun += (uint offset) =>
            {
                // Seek the parser to given offset and run.
                commandParser.SeekBack(offset);
                commandParser.Parse(binderAndCommand, arguments);
            };

            if (commandParser.Parse(binderAndCommand, arguments))
            {
                binderAndCommand.ParserSeekBeginAndRun += () =>
                {
                    // Seek the parser to begining and run.
                    commandParser.SeekBegin();
                    commandParser.Parse(binderAndCommand, arguments);
                };

                try
                {
                    if (binderAndCommand.IsAsync)
                    {
                        binderAndCommand.InvokeAsync().Wait();

                    }
                    else
                    {
                        binderAndCommand.Invoke();
                    }

                    if (runtimeHost.TerminatingErrorReported)
                    {
                        return CommandModelErrorCode.TerminatingError;
                    }
                    else if (runtimeHost.NonTerminatingErrorReported)
                    {
                        return CommandModelErrorCode.NonTerminatingError;
                    }
                    else
                    {
                        return CommandModelErrorCode.Success;
                    }
                }
                catch (CommandNotFoundException)
                {
                    var helplines = binderAndCommand.GenerateCommandHelp(commandParser, binderAndCommand.Discriminators.ToArray(), true);
                    foreach (var entry in helplines)
                    {
                        CLUEnvironment.Console.WriteLine(entry);
                    }
                    return CommandModelErrorCode.CommandNotFound;
                }
                catch (CmdletTerminateException)
                {
                    return CommandModelErrorCode.TerminatingError;
                }
            }
            return CommandModelErrorCode.Success;
        }
    }
}