using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    [CmdletPreview(KeyVaultEkmConnectionCmdletBase.PrivateLinkPreviewMessage)]
    [Cmdlet(VerbsCommon.Get, "AzKeyVaultManagedHsmEkmPrivateEndpointOperation", DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmPrivateEndpointOperation))]
    public class GetAzKeyVaultManagedHsmEkmPrivateEndpointOperation : KeyVaultEkmConnectionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Job ID returned by an EKM private endpoint operation.")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        public override void ExecuteCmdlet()
        {
            NormalizeHsmIdentifier();
            WriteObject(Track2DataClient.GetManagedHsmEkmPrivateEndpointOperation(HsmName, JobId, CancellationToken));
        }
    }
}