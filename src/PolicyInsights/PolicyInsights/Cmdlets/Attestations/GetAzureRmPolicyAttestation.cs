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

using Microsoft.Azure.Commands.PolicyInsights.Common;
using Microsoft.Azure.Commands.PolicyInsights.Models.Remediation;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.PolicyInsights.Models;
using Microsoft.Azure.Management.PolicyInsights;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Commands.PolicyInsights.Properties;
using Microsoft.Azure.Commands.PolicyInsights.Models;
using System.Linq;
using Microsoft.Azure.Commands.PolicyInsights.Models.Attestations;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets.Attestations
{
    /// <summary>
    /// Gets policy attestations.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "PolicyAttestation", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSAttestation))]
    public class GetAzureRmPolicyAttestation : AttestationCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Scope)]
        [Parameter(ParameterSetName = ParameterSetNames.GenericScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Scope)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Id")]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        [Parameter(ParameterSetName = ParameterSetNames.GenericScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Top)]
        public int Top { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [Parameter(ParameterSetName = ParameterSetNames.GenericScope, Mandatory = false, HelpMessage = ParameterHelpMessages.Filter)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        public override void Execute()
        {
            var queryOptions = new QueryOptions
            {
                Top = this.IsParameterBound(c => c.Top) ? (int?)Top : null,
                Filter = Filter
            };

            if (!string.IsNullOrEmpty(this.Name) && new[] { this.Scope, this.ResourceGroupName }.Count(s => s != null) > 1)
            {
                throw new AzPSArgumentException(Resources.Error_TooManyScopes, nameof(Scope));
            }

            // Determine the scope of the request and whether this is an individual GET or a list
            var rootScope = this.GetRootScope(scope: this.Scope, resourceId: this.ResourceId, resourceGroupName: this.ResourceGroupName);
            var attestationName = this.GetAttestationName(name: this.Name, resourceId: this.ResourceId);

            if (!string.IsNullOrEmpty(attestationName))
            {
                var rawAttestation = this.PolicyInsightsClient.Attestations.GetAtResource(resourceId: rootScope, attestationName: attestationName);

                WriteObject(new PSAttestation(attestation: rawAttestation));
            }
            else
            {
                PaginationHelper.ForEach(
                    getFirstPage: () => this.PolicyInsightsClient.Attestations.ListForResource(resourceId: rootScope, queryOptions: queryOptions),
                    getNextPage: nextLink => this.PolicyInsightsClient.Attestations.ListForResourceNext(nextPageLink: nextLink),
                    action: resources => this.WriteObject(sendToPipeline: resources.Select(r => new PSAttestation(r)), enumerateCollection: true),
                    numberOfResults: int.MaxValue,
                    cancellationToken: this.CancellationToken);
            }
        }
    }
}
