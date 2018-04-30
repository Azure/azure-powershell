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

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PolicyInsights.Common;
    using Microsoft.Azure.Commands.PolicyInsights.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.PolicyInsights;
    using RestApiModels = Microsoft.Azure.Management.PolicyInsights.Models;

    /// <summary>
    /// Gets policy states
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmPolicyStateSummary", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PolicyStateSummary))]
    public class GetAzureRmPolicyStateSummary : PolicyInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ManagementGroupName)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicySetDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string PolicySetDefinitionName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicyDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinitionName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicyAssignmentName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicyAssignmentName)]
        [ValidateNotNullOrEmpty]
        public string PolicyAssignmentName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        public int Top { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        public DateTime From { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        public DateTime To { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            var queryOptions = new RestApiModels.QueryOptions
            {
                Top = MyInvocation.BoundParameters.ContainsKey("Top") ? (int?)Top : null,
                FromProperty = MyInvocation.BoundParameters.ContainsKey("From") ? (DateTime?)From : null,
                To = MyInvocation.BoundParameters.ContainsKey("To") ? (DateTime?)To : null,
                Filter = Filter
            };

            RestApiModels.SummarizeResults summarizeResults;

            try
            {
                switch (ParameterSetName)
                {
                    case ParameterSetNames.ManagementGroupScope:
                        summarizeResults = PolicyInsightsClient.PolicyStates.SummarizeForManagementGroup(
                            ManagementGroupName,
                            queryOptions);
                        break;
                    case ParameterSetNames.SubscriptionScope:
                        summarizeResults = PolicyInsightsClient.PolicyStates.SummarizeForSubscription(
                            SubscriptionId ?? DefaultContext.Subscription.Id,
                            queryOptions);
                        break;
                    case ParameterSetNames.ResourceGroupScope:
                        summarizeResults = PolicyInsightsClient.PolicyStates.SummarizeForResourceGroup(
                            SubscriptionId ?? DefaultContext.Subscription.Id,
                            ResourceGroupName,
                            queryOptions);
                        break;
                    case ParameterSetNames.ResourceScope:
                        summarizeResults = PolicyInsightsClient.PolicyStates.SummarizeForResource(
                            ResourceId,
                            queryOptions);
                        break;
                    case ParameterSetNames.PolicySetDefinitionScope:
                        summarizeResults = PolicyInsightsClient.PolicyStates.SummarizeForPolicySetDefinition(
                            SubscriptionId ?? DefaultContext.Subscription.Id,
                            PolicySetDefinitionName,
                            queryOptions);
                        break;
                    case ParameterSetNames.PolicyDefinitionScope:
                        summarizeResults = PolicyInsightsClient.PolicyStates.SummarizeForPolicyDefinition(
                            SubscriptionId ?? DefaultContext.Subscription.Id,
                            PolicyDefinitionName,
                            queryOptions);
                        break;
                    case ParameterSetNames.SubscriptionLevelPolicyAssignmentScope:
                        summarizeResults = PolicyInsightsClient.PolicyStates.SummarizeForSubscriptionLevelPolicyAssignment(
                            SubscriptionId ?? DefaultContext.Subscription.Id,
                            PolicyAssignmentName,
                            queryOptions);
                        break;
                    case ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope:
                        summarizeResults = PolicyInsightsClient.PolicyStates.SummarizeForResourceGroupLevelPolicyAssignment(
                            SubscriptionId ?? DefaultContext.Subscription.Id,
                            ResourceGroupName,
                            PolicyAssignmentName,
                            queryOptions);
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
            catch (RestApiModels.QueryFailureException e)
            {
                WriteExceptionError(e.Body?.Error != null
                    ? new Exception($"{e.Message} ({e.Body.Error.Code}: {e.Body.Error.Message})")
                    : e);
                return;
            }

            var summary = summarizeResults.Value.First();
            WriteObject(new PolicyStateSummary(summary));
        }
    }
}
