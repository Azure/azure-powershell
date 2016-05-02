using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to upload a file to a storage
    /// </summary>
    [Serializable]
    internal class UploadApplicationPackageException : Exception
    {
        public UploadApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}