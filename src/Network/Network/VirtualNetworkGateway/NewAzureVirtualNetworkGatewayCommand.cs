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
using System.Security;
using Microsoft.Azure.Commands.Network.VirtualNetworkGateway;
using Microsoft.WindowsAzure.Commands.Common;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGateway",SupportsShouldProcess = true,DefaultParameterSetName = VirtualNetworkGatewayParameterSets.Default),OutputType(typeof(PSVirtualNetworkGateway))]
    public class NewAzureVirtualNetworkGatewayCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "The resource name.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.Default,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.Default,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "location.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.Default,
            HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/virtualNetworkGateways")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IpConfigurations for Virtual network gateway.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGatewayIpConfiguration[] IpConfigurations { get; set; }

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
            HelpMessage = "The Gateway Sku Tier")]
        [ValidateSet(
            MNM.VirtualNetworkGatewaySkuTier.Basic,
            MNM.VirtualNetworkGatewaySkuTier.Standard,
            MNM.VirtualNetworkGatewaySkuTier.HighPerformance,
            MNM.VirtualNetworkGatewaySkuTier.UltraPerformance,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw1,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw2,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw3,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw1AZ,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw2AZ,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw3AZ,
            MNM.VirtualNetworkGatewaySkuTier.ErGw1AZ,
            MNM.VirtualNetworkGatewaySkuTier.ErGw2AZ,
            MNM.VirtualNetworkGatewaySkuTier.ErGw3AZ,
            IgnoreCase = true)]
        public string GatewaySku { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "GatewayDefaultSite")]
        public PSLocalNetworkGateway GatewayDefaultSite { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S VpnClient AddressPool")]
        [ValidateNotNullOrEmpty]
        public string[] VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of P2S VPN client tunneling protocols")]
        [ValidateSet(
            MNM.VpnClientProtocol.SSTP,
            MNM.VpnClientProtocol.IkeV2,
            MNM.VpnClientProtocol.OpenVPN)]
        [ValidateNotNullOrEmpty]
        public string[] VpnClientProtocol { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of VpnClientRootCertificates to be added.")]
        public PSVpnClientRootCertificate[] VpnClientRootCertificates { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of VpnClientCertificates to be revoked.")]
        public PSVpnClientRevokedCertificate[] VpnClientRevokedCertificates { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "A list of IPSec policies for P2S VPN client tunneling protocols.")]
        public PSIpsecPolicy[] VpnClientIpsecPolicy { get; set; }

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
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [ValidateNotNullOrEmpty]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [ValidateNotNullOrEmpty]
        public SecureString RadiusServerSecret { get; set; }

        [Parameter(
                    Mandatory = false,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "Custom routes AddressPool specified by customer")]
        [ValidateNotNullOrEmpty]
        public string[] CustomRoute { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsVirtualNetworkGatewayPresent(this.ResourceGroupName, this.Name);
            string warningMsg = string.Empty;
            string continueMsg = Properties.Resources.CreatingResourceMessage;
            bool force = true;
            if (!string.IsNullOrEmpty(GatewaySku)
                && GatewaySku.Equals(MNM.VirtualNetworkGatewaySkuTier.UltraPerformance, StringComparison.InvariantCultureIgnoreCase))
            {
                warningMsg = string.Format(Properties.Resources.UltraPerformaceGatewayWarning, this.Name);
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
                // If gateway sku param value is not passed,  - Let NRP make the decision, just pass it as null here
                vnetGateway.Sku = null;
            }

            if (this.EnableActiveActiveFeature.IsPresent && !this.VpnType.Equals(MNM.VpnType.RouteBased))
            {
                throw new ArgumentException("Virtual Network Gateway VpnType should be " + MNM.VpnType.RouteBased + " when Active-Active feature flag is set to True.");
            }

            if (this.IpConfigurations != null)
            {
                vnetGateway.IpConfigurations = this.IpConfigurations?.ToList();
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

            if (this.VpnClientAddressPool != null ||
                this.VpnClientRootCertificates != null ||
                this.VpnClientRevokedCertificates != null ||
                this.RadiusServerAddress != null ||
                (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Length != 0))
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
                    vnetGateway.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes = this.VpnClientAddressPool?.ToList();
                }

                if (this.VpnClientProtocol != null)
                {
                    vnetGateway.VpnClientConfiguration.VpnClientProtocols = this.VpnClientProtocol?.ToList();
                }

                if (this.VpnClientRootCertificates != null)
                {
                    vnetGateway.VpnClientConfiguration.VpnClientRootCertificates = this.VpnClientRootCertificates?.ToList();
                }

                if (this.VpnClientRevokedCertificates != null)
                {
                    vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates = this.VpnClientRevokedCertificates?.ToList();
                }

                if (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Length != 0)
                {
                    vnetGateway.VpnClientConfiguration.VpnClientIpsecPolicies = this.VpnClientIpsecPolicy?.ToList();
                }

                if ((this.RadiusServerAddress != null && this.RadiusServerSecret == null) ||
                    (this.RadiusServerAddress == null && this.RadiusServerSecret != null))
                {
                    throw new ArgumentException("Both radius server address and secret must be specified if external radius is being configured");
                }

                if (this.RadiusServerAddress != null)
                {
                    vnetGateway.VpnClientConfiguration.RadiusServerAddress = this.RadiusServerAddress;
                    vnetGateway.VpnClientConfiguration.RadiusServerSecret = SecureStringExtensions.ConvertToString(this.RadiusServerSecret);
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

            if (this.CustomRoute != null && this.CustomRoute.Any())
            {
                vnetGateway.CustomRoutes = new PSAddressSpace();
                vnetGateway.CustomRoutes.AddressPrefixes = this.CustomRoute?.ToList();
            }
            else
            {
                vnetGateway.CustomRoutes = null;
            }

            // Map to the sdk object
            var vnetGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            vnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetGatewayModel);

            var getVirtualNetworkGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.Name);

            return getVirtualNetworkGateway;
        }
    }
}
