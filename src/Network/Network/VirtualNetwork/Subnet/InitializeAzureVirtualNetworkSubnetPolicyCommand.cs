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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsData.Initialize, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkSubnetPolicy", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(PSSubnet))]
    public class InitializeAzureVirtualNetworkSubnetPolicyCommand : VirtualNetworkBaseCmdlet
    {
        private const string DefaultParameterSet = "SetByResourceId";
        private const string VirtualNetworkParameterSet = "VirtualNetworkParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkParameterSet,
            HelpMessage = "The name of the subnet")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The name of the subnet")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkParameterSet,
            HelpMessage = "Name of the service deletion. Use Get-AzureRmAvailableServiceDelegation command to list of ServiceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Name of the service deletion. Use Get-AzureRmAvailableServiceDelegation command to list of ServiceName")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Alias("InputObject")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork containing the subnets trying to initialze")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id of the virtual network resource")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId) || !string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId.Trim('"'));
                var resourceGroupName = resourceIdentifier.ResourceGroupName;
                var virtualNetworkName = resourceIdentifier.ResourceName;
                this.VirtualNetwork = GetVirtualNetwork(resourceGroupName, virtualNetworkName);
            }

            // Verify if the subnet exists in the VirtualNetwork
            var subnet = this.VirtualNetwork.Subnets.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));
            if (subnet == null)
            {
                throw new ArgumentException(Properties.Resources.SubnetWithTheSpecifiedNameDoesNotExist);
            }

            if (ShouldProcess(string.Format(Properties.Resources.Subnet0, this.Name), Properties.Resources.Initialize))
            {
                // call prepareNetworkPolicies API
                var prepareRequestParams = new PrepareNetworkPoliciesRequest(this.ServiceName);
                this.NetworkClient.NetworkManagementClient.Subnets.PrepareNetworkPolicies(this.VirtualNetwork.ResourceGroupName,
                                this.VirtualNetwork.Name, this.Name, prepareRequestParams);

                var getVirtualNetwork = GetVirtualNetwork(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name);
                var getSubnet = getVirtualNetwork.Subnets.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

                //Write the output object
                WriteObject(getSubnet);
            }
        }
    }
}
