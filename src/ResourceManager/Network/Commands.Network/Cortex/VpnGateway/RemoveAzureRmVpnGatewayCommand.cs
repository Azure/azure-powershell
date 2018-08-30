namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Remove,
        "AzureRmVpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzureRmVpnGatewayCommand : VpnGatewayBaseCmdlet
    {
        [Alias("ResourceName", "VpnGatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The vpnGateway name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VpnGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpnGateway object to be deleted.")]
        [ValidateNotNullOrEmpty]
        public PSVpnGateway InputObject { get; set; }

        [Alias("vpnGatewayId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId,
            Mandatory = true,
            HelpMessage = "The Azure resource ID for the vpnGateway to be deleted.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/vpnGateways")]
        public string ResourceId { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(Properties.Resources.RemovingResource, this.Name),
                    Properties.Resources.RemoveResourceMessage,
                    this.Name,
                    () =>
                    {
                        this.VpnGatewayClient.Delete(this.ResourceGroupName, this.Name);
                        WriteObject(true);
                    });
        }
    }
}
