using Microsoft.CLU.CommandBinder;
using Microsoft.CLU.Common;

namespace Microsoft.CLU.CommandModel
{
    /// <summary>
    /// Implementation of ICommandModel interface to support "Base Progamming Model"
    /// </summary>
    internal class BaseCommandModel : CommandModel, ICommandModel
    {
        /// <summary>
        /// Runs the command programming model given it's configuration.
        /// </summary>
        /// <param name="commandConfiguration">Date from the command configuration file.</param>
        /// <param name="arguments">The command-line arguments array</param>
        public void Run(ConfigurationDictionary commandConfiguration, string[] arguments)
        {
            Init(commandConfiguration);

            using (var resolver = new AssemblyResolver(CLUEnvironment.GetPackagePaths(), true))
            {
                var command = new BaseCommand(commandConfiguration, resolver, arguments);
                if (command.IsAsync)
                {
                    command.InvokeAsync().Wait();
                }
                else
                {
                    command.Invoke();
                }
            }
        }
    }
}
