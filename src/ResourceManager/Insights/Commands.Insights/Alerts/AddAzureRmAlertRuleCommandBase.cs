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
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Management.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Add an Alert rule command base
    /// </summary>
    public abstract class AddAzureRmAlertRuleCommandBase : ManagementCmdletBase
    {
        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the Location parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Location name")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Description (rule description) parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule description")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the DisableRule flag.
        /// <para>Using DisableRule to make false the default, i.e. if the user does not include it in the call, the rule will be enabled.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The disable rule (status) flag")]
        public SwitchParameter DisableRule { get; set; }

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the rule name parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert rule name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of rule actions
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of rule actions")]
        [ValidateNotNullOrEmpty]
        public List<RuleAction> Actions { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            AlertRuleResource parameters = this.CreateSdkCallParameters();

            // Part of the result of this operation is operation (result.Body ==> a AutoscaleSettingResource) is being discarded for backwards compatibility
            var result = this.MonitorManagementClient.AlertRules.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName: this.ResourceGroup, parameters: parameters, ruleName: parameters.AlertRuleResourceName).Result;

            var response = new PSAddAlertRuleOperationResponse
            {
                RequestId = result.RequestId,
                StatusCode = result.Response != null ? result.Response.StatusCode : HttpStatusCode.OK,
                AlertRule = result.Body
            };

            WriteObject(response);
        }

        /// <summary>
        /// When overriden by a descendant class this method creates the set of parameters for the call to the sdk
        /// </summary>
        /// <returns>The set of parameters for the call to the sdk</returns>
        protected abstract AlertRuleResource CreateSdkCallParameters();
    }
}
