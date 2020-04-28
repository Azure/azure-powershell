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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using System;

    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnSiteLink",
        SupportsShouldProcess = false),
        OutputType(typeof(PSVpnSiteLink))]
    public class NewAzVpnSiteLinkCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "VpnSiteLink Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnSiteLinkIpAddress,
            HelpMessage = "The Next Hop IpAddress.")]
        [ValidateNotNullOrEmpty]
        public string IPAddress { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnSiteLinkFqdn,
            HelpMessage = "The Next Hop Fqdn.")]
        [ValidateNotNullOrEmpty]
        public string Fqdn { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Link Provider Name.")]
        public string LinkProviderName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Link Speed In Mbps.")]
        public uint LinkSpeedInMbps { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The BGP ASN for this VpnSiteLink.")]
        public uint BGPAsn { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The BGP Peering Address for this VpnSiteLink.")]
        public string BGPPeeringAddress { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vpnSiteLink = new PSVpnSiteLink
            {
                Name = this.Name,
            };

            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnSiteLinkIpAddress))
            {
                System.Net.IPAddress ipAddress;
                if (string.IsNullOrWhiteSpace(this.IPAddress) || 
                    !System.Net.IPAddress.TryParse(this.IPAddress, out ipAddress))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidIPAddress);
                }

                vpnSiteLink.IpAddress = this.IPAddress;
                vpnSiteLink.Fqdn = string.Empty;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnSiteLinkFqdn))
            {
                if (string.IsNullOrWhiteSpace(this.Fqdn))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidFqdn);
                }
                vpnSiteLink.Fqdn = this.Fqdn;
                vpnSiteLink.IpAddress = string.Empty;
            }

            if (BGPAsn > 0 || !string.IsNullOrWhiteSpace(BGPPeeringAddress))
            {
                vpnSiteLink.BgpProperties = ValidateAndCreatePSVpnLinkBgpSettings(BGPAsn, BGPPeeringAddress);
            }

            if (LinkSpeedInMbps > 0 || !string.IsNullOrWhiteSpace(LinkProviderName))
            {
                vpnSiteLink.LinkProperties = ValidateAndCreatePSVpnLinkProviderProperties(LinkSpeedInMbps, LinkProviderName);
            }

            WriteObject(vpnSiteLink);
        }

        protected PSVpnLinkBgpSettings ValidateAndCreatePSVpnLinkBgpSettings(uint bgpAsn, string bgpPeeringAddress)
        {
            if ((bgpAsn > 0 && string.IsNullOrWhiteSpace(bgpPeeringAddress)) ||
                (!string.IsNullOrWhiteSpace(bgpPeeringAddress) && bgpAsn == 0))
            {
                throw new PSArgumentException("For a BGP session to be established over IPsec, the VpnSiteLink's ASN and BgpPeeringAddress must both be specified.");
            }

            return new PSVpnLinkBgpSettings
            {
                Asn = bgpAsn,
                BgpPeeringAddress = bgpPeeringAddress
            };
        }

        protected PSVpnLinkProviderProperties ValidateAndCreatePSVpnLinkProviderProperties(uint linkSpeedInMbps, string linkProviderName)
        {
            return new PSVpnLinkProviderProperties
            {
                LinkProviderName = linkProviderName,
                LinkSpeedInMbps = Convert.ToInt32(linkSpeedInMbps)
            };
        }
    }
}
