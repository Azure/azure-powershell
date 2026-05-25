// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Models
{
    /// <summary>
    /// Exception thrown for an invalid response with CommonCloudError information.
    /// </summary>
    public partial class CommonCloudErrorException : Microsoft.Rest.RestException
    {
        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        public Microsoft.Rest.HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public Microsoft.Rest.HttpResponseMessageWrapper Response { get; set; }

        /// <summary>
        /// Gets or sets the body object.
        /// </summary>
        public CommonCloudError Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the CommonCloudErrorException class.
        /// </summary>
        public CommonCloudErrorException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CommonCloudErrorException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public CommonCloudErrorException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CommonCloudErrorException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CommonCloudErrorException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
