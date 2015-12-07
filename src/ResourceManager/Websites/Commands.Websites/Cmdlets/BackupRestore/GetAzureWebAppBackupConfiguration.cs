using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Gets the automatic backup configuration for an Azure Web App
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureWebAppBackupConfiguration")]
    public class GetAzureWebAppBackupConfiguration : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        public string Slot { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(WebsitesClient.GetWebAppBackupConfiguration(ResourceGroupName, Name, Slot));
        }
    }
}
