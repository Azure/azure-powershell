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

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnSite",
<<<<<<< HEAD
        DefaultParameterSetName = CortexParameterSetNames.ByVpnSiteName + "NoVirtualWanUpdate",
=======
        DefaultParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.NoVirtualWanUpdate,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnSite))]
    public class UpdateAzureRmVpnSiteCommand : VpnSiteBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanResourceId,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanObject,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
<<<<<<< HEAD
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + "NoVirtualWanUpdate",
=======
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.NoVirtualWanUpdate,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VpnSiteName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanResourceId,
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanObject,
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [Parameter(
<<<<<<< HEAD
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + "NoVirtualWanUpdate",
=======
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.NoVirtualWanUpdate,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnSites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VpnSite")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + CortexParameterSetNames.ByVirtualWanResourceId,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + CortexParameterSetNames.ByVirtualWanObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [Parameter(
<<<<<<< HEAD
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + "NoVirtualWanUpdate",
=======
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + CortexParameterSetNames.NoVirtualWanUpdate,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSVpnSite InputObject { get; set; }

        [Alias("VpnSiteId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the vpn site.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + CortexParameterSetNames.ByVirtualWanResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the vpn site.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + CortexParameterSetNames.ByVirtualWanObject,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the vpn site.")]
        [Parameter(
<<<<<<< HEAD
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + "NoVirtualWanUpdate",
=======
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + CortexParameterSetNames.NoVirtualWanUpdate,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the vpn site.")]
        [ResourceIdCompleter("Microsoft.Network/vpnSites")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The resource group name of the VirtualWan this VpnSite needs to be connected to.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The resource group name of the VirtualWan this VpnSite needs to be connected to.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The resource group name of the VirtualWan this VpnSite needs to be connected to.")]
        public string VirtualWanResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The name of the VirtualWan this VpnSite needs to be connected to.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The name of the VirtualWan this VpnSite needs to be connected to.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The name of the VirtualWan this VpnSite needs to be connected to.")]
        public string VirtualWanName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The VirtualWan this VpnSite needs to be connected to.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The VirtualWan this VpnSite needs to be connected to.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The VirtualWan this VpnSite needs to be connected to.")]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId + CortexParameterSetNames.ByVirtualWanResourceId,
            HelpMessage = "The ResourceId VirtualWan this VpnSite needs to be connected to.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName + CortexParameterSetNames.ByVirtualWanResourceId,
            HelpMessage = "The ResourceId VirtualWan this VpnSite needs to be connected to.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject + CortexParameterSetNames.ByVirtualWanResourceId,
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
        public string[] AddressSpace { get; set; }

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
<<<<<<< HEAD
=======
            HelpMessage = "The list of VpnSiteLinks that this VpnSite have.")]
        public PSVpnSiteLink[] VpnSiteLink { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The office 365 traffic breakout policy for this VpnSite.")]
        [ValidateNotNullOrEmpty]
        public PSO365PolicyProperties O365Policy { get; set; }

        [Parameter(
            Mandatory = false,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSVpnSite vpnSiteToUpdate = null;
            
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnSiteObject))
            {
                vpnSiteToUpdate = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnSiteResourceId))
                {
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    this.Name = parsedResourceId.ResourceName;
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                vpnSiteToUpdate = this.GetVpnSite(this.ResourceGroupName, this.Name);
            }

            if (vpnSiteToUpdate == null)
            {
                throw new PSArgumentException(Properties.Resources.VpnSiteNotFound);
            }

            //// Resolve the virtual wan, if specified
<<<<<<< HEAD
            if (!ParameterSetName.Contains("NoVirtualWanUpdate"))
=======
            if (!ParameterSetName.Contains(CortexParameterSetNames.NoVirtualWanUpdate))
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualWanObject))
                {
                    this.VirtualWanResourceGroupName = this.VirtualWan.ResourceGroupName;
                    this.VirtualWanName = this.VirtualWan.Name;
                }
                else if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualWanResourceId))
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
                        throw new PSArgumentException(Properties.Resources.VirtualWanNotFound);
                    }

                    vpnSiteToUpdate.VirtualWan = new PSResourceId() { Id = resolvedVirtualWan.Id };
                }
            }

<<<<<<< HEAD
=======
            if (vpnSiteToUpdate.VpnSiteLinks != null && vpnSiteToUpdate.VpnSiteLinks.Any())
            {
                //// Use only link properties instead of Site properties.
                if (this.BgpAsn > 0 || this.BgpPeeringWeight > 0 || !string.IsNullOrWhiteSpace(this.BgpPeeringAddress) || this.LinkSpeedInMbps > 0 || !string.IsNullOrWhiteSpace(this.IpAddress))
                {
                    throw new PSArgumentException(Properties.Resources.VpnSitePropertyIsDeprecated);
                }
            }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
                vpnSiteToUpdate.DeviceProperties = this.ValidateAndCreateVpnSiteDeviceProperties(
                    this.DeviceModel ?? string.Empty, 
                    this.DeviceVendor ?? string.Empty, 
                    this.LinkSpeedInMbps);
            }

            //// IpAddress
            if (!string.IsNullOrWhiteSpace(this.IpAddress))
            {
                System.Net.IPAddress ipAddress;
                if (!System.Net.IPAddress.TryParse(this.IpAddress, out ipAddress))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidIPAddress);
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

<<<<<<< HEAD
=======
            //// VpnSiteLinks
            if (this.VpnSiteLink != null)
            {
                vpnSiteToUpdate.VpnSiteLinks = new List<PSVpnSiteLink>();
                vpnSiteToUpdate.VpnSiteLinks.AddRange(this.VpnSiteLink);
            }

            if (this.O365Policy != null)
            {
                vpnSiteToUpdate.O365Policy = this.O365Policy;
            }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        WriteObject(this.CreateOrUpdateVpnSite(this.ResourceGroupName, this.Name, vpnSiteToUpdate, this.Tag));
                    });
        }
    }
}
