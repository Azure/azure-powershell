﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Remove an Alert rule
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertRule", SupportsShouldProcess = true), OutputType(typeof(AzureOperationResponse))]
    public class RemoveAzureRmAlertRuleCommand : ManagementCmdletBase
    {
        internal const string RemoveAzureRmAlertRuleParamGroup = "RemoveAlertRules";

        #region Parameter declaration

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = RemoveAzureRmAlertRuleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

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
            if (ShouldProcess(
                target: string.Format("Remove an alert rule: {0} from resource group: {1}", this.Name, this.ResourceGroupName),
                action: "Remove an alert rule"))
            {
                var result = this.MonitorManagementClient.AlertRules.DeleteWithHttpMessagesAsync(resourceGroupName: this.ResourceGroupName, ruleName: this.Name).Result;

                var response = new AzureOperationResponse()
                {
                    RequestId = result.RequestId,
                    StatusCode = result.Response != null ? result.Response.StatusCode : HttpStatusCode.OK
                };

                WriteObject(response);
            }
        }
    }
}
