using System.Management.Automation;
using Microsoft.Azure.Management.ManagementPartner;
using PartnerResources = Microsoft.Azure.Commands.Resources.Properties.Resources;


namespace Microsoft.Azure.Commands.Resources
{
    [Cmdlet(VerbsCommon.New, "AzureRmManagementPartner", SupportsShouldProcess = true), OutputType(typeof(PSManagementPartner))]
    public class NewManagementPartner:AzureManagementPartnerCmdletsBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The management partner id")]
        [ValidateNotNull]
        public string PartnerId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Format(PartnerResources.NewManagementParnterTarget, PartnerId),
                string.Format(PartnerResources.NewManagementParnterAction,PartnerId)))
            {
                var response = new PSManagementPartner(AceProvisioningManagementPartnerApiClient.Partner
                    .CreateAsync(PartnerId).Result);
                WriteObject(response);
            }
        }
    }
}
