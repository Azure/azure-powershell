using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet("Disconnect", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayVpnConnection", DefaultParameterSetName = "ByFactoryName", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGateway))]
    public class DisconnectVirtualNetworkGatewayVpnConnectionCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.ByFactoryName,
            HelpMessage = "Virtual network gateway name")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualNetworkGatewayName { get; set; }

        [Alias("VirtualNetworkGatewayId")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.ByResourceId,
            HelpMessage = "The resource id of the virtual network gateway Id")]
        public string ResourceId { get; set; }

        [Alias("VirtualNetworkGateway")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = ParameterSetNames.ByFactoryObject,
            HelpMessage = "The virtual network gateway object")]
        public PSVirtualNetworkGateway InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.ByFactoryName,
            HelpMessage = "Virtual network gateway resource group's name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Virtual network gateway Vpn connection Ids, which are returned by getting virtualNetwork gateway Vpn client connection Health")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string[] VpnConnectionIds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObject, StringComparison.OrdinalIgnoreCase))
            {
                VirtualNetworkGatewayName = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                VirtualNetworkGatewayName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();

            if (!IsVirtualNetworkGatewayPresent(ResourceGroupName, VirtualNetworkGatewayName))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var req = new P2SVpnConnectionRequest(new List<string>(VpnConnectionIds));
            this.VirtualNetworkGatewayClient.DisconnectVirtualNetworkGatewayVpnConnections(ResourceGroupName, VirtualNetworkGatewayName, req);
            
            var getVirtualNetworkGateway = this.GetVirtualNetworkGateway(ResourceGroupName, VirtualNetworkGatewayName);
            WriteObject(getVirtualNetworkGateway);
        }
    }
}
