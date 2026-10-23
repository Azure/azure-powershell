using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    [CmdletPreview(KeyVaultEkmConnectionCmdletBase.PrivateLinkPreviewMessage)]
    [Cmdlet(VerbsCommon.Remove, "AzKeyVaultManagedHsmEkmPrivateEndpoint", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High, DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmPrivateEndpointOperation))]
    public class RemoveAzKeyVaultManagedHsmEkmPrivateEndpoint : KeyVaultEkmConnectionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of the EKM private endpoint to delete. An in-use endpoint cannot be deleted.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Return after submitting the delete operation without polling or writing an operation result.")]
        public SwitchParameter NoWait { get; set; }

        public override void ExecuteCmdlet()
        {
            NormalizeHsmIdentifier();
            EkmConnectionHelper.ValidatePrivateEndpointName(Name);
            if (ShouldProcess(HsmName + "/" + Name, "Delete outbound EKM private endpoint"))
            {
                var operation = Track2DataClient.RemoveManagedHsmEkmPrivateEndpoint(HsmName, Name, NoWait, CancellationToken);
                if (operation != null)
                {
                    WriteObject(operation);
                }
            }
        }
    }
}