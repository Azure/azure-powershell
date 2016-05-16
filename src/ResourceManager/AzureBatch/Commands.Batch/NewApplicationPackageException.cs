using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to upload a file to Azure Storage
    /// </summary>
    [Serializable]
    sealed class NewApplicationPackageException : Exception
    {
        public NewApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }

        public NewApplicationPackageException(string message)
            : base(message)
        {
        }
    }
}