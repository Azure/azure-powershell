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
        "AzureRmVpnSite",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnSiteName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzureRmVpnSiteCommand : VpnSiteBaseCmdlet
    {
        [Alias("ResourceName", "VpnSiteName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName,
            Mandatory = true,
            HelpMessage = "The vpnSite name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VpnSite")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpnSite object to be deleted.")]
        [ValidateNotNullOrEmpty]
        public PSVpnSite InputObject { get; set; }

        [Alias("VpnSiteId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnSiteResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the vpnSite to be deleted.")]
        [ResourceIdCompleter("Microsoft.Network/vpnSites")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnSiteObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnSiteResourceId, StringComparison.OrdinalIgnoreCase))
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
                        this.VpnSiteClient.Delete(this.ResourceGroupName, this.Name);
                        WriteObject(true);
                    });
        }
    }
}
