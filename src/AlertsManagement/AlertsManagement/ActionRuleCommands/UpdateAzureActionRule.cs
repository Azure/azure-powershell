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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Newtonsoft.Json;
using System.Collections;
using Microsoft.Azure.PowerShell.Cmdlets.AlertsManagement.Properties;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionRule", DefaultParameterSetName = ByNameSimplifiedPatchParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSActionRule))]
    public class UpdateAzureActionRule : AlertsManagementBaseCmdlet
    {
        #region Parameter Set Names

        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByNameSimplifiedPatchParameterSet = "ByNameSimplifiedPatch";

        #endregion

        #region Parameters declarations
        /// <summary>
        /// Gets or sets the resource id parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id of action rule")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the input object
        /// </summary>
        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The action rule resource")]
        public PSActionRule InputObject { get; set; }

        /// <summary>
        /// Gets or sets the action rule name
        /// </summary>
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = true, HelpMessage = "Action rule name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = true, HelpMessage = "Action rule name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets simplified property of patch object : status
        /// </summary>
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = false, HelpMessage = "Action rule status")]
        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = false, HelpMessage = "Action rule status")]
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = false, HelpMessage = "Action rule status")]
        [PSArgumentCompleter(ActionRuleStatus.Enabled, ActionRuleStatus.Disabled)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets simplified property of patch object : tags
        /// </summary>
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = false, HelpMessage = "Action rule tags")]
        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = false, HelpMessage = "Action rule tags")]
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = false, HelpMessage = "Action rule tags")]
        public Hashtable Tag { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {      
            PSActionRule updatedActionRule = new PSActionRule();
            switch (ParameterSetName)
            {
                case ByNameSimplifiedPatchParameterSet:
                    if (ShouldProcess(
                        target: string.Format(Resources.TargetWithRG, this.Name, this.ResourceGroupName),
                        action: Resources.CreateOrUpdateActionRule_Action))
                    {
                        updatedActionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.UpdateWithHttpMessagesAsync(
                        resourceGroupName: ResourceGroupName,
                        actionRuleName: Name,
                        actionRulePatch: new PatchObject(
                                status: Status,
                                tags: Tag
                            )
                        ).Result.Body);
                    }
                    break;

                case ByInputObjectParameterSet:
                    if (ShouldProcess(
                        target: string.Format(Resources.Target, this.InputObject.Id),
                        action: Resources.CreateOrUpdateActionRule_Action))
                    {
                        var extractedInfo = CommonUtils.ExtractFromActionRuleResourceId(InputObject.Id);
                        updatedActionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.UpdateWithHttpMessagesAsync(
                            resourceGroupName: extractedInfo.ResourceGroupName,
                            actionRuleName: extractedInfo.Resource,
                            actionRulePatch: new PatchObject(
                                    status: Status,
                                    tags: Tag
                                )
                            ).Result.Body);
                    }
                    break;

                case ByResourceIdParameterSet:
                    if (ShouldProcess(
                        target: string.Format(Resources.Target, this.ResourceId),
                        action: Resources.CreateOrUpdateActionRule_Action))
                    {
                        var info = CommonUtils.ExtractFromActionRuleResourceId(ResourceId);
                        updatedActionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.UpdateWithHttpMessagesAsync(
                            resourceGroupName: info.ResourceGroupName,
                            actionRuleName: info.Resource,
                            actionRulePatch: new PatchObject(
                                    status: Status,
                                    tags: Tag
                                )
                            ).Result.Body);
                    }
                    break;
            }

            WriteObject(sendToPipeline: updatedActionRule);
        }
    }
}