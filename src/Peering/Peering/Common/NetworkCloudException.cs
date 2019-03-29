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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using System;
    using System.Text;

    using Microsoft.Rest.Azure;

    /// <summary>
    /// The network cloud exception.
    /// </summary>
    public class NetworkCloudException : CloudException
    {
        /// <summary>
        /// The request id header in response.
        /// </summary>
        protected const string RequestIdHeaderInResponse = "x-ms-request-id";

        /// <inheritdoc />
        public NetworkCloudException(CloudException ex)
            : base(GetErrorMessageWithRequestIdInfo(ex), ex)
        {
        }

        /// <summary>
        /// The get error message with request id info.
        /// </summary>
        /// <param name="cloudException">
        /// The cloud exception.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        protected static string GetErrorMessageWithRequestIdInfo(CloudException cloudException)
        {
            if (cloudException == null) throw new ArgumentNullException("cloudException");

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(cloudException.Message)) sb.Append(cloudException.Message);

            if (cloudException.Response == null)
            {
                return sb.ToString();
            }

            sb.AppendLine().AppendFormat("StatusCode: {0}", cloudException.Response.StatusCode.GetHashCode());
            sb.AppendLine().AppendFormat("ReasonPhrase: {0}", cloudException.Response.ReasonPhrase);
            if (cloudException.Response.Headers == null
                || !cloudException.Response.Headers.ContainsKey(RequestIdHeaderInResponse))
                return sb.ToString();

            var operationId = cloudException.RequestId;

            sb.AppendLine().AppendFormat(
                "OperationID : '{0}'",
                operationId);
            return sb.ToString();
        }
    }
}