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

using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Get the list of events for at a subscription level.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmDiagnosticSetting", SupportsShouldProcess = true), OutputType(typeof(AzureOperationResponse))]
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
                Rest.Azure.AzureOperationResponse result = this.MonitorManagementClient.DiagnosticSettings.DeleteWithHttpMessagesAsync(
                    resourceUri: this.ResourceId,
                    name: string.IsNullOrWhiteSpace(this.Name) ? TempServiceName : this.Name).Result;

                var response = new AzureOperationResponse
                {
                    RequestId = result.RequestId,
                    StatusCode = result.Response != null ? result.Response.StatusCode : HttpStatusCode.OK
                };

                WriteObject(response);
            }
        }
    }
}
