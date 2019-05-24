using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayVpnClientConnectionHealth", DefaultParameterSetName = "ByFactoryName", SupportsShouldProcess = true), OutputType(typeof(PSVpnClientConnectionHealthDetail))]
    public class GetVpnclientConnectionHealthCommand : VirtualNetworkGatewayBaseCmdlet
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
            HelpMessage = "The resource id of the virtual network gateway object")]
        public string ResourceId { get; set; }

        [Alias("VirtualNetworkGateway")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = ParameterSetNames.ByFactoryObject,
            HelpMessage = "The virtual network gateway object to update.")]
        public PSVirtualNetworkGateway InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParameterSetNames.ByFactoryName,
            HelpMessage = "Virtual network gateway resource group's name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

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

            List<PSVpnClientConnectionHealthDetail> vpnclientConnectionHealths = new List<PSVpnClientConnectionHealthDetail>();
            foreach(var h in VirtualNetworkGatewayClient.GetVpnclientConnectionHealth(ResourceGroupName, VirtualNetworkGatewayName).Value)
            {
                vpnclientConnectionHealths.Add(NetworkResourceManagerProfile.Mapper.Map<PSVpnClientConnectionHealthDetail>(h));
            }            
            WriteObject(vpnclientConnectionHealths, true);
        }
    }
}
