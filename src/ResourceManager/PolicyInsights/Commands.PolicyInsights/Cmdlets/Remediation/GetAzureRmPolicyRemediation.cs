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

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets.Remediation
{
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PolicyInsights.Common;
    using Microsoft.Azure.Commands.PolicyInsights.Models.Remediation;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Gets policy remediations.
    /// </summary>
    [Cmdlet("Get", AzureRMConstants.AzureRMPrefix + "PolicyRemediation", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSRemediation))]
    public class GetAzureRmPolicyRemediation : RemediationCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [Parameter(ParameterSetName = ParameterSetNames.GenericScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Scope)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ManagementGroupName)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Id")]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.GenericScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        public int Top { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.GenericScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        /// <summary>
        /// Executes the cmdlet to retrieve remediation resources
        /// </summary>
        public override void ExecuteCmdlet()
        {
            var queryOptions = new QueryOptions
            {
                Top = this.IsParameterBound(c => c.Top) ? (int?)Top : null,
                Filter = Filter
            };

            if (!string.IsNullOrEmpty(this.Name) && new[] { this.Scope, this.ManagementGroupName, this.ResourceGroupName }.Count(s => s != null) > 1)
            {
                throw new PSArgumentException($"Only one of {nameof(this.Scope)}, {nameof(this.ManagementGroupName)}, {nameof(this.ResourceGroupName)} can be specified when {nameof(this.Name)} is provided.");
            }

            // Determine the scope of the request and whether this is an individual GET or a list
            var rootScope = this.GetRootScope(scope: this.Scope, resourceId: this.ResourceId, managementGroupId: this.ManagementGroupName, resourceGroupName: this.ResourceGroupName);
            var remediationName = this.GetRemediationName(name: this.Name, resourceId: this.ResourceId);

            if (!string.IsNullOrEmpty(remediationName))
            {
                var rawRemediation = this.PolicyInsightsClient.Remediations.GetAtResource(resourceId: rootScope, remediationName: remediationName);
                WriteObject(new PSRemediation(rawRemediation));
            }
            else
            {
                PaginationHelper.ForEach(
                    getFirstPage: () => this.PolicyInsightsClient.Remediations.ListForResource(resourceId: rootScope, queryOptions: queryOptions),
                    getNextPage: nextLink => this.PolicyInsightsClient.Remediations.ListForResourceNext(nextPageLink: nextLink),
                    action: resources => this.WriteObject(sendToPipeline: resources.Select(r => new PSRemediation(r)), enumerateCollection: true),
                    top: queryOptions.Top.GetValueOrDefault(int.MaxValue),
                    cancellationToken: this.CancellationToken);
            }
        }
    }
}
