using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    [CmdletPreview(KeyVaultEkmConnectionCmdletBase.PrivateLinkPreviewMessage)]
    [Cmdlet(VerbsCommon.Get, "AzKeyVaultManagedHsmEkmPrivateEndpoint", DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmPrivateEndpoint))]
    public class GetAzKeyVaultManagedHsmEkmPrivateEndpoint : KeyVaultEkmConnectionCmdletBase
    {
        [Parameter(HelpMessage = "Name of one EKM private endpoint. Omit to list all endpoints on the HSM.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            NormalizeHsmIdentifier();
            if (Name != null)
            {
                EkmConnectionHelper.ValidatePrivateEndpointName(Name);
            }
            WriteObject(Track2DataClient.GetManagedHsmEkmPrivateEndpoint(HsmName, Name, CancellationToken), true);
        }
    }
}