using System.Management.Automation;
using Microsoft.Azure.Management.ManagementPartner;
using PartnerResources = Microsoft.Azure.Commands.Resources.Properties.Resources;


namespace Microsoft.Azure.Commands.Resources
{
    [Cmdlet(VerbsData.Update, "AzureRmManagementPartner", SupportsShouldProcess = true),
     OutputType(typeof(PSManagementPartner))]
    public class UpdateManagementPartner : AzureManagementPartnerCmdletsBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The management partner id")]
        [ValidateNotNull]
        public string PartnerId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Format(PartnerResources.UpdateManagementParnterTarget, PartnerId),
                string.Format(PartnerResources.UpdateManagementParnterAction, PartnerId)))
            {
                var response = new PSManagementPartner(AceProvisioningManagementPartnerApiClient.Partner
                    .UpdateAsync(PartnerId).Result);
                WriteObject(response);
            }
        }
    }
}
