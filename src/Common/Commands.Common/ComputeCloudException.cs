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

            var sb = new StringBuilder(cloudException.Message);

            if (cloudException.Response != null)
            {
                var headers = cloudException.Response.Headers;
                if (headers != null && headers.ContainsKey(RequestIdHeaderInResponse))
                {
                    if (sb.Length > 0)
                    {
                        // If the original exception message is not empty, append a new line here.
                        sb.Append(Environment.NewLine);
                    }

                    sb.AppendFormat(
                        Properties.Resources.ComputeCloudExceptionOperationIdMessage,
                        headers[RequestIdHeaderInResponse].FirstOrDefault());
                }
            }

            return sb.ToString();
        }
    }
}