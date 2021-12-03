using Microsoft.Azure.Commands.KeyVault.Models;

using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    /// <summary>
    /// Gets the KeyRotationPolicy for the specified key in Key Vault.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRotationPolicy", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyRotationPolicy))]
    public class GetAzKeyVaultKeyRotationPolicy: KeyVaultKeyCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            if (string.IsNullOrEmpty(HsmName))
            {
                WriteObject(this.Track2DataClient.GetKeyRotationPolicy(VaultName, Name));
            }
            else
            {
                WriteObject(this.Track2DataClient.GetManagedHsmKeyRotationPolicy(HsmName, Name));
            }
        }
    }
}
