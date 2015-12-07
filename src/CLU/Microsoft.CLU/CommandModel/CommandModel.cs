using Microsoft.CLU.Common.Properties;
using System;
using System.Diagnostics;

namespace Microsoft.CLU.CommandModel
{
    /// <summary>
    /// Base class for different "Programming Model" implementations.
    /// </summary>
    internal abstract class CommandModel
    {
        /// <summary>
        /// The command configuration.
        /// </summary>
        protected ConfigurationDictionary commandConfiguration;

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        /// <param name="commandConfiguration">The command configuration</param>
        protected void Init(ConfigurationDictionary commandConfiguration)
        {
            Debug.Assert(commandConfiguration != null);
            this.commandConfiguration = commandConfiguration;
        }

        /// <summary>
        /// Creates an instance of ICommandLineParser implementation based on command configuration.
        /// If the parser implementation has a constructor that accepts parameter of type
        /// ConfigurationDictionary then this method creates parser by passing command configuration
        /// otherwise it creates parser using default constructor.
        /// </summary>
        /// <returns></returns>
        protected ICommandLineParser GetCommandLineParser()
        {
            var config = CLUEnvironment.RuntimeConfig;
            ICommandLineParser commandParser = null;
            Type parserType = Type.GetType(config.CommandParser, true);
            if (parserType.hasConstructorWithSingleParameterOfType(typeof(ConfigurationDictionary)))
            {
                commandParser = Activator.CreateInstance(parserType, commandConfiguration) as ICommandLineParser;
            }
            else if (parserType.hasDefaultConstructor())
            {
                commandParser = Activator.CreateInstance(parserType) as ICommandLineParser;
            }

            if (commandParser == null)
            {
                throw new ArgumentException(Strings.CommandModel_GetCommandLineParser_ParserNotFound);
            }

            return commandParser;
        }
    }
}
