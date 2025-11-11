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
using System.Collections.Generic;
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

        [Parameter(
            Mandatory = false,
            HelpMessage = DisableLocalAuthMessage)]
        public bool? DisableLocalAuth { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuthOptionsMessage)]
        public PSAuthOptionName? AuthOption { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AadAuthFailureModeMessage)]
        public PSAadAuthFailureMode? AadAuthFailureMode { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = SemanticSearchModeMessage)]
        public PSSemanticSearchMode? SemanticSearchMode { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = ComputeTypeMessage)]
        public PSComputeType? ComputeType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DataExfiltrationProtectionsMessage)]
        public PSDataExfiltrationProtection[] DataExfiltrationProtectionList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = BypassMessage)]
        public PSSearchBypass? Bypass { get; set; }

        public override void ExecuteCmdlet()
        {
            NetworkRuleSet networkRuleSet = null;
            if (IPRuleList != null || Bypass != null)
            {
                networkRuleSet = new NetworkRuleSet();

                if (IPRuleList != null)
                {
                    networkRuleSet.IPRules = IPRuleList.Select(ipRule => (IpRule)ipRule).ToList();
                }

                if (Bypass.HasValue)
                {
                    networkRuleSet.Bypass = Bypass.ToString();
                }
            }

            var identity = IdentityType.HasValue ? new PSIdentity
            {
                Type = IdentityType.Value
            } : null;

            PSAuthOptions authOptions = null;
            if (AuthOption == PSAuthOptionName.ApiKeyOnly)
            {
                authOptions = new PSAuthOptions { ApiKeyOnly = new PSObject() };
            }
            else if (AuthOption == PSAuthOptionName.AadOrApiKey)
            {
                authOptions = new PSAuthOptions { AadOrApiKey = new PsAadOrApiKeyAuthOption() };
                if (AadAuthFailureMode.HasValue)
                {
                    authOptions.AadOrApiKey.AadAuthFailureMode = AadAuthFailureMode;
                }
            }

            string semanticSearchMode = null;
            if (SemanticSearchMode.HasValue)
            {
                semanticSearchMode = SemanticSearchMode.ToString().ToLower();
            }

            string computeType = null;
            if (ComputeType.HasValue)
            {
                computeType = ComputeType.ToString().ToLower();
            }

            var dataExfiltrationProtections = new List<string>();

            if (DataExfiltrationProtectionList != null)
            {
                dataExfiltrationProtections = DataExfiltrationProtectionList.Select(x => x.ToString()).ToList();
            }

            string publicNetworkAccess = null;
            if (PublicNetworkAccess.HasValue)
            {
                publicNetworkAccess = PublicNetworkAccess.ToString().ToLower();
            }

            Azure.Management.Search.Models.SearchService searchService =
                new Azure.Management.Search.Models.SearchService(
                    name: Name,
                    location: Location,
                    sku: new Sku(Sku.ToString().ToLower()),
                    replicaCount: ReplicaCount,
                    partitionCount: PartitionCount,
                    hostingMode: (HostingMode?)HostingMode,
                    publicNetworkAccess: publicNetworkAccess,
                    identity: (Identity)identity,
                    networkRuleSet: networkRuleSet,
                    disableLocalAuth: DisableLocalAuth,
                    authOptions: (DataPlaneAuthOptions)authOptions,
                    semanticSearch: semanticSearchMode,
                    computeType: computeType,
                    dataExfiltrationProtections: dataExfiltrationProtections);

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
