using System;

namespace Microsoft.Azure.Commands.Synapse.Models.Exceptions
{
    /// <summary>
    /// Exception thrown for Bad Request Response
    /// </summary>
    [Serializable]
    public class BadRequestException : SynapseException
    {
        public BadRequestException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
