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

using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerAssociatedResourcesList"), OutputType(typeof(List<PSPoolAssociation>))]
    public class GetAzNetworkManagerAssociatedResourcesListCommand : IpamPoolBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The ipamPool name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/ipamPools", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string IpamPoolName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The networkManager name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
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

        public override void Execute()
        {
            base.Execute();

            IPage<Management.Network.Models.PoolAssociation> poolAssociationPage;
            poolAssociationPage = this.NetworkClient.NetworkManagementClient.IpamPools.ListAssociatedResources(this.ResourceGroupName, this.NetworkManagerName, IpamPoolName);

            // Get all resources by polling on next page link
            var poolAssociationList = ListNextLink<PoolAssociation>.GetAllResourcesByPollingNextLink(poolAssociationPage, this.NetworkClient.NetworkManagementClient.IpamPools.ListAssociatedResourcesNext);

            var psPoolAssociationList = new List<PSPoolAssociation>();

            foreach (var poolAssociation in poolAssociationList)
            {
                var psPoolAssociation = this.ToPsPoolAssociation(poolAssociation);
                psPoolAssociationList.Add(psPoolAssociation);
            }

            WriteObject(psPoolAssociationList);
        }
    }
}