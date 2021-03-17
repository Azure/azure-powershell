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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.Network.VirtualNetworkGateway;
using Microsoft.WindowsAzure.Commands.Common;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;
using System.Collections;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGateway", DefaultParameterSetName = VirtualNetworkGatewayParameterSets.Default, SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGateway))]
    public class SetAzureVirtualNetworkGatewayCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateway object to base modifications off of. This can be retrieved using Get-AzVirtualNetworkGateway")]
        public PSVirtualNetworkGateway VirtualNetworkGateway { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network gateway's SKU")]
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
            IgnoreCase = true)]
        public string GatewaySku { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The default site to use for force tunneling. If a default site is specified, all internet traffic from the gateway's vnet is routed to that site.")]
        public PSLocalNetworkGateway GatewayDefaultSite { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address space to allocate VPN client IP addresses from. This should not overlap with virtual network or on-premise ranges.")]
        [ValidateNotNullOrEmpty]
        public string[] VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A list of P2S VPN client tunneling protocols")]
        [ValidateSet(
            MNM.VpnClientProtocol.SSTP,
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
            HelpMessage = "A list of VPN client root certificates to use for VPN client authentication. Connecting VPN clients must present certificates generated from one of these root certificates.")]
        public PSVpnClientRootCertificate[] VpnClientRootCertificates { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A list of revoked VPN client certificates. A VPN client presenting a certificate that matches one of these will be told to go away.")]
        public PSVpnClientRevokedCertificate[] VpnClientRevokedCertificates { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "A list of IPSec policies for P2S VPN client tunneling protocols.")]
        public PSIpsecPolicy[] VpnClientIpsecPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network gateway's ASN, used to set up BGP sessions inside IPsec tunnels")]
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
            HelpMessage = "Flag to enable Active Active feature on virtual network gateway")]
        public SwitchParameter EnableActiveActiveFeature { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable Active Active feature on virtual network gateway")]
        public bool? EnablePrivateIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to disable Active Active feature on virtual network gateway")]
        public SwitchParameter DisableActiveActiveFeature { get; set; }

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
            HelpMessage = "P2S multiple external Radius servers.")]
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
            HelpMessage = "Flag to remove AAD authentication for P2S client from virtual network gateway.")]
        public SwitchParameter RemoveAadAuthentication { get; set; }

        [Parameter(
                    Mandatory = false,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "Custom routes AddressPool specified by customer")]
        public string[] CustomRoute { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.UpdateResourceWithTags,
            HelpMessage = "P2S External Radius server address.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsVirtualNetworkGatewayPresent(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name))
            {
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.VirtualNetworkGateway.Name));
            }

            if (this.EnableActiveActiveFeature.IsPresent && this.DisableActiveActiveFeature.IsPresent)
            {
                throw new ArgumentException("Both EnableActiveActiveFeature and DisableActiveActiveFeature Parameters can not be passed.");
            }

            if (this.EnableActiveActiveFeature.IsPresent)
            {
                this.VirtualNetworkGateway.ActiveActive = true;
            }

            if (this.DisableActiveActiveFeature.IsPresent)
            {
                this.VirtualNetworkGateway.ActiveActive = false;
            }

            if (this.EnablePrivateIpAddress.HasValue)
            {
                this.VirtualNetworkGateway.EnablePrivateIpAddress = this.EnablePrivateIpAddress.Value;
            }

            if (!string.IsNullOrEmpty(GatewaySku))
            {
                this.VirtualNetworkGateway.Sku = new PSVirtualNetworkGatewaySku();
                this.VirtualNetworkGateway.Sku.Tier = this.GatewaySku;
                this.VirtualNetworkGateway.Sku.Name = this.GatewaySku;
            }

            if (this.VirtualNetworkGateway.ActiveActive && !this.VirtualNetworkGateway.VpnType.Equals(MNM.VpnType.RouteBased))
            {
                throw new ArgumentException("Virtual Network Gateway VpnType should be " + MNM.VpnType.RouteBased + " when Active-Active feature flag is set to True.");
            }

            if (this.GatewayDefaultSite != null)
            {
                this.VirtualNetworkGateway.GatewayDefaultSite = new PSResourceId();
                this.VirtualNetworkGateway.GatewayDefaultSite.Id = this.GatewayDefaultSite.Id;
            }


            if ((this.VpnClientAddressPool != null ||
                 this.VpnClientRootCertificates != null ||
                 this.VpnClientRevokedCertificates != null ||
                 this.RadiusServerAddress != null ||
                 this.RadiusServerSecret != null ||
                 this.RadiusServerList != null ||
                 (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Length != 0) ||
                 this.AadTenantUri != null) &&
                this.VirtualNetworkGateway.VpnClientConfiguration == null)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration = new PSVpnClientConfiguration();
            }

            if (this.VpnClientAddressPool != null)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientAddressPool = new PSAddressSpace();
                this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes = this.VpnClientAddressPool?.ToList();
            }

            if (this.VpnClientProtocol != null)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientProtocols = this.VpnClientProtocol?.ToList();
            }

            if (this.VpnAuthenticationType != null)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.VpnAuthenticationTypes = this.VpnAuthenticationType?.ToList();
            }

            if (this.VpnClientRootCertificates != null)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientRootCertificates = this.VpnClientRootCertificates?.ToList();
            }

            if (this.VpnClientRevokedCertificates != null)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientRevokedCertificates = this.VpnClientRevokedCertificates?.ToList();
            }

            if (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Length != 0)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientIpsecPolicies = this.VpnClientIpsecPolicy?.ToList();
            }

            if (!string.IsNullOrEmpty(this.RadiusServerAddress) &&
                (this.RadiusServerList != null && this.RadiusServerList.Any()))
            {
                throw new ArgumentException("Cannot configure both singular radius server and multiple radius servers at the same time.");
            }

            if (!string.IsNullOrEmpty(this.RadiusServerAddress) && this.RadiusServerSecret != null && !string.IsNullOrEmpty(SecureStringExtensions.ConvertToString(this.RadiusServerSecret)))
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServerAddress = this.RadiusServerAddress;
                this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServerSecret = SecureStringExtensions.ConvertToString(this.RadiusServerSecret);
                this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServers = null;
            }

            if (this.RadiusServerList != null && this.RadiusServerList.Any())
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServers = this.RadiusServerList?.ToList();
                this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServerAddress = null;
                this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServerSecret = null;
            }

            if (this.AadTenantUri != null || this.AadIssuerUri != null || this.AadAudienceId != null)
            {
                if (this.AadTenantUri == null || this.AadIssuerUri == null || this.AadAudienceId == null)
                {
                    throw new ArgumentException("AadTenantUri, AadIssuerUri and AadAudienceId must be specified if AAD authentication is being configured for P2S.");
                }

                if (this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientProtocols.Count() == 1 && 
                    this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientProtocols.First().Equals(MNM.VpnClientProtocol.OpenVPN))
                {
                    this.VirtualNetworkGateway.VpnClientConfiguration.AadTenant = this.AadTenantUri;
                    this.VirtualNetworkGateway.VpnClientConfiguration.AadIssuer = this.AadIssuerUri;
                    this.VirtualNetworkGateway.VpnClientConfiguration.AadAudience = this.AadAudienceId;
                }
                else
                {
                    throw new ArgumentException("Virtual Network Gateway VpnClientProtocol should be :" + MNM.VpnClientProtocol.OpenVPN + " when P2S AAD authentication is being configured.");
                }
            }

            if (this.RemoveAadAuthentication.IsPresent)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.AadTenant = null;
                this.VirtualNetworkGateway.VpnClientConfiguration.AadIssuer = null;
                this.VirtualNetworkGateway.VpnClientConfiguration.AadAudience = null;
            }

            if (this.VirtualNetworkGateway.VpnClientConfiguration?.VpnAuthenticationTypes != null && this.VirtualNetworkGateway.VpnClientConfiguration.VpnAuthenticationTypes.Count() > 0)
            {
                
                if (!this.VirtualNetworkGateway.VpnClientConfiguration.VpnAuthenticationTypes.Contains(MNM.VpnAuthenticationType.AAD))
                {
                    this.VirtualNetworkGateway.VpnClientConfiguration.AadTenant = string.Empty;
                    this.VirtualNetworkGateway.VpnClientConfiguration.AadIssuer = string.Empty;
                    this.VirtualNetworkGateway.VpnClientConfiguration.AadAudience = string.Empty;
                }

                if (!this.VirtualNetworkGateway.VpnClientConfiguration.VpnAuthenticationTypes.Contains(MNM.VpnAuthenticationType.Radius))
                {
                    this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServers = new List<PSRadiusServer>();
                    this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServerAddress = string.Empty;
                    this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServerSecret = string.Empty;
                }

                if (!this.VirtualNetworkGateway.VpnClientConfiguration.VpnAuthenticationTypes.Contains(MNM.VpnAuthenticationType.Certificate))
                {
                    this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientRevokedCertificates = new List<PSVpnClientRevokedCertificate>();
                    this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientRootCertificates = new List<PSVpnClientRootCertificate>();
                }
                
            }

            if ((this.Asn > 0 || this.PeerWeight > 0) && this.VirtualNetworkGateway.BgpSettings == null)
            {
                this.VirtualNetworkGateway.BgpSettings = new PSBgpSettings();
                this.VirtualNetworkGateway.BgpSettings.BgpPeeringAddress = null; // The gateway's BGP peering address (private IP address assigned within the vnet) can't be changed
            }

            if (this.Asn > 0)
            {
                this.VirtualNetworkGateway.BgpSettings.Asn = this.Asn;
            }

            if (this.PeerWeight > 0)
            {
                this.VirtualNetworkGateway.BgpSettings.PeerWeight = this.PeerWeight;
            }
            else if (this.PeerWeight < 0)
            {
                throw new ArgumentException("PeerWeight must be a positive integer");
            }

            if(this.IpConfigurationBgpPeeringAddresses != null)
            {
               if(this.VirtualNetworkGateway.BgpSettings == null)
               {
                    this.VirtualNetworkGateway.BgpSettings = new PSBgpSettings();
               }

               if (this.VirtualNetworkGateway.BgpSettings.BgpPeeringAddresses == null)
               {
                    this.VirtualNetworkGateway.BgpSettings.BgpPeeringAddresses = new List<PSIpConfigurationBgpPeeringAddress>();

                    foreach (var address in this.IpConfigurationBgpPeeringAddresses)
                    {
                        this.VirtualNetworkGateway.BgpSettings.BgpPeeringAddresses.Add(address);
                    }
               }
               else
               {
                    foreach (var address in this.IpConfigurationBgpPeeringAddresses)
                    {
                        bool isGatewayIpConfigurationExists = this.VirtualNetworkGateway.BgpSettings.BgpPeeringAddresses.Any(
                        ipconfaddress => ipconfaddress.IpconfigurationId.Equals(address.IpconfigurationId, StringComparison.OrdinalIgnoreCase));

                        if(isGatewayIpConfigurationExists)
                        {
                            var bgpPeeringPropertiesInRequest = this.VirtualNetworkGateway.BgpSettings.BgpPeeringAddresses.FirstOrDefault(
                                x => x.IpconfigurationId.Equals(address.IpconfigurationId, StringComparison.OrdinalIgnoreCase));

                            bgpPeeringPropertiesInRequest.CustomBgpIpAddresses = address.CustomBgpIpAddresses;
                        }
                        else
                        {
                            this.VirtualNetworkGateway.BgpSettings.BgpPeeringAddresses.Add(address);
                        }
                    }
               }
            }

            if (this.CustomRoute != null && this.CustomRoute.Any())
            {
                this.VirtualNetworkGateway.CustomRoutes = new PSAddressSpace();
                this.VirtualNetworkGateway.CustomRoutes.AddressPrefixes = this.CustomRoute?.ToList();
            }
            else
            {
                this.VirtualNetworkGateway.CustomRoutes = null;
            }

            // Map to the sdk object
            MNM.VirtualNetworkGateway sdkVirtualNetworkGateway = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkGateway>(this.VirtualNetworkGateway);
            sdkVirtualNetworkGateway.Tags =
                ParameterSetName.Contains(VirtualNetworkGatewayParameterSets.UpdateResourceWithTags) ?
                TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true) :
                TagsConversionHelper.CreateTagDictionary(this.VirtualNetworkGateway.Tag, validate: true);

            string shouldProcessMessage = string.Format("Execute AzureRmVirtualNetworkGateway for ResourceGroupName {0} VirtualNetworkGateway {1}", this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name);
            if (ShouldProcess(shouldProcessMessage, VerbsCommon.Set))
            {
                this.VirtualNetworkGatewayClient.CreateOrUpdate(this.VirtualNetworkGateway.ResourceGroupName,
                    this.VirtualNetworkGateway.Name, sdkVirtualNetworkGateway);

                var getVirtualNetworkGateway =
                    this.GetVirtualNetworkGateway(this.VirtualNetworkGateway.ResourceGroupName,
                        this.VirtualNetworkGateway.Name);

                WriteObject(getVirtualNetworkGateway);
            }
        }
    }
}
