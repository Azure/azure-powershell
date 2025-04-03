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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerIpamPool", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSIpamPool))]
    public class GetAzNetworkManagerIpamPoolCommand : IpamPoolBaseCmdlet
    {
        private const string ListParameterSet = "ByList";
        private const string GetByNameParameterSet = "ByName";
        private const string GetByResourceIdParameterSet = "ByResourceId";

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/ipamPools", "ResourceGroupName", "NetworkManagerName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.",
           ParameterSetName = ListParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = ListParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = "The Ipam Pool resource id.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("IpamPoolId")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();
            switch (this.ParameterSetName)
            {
                case GetByNameParameterSet:
                    var ipamPoolByName = this.GetIpamPool(this.ResourceGroupName, this.NetworkManagerName, this.Name);
                    ipamPoolByName.ResourceGroupName = this.ResourceGroupName;
                    ipamPoolByName.NetworkManagerName = this.NetworkManagerName;
                    WriteObject(ipamPoolByName);
                    break;

                case ListParameterSet:
                    IPage<Management.Network.Models.IpamPool> ipamPoolPage;
                    ipamPoolPage = this.IpamPoolClient.List(this.ResourceGroupName, this.NetworkManagerName);

                    // Get all resources by polling on next page link
                    var ipamPoolList = ListNextLink<IpamPool>.GetAllResourcesByPollingNextLink(ipamPoolPage, this.IpamPoolClient.ListNext);

                    var psIpamPoolList = new List<PSIpamPool>();

                    foreach (var ipamPool in ipamPoolList)
                    {
                        var psIpamPool = this.ToPsIpamPool(ipamPool);
                        psIpamPool.ResourceGroupName = this.ResourceGroupName;
                        psIpamPool.NetworkManagerName = this.NetworkManagerName;
                        psIpamPoolList.Add(psIpamPool);
                    }

                    WriteObject(psIpamPoolList);
                    break;

                case GetByResourceIdParameterSet:
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);

                    // Validate the format of the ResourceId
                    var segments = parsedResourceId.ParentResource.Split('/');
                    if (segments.Length < 2)
                    {
                        throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                    }

                    this.Name = parsedResourceId.ResourceName;
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.NetworkManagerName = segments[1];

                    var ipamPoolByResourceId = this.GetIpamPool(this.ResourceGroupName, this.NetworkManagerName, this.Name);
                    WriteObject(ipamPoolByResourceId);
                    break;

                default:
                    break;
            }
        }
    }
}