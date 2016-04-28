using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to upload activate an application package
    /// </summary>
    [Serializable]
    internal class ActivateApplicationPackageException : Exception
    {
        public ActivateApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}