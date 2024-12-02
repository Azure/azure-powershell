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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerVerifierWorkspaceReachabilityAnalysisIntent", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSReachabilityAnalysisIntent))]
    public class GetAzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntentCommand : ReachabilityAnalysisIntentBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/reachabilityAnalysisIntents", "ResourceGroupName", "NetworkManagerName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The verifier workspace name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string VerifierWorkspaceName { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.Name != null)
            {
                var analysisIntent = this.GetAnalysisIntent(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName, this.Name);
                analysisIntent.ResourceGroupName = this.ResourceGroupName;
                analysisIntent.NetworkManagerName = this.NetworkManagerName;
                WriteObject(analysisIntent);
            }
            else
            {
                IPage<ReachabilityAnalysisIntent> analysisIntentPage;
                analysisIntentPage = this.ReachabilityAnalysisIntentClient.List(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName);

                // Get all resources by polling on next page link
                var analysisIntentList = ListNextLink<ReachabilityAnalysisIntent>.GetAllResourcesByPollingNextLink(analysisIntentPage, this.ReachabilityAnalysisIntentClient.ListNext);

                var psAnalysisIntentList = new List<PSReachabilityAnalysisIntent>();

                foreach (var analysisIntent in analysisIntentList)
                {
                    var psAnalysisIntent = this.ToPsReachabilityAnalysisIntent(analysisIntent);
                    psAnalysisIntent.ResourceGroupName = this.ResourceGroupName;
                    psAnalysisIntent.NetworkManagerName = this.NetworkManagerName;
                    psAnalysisIntentList.Add(psAnalysisIntent);
                }

                WriteObject(psAnalysisIntentList);
            }
        }
    }
}