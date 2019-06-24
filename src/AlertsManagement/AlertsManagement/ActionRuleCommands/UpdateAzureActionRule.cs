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

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSActionRule))]
    public class UpdateAzureActionRule : AlertsManagementBaseCmdlet
    {
        #region Parameter Set Names

        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByNameJsonPatchParameterSet = "ByNameJsonPatch";
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
        [Parameter(ParameterSetName = ByNameJsonPatchParameterSet, Mandatory = true, HelpMessage = "Action rule name")]
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = true, HelpMessage = "Action rule name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(ParameterSetName = ByNameJsonPatchParameterSet, Mandatory = true, HelpMessage = "Action rule name")]
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = true, HelpMessage = "Action rule name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets patch object
        /// </summary>
        [Parameter(ParameterSetName = ByNameJsonPatchParameterSet, Mandatory = true, HelpMessage = "Action rule patch object in JSON format")]
        [ValidateNotNullOrEmpty]
        public string ActionRulePatch { get; set; }

        /// <summary>
        /// Gets or sets simplified property of patch object : status
        /// </summary>
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = false, HelpMessage = "Action rule status")]
        [PSArgumentCompleter(ActionRuleStatus.Enabled, ActionRuleStatus.Disabled)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets simplified property of patch object : tags
        /// </summary>
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = false, HelpMessage = "Action rule tags")]
        public object Tags { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (ShouldProcess(
                       target: string.Format("Update Action rule (status/tags)"),
                       action: "Update Action rule"))
            {
                PSActionRule updatedActionRule = new PSActionRule();
                switch (ParameterSetName)
                {
                    case ByNameJsonPatchParameterSet:
                        PatchObject patchObject = JsonConvert.DeserializeObject<PatchObject>(ActionRulePatch);
                        updatedActionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.UpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName,
                            actionRuleName: Name,
                            actionRulePatch: patchObject
                            ).Result.Body);
                        break;

                    case ByNameSimplifiedPatchParameterSet:
                        updatedActionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.UpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName,
                            actionRuleName: Name,
                            actionRulePatch: new PatchObject(
                                    status: Status,
                                    tags: Tags
                                )
                            ).Result.Body);
                        break;

                    case ByInputObjectParameterSet:
                        string[] tokens = InputObject.Id.Split('/');
                        updatedActionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.UpdateWithHttpMessagesAsync(
                            resourceGroupName: tokens[4],
                            actionRuleName: tokens[8],
                            actionRulePatch: new PatchObject(
                                    status: Status,
                                    tags: Tags
                                )
                            ).Result.Body);
                        break;

                    case ByResourceIdParameterSet:
                        string[] tokensRId = ResourceId.Split('/');
                        updatedActionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.UpdateWithHttpMessagesAsync(
                            resourceGroupName: tokensRId[4],
                            actionRuleName: tokensRId[8],
                            actionRulePatch: new PatchObject(
                                    status: Status,
                                    tags: Tags
                                )
                            ).Result.Body);
                        break;
                }

                WriteObject(sendToPipeline: string.Format("Successfully updated Action Rule : {0}.", Name));
                WriteObject(sendToPipeline: updatedActionRule);
            }
        }
    }
}