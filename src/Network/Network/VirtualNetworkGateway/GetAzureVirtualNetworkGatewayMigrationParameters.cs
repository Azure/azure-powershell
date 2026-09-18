using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayMigrationParameters"), OutputType(typeof(VirtualNetworkGatewayMigrationParameters))]
    public class GetAzureVirtualNetworkGatewayMigrationParameters : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Virtual Network Gateway Policy Group Member")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Attribute Type of the policy group member.",
            ValueFromPipelineByPropertyName = true)]
        public string AttributeType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Attribute Value")]
        public string AttributeValue { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var policyGroup = new PSVirtualNetworkGatewayPolicyGroupMember();
            policyGroup.Name = this.Name;
            policyGroup.AttributeType = this.AttributeType;
            policyGroup.AttributeValue = this.AttributeValue;
            WriteObject(policyGroup);
        }
    }
}
