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
        /// Generates a list of text lines containing help information for a specific command.
        /// </summary>
        /// <param name="parser">The active command-line parser</param>
        /// <param name="args">The command-line arguments to be considered in the help logic.</param>
        /// <param name="prefix">True if the help argument comes first, false if last.</param>
        /// <returns>A list of lines containing help information.</returns>
        /// <remarks>
        /// This should be called for generating help for a commands, for example,
        /// 
        ///     azure vm start --help   (prefix = false)
        ///     azure help vm start     (prefix = true)
        /// 
        /// If the arguments provide sufficient detail to identify a single command, the details about
        /// that command are listed. Otherwise, all commands matching what is available are listed, with
        /// brief summaries on what they do.
        IEnumerable<string> GenerateCommandHelp(ICommandLineParser parser, string[] args, bool prefix);
    }
}
