using System;

namespace Microsoft.Azure.Internal.Common
{
    public partial interface IAzureRestClient : IDisposable
    {
        /// <summary>
        /// Gets the IAzureRestOperations.
        /// </summary>
        IAzureRestOperations Operations { get; }
    }
}
