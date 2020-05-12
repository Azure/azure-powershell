using System;
using System.Net;

namespace Microsoft.Azure.Commands.Synapse.Models.Exceptions
{
    /// <summary>
    /// Base for all Synapse cmdlet Exceptions
    /// </summary>
    [Serializable]
    public class SynapseException : Exception
    {
        public new Exception InnerException { get; set; }

        public SynapseException(string message) : this(message, null)
        {
        }

        protected SynapseException(string message, Exception innerException)
            : base(message)
        {
            this.InnerException = innerException;
        }

        internal static SynapseException Create(HttpStatusCode statusCode, string message, Exception ex)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    return new BadRequestException(message, ex);

                case HttpStatusCode.NotFound:
                    return new NotFoundException(message, ex);

                default:
                    return new SynapseException(message, ex);
            }
        }
    }
}
