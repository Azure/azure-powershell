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

using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Threading;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Removes a named diagnostic setting or disables the setting called 'service' if the name argument is not present or if is 'service'.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiagnosticSetting", SupportsShouldProcess = true), OutputType(typeof(AzureOperationResponse))]
    public class RemoveAzureRmDiagnosticSettingCommand : ManagementCmdletBase
    {
        /// <summary>
        /// This is a temporary constant to provide backwards compatibility
        /// </summary>
        internal const string TempServiceName = "service";

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the diagnostic setting")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            string requestId;
            HttpStatusCode statusCode;

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                WriteDebugWithTimestamp(string.Format(CultureInfo.InvariantCulture, "Listing existing diagnostics settings for resourceId '{0}'", this.ResourceId));
                IList<DiagnosticSettingsResource> listSettings = this.MonitorManagementClient.DiagnosticSettings.ListAsync(resourceUri: this.ResourceId).Result.Value;

                if (listSettings.Any())
                {
                    if (listSettings.Count == 1)
                    {
                        // Default to the only existing setting regardless of name
                        this.Name = listSettings[0].Name;
                    }
                    else
                    {
                        throw new ErrorResponseException
                        {
                            Body = new ErrorResponse
                            {
                                Code = HttpStatusCode.Ambiguous.ToString(),
                                Message = "Multiple resources exist, but no name given as input."
                            },
                            Response = new HttpResponseMessageWrapper(
                                new System.Net.Http.HttpResponseMessage
                                {
                                    StatusCode = HttpStatusCode.Ambiguous,
                                    ReasonPhrase = "Multiple resources exist, but no name given as input."
                                },
                                null)
                        };
                    }
                }
                else
                {
                    WriteDebugWithTimestamp("No setting to delete for resource: {0}", this.ResourceId);
                    return;
                }

                DiagnosticSettingsResource singleResource = listSettings.FirstOrDefault(e => string.Equals(e.Name, this.Name, StringComparison.OrdinalIgnoreCase));
                if (singleResource == null)
                {
                    throw new ErrorResponseException
                    {
                        Body = new ErrorResponse
                        {
                            Code = HttpStatusCode.NotFound.ToString(),
                            Message = string.Format(
                                CultureInfo.InvariantCulture,
                                "Diagnostic setting named {0} not found.",
                                this.Name)
                        },
                        Response = new HttpResponseMessageWrapper(
                            new System.Net.Http.HttpResponseMessage
                            {
                                StatusCode = HttpStatusCode.NotFound,
                                ReasonPhrase = string.Format(
                                    CultureInfo.InvariantCulture,
                                    "Diagnostic setting named {0} not found.",
                                    this.Name)
                            },
                            null)
                    };
                }
            }

            if (ShouldProcess(
                target: string.Format("Remove a diagnostic setting for resource Id: {0}", this.ResourceId),
                action: "Remove a diagnostic setting"))
            {
                WriteDebugWithTimestamp("Removing named diagnostic setting: {0}", this.Name);
                Rest.Azure.AzureOperationResponse resultDelete = this.MonitorManagementClient.DiagnosticSettings.DeleteWithHttpMessagesAsync(
                    resourceUri: this.ResourceId,
                    name: this.Name).Result;

                requestId = resultDelete.RequestId;
                statusCode = resultDelete.Response != null ? resultDelete.Response.StatusCode : HttpStatusCode.OK;

                WriteDebugWithTimestamp("Sending response");
                var response = new AzureOperationResponse
                {
                    RequestId = requestId,
                    StatusCode = statusCode
                };

                WriteObject(response);
            }
            else
            {
                WriteDebugWithTimestamp("Delete operation cancelled");
                return;
            }
        }

        private void DisableAllCategoriesAndTimegrains(DiagnosticSettingsResource properties)
        {
            if (properties.Logs != null)
            {
                foreach (var log in properties.Logs)
                {
                    log.Enabled = false;
                }
            }

            if (properties.Metrics != null)
            {
                foreach (var metric in properties.Metrics)
                {
                    metric.Enabled = false;
                }
            }
        }
    }
}
