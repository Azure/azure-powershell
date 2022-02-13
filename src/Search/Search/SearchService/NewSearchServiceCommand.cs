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
using Microsoft.Azure.Management.Search.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchService", SupportsShouldProcess = true), OutputType(typeof(PSSearchService))]
    public class NewSearchServiceCommand : SearchServiceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = ResourceGroupHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = SkuHelpMessage)]
        public PSSkuName Sku { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = LocationHelpMessage)]
        [LocationCompleter("Microsoft.Search/operations")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

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
            HelpMessage = HostingModeHelpMessage)]
        public PSHostingMode? HostingMode { get; set; }

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
            var networkRuleSet = IPRuleList?.Any() == true ? new PSNetworkRuleSet
            {
                IpRules = IPRuleList
            } : null;

            var identity = IdentityType.HasValue ? new PSIdentity
            {
                Type = IdentityType.Value
            } : null;

            Azure.Management.Search.Models.SearchService searchService = 
                new Azure.Management.Search.Models.SearchService(
                    name: Name,
                    location: Location,
                    sku: new Sku((SkuName)Sku),
                    replicaCount: ReplicaCount,
                    partitionCount: PartitionCount,
                    hostingMode: (HostingMode?)HostingMode,
                    publicNetworkAccess: (PublicNetworkAccess?)PublicNetworkAccess,
                    identity: (Identity)identity,
                    networkRuleSet: (NetworkRuleSet)networkRuleSet);

            if (ShouldProcess(Name, Resources.CreateSearchService))
            {
                CatchThrowInnerException(() =>
                {
                    var response = SearchClient.Services.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, Name, searchService).Result;
                    WriteSearchService(response.Body);
                });
            }
        }
    }
}
