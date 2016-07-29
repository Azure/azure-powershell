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


using Microsoft.Azure.Commands.Compute.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public class ComputeCloudException : Rest.Azure.CloudException
    {
        protected const string RequestIdHeaderInResponse = "x-ms-request-id";

        public ComputeCloudException(Rest.Azure.CloudException ex)
            : base(GetErrorMessageWithRequestIdInfo(ex), ex)
        {
        }

        protected static string GetErrorMessageWithRequestIdInfo(Rest.Azure.CloudException cloudException)
        {
            if (cloudException == null)
            {
                return "No information in the cloud exception.";
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
                var errorReturned = JsonConvert.DeserializeObject<PSComputeLongRunningOperation>(
                    cloudException.Response.Content);

                if (errorReturned.Error != null)
                {
                    sb.AppendLine().AppendFormat("ErrorCode: {0}", errorReturned.Error.Code);
                    sb.AppendLine().AppendFormat("ErrorMessage: {0}", errorReturned.Error.Message);
                }

                if (errorReturned.StartTime != null)
                {
                    sb.AppendLine().AppendFormat("StartTime: {0}", errorReturned.StartTime);
                }

                if (errorReturned.EndTime != null)
                {
                    sb.AppendLine().AppendFormat("EndTime: {0}", errorReturned.EndTime);
                }

                if (string.IsNullOrWhiteSpace(errorReturned.OperationId) &&
                    !string.IsNullOrWhiteSpace(errorReturned.Name))
                {
                    sb.AppendLine().AppendFormat("OperationID: {0}", errorReturned.Name);
                }
                else if (!string.IsNullOrWhiteSpace(errorReturned.OperationId))
                {
                    sb.AppendLine().AppendFormat("OperationID: {0}", errorReturned.OperationId);
                }

                if (!string.IsNullOrWhiteSpace(errorReturned.Status))
                {
                    sb.AppendLine().AppendFormat("Status: {0}", errorReturned.Status);
                }
            }

            if (!cloudException.Response.StatusCode.Equals(HttpStatusCode.OK))
            {
                sb.AppendLine().AppendFormat("StatusCode: {0}", cloudException.Response.StatusCode.GetHashCode());
                sb.AppendLine().AppendFormat("ReasonPhrase: {0}", cloudException.Response.ReasonPhrase);
                if (cloudException.Response.Headers == null
                    || !cloudException.Response.Headers.ContainsKey(RequestIdHeaderInResponse))
                {
                    return sb.ToString();
                }

                string operationId = cloudException.RequestId;

                sb.AppendLine().AppendFormat(
                    "OperationID : {0}",
                    operationId);
            }
            return sb.ToString();
        }
    }
}
