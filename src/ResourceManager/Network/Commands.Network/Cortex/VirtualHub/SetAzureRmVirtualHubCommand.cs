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

    [Cmdlet(VerbsCommon.Set,
        "AzureRmVirtualHub",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class SetAzureRmVirtualHubCommand : VirtualHubBaseCmdlet
    {
        [Alias("ResourceName", "VirtualHubName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VirtualHubId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The resource id of the Virtual hub to be modified.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Alias("VirtualHub")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The Virtual hub object to be modified.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public PSVirtualHub InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The virtual wan object this hub is linked to.")]
        [ResourceGroupCompleter]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            HelpMessage = "The id of virtual wan object this hub is linked to.")]
        [ResourceGroupCompleter]
        public string VirtualWanId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address space string for this virtual hub.")]
        [ResourceGroupCompleter]
        public string AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The hub virtual network connections associated with this Virtual Hub.")]
        [ResourceGroupCompleter]
        public List<PSHubVirtualNetworkConnection> HubVnetConnection { get; set; }

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

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            PSVirtualHub virtualHubToUpdate = this.GetVirtualHub(this.ResourceGroupName, this.Name);

            if (this.VirtualWan != null)
            {
                virtualHubToUpdate.VirtualWan = new MNM.SubResource(this.VirtualWan.Id);
            }
            else if (!string.IsNullOrWhiteSpace(this.VirtualWanId))
            {
                virtualHubToUpdate.VirtualWan = new MNM.SubResource(this.VirtualWanId);
            }

            if (!string.IsNullOrWhiteSpace(this.AddressPrefix))
            {
                virtualHubToUpdate.AddressPrefix = this.AddressPrefix;
            }

            bool shouldProcess = this.Force.IsPresent;
            if (!shouldProcess)
            {
                shouldProcess = ShouldProcess(this.Name, Properties.Resources.CreatingResourceMessage);
            }

            if (shouldProcess)
            {
                if (this.HubVnetConnection != null && this.HubVnetConnection.Any())
                {
                    virtualHubToUpdate.HubVirtualNetworkConnections = new List<PSHubVirtualNetworkConnection>();
                    virtualHubToUpdate.HubVirtualNetworkConnections.AddRange(this.HubVnetConnection);
                }

                WriteObject(this.CreateOrUpdateVirtualHub(
                    this.ResourceGroupName,
                    this.Name,
                    virtualHubToUpdate,
                    this.Tag));
            }
        }
    }
}
