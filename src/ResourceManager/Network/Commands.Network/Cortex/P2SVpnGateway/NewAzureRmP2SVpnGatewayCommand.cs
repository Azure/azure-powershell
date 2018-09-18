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
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        "AzureRmP2sVpnGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSP2SVpnGateway))]
    public class NewAzureRmP2sVpnGatewayCommand : P2sVpnGatewayBaseCmdlet
    {
        [Alias("ResourceName", "P2SVpnGatewayName")]
        [Parameter(
            Mandatory = true,
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

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource location.")]
        [LocationCompleter]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The scale unit for this P2SVpnGateway.")]
        public uint VpnGatewayScaleUnit { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The VirtualHub this P2SVpnGateway needs to be associated with.")]
        public PSVirtualHub VirtualHub { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The Id of the VirtualHub this P2SVpnGateway needs to be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        [ValidateNotNullOrEmpty]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The name of the VirtualHub this P2SVpnGateway needs to be associated with.")]
        public string VirtualHubName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The VirtualWan PSP2SVpnServerConfiguration to be attached to this P2SVpnGateway. This is optional parameter.")]
        public PSP2SVpnServerConfiguration P2SVpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "P2S VpnClient AddressPool for this P2SVpnGateway.")]
        [ValidateNotNullOrEmpty]
        public string[] VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
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

            var p2sVpnGateway = new PSP2SVpnGateway();
            p2sVpnGateway.Name = this.Name;
            p2sVpnGateway.ResourceGroupName = this.ResourceGroupName;
            p2sVpnGateway.VirtualHub = null;

            //// Resolve and Set the virtual hub
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualHubName = this.VirtualHub.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHubId);
                this.VirtualHubName = parsedResourceId.ResourceName;
            }

            //// At this point, we should have the virtual hub name resolved. Fail this operation if it is not.
            if (string.IsNullOrWhiteSpace(this.VirtualHubName))
            {
                throw new PSArgumentException("A valid VirtualHub reference is required to create a P2SVpnGateway");
            }

            var resolvedVirtualHub = new VirtualHubBaseCmdlet().GetVirtualHub(this.ResourceGroupName, this.VirtualHubName);
            p2sVpnGateway.Location = resolvedVirtualHub.Location;
            p2sVpnGateway.VirtualHub = new PSResourceId() { Id = resolvedVirtualHub.Id };

            //// Set the P2SVpnServerConfiguration
            p2sVpnGateway.P2SVpnServerConfiguration = this.P2SVpnServerConfiguration;

            //// Set the VpnClientAddressPool
            if (this.VpnClientAddressPool == null)
            {
                throw new PSArgumentException("A valid VpnClientAddressPool is required to create a P2SVpnGateway");
            }
            else
            {
                p2sVpnGateway.VpnClientAddressPool = new PSAddressSpace();
                p2sVpnGateway.VpnClientAddressPool.AddressPrefixes = new List<string>(this.VpnClientAddressPool);
            }

            //// Scale unit, if specified
            p2sVpnGateway.VpnGatewayScaleUnit = 0;
            if (this.VpnGatewayScaleUnit > 0)
            {
                p2sVpnGateway.VpnGatewayScaleUnit = Convert.ToInt32(this.VpnGatewayScaleUnit);
            }

            bool shouldProcess = this.Force.IsPresent;

            if (!shouldProcess)
            {
                shouldProcess = ShouldProcess(this.Name, Properties.Resources.CreatingResourceMessage);
            }

            if (shouldProcess)
            {
                WriteObject(this.CreateOrUpdateP2SVpnGateway(this.ResourceGroupName, this.Name, p2sVpnGateway, this.Tag));
            }
        }
    }
}
