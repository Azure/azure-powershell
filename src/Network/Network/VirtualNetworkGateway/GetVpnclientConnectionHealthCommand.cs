using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayVpnclientConnectionHealth", SupportsShouldProcess = true), OutputType(typeof(PSVpnClientConnectionHealthDetail))]
    public class GetVpnclientConnectionHealthCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual network gateway name")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual network gateway resource group's name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            List<PSVpnClientConnectionHealthDetail> vpnclientConnectionHealths = new List<PSVpnClientConnectionHealthDetail>();
            foreach(var h in this.VirtualNetworkGatewayClient.GetVpnclientConnectionHealth(this.ResourceGroupName, this.VirtualNetworkGatewayName).Value)
            {
                vpnclientConnectionHealths.Add(NetworkResourceManagerProfile.Mapper.Map<PSVpnClientConnectionHealthDetail>(h));
            }            
            WriteObject(vpnclientConnectionHealths, true);
        }
    }
}
