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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkSubnetConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSSubnet))]
    public class NewAzureVirtualNetworkSubnetConfigCommand : AzureVirtualNetworkSubnetConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the subnet")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.NetworkSecurityGroup != null)
                {
                    this.NetworkSecurityGroupId = this.NetworkSecurityGroup.Id;
                }

                if (this.RouteTable != null)
                {
                    this.RouteTableId = this.RouteTable.Id;
                }

                if (this.InputObject != null)
                {
                    this.ResourceId = this.InputObject.Id;
                }
            }

            var subnet = new PSSubnet();
            subnet.Name = this.Name;
            subnet.AddressPrefix = this.AddressPrefix?.ToList();

            if (IpamPoolPrefixAllocation?.Length > 0)
            {
                subnet.IpamPoolPrefixAllocations = IpamPoolPrefixAllocation.ToList();
            }

            subnet.IpAllocations = new List<PSResourceId>();
            subnet.DefaultOutboundAccess = this.DefaultOutboundAccess;

            if (this.IpAllocation != null)
            {
                foreach (var allocation in this.IpAllocation)
                {
                    subnet.IpAllocations.Add(allocation);
                }
            }

            if (!string.IsNullOrEmpty(this.NetworkSecurityGroupId))
            {
                subnet.NetworkSecurityGroup = new PSNetworkSecurityGroup();
                subnet.NetworkSecurityGroup.Id = this.NetworkSecurityGroupId;
            }

            if (!string.IsNullOrEmpty(this.RouteTableId))
            {
                subnet.RouteTable = new PSRouteTable();
                subnet.RouteTable.Id = this.RouteTableId;
            }

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                subnet.NatGateway = new PSNatGateway();
                subnet.NatGateway.Id = this.ResourceId;
            }

            if (this.ServiceEndpoint != null || this.ServiceEndpointConfig != null)
            {
                AzureVirtualNetworkSubnetConfigHelper helper = new AzureVirtualNetworkSubnetConfigHelper();
                if (helper.MultipleNetworkIdentifierExists(this.ServiceEndpointConfig))
                    throw new ArgumentException("Multiple Service Endpoints with different Network Identifiers are not allowed");

                helper.ConfigureServiceEndpoint(this.ServiceEndpoint, this.NetworkIdentifier, this.ServiceEndpointConfig, subnet);
            }
            
            if (this.ServiceEndpointPolicy != null)
            {
                subnet.ServiceEndpointPolicies = this.ServiceEndpointPolicy?.ToList();
            }

            if (this.Delegation != null)
            {
                subnet.Delegations = this.Delegation?.ToList();
            }

            subnet.PrivateEndpointNetworkPolicies = this.PrivateEndpointNetworkPoliciesFlag ?? "Disabled";
            subnet.PrivateLinkServiceNetworkPolicies = this.PrivateLinkServiceNetworkPoliciesFlag ?? "Enabled";

            WriteObject(subnet);
        }
    }
}