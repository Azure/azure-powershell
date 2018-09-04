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
    using Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        "AzureRmVirtualWanP2SVpnServerConfiguration",
        SupportsShouldProcess = true),
        OutputType(typeof(PSP2SVpnServerConfiguration))]
    public class AddAzureRmVirtualWanP2SVpnServerConfigCommand : VirtualWanBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            HelpMessage = "The name of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        public string VirtualWanName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            HelpMessage = "The Id of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualWans")]
        [ValidateNotNullOrEmpty]
        public string VirtualWanId { get; set; }

        [Alias("ResourceName", "P2SVpnServerConfigurationName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name to be created.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PSP2SVpnServerConfiguration in-memory object.")]
        public PSP2SVpnServerConfiguration P2SVpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to create a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            bool shouldProcess = this.Force.IsPresent;

            if (!shouldProcess)
            {
                shouldProcess = ShouldProcess(this.Name, Properties.Resources.CreatingResourceMessage);
            }

            if (shouldProcess)
            {
                WriteObject(this.CreateP2SVpnServerConfiguration());
            }
        }

        private PSP2SVpnServerConfiguration CreateP2SVpnServerConfiguration()
        {
            if (this.P2SVpnServerConfiguration == null)
            {
                throw new PSArgumentException("P2SVpnServerConfiguration object is null.");
            }

            P2SVpnServerConfiguration.Name = this.Name;

            //// Verify the parent virtual wan exists
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualWanName = this.VirtualWan.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualWanId);
                this.VirtualWanName = parsedResourceId.ResourceName;
            }

            //// At this point, we should have the virtual Wan name resolved. Fail this operation if it is not.
            if (string.IsNullOrWhiteSpace(this.VirtualWanName))
            {
                throw new PSArgumentException("A valid Parent VirtualWan reference is required to create and associate a P2SVpnServerConfiguration.");
            }

            var parentVirtualWan = new VirtualWanBaseCmdlet().GetVirtualWan(this.ResourceGroupName, this.VirtualWanName);

            // Verify if the P2SVpnServerConfiguration already exists in the Parent VirtualWn
            var p2sVpnServerConfig = parentVirtualWan.P2SVpnServerConfigurations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (p2sVpnServerConfig != null)
            {
                throw new ArgumentException("P2SVpnServerConfiguration with the specified name already exists.");
            }

            return this.CreateOrUpdateVirtualWanP2SVpnServerConfiguration(this.ResourceGroupName, parentVirtualWan.Name, this.Name, P2SVpnServerConfiguration);
        }
    }
}
