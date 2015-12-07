using System;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// This exception should be used for operations that may or may not be available to commands.
    /// For example, reading from the console supported when the command is not taking data from the
    /// input pipeline.
    /// </summary>
    internal class OperationNotAvailableException : InvalidOperationException
    {
        /// <summary>
        /// Creates OperationNotAvailableException
        /// </summary>
        public OperationNotAvailableException() { }

        /// <summary>
        /// Creates OperationNotAvailableException
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public OperationNotAvailableException(string message) : base(message) { }

        /// <summary>
        /// Creates OperationNotAvailableException
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public OperationNotAvailableException(string message, Exception innerException) : base(message, innerException) { }
    }
}
