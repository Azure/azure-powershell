using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouterPeerLearnedRoute", DefaultParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName), OutputType(typeof(PSPeerRoute))]
    public class GetVirtualRouterPeerLearnedRouteCommand : NetworkBaseCmdlet
    {
        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual router peer resource group's name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual router name")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualRouterName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual router peer name")]
        [ValidateNotNullOrEmpty]
        public virtual string PeerName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual router peer input object.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualRouterPeer InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerInputObject, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                PeerName = resourceInfo.ResourceName;
                VirtualRouterName = resourceInfo.ParentResource;
            }

            List<PSPeerRoute> learnedRoutes = new List<PSPeerRoute>();
            foreach (var route in this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnections.ListLearnedRoutes(this.ResourceGroupName, this.VirtualRouterName, this.PeerName).Value)
            {
                learnedRoutes.Add(NetworkResourceManagerProfile.Mapper.Map<PSPeerRoute>(route));
            }

            WriteObject(learnedRoutes, true);
        }
    }
}