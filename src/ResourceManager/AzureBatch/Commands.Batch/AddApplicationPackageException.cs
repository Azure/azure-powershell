using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to add an application package
    /// </summary>
    [Serializable]
    internal sealed class AddApplicationPackageException : Exception
    {
        public AddApplicationPackageException()
        {
        }

        public AddApplicationPackageException(string message)
            : base(message)
        {
        }

        public AddApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }

        public AddApplicationPackageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}