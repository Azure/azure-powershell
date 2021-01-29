namespace Microsoft.Azure.Commands.Network
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using System;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using System.Security;
    using Microsoft.WindowsAzure.Commands.Common;
    using System.Linq;

    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnSiteLinkConnection",
        SupportsShouldProcess = false),
        OutputType(typeof(PSVpnSiteLinkConnection))]
    public class NewAzVpnSiteLinkConnectionCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "VpnSiteLinkConnection Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("InputObject")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site link object to connect to.")]
        [ValidateNotNullOrEmpty]
        public PSVpnSiteLink VpnSiteLink { get; set; }

        [Parameter(
                    Mandatory = false,
                    HelpMessage = "The shared key required to set this link connection up.")]
        [ValidateNotNullOrEmpty]
        public SecureString SharedKey { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The bandwidth that needs to be handled by this link connection in mbps.")]
        public uint ConnectionBandwidth { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Routing Weight")]
        public uint RoutingWeight { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "IpSec Policy to be considered for this link connection.")]
        public PSIpsecPolicy IpSecPolicy { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "Gateway connection protocol:IKEv1/IKEv2")]
        [ValidateSet(
            MNM.VirtualNetworkGatewayConnectionProtocol.IKEv1,
            MNM.VirtualNetworkGatewayConnectionProtocol.IKEv2,
            IgnoreCase = true)]
        public string VpnConnectionProtocolType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable BGP for this link connection")]
        public SwitchParameter EnableBgp { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Use local azure ip address as source ip for this link connection.")]
        public SwitchParameter UseLocalAzureIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Use policy based traffic selectors for this link connection.")]
        public SwitchParameter UsePolicyBasedTrafficSelectors { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of ingress NAT rules that are associated with this link Connection.")]
        public PSResourceId[] IngressNatRule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of egress  NAT rules that are associated with this link Connection.")]
        public PSResourceId[] EgressNatRule { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vpnSiteLinkConnection = new PSVpnSiteLinkConnection
            {
                Name = this.Name,
                EnableBgp = this.EnableBgp.IsPresent,
                UseLocalAzureIpAddress = this.UseLocalAzureIpAddress.IsPresent,
                UsePolicyBasedTrafficSelectors = this.UsePolicyBasedTrafficSelectors.IsPresent,
                RoutingWeight = Convert.ToInt32(this.RoutingWeight),
                IngressNatRules = IngressNatRule?.ToList(),
                EgressNatRules = EgressNatRule?.ToList()
            };

            if (this.VpnSiteLink == null)
            {
                throw new PSArgumentException(Properties.Resources.VpnSiteLinkRequiredForVpnSiteLinkConnection);
            }

            vpnSiteLinkConnection.VpnSiteLink = this.VpnSiteLink;

            //// Set the shared key, if specified
            if (this.SharedKey != null)
            {
                vpnSiteLinkConnection.SharedKey = SecureStringExtensions.ConvertToString(this.SharedKey);
            }

            if (!String.IsNullOrEmpty(this.VpnConnectionProtocolType))
            {
                vpnSiteLinkConnection.VpnConnectionProtocolType = this.VpnConnectionProtocolType;
            }

            //// Connection bandwidth
            vpnSiteLinkConnection.ConnectionBandwidth = this.ConnectionBandwidth > 0 ?
                Convert.ToInt32(this.ConnectionBandwidth) :
                20;

            WriteObject(vpnSiteLinkConnection);
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
