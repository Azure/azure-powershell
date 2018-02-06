using System.Management.Automation;
using Microsoft.Azure.Management.ManagementPartner;
using PartnerResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmManagementPartner", SupportsShouldProcess = true)]
    public class RemoveManagementPartner : AzureManagementPartnerCmdletsBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The management partner id")]
        [ValidateNotNull]
        public string PartnerId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Format(PartnerResources.RemoveManagementParnterTarget, PartnerId),
                string.Format(PartnerResources.RemoveManagementParnterAction, PartnerId)))
            {
                AceProvisioningManagementPartnerApiClient.Partner.DeleteAsync(PartnerId).Wait();
                WriteObject(string.Format(PartnerResources.RemovedManagementPartner, PartnerId));
            }
        }
    }
}
