using Microsoft.CLU.CommandBinder;
using Microsoft.CLU.Common;
using System.Diagnostics;

namespace Microsoft.CLU.CommandModel
{
    /// <summary>
    /// Implementation of ICommandModel interface to support "Static Progamming Model"
    /// </summary>
    internal class StaticCommandModel : CommandModel, ICommandModel
    {
        /// <summary>
        /// Creates an instance of StaticCommandModel.
        /// </summary>
        public StaticCommandModel()
        {
        }

        /// <summary>
        /// Runs the static command programming model given it's configuration.
        /// </summary>
        /// <param name="commandConfiguration">Date from the command configuration file.</param>
        /// <param name="arguments">The command-line arguments array</param>
        public CommandModelErrorCode Run(ConfigurationDictionary commandConfiguration, string[] arguments)
        {
            Debug.Assert(commandConfiguration != null);
            Debug.Assert(arguments != null);

            Init(commandConfiguration);

            using (var resolver = new AssemblyResolver(CLUEnvironment.GetPackagePaths(), true))
            {
                // Create instance of ICommandBinder and ICommand implementation for static model
                var binderAndCommand = new StaticBinderAndCommand(commandConfiguration, resolver);

                ICommandLineParser commandParser = GetCommandLineParser();
                if (commandParser.Parse(binderAndCommand, arguments))
                {

                    if (binderAndCommand.IsAsync)
                    {
                        binderAndCommand.InvokeAsync().Wait();
                    }
                    else
                    {
                        binderAndCommand.Invoke();
                    }
                }
                return CommandModelErrorCode.Success;
            }
        }
    }
}
