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

using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.StorageSync.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Common.Exceptions
{
    /// <summary>
    /// Class StorageSyncCloudException.
    /// Implements the <see cref="Microsoft.Rest.Azure.CloudException" />
    /// </summary>
    /// <seealso cref="Microsoft.Rest.Azure.CloudException" />
    public class StorageSyncCloudException : Rest.Azure.CloudException
    {
        /// <summary>
        /// The request identifier header in response
        /// </summary>
        protected const string RequestIdHeaderInResponse = "x-ms-request-id";

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncCloudException" /> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public StorageSyncCloudException(Rest.Azure.CloudException ex)
            : base(GetErrorMessageWithRequestIdInfo(ex), ex)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncCloudException" /> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public StorageSyncCloudException(StorageSyncErrorException ex)
            : base(ex.Body?.Error?.Message ?? ex.Message, ex)
        {
        }

        /// <summary>
        /// Gets the error message with request identifier information.
        /// </summary>
        /// <param name="cloudException">The cloud exception.</param>
        /// <returns>System.String.</returns>
        protected static string GetErrorMessageWithRequestIdInfo(Rest.Azure.CloudException cloudException)
        {
            if (cloudException == null)
            {
                return StorageSyncResources.CloudNoInformationError;
            }

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(cloudException.Message))
            {
                sb.Append(cloudException.Message);
            }

            if (cloudException.Response == null)
            {
                return sb.ToString();
            }

            if (cloudException.Response.Content != null)
            {
                StorageSyncError storageSyncError = JsonConvert.DeserializeObject<StorageSyncError>(cloudException.Response.Content);

                if (storageSyncError.Error != null)
                {
                    sb.AppendLine().AppendFormat($"{nameof(storageSyncError.Error.Code)}: {storageSyncError.Error.Code}");
                    sb.AppendLine().AppendFormat($"{nameof(storageSyncError.Error.Message)}: {storageSyncError.Error.Message}");
                    sb.AppendLine().AppendFormat($"{nameof(storageSyncError.Error.Target)}: {storageSyncError.Error.Target}");
                }

            }

            if (!cloudException.Response.StatusCode.Equals(HttpStatusCode.OK))
            {
                sb.AppendLine().AppendFormat($"{nameof(cloudException.Response.StatusCode)}: {cloudException.Response.StatusCode.GetHashCode()}");
                sb.AppendLine().AppendFormat($"{nameof(cloudException.Response.ReasonPhrase)}: {cloudException.Response.ReasonPhrase}");

                if (cloudException.Response.Headers == null
                    || !cloudException.Response.Headers.ContainsKey(RequestIdHeaderInResponse))
                {
                    return sb.ToString();
                }

                sb.AppendLine().AppendFormat($"{nameof(cloudException.RequestId)} : {cloudException.RequestId}");
            }

            return sb.ToString();
        }
    }
}
