using System;

namespace Microsoft.Azure.Commands.Synapse.Models.Exceptions
{
    /// <summary>
    /// Exception thrown when the user requests a object that does not exist
    /// </summary>
    [Serializable]
    public class NotFoundException : SynapseException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
