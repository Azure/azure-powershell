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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Set,
        "AzureRmVpnSite",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnSiteName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnSite))]
    public class SetAzureRmVpnSiteCommand : VpnSiteBaseCmdlet
    {
        [Alias("ResourceName", "VpnSiteName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VpnSite")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSVpnSite InputObject { get; set; }

        [Alias("VpnSiteId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the vpn site.")]
        [ResourceIdCompleter("Microsoft.Network/vpnSites")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource group name of the VirtualWan this VpnSite needs to be connected to.")]
        public string VirtualWanResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the VirtualWan this VpnSite needs to be connected to.")]
        public string VirtualWanName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The VirtualWan this VpnSite needs to be connected to.")]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ResourceId VirtualWan this VpnSite needs to be connected to.")]
        [ResourceIdCompleter("Microsoft.Network/virtualWans")]
        public string VirtualWanId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "IP address of local network gateway.")]
        public string IpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The address prefixes of the virtual network. Use this or AddressSpaceObject but not both.")]
        [ValidateNotNullOrEmpty]
        public List<string> AddressSpace { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The device model of the remote vpn device.")]
        public string DeviceModel { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The device vendor of the remote vpn device.")]
        public string DeviceVendor { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The device model of the remote vpn device.")]
        public uint LinkSpeedInMbps { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The BGP ASN for this VpnSite.")]
        public uint BgpAsn { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The BGP Peering Address for this VpnSite.")]
        public string BgpPeeringAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The BGP Peering weight for this VpnSite.")]
        public uint BgpPeeringWeight { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SiteKey for this VpnSite.")]
        public SecureString SiteKey { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Is this VpnSite a security site")]
        public SwitchParameter IsSecuritySite { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnSiteObject, StringComparison.OrdinalIgnoreCase))
            {
                this.Name = this.InputObject.Name;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnSiteResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.Name = parsedResourceId.ResourceName;
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            var vpnSiteToUpdate = this.GetVpnSite(this.ResourceGroupName, this.Name);
            if (vpnSiteToUpdate == null)
            {
                throw new PSArgumentException("The VpnSite to update could not be found");
            }

            //// Resolve the virtual wan, if specified
            if (this.VirtualWan != null)
            {
                this.VirtualWanResourceGroupName = this.VirtualWan.ResourceGroupName;
                this.VirtualWanName = this.VirtualWan.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.VirtualWanId))
            {
                var parsedWanResourceId = new ResourceIdentifier(this.VirtualWanId);
                this.VirtualWanResourceGroupName = parsedWanResourceId.ResourceGroupName;
                this.VirtualWanName = parsedWanResourceId.ResourceName;
            }

            if (!string.IsNullOrWhiteSpace(this.VirtualWanResourceGroupName) && !string.IsNullOrWhiteSpace(this.VirtualWanName))
            {
                PSVirtualWan resolvedVirtualWan = new VirtualWanBaseCmdlet().GetVirtualWan(this.VirtualWanResourceGroupName, this.VirtualWanName);

                if (resolvedVirtualWan == null)
                {
                    throw new PSArgumentException("The referenced virtual wan cannot be resolved.");
                }

                vpnSiteToUpdate.VirtualWan = new PSResourceId() { Id = resolvedVirtualWan.Id };
            }

            //// Bgp Settings
            if (this.BgpAsn > 0 || this.BgpPeeringWeight > 0 || !string.IsNullOrWhiteSpace(this.BgpPeeringAddress))
            {
                if (vpnSiteToUpdate.BgpSettings == null)
                {
                    //// New BGP settings
                    vpnSiteToUpdate.BgpSettings = this.ValidateAndCreatePSBgpSettings(this.BgpAsn, this.BgpPeeringWeight, this.BgpPeeringAddress);
                }
                else
                {
                    //// Update BGP settings for the specified values only
                    if (this.BgpAsn > 0)
                    {
                        vpnSiteToUpdate.BgpSettings.Asn = this.BgpAsn;
                    }

                    if (this.BgpPeeringWeight > 0)
                    {
                        vpnSiteToUpdate.BgpSettings.PeerWeight = Convert.ToInt32(this.BgpPeeringWeight);
                    }

                    if (!string.IsNullOrWhiteSpace(this.BgpPeeringAddress))
                    {
                        vpnSiteToUpdate.BgpSettings.BgpPeeringAddress = this.BgpPeeringAddress;
                    }
                }
            }

            //// VpnSite device settings
            if (!string.IsNullOrWhiteSpace(this.DeviceModel) || !string.IsNullOrWhiteSpace(this.DeviceVendor))
            {
                vpnSiteToUpdate.DeviceProperties = this.ValidateAndCreateVpnSiteDeviceProperties(this.DeviceModel, this.DeviceVendor, this.LinkSpeedInMbps);
            }

            //// IpAddress
            if (!string.IsNullOrWhiteSpace(this.IpAddress))
            {
                System.Net.IPAddress ipAddress;
                if (!System.Net.IPAddress.TryParse(this.IpAddress, out ipAddress))
                {
                    throw new PSArgumentException("The IPAddress specified is invalid.");
                }

                vpnSiteToUpdate.IpAddress = this.IpAddress;
            }

            //// Adress spaces
            if (this.AddressSpace != null && this.AddressSpace.Any())
            {
                if (vpnSiteToUpdate.AddressSpace == null)
                {
                    vpnSiteToUpdate.AddressSpace = new PSAddressSpace();
                }
                
                vpnSiteToUpdate.AddressSpace.AddressPrefixes.AddRange(this.AddressSpace);
            }

            //// SiteKey
            if (this.SiteKey != null)
            {
                vpnSiteToUpdate.SiteKey = SecureStringExtensions.ConvertToString(this.SiteKey);
            }

            ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(Properties.Resources.SettingResourceMessage, this.Name),
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteObject(this.CreateOrUpdateVpnSite(this.ResourceGroupName, this.Name, vpnSiteToUpdate, this.Tag));
                    });
        }
    }
}
