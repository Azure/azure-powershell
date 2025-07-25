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
    /// Gets policy events
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyEvent", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PolicyEvent))]
    public class GetAzureRmPolicyEvent : PolicyInsightsCmdletBase
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

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.OrderBy)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.OrderBy)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.OrderBy)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.OrderBy)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.OrderBy)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.OrderBy)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.OrderBy)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.OrderBy)]
        [ValidateNotNullOrEmpty]
        public string OrderBy { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Select)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Select)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Select)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Select)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Select)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Select)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Select)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Select)]
        [ValidateNotNullOrEmpty]
        public string Select { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.From)]
        public DateTime From { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.To)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.To)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.To)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.To)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.To)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.To)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.To)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.To)]
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

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Apply)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Apply)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Apply)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Apply)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicySetDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Apply)]
        [Parameter(ParameterSetName = ParameterSetNames.PolicyDefinitionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Apply)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Apply)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Apply)]
        [ValidateNotNullOrEmpty]
        public string Apply { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void Execute()
        {
            const int PageSize = 1000;

            int numberOfResults = MyInvocation.BoundParameters.ContainsKey("Top") ? Top : int.MaxValue;

            // Using the $top as a query parameter for the policy states API will cause it to return all results in a single page, which may exceed the response size limits.
            // Therefore, only pass a $top value if the requested number of results is below the size of a single page. If more than one page is needed, make paged requests until enough results were returned.
            var queryOptions = new RestApiModels.QueryOptions
            {
                Top = numberOfResults <= PageSize ? (int?)numberOfResults : null,
                OrderBy = OrderBy,
                Select = Select,
                FromProperty = MyInvocation.BoundParameters.ContainsKey("From") ? (DateTime?)From : null,
                To = MyInvocation.BoundParameters.ContainsKey("To") ? (DateTime?)To : null,
                Filter = Filter,
                Apply = Apply
            };

            var policyEventsQueryResults = new List<RestApiModels.PolicyEvent>();

            switch (ParameterSetName)
            {
                case ParameterSetNames.ManagementGroupScope:
                    PaginationHelper.ForEach(
                        getFirstPage: () => PolicyInsightsClient.PolicyEvents.ListQueryResultsForManagementGroup(ManagementGroupName, queryOptions),
                        getNextPage: nextLink => PolicyInsightsClient.PolicyEvents.ListQueryResultsForManagementGroupNext(nextLink),
                        action: results => policyEventsQueryResults.AddRange(results),
                        numberOfResults: numberOfResults,
                        cancellationToken: this.CancellationToken);

                    break;

                case ParameterSetNames.SubscriptionScope:
                    PaginationHelper.ForEach(
                        getFirstPage: () => PolicyInsightsClient.PolicyEvents.ListQueryResultsForSubscription(SubscriptionId ?? DefaultContext.Subscription.Id, queryOptions),
                        getNextPage: nextLink => PolicyInsightsClient.PolicyEvents.ListQueryResultsForSubscriptionNext(nextLink),
                        action: results => policyEventsQueryResults.AddRange(results),
                        numberOfResults: numberOfResults,
                        cancellationToken: this.CancellationToken);

                    break;

                case ParameterSetNames.ResourceGroupScope:
                    PaginationHelper.ForEach(
                        getFirstPage: () => PolicyInsightsClient.PolicyEvents.ListQueryResultsForResourceGroup(SubscriptionId ?? DefaultContext.Subscription.Id, ResourceGroupName, queryOptions),
                        getNextPage: nextLink => PolicyInsightsClient.PolicyEvents.ListQueryResultsForResourceGroupNext(nextLink),
                        action: results => policyEventsQueryResults.AddRange(results),
                        numberOfResults: numberOfResults,
                        cancellationToken: this.CancellationToken);

                    break;

                case ParameterSetNames.ResourceScope:
                    PaginationHelper.ForEach(
                        getFirstPage: () => PolicyInsightsClient.PolicyEvents.ListQueryResultsForResource(ResourceId, queryOptions),
                        getNextPage: nextLink => PolicyInsightsClient.PolicyEvents.ListQueryResultsForResourceNext(nextLink),
                        action: results => policyEventsQueryResults.AddRange(results),
                        numberOfResults: numberOfResults,
                        cancellationToken: this.CancellationToken);

                    break;

                case ParameterSetNames.PolicySetDefinitionScope:
                    PaginationHelper.ForEach(
                        getFirstPage: () => PolicyInsightsClient.PolicyEvents.ListQueryResultsForPolicySetDefinition(SubscriptionId ?? DefaultContext.Subscription.Id, PolicySetDefinitionName, queryOptions),
                        getNextPage: nextLink => PolicyInsightsClient.PolicyEvents.ListQueryResultsForPolicySetDefinitionNext(nextLink),
                        action: results => policyEventsQueryResults.AddRange(results),
                        numberOfResults: numberOfResults,
                        cancellationToken: this.CancellationToken);

                    break;

                case ParameterSetNames.PolicyDefinitionScope:
                    PaginationHelper.ForEach(
                        getFirstPage: () => PolicyInsightsClient.PolicyEvents.ListQueryResultsForPolicyDefinition(SubscriptionId ?? DefaultContext.Subscription.Id, PolicyDefinitionName, queryOptions),
                        getNextPage: nextLink => PolicyInsightsClient.PolicyEvents.ListQueryResultsForPolicyDefinitionNext(nextLink),
                        action: results => policyEventsQueryResults.AddRange(results),
                        numberOfResults: numberOfResults,
                        cancellationToken: this.CancellationToken);

                    break;

                case ParameterSetNames.SubscriptionLevelPolicyAssignmentScope:
                    PaginationHelper.ForEach(
                        getFirstPage: () => PolicyInsightsClient.PolicyEvents.ListQueryResultsForSubscriptionLevelPolicyAssignment(SubscriptionId ?? DefaultContext.Subscription.Id, PolicyAssignmentName, queryOptions),
                        getNextPage: nextLink => PolicyInsightsClient.PolicyEvents.ListQueryResultsForSubscriptionLevelPolicyAssignmentNext(nextLink),
                        action: results => policyEventsQueryResults.AddRange(results),
                        numberOfResults: numberOfResults,
                        cancellationToken: this.CancellationToken);

                    break;

                case ParameterSetNames.ResourceGroupLevelPolicyAssignmentScope:
                    PaginationHelper.ForEach(
                        getFirstPage: () => PolicyInsightsClient.PolicyEvents.ListQueryResultsForResourceGroupLevelPolicyAssignment(SubscriptionId ?? DefaultContext.Subscription.Id, ResourceGroupName, PolicyAssignmentName, queryOptions),
                        getNextPage: nextLink => PolicyInsightsClient.PolicyEvents.ListQueryResultsForResourceGroupLevelPolicyAssignmentNext(nextLink),
                        action: results => policyEventsQueryResults.AddRange(results),
                        numberOfResults: numberOfResults,
                        cancellationToken: this.CancellationToken);

                    break;

                default:
                    throw new PSInvalidOperationException();
            }

            WriteObject(policyEventsQueryResults.Select(policyEvent => new PolicyEvent(policyEvent)), true);
        }
    }
}
