namespace Microsoft.Azure.Commands.Network.Cortex.VpnGateway
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
    using System.Linq;

    [Cmdlet(VerbsCommon.Get,
        "AzureRmVpnConnection",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnConnection))]
    public class GetAzureRmVpnConnectionCommand : VpnConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ParentVpnGatewayName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The parent resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ParentResourceName { get; set; }

        [Alias("ResourceName", "VpnConnectionName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                WriteObject(this.GetVpnConnection(this.ResourceGroupName, this.ParentResourceName, this.Name));
            }
            else
            {
                WriteObject(this.ListVpnConnections(this.ResourceGroupName, this.ParentResourceName));
            }
        }
    }
}
