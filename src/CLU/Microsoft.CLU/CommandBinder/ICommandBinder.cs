using System;
using System.Collections.Generic;

namespace Microsoft.CLU
{
    /// <summary>
    /// The contract that needs to be implemented by binders defined for
    /// various "Programming Model"
    /// </summary>
    public interface ICommandBinder
    {
        /// <summary>
        /// Bind a positonal argument.
        /// </summary>
        /// <param name="position">The argument position in the command line</param>
        /// <param name="value">The value of the argument</param>
        void BindArgument(int position, string value);

        /// <summary>
        /// Bind a named argument.
        /// </summary>
        /// <param name="name">The argument name</param>
        /// <param name="value">The argument value</param>
        void BindArgument(string name, string value);

        /// <summary>
        /// Attempt to bind an argument name switch.
        /// </summary>
        /// <param name="name">The argument name</param>
        /// <returns>true if the argument is known and is a switch</returns>
        bool TryBindSwitch(string name);

        /// <summary>
        /// Checks whether a command implementation supports generation of help information.
        /// </summary>
        bool SupportsAutomaticHelp { get; }

        /// <summary>
        /// List the set of possible command matches for the given set of commands
        /// </summary>  
        IEnumerable<string> ListCommands(string[] args, bool autoComplete);
    }
}
