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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManager", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSNetworkManager))]
    public class GetAzNetworkManagerCommand : NetworkManagerBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var networkManager = this.GetNetworkManager(this.ResourceGroupName, this.Name);
                networkManager.ResourceGroupName = this.ResourceGroupName;
                WriteObject(networkManager);
            }
            else
            {
                IPage<Management.Network.Models.NetworkManager> networkManagerPage;
                if (ShouldListByResourceGroup(ResourceGroupName, Name))
                {
                    networkManagerPage = this.NetworkManagerClient.List(this.ResourceGroupName);
                }
                else
                {
                    networkManagerPage = this.NetworkManagerClient.ListBySubscription();
                }


                // Get all resources by polling on next page link
                var networkManagerList = ListNextLink<Management.Network.Models.NetworkManager>.GetAllResourcesByPollingNextLink(networkManagerPage, this.NetworkManagerClient.ListNext);

                var psNetworkManagerList = new List<PSNetworkManager>();

                foreach (var networkManager in networkManagerList)
                {
                    var psNetworkManager = this.ToPsNetworkManager(networkManager);
                    psNetworkManager.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkManager.Id);
                    psNetworkManagerList.Add(psNetworkManager);
                }

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psNetworkManagerList), true);
            }
        }
    }
}