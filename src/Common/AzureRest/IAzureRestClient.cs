using Microsoft.Rest;
using System;

namespace Microsoft.WindowsAzure.Commands.Common.AzureRest
{
    public partial interface IAzureRestClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// Gets the IAzureRestOperations.
        /// </summary>
        IAzureRestOperations Operations { get; }
    }
}
