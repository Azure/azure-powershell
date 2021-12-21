using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key.KeyRotationPolicy
{
    /// <summary>
    /// Get the KeyRotationPolicy for the specified key in Key Vault.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRotation", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class InvokeAzKeyVaultKeyRotation : KeyVaultOnlyKeyCmdletBase
    {
        internal override void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;

                if (InputObject.IsHsm)
                {
                    throw new NotImplementedException("Rotating key on managed HSM is not supported yet");
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
            }

        }

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            ConfirmAction(Name, Properties.Resources.RotateKey, () =>
            {
                WriteObject(this.Track2DataClient.RotateKey(VaultName, Name));
            });
        }
    }
} 