using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    ///     Gets the automatic backup configuration for an Azure Web App
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmWebAppBackupConfiguration"), OutputType(typeof(BackupRequest))]
    public class GetAzureWebAppBackupConfiguration : WebAppOptionalSlotBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(WebsitesClient.GetWebAppBackupConfiguration(ResourceGroupName, Name, Slot));
        }
    }
}