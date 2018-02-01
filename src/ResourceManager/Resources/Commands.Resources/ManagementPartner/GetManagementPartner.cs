using System.Management.Automation;
using Microsoft.Azure.Management.ManagementPartner;

namespace Microsoft.Azure.Commands.Resources
{
    [Cmdlet(VerbsCommon.Get, "AzureRmManagementPartner"), OutputType(typeof(PSManagementPartner))]
    public class GetManagementPartner : AzureManagementPartnerCmdletsBase
    {
        [Parameter(Position = 0, Mandatory = false)]
        public string PartnerId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (PartnerId != null)
            {
                var response = new PSManagementPartner(AceProvisioningManagementPartnerApiClient.Partner.GetAsync(PartnerId).Result);
                WriteObject(response);
            }
            else
            {
                var response = new PSManagementPartner(AceProvisioningManagementPartnerApiClient.Partner.GetAsync("").Result);
                WriteObject(response);
            }
        }
    }
}
