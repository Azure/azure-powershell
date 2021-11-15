namespace Microsoft.Azure.Commands.Network.Cortex.VpnConnection
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.Network.Models.Cortex;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnSiteLinkConnectionIkeSa",
        DefaultParameterSetName = "ByName"),
        OutputType(typeof(List<PSVpnSiteLinkConnectionIkeSaMainModeSa>))]
    public class GetAzVpnSiteLinkConnectionIkeSaCommand : VpnLinkConnectionBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("GrandParentName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The Vpn gateway name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VpnGatewayName { get; set; }

        [Alias("ParentName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The Vpn connection name.")]
        [ResourceNameCompleter("Microsoft.Network/connections", "GrandParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string VpnConnectionName { get; set; }

        [Alias("ResourceName", "VpnSiteLinkConnectionName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The Vpn site link connection name.")]
        [ResourceNameCompleter("Microsoft.Network/connections", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VpnSiteLinkConnection")]
        [Parameter(
            ParameterSetName = "ByInputObject",
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Vpn site link connection object.")]
        [ValidateNotNullOrEmpty]
        public PSVpnSiteLinkConnection InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByResourceId",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the Vpn site link connection for which IKE SAs needs to be fetched.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public List<PSVpnSiteLinkConnectionIkeSaMainModeSa> ConvertToPsReadableFormat(string response)
        {
            int startIndex = response.IndexOf("[");
            string jsonArrayResponse = response.Substring(startIndex, response.Length - startIndex - 1);
            var result = JsonConvert.DeserializeObject<List<PSVpnSiteLinkConnectionIkeSaMainModeSa>>(jsonArrayResponse);

            List<PSVpnSiteLinkConnectionIkeSaMainModeSa> psIkeSa = new List<PSVpnSiteLinkConnectionIkeSaMainModeSa>();

            if (result != null)
            {
                foreach (var mmsa in result)
                {
                    PSVpnSiteLinkConnectionIkeSaMainModeSa psMainModeSa = new PSVpnSiteLinkConnectionIkeSaMainModeSa();

                    psMainModeSa.localEndpoint = mmsa.localEndpoint;
                    psMainModeSa.remoteEndpoint = mmsa.remoteEndpoint;
                    psMainModeSa.initiatorCookie = mmsa.initiatorCookie;
                    psMainModeSa.responderCookie = mmsa.responderCookie;
                    psMainModeSa.localUdpEncapsulationPort = mmsa.localUdpEncapsulationPort;
                    psMainModeSa.remoteUdpEncapsulationPort = mmsa.remoteUdpEncapsulationPort;
                    psMainModeSa.encryption = mmsa.encryption;
                    psMainModeSa.integrity = mmsa.integrity;
                    psMainModeSa.dhGroup = mmsa.dhGroup;
                    psMainModeSa.lifeTimeSeconds = mmsa.lifeTimeSeconds;
                    psMainModeSa.isSaInitiator = mmsa.isSaInitiator;
                    psMainModeSa.elapsedTimeInseconds = mmsa.elapsedTimeInseconds;

                    if (mmsa.quickModeSa != null)
                    {
                        foreach (var qmsa in mmsa.quickModeSa)
                        {
                            PSVpnSiteLinkConnectionIkeSaQuickModeSa psQuickModeSa = new PSVpnSiteLinkConnectionIkeSaQuickModeSa();

                            psQuickModeSa.localEndpoint = qmsa.localEndpoint;
                            psQuickModeSa.remoteEndpoint = qmsa.remoteEndpoint;
                            psQuickModeSa.encryption = qmsa.encryption;
                            psQuickModeSa.integrity = qmsa.integrity;
                            psQuickModeSa.pfsGroupId = qmsa.pfsGroupId;
                            psQuickModeSa.inboundSPI = qmsa.inboundSPI;
                            psQuickModeSa.outboundSPI = qmsa.outboundSPI;
                            psQuickModeSa.lifetimeKilobytes = qmsa.lifetimeKilobytes;
                            psQuickModeSa.lifeTimeSeconds = qmsa.lifeTimeSeconds;
                            psQuickModeSa.isSaInitiator = qmsa.isSaInitiator;
                            psQuickModeSa.elapsedTimeInseconds = qmsa.elapsedTimeInseconds;
                            psQuickModeSa.localTrafficSelectors = qmsa.localTrafficSelectors;
                            psQuickModeSa.remoteTrafficSelectors = qmsa.remoteTrafficSelectors;

                            psMainModeSa.quickModeSa.Add(psQuickModeSa);
                        }
                    }
                    psIkeSa.Add(psMainModeSa);
                }
            }

            return psIkeSa;
        }

        public override void Execute()
        {
            var parsedResourceId = new ResourceIdentifier();

            if (!ParameterSetName.Equals("ByName"))
            {
                if (ParameterSetName.Equals("ByResourceId"))
                {
                    parsedResourceId = new ResourceIdentifier(this.ResourceId);
                }
                else if(ParameterSetName.Equals("ByInputObject"))
                {
                    parsedResourceId = new ResourceIdentifier(this.InputObject.Id);
                }

                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                var resources = parsedResourceId.ParentResource.Split(new[] { '/' }, 4, StringSplitOptions.RemoveEmptyEntries);
                this.VpnGatewayName = resources[1];
                this.VpnConnectionName = resources[3];
                this.Name = parsedResourceId.ResourceName;
            }

            base.Execute();

            if (this.IsVpnConnectionPresent(this.ResourceGroupName, this.VpnGatewayName, this.VpnConnectionName))
            {
                this.VpnLinkConnectionClient.GetIkeSas(this.ResourceGroupName, this.VpnGatewayName, this.VpnConnectionName, this.Name);
                string response = this.VpnLinkConnectionClient.GetIkeSas(this.ResourceGroupName, this.VpnGatewayName, this.VpnConnectionName, this.Name);

                WriteObject(this.ConvertToPsReadableFormat(response), true);
            }
            else
            {
                throw new PSArgumentException(Properties.Resources.ResourceNotFound, this.Name);
            }
        }
    }
}
