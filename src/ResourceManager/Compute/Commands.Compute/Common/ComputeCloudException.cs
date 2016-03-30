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

using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Hyak.Common;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;

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
                throw new ArgumentNullException("cloudException");
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

            if (cloudException.Response.StatusCode.Equals(HttpStatusCode.OK)
                && cloudException.Response.Content != null)
            {
                var errorReturned = JsonConvert.DeserializeObject<ComputeLongRunningOperationError>(
                    cloudException.Response.Content);

                sb.AppendLine().AppendFormat("StartTime: {0}", errorReturned.StartTime);
                sb.AppendLine().AppendFormat("EndTime: {0}", errorReturned.EndTime);
                sb.AppendLine().AppendFormat("OperationID: {0}", errorReturned.OperationId);
                sb.AppendLine().AppendFormat("Status: {0}", errorReturned.Status);
                if (errorReturned.Error == null)
                {
                    return sb.ToString();
                }

                sb.AppendLine().AppendFormat("ErrorCode: {0}", errorReturned.Error.Code);
                sb.AppendLine().AppendFormat("ErrorMessage: {0}", errorReturned.Error.Message);
            }
            else
            {
                sb.AppendLine().AppendFormat("StatusCode: {0}", cloudException.Response.StatusCode.GetHashCode());
                sb.AppendLine().AppendFormat("ReasonPhrase: {0}", cloudException.Response.ReasonPhrase);
                if (cloudException.Response.Headers == null
                    || !cloudException.Response.Headers.ContainsKey(RequestIdHeaderInResponse))
                {
                    return sb.ToString();
                }

                var headers = cloudException.Response.Headers;

                var match = Regex.Match(headers.ToString(),
                    @"x-ms-request-id: ([a-z0-9]{8}\-[a-z0-9]{4}\-[a-z0-9]{4}\-[a-z0-9]{4}\-[a-z0-9]{12})",
                    RegexOptions.IgnoreCase);
                string operationId = (match.Success) ? match.Groups[1].Value : "";

                sb.AppendLine().AppendFormat(
                    "OperationID : '{0}'",
                    operationId);
            }
            return sb.ToString();
        }
    }

    public class ComputeLongRunningOperationError
    {
        public string OperationId;
        public string Status;
        public DateTime? StartTime;
        public DateTime? EndTime;
        public ApiError Error;
    }
}
