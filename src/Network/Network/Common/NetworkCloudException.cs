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


using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Network.Common
{
    public class NetworkCloudException : Rest.Azure.CloudException
    {
        protected const string RequestIdHeaderInResponse = "x-ms-request-id";

        public NetworkCloudException(Rest.Azure.CloudException ex)
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

            if (cloudException.Response != null)
            {
                sb.AppendLine().AppendFormat("StatusCode: {0}", cloudException.Response.StatusCode.GetHashCode());

                if (cloudException.Response.ReasonPhrase != null)
                {
                    sb.AppendLine().AppendFormat("ReasonPhrase: {0}", cloudException.Response.ReasonPhrase);
                }

                if (cloudException.Response.Content != null)
                {
                    var errorReturned = JsonConvert.DeserializeObject<PSNetworkLongRunningOperation>(
                        cloudException.Response.Content);

                    if (!string.IsNullOrEmpty(errorReturned.Status))
                    {
                        sb.AppendLine().AppendFormat("Status: {0}", errorReturned.Status);
                    }

                    if (errorReturned.Error != null)
                    {
                        if (!string.IsNullOrEmpty(errorReturned.Error.Code))
                        {
                            sb.AppendLine().AppendFormat("ErrorCode: {0}", errorReturned.Error.Code);
                        }

                        if (!string.IsNullOrEmpty(errorReturned.Error.Target))
                        {
                            sb.AppendLine().AppendFormat("Target: {0}", errorReturned.Error.Target);
                        }

                        if (!string.IsNullOrEmpty(errorReturned.Error.Message))
                        {
                            sb.AppendLine().AppendFormat("ErrorMessage: {0}", errorReturned.Error.Message);
                        }
                    }
                }
            }

            if (cloudException.Body != null && cloudException.Body.Details != null)
            {
                if (cloudException.Body.Details.Count != 0)
                {
                    sb.AppendLine().Append("Additional details:");

                    for (int i = 0, l = cloudException.Body.Details.Count; i < l; i++)
                    {
                        var details = cloudException.Body.Details[i];
                        string index = l == 1 ? string.Empty : string.Format("{0}. ", i + 1);

                        if (!string.IsNullOrEmpty(details.Code))
                        {
                            sb.AppendLine().AppendFormat("    {0}Code: {1}", index, details.Code);
                        }

                        if (!string.IsNullOrEmpty(details.Message))
                        {
                            sb.AppendLine().AppendFormat("    {0}Message: {1}", index, details.Message);
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(cloudException.RequestId))
            {
                sb.AppendLine().AppendFormat("OperationID : {0}", cloudException.RequestId);
            }

            return sb.ToString();
        }
    }
}

