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
        "AzureRmVirtualHub",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class NewAzureRmVirtualHubCommand : VirtualHubBaseCmdlet
    {
        [Alias("ResourceName", "VirtualHubName")]
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
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual wan object this hub is linked to.")]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of virtual wan object this hub is linked to.")]
        public string VirtualWanId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address space string for this virtual hub.")]
        [ValidateNotNullOrEmpty]
        public string AddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

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

            if (this.VirtualWan == null)
            {
                if (string.IsNullOrWhiteSpace(this.VirtualWanId))
                {
                    throw new PSArgumentException("A virtual hub cannot be created without a virtual wan");
                }

                var parsedWanResourceId = new ResourceIdentifier(this.VirtualWanId);
                this.VirtualWan = new PSVirtualWan
                {
                    ResourceGroupName = parsedWanResourceId.ResourceGroupName,
                    Name = parsedWanResourceId.ResourceGroupName,
                    Id = this.VirtualWanId
                };
            }

            bool shouldProcess = this.Force.IsPresent;
            if (!shouldProcess)
            {
                shouldProcess = ShouldProcess(this.Name, Properties.Resources.CreatingResourceMessage);
            }

            if (shouldProcess)
            {
                PSVirtualHub virtualHub = new PSVirtualHub
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name,
                    VirtualWan = new MNM.SubResource(this.VirtualWan.Id),
                    AddressPrefix = this.AddressPrefix,
                    Location = this.Location
                };

                virtualHub.HubVirtualNetworkConnections = new List<PSHubVirtualNetworkConnection>();
                if (this.HubVnetConnection != null && this.HubVnetConnection.Any())
                {
                    virtualHub.HubVirtualNetworkConnections.AddRange(this.HubVnetConnection);
                }
                
                WriteObject(this.CreateOrUpdateVirtualHub(
                    this.ResourceGroupName,
                    this.Name,
                    virtualHub,
                    this.Tag));
            }
        }
    }
}
