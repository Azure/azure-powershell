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

using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;
using System;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertProcessingRule", DefaultParameterSetName = ListAlertProcessingRulesParameterSet)]
    [OutputType(typeof(PSAlertProcessingRule))]
    public class GetAzureAlertProcessingRule : AlertsManagementBaseCmdlet
    {
        #region Parameter Set Names

        private const string ResourceIdParameterSet = "ResourceId";
        private const string ListAlertProcessingRulesParameterSet = "ListAlertProcessingRules";
        private const string ListAlertProcessingRulesByResourceGroupParameterSet = "ListAlertProcessingRulesByResourceGroupName";
        private const string AlertProcessingRuleByNameParameterSet = "AlertProcessingRuleByName";

        #endregion

        #region Parameters declarations

        /// <summary>
        /// Alert Processing rule name
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = AlertProcessingRuleByNameParameterSet,
                   HelpMessage = "Name of alert processing rule.")]
        public string Name { get; set; }

        /// <summary>
        /// Resource Group Name
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ListAlertProcessingRulesByResourceGroupParameterSet,
                   HelpMessage = "Resource Group Name in which alert processing rule resides.")]
        [Parameter(Mandatory = true,
                   ParameterSetName = AlertProcessingRuleByNameParameterSet,
                   HelpMessage = "Resource Group Name in which alert processing rule resides.")]
        public string ResourceGroupName { get; set; }


        /// <summary>
        /// Resource Id of Alert Processing rule
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ResourceIdParameterSet,
                   HelpMessage = "Get Alert Processing rule by resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case ListAlertProcessingRulesParameterSet:
                    case ListAlertProcessingRulesByResourceGroupParameterSet:
                        IPage<AlertProcessingRule> pageResult = new Page<AlertProcessingRule>();
                        List<AlertProcessingRule> resultList = new List<AlertProcessingRule>();
                        bool listByResourceGroup = false;

                        if (string.IsNullOrWhiteSpace(ResourceGroupName))
                        {
                            pageResult = this.AlertsManagementClient.AlertProcessingRules.ListBySubscriptionWithHttpMessagesAsync(
                            ).Result.Body;

                            listByResourceGroup = false;
                        }
                        else
                        {
                            pageResult = this.AlertsManagementClient.AlertProcessingRules.ListByResourceGroupWithHttpMessagesAsync(
                                resourceGroupName: ResourceGroupName
                            ).Result.Body;

                            listByResourceGroup = true;
                        }

                        // Deal with paging in response
                        ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
                        ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;

                        // Any items before this count should be return
                        ulong lastCount = MyInvocation.BoundParameters.ContainsKey("First") ? skip + first : ulong.MaxValue;
                        ulong currentCount = 0;
                        var nextPageLink = pageResult.NextPageLink;

                        do
                        {
                            nextPageLink = pageResult.NextPageLink;
                            List<AlertProcessingRule> tempList = pageResult.ToList();
                            if (currentCount + (ulong)tempList.Count - 1 < skip)
                            {
                                // skip the whole chunk if they are all in skip
                                currentCount += (ulong)tempList.Count;
                            }
                            else
                            {
                                foreach (AlertProcessingRule currentActionRule in tempList)
                                {
                                    // not return "skip" count of items in the begin, and only return "first" count of items after that.
                                    if (currentCount >= skip && currentCount < lastCount)
                                    {
                                        resultList.Add(currentActionRule);
                                    }
                                    currentCount++;
                                    if (currentCount >= lastCount)
                                    {
                                        break;
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(nextPageLink))
                            {
                                if (listByResourceGroup)
                                {
                                    pageResult = this.AlertsManagementClient.AlertProcessingRules.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink).Result.Body;
                                }
                                else
                                {
                                    pageResult = this.AlertsManagementClient.AlertProcessingRules.ListBySubscriptionNextWithHttpMessagesAsync(nextPageLink).Result.Body;
                                }
                            }

                        } while (!string.IsNullOrEmpty(nextPageLink) && currentCount < lastCount);

                        WriteObject(resultList.Select((r) => TransformOutput(r)), enumerateCollection: true);
                        break;

                    case AlertProcessingRuleByNameParameterSet:
                        var rulebyName = this.AlertsManagementClient.AlertProcessingRules.GetByNameWithHttpMessagesAsync(ResourceGroupName, Name).Result.Body;
                        WriteObject(sendToPipeline: TransformOutput(rulebyName));
                        break;

                    case ResourceIdParameterSet:
                        ExtractedInfo info = CommonUtils.ExtractFromActionRuleResourceId(ResourceId);
                        var ruleById = this.AlertsManagementClient.AlertProcessingRules.GetByNameWithHttpMessagesAsync(info.ResourceGroupName, info.Resource).Result.Body;
                        WriteObject(sendToPipeline: TransformOutput(ruleById));
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private PSAlertProcessingRule TransformOutput(AlertProcessingRule input)
        {
            if (input.Properties.Actions[0] is AddActionGroups)
            {
                return new PSActionGroupAlertProcessingRule(input);
            }
            if (input.Properties.Actions[0] is RemoveAllActionGroups)
            {
                return new PSSuppressionAlertProcessingRule(input);
            }
                return new PSAlertProcessingRule(input);
        }
    }
}