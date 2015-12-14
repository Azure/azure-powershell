using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Gets the status of an Azure Web App backup
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRMWebAppBackup")]
    public class GetAzureWebAppBackupCmdlet : WebAppOptionalSlotBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The id of the backup.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string BackupId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(WebsitesClient.GetSiteBackupStatus(ResourceGroupName, Name, Slot, BackupId));
        }
    }
}
