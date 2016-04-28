using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// The exception that is thrown when failing to add an application package
    /// </summary>
    [Serializable]
    internal class AddApplicationPackageException : Exception
    {
        public AddApplicationPackageException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}