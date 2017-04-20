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

using System.Net;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Deletes the Diagnostic Settings of a resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmDiagnosticSetting"), OutputType(typeof(PSDiagnosticSettingOperationResponse))]
    public class RemoveAzureRmDiagnosticSettingCommand : ManagementCmdletBase
    {

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The ResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the service. Defaults to 'service'")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                this.Name = "service";
            }

            Rest.Azure.AzureOperationResponse result = this.MonitorManagementClient.DiagnosticSettings.DeleteWithHttpMessagesAsync(resourceUri: this.ResourceId, name: this.Name, cancellationToken: CancellationToken.None).Result;
            var response = new PSDiagnosticSettingOperationResponse
            {
                RequestId = result.RequestId,
                StatusCode = result.Response != null ? result.Response.StatusCode : HttpStatusCode.OK
            };

            WriteObject(response);
        }
    }
}
