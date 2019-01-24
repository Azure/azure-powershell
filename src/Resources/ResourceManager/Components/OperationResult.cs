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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using System;
    using System.Net;

    /// <summary>
    /// A simple class that represents the result of an operation.
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Gets or sets the status code that was returned.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the retry after interval that was returned.
        /// </summary>
        public TimeSpan? RetryAfter { get; set; }

        /// <summary>
        /// Gets or sets the long operation location Uri where clients can poll for progress of the operation.
        /// </summary>
        public Uri LocationUri { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Uri"/> of the <see cref="System.Net.Http.HttpRequestMessage"/> that created this result.
        /// </summary>
        public Uri OperationUri { get; set; }

        /// <summary>
        /// Gets or sets the azure async operation location Uri where clients can poll for progress of the operation.
        /// </summary>
        public Uri AzureAsyncOperationUri { get; set; }

        /// <summary>
        /// Gets or sets the percentage of completion. 
        /// </summary>
        public double? PercentComplete { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }
}
