using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.WebApps.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Deletes an Azure Web App backup
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRMWebAppBackup")]
    public class RemoveAzureWebAppBackup : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AppName { get; set; }
        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The id of the backup.")]
        [ValidateNotNullOrEmpty]
        public string BackupId { get; set; }
        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(WebsitesClient.DeleteBackup(ResourceGroupName, Name, Slot, BackupId));
        }
    }
}
