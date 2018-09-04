namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        "AzureRmP2SVpnGateway",
        SupportsShouldProcess = true),
        OutputType(typeof(PSP2SVpnGateway))]
    public class GetAzureRmP2SVpnGatewayCommand : P2SVpnGatewayBaseCmdlet
    {
        [Alias("ResourceName", "P2SVpnGatewayName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
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
                var p2sVpnGateway = this.GetP2SVpnGateway(this.ResourceGroupName, this.Name);

                WriteObject(p2sVpnGateway);
            }
            else
            {
                // Get the list of all P2SVpnGateways under Resource Group (if specified) else under Subscription
                var psP2SVpnGateways = new List<PSP2SVpnGateway>();
                psP2SVpnGateways = this.ListP2SVpnGateways(this.ResourceGroupName);

                WriteObject(psP2SVpnGateways, true);
            }
        }
    }
}
