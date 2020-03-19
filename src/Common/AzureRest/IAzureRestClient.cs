using System;

namespace Microsoft.WindowsAzure.Commands.Common.AzureRest
{
    public partial interface IAzureRestClient : IDisposable
    {
        /// <summary>
        /// Gets the IAzureRestOperations.
        /// </summary>
        IAzureRestOperations Operations { get; }
    }
}
