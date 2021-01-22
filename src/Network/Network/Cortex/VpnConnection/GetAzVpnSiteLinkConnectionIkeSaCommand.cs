namespace Microsoft.Azure.Commands.Network.Cortex.VpnConnection
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.Network.Models.Cortex;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
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
    class GetAzVpnSiteLinkConnectionIkeSaCommand : NetworkBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VpnGatewayName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The Vpn gateway name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string GrandParentResourceName { get; set; }

        [Alias("VpnConnectionName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The Vpn connection name.")]
        [ResourceNameCompleter("Microsoft.Network/connections", "GrandParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("VpnSiteLinkConnectionName")]
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
        public PSVpnSiteLinkConnection VpnSiteLinkConnection { get; set; }

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
            if (ParameterSetName.Equals("ByInputObject"))
            {
                //this.ResourceGroupName = this.InputObject.ResourceGroupName;
                //this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals("ByResourceId"))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.GrandParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).First();
                    this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    this.Name = parsedResourceId.ResourceName;
                }
            }

            base.Execute();

            if (true)
            {
                /*
                 * Update SDK and nuget packages and then call GetIkeSas()
                 */
            }
        }
    }
}
