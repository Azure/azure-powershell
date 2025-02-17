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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGateway", SupportsShouldProcess = true, DefaultParameterSetName = VirtualNetworkGatewayParameterSets.Default), OutputType(typeof(PSVirtualNetworkGateway))]
    public class NewAzureVirtualNetworkGatewayCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
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
            ParameterSetName = VirtualNetworkGatewayParameterSets.Default,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

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
            HelpMessage = "The type of this virtual network gateway: Vpn, ExpressRoute, LocalGateway")]
        [ValidateSet(
            MNM.VirtualNetworkGatewayType.Vpn,
            MNM.VirtualNetworkGatewayType.ExpressRoute,
            MNM.VirtualNetworkGatewayType.LocalGateway,
            IgnoreCase = true)]
        public string GatewayType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extended location of this virtual network gateway")]
        public string ExtendedLocation { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "VNetExtendedLocationResourceId for Virtual network gateway.")]
        [ValidateNotNullOrEmpty]
        public string VNetExtendedLocationResourceId { get; set; }

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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Disable IPsec Protection Flag")]
        public bool DisableIPsecProtection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable Active Active feature on virtual network gateway")]
        public SwitchParameter EnableActiveActiveFeature { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable private IPAddress on virtual network gateway")]
        public SwitchParameter EnablePrivateIpAddress { get; set; }

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
            MNM.VirtualNetworkGatewaySkuTier.VpnGw4,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw5,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw1AZ,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw2AZ,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw3AZ,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw4AZ,
            MNM.VirtualNetworkGatewaySkuTier.VpnGw5AZ,
            MNM.VirtualNetworkGatewaySkuTier.ErGw1AZ,
            MNM.VirtualNetworkGatewaySkuTier.ErGw2AZ,
            MNM.VirtualNetworkGatewaySkuTier.ErGw3AZ,
            MNM.VirtualNetworkGatewaySkuTier.ErGwScale,
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
            MNM.VpnClientProtocol.Sstp,
            MNM.VpnClientProtocol.IkeV2,
            MNM.VpnClientProtocol.OpenVPN)]
        [ValidateNotNullOrEmpty]
        public string[] VpnClientProtocol { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of P2S VPN client authentication types.")]
        [ValidateSet(
            MNM.VpnAuthenticationType.Certificate,
            MNM.VpnAuthenticationType.Radius,
            MNM.VpnAuthenticationType.AAD)]
        [ValidateNotNullOrEmpty]
        public string[] VpnAuthenticationType { get; set; }

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
            HelpMessage = "The BgpPeeringAddresses for Virtual network gateway bgpsettings.")]
        [ValidateNotNullOrEmpty]
        public PSIpConfigurationBgpPeeringAddress[] IpConfigurationBgpPeeringAddresses { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The NatRules for Virtual network gateway.")]
        public PSVirtualNetworkGatewayNatRule[] NatRule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable BgpRouteTranslationForNat on this VirtualNetworkGateway.")]
        public SwitchParameter EnableBgpRouteTranslationForNat { get; set; }

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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S External Radius server address.")]
        [ValidateNotNullOrEmpty]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S External Radius server secret.")]
        [ValidateNotNullOrEmpty]
        public SecureString RadiusServerSecret { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S multiple external Radius server servers.")]
        public PSRadiusServer[] RadiusServerList { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S AAD authentication option:AadTenantUri.")]
        [ValidateNotNullOrEmpty]
        public string AadTenantUri { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S AAD authentication option:AadAudienceId.")]
        [ValidateNotNullOrEmpty]
        public string AadAudienceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S AAD authentication option:AadIssuerUri.")]
        [ValidateNotNullOrEmpty]
        public string AadIssuerUri { get; set; }

        [Parameter(
                    Mandatory = false,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "Custom routes AddressPool specified by customer")]
        [ValidateNotNullOrEmpty]
        public string[] CustomRoute { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The generation for this VirtualNetwork VPN gateway. Must be None if GatewayType is not VPN.")]
        [PSArgumentCompleter(
            MNM.VpnGatewayGeneration.None,
            MNM.VpnGatewayGeneration.Generation1,
            MNM.VpnGatewayGeneration.Generation2)]
        public string VpnGatewayGeneration { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S policy group added to this gateway")]
        public PSVirtualNetworkGatewayPolicyGroup[] VirtualNetworkGatewayPolicyGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S Client Connection Configuration that assiociate between address and policy group")]
        public PSClientConnectionConfiguration[] ClientConnectionConfiguration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Property to indicate if the Express Route Gateway serves traffic when there are multiple Express Route Gateways in the vnet: Enabled/Disabled")]
        [PSArgumentCompleter(
            "Enabled",
            "Disabled")]
        public string AdminState  { get; set; }

		[Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Property to indicate the resiliency model of Express Route Gateway: SingleHomed / MultiHomed")]
        [PSArgumentCompleter(
            "SingleHomed",
            "MultiHomed")]
        public string ResiliencyModel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set min scale units for scalable gateways")]
        public Int32 MinScaleUnit { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set max scale units for scalable gateways")]
        public Int32 MaxScaleUnit { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsVirtualNetworkGatewayPresent(this.ResourceGroupName, this.Name);
            string warningMsg = string.Empty;
            string continueMsg = Properties.Resources.CreatingResourceMessage;
            bool force = true;
            var useShouldContinue = present;
            var isCertConfigured = (this.VpnClientRootCertificates != null && this.VpnClientRootCertificates.Count() > 0) || (this.VpnClientRevokedCertificates != null && this.VpnClientRevokedCertificates.Count() > 0);
            var isRadiusConfigured = !string.IsNullOrEmpty(this.RadiusServerAddress) && this.RadiusServerSecret != null && !string.IsNullOrEmpty(SecureStringExtensions.ConvertToString(this.RadiusServerSecret));
            var isAadConfigured = this.AadTenantUri != null && this.AadAudienceId != null && this.AadIssuerUri != null;
            
            if (!string.IsNullOrEmpty(GatewaySku)
                && GatewaySku.Equals(MNM.VirtualNetworkGatewaySkuTier.UltraPerformance, StringComparison.InvariantCultureIgnoreCase))
            {
                warningMsg = string.Format(Properties.Resources.UltraPerformaceGatewayWarning, this.Name);
                force = false;
            }
            else if (this.VpnClientProtocol != null &&
                this.VpnClientProtocol.Count() > 0 &&
                this.VpnClientProtocol.Contains(MNM.VpnClientProtocol.OpenVPN) &&
                this.VpnClientProtocol.Contains(MNM.VpnClientProtocol.IkeV2) &&
                isAadConfigured &&
                (isRadiusConfigured || isCertConfigured))
            {
                warningMsg = Properties.Resources.VpnMultiAuthIkev2OpenvpnAadWarning;
                useShouldContinue = true;
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
                () => useShouldContinue);

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
            if (this.ExtendedLocation != null && (vnetGateway.GatewayType == "LocalGateway" || vnetGateway.GatewayType == "ExpressRoute"))
            {
                vnetGateway.ExtendedLocation = new PSExtendedLocation(this.ExtendedLocation);
                vnetGateway.VNetExtendedLocationResourceId = this.VNetExtendedLocationResourceId;
            }
            vnetGateway.VpnType = this.VpnType;
            vnetGateway.EnableBgp = this.EnableBgp;
            vnetGateway.DisableIPsecProtection = this.DisableIPsecProtection;
            vnetGateway.ActiveActive = this.EnableActiveActiveFeature.IsPresent;
            vnetGateway.EnablePrivateIpAddress = this.EnablePrivateIpAddress.IsPresent;

            if (this.VirtualNetworkGatewayPolicyGroup != null && this.VirtualNetworkGatewayPolicyGroup.Length > 0)
            {
                vnetGateway.VirtualNetworkGatewayPolicyGroups = this.VirtualNetworkGatewayPolicyGroup.ToList();
            }

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
                (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Length != 0) ||
                this.AadTenantUri != null)
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

                if (this.VpnAuthenticationType != null)
                {
                    vnetGateway.VpnClientConfiguration.VpnAuthenticationTypes = this.VpnAuthenticationType?.ToList();
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

                if (this.RadiusServerAddress != null && this.RadiusServerSecret != null)
                {
                    vnetGateway.VpnClientConfiguration.RadiusServerAddress = this.RadiusServerAddress;
                    vnetGateway.VpnClientConfiguration.RadiusServerSecret = SecureStringExtensions.ConvertToString(this.RadiusServerSecret);
                }
                
                if (this.RadiusServerList != null && this.RadiusServerList.Any())
                {
                    vnetGateway.VpnClientConfiguration.RadiusServers = this.RadiusServerList?.ToList();
                }

                if (this.AadTenantUri != null)
                {
                    if (this.AadIssuerUri == null || this.AadAudienceId == null)
                    {
                        throw new ArgumentException("AadTenantUri, AadIssuerUri and AadAudienceId must be specified if AAD authentication is being configured for P2S.");
                    }

                    // In the case of multi-auth with OpenVPN and IkeV2, block user from configuring with just AAD since AAD is not supported for IkeV2
                    var isCertConfigured = (this.VpnClientRootCertificates != null && this.VpnClientRootCertificates.Count() > 0) || (this.VpnClientRevokedCertificates != null && this.VpnClientRevokedCertificates.Count() > 0);
                    var isRadiusConfigured = !string.IsNullOrEmpty(this.RadiusServerAddress) && this.RadiusServerSecret != null && !string.IsNullOrEmpty(SecureStringExtensions.ConvertToString(this.RadiusServerSecret));

                    if (!isCertConfigured &&
                        !isRadiusConfigured &&
                        vnetGateway.VpnClientConfiguration.VpnClientProtocols.Contains(MNM.VpnClientProtocol.IkeV2) &&
                        vnetGateway.VpnClientConfiguration.VpnClientProtocols.Contains(MNM.VpnClientProtocol.OpenVPN) &&
                        vnetGateway.VpnClientConfiguration.VpnClientProtocols.Count() == 2)
                    {
                        throw new ArgumentException(Properties.Resources.VpnMultiAuthIkev2OpenvpnOnlyAad);
                    }

                    if (vnetGateway.VpnClientConfiguration.VpnClientProtocols.Count() >= 1 &&
                        vnetGateway.VpnClientConfiguration.VpnClientProtocols.Contains(MNM.VpnClientProtocol.OpenVPN))
                    {
                        vnetGateway.VpnClientConfiguration.AadTenant = this.AadTenantUri;
                        vnetGateway.VpnClientConfiguration.AadIssuer = this.AadIssuerUri;
                        vnetGateway.VpnClientConfiguration.AadAudience = this.AadAudienceId;
                    }
                    else
                    {
                        throw new ArgumentException("Virtual Network Gateway VpnClientProtocol should contain :" + MNM.VpnClientProtocol.OpenVPN + " when P2S AAD authentication is being configured.");
                    }
                }

                if (this.ClientConnectionConfiguration != null && this.ClientConnectionConfiguration.Any())
                {
                    foreach( var config in this.ClientConnectionConfiguration)
                    {
                        foreach (var policyGroup  in config.VirtualNetworkGatewayPolicyGroups)
                        {
                            policyGroup.Id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworkGateways/{2}/virtualNetworkGatewayPolicyGroups/{3}", this.NetworkClient.NetworkManagementClient.SubscriptionId, vnetGateway.ResourceGroupName, Name, policyGroup.Id);
                         }
                    }
                    vnetGateway.VpnClientConfiguration.ClientConnectionConfigurations = this.ClientConnectionConfiguration.ToList();
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

            if (this.IpConfigurationBgpPeeringAddresses != null)
            {
                if(vnetGateway.BgpSettings == null)
                {
                    vnetGateway.BgpSettings = new PSBgpSettings();
                }

                if(this.IpConfigurationBgpPeeringAddresses.Any(address => address.CustomBgpIpAddresses == null || !address.CustomBgpIpAddresses.Any()))
                {
                    throw new ArgumentException("if IpConfigurationBgpPeeringAddresses are provided, CustomBgpIpAddresses must be a provided in create gateway");
                }

                vnetGateway.BgpSettings.BgpPeeringAddresses = new List<PSIpConfigurationBgpPeeringAddress>();

                foreach (var address in this.IpConfigurationBgpPeeringAddresses)
                {
                    address.IpconfigurationId = FormatIdBgpPeeringAddresses(address.IpconfigurationId, this.ResourceGroupName, this.Name);
                    vnetGateway.BgpSettings.BgpPeeringAddresses.Add(address);
                }
            }
            else if(vnetGateway.BgpSettings != null)
            {
                vnetGateway.BgpSettings.BgpPeeringAddresses = null;
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

            vnetGateway.VpnGatewayGeneration = MNM.VpnGatewayGeneration.None;
            if (this.VpnGatewayGeneration != null)
            {
                if (GatewayType.Equals(MNM.VirtualNetworkGatewayType.ExpressRoute.ToString(), StringComparison.InvariantCultureIgnoreCase) &&
                    !this.VpnGatewayGeneration.Equals(MNM.VpnGatewayGeneration.None, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Virtual Network Express Route Gateway cannot have any generation other than None.");
                }

                vnetGateway.VpnGatewayGeneration = this.VpnGatewayGeneration;
            }

            if (this.NatRule != null && this.NatRule.Any())
            {
                vnetGateway.NatRules = this.NatRule?.ToList();
            }

            if (this.AdminState != null)
            {
                if (!GatewayType.Equals(MNM.VirtualNetworkGatewayType.ExpressRoute.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new ArgumentException("AdminState parameter is only supported for Express Route gateways.");
                }

                vnetGateway.AdminState = this.AdminState;
            }

			if (this.ResiliencyModel != null)
            {
                if (!GatewayType.Equals(MNM.VirtualNetworkGatewayType.ExpressRoute.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new ArgumentException("ResiliencyModel parameter is only supported for Express Route gateways.");
                }

                vnetGateway.ResiliencyModel = this.ResiliencyModel;
            }

            if (!string.IsNullOrEmpty(this.GatewaySku) && this.GatewaySku.Equals(MNM.VirtualNetworkGatewaySkuTier.ErGwScale))
            {
                if (this.MaxScaleUnit > 0 && this.MinScaleUnit > this.MaxScaleUnit)
                {
                   throw new PSArgumentException(string.Format(Properties.Resources.InvalidAutoScaleConfiguration, this.MinScaleUnit, this.MaxScaleUnit));
                }

                if (this.MaxScaleUnit > 40) {
                   throw new PSArgumentException(Properties.Resources.InvalidAutoScaleConfigurationBounds);          
                }

                vnetGateway.AutoScaleConfiguration = new PSVirtualNetworkGatewayAutoscaleConfiguration();
                vnetGateway.AutoScaleConfiguration.Bounds = new PSVirtualNetworkGatewayPropertiesAutoScaleConfigurationBounds();
                vnetGateway.AutoScaleConfiguration.Bounds.Min = Convert.ToInt32(this.MinScaleUnit);
                vnetGateway.AutoScaleConfiguration.Bounds.Max = (this.MaxScaleUnit > 0) ? Convert.ToInt32(this.MaxScaleUnit) : Convert.ToInt32(this.MinScaleUnit);    
            }
                
            // Set the EnableBgpRouteTranslationForNat, if it is specified by customer.
            vnetGateway.EnableBgpRouteTranslationForNat = EnableBgpRouteTranslationForNat.IsPresent;

            // Map to the sdk object
            var vnetGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            vnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetGatewayModel);

            var getVirtualNetworkGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.Name);

            if (getVirtualNetworkGateway != null && getVirtualNetworkGateway.GatewayType == MNM.VirtualNetworkGatewayType.ExpressRoute.ToString())
            {
                if (getVirtualNetworkGateway.ResiliencyModel != null && getVirtualNetworkGateway.ResiliencyModel.Equals("MultiHomed", StringComparison.InvariantCultureIgnoreCase))
                {
                    WriteWarning("The ExpressRoute Virtual Network Gateway with Resiliency Model as Multi-Homed is required to have connections from two ExpressRoute circuits in different peering locations or " +
                        "a single connection with a circuit in metro location. Connectivity on the Virtual Network Gateway will be disabled until the required number of connections are created.");
                }
            }
            return getVirtualNetworkGateway;
        }
    }
}
