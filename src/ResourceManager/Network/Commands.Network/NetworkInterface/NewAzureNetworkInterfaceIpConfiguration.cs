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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkInterfaceIpConfiguration"), OutputType(typeof(PSNetworkInterfaceIPConfiguration))]
    public class NewAzureNetworkInterfaceIpConfiguration : NetworkInterfaceBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The Subnet Id")]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "Public IP Address Id")]
        public string PublicIpAddressId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [Parameter(
                    Mandatory = false,
                    ValueFromPipelineByPropertyName = true,
                    ParameterSetName = "SetByResourceId",
                    HelpMessage = "LoadBalancerBackendAddressPoolId")]
        public List<string> LoadBalancerBackendAddressPoolId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "LoadBalancerBackendAddressPools")]
        public List<PSBackendAddressPool> LoadBalancerBackendAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "LoadBalancerInboundNatRuleId")]
        public List<string> LoadBalancerInboundNatRuleId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "LoadBalancerInboundNatRule")]
        public List<PSInboundNatRule> LoadBalancerInboundNatRule { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The private ip address of the Network Interface IP Configuration" +
                          "if static allocation is specified.")]
        public string PrivateIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Select this parameter in case of Primary CA")]
        public SwitchParameter Primary { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            PopulateResourceIdsIfNeeded();

            var nicIpConfiguration = new PSNetworkInterfaceIPConfiguration();

            this.SetNetworkInterfaceIpConfiguration(
                nicIpConfiguration,
                this.PrivateIpAddress,
                this.SubnetId,
                this.PublicIpAddressId,
                this.LoadBalancerBackendAddressPoolId,
                this.LoadBalancerInboundNatRuleId,
                this.Primary.IsPresent);

            WriteObject(nicIpConfiguration);
        }

        private void PopulateResourceIdsIfNeeded()
        {
            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                this.SubnetId = this.Subnet.Id;

                if (this.PublicIpAddress != null)
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
            }
        }
    }
}
