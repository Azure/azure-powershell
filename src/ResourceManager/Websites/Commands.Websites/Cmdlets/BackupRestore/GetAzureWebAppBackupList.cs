using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Gets the status of an Azure Web App backup
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureWebAppBackupList")]
    public class GetAzureWebAppBackupList : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }
        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        public string Slot { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(WebsitesClient.ListSiteBackups(ResourceGroupName, Name, Slot));
        }
    }
}
