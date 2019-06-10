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

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnSite",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnSite))]
    public class NewAzureRmVpnSiteCommand : VpnSiteBaseCmdlet
    {

        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VpnSiteName")]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource location.")]
        [LocationCompleter("Microsoft.Network/vpnSites")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            HelpMessage = "The resource group name of the VirtualWan this VpnSite needs to be connected to.")]
        [ResourceGroupCompleter]
        public string VirtualWanResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            HelpMessage = "The name of the VirtualWan this VpnSite needs to be connected to.")]
        [ResourceNameCompleter("Microsoft.Network/virtualWans", "VirtualWanResourceGroupName")]
        public string VirtualWanName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The VirtualWan this VpnSite needs to be connected to.")]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            HelpMessage = "The ResourceId VirtualWan this VpnSite needs to be connected to.")]
        [ResourceIdCompleter("Microsot.Network/virtualWans")]
        public string VirtualWanId { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The IpAddress for this VpnSite.")]
        public string IpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The address prefixes of the virtual network.")]
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
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            PSVpnSite vpnSiteToCreate = new PSVpnSite();
            vpnSiteToCreate.ResourceGroupName = this.ResourceGroupName;
            vpnSiteToCreate.Name = this.Name;
            vpnSiteToCreate.Location = this.Location;

            if (this.IsVpnSitePresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }

            //// Resolve the virtual wan
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualWanResourceGroupName = this.VirtualWan.ResourceGroupName;
                this.VirtualWanName = this.VirtualWan.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedWanResourceId = new ResourceIdentifier(this.VirtualWanId);
                this.VirtualWanResourceGroupName = parsedWanResourceId.ResourceGroupName;
                this.VirtualWanName = parsedWanResourceId.ResourceName;
            }

            PSVirtualWan resolvedVirtualWan = new VirtualWanBaseCmdlet().GetVirtualWan(this.VirtualWanResourceGroupName, this.VirtualWanName);

            if (resolvedVirtualWan == null)
            {
                throw new PSArgumentException(Properties.Resources.VirtualWanNotFound);
            }

            vpnSiteToCreate.VirtualWan = new PSResourceId() { Id = resolvedVirtualWan.Id };

            //// Bgp Settings
            if (this.BgpAsn > 0 || this.BgpPeeringWeight > 0 || !string.IsNullOrWhiteSpace(this.BgpPeeringAddress))
            {
                vpnSiteToCreate.BgpSettings = this.ValidateAndCreatePSBgpSettings(this.BgpAsn, this.BgpPeeringWeight, this.BgpPeeringAddress);
            }

            //// VpnSite device settings
            if (!string.IsNullOrWhiteSpace(this.DeviceModel) || !string.IsNullOrWhiteSpace(this.DeviceVendor))
            {
                vpnSiteToCreate.DeviceProperties = this.ValidateAndCreateVpnSiteDeviceProperties(
                    this.DeviceModel ?? string.Empty,
                    this.DeviceVendor ?? string.Empty,
                    this.LinkSpeedInMbps);
            }

            //// IpAddress
            System.Net.IPAddress ipAddress;
            if (!System.Net.IPAddress.TryParse(this.IpAddress, out ipAddress))
            {
                throw new PSArgumentException(Properties.Resources.InvalidIPAddress);
            }

            vpnSiteToCreate.IpAddress = this.IpAddress;

            //// Address spaces
            if (this.AddressSpace != null && this.AddressSpace.Any())
            {
                vpnSiteToCreate.AddressSpace = new PSAddressSpace();
                vpnSiteToCreate.AddressSpace.AddressPrefixes = new List<string>();
                vpnSiteToCreate.AddressSpace.AddressPrefixes.AddRange(this.AddressSpace);
            }

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateVpnSite(this.ResourceGroupName, this.Name, vpnSiteToCreate, this.Tag));
                });
        }
    }
}
