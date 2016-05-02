using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to upload a file to Azure Storage
    /// </summary>
    [Serializable]
    internal sealed class UploadApplicationPackageException : Exception
    {
        public UploadApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }

        private UploadApplicationPackageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}