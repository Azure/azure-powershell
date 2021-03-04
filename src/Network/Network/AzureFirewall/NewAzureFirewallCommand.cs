﻿// ----------------------------------------------------------------------------------
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Firewall", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(PSAzureFirewall))]
    public class NewAzureFirewallCommand : AzureFirewallBaseCmdlet

    {
        private const string DefaultParameterSet = "Default";
        private PSVirtualNetwork virtualNetwork;
        private PSPublicIpAddress[] publicIpAddresses;

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
            HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [CmdletParameterBreakingChange(
            "VirtualNetworkName",
            deprecateByVersion: "2.0.0",
            ChangeDescription = "This parameter will be removed in an upcoming breaking change release. After this point the Virtual Network will be provided as an object instead of a string.",
            OldWay = "New-AzFirewall -VirtualNetworkName \"vnet-name\"",
            NewWay = "New-AzFirewall -VirtualNetwork $vnet",
            OldParamaterType = typeof(string),
            NewParameterTypeName = nameof(PSVirtualNetwork),
            ReplaceMentCmdletParameterName = "VirtualNetwork")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "OldIpConfigurationParameterValues",
            HelpMessage = "Virtual Network Name")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [CmdletParameterBreakingChange(
            "PublicIpName",
            deprecateByVersion: "2.0.0",
            ChangeDescription = "This parameter will be removed in an upcoming breaking change release. After this point the Public IP Address will be provided as a list of one or more objects instead of a string.",
            OldWay = "New-AzFirewall -PublicIpName \"public-ip-name\"",
            NewWay = "New-AzFirewall -PublicIpAddress @($publicip1, $publicip2)",
            OldParamaterType = typeof(string),
            NewParameterTypeName = "List<PSPublicIpAddress>",
            ReplaceMentCmdletParameterName = "PublicIpAddress")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "OldIpConfigurationParameterValues",
            HelpMessage = "Public IP address name. The Public IP must use Standard SKU and must belong to the same resource group as the Firewall.")]
        [ValidateNotNullOrEmpty]
        public string PublicIpName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "IpConfigurationParameterValues",
            HelpMessage = "Virtual Network")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "IpConfigurationParameterValues",
            HelpMessage = "One or more Public IP Addresses. The Public IP addresses must use Standard SKU and must belong to the same resource group as the Firewall.")]
        [ValidateNotNullOrEmpty]
        public PSPublicIpAddress[] PublicIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "IpConfigurationParameterValues",
            HelpMessage = "One or more Public IP Addresses to use for management traffic. The Public IP addresses must use Standard SKU and must belong to the same resource group as the Firewall.")]
        [ValidateNotNullOrEmpty]
        public PSPublicIpAddress ManagementPublicIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of AzureFirewallApplicationRuleCollections")]
        public PSAzureFirewallApplicationRuleCollection[] ApplicationRuleCollection { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of AzureFirewallNatRuleCollections")]
        public PSAzureFirewallNatRuleCollection[] NatRuleCollection { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of AzureFirewallNetworkRuleCollections")]
        public PSAzureFirewallNetworkRuleCollection[] NetworkRuleCollection { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The operation mode for Threat Intelligence.")]
        [ValidateSet(
            MNM.AzureFirewallThreatIntelMode.Alert,
            MNM.AzureFirewallThreatIntelMode.Deny,
            MNM.AzureFirewallThreatIntelMode.Off,
            IgnoreCase = false)]
        public string ThreatIntelMode { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The whitelist for Threat Intelligence")]
        public PSAzureFirewallThreatIntelWhitelist ThreatIntelWhitelist { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The private IP ranges to which traffic won't be SNAT'ed"
        )]
        public string[] PrivateRange { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable DNS Proxy. By default it is disabled."
        )]
        public SwitchParameter EnableDnsProxy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of DNS Servers"
        )]
        public string[] DnsServer { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of availability zones denoting where the firewall needs to come from.")]
        public string[] Zone { get; set; }

        [Alias("Sku")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The sku name for firewall")]
        [ValidateSet(
                MNM.AzureFirewallSkuName.AZFWHub,
                MNM.AzureFirewallSkuName.AZFWVNet,
                IgnoreCase = false)]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The sku tier for firewall")]
        [ValidateSet(
                MNM.AzureFirewallSkuTier.Standard,
                MNM.AzureFirewallSkuTier.Premium,
                IgnoreCase = false)]
        public string SkuTier { get; set; }

        [Parameter(
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                HelpMessage = "The virtual hub that a firewall is attached to")]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ip addresses for the firewall attached to a virtual hub")]
        public PSAzureFirewallHubIpAddresses HubIPAddress { get; set; }

        [Parameter(
                Mandatory = false,
                ValueFromPipelineByPropertyName = true,
                HelpMessage = "The firewall policy attached to the firewall")]
        public string FirewallPolicyId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Allow Active FTP. By default it is false."
        )]
        public SwitchParameter AllowActiveFTP { get; set; }

        public override void Execute()
        {
            // Old params provided - Get the virtual network, get the public IP address
            if (!string.IsNullOrEmpty(VirtualNetworkName))
            {
                var vnet = this.VirtualNetworkClient.Get(this.ResourceGroupName, VirtualNetworkName);
                this.virtualNetwork = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetwork>(vnet);

                var publicIp = this.PublicIPAddressesClient.Get(this.ResourceGroupName, PublicIpName);
                this.publicIpAddresses = new PSPublicIpAddress[]
                {
                    NetworkResourceManagerProfile.Mapper.Map<PSPublicIpAddress>(publicIp)
                };
            }
            // New params
            else if (VirtualNetwork != null)
            {
                this.virtualNetwork = VirtualNetwork;
                this.publicIpAddresses = PublicIpAddress;
            }

            base.Execute();

            var present = this.IsAzureFirewallPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () => WriteObject(this.CreateAzureFirewall()),
                () => present);
        }

        private PSAzureFirewall CreateAzureFirewall()
        {
            var firewall = new PSAzureFirewall();
            var sku = new PSAzureFirewallSku();
            sku.Name = !string.IsNullOrEmpty(this.SkuName) ? this.SkuName : MNM.AzureFirewallSkuName.AZFWVNet;
            sku.Tier = !string.IsNullOrEmpty(this.SkuTier) ? this.SkuTier : MNM.AzureFirewallSkuTier.Standard;

            if (this.SkuName == MNM.AzureFirewallSkuName.AZFWHub)
            {

                if (VirtualHubId != null && this.Location != null)
                {
                    var resourceInfo = new ResourceIdentifier(VirtualHubId);
                    var hub = this.VirtualHubClient.Get(resourceInfo.ResourceGroupName, resourceInfo.ResourceName);
                    if (hub.Location != this.Location)
                    {
                        throw new ArgumentException("VirtualHub and Firewall cannot be in different locations", nameof(VirtualHubId));
                    }

                }

                if (this.HubIPAddress != null && this.HubIPAddress.PublicIPs != null && this.HubIPAddress.PublicIPs.Addresses != null)
                {
                    throw new ArgumentException("The list of public Ip addresses cannot be provided during the firewall creation");
                }

                firewall = new PSAzureFirewall()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location,
                    Sku = sku,
                    VirtualHub = VirtualHubId != null ? new MNM.SubResource(VirtualHubId) : null,
                    FirewallPolicy = FirewallPolicyId != null ? new MNM.SubResource(FirewallPolicyId) : null,
                    HubIPAddresses = this.HubIPAddress
                };
            }
            else
            {
                firewall = new PSAzureFirewall()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location,
                    FirewallPolicy = FirewallPolicyId != null ? new MNM.SubResource(FirewallPolicyId) : null,
                    ApplicationRuleCollections = this.ApplicationRuleCollection?.ToList(),
                    NatRuleCollections = this.NatRuleCollection?.ToList(),
                    NetworkRuleCollections = this.NetworkRuleCollection?.ToList(),
                    ThreatIntelMode = this.ThreatIntelMode ?? MNM.AzureFirewallThreatIntelMode.Alert,
                    ThreatIntelWhitelist = this.ThreatIntelWhitelist,
                    PrivateRange = this.PrivateRange,
                    DNSEnableProxy = (this.EnableDnsProxy.IsPresent ? "true" : null),
                    DNSServer = this.DnsServer,
                    AllowActiveFTP = (this.AllowActiveFTP.IsPresent ? "true" : null),
                    Sku = sku
                };

                if (this.Zone != null)
                {
                    firewall.Zones = this.Zone?.ToList();
                }

                if (this.virtualNetwork != null)
                {
                    firewall.Allocate(this.virtualNetwork, this.publicIpAddresses, this.ManagementPublicIpAddress);
                }

                firewall.ValidateDNSProxyRequirements();
            }

            // Map to the sdk object
            var azureFirewallModel = NetworkResourceManagerProfile.Mapper.Map<MNM.AzureFirewall>(firewall);
            azureFirewallModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create AzureFirewall call
            this.AzureFirewallClient.CreateOrUpdate(this.ResourceGroupName, this.Name, azureFirewallModel);
            return this.GetAzureFirewall(this.ResourceGroupName, this.Name);
        }
    }
}
