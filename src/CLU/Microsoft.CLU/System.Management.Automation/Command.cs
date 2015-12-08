using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Type represents a Cmdlet command set.
    /// </summary>
    public sealed class CommandCollection : Collection<Command>
    {
        /// <summary>
        /// Add a command.
        /// </summary>
        /// <param name="command">The command</param>
        public void Add(string command)
        {
            Add(new Command(command));
        }
    }

    /// <summary>
    /// Type represents a Cmdlet command.
    /// </summary>
    public sealed class Command
    {
        /// <summary>
        /// The command name
        /// </summary>
        public string CommandText { get; private set; }

        /// <summary>
        /// The command discriminators.
        /// </summary>
        public IEnumerable<string> CommandDiscriminators
        {
            get
            {
                return CommandText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        /// <summary>
        /// The Cmdlet parameter collection.
        /// </summary>
        public CommandParameterCollection Parameters { get; private set; }

        /// <summary>
        /// Creates an instance of Command.
        /// </summary>
        /// <param name="command"></param>
        public Command(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }

            CommandText = command.Trim();
            Parameters = new CommandParameterCollection();
        }

        public override string ToString()
        {
            return CommandText;
        }
    }
}