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

        /// <summary>
        /// Gets or sets the force parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string confirmMessage  = string.Format(PartnerResources.AddManagementParnter, PartnerId);
          
            ConfirmAction(
                Force,
                confirmMessage,
                PartnerResources.AddManagementParnter,
                PartnerId,
                () =>
                {
                    var response = new PSManagementPartner(AceProvisioningManagementPartnerApiClient.Partner.CreateAsync(PartnerId).Result);
                    WriteObject(response);
                });
        }
    }
}
