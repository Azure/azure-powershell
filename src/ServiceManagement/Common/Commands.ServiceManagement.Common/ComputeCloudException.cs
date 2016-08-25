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

using Hyak.Common;
using System;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class ComputeCloudException : CloudException
    {
        protected const string RequestIdHeaderInResponse = "x-ms-request-id";

        public ComputeCloudException(CloudException ex)
            : base(GetErrorMessageWithRequestIdInfo(ex), ex)
        {
        }

        protected static string GetErrorMessageWithRequestIdInfo(CloudException cloudException)
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

            if (cloudException.Response != null &&
                cloudException.Response.Headers != null)
            {
                var headers = cloudException.Response.Headers;
                if (headers.ContainsKey(RequestIdHeaderInResponse))
                {
                    sb.AppendLine().AppendFormat(
                        "OperationID : '{0}'",
                        headers[RequestIdHeaderInResponse].FirstOrDefault());
                }
            }

            return sb.ToString();
        }
    }
}