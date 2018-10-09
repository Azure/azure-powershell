using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Reset", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayVpnClientSharedKey")]
    public class ResetAzureVirtualNetworkGatewayVpnClientSharedKey : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetworkGateway")]
        [ValidateNotNull]
        public PSVirtualNetworkGateway VirtualNetworkGateway { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!this.IsVirtualNetworkGatewayPresent(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            this.VirtualNetworkGatewayClient.ResetVpnClientSharedKey(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name);
        }
    }
}