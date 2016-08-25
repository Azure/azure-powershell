// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses
{
    using Cmdlets.Utilities;
    using System;
    using System.Net;

    /// <summary>
    /// The error response message exception.
    /// </summary>
    public class ErrorResponseMessageException : Exception
    {
        /// <summary>
        /// Gets or sets the http status code.
        /// </summary>
        public HttpStatusCode HttpStatus { get; set; }

        /// <summary>
        /// Gets or sets the error response code.
        /// </summary>
        public ErrorResponseMessage ErrorResponseMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponseMessageException" /> class.
        /// </summary>
        /// <param name="httpStatus">The http status code.</param>
        /// <param name="errorResponseMessage">The error response code.</param>
        /// <param name="errorMessage">The error response message.</param>
        /// <param name="innerException">Optional. The inner exception.</param>
        public ErrorResponseMessageException(HttpStatusCode httpStatus, ErrorResponseMessage errorResponseMessage, string errorMessage, Exception innerException = null)
            : base(errorMessage, innerException)
        {
            if (HttpUtility.IsSuccessfulRequest(httpStatus))
            {
                throw new ArgumentException(
                    message: "The error response message exception should not be used for successful http response messages.",
                    paramName: "httpStatus");
            }

            this.HttpStatus = httpStatus;
            this.ErrorResponseMessage = errorResponseMessage;
        }
    }
}
