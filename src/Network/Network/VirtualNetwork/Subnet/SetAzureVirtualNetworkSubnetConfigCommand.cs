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
<<<<<<< HEAD
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkSubnetConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSVirtualNetwork))]
    public class SetAzureVirtualNetworkSubnetConfigCommand : AzureVirtualNetworkSubnetConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the subnet")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Verify if the subnet exists in the VirtualNetwork
            var subnet = this.VirtualNetwork.Subnets.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

            if (subnet == null)
            {
                throw new ArgumentException("Subnet with the specified name does not exist");
            }

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.NetworkSecurityGroup != null)
                {
                    this.NetworkSecurityGroupId = this.NetworkSecurityGroup.Id;
                }
<<<<<<< HEAD
=======
                else if (this.MyInvocation.BoundParameters.ContainsKey("NetworkSecurityGroup"))
                {
                    this.NetworkSecurityGroupId = null;
                }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                if (this.RouteTable != null)
                {
                    this.RouteTableId = this.RouteTable.Id;
                }
<<<<<<< HEAD
=======
                else if (this.MyInvocation.BoundParameters.ContainsKey("RouteTable"))
                {
                    this.RouteTableId = null;
                }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }

            subnet.AddressPrefix = this.AddressPrefix?.ToList();

<<<<<<< HEAD
=======
            if (this.IpAllocation != null)
            {
                foreach (var allocation in this.IpAllocation)
                {
                    subnet.IpAllocations.Add(allocation);
                }
            }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            if (!string.IsNullOrEmpty(this.NetworkSecurityGroupId))
            {
                subnet.NetworkSecurityGroup = new PSNetworkSecurityGroup();
                subnet.NetworkSecurityGroup.Id = this.NetworkSecurityGroupId;
            }
<<<<<<< HEAD
=======
            else if (this.MyInvocation.BoundParameters.ContainsKey("NetworkSecurityGroup") || this.MyInvocation.BoundParameters.ContainsKey("NetworkSecurityGroupId"))
            {
                subnet.NetworkSecurityGroup = null;
            }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            if (!string.IsNullOrEmpty(this.RouteTableId))
            {
                subnet.RouteTable = new PSRouteTable();
                subnet.RouteTable.Id = this.RouteTableId;
            }
<<<<<<< HEAD
=======
            else if (this.MyInvocation.BoundParameters.ContainsKey("RouteTable") || this.MyInvocation.BoundParameters.ContainsKey("RouteTableId"))
            {
                subnet.RouteTable = null;
            }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            if (this.ServiceEndpoint != null)
            {
                subnet.ServiceEndpoints = new List<PSServiceEndpoint>();
                foreach (var item in this.ServiceEndpoint)
                {
                    var service = new PSServiceEndpoint();
                    service.Service = item;
                    subnet.ServiceEndpoints.Add(service);
                }
            }
            else
            {
                subnet.ServiceEndpoints = null;
            }

            if (this.ServiceEndpointPolicy != null)
            {
                subnet.ServiceEndpointPolicies = this.ServiceEndpointPolicy?.ToList();
            }
            else
            {
                subnet.ServiceEndpointPolicies = null;
            }

            if (this.Delegation != null)
            {
                subnet.Delegations = this.Delegation?.ToList();
            }
            else
            {
                subnet.Delegations = null;
            }

            if(!string.IsNullOrEmpty(this.PrivateEndpointNetworkPoliciesFlag))
            {
                subnet.PrivateEndpointNetworkPolicies = this.PrivateEndpointNetworkPoliciesFlag;
            }

            if (!string.IsNullOrEmpty(this.PrivateLinkServiceNetworkPoliciesFlag))
            {
                subnet.PrivateLinkServiceNetworkPolicies = this.PrivateLinkServiceNetworkPoliciesFlag;
            }


            WriteObject(this.VirtualNetwork);
        }
    }
}
