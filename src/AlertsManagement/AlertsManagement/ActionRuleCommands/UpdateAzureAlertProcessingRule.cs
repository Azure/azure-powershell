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
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertProcessingRule", DefaultParameterSetName = ByNameSimplifiedPatchParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSAlertProcessingRule))]
    public class UpdateAzureAlertProcessingRule : AlertsManagementBaseCmdlet
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
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id of alert processing rule")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the input object
        /// </summary>
        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The alert processing rule resource")]
        public PSAlertProcessingRule InputObject { get; set; }

        /// <summary>
        /// Gets or sets the action rule name
        /// </summary>
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = true, HelpMessage = "Alert Processing rule name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = true, HelpMessage = "Alert Processing rule name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets simplified property of patch object : status
        /// </summary>
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = false, HelpMessage = "Alert Processing rule status")]
        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = false, HelpMessage = "Alert Processing rule status")]
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = false, HelpMessage = "Alert Processing rule status")]
        [PSArgumentCompleter("True", "False")]
        public string Enabled { get; set; }

        /// <summary>
        /// Gets or sets simplified property of patch object : tags
        /// </summary>
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = false, HelpMessage = "Alert Processing rule tags")]
        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = false, HelpMessage = "Alert Processing rule tags")]
        [Parameter(ParameterSetName = ByNameSimplifiedPatchParameterSet, Mandatory = false, HelpMessage = "Alert Processing rule tags")]
        public Hashtable Tag { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            PSAlertProcessingRule updatedAlertProcessingRule = new PSAlertProcessingRule();
            try
            {
                switch (ParameterSetName)
                {
                    case ByNameSimplifiedPatchParameterSet:
                        if (ShouldProcess(
                            target: string.Format(Resources.TargetWithRG, this.Name, this.ResourceGroupName),
                            action: Resources.CreateOrUpdateAlertProcessingRule_Action))
                        {
                            updatedAlertProcessingRule = new PSAlertProcessingRule(this.AlertsManagementClient.AlertProcessingRules.UpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName,
                            alertProcessingRuleName: Name,
                            alertProcessingRulePatch: new PatchObject(
                                    enabled: Enabled != null ? bool.Parse(Enabled) : (bool?)null,
                                    tags: ParseTags()
                                )
                            ).Result.Body);
                        }
                        break;

                    case ByInputObjectParameterSet:
                        if (ShouldProcess(
                            target: string.Format(Resources.Target, this.InputObject.Id),
                            action: Resources.CreateOrUpdateAlertProcessingRule_Action))
                        {
                            var extractedInfo = CommonUtils.ExtractFromActionRuleResourceId(InputObject.Id);
                            updatedAlertProcessingRule = new PSAlertProcessingRule(this.AlertsManagementClient.AlertProcessingRules.UpdateWithHttpMessagesAsync(
                                resourceGroupName: extractedInfo.ResourceGroupName,
                                alertProcessingRuleName: extractedInfo.Resource,
                                alertProcessingRulePatch: new PatchObject(
                                    enabled: Enabled != null ? bool.Parse(Enabled) : (bool?)null,
                                        tags: ParseTags()

                                    )
                                ).Result.Body);
                        }
                        break;

                    case ByResourceIdParameterSet:
                        if (ShouldProcess(
                            target: string.Format(Resources.Target, this.ResourceId),
                            action: Resources.CreateOrUpdateAlertProcessingRule_Action))
                        {
                            var info = CommonUtils.ExtractFromActionRuleResourceId(ResourceId);
                            updatedAlertProcessingRule = new PSAlertProcessingRule(this.AlertsManagementClient.AlertProcessingRules.UpdateWithHttpMessagesAsync(
                                resourceGroupName: info.ResourceGroupName,
                                alertProcessingRuleName: info.Resource,
                                alertProcessingRulePatch: new PatchObject(
                                        enabled: Enabled != null ? bool.Parse(Enabled) : (bool?)null,
                                        tags: ParseTags()
                                    )
                                ).Result.Body);
                        }
                        break;
                }
            }
            catch (System.Exception e)
            {
                throw (e);
            }

            WriteObject(sendToPipeline: updatedAlertProcessingRule);
        }

        private IDictionary<string, string> ParseTags()
        {
            if (Tag == null)
            {
                return null;
            }
            Dictionary<string, string> tagsDictionary = new Dictionary<string, string>();
            foreach (var key in Tag.Keys)
            {
                tagsDictionary.Add((string)key, (string)Tag[key]);
            }
            return tagsDictionary;
        }
    }
}