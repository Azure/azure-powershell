

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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [GenericBreakingChange("Default behaviour of Zone will be changed", OldWay = "Sku = Standard means the Standard Public IP is zone-redundant.",
        NewWay = "Sku = Standard and Zone = {} means the Standard Public IP has no zones. If you want to create a zone-redundant Public IP address, please specify all the zones in the region. For example, Zone = ['1', '2', '3'].")]
    [GenericBreakingChange("It is recommended to use parameter '-Sku Standard' to create new IP address. Please note that it will become the default behavior for IP address creation in the future.")]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PublicIpAddress", SupportsShouldProcess = true),OutputType(typeof(PSPublicIpAddress))]
    public class NewAzurePublicIpAddressCommand : PublicIpAddressBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address location.")]
        [LocationCompleter("Microsoft.Network/publicIPAddresses")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the extended location.")]
        public string EdgeZone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP Sku name.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.PublicIPAddressSkuName.Basic,
            MNM.PublicIPAddressSkuName.Standard,
            IgnoreCase = true)]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP Sku tier.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.PublicIPAddressSkuTier.Regional,
            MNM.PublicIPAddressSkuTier.Global,
            IgnoreCase = true)]
        public string Tier { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address allocation method.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.IPAllocationMethod.Dynamic,
            MNM.IPAllocationMethod.Static,
            IgnoreCase = true)]
        public string AllocationMethod { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address version.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.IPVersion.IPv4,
            MNM.IPVersion.IPv6,
            IgnoreCase = true)]
        public string IpAddressVersion { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Domain Name label.")]
        public string DomainNameLabel { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IpTag List.")]
        public PSPublicIpTag[] IpTag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The PublicIpPrefix to use for Public IP address")]
        public PSPublicIpPrefix PublicIpPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The DdosProtectionMode to use for Public IP address")]
        [ValidateSet(
            MNM.DdosSettingsProtectionMode.VirtualNetworkInherited,
            MNM.DdosSettingsProtectionMode.Enabled,
            MNM.DdosSettingsProtectionMode.Disabled,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string DdosProtectionMode { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Reverse FQDN.")]
        public string ReverseFqdn { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IdleTimeoutInMinutes")]
        public int IdleTimeoutInMinutes { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of availability zones denoting the IP allocated for the resource needs to come from.",
            ValueFromPipelineByPropertyName = true)]
        public string[] Zone { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Target ip Address for BYOIP PublicIpAddress.",
            ValueFromPipelineByPropertyName = true)]
        public string IpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsPublicIpAddressPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var publicIp = CreatePublicIpAddress();
                    WriteObject(publicIp);
                },
                () => present);
        }

        private PSPublicIpAddress CreatePublicIpAddress()
        {
            var publicIp = new PSPublicIpAddress();
            publicIp.Name = this.Name;
            publicIp.Location = this.Location;
            publicIp.PublicIpAllocationMethod = this.AllocationMethod;
            publicIp.PublicIpAddressVersion = this.IpAddressVersion;
            publicIp.Zones = this.Zone?.ToList();
            publicIp.PublicIpPrefix = this.PublicIpPrefix;
            publicIp.IpAddress = this.IpAddress;

            if (!string.IsNullOrEmpty(this.EdgeZone))
            {
                publicIp.ExtendedLocation = new PSExtendedLocation(this.EdgeZone);
            }

            if (!string.IsNullOrEmpty(this.Sku))
            {
                publicIp.Sku = new PSPublicIpAddressSku();
                publicIp.Sku.Name = this.Sku;
            }

            if (!string.IsNullOrEmpty(this.DdosProtectionMode))
            {
                publicIp.DdosSettings = new PSDdosSettings();
                publicIp.DdosSettings.ProtectionMode = this.DdosProtectionMode;
            }

                if (!string.IsNullOrEmpty(this.Tier))
            {
                if(publicIp.Sku == null)
                {
                    publicIp.Sku = new PSPublicIpAddressSku();
                }

                publicIp.Sku.Tier = this.Tier;
            }

            if (this.IdleTimeoutInMinutes > 0)
            {
                publicIp.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }

            if (!string.IsNullOrEmpty(this.DomainNameLabel))
            {
                publicIp.DnsSettings = new PSPublicIpAddressDnsSettings();
                publicIp.DnsSettings.DomainNameLabel = this.DomainNameLabel;
                publicIp.DnsSettings.ReverseFqdn = this.ReverseFqdn;
            }

            if (this.IpTag != null && this.IpTag.Length > 0)
            {
                publicIp.IpTags = this.IpTag?.ToList();
            }

            var publicIpModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PublicIPAddress>(publicIp);

            publicIpModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            this.PublicIpAddressClient.CreateOrUpdate(this.ResourceGroupName, this.Name, publicIpModel);

            var getPublicIp = this.GetPublicIpAddress(this.ResourceGroupName, this.Name);

            return getPublicIp;
        }
    }
}
