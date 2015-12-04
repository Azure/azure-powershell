using System;

namespace Microsoft.CLU
{
    /// <summary>
    /// An exception representing that a cmdlet is not invokable.
    /// </summary>
    internal class InvalidCmdletException : Exception
    {
        /// <summary>
        /// Create an instance of InvalidCmdletException.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public InvalidCmdletException(String message) : base(message)
        {
        }
    }
}
