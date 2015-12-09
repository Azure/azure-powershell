using System.Management.Automation.Runspaces;

namespace System.Management.Automation
{
    /// <summary>
    /// Type represents a set of Cmdlets and it's parameters.
    /// </summary>
    public sealed class PSCommand
    {
        /// <summary>
        /// The commands set.
        /// </summary>
        public CommandCollection Commands
        {
            get;
        }

        /// <summary>
        /// Creates an instance of PSCommand.
        /// </summary>
        public PSCommand()
        {
            Commands = new CommandCollection();
        }

        /// <summary>
        /// Add a new command and mark it as active command.
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns></returns>
        public PSCommand AddCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            _activeCommand = command;
            Commands.Add(_activeCommand);
            return this;
        }

        /// <summary>
        /// Add a new command using it name and mark it as active command.
        /// </summary>
        /// <param name="command">The command name</param>
        /// <returns></returns>
        public PSCommand AddCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }

            _activeCommand = new Command(command);
            Commands.Add(_activeCommand);
            return this;
        }

        /// <summary>
        /// Specify a switch parameter for the active command.
        /// </summary>
        /// <param name="parameterName">The parameter name</param>
        /// <returns></returns>
        public PSCommand AddParameter(string parameterName)
        {
            if (_activeCommand == null)
            {
                throw new InvalidOperationException("no active command");
            }

            if (string.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            _activeCommand.Parameters.Add(parameterName);
            return this;
        }

        /// <summary>
        /// Specify a named parameter for the active command.
        /// </summary>
        /// <param name="parameterName">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <returns></returns>
        public PSCommand AddParameter(string parameterName, object value)
        {
            if (_activeCommand == null)
            {
                throw new InvalidOperationException("no active command");
            }

            if (string.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            _activeCommand.Parameters.Add(parameterName, value);
            return this;
        }

        /// <summary>
        /// Specify a positional argument for the active command.
        /// </summary>
        /// <param name="value">Positional argument value</param>
        /// <returns></returns>
        public PSCommand AddArgument(object value)
        {
            _activeCommand.Parameters.Add(null, value);
            return this;
        }

        /// <summary>
        /// Clear the set.
        /// </summary>
        public void Clear()
        {
            _activeCommand = null;
            Commands.Clear();
        }

        #region  private fields

        /// <summary>
        /// The active command.
        /// </summary>
        private Command _activeCommand;

        #endregion
    }
}