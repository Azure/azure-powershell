using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Restore an Azure Web App from a backup
    /// </summary>
    [Cmdlet(VerbsData.Restore, "AzureWebApp")]
    public class RestoreAzureWebApp : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The settings for restoring the web app.")]
        [ValidateNotNullOrEmpty]
        public RestoreRequest RestoreSettings { get; set; }
        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WebsitesClient.RestoreSite(ResourceGroupName, Name, Slot, null, RestoreSettings);
        }
    }
}
