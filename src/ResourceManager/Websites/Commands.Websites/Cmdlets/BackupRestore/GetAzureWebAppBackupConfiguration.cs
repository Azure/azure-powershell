using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    ///     Gets the automatic backup configuration for an Azure Web App
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmWebAppBackupConfiguration")]
    public class GetAzureWebAppBackupConfiguration : WebAppOptionalSlotBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(WebsitesClient.GetWebAppBackupConfiguration(ResourceGroupName, Name, Slot));
        }
    }
}