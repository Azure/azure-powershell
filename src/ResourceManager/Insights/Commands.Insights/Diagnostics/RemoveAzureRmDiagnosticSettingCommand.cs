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
using System.Globalization;
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
            if (ShouldProcess(
                target: string.Format("Remove a diagnostic setting for resource Id: {0}", this.ResourceId),
                action: "Remove a diagnostic setting"))
            {
                // Name defaults to "service"
                if (string.IsNullOrWhiteSpace(this.Name))
                {
                    this.Name = TempServiceName;
                }

                string requestId;
                HttpStatusCode statusCode;
                bool isService = string.Equals(TempServiceName, this.Name, System.StringComparison.OrdinalIgnoreCase);
                if (isService)
                {
                    WriteDebugWithTimestamp("Getting 'service' diagnostic setting");
                    AzureOperationResponse<DiagnosticSettingsResource> result = this.MonitorManagementClient.DiagnosticSettings.GetWithHttpMessagesAsync(resourceUri: this.ResourceId, name: TempServiceName).Result;
                    if (result.Response == null)
                    {
                        WriteDebugWithTimestamp("Response was null");
                        requestId = result.RequestId;
                        statusCode = HttpStatusCode.OK;
                    }
                    else if (!result.Response.IsSuccessStatusCode)
                    {
                        // NotFound is still OK since this cmdlet want to delete
                        WriteDebugWithTimestamp("Response marked as not successful");
                        if (result.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            WriteErrorWithTimestamp(message: string.Format(CultureInfo.InvariantCulture, "Error removing Diagnostic Settings. Status code: {0}", result.Response.StatusCode));
                            return;
                        }

                        WriteDebugWithTimestamp("Response marked as not NotFound");
                        requestId = result.RequestId;
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        WriteDebugWithTimestamp("Setting successfully recovered, disabling it");
                        this.DisableAllCategoriesAndTimegrains(result.Body);

                        AzureOperationResponse<DiagnosticSettingsResource> resultService = this.MonitorManagementClient.DiagnosticSettings.CreateOrUpdateWithHttpMessagesAsync(
                            resourceUri: this.ResourceId,
                            parameters: result.Body,
                            name: TempServiceName).Result;

                        requestId = resultService.RequestId;
                        statusCode = resultService.Response != null ? resultService.Response.StatusCode : HttpStatusCode.OK;
                    }
                }
                else
                {
                    WriteDebugWithTimestamp("Removing named diagnostic setting: {0}", this.Name);
                    Rest.Azure.AzureOperationResponse resultDelete = this.MonitorManagementClient.DiagnosticSettings.DeleteWithHttpMessagesAsync(
                        resourceUri: this.ResourceId,
                        name: this.Name).Result;

                    requestId = resultDelete.RequestId;
                    statusCode = resultDelete.Response != null ? resultDelete.Response.StatusCode : HttpStatusCode.OK;
                }

                WriteDebugWithTimestamp("Sending response");
                var response = new AzureOperationResponse
                {
                    RequestId = requestId,
                    StatusCode = statusCode
                };

                WriteObject(response);
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
