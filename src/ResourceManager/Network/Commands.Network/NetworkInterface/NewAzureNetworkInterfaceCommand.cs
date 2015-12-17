

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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Resources.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Linq;

    [Cmdlet(VerbsCommon.New, "AzureRmNetworkInterface"), OutputType(typeof(PSNetworkInterface))]
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
            ParameterSetName = "SetByResourceId",
            HelpMessage = "NetworkSecurityGroupId")]

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "UseIPConfigurations",
            HelpMessage = "NetworkSecurityGroupId")]
        public string NetworkSecurityGroupId { get; set; }

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
            ParameterSetName = "SetByResource",
            HelpMessage = "The IpConfiguration name." +
                          "default value: ipconfig1")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The IpConfiguration name." +
                          "default value: ipconfig1")]
        [ValidateNotNullOrEmpty]
        public string IpConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "UseIPConfigurations",
            HelpMessage = "IPConfiguration List to be used on the Network interface")]
        public List<PSNetworkInterfaceIPConfiguration> IpConfigurations { get; set; }

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
            HelpMessage = "An array of hashtables which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.IsNetworkInterfacePresent(this.ResourceGroupName, this.Name))
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResource, Name),
                    Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage,
                    Name,
                    () => CreateNetworkInterface());

                WriteObject(this.GetNetworkInterface(this.ResourceGroupName, this.Name));
            }
            else
            {
                var networkInterface = CreateNetworkInterface();

                WriteObject(networkInterface);
            }
        }

        private PSNetworkInterface CreateNetworkInterface()
        {
            // Get the subnetId and publicIpAddressId from the object if specified
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
            }

            var networkInterface = new PSNetworkInterface();
            networkInterface.Name = this.Name;
            networkInterface.Location = this.Location;
            networkInterface.EnableIPForwarding = this.EnableIPForwarding.IsPresent;
            networkInterface.IpConfigurations = new List<PSNetworkInterfaceIPConfiguration>();

            if (!string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.UseIPConfigurations))
            {
                var nicIpConfiguration = new PSNetworkInterfaceIPConfiguration();
                nicIpConfiguration.Name = string.IsNullOrEmpty(this.IpConfigurationName)
                    ? "ipconfig1"
                    : this.IpConfigurationName;

                // By default it is the primary IpConfig

                this.SetNetworkInterfaceIpConfiguration(
                    nicIpConfiguration,
                    this.PrivateIpAddress,
                    this.SubnetId,
                    this.PublicIpAddressId,
                    this.LoadBalancerBackendAddressPoolId,
                    this.LoadBalancerInboundNatRuleId,
                    primary: true);

                networkInterface.IpConfigurations.Add(nicIpConfiguration);
            }
            else
            {
                // We can do more validations if required

                if (this.IpConfigurations == null || !this.IpConfigurations.Any())
                {
                    throw new ArgumentException(
                        string.Format(
                            Microsoft.Azure.Commands.Network.Properties.Resources.IPConfigurationsNullOrEmpty, this.Name));
                }
                if (this.IpConfigurations.Count > 1 &&
                    this.IpConfigurations.Count(ipconfig => ipconfig.Primary == true) != 1)
                {
                    throw new ArgumentException(
                        string.Format(
                            Microsoft.Azure.Commands.Network.Properties.Resources.IPConfigurationsNullOrEmpty, this.Name));
                }

                networkInterface.IpConfigurations.AddRange(this.IpConfigurations);
            }

            if (!string.IsNullOrEmpty(this.NetworkSecurityGroupId))
            {
                networkInterface.NetworkSecurityGroup = new PSNetworkSecurityGroup { Id = this.NetworkSecurityGroupId };
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

            var networkInterfaceModel = Mapper.Map<MNM.NetworkInterface>(networkInterface);
            networkInterfaceModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            this.NetworkInterfaceClient.CreateOrUpdate(this.ResourceGroupName, this.Name, networkInterfaceModel);

            var getNetworkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.Name);

            return getNetworkInterface;
        }
    }
}

 