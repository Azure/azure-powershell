using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to create a new application package and upload the application to Azure Storage.
    /// </summary>
    [Serializable]
    sealed internal class NewApplicationPackageException : Exception
    {
        public NewApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }

        private NewApplicationPackageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NewApplicationPackageException(string message)
            : base(message)
        {
        }
    }
}