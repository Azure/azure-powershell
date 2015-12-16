using System;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.CLU.Common.Properties;

namespace Microsoft.CLU.Run
{
    /// <summary>
    /// The "IRunMode" implementation for command execution.
    /// </summary>
    internal class CommandExecMode : IRunMode
    {
        #region IRunMode implementation

        /// <summary>
        /// Check if this IRunMode implementation for executing command can handle the arguments.
        /// </summary>
        /// <param name="arguments">The argument to inspect to see implementation can handle it</param>
        /// <returns>True, if arguments can be handled, False otherwise</returns>
        public bool CanHandle(string[] arguments)
        {
            return _options.ContainsKey(arguments[0]);
        }

        /// <summary>
        /// Run a command that is identified by the arguments and supported by this
        /// IRunMode implementation for executing command.
        /// </summary>
        /// <param name="arguments">The arguments</param>
        public Microsoft.CLU.CommandModelErrorCode Run(string[] arguments)
        {
            if (arguments.Length < 2)
            {
                CLUEnvironment.Console.WriteErrorLine(Strings.CommandExecMode_Run_MissingCommandConfigFileArgument);
                return Microsoft.CLU.CommandModelErrorCode.MissingParameters;
            }

            try
            {
                int argsBase = 0;

                CommandConfig commandConfiguration = null;
                bool done = false;

                while (!done && argsBase < arguments.Length-1)
                {
                    switch (arguments[argsBase])
                    {
                        case "--script":
                        case "-s":
                            if (argsBase + 1 >= arguments.Length ||
                                arguments[argsBase + 1].StartsWith("-", StringComparison.Ordinal))
                            {
                                CLUEnvironment.Console.WriteErrorLine(Strings.CommandExecMode_Run_MissingScriptName);
                                return Microsoft.CLU.CommandModelErrorCode.MissingParameters;
                            }

                            CLUEnvironment.ScriptName = arguments[argsBase + 1];
                            argsBase += 2;
                            break;

                        case "--run":
                        case "-r":
                            if (argsBase + 1 >= arguments.Length ||
                                arguments[argsBase + 1].StartsWith("-", StringComparison.Ordinal))
                            {
                                CLUEnvironment.Console.WriteErrorLine(Strings.CommandExecMode_Run_MissingScriptConfigFileName);
                                return Microsoft.CLU.CommandModelErrorCode.MissingParameters;
                            }

                            commandConfiguration = CommandConfig.Load(arguments[argsBase + 1]);
                            argsBase += 2;
                            break;
                        default:
                            done = true;
                            break;
                    }
                }

                return CommandModel.Run(commandConfiguration, GetModelArguments(arguments, argsBase));
            }
            catch (TargetInvocationException tie)
            {
                CLUEnvironment.Console.WriteErrorLine(tie.InnerException.Message);
                CLUEnvironment.Console.WriteDebugLine($"{tie.InnerException.GetType().FullName}\n{tie.InnerException.StackTrace}");
            }
            catch (Exception exc)
            {
                CLUEnvironment.Console.WriteErrorLine(exc.Message);
                CLUEnvironment.Console.WriteDebugLine($"{exc.GetType().FullName}\n{exc.StackTrace}");
            }

            return CommandModelErrorCode.InternalFailure;
        }

        #endregion

        /// <summary>
        /// Gets the subset of command line arguments to be passed to command model entry point.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        private static string [] GetModelArguments(string [] arguments, int offset)
        {
            string[] modelArguments;
            if (arguments.Length > offset)
            {
                modelArguments = new string[arguments.Length - offset];
                Array.Copy(arguments, offset, modelArguments, 0, modelArguments.Length);
            }
            else
            {
                modelArguments = new string[] { };
            }

            return modelArguments;
        }

        private IDictionary<string, int> _options = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "-s", 1 },
            { "--script", 1 },
            { "-r", 0 },
            { "--run", 0 }
        };
    }
}
