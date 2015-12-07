using Microsoft.CLU.Common.Properties;
using System;

namespace Microsoft.CLU
{
    /// <summary>
    /// An exception representing failure in parameter binding.
    /// </summary>
    internal class ParameterBindingException : Exception
    {
        /// <summary>
        /// Create an instance of ParameterBindingException.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception</param>
        public ParameterBindingException(string message, Exception innerException) : base(message, innerException)
        {}

        /// <summary>
        /// Create an instance of ParameterBindingException.
        /// </summary>
        /// <param name="parameterName">The parameter which failed to bind</param>
        /// <param name="filePath">The source of data</param>
        /// <param name="innerException">The inner exception</param>
        public ParameterBindingException(string parameterName, string filePath, Exception innerException) : this(string.Format(Strings.ParameterBindingException_FileBindingFailedMessage, parameterName, filePath), innerException)
        {}

        /// <summary>
        /// Create an instance of ParameterBindingException.
        /// </summary>
        /// <param name="parameterName">The parameter which failed to bind</param>
        /// <param name="position">Position of the argument</param>
        /// <param name="innerException">The inner exception</param>
        public ParameterBindingException(string parameterName, int position, Exception innerException) : this(string.Format(Strings.ParameterBindingException_PositionalBindingFailedMessage, parameterName, position), innerException)
        {}
    }
}
