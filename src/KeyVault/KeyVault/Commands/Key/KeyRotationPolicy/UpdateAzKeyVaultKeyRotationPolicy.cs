using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    /// <summary>
    /// Updates the KeyRotationPolicy for the specified key in Key Vault.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRotationPolicy", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyRotationPolicy))]
    public class UpdateAzKeyVaultKeyRotationPolicy: KeyVaultOnlyKeyCmdletBase
    {
        [Parameter(HelpMessage = "The time span when the key rotation policy will expire. It should be at least 28 days.")]
        public TimeSpan ExpiresIn { get; set; }

        internal override void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;

                if (InputObject.IsHsm)
                {
                    throw new NotImplementedException("Updating key rotation policy on managed HSM is not supported yet");
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
            }
        }

        internal bool ValidateParameter()
        {
            if (null == ExpiresIn || default(TimeSpan) == ExpiresIn)
            {
                WriteWarning("No parameter needs be updated.");
                return false;
            }
            return true;
        }

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            if (!ValidateParameter())
            {
                return;
            };

            WriteObject(this.Track2DataClient.UpdateKeyRotationPolicy(VaultName, Name, ExpiresIn));
        }
    }
}
