

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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkInterface", SupportsShouldProcess = true,
        DefaultParameterSetName = "SetByIpConfigurationResource"), OutputType(typeof(PSNetworkInterface))]
    public class NewAzureNetworkInterfaceCommand : NetworkInterfaceBaseCmdlet
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByIpConfigurationResourceId",
            HelpMessage = "List of IpConfigurations")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByIpConfigurationResource",
            HelpMessage = "List of IpConfigurations")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkInterfaceIPConfiguration> IpConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "SubnetId")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "PublicIpAddressId")]
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
            ParameterSetName = "SetByIpConfigurationResourceId",
            HelpMessage = "NetworkSecurityGroup")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "NetworkSecurityGroupId")]
        public string NetworkSecurityGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByIpConfigurationResourceId",
            HelpMessage = "NetworkSecurityGroup")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "NetworkSecurityGroup")]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

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
            ParameterSetName = "SetByResourceId",
            HelpMessage = "ApplicationGatewayBackendAddressPoolId")]
        public List<string> ApplicationGatewayBackendAddressPoolId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "ApplicationGatewayBackendAddressPools")]
        public List<PSApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The private ip address of the Network Interface " +
                          "if static allocation is specified.")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "The private ip address of the Network Interface " +
                          "if static allocation is specified.")]
        public string PrivateIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceId",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IpConfiguration name." +
                          "default value: ipconfig1")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResource",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IpConfiguration name." +
                          "default value: ipconfig1")]
        [ValidateNotNullOrEmpty]
        public string IpConfigurationName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of Dns Servers")]
        public List<string> DnsServer { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Internal Dns name")]
        public string InternalDnsNameLabel { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "EnableIPForwarding")]
        public SwitchParameter EnableIPForwarding { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }


        public override void Execute()
        {           
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            var present = this.IsNetworkInterfacePresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkInterface = CreateNetworkInterface();
                    if (present)
                    {
                        networkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.Name);
                    }

                    WriteObject(networkInterface);
                },
                () => present);
        }

        private PSNetworkInterface CreateNetworkInterface()
        {
            var networkInterface = new PSNetworkInterface();
            networkInterface.Name = this.Name;
            networkInterface.Location = this.Location;
            networkInterface.EnableIPForwarding = this.EnableIPForwarding.IsPresent;

            // Get the subnetId and publicIpAddressId from the object if specified
            if (ParameterSetName.Contains(Microsoft.Azure.Commands.Network.Properties.Resources.SetByIpConfiguration))
            {
                networkInterface.IpConfigurations = this.IpConfiguration;

                if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByIpConfigurationResourceId))
                {
                    if (this.NetworkSecurityGroup != null)
                    {
                        this.NetworkSecurityGroupId = this.NetworkSecurityGroup.Id;
                    }
                }
            }
            else
            {
                if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
                {
                    this.SubnetId = this.Subnet.Id;

                    if (this.PublicIpAddress != null)
                    {
                        this.PublicIpAddressId = this.PublicIpAddress.Id;
                    }

                    if (this.NetworkSecurityGroup != null)
                    {
                        this.NetworkSecurityGroupId = this.NetworkSecurityGroup.Id;
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

                var nicIpConfiguration = new PSNetworkInterfaceIPConfiguration();
                nicIpConfiguration.Name = string.IsNullOrEmpty(this.IpConfigurationName) ? "ipconfig1" : this.IpConfigurationName;
                nicIpConfiguration.PrivateIpAllocationMethod = MNM.IPAllocationMethod.Dynamic;
                nicIpConfiguration.Primary = true;
                // Uncomment when ipv6 is supported as standalone ipconfig in a nic
                // nicIpConfiguration.PrivateIpAddressVersion = this.PrivateIpAddressVersion;

                if (!string.IsNullOrEmpty(this.PrivateIpAddress))
                {
                    nicIpConfiguration.PrivateIpAddress = this.PrivateIpAddress;
                    nicIpConfiguration.PrivateIpAllocationMethod = MNM.IPAllocationMethod.Static;
                }

                nicIpConfiguration.Subnet = new PSSubnet();
                nicIpConfiguration.Subnet.Id = this.SubnetId;

                if (!string.IsNullOrEmpty(this.PublicIpAddressId))
                {
                    nicIpConfiguration.PublicIpAddress = new PSPublicIpAddress();
                    nicIpConfiguration.PublicIpAddress.Id = this.PublicIpAddressId;
                }

                if (this.LoadBalancerBackendAddressPoolId != null)
                {
                    nicIpConfiguration.LoadBalancerBackendAddressPools = new List<PSBackendAddressPool>();
                    foreach (var bepoolId in this.LoadBalancerBackendAddressPoolId)
                    {
                        nicIpConfiguration.LoadBalancerBackendAddressPools.Add(new PSBackendAddressPool { Id = bepoolId });
                    }
                }

                if (this.LoadBalancerInboundNatRuleId != null)
                {
                    nicIpConfiguration.LoadBalancerInboundNatRules = new List<PSInboundNatRule>();
                    foreach (var natruleId in this.LoadBalancerInboundNatRuleId)
                    {
                        nicIpConfiguration.LoadBalancerInboundNatRules.Add(new PSInboundNatRule { Id = natruleId });
                    }
                }

                if (this.ApplicationGatewayBackendAddressPoolId != null)
                {
                    nicIpConfiguration.ApplicationGatewayBackendAddressPools = new List<PSApplicationGatewayBackendAddressPool>();
                    foreach (var appgwBepoolId in this.ApplicationGatewayBackendAddressPoolId)
                    {
                        nicIpConfiguration.ApplicationGatewayBackendAddressPools.Add(new PSApplicationGatewayBackendAddressPool { Id = appgwBepoolId });
                    }
                }

                networkInterface.IpConfigurations = new List<PSNetworkInterfaceIPConfiguration>();
                networkInterface.IpConfigurations.Add(nicIpConfiguration);
            }

            if (this.DnsServer != null || this.InternalDnsNameLabel != null)
            {
                networkInterface.DnsSettings = new PSNetworkInterfaceDnsSettings();
                if (this.DnsServer != null)
                {
                    networkInterface.DnsSettings.DnsServers = this.DnsServer;
                }
                if (this.InternalDnsNameLabel != null)
                {
                    networkInterface.DnsSettings.InternalDnsNameLabel = this.InternalDnsNameLabel;
                }

            }

            if (!string.IsNullOrEmpty(this.NetworkSecurityGroupId))
            {
                networkInterface.NetworkSecurityGroup = new PSNetworkSecurityGroup();
                networkInterface.NetworkSecurityGroup.Id = this.NetworkSecurityGroupId;
            }

            var networkInterfaceModel = Mapper.Map<MNM.NetworkInterface>(networkInterface);

            networkInterfaceModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            this.NetworkInterfaceClient.CreateOrUpdate(this.ResourceGroupName, this.Name, networkInterfaceModel);

            var getNetworkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.Name);

            return getNetworkInterface;
        }
    }
}

