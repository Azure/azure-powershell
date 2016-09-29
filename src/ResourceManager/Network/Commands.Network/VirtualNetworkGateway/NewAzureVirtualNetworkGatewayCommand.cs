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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmVirtualNetworkGateway", SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualNetworkGateway))]
    public class NewAzureVirtualNetworkGatewayCommand : VirtualNetworkGatewayBaseCmdlet
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
            HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IpConfigurations for Virtual network gateway.")]
        [ValidateNotNullOrEmpty]
        public List<PSVirtualNetworkGatewayIpConfiguration> IpConfigurations { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type of this virtual network gateway: Vpn, ExoressRoute")]
        [ValidateSet(
        MNM.VirtualNetworkGatewayType.Vpn,
        MNM.VirtualNetworkGatewayType.ExpressRoute,
        IgnoreCase = true)]
        public string GatewayType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type of the Vpn:PolicyBased/RouteBased")]
        [ValidateSet(
        MNM.VpnType.PolicyBased,
        MNM.VpnType.RouteBased,
        IgnoreCase = true)]
        public string VpnType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "EnableBgp Flag")]
        public bool EnableBgp { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable Active Active feature on virtual network gateway")]
        public SwitchParameter EnableActiveActiveFeature { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type of the Vpn:PolicyBased/RouteBased")]
        [ValidateSet(
        MNM.VirtualNetworkGatewaySkuTier.Basic,
        MNM.VirtualNetworkGatewaySkuTier.Standard,
        MNM.VirtualNetworkGatewaySkuTier.HighPerformance,
        MNM.VirtualNetworkGatewaySkuTier.UltraPerformance,
        IgnoreCase = true)]
        public string GatewaySku { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             ParameterSetName = "SetByResource",
            HelpMessage = "GatewayDefaultSite")]
        public PSLocalNetworkGateway GatewayDefaultSite { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S VpnClient AddressPool")]
        [ValidateNotNullOrEmpty]
        public List<string> VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of VpnClientRootCertificates to be added.")]
        public List<PSVpnClientRootCertificate> VpnClientRootCertificates { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of VpnClientCertificates to be revoked.")]
        public List<PSVpnClientRevokedCertificate> VpnClientRevokedCertificates { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network gateway's ASN for BGP over VPN")]
        public uint Asn { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The weight added to routes learned over BGP from this virtual network gateway")]
        public int PeerWeight { get; set; }

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
            var present = this.IsVirtualNetworkGatewayPresent(this.ResourceGroupName, this.Name);
            string warningMsg = string.Empty;
            string continueMsg = Properties.Resources.CreatingResourceMessage;
            bool force = true;
            if (!string.IsNullOrEmpty(GatewaySku)
                && GatewaySku.Equals(MNM.VirtualNetworkGatewaySkuTier.UltraPerformance,StringComparison.InvariantCultureIgnoreCase))
            {
                warningMsg = string.Format(Properties.Resources.UltraPerformaceGatewayWarning,this.Name);
                force = false;
            }
            else
            {
                warningMsg = string.Format(Properties.Resources.OverwritingResource, this.Name);
            }
            if (this.Force.IsPresent)
            {
                force = true;
            }

            ConfirmAction(
                force,
                warningMsg,
                continueMsg,
                Name,
                () =>
                {
                    var virtualNetworkGateway = CreateVirtualNetworkGateway();
                    WriteObject(virtualNetworkGateway);
                },
                () => present);
            
        }

        private PSVirtualNetworkGateway CreateVirtualNetworkGateway()
        {
            var vnetGateway = new PSVirtualNetworkGateway();
            vnetGateway.Name = this.Name;
            vnetGateway.ResourceGroupName = this.ResourceGroupName;
            vnetGateway.Location = this.Location;

            if (this.GatewaySku != null)
            {
                vnetGateway.Sku = new PSVirtualNetworkGatewaySku();
                vnetGateway.Sku.Tier = this.GatewaySku;
                vnetGateway.Sku.Name = this.GatewaySku;
            }
            else
            {
                // If gateway sku param value is not passed, set gateway sku to Standard if VpnType is RouteBased and Basic if VpnType is PolicyBased
                if (this.VpnType != null && this.VpnType.Equals(MNM.VpnType.RouteBased))
                {
                    vnetGateway.Sku = new PSVirtualNetworkGatewaySku();
                    vnetGateway.Sku.Tier = MNM.VirtualNetworkGatewaySkuTier.Standard;
                    vnetGateway.Sku.Name = MNM.VirtualNetworkGatewaySkuTier.Standard;
                }
                else
                {
                    vnetGateway.Sku = new PSVirtualNetworkGatewaySku();
                    vnetGateway.Sku.Tier = MNM.VirtualNetworkGatewaySkuTier.Basic;
                    vnetGateway.Sku.Name = MNM.VirtualNetworkGatewaySkuTier.Basic;
                }
            }

            if (this.EnableActiveActiveFeature.IsPresent && !vnetGateway.Sku.Tier.Equals(MNM.VirtualNetworkGatewaySkuTier.HighPerformance))
            {
                throw new ArgumentException("Virtual Network Gateway Sku should be " + MNM.VirtualNetworkGatewaySkuTier.HighPerformance + " when Active-Active feature flag is set to True.");
            }

            if (this.EnableActiveActiveFeature.IsPresent && !this.VpnType.Equals(MNM.VpnType.RouteBased))
            {
                throw new ArgumentException("Virtual Network Gateway VpnType should be " + MNM.VpnType.RouteBased + " when Active-Active feature flag is set to True.");
            }

            if (this.EnableActiveActiveFeature.IsPresent && this.IpConfigurations.Count != 2)
            {
                throw new ArgumentException("Virtual Network Gateway should have 2 Gateway IpConfigurations specified when Active-Active feature flag is True.");
            }

            if (!this.EnableActiveActiveFeature.IsPresent && this.IpConfigurations.Count == 2)
            {
                throw new ArgumentException("Virtual Network Gateway should have Active-Active feature flag set to True as there are 2 Gateway IpConfigurations specified. OR there should be only one Gateway IpConfiguration specified.");
            }

            if (this.IpConfigurations != null)
            {
                vnetGateway.IpConfigurations = this.IpConfigurations;
            }

            if (!string.IsNullOrEmpty(GatewaySku)
                && GatewaySku.Equals(
                    MNM.VirtualNetworkGatewaySkuTier.UltraPerformance,
                    StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(GatewayType)
                && !GatewayType.Equals(
                    MNM.VirtualNetworkGatewayType.ExpressRoute.ToString(),
                    StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("Virtual Network Gateway Need to be Express Route when the sku is UltraPerformance.");

            }
            vnetGateway.GatewayType = this.GatewayType;
            vnetGateway.VpnType = this.VpnType;
            vnetGateway.EnableBgp = this.EnableBgp;
            vnetGateway.ActiveActive = this.EnableActiveActiveFeature.IsPresent;

            if (this.GatewayDefaultSite != null)
            {
                vnetGateway.GatewayDefaultSite = new PSResourceId();
                vnetGateway.GatewayDefaultSite.Id = this.GatewayDefaultSite.Id;
            }
            else
            {
                vnetGateway.GatewayDefaultSite = null;
            }

            if (this.VpnClientAddressPool != null || this.VpnClientRootCertificates != null || this.VpnClientRevokedCertificates != null)
            {
                vnetGateway.VpnClientConfiguration = new PSVpnClientConfiguration();

                if (this.VpnClientAddressPool != null)
                {
                    // Make sure passed Virtual Network gateway type is RouteBased if P2S VpnClientAddressPool is specified.
                    if (this.VpnType == null || !this.VpnType.Equals(MNM.VpnType.RouteBased))
                    {
                        throw new ArgumentException("Virtual Network Gateway VpnType should be :" + MNM.VpnType.RouteBased + " when P2S VpnClientAddressPool is specified.");
                    }

                    vnetGateway.VpnClientConfiguration.VpnClientAddressPool = new PSAddressSpace();
                    vnetGateway.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes = this.VpnClientAddressPool;
                }

                if (this.VpnClientRootCertificates != null)
                {
                    vnetGateway.VpnClientConfiguration.VpnClientRootCertificates = this.VpnClientRootCertificates;
                }

                if (this.VpnClientRevokedCertificates != null)
                {
                    vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates = this.VpnClientRevokedCertificates;
                }
            }
            else
            {
                vnetGateway.VpnClientConfiguration = null;
            }

            if (this.Asn > 0 || this.PeerWeight > 0)
            {
                vnetGateway.BgpSettings = new PSBgpSettings();
                vnetGateway.BgpSettings.BgpPeeringAddress = null; // We block modifying the gateway's BgpPeeringAddress (CA)

                if (this.Asn > 0)
                {
                    vnetGateway.BgpSettings.Asn = this.Asn;
                }

                if (this.PeerWeight > 0)
                {
                    vnetGateway.BgpSettings.PeerWeight = this.PeerWeight;
                }
                else if (this.PeerWeight < 0)
                {
                    throw new ArgumentException("PeerWeight must be a positive integer");
                }
            }

            // Map to the sdk object
            var vnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            vnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetGatewayModel);

            var getVirtualNetworkGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.Name);

            return getVirtualNetworkGateway;
        }
    }
}
