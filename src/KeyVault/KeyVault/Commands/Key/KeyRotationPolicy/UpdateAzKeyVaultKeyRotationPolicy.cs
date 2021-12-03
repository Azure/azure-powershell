using Microsoft.Azure.Commands.KeyVault.Models;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    /// <summary>
    /// Updates the KeyRotationPolicy for the specified key in Key Vault.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRotationPolicy", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyRotationPolicy))]
    public class UpdateAzKeyVaultKeyRotationPolicy: KeyVaultKeyCmdletBase
    {
        [Parameter(HelpMessage = "ExpiresIn time.")]
        public TimeSpan ExpiresIn { get; set; }

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            if (string.IsNullOrEmpty(HsmName))
            {
                WriteObject(this.Track2DataClient.UpdateKeyRotationPolicy(VaultName, Name, ExpiresIn));
            }
            else
            {
                WriteObject(this.Track2DataClient.UpdateManagedHsmKeyRotationPolicy(HsmName, Name, ExpiresIn));
            }
        }
    }
}
