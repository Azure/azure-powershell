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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkInterfaceIpConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSNetworkInterfaceIPConfiguration))]
    public class NewAzureNetworkInterfaceIpConfigCommand : AzureNetworkInterfaceIpConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the IpConfiguration")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Get the subnetId and publicIpAddressId from the object if specified
            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.Subnet != null)
                {
                    this.SubnetId = this.Subnet.Id;
                }

                if (PublicIpAddress != null)
                {
                    this.PublicIpAddressId = this.PublicIpAddress.Id;
                }

                if (this.LoadBalancerBackendAddressPool != null)
                {
                    this.LoadBalancerBackendAddressPoolId = new List<string>();
                    foreach (var bepool in this.LoadBalancerBackendAddressPool)
                    {
                        this.LoadBalancerBackendAddressPoolId.Add(bepool.Id);
                    }
                }

                if (this.LoadBalancerInboundNatRule != null)
                {
                    this.LoadBalancerInboundNatRuleId = new List<string>();
                    foreach (var natRule in this.LoadBalancerInboundNatRule)
                    {
                        this.LoadBalancerInboundNatRuleId.Add(natRule.Id);
                    }
                }

                if (this.ApplicationGatewayBackendAddressPool != null)
                {
                    this.ApplicationGatewayBackendAddressPoolId = new List<string>();
                    foreach (var appgwBepool in this.ApplicationGatewayBackendAddressPool)
                    {
                        this.ApplicationGatewayBackendAddressPoolId.Add(appgwBepool.Id);
                    }
                }
            }

            var ipconfig = new PSNetworkInterfaceIPConfiguration();
            ipconfig.Name = this.Name;

            if (!string.IsNullOrEmpty(this.SubnetId))
            {
                ipconfig.Subnet = new PSSubnet();
                ipconfig.Subnet.Id = this.SubnetId;

                if (!string.IsNullOrEmpty(this.PrivateIpAddress))
                {
                    ipconfig.PrivateIpAddress = this.PrivateIpAddress;
                    ipconfig.PrivateIpAllocationMethod = Management.Network.Models.IPAllocationMethod.Static;
                }
                else
                {
                    ipconfig.PrivateIpAllocationMethod = Management.Network.Models.IPAllocationMethod.Dynamic;
                }
            }

            if (!string.IsNullOrEmpty(this.PublicIpAddressId))
            {
                ipconfig.PublicIpAddress = new PSPublicIpAddress();
                ipconfig.PublicIpAddress.Id = this.PublicIpAddressId;
            }

            if (this.LoadBalancerBackendAddressPoolId != null)
            {
                ipconfig.LoadBalancerBackendAddressPools = new List<PSBackendAddressPool>();
                foreach (var bepoolId in this.LoadBalancerBackendAddressPoolId)
                {
                    ipconfig.LoadBalancerBackendAddressPools.Add(new PSBackendAddressPool { Id = bepoolId });
                }
            }

            if (this.LoadBalancerInboundNatRuleId != null)
            {
                ipconfig.LoadBalancerInboundNatRules = new List<PSInboundNatRule>();
                foreach (var natruleId in this.LoadBalancerInboundNatRuleId)
                {
                    ipconfig.LoadBalancerInboundNatRules.Add(new PSInboundNatRule { Id = natruleId });
                }
            }

            if (this.ApplicationGatewayBackendAddressPoolId != null)
            {
                ipconfig.ApplicationGatewayBackendAddressPools = new List<PSApplicationGatewayBackendAddressPool>();
                foreach (var appgwBepoolId in this.ApplicationGatewayBackendAddressPoolId)
                {
                    ipconfig.ApplicationGatewayBackendAddressPools.Add(new PSApplicationGatewayBackendAddressPool { Id = appgwBepoolId });
                }
            }

            ipconfig.PrivateIpAddressVersion = this.PrivateIpAddressVersion;
            ipconfig.Primary = this.Primary.IsPresent;
            WriteObject(ipconfig);

        }
    }
}
