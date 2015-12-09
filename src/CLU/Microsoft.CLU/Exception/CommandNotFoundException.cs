using Microsoft.CLU.Common.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.CLU
{
    /// <summary>
    /// An exception representing that a command could not be found.
    /// </summary>
    internal class CommandNotFoundException : Exception
    {
        /// <summary>
        /// Create an instance of CommandNotFoundException.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public CommandNotFoundException(string message) : base(message)
        { }

        /// <summary>
        /// Create an instance of CommandNotFoundException.
        /// </summary>
        /// <param name="verb">The verb</param>
        /// <param name="noun">The noun</param>
        public CommandNotFoundException(IEnumerable<string> commandDiscriminators) : this(string.Format(Strings.CommandNotFoundException_Ctor_Message, CLUEnvironment.ScriptName + " " + string.Join(" ", commandDiscriminators)))
        { }
    }
}