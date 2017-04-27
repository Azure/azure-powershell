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

using System.Collections.Generic;
using System.Net;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Remove an Alert rule
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmAlertRule"), OutputType(typeof(List<AzureOperationResponse>))]
    public class RemoveAzureRmAlertRuleCommand : ManagementCmdletBase
    {
        internal const string RemoveAzureRmAlertRuleParamGroup = "Parameters for Remove-AzureRmAlertRule cmdlet";

        #region Parameter declaration

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = RemoveAzureRmAlertRuleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the rule name parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = RemoveAzureRmAlertRuleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert rule name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            WriteWarning("The type of the output will change in future releases to become a single object, not a list.");
            var result = this.MonitorManagementClient.AlertRules.DeleteWithHttpMessagesAsync(resourceGroupName: this.ResourceGroup, ruleName: this.Name).Result;

            // Keep this response for backwards compatibility.
            // Note: Delete operations return nothing in the new specification.
            var response = new List<AzureOperationResponse>
            {
                new AzureOperationResponse()
                {
                    RequestId = result.RequestId,
                    StatusCode = result.Response != null ? result.Response.StatusCode : HttpStatusCode.OK
                }
            };

            WriteObject(response);
        }
    }
}
