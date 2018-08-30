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

    [Cmdlet(VerbsCommon.Remove,
        "AzureRmVirtualHub",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzureRmVirtualHubCommand : VirtualHubBaseCmdlet
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
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Alias("VirtualHub")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The Virtual hub object to be modified.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualHub InputObject { get; set; }

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

            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            ConfirmAction(
                    Force.IsPresent,
                    string.Format(Properties.Resources.RemovingResource, this.Name),
                    Properties.Resources.RemoveResourceMessage,
                    this.Name,
                    () =>
                    {
                        this.VirtualHubClient.Delete(this.ResourceGroupName, this.Name);
                        WriteObject(true);
                    });
        }
    }
}
