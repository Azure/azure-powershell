using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    [CmdletPreview(KeyVaultEkmConnectionCmdletBase.PrivateLinkPreviewMessage)]
    [Cmdlet(VerbsCommon.New, "AzKeyVaultManagedHsmEkmPrivateEndpoint", SupportsShouldProcess = true, DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmPrivateEndpointOperation))]
    public class NewAzKeyVaultManagedHsmEkmPrivateEndpoint : KeyVaultEkmConnectionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of the outbound EKM private endpoint, containing 1-24 alphanumeric or hyphen characters.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Alias of the proxy's Private Link Service, not its resource ID.")]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkServiceAlias { get; set; }

        [Parameter(HelpMessage = "Message sent to the Private Link Service owner with the connection request.")]
        public string RequestMessage { get; set; }

        [Parameter(HelpMessage = "Return after submitting the operation, without polling or writing an operation result.")]
        public SwitchParameter NoWait { get; set; }

        public override void ExecuteCmdlet()
        {
            NormalizeHsmIdentifier();
            EkmConnectionHelper.ValidatePrivateEndpointName(Name);
            if (string.IsNullOrWhiteSpace(PrivateLinkServiceAlias) || PrivateLinkServiceAlias.Contains("/"))
            {
                throw new AzPSArgumentException("Specify the Private Link Service alias, not a URL or resource ID.", nameof(PrivateLinkServiceAlias));
            }
            if (ShouldProcess(HsmName + "/" + Name, "Create outbound EKM private endpoint"))
            {
                var operation = Track2DataClient.CreateManagedHsmEkmPrivateEndpoint(
                    HsmName, Name, PrivateLinkServiceAlias, RequestMessage, NoWait, CancellationToken);
                if (operation != null)
                {
                    WriteObject(operation);
                }
            }
        }
    }
}