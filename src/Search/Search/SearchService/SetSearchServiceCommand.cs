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

using Microsoft.Azure.Commands.Management.Search.Models;
using Microsoft.Azure.Commands.Management.Search.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Search.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchService", SupportsShouldProcess = true, DefaultParameterSetName = ResourceNameParameterSetName), OutputType(typeof(PSSearchService))]
    public class SetSearchServiceCommand : SearchServiceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectParameterSetName,
            HelpMessage = InputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSSearchService InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSetName,
            HelpMessage = ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceGroupHelpMessage)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = PartitionCountHelpMessage)]
        public int? PartitionCount { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = ReplicaCountHelpMessage)]
        public int? ReplicaCount { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = PublicNetworkAccessMessage)]
        public PSPublicNetworkAccess? PublicNetworkAccess { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = IdentityMessage)]
        public PSIdentityType? IdentityType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = IPRulesMessage)]
        public PSIpRule[] IPRuleList { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(InputObjectParameterSetName, StringComparison.InvariantCulture))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.Name;
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSetName, StringComparison.InvariantCulture))
            {
                var id = new ResourceIdentifier(ResourceId);
                ResourceGroupName = id.ResourceGroupName;
                Name = id.ResourceName;
            }

            if (ShouldProcess(Name, Resources.UpdateSearchService))
            {
                CatchThrowInnerException(() =>
                {
                    // GET
                    var service = SearchClient.Services.GetWithHttpMessagesAsync(ResourceGroupName, Name).Result.Body;

                    var networkRuleSet = IPRuleList?.Any() == true ? new PSNetworkRuleSet
                    {
                        IpRules = IPRuleList
                    } : null;

                    var identity = IdentityType.HasValue ? new PSIdentity
                    {
                        Type = IdentityType.Value
                    } : null;

                    // UPDATE
                    var update = new SearchServiceUpdate
                    {
                        // Keep existing properties
                        HostingMode = service.HostingMode,
                        Location = service.Location,
                        //NetworkRuleSet = service.NetworkRuleSet,
                        Sku = service.Sku,
                        Tags = service.Tags,

                        // Update the properties passed in (treating nulls as no change to be consistent)
                        NetworkRuleSet = (NetworkRuleSet)networkRuleSet ?? service.NetworkRuleSet,
                        PublicNetworkAccess = (PublicNetworkAccess?)PublicNetworkAccess ?? service.PublicNetworkAccess,
                        Identity = (Identity)identity ?? service.Identity,

                        PartitionCount = PartitionCount,
                        ReplicaCount = ReplicaCount,
                    };

                    service = SearchClient.Services.UpdateWithHttpMessagesAsync(ResourceGroupName, Name, update).Result.Body;

                    // OUTPUT
                    WriteSearchService(service);
                });
            }
        }
    }
}
