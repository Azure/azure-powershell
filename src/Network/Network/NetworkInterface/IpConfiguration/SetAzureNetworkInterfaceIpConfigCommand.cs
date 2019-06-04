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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkInterfaceIpConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSNetworkInterface))]
    public class SetAzureNetworkInterfaceIpConfigCommand : AzureNetworkInterfaceIpConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the IpConfiguration")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Interface")]
        public PSNetworkInterface NetworkInterface { get; set; }

        public override void Execute()
        {
            base.Execute();

            var ipconfig = this.NetworkInterface.IpConfigurations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (ipconfig == null)
            {
                throw new ArgumentException("IpConfiguration with the specified name does not exist");
            }

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
                    var poolIds = new List<string>();
                    foreach (var bepool in this.LoadBalancerBackendAddressPool)
                    {
                        poolIds.Add(bepool.Id);
                    }
                    this.LoadBalancerBackendAddressPoolId = poolIds.ToArray();
                }

                if (this.LoadBalancerInboundNatRule != null)
                {

                    var lbNatIds = new List<string>();
                    foreach (var natRule in this.LoadBalancerInboundNatRule)
                    {
                        lbNatIds.Add(natRule.Id);
                    }
                    LoadBalancerInboundNatRuleId = lbNatIds.ToArray();
                }

                if (this.ApplicationGatewayBackendAddressPool != null)
                {

                    var appGwPoolIds = new List<string>();
                    foreach (var appgwBepool in this.ApplicationGatewayBackendAddressPool)
                    {
                        appGwPoolIds.Add(appgwBepool.Id);
                    }
                    ApplicationGatewayBackendAddressPoolId = appGwPoolIds.ToArray();
                }

                if (this.ApplicationSecurityGroup != null)
                {
                    var groupIds = new List<string>();
                    foreach (var asg in this.ApplicationSecurityGroup)
                    {
                        groupIds.Add(asg.Id);
                    }
                    ApplicationSecurityGroupId = groupIds.ToArray();
                }
            }

            ipconfig.PublicIpAddress = null;
            ipconfig.LoadBalancerBackendAddressPools = null;
            ipconfig.LoadBalancerInboundNatRules = null;
            ipconfig.ApplicationGatewayBackendAddressPools = null;

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

            if (this.ApplicationSecurityGroupId != null)
            {
                ipconfig.ApplicationSecurityGroups = new List<PSApplicationSecurityGroup>();
                foreach (var asgId in this.ApplicationSecurityGroupId)
                {
                    ipconfig.ApplicationSecurityGroups.Add(new PSApplicationSecurityGroup { Id = asgId });
                }
            }

            if(this.PrivateIpAddressVersion != null)
            {
                ipconfig.PrivateIpAddressVersion = this.PrivateIpAddressVersion;
            }

            if (this.Primary.IsPresent)
            {
                foreach (var item in NetworkInterface.IpConfigurations)
                {
                    item.Primary = false;
                }

                ipconfig.Primary = this.Primary.IsPresent;
            }

            WriteObject(this.NetworkInterface);
        }
    }
}
