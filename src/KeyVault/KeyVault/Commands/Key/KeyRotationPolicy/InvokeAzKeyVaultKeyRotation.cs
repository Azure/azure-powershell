using Microsoft.Azure.Commands.KeyVault.Models;

using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key.KeyRotationPolicy
{
    /// <summary>
    /// Get the KeyRotationPolicy for the specified key in Key Vault.
    /// </summary>
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRotation", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class InvokeAzKeyVaultKeyRotation : KeyVaultKeyCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            if (string.IsNullOrEmpty(HsmName))
            {
                WriteObject(this.Track2DataClient.RotateKey(VaultName, Name));
            }
            else
            {
                WriteObject(this.Track2DataClient.RotateManagedHsmKey(HsmName, Name));
            }
        }
    }
} 