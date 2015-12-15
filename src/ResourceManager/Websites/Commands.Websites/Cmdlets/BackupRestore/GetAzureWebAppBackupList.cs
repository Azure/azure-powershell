using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    ///     Gets the status of an Azure Web App backup
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRMWebAppBackupList")]
    public class GetAzureWebAppBackupList : WebAppOptionalSlotBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var list = WebsitesClient.ListSiteBackups(ResourceGroupName, Name, Slot).Value;
            WriteObject(list, true);
        }
    }
}