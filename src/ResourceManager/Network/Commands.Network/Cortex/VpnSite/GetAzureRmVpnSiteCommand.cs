namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        "AzureRmVpnSite",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnSite))]
    public class GetAzureRmVpnSiteCommand : VpnSiteBaseCmdlet
    {
        [Alias("ResourceName", "VpnSiteName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
                {
                    throw new PSArgumentException("ResourceGroupName must be specified if ResourceName is specified.");
                }

                WriteObject(this.GetVpnSite(this.ResourceGroupName, this.Name));
            }
            else
            {
                //// Resource name has not been specified - list all vpnsites
                WriteObject(this.ListVpnSites(this.ResourceGroupName));
            }
        }
    }
}
