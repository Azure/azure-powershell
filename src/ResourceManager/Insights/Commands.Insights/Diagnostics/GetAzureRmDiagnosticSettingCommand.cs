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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Gets the logs and metrics for the resource.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiagnosticSetting"), OutputType(typeof(PSServiceDiagnosticSettings))]
    public class GetAzureRmDiagnosticSettingCommand : ManagementCmdletBase
    {

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The ResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the diagnostics setting name parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The diagnostic setting name. Defaults to 'service'")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            // Temporary service name constant provided for backwards compatibility
            DiagnosticSettingsResource result = this.MonitorManagementClient.DiagnosticSettings.Get(
                resourceUri: this.ResourceId, 
                name: string.IsNullOrWhiteSpace(this.Name) ? SetAzureRmDiagnosticSettingCommand.TempServiceName : this.Name);

            var psResult = new PSServiceDiagnosticSettings(result);
            WriteObject(psResult);
        }
    }
}
