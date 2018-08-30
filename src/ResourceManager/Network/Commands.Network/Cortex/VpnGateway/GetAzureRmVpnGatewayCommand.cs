namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        "AzureRmVpnGateway",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnGateway))]
    public class GetAzureRmVpnGatewayCommand : VpnGatewayBaseCmdlet
    {
        [Alias("ResourceName", "VpnGatewayName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrEmpty(this.Name))
            {
                if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
                {
                    throw new PSArgumentException("ResourceGroupName must be specified if ResourceName is specified.");
                }

                var vpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.Name);
                WriteObject(vpnGateway);
            }
            else
            {
                //// ResourceName has not been specified - List all gateways
                WriteObject(this.ListVpnGateways(this.ResourceGroupName));
            }
        }
    }
}
