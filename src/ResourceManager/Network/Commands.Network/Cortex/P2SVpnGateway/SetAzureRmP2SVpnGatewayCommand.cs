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
    using System.Linq;

    [Cmdlet(VerbsCommon.Set,
        "AzureRmP2SVpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnGateway))]
    public class SetAzureRmP2SVpnGatewayCommand : P2SVpnGatewayBaseCmdlet
    {
        [Alias("ResourceName", "P2SVpnGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The P2SVpnGateway name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("P2SVpnGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The P2SVpnGateway object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSP2SVpnGateway InputObject { get; set; }

        [Alias("P2SVpnGatewayId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the P2SVpnGateway to be modified.")]
        [ResourceIdCompleter("Microsoft.Network/p2sVpnGateways")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The VirtualWan PSP2SVpnServerConfiguration to be attached to this P2SVpnGateway. ")]
        public PSP2SVpnServerConfiguration P2SVpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S VpnClient AddressPool for this P2SVpnGateway.")]
        [ValidateNotNullOrEmpty]
        public string[] VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The scale unit for this P2SVpnGateway.")]
        public uint VpnGatewayScaleUnit { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnGatewayObject))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnGatewayResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            //// Let's get the existing P2SVpnGateway - this will throw not found if the P2SVpnGateway does not exist
            var existingP2SVpnGateway = this.GetP2SVpnGateway(this.ResourceGroupName, this.Name);

            if (existingP2SVpnGateway == null)
            {
                throw new PSArgumentException("The P2SVpnGateway to modify could not be found");
            }

            //// Modify scale unit if specified
            if (this.VpnGatewayScaleUnit > 0)
            {
                existingP2SVpnGateway.VpnGatewayScaleUnit = Convert.ToInt32(this.VpnGatewayScaleUnit);
            }

            //// Update P2SVpnServerConfiguration to be attached
            existingP2SVpnGateway.P2SVpnServerConfiguration = this.P2SVpnServerConfiguration;

            //// Modify the VpnClientAddressPool if specified
            if (this.VpnClientAddressPool != null)
            {
                existingP2SVpnGateway.VpnClientAddressPool = new PSAddressSpace();
                existingP2SVpnGateway.VpnClientAddressPool.AddressPrefixes = new List<string>(this.VpnClientAddressPool);
            }

            ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(Properties.Resources.SettingResourceMessage, this.Name),
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteObject(this.CreateOrUpdateP2SVpnGateway(this.ResourceGroupName, this.Name, existingP2SVpnGateway, this.Tag));
                    });
        }
    }
}
