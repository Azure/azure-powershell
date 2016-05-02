using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to activate an application package
    /// </summary>
    [Serializable]
    internal sealed class ActivateApplicationPackageException : Exception
    {
        public ActivateApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }

        private ActivateApplicationPackageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}